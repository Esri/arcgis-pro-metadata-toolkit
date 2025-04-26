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
using System.Windows.Controls;
using System.Xml;

using ArcGIS.Desktop.Metadata.Editors.ClassicEditor.Pages;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_DQ_Element.xaml
  /// </summary>
  internal partial class MTK_DQ_Element : EditorPage
  {
    public MTK_DQ_Element()
    {
      InitializeComponent();
    }

    public override string DefaultValue
    {
      get
      {
        IEnumerable<XmlNode> data = GetXmlDataContext();
        if (null == data)
          return null;

        foreach (XmlNode root in data)
        {
          // MEASURE NAME
          XmlNode node = root.SelectSingleNode("*/measName");
          if (null != node && 0 < node.InnerText.Length)
          {
            return node.InnerText;
          }

          break;
        }

        return null;
      }
      set
      {
        // DO NOTHING
      }

    }
  }
}
