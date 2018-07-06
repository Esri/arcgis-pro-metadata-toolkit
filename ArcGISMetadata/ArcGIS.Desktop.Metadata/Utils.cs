using System;
/*
COPYRIGHT 1995-2009 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States.
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts Dept
380 New York Street
Redlands, California, USA 92373
email: contracts@esri.com
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

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Metadata.Editor.Convert;
using ArcGIS.Desktop.Metadata.Editor;
using ArcGIS.Desktop.Internal.Metadata;

namespace ArcGIS.Desktop.Metadata.Editor
{
  internal class Utils
  {
    private static string _INSTALL_DIR = string.Empty;
    private const string ESRI = @"\ESRI\";
    private const string ARCGIS = @"\ArcGIS\";
    private const string DEFAULT_METADATA_STYLE = @"Item Description";
    private static string _currentStyle = string.Empty;

    private static bool _bConfigsLoaded = false;    

    private static int _truncateLength = 0;
    private static ResourceManager _resourceManager;
    private static ResourceManager _defResourceManager;
    private const string UPGRADE_NOTIFICATION_KEY = "ShowUpgradePrompt";

    public static string ArcGISFormatTag = "/metadata/Esri/ArcGISFormat";
    public static string GoodOutdatedEsriContent = "(/metadata/mdLang/languageCode | /metadata/mdChar/CharSetCd | /metadata/mdHrLv/ScopeCd | /metadata/mdHrLvName | /metadata/mdStanName | /metadata/mdStanVer | /metadata/mdFileID | /metadata/mdDateSt | /metadata/mdContact//* | /metadata/mdParentID | /metadata/dataSetURI | /metadata/mdConst//* | /metadata/mdMaint//* | /metadata/dataIdInfo//* | /metadata/distInfo//* | /metadata/spatRepInfo//* | /metadata/dqInfo//* | /metadata/refSysInfo//* | /metadata/mdExtInfo//* | /metadata/svIdInfo//* | /metadata/contInfo//* | /metadata/porCatInfo//* | /metadata/appSchInfo//* | /metadata/loc//*)[not(./@Sync = 'TRUE') and (text() != '' or @value != '')]";
    public static string GoodOutdatedFgdcContent = "(/metadata/idinfo//* | /metadata/metainfo//* | /metadata/dataqual//* | /metadata/spref//* | /metadata/distinfo//*)[not(./@Sync = 'TRUE') and not(./@Sync = 'True') and not(./@Sync = 'true') and not(contains(., 'REQUIRED')) and (./text())]";
    public static string ReallyGoodEsriContent = "(//idPurp | //idAbs | //idCredit | //idCitation/resTitle | //searchKeys/keyword | //resConst/Consts/useLimit)[not(./@Sync = 'TRUE') and not(./@Sync = 'True') and not(./@Sync = 'true') and not(contains(., 'REQUIRED')) and (./text())]";

    public static bool IsValidMetadata(string xml, out string errorMsg)
    {     
      errorMsg = string.Empty;
      XmlDocument document = null;

      //if (xml.Equals("<metadata/>\r\n", StringComparison.CurrentCultureIgnoreCase))
      //{
      //  errorMsg = Internal.Metadata.Properties.Resources.UNQUALIFIED_MD_ROOT_ONLY;
      //  return false;
      //}

      // Load metadata
      try
      {
        document = new XmlDocument();
        document.LoadXml(xml);
      }
      catch (Exception)
      {
        errorMsg = Internal.Metadata.Properties.Resources.ProjectItemNoMetadata;
        return false;
      }

      if (document.SelectSingleNode("/metadata") == null)
      {
        if (document.SelectSingleNode("/HTML") != null || document.SelectSingleNode("/html") != null)  // Check whether it is HTML
        {
          errorMsg = Internal.Metadata.Properties.Resources.UNQUALIFIED_MD_HTML;
          return false;
        }
        else if (xml.IndexOf("<MD_Metadata") >= 0)  // Check whether it is ISO19139
        {
          errorMsg = Internal.Metadata.Properties.Resources.UNQUALIFIED_MD_ISO_19139;
          return false;
        }
        else if (xml.IndexOf("<gmi:MI_Metadata") >= 0)  // Check whether it is ISO19139-2
        {
          errorMsg = Internal.Metadata.Properties.Resources.UNQUALIFIED_MD_ISO_19139_2;
          return false;
        }
        else 
        {
          errorMsg = Internal.Metadata.Properties.Resources.UNQUALIFIED_MD_UNREC_MD;
          return false;
        }
      }
      else
      {
        // We have been upgraded before
        XmlNode node = document.SelectSingleNode(ArcGISFormatTag);
        if (node != null)
          return true;

        XmlNode esriOutdatedNode = document.SelectSingleNode(GoodOutdatedEsriContent);
        XmlNode fgdcOutdatedNode = document.SelectSingleNode(GoodOutdatedFgdcContent);
        if (esriOutdatedNode != null && fgdcOutdatedNode != null)
        {
          errorMsg = Internal.Metadata.Properties.Resources.UNQUALIFIED_MD_OUTDATED_ESRI;
          return false;
        }
        else if (fgdcOutdatedNode != null)
        {
          errorMsg = Internal.Metadata.Properties.Resources.UNQUALIFIED_MD_OUTDATED_FGDC;
          return false;
        }
      }

      return true;
    }

    public static bool IsProjectItem(Core.Item item)
    {
      return (item.Path.StartsWith("CIMPATH=")); 
    }

    /// <summary>
    /// Substitute resource string references in an XML document from the XSLT resource file
    /// </summary>
    /// <param name="document"></param>
    public static void SubstituteXsltResourceStrings(XmlDocument document)
    {
      // substitute resource strings
      XmlNameTable nameTable = document.NameTable;
      XmlNamespaceManager nsMgr = new XmlNamespaceManager(nameTable);
      nsMgr.AddNamespace("res", "http://www.esri.com/metadata/res/");
      XmlNodeList resRefs = document.SelectNodes("//res:*", nsMgr);

      foreach (XmlNode node in resRefs)
      {
        string localName = node.LocalName;
        string lookup = XsltExtensionFunctions.GetResString(localName);
        if (null == lookup)
        {
          lookup = Internal.Metadata.Properties.Resources.XSLT_RES_NOTFOUND;
        }

        XmlNode textNode = document.CreateTextNode(lookup);
        node.ParentNode.InsertAfter(textNode, node);
        node.ParentNode.RemoveChild(node);
      }
    }

    /// <summary>
    /// Create an XElement from an XML document at a URL
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static XElement GetXElement(string url)
    {
      Uri uri = new Uri(url, UriKind.Relative);
      StreamResourceInfo info = Application.GetRemoteStream(uri);
      TextReader tr = new StreamReader(info.Stream);
      XElement xel = XElement.Load(tr);
      return xel;
    }

    /// <summary>
    /// Create an XDocument from an XML document at a URL
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static XDocument GetXDocument(string url)
    {
      Uri uri = new Uri(url, UriKind.Relative);
      StreamResourceInfo info = Application.GetRemoteStream(uri);
      TextReader tr = new StreamReader(info.Stream);
      XDocument xel = XDocument.Load(tr);
      return xel;
    }

    ///// <summary>
    ///// Allow the upgrade notification message box to appear
    ///// when upgrades are possible
    ///// </summary>
    //public static bool AllowUpgradeNotification
    //{
    //  get
    //  {
    //    string activeProduct = GetActiveProduct();
    //    if (null == activeProduct || activeProduct.Length <= 0)
    //    {
    //      return false;
    //    }
    //    else
    //    {
    //      RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\ESRI\" + activeProduct + @"\Metadata\Config\");
    //      object obj = (null != regkey) ? regkey.GetValue(UPGRADE_NOTIFICATION_KEY) : null;
    //      return (obj is int) ? (1 == (int)obj) : true;
    //    }
    //  }
    //}

    //public static void SetUpgradeNotificationKey(bool enablePrompt)
    //{
    //  string activeProduct = GetActiveProduct();
    //  if (null == activeProduct || activeProduct.Length <= 0)
    //  {
    //    return;
    //  }
    //  else
    //  {
    //    RegistryKey regkey = Registry.CurrentUser.CreateSubKey(@"Software\ESRI\" + activeProduct + @"\Metadata\Config\");
    //    regkey.SetValue(UPGRADE_NOTIFICATION_KEY, enablePrompt ? 1 : 0);
    //  }
    //}

    private static XElement RemoveAllNamespaces(XElement e)
    {
      return new XElement(e.Name.LocalName,
         (from n in e.Nodes()
          select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
         (e.HasAttributes) ? (from a in e.Attributes()
                              where (!a.IsNamespaceDeclaration)
                              select new XAttribute(a.Name.LocalName, a.Value)) : null);
    }

    private static Dictionary<string, XmlDocument> _configsMap;
    private static Dictionary<string, IMetadataEditor> _editorMap;
    static void InitConfigurations()
    {
      if (!_bConfigsLoaded)
      {
        System.Collections.ObjectModel.Collection<ComponentElement> editorConfigs = Categories.GetComponentElements("esri_metadata_metadataEditors");

        _configsMap = new Dictionary<string, XmlDocument>();
        _editorMap = new Dictionary<string, IMetadataEditor>();

        for (int i = 0; i < editorConfigs.Count; i++)
        {
          try
          {
            XElement content = editorConfigs[i].GetContent();
            XAttribute attr = content.Attribute("displayName");

            var component = editorConfigs[i].CreateComponent();
        //    Assembly assembly = component.GetType().Assembly;

            _editorMap[(string)attr.Value] = component as IMetadataEditor;

            XNamespace ns = "http://schemas.esri.com/DADF/Registry";
            XElement configElement = content.Element(ns + "metadataConfig");

            if (attr != null && configElement != null)
            {
              // Remove the namespace
              XElement purifiedConfigElement = RemoveAllNamespaces(configElement);

              XmlDocument xmlDoc = new XmlDocument();
              xmlDoc.LoadXml(purifiedConfigElement.ToString());       

              _configsMap[(string)attr.Value] = xmlDoc;
            }
          }
          catch { }
        }

        _bConfigsLoaded = true;
      }
    }

    internal static Type GetType(string styleName, string className)
    {
      InitConfigurations();

      IMetadataEditor editor = null;
      _editorMap.TryGetValue(styleName, out editor);

      if (editor != null)
        return editor.GetType(className);
      else
        return Type.GetType(className);
    }

    internal static IMetadataEditor GetEditor(string styleName)
    {
      InitConfigurations();

      IMetadataEditor editor = null;
      _editorMap.TryGetValue(styleName, out editor);
      return editor;
    }

    internal static XmlDocument GetConfigDocument(string styleName)
    {
      InitConfigurations();

      XmlDocument doc = null;
      _configsMap.TryGetValue(styleName, out doc);

      return doc;
    }

    internal static List<string> GetStylesheetNames()
    {
      List<string> stylesheetNames = new List<string>();

      InitConfigurations();

      foreach (var config in _configsMap)
        stylesheetNames.Add(config.Key);

      return stylesheetNames;
    }

    public static string GetESRIApplicationDataFolder()
    {
      string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + ESRI;
      return folder;
    }

    public static string GetESRIDocumentsFolder()
    {
      string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + ARCGIS;
      return folder;
    }

    public static string GetArcGISInstallDir()
    {
      string assemblyPath = System.Reflection.Assembly.GetCallingAssembly().Location;
      int x = assemblyPath.LastIndexOf(@"\bin\", System.StringComparison.CurrentCultureIgnoreCase);
      return assemblyPath.Substring(0, x);
    }

    public static string InstallPath
    {
      get
      {
        if (string.IsNullOrEmpty(_INSTALL_DIR))
          _INSTALL_DIR = GetArcGISInstallDir();

        return _INSTALL_DIR;
      }
    }

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
        // NOTE: this doesn't work
        //provider.InitialLoad();
        //object data = provider.Data;
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

    public static void AppendXml(object sender, EventArgs e)
    {
      //rameworkElement parentControl = parent as FrameworkElement;
      FrameworkElement senderControl = sender as FrameworkElement;
      XmlDataProvider provider = senderControl.Resources["AppendXml"] as XmlDataProvider;

      if (null != provider)
      {
        // append to data context
        IEnumerable<XmlNode> data = GetXmlDataContext(senderControl.DataContext); // as IEnumerable<XmlNode>;
        if (null != data)
        {
          foreach (XmlNode node in data)
          {
            // get the fill-record xml
            XmlNode fillNode = provider.Document.FirstChild;
            node.AppendChild(fillNode);
            //CopyElements(node, fillNode);

            System.Console.WriteLine("New Source: " + node.InnerXml);
            break;
          }
        }
        else
          throw new MetadataException("Data Context is NULL for Filling Xml Record!");
      }
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
      // construct xml record key
      string resKey = "XmlRecord";

      // use the parent node of the current data context instead?
      // tag will be e.g.: HierarchyLevel_Parent
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

      // calc the data context and get an xml provider from the record key
      object controlDataContext = null;
      XmlDataProvider provider = null;

      if (sender is Button)
      {
        // data context from control
        System.Windows.FrameworkElement control = sender as System.Windows.FrameworkElement;

        controlDataContext = control.DataContext;
        if (useParent)
          controlDataContext = ((XmlNode)controlDataContext).ParentNode;
        else if (useGrandparent)
          controlDataContext = ((XmlNode)controlDataContext).ParentNode.ParentNode;

        // xml provider from user control
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
        // get the data context
        // and apply fill to each element
        IEnumerable<XmlNode> data = GetXmlDataContext(controlDataContext); // as IEnumerable<XmlNode>;
        if (null != data && 0 < data.Count())
        {
          foreach (XmlNode node in data)
          {
            // get the fill-record xml
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
    /// recursively interrogate elements from the source XML against an XML fragment 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="fragment"></param>
    /// <param name="supressAppend"></param>
    /// <param name="supressFill"></param>
    public static void CopyElements(XmlNode source, XmlNode fragment, bool supressAppend, bool supressFill)
    {
      // 
      // elements names must match OR match the <ANY> tag
      //
      if (source.LocalName != fragment.LocalName && !("ANY".Equals(fragment.LocalName)))
        return;

      //
      // if not supressing fill and this is a node (not a document)
      // then fill the attributes
      //
      if (!supressFill && null != source.OwnerDocument)
      {
        // copy attributes of fragment that DON'T exist in the source
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

      //
      // recurse into the fragments children
      //
      foreach (XmlNode tchild in fragment.ChildNodes)
      {
        if (XmlNodeType.Element != tchild.NodeType)
          continue;

        // test if the fragment element exists in the data context (source)
        bool found = false;

        if (!supressFill)
        {
          //
          // recursively copy child elements
          //
          foreach (XmlNode schild in source.ChildNodes)
          {
            if (XmlNodeType.Element != schild.NodeType)
              continue;

            // identical element?
            if (schild.LocalName == tchild.LocalName)
            {
              CopyElements(schild, tchild, supressAppend, supressFill); // recurse
              found = true;
            }
          }
        }

        // fill only?
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
          // append new one?
          forceappend = true;
        }

        // IF source node wasn't found with the same local name
        // AND fill only is NOT set
        //
        // ... OR forcing append
        // THEN create a new node
        if ((!found && !fillOnly) || forceappend)
        {
          RecurseCopy(source, tchild);
        }
      }
    }

    public static void RecurseCopy(XmlNode sourceParent, XmlNode fragment)
    {
      // is the fragment node fill only?
      //
      XmlAttribute fillOnlyNode = fragment.Attributes.GetNamedItem("editorFillOnly") as XmlAttribute;
      bool fillOnly = (null != fillOnlyNode && "true".Equals(fillOnlyNode.Value, StringComparison.InvariantCultureIgnoreCase));

      if (fillOnly)
        return; // bail

      // get source document
      //
      XmlDocument sourceDocument = null;
      if (sourceParent is XmlDocument)
        sourceDocument = sourceParent as XmlDocument;
      else
        sourceDocument = sourceParent.OwnerDocument;

      // create new element from fragment node
      //
      XmlNode newchild = sourceDocument.CreateElement(fragment.Prefix, fragment.LocalName, fragment.NamespaceURI);

      // copy attributes from fragment node to new node
      //
      foreach (XmlAttribute at in fragment.Attributes)
      {
        // create a new attribute in the source document's context
        XmlAttribute newAt = sourceDocument.CreateAttribute(at.Prefix, at.LocalName, at.NamespaceURI);
        newAt.Value = at.Value;
        newchild.Attributes.Append(newAt);
      }

      // append new child
      sourceParent.AppendChild(newchild);

      // copy TEXT or CHILD NODES, no mixed-content 
      //
      var childNodes = fragment.SelectNodes("*");
      if (0 == childNodes.Count)
      {
        newchild.InnerText = fragment.InnerText;
      }
      else
      {
        // recurse into fragment, providing new source and fragment child
        foreach (XmlNode fragChild in fragment.SelectNodes("*"))
        {
          RecurseCopy(newchild, fragChild);
        }
      }
    }

    public static int TruncateLength
    {
      get
      {
        if (0 == _truncateLength)
        {
          string len = GetResString("truncate.length");
          int nlen = 15;
          if (null != len)
          {
            try { nlen = int.Parse(len); }
            catch (Exception) { /* NOOP */ }
          }
          _truncateLength = nlen;
        }
        return _truncateLength;
      }
    }

    /// <summary>
    /// Return a resource string from the definitions resource
    /// </summary>
    /// <param name="key">key</param>
    /// <returns></returns>
    public static string GetDefResString(string key)
    {
      if (null == _defResourceManager)
        _defResourceManager = new ResourceManager("ArcGIS.Desktop.Internal.Metadata.Properties.Definitions",
                           System.Reflection.Assembly.GetExecutingAssembly());
      string reslabel = _defResourceManager.GetString(key, Thread.CurrentThread.CurrentCulture);
      if (null == reslabel)
        return null;

      //reslabel = HttpUtility.HtmlDecode(reslabel);
      return reslabel;
    }

    /// <summary>
    /// Return a resource string
    /// </summary>
    /// <param name="key">key</param>
    /// <returns></returns>
    public static string GetResString(string key)
    {
      if (null == _resourceManager)
        _resourceManager = new ResourceManager("ArcGIS.Desktop.Internal.Metadata.Properties.Resources",
                           System.Reflection.Assembly.GetExecutingAssembly());
      string reslabel = _resourceManager.GetString(key, Thread.CurrentThread.CurrentCulture);
      if (null == reslabel)
        return null;

      reslabel = HttpUtility.HtmlDecode(reslabel);
      return reslabel;
    }

    /// <summary>
    /// Return the "sync" status of an ESRI tag
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static XmlAttribute GetSyncNode(XmlNode node)
    {
      XmlAttribute syncNode = node.SelectSingleNode("@Sync|@sync|@SYNC") as XmlAttribute;
      return syncNode;
      //return (null != syncNode && "true".Equals(syncNode.Value, StringComparison.InvariantCultureIgnoreCase));
    }

    public static string PartyDefaultValue(XmlNode root)
    {
      if (null != root)
      {
        // Person
        XmlNode node = root.SelectSingleNode("rpIndName");
        if (null != node && 0 < node.InnerText.Length)
        {
          return node.InnerText;
        }

        // Org
        node = root.SelectSingleNode("rpOrgName");
        if (null != node && 0 < node.InnerText.Length)
        {
          return node.InnerText;
        }

        // Position
        node = root.SelectSingleNode("rpPosName");
        if (null != node && 0 < node.InnerText.Length)
        {
          return node.InnerText;
        }
      }

      return String.Empty;
    }

    /// <summary>
    /// generate the contacts list
    /// </summary>
    /// <param name="contactsDoc"></param>
    /// <param name="dataContext"></param>
    /// <returns></returns>
    public static XmlNodeList GenerateContactsList(XmlDocument contactsDoc, object dataContext)
    {
      return GenerateContactsDocument(contactsDoc, dataContext)?.SelectNodes("//contact");
    }

    /// <summary>
    /// generate the contacts document
    /// </summary>
    public static XmlNode GenerateContactsDocument(XmlDocument contactsDoc, object dataContext)
    {
      // new document
      XmlNode contactsNode = null;

      // attempt read contacts from file
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

      // create a new one...
      if (null == contactsNode)
      {
        contactsNode = contactsDoc.CreateElement("contacts");
        contactsDoc.AppendChild(contactsNode);
      }

      // merge with contacts in the source document    
      //object dataContext = this.DataContext;
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

            // insert the metadata contact into the contact manager xml
            // 1) remove the "editorSave" element, it will be re-inserted
            // 2) remove the "editorDigest" element, it will be re-inserted with a fresh value
            // 3) remove the "editorSource" element

            var editorSaveNode = pn.SelectSingleNode("editorSave");
            if (null != editorSaveNode)
            {
              pn.RemoveChild(editorSaveNode);
            }

            var editorDigestNode = pn.SelectSingleNode("editorDigest");
            if (null != editorDigestNode)
            {
              pn.RemoveChild(editorDigestNode);
            }

            var editorSourceNode = pn.SelectSingleNode("editorSource");
            if (null != editorSourceNode)
            {
              pn.RemoveChild(editorSourceNode);
            }

            // create contact node
            XmlNode contactNode = contactsNode.OwnerDocument.CreateElement("contact");
            contactNode.InnerXml = pn.InnerXml;

            // create 'editorSave' attribute
            editorSaveNode = contactsNode.OwnerDocument.CreateElement("editorSave");
            editorSaveNode.InnerText = alreadyExists ? "True" : "False";
            contactNode.AppendChild(editorSaveNode);

            // add to contacts
            contactsNode.AppendChild(contactNode);
          }
        }

        break; // only one
      }

      return contactsDoc;
    }

    /// <summary>
    /// generate a unique key for an ISO party
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

      // return key
      string digest = GetSHA1Hash(sb.ToString());
      return digest;
    }

    /// <summary>
    /// extract a label appropriate for a responsible party
    /// </summary>
    /// <param name="el"></param>
    /// <returns></returns>
    static public String ExtractResponsiblePartyLabel(FrameworkElement el, string format)
    {
      IEnumerable<XmlNode> data = GetXmlDataContext(el.DataContext);
      if (null == data)
        return String.Empty;

      foreach (XmlNode root in data)
      {
        return ExtractResponsiblePartyLabel(root, format);
      }

      return String.Empty; // should never get here
    }

    static public String ExtractResponsiblePartyLabel(XmlNode root, string format)
    {
      var label = "";
      var name = "";
      var organization = "";
      var position = "";

      // individual
      XmlNode node = root.SelectSingleNode("rpIndName");
      if (null != node && 0 < node.InnerText.Length)
      {
        name = node.InnerText;
      }

      // organization
      node = root.SelectSingleNode("rpOrgName");
      if (null != node && 0 < node.InnerText.Length)
      {
        organization = node.InnerText;
      }

      // position
      node = root.SelectSingleNode("rpPosName");
      if (null != node && 0 < node.InnerText.Length)
      {
        position = node.InnerText;
      }

      // generic label
      if (null != name && 0 < name.Length)
        label = name;
      else if (null != organization && 0 < organization.Length)
        label = organization;
      else if (null != position && 0 < position.Length)
        label = position;

      // role
      var role = "";
      var roleLabel = Internal.Metadata.Properties.Resources.LBL_CI_PARTY_ROLE_UNKNOWN;

      node = root.SelectSingleNode("role/RoleCd/@value");
      if (null != node && 0 < node.Value.Length)
      {
        role = node.InnerText;

        // create codelist
        var codeList = new Codelists();
        codeList.CodelistName = "CI_RoleCode";

        // get the list and find a codelist item with the same codelist value
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

      // format it
      var labelFormatString = format; // Properties.Resources.LBL_CI_PARTY_FORMAT;
      labelFormatString = labelFormatString.Replace("%NAME%", name);
      labelFormatString = labelFormatString.Replace("%ORG%", organization);
      labelFormatString = labelFormatString.Replace("%POS%", position);
      labelFormatString = labelFormatString.Replace("%LABEL%", label);
      labelFormatString = labelFormatString.Replace("%ROLE%", roleLabel);

      // return result and break out of loop
      return labelFormatString;
    }

    /// <summary>
    /// generate an MD5 digest from a string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string GetSHA1Hash(string input)
    {
      // Create a new instance of the MD5CryptoServiceProvider object.
      var sha1Hasher = System.Security.Cryptography.SHA1.Create();

      // Convert the input string to a byte array and compute the hash.
      byte[] data = sha1Hasher.ComputeHash(Encoding.Default.GetBytes(input));

      // Create a new Stringbuilder to collect the bytes
      // and create a string.
      StringBuilder sBuilder = new StringBuilder();

      // Loop through each byte of the hashed data 
      // and format each one as a hexadecimal string.
      for (int i = 0; i < data.Length; i++)
      {
        sBuilder.Append(data[i].ToString("x2"));
      }

      // Return the hexadecimal string.
      return sBuilder.ToString();
    }

    /// <summary>
    /// get the path of the contacts file
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
    /// remove markup from a string
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string StripHtml(string data)
    {
      if (null != data)
      {
        data = HttpUtility.HtmlDecode(data);
        return Regex.Replace(data, @"<(.|\n)*?>", "");
      }
      else
      {
        return String.Empty;
      }
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

      // load from encoded HTML
      foreach (XmlNode node in xmlNodes)
      {

        string htmlString = "";

        // check for existing XML child nodes
        XmlNodeList children = node.SelectNodes("*");
        if (null != children && 0 < children.Count)
        {
          string xml = node.InnerXml;

          // convert
          htmlString = Utils.ConvertToolXML(xml);

          // write back to node the updated encoded xml
          node.InnerText = HttpUtility.HtmlEncode(htmlString);
        }
        else
        {
          // inside element
          // may be encoded markup
          // innerText decodes
          htmlString = node.InnerText.Trim();

          if (0 != htmlString.IndexOf("<")) // does NOT have encoded markup
          {
            // wrap the XML
            // preserve non-tag entities
            string xmlString = node.InnerXml.Trim();
            htmlString = "<DIV>" + xmlString + "</DIV>";

            // innerText encodes
            node.InnerText = htmlString;
          }
        }

        // node.InnerText does the decoding for us
        xaml = HtmlToXamlConverter.ConvertHtmlToXaml(node.InnerText, false);

        break; // only one
      }

      // now read the new XAML and add to the rich text box
      if (null != xaml && 0 < xaml.Length)
      {

        RichTextBox box = sender as RichTextBox;
        box.Document.Blocks.Clear();

        using (MemoryStream xamlMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xaml)))
        {
          ParserContext parser = new ParserContext();
          parser.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
          parser.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
          //FlowDocument doc = new FlowDocument();

          try
          {
            Section section = XamlReader.Load(xamlMemoryStream, parser) as Section;
            box.Document.Blocks.Add(section);
          }
          catch (Exception)
          {
            // NOOP
          }
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

        // need to explictly create this to force a byte-order-mark
        UTF8Encoding encoder = new UTF8Encoding(true, true);
        string xamlText = encoder.GetString(ms.ToArray());
        var html = HtmlFromXamlConverter.ConvertXamlToHtml(xamlText, false);

        // test to see if there's anything in the HTML
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

        // load from encoded HTML
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
    /// return the current metadata editor profile
    /// </summary>
    /// <param name="dep"></param>
    /// <returns></returns>
    public static string GetCurrentProfile(DependencyObject dep)
    {
      MetadataEditorControl mec = Utils.FindAncestorOrSelf<MetadataEditorControl>(dep);
      if (null != mec)
      {
        var vm = mec.DataContext as MetadataEditorViewModel;
        if (null != vm)
        {
          return vm.ArcGISProfile;
        }
      }
      return null;
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

    /// <summary>
    /// return the current metadata editor
    /// </summary>
    /// <param name="dep"></param>
    /// <returns></returns>
    public static MetadataEditorControl GetMetadataEditorControl(DependencyObject dep)
    {
      return Utils.FindAncestorOrSelf<MetadataEditorControl>(dep);
    }

    internal static MetadataEditorViewModel GetMetadataEditorViewModel(DependencyObject dep)
    {
      var control = Utils.FindAncestorOrSelf<MetadataEditorControl>(dep);
      return (control == null) ? null: control.DataContext as MetadataEditorViewModel;
    } 

    public static void AppendLog(string msg)
    {
      string file = @"c:\temp\metadataeditor-debug.txt";
      File.AppendAllText(file, msg + "\n");
    }

    /// <summary>
    /// Find Parent
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static DependencyObject GetParent(DependencyObject obj)
    {
      if (obj == null)
        return null;

      FrameworkElement fe = obj as FrameworkElement;
      if (null != fe)
      {
        DependencyObject fdo = fe.Parent;
        if (null != fdo)
          return fdo;
      }

      ContentElement ce = obj as ContentElement;
      if (ce != null)
      {
        DependencyObject parent = ContentOperations.GetParent(ce);
        if (parent != null)
          return parent;

        FrameworkContentElement fce = ce as FrameworkContentElement;
        return fce != null ? fce.Parent : null;
      }

      return VisualTreeHelper.GetParent(obj);
    }

    /// <summary>
    /// Find Ancestor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T FindAncestorOrSelf<T>(DependencyObject obj)
        where T : DependencyObject
    {
      while (obj != null)
      {
        T objTest = obj as T;
        if (objTest != null)
          return objTest;
        obj = GetParent(obj);
      }
      return null;
    }

    private static string _htmlStringForError = string.Empty;
    internal static string GetErrorHtml(string errorMsg)
    {
      if (string.IsNullOrEmpty(_htmlStringForError))
      {
        string assemblyPath = System.Reflection.Assembly.GetCallingAssembly().Location;
        int x = assemblyPath.LastIndexOf(@"\bin\", System.StringComparison.CurrentCultureIgnoreCase);
        string installPath = assemblyPath.Substring(0, x);
        string errorHtmlFilePath = System.IO.Path.Combine(installPath, "Resources", "Metadata", "Errors", "Error_OL.htm");

        _htmlStringForError = System.IO.File.ReadAllText(errorHtmlFilePath);
      }

      if (string.IsNullOrEmpty(_htmlStringForError))
        return string.Empty;

      string result = _htmlStringForError;
      result = result.Replace("$######$", errorMsg);

      string colorCode = "#4C4C4C";
      if (ArcGIS.Desktop.Framework.FrameworkApplication.ApplicationTheme == ArcGIS.Desktop.Framework.ApplicationTheme.Dark)
        colorCode = "#D1D1D1";
      else if (ArcGIS.Desktop.Framework.FrameworkApplication.ApplicationTheme == ArcGIS.Desktop.Framework.ApplicationTheme.HighContrast)
        colorCode = "#000000";

      result = result.Replace("$ssss$", colorCode);

      return result;
    }

    private static string _htmlStringForDetailedError = string.Empty;
    internal static string GetDetailedErrorHtml(string summary, string detailedMsg)
    {
      if (string.IsNullOrEmpty(_htmlStringForDetailedError))
      {
        string assemblyPath = System.Reflection.Assembly.GetCallingAssembly().Location;
        int x = assemblyPath.LastIndexOf(@"\bin\", System.StringComparison.CurrentCultureIgnoreCase);
        string installPath = assemblyPath.Substring(0, x);
        string errorHtmlFilePath = System.IO.Path.Combine(installPath, "Resources", "Metadata", "Errors", "Error_TL.htm");

        _htmlStringForDetailedError = System.IO.File.ReadAllText(errorHtmlFilePath);
      }

      if (string.IsNullOrEmpty(_htmlStringForDetailedError))
        return string.Empty;

      string result = _htmlStringForDetailedError;
      result = result.Replace("$S####S$", summary);
      result = result.Replace("$D####D$", detailedMsg);

      return result;
    }

    private static string _htmlStringWithLinkForError = string.Empty;
    internal static string GetErrorHtmlWithLink(string errorMsg, string mdURI)
    {
      if (string.IsNullOrEmpty(_htmlStringWithLinkForError))
      {
        string assemblyPath = System.Reflection.Assembly.GetCallingAssembly().Location;
        int x = assemblyPath.LastIndexOf(@"\bin\", System.StringComparison.CurrentCultureIgnoreCase);
        string installPath = assemblyPath.Substring(0, x);
        string errorHtmlFilePath = System.IO.Path.Combine(installPath, "Resources", "Metadata", "Errors", "Error_OWL.htm");

        _htmlStringWithLinkForError = System.IO.File.ReadAllText(errorHtmlFilePath);
      }

      if (string.IsNullOrEmpty(_htmlStringWithLinkForError))
        return string.Empty;

      string result = _htmlStringWithLinkForError;
      result = result.Replace("$######$", errorMsg);
      result = result.Replace("$L####L$", mdURI);
      result = result.Replace("$View_content$", Internal.Metadata.Properties.Resources.MD_View_Content_Label); 

      return result;
    }

    internal static string NavigateToError(string msg, EditorError navErrors)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("<html><head></head>");
      sb.Append("<body style=\"text-align:center;color:red;background:#FFF;font-family:sans-serif;font-size:1em;\">");
      sb.Append("<p>");
      sb.Append(msg);
      sb.Append("</p>");

      if (null != navErrors && null != navErrors.Cause)
      {
        Exception inner = navErrors.Cause;
        if (null != inner)
        {
          sb.Append("<p>");
          sb.Append(HttpUtility.HtmlEncode(inner.Message));
          sb.Append("</p>");
        }
      }
      sb.Append("</body></html>");
      return sb.ToString();
    }

    internal static string NavigateToError(string msg, string exMsg)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("<html><head></head>");
      sb.Append("<body style=\"text-align:center;color:red;background:#FFF;font-family:sans-serif;font-size:1em;\">");
      sb.Append("<p>");
      sb.Append(msg);
      sb.Append("</p>");

      if (!string.IsNullOrEmpty(exMsg))
      {
        sb.Append("<p>");
        sb.Append(HttpUtility.HtmlEncode(exMsg));
        sb.Append("</p>");
      }
      sb.Append("</body></html>");
      return sb.ToString();
    }
  }
}
