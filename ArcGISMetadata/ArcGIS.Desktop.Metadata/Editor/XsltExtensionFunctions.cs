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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Resources;
using System.Threading;
using System.Globalization;

namespace ArcGIS.Desktop.Metadata.Editor
{
  /// <summary>
  /// Various extension functions for XSLT
  /// </summary>
  /// 
  [Guid("D914EF25-C405-4998-A534-031B3FE4D2F2")]
  [ClassInterface(ClassInterfaceType.None)]
  [ProgId("ArcGIS.Desktop.Metadata.Editor.XsltExtensionFunctions")]
  [ComVisible(true)]
  internal class XsltExtensionFunctions
  {

    // The constants reprtesent all Xaml names used in a conversion
    public const string Xaml_FlowDocument = "FlowDocument";

    public const string Xaml_Run = "Run";
    public const string Xaml_Span = "Span";
    public const string Xaml_Hyperlink = "Hyperlink";
    public const string Xaml_Hyperlink_NavigateUri = "NavigateUri";
    public const string Xaml_Hyperlink_TargetName = "TargetName";

    public const string Xaml_Section = "Section";

    public const string Xaml_List = "List";

    public const string Xaml_List_MarkerStyle = "MarkerStyle";
    public const string Xaml_List_MarkerStyle_None = "None";
    public const string Xaml_List_MarkerStyle_Decimal = "Decimal";
    public const string Xaml_List_MarkerStyle_Disc = "Disc";
    public const string Xaml_List_MarkerStyle_Circle = "Circle";
    public const string Xaml_List_MarkerStyle_Square = "Square";
    public const string Xaml_List_MarkerStyle_Box = "Box";
    public const string Xaml_List_MarkerStyle_LowerLatin = "LowerLatin";
    public const string Xaml_List_MarkerStyle_UpperLatin = "UpperLatin";
    public const string Xaml_List_MarkerStyle_LowerRoman = "LowerRoman";
    public const string Xaml_List_MarkerStyle_UpperRoman = "UpperRoman";

    public const string Xaml_ListItem = "ListItem";

    public const string Xaml_LineBreak = "LineBreak";

    public const string Xaml_Paragraph = "Paragraph";

    public const string Xaml_Margin = "Margin";
    public const string Xaml_Padding = "Padding";
    public const string Xaml_BorderBrush = "BorderBrush";
    public const string Xaml_BorderThickness = "BorderThickness";

    public const string Xaml_Table = "Table";

    public const string Xaml_TableColumn = "TableColumn";
    public const string Xaml_TableRowGroup = "TableRowGroup";
    public const string Xaml_TableRow = "TableRow";

    public const string Xaml_TableCell = "TableCell";
    public const string Xaml_TableCell_BorderThickness = "BorderThickness";
    public const string Xaml_TableCell_BorderBrush = "BorderBrush";

    public const string Xaml_TableCell_ColumnSpan = "ColumnSpan";
    public const string Xaml_TableCell_RowSpan = "RowSpan";

    public const string Xaml_Width = "Width";
    public const string Xaml_Brushes_Black = "Black";
    public const string Xaml_FontFamily = "FontFamily";

    public const string Xaml_FontSize = "FontSize";
    public const string Xaml_FontSize_XXLarge = "22pt"; // "XXLarge";
    public const string Xaml_FontSize_XLarge = "20pt"; // "XLarge";
    public const string Xaml_FontSize_Large = "18pt"; // "Large";
    public const string Xaml_FontSize_Medium = "16pt"; // "Medium";
    public const string Xaml_FontSize_Small = "12pt"; // "Small";
    public const string Xaml_FontSize_XSmall = "10pt"; // "XSmall";
    public const string Xaml_FontSize_XXSmall = "8pt"; // "XXSmall";

    public const string Xaml_FontWeight = "FontWeight";
    public const string Xaml_FontWeight_Bold = "Bold";

    public const string Xaml_FontStyle = "FontStyle";

    public const string Xaml_Foreground = "Foreground";
    public const string Xaml_Background = "Background";
    public const string Xaml_TextDecorations = "TextDecorations";
    public const string Xaml_TextDecorations_Underline = "Underline";

    public const string Xaml_TextIndent = "TextIndent";
    public const string Xaml_TextAlignment = "TextAlignment";

    private static ResourceManager _resourceManager = null;

    public string str(string key)
    { 
      string value = GetResString(key);
      if (null == value)
      {
        // test for missing strings...
        //TextWriter tw = new StreamWriter(@"c:\temp\missing.txt", true);
        //tw.WriteLine(key);
        //tw.Close();
        return Internal.Metadata.Properties.Resources.XSLT_RES_NOTFOUND;
      }
      else
        return value;
    }

    public static string GetResString(string key)
    {
      if (null == _resourceManager)
        _resourceManager = new ResourceManager("ArcGIS.Desktop.Metadata.Properties.XsltResources",
                           System.Reflection.Assembly.GetExecutingAssembly());
      string reslabel = _resourceManager.GetString(key);
      if (null == reslabel)
        return null;
      return reslabel;
    }

