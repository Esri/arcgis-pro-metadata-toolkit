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

using System;
using System.ComponentModel;
using System.Windows;
using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace MetadataToolkit
{
  /// <summary>
  /// Interaction logic for MTK_CI_Citation.xaml
  /// </summary>
  internal partial class MTK_CI_Citation : EditorPage, INotifyPropertyChanged
  {
    public MTK_CI_Citation()
    {
      InitializeComponent();
    }

    public static readonly DependencyProperty SupressPartiesProperty = DependencyProperty.Register(
       "SupressParties",
       typeof(Boolean),
       typeof(MTK_CI_Citation));

    public static readonly DependencyProperty SupressOnlineResourceProperty = DependencyProperty.Register(
       "SupressOnlineResource",
       typeof(Boolean),
       typeof(MTK_CI_Citation));

    public Boolean SupressParties
    {
      get { return (Boolean)this.GetValue(SupressPartiesProperty); }
      set { this.SetValue(SupressPartiesProperty, value); }
    }

    public Boolean SupressOnlineResource
    {
      get { return (Boolean)this.GetValue(SupressOnlineResourceProperty); }
      set { this.SetValue(SupressOnlineResourceProperty, value); }
    }

  }
}
