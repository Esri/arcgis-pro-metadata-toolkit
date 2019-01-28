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

namespace $safeprojectname$.Pages
{
  internal class MetadataContactsSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return MetadataContactsSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return $safeprojectname$.Properties.Resources.CFG_LBL_METADATACONTACTS; }
    }
  }
  /// <summary>
  /// Interaction logic for MTK_MetadataContacts.xaml
  /// </summary>
  internal partial class MTK_MetadataContacts : EditorPage
  {
    public MTK_MetadataContacts()
    {
      InitializeComponent();
    }

    public override string SidebarLabel
    {
      get { return MetadataContactsSidebarLabel.SidebarLabel; }
    }
  }
}
