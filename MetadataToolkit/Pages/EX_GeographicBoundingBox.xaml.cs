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
using System.Xml;

using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_EX_GeographicBoundingBox.xaml
  /// </summary>
  internal partial class MTK_EX_GeographicBoundingBox : EditorPage
  {
    public MTK_EX_GeographicBoundingBox()
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
          XmlNode node = root.SelectSingleNode("GeoBndBox/westBL");
          if (null != node && 0 < node.InnerText.Length)
          {
            sb.Append(node.InnerText);
            sb.Append(", ");
          }

          // east
          node = root.SelectSingleNode("GeoBndBox/eastBL");
          if (null != node && 0 < node.InnerText.Length)
          {
            sb.Append(node.InnerText);
            sb.Append(", ");
          }

          // south
          node = root.SelectSingleNode("GeoBndBox/southBL");
          if (null != node && 0 < node.InnerText.Length)
          {
            sb.Append(node.InnerText);
            sb.Append(", ");
          }

          // north
          node = root.SelectSingleNode("GeoBndBox/northBL");
          if (null != node && 0 < node.InnerText.Length)
          {
            sb.Append(node.InnerText);
            sb.Append(", ");
          }
          break;
        }

        if (0 < sb.Length)
          return MetadataToolkit.Properties.Resources.LBL_EXTENTS_BBOX + sb.ToString().Substring(0, 30) + "...";
        else
          return String.Empty; // Properties.Resources.LBL_EXTENTS_BBOX_EMPTY;
      }
      set
      {
        // NOOP
      }
    }
  }
}
