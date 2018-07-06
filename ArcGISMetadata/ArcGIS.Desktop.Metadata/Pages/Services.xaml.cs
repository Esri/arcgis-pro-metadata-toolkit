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
  internal class ServicesSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ServicesSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return Internal.Metadata.Properties.Resources.CFG_LBL_SERVICES; }
    }
  }
  /// <summary>
  /// Interaction logic for Services.xaml
  /// </summary>
  internal partial class Services : EditorPage
  {
    public Services()
    {
      InitializeComponent();
    }

    public override string SidebarLabel
    {
      get { return ServicesSidebarLabel.SidebarLabel; }
    }
  }
}