    /// <summary>
    /// split coordates
    /// 12.0,11.0 5.0,3.0 ...
    /// into <coords><coord>12.0</coord><coord>11.0</coord></coords>
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public XPathNodeIterator htmlproperties(XPathNodeIterator data)
    {
      if (null == data || 0 == data.Count)
      {
        XmlDocument doc = new XmlDocument();
        XPathNavigator navigator = doc.CreateNavigator();
        XPathNodeIterator nodes = navigator.Select("/");
        return nodes;
      }

      Dictionary<string, object> properties = new Dictionary<string, object>();

      foreach (XPathNavigator navNode in data)
      {
        string elementName = navNode.LocalName.ToLower();
        switch (elementName)
        {
          // Character formatting
          case "i":
          case "em":
            properties[Xaml_FontStyle] = "italic";
            break;
          case "b":
          case "bold":
          case "strong":
            properties[Xaml_FontWeight] = "bold";
            break;
          case "u":
            properties[Xaml_TextDecorations] = "true";
            break;
          case "sub":
            break;
          case "sup":
            break;

          // Hyperlinks
          case "a": // href, hreflang, urn, methods, rel, rev, title
            //  Set default hyperlink properties
            break;
          case "acronym":
            break;

          // Paragraph formatting:
          case "p":
            //  Set default paragraph properties
            break;
          case "div":
            //  Set default div properties
            break;
          case "pre":
            properties[Xaml_FontFamily] = "Courier New"; // renders text in a fixed-width font
            break;
          //case "blockquote":
          //  properties["margin-left"] = "16";
          //  break;
          case "h1":
            properties[Xaml_FontSize] = Xaml_FontSize_XXLarge;
            break;
          case "h2":
            properties[Xaml_FontSize] = Xaml_FontSize_XLarge;
            break;
          case "h3":
            properties[Xaml_FontSize] = Xaml_FontSize_Large;
            break;
          case "h4":
            properties[Xaml_FontSize] = Xaml_FontSize_Medium;
            break;
          case "h5":
            properties[Xaml_FontSize] = Xaml_FontSize_Small;
            break;
          case "h6":
            properties[Xaml_FontSize] = Xaml_FontSize_XSmall;
            break;
          // List properties
          case "ul":
            properties[Xaml_List_MarkerStyle] = Xaml_List_MarkerStyle_Disc;
            break;
          case "ol":
            properties[Xaml_List_MarkerStyle] = Xaml_List_MarkerStyle_Decimal;
            break;

          case "table":
          case "body":
          case "html":
            break;
        }

        // extract properties from inline 'style'
        XPathNodeIterator styleAttIterator = navNode.Select("@style|@STYLE");
        foreach (XPathNavigator styleAtt in styleAttIterator)
        {

          string style = styleAtt.Value;
          string[] styleValues = style.Split(';');

          for (int i = 0; i < styleValues.Length; i++)
          {
            string[] styleNameValue = styleValues[i].Split(':');
            if (styleNameValue.Length == 2)
            {
              // get style name
              string styleName = styleNameValue[0].Trim().ToLower();

              // get whole value (may contain 1.* values)
              string styleValue = styleNameValue[1].Trim().ToLower();

              // get style values
              string[] styleNameValues = styleValue.Split(' ');

              for (int j = 0; j < styleNameValues.Length; j++)
              {
                // clean up value
                string v = styleNameValues[j];
                if (v.StartsWith("\"") && v.EndsWith("\"") || v.StartsWith("'") && v.EndsWith("'"))
                  v = v.Substring(1, v.Length - 2).Trim();

                styleNameValues[j] = v;
              }

              // add to property list
              properties[styleName] = styleNameValues;
            }
          }

          break; // paranoid
        }
      }

      StringBuilder sb = new StringBuilder("<properties>");

      foreach (string prop in properties.Keys)
      {
        object propValue = properties[prop];
        sb.Append("<");
        sb.Append(prop.Trim());
        sb.Append(">\n");



        if (propValue is string)
        {
          sb.Append("  <value>");
          sb.Append(((string)propValue).Trim());
          sb.Append("</value>\n");
        }
        else if (propValue is string[])
        {
          foreach (string s in (string[])propValue)
          {
            sb.Append("  <value>");
            sb.Append(s.Trim());
            sb.Append("</value>\n");
          }
        }

        sb.Append("</");
        sb.Append(prop);
        sb.Append(">\n");

      }
      sb.Append("</properties>");

      // create a document and return result
      TextReader tr = new StringReader(sb.ToString());
      XmlTextReader xtr = new XmlTextReader(tr);
      XPathDocument document = new XPathDocument(xtr, XmlSpace.Preserve);
      XPathNavigator nav = document.CreateNavigator();
      XPathNodeIterator n = nav.Select("/properties");
      return n;

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
        // need to re-encode special entities
        //var encodedXml = HttpUtility.HtmlEncode(xml);
        data = "<span>" + data + "</span>";
      }

      TextReader tr = new StringReader(xml);
      XmlTextReader xtr = new XmlTextReader(tr);
      try
      {
        XPathDocument document = new XPathDocument(xtr, XmlSpace.Preserve);
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
}
