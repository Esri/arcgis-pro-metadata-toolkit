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

namespace $safeprojectname$
{
  internal class ResourceConstraintsSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ResourceConstraintsSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return $safeprojectname$.Properties.Resources.CFG_LBL_RESOURCECONSTRAINTS; }
    }
  }
  /// <summary>
  /// Interaction logic for MTK_ResourceConstraints.xaml
  /// </summary>
  internal partial class MTK_ResourceConstraints : EditorPage
  {
    public MTK_ResourceConstraints()
    {
      InitializeComponent();
    }

    public override string SidebarLabel
    {
      get { return ResourceConstraintsSidebarLabel.SidebarLabel; }
    }
  }
}
