/*
COPYRIGHT 2013-2016 ESRI

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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.XPath;

namespace ArcGIS.Desktop.Internal.Metadata
{
  #pragma warning disable 1591  //This line will prevent the API Build Warning report from displaying these "internal" items as missing doc members.

  /// <summary>
  /// see: http://msdn.microsoft.com/en-us/library/aa302284.aspx
  /// </summary>
  class XmlResourceResolver : XmlUrlResolver
  {
    public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
    {
      Stream stream = null;

      string origString = absoluteUri.OriginalString;
      int schemestart = origString.LastIndexOf("//") + 2;
      int start = origString.LastIndexOf("/") + 1;
      int end = origString.IndexOf('?');

      Console.WriteLine("Attempting to retrieve: {0}", absoluteUri);

      switch (absoluteUri.Scheme)
      {
        case "res":
          // Handled res:// scheme requests against
          // a named assembly with embedded resources

          Assembly assembly = null;
          string assemblyfilename = origString.Substring(start, end - start);

          try
          {
            if (string.Compare(Assembly.GetExecutingAssembly().GetName().Name, assemblyfilename, true) == 0)
            {
              assembly = Assembly.GetExecutingAssembly();
            }
            // Requested assembly is not loaded, so load it
            else
            {
              assembly = Assembly.Load(AssemblyName.GetAssemblyName(assemblyfilename + ".exe"));
            }
            string resourceName = assemblyfilename + "." +
            absoluteUri.Query.Substring(absoluteUri.Query.IndexOf('?') + 1);
            stream = assembly.GetManifestResourceStream(resourceName);
          }

          catch (Exception e)
          {
            Console.Out.WriteLine(e.Message);
          }

          return stream;


        default:
          return base.GetEntity(absoluteUri, role, ofObjectToReturn);

        //default:
        //  // Handle file:// and http:// 
        //  // requests from the XmlUrlResolver base class
        //  stream = (Stream)base.GetEntity(absoluteUri, role, ofObjectToReturn);
        //  //try
        //  //{
        //  //  if (CacheStreams)
        //  //    CacheStream(stream, absoluteUri);
        //  //}
        //  //catch (Exception e)
        //  //{
        //  //  Console.Out.WriteLine(e.Message);
        //  //}

        //  return stream;
      }
    }
  }

  /// <summary>
  /// This class is not for public use and is used internally by the system to 
  /// implement support for other ArcGIS Pro modules
  /// </summary>
  public class XsltExtFunctions
  {
    private static ResourceManager _resourceManager = null;

    public string str(string key)
    {
      string value = GetResString(key);
      if (null == value)
        return String.Empty;
      else
        return value;
    }

    public static string GetResString(string key)
    {
      if (null == _resourceManager)
        _resourceManager = new ResourceManager("ArcGIS.Desktop.Metadata.Properties.XsltResources",
                           System.Reflection.Assembly.GetExecutingAssembly());
      return _resourceManager.GetString(key);
    }

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
        string lookup = GetResString(localName);
        if (null == lookup)
          lookup = String.Empty;

        XmlNode textNode = document.CreateTextNode(lookup);
        node.ParentNode.InsertAfter(textNode, node);
        node.ParentNode.RemoveChild(node);
      }
    }

    // function that gets called from XSLT
    public string GuidGen()
    {
      return System.Guid.NewGuid().ToString().ToUpper();
    }

    // strip escaped HTML
    public string striphtml(string data)
    {
      return striphtml(data, String.Empty);
    }

    public string striphtml(string data, string replace)
    {
      if (null == replace)
        replace = String.Empty;

      if (null != data)
      {
        data = HttpUtility.HtmlDecode(data);
        return Regex.Replace(data, @"<(.|\n)*?>", replace);
      }
      else
      {
        return String.Empty;
      }
    }

    // take an encoded HTML string and decode it into a nodeset,
    // if a root node doesn't exist, 
    // then insert a <SPAN> around the content
    public object decodenodeset(string data)
    {
      // return empty nodeset if string is empty or null
      if (null == data || 0 == data.Length)
      {
        XmlDocument doc = new XmlDocument();
        XPathNavigator navigator = doc.CreateNavigator();
        XPathNodeIterator nodes = navigator.Select("/");
        return nodes;
      }

      // decode the string into HTML
      string xml = HttpUtility.HtmlDecode(data);

      // insert enclosing SPAN tag if necessary
      if (!"<".Equals(xml.Trim().Substring(0, 1)))
      {
        xml = "<span>" + xml + "</span>";
      }

      // Escape & (existing in href links.)
      string escaped = EscapeXMLAMPValue(xml);

      // Fixed not well formed HTML
      Stream stream = GenerateStreamFromString(escaped);
      XmlTextReader xtr = new XmlTextReader(stream, XmlNodeType.Element, null);

      try
      {
        XPathDocument document = new XPathDocument(xtr, XmlSpace.Preserve);
        XPathNavigator navigator = document.CreateNavigator();
        XPathNodeIterator nodes = navigator.Select("/");
        return nodes;
      }
      catch (Exception)
      {
        try
        {
          TextReader tr1 = new StringReader(data);
          XmlTextReader xtr1 = new XmlTextReader(tr1);
          XPathDocument document = new XPathDocument(xtr1, XmlSpace.Preserve);
          XPathNavigator navigator = document.CreateNavigator();
          XPathNodeIterator nodes = navigator.Select("/");
          return nodes;
        }
        catch (Exception)
        {
          XmlDocument doc = new XmlDocument();
          XPathNavigator navigator = doc.CreateNavigator();
          XPathNodeIterator nodes = navigator.Select("/");
          return nodes;
        }
      }

    }

    private Stream GenerateStreamFromString(string s)
    {
      MemoryStream stream = new MemoryStream();
      StreamWriter writer = new StreamWriter(stream);
      writer.Write(s);
      writer.Flush();
      stream.Position = 0;
      return stream;
    }

    private static string EscapeXMLAMPValue(string xmlString)
    {

      if (xmlString == null)
        throw new ArgumentNullException("xmlString");

      return xmlString.Replace("&", "&amp;");
    }

    /// <summary>
    /// split coordates
    /// 12.0,11.0 5.0,3.0 ...
    /// into <coords><coord>12.0</coord><coord>11.0</coord></coords>
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public XPathNodeIterator splitcoords(string data)
    {
      StringBuilder sb = new StringBuilder("<result>");
      string[] pairs = data.Split(' ');
      foreach (string pair in pairs)
      {
        string[] coords = pair.Split(',');
        if (0 < coords.Length)
        {
          sb.Append("<coords>");
          foreach (string coord in coords)
          {
            sb.Append("<coord>");
            sb.Append(coord);
            sb.Append("</coord>");
          }
          sb.Append("</coords>");
        }
      }
      sb.Append("</result>");

      // create a document and return result
      TextReader tr = new StringReader(sb.ToString());
      XPathDocument document = new XPathDocument(tr);
      XPathNavigator navigator = document.CreateNavigator();
      XPathNodeIterator nodes = navigator.Select("/result/coords");
      return nodes;

    }

    // string to lowercase
    public string strtolower(string data)
    {
      if (null != data)
        return data.ToLower();
      else
        return "";
    }

    // string to uppercase
    public string strtoupper(string data)
    {
      if (null != data)
        return data.ToUpper();
      else
        return "";
    }
  }
  #pragma warning restore 1591
}
