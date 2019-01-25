/*
Copyright 2019 Esri
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.​
*/

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Xml.Linq;
using System.Windows.Resources;
using System.Windows;
using System.IO;
using System.Web;
using System.Threading;
using System.Xml;
using System.Windows.Data;
using System.Windows.Controls;
using System.Collections;
using Microsoft.Win32;
using System.Windows.Markup;
using System.Windows.Documents;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Reflection;

using ArcGIS.Desktop.Metadata.Editor.Convert;
using ArcGIS.Desktop.Metadata.Editor;

namespace MetadataToolkit.Utils
{
  internal class Utils
  {
    private static ResourceManager _resourceManager;

    /// <summary>
    /// Get an XML node from the current Data Context
    /// </summary>
    /// <param name="dataContext"></param>
    /// <returns></returns>
    public static IEnumerable<XmlNode> GetXmlDataContext(object dataContext)
    {
      if (null == dataContext)
        return null;

      if (dataContext is XmlNode)
      {
        IList newList = new List<XmlNode>();
        newList.Add(dataContext);
        return newList as IEnumerable<XmlNode>;
      }
      else if (dataContext is IEnumerable)
      {
        return dataContext as IEnumerable<XmlNode>;
      }
      else if (dataContext is XmlDataProvider)
      {
        XmlDataProvider provider = dataContext as XmlDataProvider;
        XmlDocument doc = provider.Document;
        XmlNodeList list = doc.SelectNodes(provider.XPath);
        IList newList = new List<XmlNode>();
        foreach (XmlNode node in list)
        {
          newList.Add(node);
        }
        return newList as IEnumerable<XmlNode>;
      }

      // can't handle it
      return null;
    }

