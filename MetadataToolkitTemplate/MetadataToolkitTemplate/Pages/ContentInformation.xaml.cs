﻿/*
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

namespace $safeprojectname$.Pages
{
  internal class ContentInformationSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ContentInformationSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return $safeprojectname$.Properties.Resources.CFG_LBL_CONTENTINFORMATION; }
    }    
  }
  /// <summary>
  /// Interaction logic for MTK_ContentInformation.xaml
  /// </summary>
  internal partial class MTK_ContentInformation : EditorPage
  {
    public MTK_ContentInformation()
    {
      InitializeComponent();
    }

    public override string SidebarLabel
    {
      get { return ContentInformationSidebarLabel.SidebarLabel; }
    }
  }
}