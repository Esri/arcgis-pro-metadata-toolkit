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
  internal class ResourceExtentSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ResourceExtentSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return MetadataToolkit.Properties.Resources.CFG_LBL_RESOURCEEXTENT; }
    }
  }
  /// <summary>
  /// Interaction logic for MTK_ResourceExtent.xaml
  /// </summary>
  internal partial class MTK_ResourceExtent : EditorPage
  {
    public MTK_ResourceExtent()
    {
      InitializeComponent();
    }

    public override string SidebarLabel
    {
      get { return ResourceExtentSidebarLabel.SidebarLabel; }
    }
  }
}