    public static string GetResString(string key)
    {
      if (null == _resourceManager)
        _resourceManager = new ResourceManager("MetadataToolkit.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

      string reslabel = _resourceManager.GetString(key, Thread.CurrentThread.CurrentCulture);
      if (null == reslabel)
        return null;

      reslabel = HttpUtility.HtmlDecode(reslabel);
      return reslabel;
    }

    /// <summary>
    /// Fill an XML Record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="supressAppend"></param>
    public static void FillXml(object sender, bool supressAppend, bool supressFill)
    {
      FillXml(sender, sender, supressAppend, supressFill, null);
    }

    public static void FillXml(object sender, bool supressAppend, bool supressFill, string targetTag)
    {
      FillXml(sender, sender, supressAppend, supressFill, targetTag);
    }
    
    /// <summary>
    /// Fill and XML Record with a target xml provider specified
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="supressAppend"></param>
    /// <param name="targetTag"></param>
    public static void FillXml(object sender, object resourceSource, bool supressAppend, bool supressFill, string targetTag)
    {
      // Construct xml record key
      string resKey = "XmlRecord";

      // Use the parent node of the current data context instead?
      // Tag will be e.g.: HierarchyLevel_Parent
      bool useParent = false;
      bool useGrandparent = false;

      if (null != targetTag)
      {
        if (0 < targetTag.IndexOf('_'))
        {
          string[] parts = targetTag.Split('_');
          targetTag = parts[0];
          if ("Parent".Equals(parts[1], StringComparison.CurrentCultureIgnoreCase))
          {
            useParent = true;
          }
          else if ("Grandparent".Equals(parts[1], StringComparison.CurrentCultureIgnoreCase))
          {
            useGrandparent = true;
          }
        }

        resKey += "_" + targetTag;
      }

      // Calc the data context and get an xml provider from the record key
      object controlDataContext = null;
      XmlDataProvider provider = null;

      if (sender is Button)
      {
        // Data context from control
        System.Windows.FrameworkElement control = sender as System.Windows.FrameworkElement;

        controlDataContext = control.DataContext;
        if (useParent)
          controlDataContext = ((XmlNode)controlDataContext).ParentNode;
        else if (useGrandparent)
          controlDataContext = ((XmlNode)controlDataContext).ParentNode.ParentNode;

        // Xml provider from user control
        System.Windows.FrameworkElement resourceSourceControl = resourceSource as System.Windows.FrameworkElement;
        provider = resourceSourceControl.Resources[resKey] as XmlDataProvider;
      }
      else if (sender is FrameworkElement)
      {
        System.Windows.FrameworkElement control = sender as System.Windows.FrameworkElement;
        provider = control.Resources[resKey] as XmlDataProvider;

        controlDataContext = control.DataContext;
        if (useParent)
          controlDataContext = ((XmlNode)controlDataContext).ParentNode;
        else if (useGrandparent)
          controlDataContext = ((XmlNode)controlDataContext).ParentNode.ParentNode;
      }
      else if (sender is FrameworkContentElement)
      {
        System.Windows.FrameworkContentElement control = sender as System.Windows.FrameworkContentElement;

        controlDataContext = control.DataContext;
        if (useParent)
          controlDataContext = ((XmlNode)controlDataContext).ParentNode;
        else if (useGrandparent)
          controlDataContext = ((XmlNode)controlDataContext).ParentNode.ParentNode;

        System.Windows.FrameworkElement resourceSourceControl = resourceSource as System.Windows.FrameworkElement;
        provider = resourceSourceControl.Resources[resKey] as XmlDataProvider;
      }

      if (null != provider)
      {
        // Get the data context and apply fill to each element
        IEnumerable<XmlNode> data = GetXmlDataContext(controlDataContext); // as IEnumerable<XmlNode>;
        if (null != data && 0 < data.Count())
        {
          foreach (XmlNode node in data)
          {
            // Get the fill-record xml
            XmlNode fillNode = provider.Document.FirstChild;
            CopyElements(node, fillNode, supressAppend, supressFill);
            break;
          }
        }
        else
        {
          // NO-OP
        }
      }
    }

    /// <summary>
    /// Returns the STRING tag of a FrameworkElement or FrameworkContentElement object
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static string GetStringTag(object element)
    {
      if (element is FrameworkElement)
      {
        return ((FrameworkElement)element).Tag as string;
      }
      else if (element is FrameworkContentElement)
      {
        return ((FrameworkContentElement)element).Tag as string;
      }
      return null;
    }

    /// <summary>
    /// Returns the data context for either a framework element or content element
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static object GetDataContext(object element)
    {
      if (element is FrameworkElement)
      {
        return ((FrameworkElement)element).DataContext;
      }
      else if (element is FrameworkContentElement)
      {
        return ((FrameworkContentElement)element).DataContext;
      }
      return null;
    }

    /// <summary>
    /// Recursively interrogate elements from the source XML against an XML fragment 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="fragment"></param>
    /// <param name="supressAppend"></param>
    /// <param name="supressFill"></param>
    public static void CopyElements(XmlNode source, XmlNode fragment, bool supressAppend, bool supressFill)
    {
      // Elements names must match OR match the <ANY> tag
      if (source.LocalName != fragment.LocalName && !("ANY".Equals(fragment.LocalName)))
        return;

      // If not supressing fill and this is a node (not a document), then fill the attributes
      if (!supressFill && null != source.OwnerDocument)
      {
        // Copy attributes of fragment that DON'T exist in the source
        foreach (XmlNode fragAtt in fragment.Attributes)
        {
          if (null == source.Attributes.GetNamedItem(fragAtt.LocalName, fragAtt.NamespaceURI))
          {
            XmlAttribute newSourceAtt = source.OwnerDocument.CreateAttribute(fragAtt.LocalName, fragAtt.NamespaceURI);
            newSourceAtt.Value = fragAtt.Value;
            source.Attributes.SetNamedItem(newSourceAtt);
          }
        }
      }

      // Recurse into the fragments children
      foreach (XmlNode tchild in fragment.ChildNodes)
      {
        if (XmlNodeType.Element != tchild.NodeType)
          continue;

        // Test if the fragment element exists in the data context (source)
        bool found = false;

        if (!supressFill)
        {
          // Recursively copy child elements
          foreach (XmlNode schild in source.ChildNodes)
          {
            if (XmlNodeType.Element != schild.NodeType)
              continue;

            // Identical element?
            if (schild.LocalName == tchild.LocalName)
            {
              CopyElements(schild, tchild, supressAppend, supressFill); // recurse
              found = true;
            }
          }
        }

        // Fill only?
        XmlAttribute fillOnlyNode = tchild.Attributes.GetNamedItem("editorFillOnly") as XmlAttribute;
        bool fillOnly = (null != fillOnlyNode && "true".Equals(fillOnlyNode.Value, StringComparison.InvariantCultureIgnoreCase));

        // IF it existed in the data context (source)
        // AND the fragment is marked for appending,
        // THEN append the fragment
        bool forceappend = false;
        XmlAttribute editorAppendNode = tchild.Attributes.GetNamedItem("editorAppend") as XmlAttribute;
        bool editorAppend = (null != editorAppendNode && "true".Equals(editorAppendNode.Value, StringComparison.InvariantCultureIgnoreCase));

        if (found && editorAppend && !supressAppend)
        {
          // Append new one?
          forceappend = true;
        }

        // IF source node wasn't found with the same local name
        // AND fill only is NOT set
        //
        // ... OR forcing append
        // THEN create a new node
        if ((!found && !fillOnly) || forceappend)
        {
          RecursiveCopy(source, tchild);
        }
      }
    }

    public static void RecursiveCopy(XmlNode sourceParent, XmlNode fragment)
    {
      // Is the fragment node fill only?
      XmlAttribute fillOnlyNode = fragment.Attributes.GetNamedItem("editorFillOnly") as XmlAttribute;
      bool fillOnly = (null != fillOnlyNode && "true".Equals(fillOnlyNode.Value, StringComparison.InvariantCultureIgnoreCase));

      if (fillOnly)
        return; // bail

      // Get source document
      XmlDocument sourceDocument = null;
      if (sourceParent is XmlDocument)
        sourceDocument = sourceParent as XmlDocument;
      else
        sourceDocument = sourceParent.OwnerDocument;

      // Create new element from fragment node
      XmlNode newchild = sourceDocument.CreateElement(fragment.Prefix, fragment.LocalName, fragment.NamespaceURI);

      // Copy attributes from fragment node to new node
      foreach (XmlAttribute at in fragment.Attributes)
      {
        // Create a new attribute in the source document's context
        XmlAttribute newAt = sourceDocument.CreateAttribute(at.Prefix, at.LocalName, at.NamespaceURI);
        newAt.Value = at.Value;
        newchild.Attributes.Append(newAt);
      }

      // Append new child
      sourceParent.AppendChild(newchild);

      // Copy TEXT or CHILD NODES, no mixed-content 
      var childNodes = fragment.SelectNodes("*");
      if (0 == childNodes.Count)
        newchild.InnerText = fragment.InnerText;
      else
      {
        // Recurse into fragment, providing new source and fragment child
        foreach (XmlNode fragChild in fragment.SelectNodes("*"))
          RecursiveCopy(newchild, fragChild);
      }
    }

    /// <summary>
    /// Generate the contacts list
    /// </summary>
    /// <param name="contactsDoc"></param>
    /// <param name="dataContext"></param>
    /// <returns></returns>
    public static XmlNodeList GenerateContactsList(XmlDocument contactsDoc, object dataContext)
    {
      return GenerateContactsDocument(contactsDoc, dataContext)?.SelectNodes("//contact");
    }

    /// <summary>
    /// Generate the contacts document
    /// </summary>
    public static XmlNode GenerateContactsDocument(XmlDocument contactsDoc, object dataContext)
    {
      // New document
      XmlNode contactsNode = null;

      // Attempt read contacts from file
      string path = Utils.GetContactsFileLocation();
      if (null == path || 0 == path.Length)
        return null;

      if (File.Exists(path))
      {
        try
        {
          contactsDoc.Load(path);
          contactsNode = contactsDoc.SelectSingleNode("/contacts");
        }
        catch (Exception) { }
      }

      // Create a new one...
      if (null == contactsNode)
      {
        contactsNode = contactsDoc.CreateElement("contacts");
        contactsDoc.AppendChild(contactsNode);
      }

      // Merge with contacts in the source document    
      var dataContextXml = Utils.GetXmlDataContext(dataContext);
      if (null == dataContextXml)
        return contactsDoc;

      foreach (XmlNode n in dataContextXml)
      {
        var parentNodes = n.SelectNodes("//*[rpIndName | rpOrgName | rpPosName]");
        foreach (XmlNode pn in parentNodes)
        {
          string key = Utils.GeneratePartyKey(pn);

          XmlNode existNode = contactsNode.SelectSingleNode("//editorDigest[.='" + key + "']");
          bool alreadyExists = (null != existNode);
          if (!alreadyExists)
          {

            // Insert the metadata contact into the contact manager xml
            // 1) Remove the "editorSave" element, it will be re-inserted
            // 2) Remove the "editorDigest" element, it will be re-inserted with a fresh value
            // 3) Remove the "editorSource" element
            var editorSaveNode = pn.SelectSingleNode("editorSave");
            if (null != editorSaveNode)
              pn.RemoveChild(editorSaveNode);

            var editorDigestNode = pn.SelectSingleNode("editorDigest");
            if (null != editorDigestNode)
              pn.RemoveChild(editorDigestNode);

            var editorSourceNode = pn.SelectSingleNode("editorSource");
            if (null != editorSourceNode)
              pn.RemoveChild(editorSourceNode);

            // Create contact node
            XmlNode contactNode = contactsNode.OwnerDocument.CreateElement("contact");
            contactNode.InnerXml = pn.InnerXml;

            // Create 'editorSave' attribute
            editorSaveNode = contactsNode.OwnerDocument.CreateElement("editorSave");
            editorSaveNode.InnerText = alreadyExists ? "True" : "False";
            contactNode.AppendChild(editorSaveNode);

            // Add to contacts
            contactsNode.AppendChild(contactNode);
          }
        }

        break; // Only one
      }

      return contactsDoc;
    }

    /// <summary>
    /// Generate a unique key for an ISO party
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static string GeneratePartyKey(XmlNode node)
    {
      StringBuilder sb = new StringBuilder();

      //XmlNodeList list = node.SelectNodes("rpIndName | rpOrgName | rpPosName | role//@value");
      XmlNodeList list = node.SelectNodes("rpIndName | rpOrgName | rpPosName | rpCntInfo/cntAddress/delPoint | rpCntInfo/cntAddress/city | rpCntInfo/cntAddress/adminArea | rpCntInfo/cntAddress/postCode | rpCntInfo/cntAddress/eMailAdd | rpCntInfo/cntAddress/country//@value | rpCntInfo/cntOnlineRes/linkage | rpCntInfo/cntOnlineRes/protocol | rpCntInfo/cntOnlineRes/appProfile | rpCntInfo/cntOnlineRes/orName | rpCntInfo/cntOnlineRes/orDesc | rpCntInfo/cntOnlineRes/orFunct//@value | rpCntInfo/cntPhone/voiceNum | rpCntInfo/cntPhone/faxNum | rpCntInfo/cntHours | rpCntInfo/cntInstr");
      foreach (XmlNode childNode in list)
      {
        sb.Append(childNode.InnerText);
      }

      // Return key
      string digest = GetSHA1Hash(sb.ToString());
      return digest;
    }

    /// <summary>
    /// Extract a label appropriate for a responsible party
    /// </summary>
    /// <param name="el"></param>
    /// <returns></returns>
    static public String ExtractResponsiblePartyLabel(FrameworkElement el, string format)
    {
      IEnumerable<XmlNode> data = GetXmlDataContext(el.DataContext);
      if (null == data)
        return String.Empty;

      foreach (XmlNode root in data)
        return ExtractResponsiblePartyLabel(root, format);

      return String.Empty; // Should never get here
    }

    static public String ExtractResponsiblePartyLabel(XmlNode root, string format)
    {
      var label = "";
      var name = "";
      var organization = "";
      var position = "";

      // Individual
      XmlNode node = root.SelectSingleNode("rpIndName");
      if (null != node && 0 < node.InnerText.Length)
        name = node.InnerText;

      // Organization
      node = root.SelectSingleNode("rpOrgName");
      if (null != node && 0 < node.InnerText.Length)
        organization = node.InnerText;

      // Position
      node = root.SelectSingleNode("rpPosName");
      if (null != node && 0 < node.InnerText.Length)
        position = node.InnerText;

      // Generic label
      if (null != name && 0 < name.Length)
        label = name;
      else if (null != organization && 0 < organization.Length)
        label = organization;
      else if (null != position && 0 < position.Length)
        label = position;

      // Role
      var role = string.Empty;
      var roleLabel = MetadataToolkit.Properties.Resources.LBL_CI_PARTY_ROLE_UNKNOWN;

      node = root.SelectSingleNode("role/RoleCd/@value");
      if (null != node && 0 < node.Value.Length)
      {
        role = node.InnerText;

        // Create codelist
        var codeList = new Codelists();
        codeList.CodelistName = "CI_RoleCode";

        // Get the list and find a codelist item with the same codelist value
        var list = codeList.List as IEnumerable;

        foreach (XmlNode codeNode in list)
        {
          //<code value="001">
          //  <res:CODE_IMS_LIVE_DATA_AND_MAPS/>
          //</code>
          if (role.Equals(codeNode.Attributes["value"].Value))
          {
            roleLabel = codeNode.InnerText;
            break;
          }
        }
      }

      // Format it
      var labelFormatString = format; 
      labelFormatString = labelFormatString.Replace("%NAME%", name);
      labelFormatString = labelFormatString.Replace("%ORG%", organization);
      labelFormatString = labelFormatString.Replace("%POS%", position);
      labelFormatString = labelFormatString.Replace("%LABEL%", label);
      labelFormatString = labelFormatString.Replace("%ROLE%", roleLabel);

      // Return result and break out of loop
      return labelFormatString;
    }

    /// <summary>
    /// Generate an MD5 digest from a string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string GetSHA1Hash(string input)
    {
      // Create a new instance of the MD5CryptoServiceProvider object.
      var sha1Hasher = System.Security.Cryptography.SHA1.Create();

      // Convert the input string to a byte array and compute the hash.
      byte[] data = sha1Hasher.ComputeHash(Encoding.Default.GetBytes(input));

      // Create a new Stringbuilder to collect the bytes and create a string.
      StringBuilder sBuilder = new StringBuilder();

      // Loop through each byte of the hashed data and format each one as a hexadecimal string.
      for (int i = 0; i < data.Length; i++)
        sBuilder.Append(data[i].ToString("x2"));

      // Return the hexadecimal string.
      return sBuilder.ToString();
    }

    public static string GetESRIDocumentsFolder()
    {
      string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ArcGIS\";
      return folder;
    }

    /// <summary>
    /// Get the path of the contacts file
    /// </summary>
    /// <returns></returns>
    public static string GetContactsFileLocation()
    {
      //string path = GetESRIApplicationDataFolder() + activeProduct + arcCatalog + @"\Descriptions\";
      string path = GetESRIDocumentsFolder() + @"Descriptions\";

      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      return path + "contacts.xml";
    }

    /// <summary>
    /// Load a rich text box by converting encoded HTML to XAML
    /// -
    /// Content maybe plain text -OR- GP-style tags
    /// GP-style tags are converted first and are subsequently lost
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="context"></param>
    public static void LoadRichTextbox(object sender, object context)
    {
      IEnumerable<XmlNode> xmlNodes = Utils.GetXmlDataContext(context);
      if (null == xmlNodes)
        return;

      string xaml = null;

      // Load from encoded HTML
      foreach (XmlNode node in xmlNodes)
      {

        string htmlString = "";

        // Check for existing XML child nodes
        XmlNodeList children = node.SelectNodes("*");
        if (null != children && 0 < children.Count)
        {
          string xml = node.InnerXml;

          // Convert
          htmlString = ConvertToolXML(xml);

          // Write back to node the updated encoded xml
          node.InnerText = HttpUtility.HtmlEncode(htmlString);
        }
        else
        {
          // Inside element
          // May be encoded markup
          // InnerText decodes
          htmlString = node.InnerText.Trim();

          if (0 != htmlString.IndexOf("<")) // does NOT have encoded markup
          {
            // Wrap the XML
            // Preserve non-tag entities
            string xmlString = node.InnerXml.Trim();
            htmlString = "<DIV>" + xmlString + "</DIV>";

            // InnerText encodes
            node.InnerText = htmlString;
          }
        }

        // node.InnerText does the decoding for us
        xaml = HtmlToXamlConverter.ConvertHtmlToXaml(node.InnerText, false);

        break; // Only one
      }

      // Now read the new XAML and add to the rich text box
      if (null != xaml && 0 < xaml.Length)
      {
        RichTextBox box = sender as RichTextBox;
        box.Document.Blocks.Clear();

        using (MemoryStream xamlMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xaml)))
        {
          ParserContext parser = new ParserContext();
          parser.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
          parser.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");

          try
          {
            Section section = XamlReader.Load(xamlMemoryStream, parser) as Section;
            box.Document.Blocks.Add(section);
          }
          catch { }
        }
      }
    }

