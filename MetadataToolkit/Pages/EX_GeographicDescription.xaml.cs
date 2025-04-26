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

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Xml;

using ArcGIS.Desktop.Metadata.Editors.ClassicEditor.Pages;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_EX_GeographicDescription.xaml
  /// </summary>
  internal partial class MTK_EX_GeographicDescription : EditorPage
  {
    public MTK_EX_GeographicDescription()
    {
      InitializeComponent();
    }

    public override string DefaultValue
    {
      get
      {
        IEnumerable<XmlNode> data = GetXmlDataContext();
        if (null == data)
          return String.Empty;

        StringBuilder sb = new StringBuilder();
        foreach (XmlNode root in data)
        {
          // west
          XmlNode node = root.SelectSingleNode("GeoDesc/geoId/identCode");
          if (null != node && 0 < node.InnerText.Length)
          {
            sb.Append(node.InnerText);
          }

          break;
        }

        if (0 < sb.Length)
          return MetadataToolkit.Properties.Resources.LBL_EXTENTS_GEODESC + sb.ToString().Substring(0, 30) + "...";
        else
          return String.Empty; // Properties.Resources.LBL_EXTENTS_GEODESC_EMPTY;
      }
      set
      {
        // NOOP
      }
    }
  }
}
