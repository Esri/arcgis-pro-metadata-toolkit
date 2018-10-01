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

namespace MetadataToolkit.Pages
{
  internal class ReferencesSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ReferencesSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return MetadataToolkit.Properties.Resources.CFG_LBL_RES_REF; }
    }
  }
  /// <summary>
  /// Interaction logic for MTK_References.xaml
  /// </summary>
  internal partial class MTK_References : EditorPage
  {
    public MTK_References()
    {
      InitializeComponent();
    }

    public override string SidebarLabel
    {
      get { return ReferencesSidebarLabel.SidebarLabel; }
    }
  }
}