    public static void UnLoadRichTextbox(RichTextBox box, object context, bool encode)
    {
      if (null == context)
        return;

      TextRange tr = new TextRange(box.Document.ContentStart, box.Document.ContentEnd);
      using (MemoryStream ms = new MemoryStream())
      {
        tr.Save(ms, DataFormats.Xaml);

        // Need to explictly create this to force a byte-order-mark
        UTF8Encoding encoder = new UTF8Encoding(true, true);
        string xamlText = encoder.GetString(ms.ToArray());
        var html = HtmlFromXamlConverter.ConvertXamlToHtml(xamlText, false);

        // Test to see if there's anything in the HTML
        string striped = Regex.Replace(html, @"<(.|\n)*?>", "").Trim();
        if (0 == striped.Length)
          html = String.Empty;

        if (context is XmlElement)
        {
          var contextElement = context as XmlElement;
          var oldXml = contextElement.InnerText;
          if (oldXml == html)
            return;
        }

        IEnumerable<XmlNode> xmlNodes = Utils.GetXmlDataContext(context);

        // Load from encoded HTML
        if (null == xmlNodes)
          return;

        foreach (XmlNode node in xmlNodes)
        {
          if (encode)
            node.InnerText = html.Trim(); // encodes automagically
          else
            node.InnerXml = html.Trim();

          break;
        }
      }
    }

