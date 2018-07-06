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

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  internal class ResourceCitationContactsSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ResourceCitationContactsSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return Internal.Metadata.Properties.Resources.CFG_LBL_RESOURCECITATIONCONTACTS; }
    }
  }
  /// <summary>
  /// Interaction logic for ResourceCitationContacts.xaml
  /// </summary>
  internal partial class ResourceCitationContacts : EditorPage
  {
    public ResourceCitationContacts()
    {
      InitializeComponent();
    }

    public override string SidebarLabel
    {
      get { return ResourceCitationContactsSidebarLabel.SidebarLabel; }
    }
  }
}
