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
using System.Linq;
using System.Xml;

using ArcGIS.Desktop.Metadata.Editors.ClassicEditor.Pages;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_CI_OnlineResource.xaml
  /// </summary>
  internal partial class MTK_CI_OnlineResource : EditorPage
  {
    public MTK_CI_OnlineResource()
    {
      InitializeComponent();
      Loaded += CI_OnlineResource_Loaded;
    }

    private void CI_OnlineResource_Loaded(object sender, RoutedEventArgs e)
    {
      SetDefaults();
    }

    private void SetDefaults()
    {
      object context = Utils.Utils.GetDataContext(this);
      IEnumerable<XmlNode> nodes = Utils.Utils.GetXmlDataContext(context);
      if (null != nodes)
      {
        var node = nodes.First();
        XmlNode linkageNode = node.SelectSingleNode("linkage");
        if (linkageNode != null && !string.IsNullOrWhiteSpace(DefaultLinkage) && string.IsNullOrWhiteSpace(linkageNode.InnerText))
        {
          linkageNode.InnerText = DefaultLinkage;
        }
      }
    }

    public static readonly DependencyProperty DefaultLinkageProperty = DependencyProperty.Register(
       "DefaultLinkage",
       typeof(string),
       typeof(MTK_CI_OnlineResource));

    public string DefaultLinkage
    {
      get { return (string)this.GetValue(DefaultLinkageProperty); }
      set { this.SetValue(DefaultLinkageProperty, value); }
    }
  }
}