    /// <summary>
    /// Convert a gp tool's XML to HTML
    /// </summary>
    /// <param name="xml"></param>
    public static string ConvertToolXML(string xml)
    {
      xml = xml.Replace("<para>", "<P>");
      xml = xml.Replace("</para>", "</P>");

      xml = xml.Replace("<bulletList>", "<UL>");
      xml = xml.Replace("</bulletList>", "</UL>");

      xml = xml.Replace("<bullet_item>", "<LI>");
      xml = xml.Replace("</bullet_item>", "</LI>");

      return xml;
    }

    /// <summary>
    /// Generate a label for references and anchors on the XAML page
    /// </summary>
    /// <param name="anchorBase"></param>
    /// <param name="childNode"></param>
    /// <returns></returns>
    public static string GenerateLabel(string anchorBase, XmlNode childNode)
    {
      // new string builder
      StringBuilder sb = new StringBuilder(anchorBase);

      // if passed a null childNode
      if (null == childNode)
        return anchorBase;

      // get children to start, handles elements and attributes
      XmlNode parentNode = null;
      if (childNode is XmlElement)
        parentNode = childNode.ParentNode;
      else if (childNode is XmlAttribute)
        parentNode = ((XmlAttribute)childNode).OwnerElement;

      // if childNode was a Document
      if (null == parentNode)
        return anchorBase;

      // get children to determine position-index of this childNode
      XmlNodeList children = parentNode.ChildNodes;

      while (null != children && XmlNodeType.Document != parentNode.NodeType)
      {
        int childIndex = 0; // init

        if (childNode is XmlAttribute)
        {
          sb.Append(String.Format("[{0}]", childIndex));
        }
        else
        {
          foreach (XmlNode child in children)
          {
            if (XmlNodeType.Element != child.NodeType)
              continue;

            childIndex++;
            if (child == childNode)
            {
              sb.Append(String.Format("[{0}]", childIndex));
              break;
              //string anchorName = String.Format("{0}[{1}]", anchorBase, childIndex);
              //return anchorName;
            }
          }
        }

        // ascend hierarchy
        childNode = parentNode;
        parentNode = parentNode.ParentNode;
        children = parentNode.ChildNodes;
      }

      return sb.ToString();
    }
  }
}
