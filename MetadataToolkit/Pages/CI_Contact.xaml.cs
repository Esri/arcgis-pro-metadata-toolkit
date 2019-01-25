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
using System.Xml;
using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_CI_Contact.xaml
  /// </summary>
  internal partial class MTK_CI_Contact : EditorPage
  {
    public MTK_CI_Contact()
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
          // URL
          //XmlNode node = root.SelectSingleNode("cntOnlineRes/linkage");
          //if (null != node && 0 < node.InnerText.Length)
          //{
          //    return node.InnerText;
          //}

          // EMAIL
          XmlNode node = root.SelectSingleNode("cntAddress/eMailAdd");
          if (null != node && 0 < node.InnerText.Length)
          {
            return node.InnerText;
          }

          // ADDRESS
          string address = "";
          node = root.SelectSingleNode("cntAddress/delPoint");
          if (null != node && 0 < node.InnerText.Length)
          {
            address += node.InnerText;
            address += " ";
          }
          node = root.SelectSingleNode("cntAddress/city");
          if (null != node && 0 < node.InnerText.Length)
          {
            address += node.InnerText;
            address += ", ";
          }
          node = root.SelectSingleNode("cntAddress/adminArea");
          if (null != node && 0 < node.InnerText.Length)
          {
            address += node.InnerText;
            //address += " ";
          }

          if (0 < address.Length)
            return address;

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
