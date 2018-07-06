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
using System.Windows;
using System.Xml;

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  /// <summary>
  /// Interaction logic for LanguageCode.xaml
  /// </summary>
  internal partial class LanguageCode : EditorPage
  {
    public LanguageCode()
    {
      InitializeComponent();
      // Test
    }

    public void ValidateCode(object sender, RoutedEventArgs e)
    {
      object context = Utils.GetDataContext(sender);
      IEnumerable<XmlNode> data = Utils.GetXmlDataContext(context);
      if (null != data)
      {
        foreach (XmlNode node in data)
        {
          XmlNode attr = node.SelectSingleNode("languageCode/@value");
          if (null != attr)
          {
            string code = attr.Value;
            if (2 == code.Length)
            {
              string threeLetter = LanguageConverter.GetThreeLetterCode(code);
              if (null != threeLetter)
              {
                attr.Value = threeLetter;
                MetadataEditorViewModel.UpdateDataContext(this as DependencyObject);
              }
            }
          }
          break; // just one
        }
      }
    }
  }
}
