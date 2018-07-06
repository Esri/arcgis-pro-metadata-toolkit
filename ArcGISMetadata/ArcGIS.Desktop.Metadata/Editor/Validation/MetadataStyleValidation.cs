/*
COPYRIGHT 1995-2012 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States and applicable international
laws, treaties, and conventions.
 
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts and Legal Services Department
380 New York Street
Redlands, California, 92373
USA
 
email: contracts@esri.com
*/
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows;
using System.Collections;

namespace ArcGIS.Desktop.Metadata.Editor.Validation
{

  #region Metadata Anchor Class

  public class MetadataAnchor
  {

    private string _anchorName;
    private string _xpath;
    private string _expandedName;
    private DependencyObject _source;

    public string Anchor { get { return _anchorName; } }
    public string XPath { get { return _xpath; } }
    public string ExpandedAnchor { get { return _expandedName; } }
    public DependencyObject Source { get { return _source; } }

    public MetadataAnchor(string anchorName, string xpath)
    {
      _anchorName = anchorName;
      _xpath = xpath;
    }

    public MetadataAnchor(string anchorName, string xpath, DependencyObject dp)
    {
      _anchorName = anchorName;
      _xpath = xpath;
      _expandedName = Expand(dp);
      _source = dp;
    }

    private string Expand(DependencyObject dp)
    {
      if (null != _xpath && 0 < _xpath.Length)
      {
        var nodes = Utils.GetXmlDataContext(Utils.GetDataContext(dp));
        if (null == nodes)
          return null;

        foreach (XmlNode node in nodes)
        {
          // get child node
          try
          {
            XmlNode childNode = node.SelectSingleNode(_xpath);

            if (null == childNode)
            {
              return null;
            }
            // get anchor name with qualified indexes
            string anchorName = Utils.GenerateLabel(_anchorName, childNode);
            return anchorName;
          }
          catch (Exception)
          {
            /* noop */
          }

          break; // paranoid
        }
      }
      return null;
    }
  }

  #endregion

  #region Nav Class

  public class Nav
  {

    # region Metadata Anchor Found Event

    public static readonly RoutedEvent MetadataAnchorFoundEvent = EventManager.RegisterRoutedEvent(
        "MetadataAnchorFound",
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(Nav)
    );

    #endregion

    #region Validation Participant Dependency Property

    public static readonly DependencyProperty CheckProperty = DependencyProperty.RegisterAttached(
      "Check",
      typeof(string),
      typeof(Nav),
      new PropertyMetadata(String.Empty, new PropertyChangedCallback(CheckPropertyChanged)));

    public static void SetCheck(UIElement element, string value)
    {
      element.SetValue(CheckProperty, value);
    }
    public static string GetCheck(UIElement element)
    {
      return (string)element.GetValue(CheckProperty);
    }

    private static void CheckPropertyChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
    {
      FrameworkElement fe = element as FrameworkElement;
      if (null == fe)
        return;

      if (null != args.NewValue && 0 < ((string)args.NewValue).Length)
      {
        // get name of anchor
        string checkValue = (string)args.NewValue;

        if ("true".Equals(checkValue, StringComparison.InvariantCultureIgnoreCase))
        {
          fe.Loaded += new RoutedEventHandler(delegate(object sender, RoutedEventArgs rea)
          {
            fe.SetValue(MetadataRules.RulesProperty, MetadataRules.CheckRules);
          });
        }
      }
    }
  
    #endregion

    #region AnchorName Attached Dependency Property

    public static readonly DependencyProperty AnchorNameProperty = DependencyProperty.RegisterAttached(
      "AnchorName",
      typeof(string),
      typeof(Nav),
      new PropertyMetadata(String.Empty, new PropertyChangedCallback(AnchorNamePropertyChanged)));

    public static void SetAnchorName(UIElement element, string value)
    {
      element.SetValue(AnchorNameProperty, value);
    }
    public static string GetAnchorName(UIElement element)
    {
      return (string)element.GetValue(AnchorNameProperty);
    }

    #endregion

    delegate void AddAnchor();
    private static IList<AddAnchor> addAnchors = new List<AddAnchor>();

