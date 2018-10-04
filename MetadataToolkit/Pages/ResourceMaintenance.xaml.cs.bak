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

using ArcGIS.Desktop.Metadata;
using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace MetadataToolkit
{
  internal class ResourceMaintenanceSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ResourceMaintenanceSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return MetadataToolkit.Properties.Resources.CFG_LBL_RESOURCEMAINTENANCE; }
    }
  }
  /// <summary>
  /// Interaction logic for MTK_ResourceMaintenance.xaml
  /// </summary>
  internal partial class MTK_ResourceMaintenance : EditorPage
  {
    public MTK_ResourceMaintenance()
    {
      InitializeComponent();
    }

    public override string SidebarLabel
    {
      get { return ResourceMaintenanceSidebarLabel.SidebarLabel; }
    }
  }
}
