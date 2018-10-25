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
  internal class ResourceCitationContactsSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ResourceCitationContactsSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return $safeprojectname$.Properties.Resources.CFG_LBL_RESOURCECITATIONCONTACTS; }
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