    public static void FlushAnchors()
    {
      foreach (AddAnchor addAnchor in addAnchors)
        addAnchor();

      // clear it
      addAnchors.Clear();
    }

    public static MetadataAnchor GetAnchorInfo(DependencyObject dp)
    {
      var o = ((DependencyObject)dp).GetValue(Nav.AnchorNameProperty);
      var anchorString = o as string;
  
      // get predicate
      Match match = Regex.Match(anchorString, @"(.*),(.*)");
      if (match.Success)
      {
        if (3 == match.Groups.Count)
        {
          //string m = match.Groups[0].ToString();
          string anchorName = match.Groups[1].ToString();

          // .[grandchild/@id="2.1"] # this is valid xpath
          string xpath = match.Groups[2].ToString();

          return new MetadataAnchor(anchorName, xpath, dp);
        }
      }
      return null;
    }

    private static void AnchorNamePropertyChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
    {
      FrameworkElement fe = element as FrameworkElement;
      if (null == fe)
        return;

      if (null != args.NewValue && 0 < ((string)args.NewValue).Length)
      {
        // get name of anchor
        string anchor = (string)args.NewValue;

        // when this is loaded, add the anchor name
        //
        fe.Loaded += new RoutedEventHandler(delegate(object sender, RoutedEventArgs rea)
        {

          // relative xpath to compute the anchor from
          string relXPath = "."; // default is current node

          // get predicate
          Match match = Regex.Match(anchor, @"(.*),(.*)");
          string shortAnchor = anchor;
          if (match.Success)
          {
            if (3 == match.Groups.Count)
            {
              //string m = match.Groups[0].ToString();
              shortAnchor = match.Groups[1].ToString();

              // .[grandchild/@id="2.1"] # this is valid xpath
              relXPath = match.Groups[2].ToString();
            }
          }

          if (null != relXPath && 0 < relXPath.Length)
          {
            // create anchor and get the expanded name
            var mAnchor = new MetadataAnchor(shortAnchor, relXPath, fe);

            //Utils.AppendLog("Found Anchor: " + mAnchor.ExpandedAnchor + " (" + fe.GetType().ToString() + ")");

            // create event and raise it
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Nav.MetadataAnchorFoundEvent, mAnchor);
            fe.RaiseEvent(newEventArgs);

            // add a check rule if no other rule is present
            var rules = fe.GetValue(MetadataRules.RulesProperty);
            if (null == rules)
            {
              // add check AFTER anchor event has been sent
              fe.SetValue(MetadataRules.RulesProperty, MetadataRules.CheckRules);
            }
          }        
        });
      }
    }
  }

  #endregion

  public class MetadataIssueInfo
  {
    public string Message { get; set; }
    public string IssueType { get; set; }
    public string Name { get; set; }
  }

  /// <summary>
  /// individual metadata validation issue
  /// </summary>
  public class MetadataValidationIssue
  {
    private string _message;

    public bool IsError { get; set; }
     
    public string AnchorName { get; set; }

    public string PageClass { get; set; }

    public string PageName { get; set; }

    public bool IsChildError { get; set; }

    public bool IsSupressMessage { get; set; }

    public string Message
    {
      get
      {
        return _message;
        //var text = (new[] { IssueType, _message }).Where(x => (null != x && 0 < x.Length)).Aggregate(new StringBuilder(), (sb, s) => (sb.Length == 0 ? sb : sb.Append("; ")).Append(s));
        //return text.ToString();
      }

      set
      {
        this._message = value;
      }
    }

    public string TagName { get; set; }

    public string IssueType { get; set; }

    public string Name { get; set; }

    public MetadataValidationIssue(bool isError, string message)
    {
      this.IsError = isError;
      this._message = message;
    }

    public override int GetHashCode()
    {
      if (null != AnchorName)
        return AnchorName.GetHashCode();
      return base.GetHashCode();
    }

    public MetadataValidationIssue(bool isError, string tagName, string issueType, string anchorName, string message, string issueName)
    {
      //if (isError)
      //  Utils.AppendLog("Found Issue: " + anchorName + " (" + tagName + ")");
      this.IsError = isError;
      this.TagName = tagName;
      this.IssueType = issueType;
      this.AnchorName = anchorName;
      //this._pageName = pageName;   
      this._message = message;
      this.Name = issueName;
    }
  }

  /// <summary>
  /// Validate an XML node according to a metadata style configuration page's validation rules
  /// </summary>
  public class MetadataStyleValidation
  {
    delegate void AddIssue(MetadataValidationIssue issue);

    public static void ValidatePage(FrameworkElement xamlPage, XmlNode pageNode, XmlNode sourceNode, IList<MetadataValidationIssue> issues)
    {

      // get page class
      // e.g. "CustomMetadataEditor.Pages.ContentInformation,CustomMetadataEditor"
      XmlAttribute pageClassAtt = pageNode.Attributes["class"];
      if (null == pageClassAtt || 0 == pageClassAtt.Value.Length)
        return;
      string pageClass = pageClassAtt.Value;

      var parts = pageClass.Split(',');
      if (2 == parts.Length)
        pageClass = parts[0];

      // setup
      //
      bool isValidating = false;
      bool isValid = false;
      bool foundIssues = false;

      // delegate to add an issue to the passed collection
      //
      AddIssue addIssue = delegate(MetadataValidationIssue issue)
      {
        // set the class from which the error was generated
        issue.PageClass = pageClass;

        // IF this issue was found on the the current page
        // THEN get more information to display
        //
        if (xamlPage.GetType().ToString().Equals(pageClass))
        {

          // iterate all the resources in the page
          // for all MetadataIssueInfo items
          // check for a matching name
          //
          // else fallback on the resource key
          //

          MetadataIssueInfo mii = null;

          // by resource name
          foreach (DictionaryEntry res in xamlPage.Resources)
          {
            if (res.Value is MetadataIssueInfo)
            {
              MetadataIssueInfo resMi = res.Value as MetadataIssueInfo;
              if (null != resMi.Name)
              {
                if (resMi.Name.Equals(issue.Name))
                {
                  mii = resMi;
                  break;
                }
              }
            }
          }

          // by resource KEY
          if (null == mii && xamlPage.Resources.Contains(issue.TagName)) {
            mii = xamlPage.Resources[issue.TagName] as MetadataIssueInfo;
          }
        
          // add issue
          //
          if (null != mii)
          {
            issue.IssueType = mii.IssueType;
            issue.Message = mii.Message;

            // add the issue to the passed collection
            issues.Add(issue);

            // flag an error has been found
            foundIssues = true;
          }
          else
          {
            // IF key not found
            // THEN supress the message
            issue.IsSupressMessage = true;

            // add the issue to the passed collection
            issues.Add(issue);            

            // flag an error has been found
            foundIssues = true;
          }
        }
        else
        {

          // add the issue to the passed collection
          issues.Add(issue);

          // flag an error has been found
          foundIssues = true;
        }
      };

      // determine 'is validating'
      //
      {
        XmlNode validationNode;
        if (null != (validationNode = pageNode.SelectSingleNode("validation")))
        {
          isValidating = true;
          isValid = ValidateAnd(pageNode.SelectNodes("validation/*"), sourceNode, addIssue);
        }
      }

      // add message is there were no errors
      if (!foundIssues)
      {
        MetadataValidationIssue mvi = new MetadataValidationIssue(false, Internal.Metadata.Properties.Resources.LBL_VALIDATE_NO_ERRORS);
        mvi.PageClass = pageClass;
        issues.Add(mvi);
      }

      // set the 'valid' attribute
      //
      XmlAttribute validAtt = pageNode.Attributes["valid"];
      if (!isValidating)
        validAtt.Value = String.Empty;
      else
        validAtt.Value = (isValid ? "true" : "false");
    }

    private static bool ValidateAnd(XmlNodeList nodeList, XmlNode sourceNode, AddIssue addIssue)
    {
      if (null == nodeList || 0 == nodeList.Count)
        return true; // no rules, then it passes... =P

      bool finalResult = true;

      foreach (XmlNode node in nodeList)
      {
        bool result = ValidateNode(node, sourceNode, addIssue);

        // shortcut false
        if (!result)
          finalResult = false;
      }

      return finalResult;
    }

    /// <summary>
    /// exclusive OR
    /// </summary>
    /// <param name="nodeList"></param>
    /// <param name="sourceNode"></param>
    /// <param name="addIssue"></param>
    /// <returns></returns>
    private static bool ValidateXor(XmlNodeList nodeList, XmlNode sourceNode, AddIssue addIssue)
    {
      if (null == nodeList || 0 == nodeList.Count)
        return true; // no rules, then it passes... =P

      bool finalResult = false;
      bool somePass = false;
      int count = 0;

      // local issue container
      IList<MetadataValidationIssue> localIssues = new List<MetadataValidationIssue>();

      // delegate to add an issue to the passed collection
      //
      AddIssue childAddIssue = delegate(MetadataValidationIssue issue)
      {
        localIssues.Add(issue);
      };

      foreach (XmlNode node in nodeList)
      {
        count++;
        bool result = ValidateNode(node, sourceNode, childAddIssue);

        if (result)
          somePass = true;

        // no shortcut false
        if (result && finalResult)
        {
          finalResult = false;
          //addIssue(MakeIssue(node.ParentNode, sourceNode, true));
          break; // short-cut
        }
        else if (result)
        {
          finalResult = true;
        }
      }

      // xor error
      if (somePass && !finalResult)
      {
        CreateAddIssues(nodeList[0].ParentNode, sourceNode, true, addIssue);
        //if (null != issue)
        //  addIssue(issue);
      }

      // individual local errors...
      if (!finalResult)
      {
        foreach (MetadataValidationIssue issue in localIssues)
        {
          addIssue(issue);
        }
      }

      // fall through is FALSE
      return finalResult;
    }

    /// <summary>
    /// exclusive NOR
    /// </summary>
    /// <param name="nodeList"></param>
    /// <param name="sourceNode"></param>
    /// <param name="addIssue"></param>
    /// <returns></returns>
    private static bool ValidateXNor(XmlNodeList nodeList, XmlNode sourceNode, AddIssue addIssue)
    {
      if (null == nodeList || 0 == nodeList.Count)
        return true; // no rules, then it passes... =P

      bool somePass = false;
      bool someFail = false;

      // local issue container
      IList<MetadataValidationIssue> localIssues = new List<MetadataValidationIssue>();

      // delegate to add an issue to the passed collection
      //
      AddIssue childAddIssue = delegate(MetadataValidationIssue issue)
      {
        localIssues.Add(issue);
      };

      foreach (XmlNode node in nodeList)
      {
        bool result = ValidateNode(node, sourceNode, childAddIssue);

        if (result)
          somePass = true;
        else
          someFail = true;
      }

      // xnor error
      if (somePass && someFail)
      {
        CreateAddIssues(nodeList[0].ParentNode, sourceNode, true, addIssue);
        //if (null != issue)
        //  addIssue(issue);
      }

      //// individual local errors...
      //if (!finalResult)
      //{
      //  foreach (MetadataValidationIssue issue in localIssues)
      //  {
      //    addIssue(issue);
      //  }
      //}

      // fall through is FALSE
      return !(somePass && someFail);
    }

    private static bool ValidateOr(XmlNodeList nodeList, XmlNode sourceNode, AddIssue addIssue)
    {
      if (null == nodeList || 0 == nodeList.Count)
        return true; // no rules, then it passes... =P

      bool finalResult = false;

      // local issue container
      IList<MetadataValidationIssue> localIssues = new List<MetadataValidationIssue>();

      // delegate to add an issue to the passed collection
      //
      AddIssue childAddIssue = delegate(MetadataValidationIssue issue)
      {
        localIssues.Add(issue);
      };

      foreach (XmlNode node in nodeList)
      {
        bool result = ValidateNode(node, sourceNode, childAddIssue);

        // no shortcut false
        if (result)
          finalResult = true;
      }

      // only add issues IF it failed
      if (!finalResult)
      {
        CreateAddIssues(nodeList[0].ParentNode, sourceNode, true, addIssue);
      }

      // fall through is FALSE
      return finalResult;
    }

    private static bool ValidateWhen(XmlNode pageNode, XmlNode sourceNode, AddIssue addIssue, bool nest, bool forAll)
    {

      // get xpath attribute
      //
      string xpath = null;

      XmlAttribute xpathAtt = pageNode.Attributes["xpath"];
      if (null != xpathAtt && 0 < xpathAtt.Value.Length)
        xpath = xpathAtt.Value;

      // test xpath
      //
      if (null != xpath)
      {
        try
        {
          bool finalResult = true; // AND
          XmlNodeList nodeList = sourceNode.SelectNodes(xpath);
          if (null != nodeList && 0 < nodeList.Count)
          {
            foreach (XmlNode node in nodeList)
            {

              if (nest)
              {
                if (!ValidateAnd(pageNode.SelectNodes("*"), node, addIssue))
                  finalResult = false;
              }
              else
              {
                if (!ValidateAnd(pageNode.SelectNodes("*"), sourceNode, addIssue))
                  finalResult = false;
              }

              // doing all or just one?
              if (!forAll)
                break;
            }
            return finalResult;
          }
        }
        catch (Exception)
        {
          // noop
        }
      }

      // fall through
      return true;
    }

    /// <summary>
    /// create an issue object from an xml node
    /// </summary>
    /// <param name="node"></param>
    /// <param name="isError"></param>
    /// <returns></returns>
    private static void CreateAddIssues(XmlNode pageNode, XmlNode sourceNode, bool isError, AddIssue addIssue)
    {

      // get message
      string strMsg = String.Empty;

      // get anchor reference
      XmlAttribute errRef = pageNode.Attributes["ref"];
      string strRef = String.Empty;
      if (null != errRef)
        strRef = errRef.Value;

      // get issue type    
      string strType = String.Empty;

      // parse the ref label
      var targets = strRef.Split(' ');
      bool processedFirst = false;

      foreach (var target in targets)
      {
        var parts = target.Split(',');
        switch (parts.Length)
        {
          case 1:
            // create a referencable path based on the source node in the XML hierarchy
            // e.g. Party -> Party[12][2][1]
            //
            var strTag = parts[0];
            strRef = Utils.GenerateLabel(strTag, sourceNode);

            // create issue
            var issue1 = new MetadataValidationIssue(isError, strTag, strType, strRef, strMsg, null);

            // add
            addIssue(issue1);

            break;
          case 2:
          case 3:

            // get xpath
            var xpath = parts[1];
            string strName = null;
            if (3 == parts.Length)
              strName = parts[2];

            // select the subpaths
            var nodeList = sourceNode.SelectNodes(xpath);
            foreach (XmlNode otherNode in nodeList)
            {
              // create a referencable path based on the source node in the XML hierarchy
              // e.g. Party -> Party[12][2][1]
              //
              strTag = parts[0];
              strRef = Utils.GenerateLabel(strTag, otherNode);

              // create issue
              var issue2 = new MetadataValidationIssue(isError, strTag, strType, strRef, strMsg, strName);

              // only the first one is the primary error
              if (processedFirst)
                issue2.IsChildError = true;

              // add
              addIssue(issue2);
            }

            break;
        }

        // set flag
        processedFirst = true;
      }
    }

    private static bool ValidateExists(XmlNode pageNode, XmlNode sourceNode, AddIssue addIssue)
    {

      // get xpath
      //
      string xpath = null;
      string xpathpred = null;
      XmlAttribute xpathAtt = pageNode.Attributes["xpath"];
      if (null == xpathAtt)
        return false;
      xpath = xpathAtt.Value;
      if (null == xpath || 0 == xpath.Length)
        return false;

      // xpaths that start with a paren
      Match match = Regex.Match(xpath, @"^\(");
      if (match.Success)
      {
        //xpath = "self::*" + xpath;
        // do nothing
      }
      else
      {
        // get predicate
        match = Regex.Match(xpath, @"(.*)(\[[^0-9].*$)");
        if (match.Success)
        {
          if (3 == match.Groups.Count)
          {
            xpath = match.Groups[1].ToString();

            // .[grandchild/@id="2.1"] # this is valid xpath
            xpathpred = "self::*" + match.Groups[2].ToString();
          }
        }
      }
    
      // get node list
      XmlNodeList nodeList = null;
      try
      {
        nodeList = sourceNode.SelectNodes(xpath);
      }
      catch (Exception)
      {
        return false;
      }

      if (0 < nodeList.Count && null != xpathpred && 0 < xpathpred.Length)
      {

        bool isOneSuccess = false;
        foreach (XmlNode matchNode in nodeList)
        {

          if (null == xpathpred || 0 == xpathpred.Length)
          {
            // if one is successful, then the entire xpath test is successful
            isOneSuccess = true;
          }
          else
          {
            XmlNodeList predNodeList = null;

            try
            {
              predNodeList = matchNode.SelectNodes(xpathpred);
            }
            catch (Exception)
            {
              // bail, gracefully and covertly...
              return false;
            }

            // test if the prediate is successful...s
            if (null != predNodeList && 0 < predNodeList.Count)
            {
              // if one is successful, then the entire xpath test is successful
              isOneSuccess = true;
            }
          }

        } // end for

        if (!isOneSuccess)
        {
          // make issue with the first parent node matched!

          // FIXME: this doesn't consider repeating elements that may have children that DO validate and DO NOT validate.

          CreateAddIssues(pageNode, nodeList[0], true, addIssue);
          //if (null != mvi)
          //  addIssue(mvi);
          return false;
        }
      }
      else
      {
        if (null == nodeList || 0 == nodeList.Count)
        {
          // TODO: maybe shouldn't even get here...

          // make issue
          CreateAddIssues(pageNode, sourceNode, true, addIssue);
          //if (null != mvi)
          //  addIssue(mvi);
          return false;
        }
      }

      // min
      //
      {
        XmlAttribute minAtt = pageNode.Attributes["min"];
        if (null != minAtt)
        {
          try
          {
            int min = Int32.Parse(minAtt.Value);
            if (nodeList.Count < min)
            {
              CreateAddIssues(pageNode, sourceNode, true, addIssue);
              //if (null != mvi)
              //  addIssue(mvi);
              return false;
            }
          }
          catch (Exception) { /* NOOP */ }
        }
      }

      // max
      //
      {
        XmlAttribute maxAtt = pageNode.Attributes["max"];
        if (null != maxAtt)
        {
          try
          {
            int max = Int32.Parse(maxAtt.Value);
            if (max < nodeList.Count)
            {
              CreateAddIssues(pageNode, sourceNode, true, addIssue);
              //if (null != mvi)
              //  addIssue(mvi);
              return false;
            }
          }
          catch (Exception) { /* NOOP */ }
        }
      }

      // fall through
      return true;
    }

    private static bool ValidateNotExists(XmlNode pageNode, XmlNode sourceNode, AddIssue addIssue)
    {
      return !ValidateExists(pageNode, sourceNode, addIssue);
    }

    private static bool ValidateNot(XmlNode pageNode, XmlNode sourceNode, AddIssue addIssue)
    {
      return !ValidateNode(pageNode, sourceNode, addIssue);
    }

    private static bool ValidateNode(XmlNode pageNode, XmlNode sourceNode, AddIssue addIssue)
    {
      switch (pageNode.LocalName)
      {
        case "not":
          return ValidateNode(pageNode.SelectSingleNode("*[1]"), sourceNode, addIssue);
        case "and":
          return ValidateAnd(pageNode.SelectNodes("*"), sourceNode, addIssue);
        case "or":
          return ValidateOr(pageNode.SelectNodes("*"), sourceNode, addIssue);
        case "xor":
          return ValidateXor(pageNode.SelectNodes("*"), sourceNode, addIssue);
        case "xnor":
          return ValidateXNor(pageNode.SelectNodes("*"), sourceNode, addIssue);
        case "exists":
          return ValidateExists(pageNode, sourceNode, addIssue);
        case "for":
          return ValidateWhen(pageNode, sourceNode, addIssue, true, true);
        case "if":
          return ValidateWhen(pageNode, sourceNode, addIssue, false, true);
        case "if-any":
          return ValidateWhen(pageNode, sourceNode, addIssue, false, false);
        //case "notexists":
        //  return ValidateNotExists(pageNode, sourceNode, addIssue);
        default: /* fall through */
          return false;
      }
    }
  }
}
