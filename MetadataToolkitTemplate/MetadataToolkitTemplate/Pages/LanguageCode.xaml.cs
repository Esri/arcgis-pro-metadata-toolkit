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

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Metadata;
using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace $safeprojectname$
{
  /// <summary>
  /// Interaction logic for MTK_LanguageCode.xaml
  /// </summary>
  internal partial class MTK_LanguageCode : EditorPage
  {
    public MTK_LanguageCode()
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

                var mdModule = FrameworkApplication.FindModule("esri_metadata_module") as IMetadataEditorHost;
                if (mdModule != null)
                  mdModule.UpdateDataContext(this as DependencyObject);
              }
            }
          }
          break; // just one
        }
      }
    }
  }
}
