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
using System.Windows;
using System.Xml;

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Metadata;
using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace $safeprojectname$.Pages
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
      object context = Utils.Utils.GetDataContext(sender);
      IEnumerable<XmlNode> data = Utils.Utils.GetXmlDataContext(context);
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
              string threeLetter = Utils.LanguageConverter.GetThreeLetterCode(code);
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
