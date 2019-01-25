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

using ArcGIS.Desktop.Metadata;
using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace MetadataToolkit.Pages
{
  internal class EntityAttributeInfoSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return EntityAttributeInfoSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return MetadataToolkit.Properties.Resources.CFG_LBL_ENTITYATTRIBUTEINFO; }
    }
  }
  /// <summary>
  /// Interaction logic for MTK_EntityAttributeInfo.xaml
  /// </summary>
  internal partial class MTK_EntityAttributeInfo : EditorPage
  {
    public MTK_EntityAttributeInfo()
    {
      InitializeComponent();
    }

    public override string SidebarLabel
    {
      get { return EntityAttributeInfoSidebarLabel.SidebarLabel; }
    }
  }
}
