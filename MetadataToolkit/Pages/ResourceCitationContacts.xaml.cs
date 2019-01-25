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
  internal class ResourceCitationContactsSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ResourceCitationContactsSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return MetadataToolkit.Properties.Resources.CFG_LBL_RESOURCECITATIONCONTACTS; }
    }
  }
  /// <summary>
  /// Interaction logic for MTK_ResourceCitationContacts.xaml
  /// </summary>
  internal partial class MTK_ResourceCitationContacts : EditorPage
  {
    public MTK_ResourceCitationContacts()
    {
      InitializeComponent();
    }

    public override string SidebarLabel
    {
      get { return ResourceCitationContactsSidebarLabel.SidebarLabel; }
    }
  }
}
