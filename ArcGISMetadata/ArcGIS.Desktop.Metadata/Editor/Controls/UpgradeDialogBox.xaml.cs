/*
COPYRIGHT 1995-2012 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States and applicable international
laws, treaties, and conventions.
 
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts and Legal Services Department
380 New York Street
Redlands, California, 92373
USA
 
email: contracts@esri.com
*/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Navigation;

namespace ArcGIS.Desktop.Metadata.Editor.Controls
{
  /// <summary>
  /// Interaction logic for UpgradeDialogBox.xaml
  /// </summary>
  internal partial class UpgradeDialogBox : Window
  {

    //public bool SupressUpgradeDialog
    //{
    //  get;
    //  set;
    //}

    public UpgradeDialogBox()
    {
      InitializeComponent();
    }

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
      Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
      e.Handled = true;
    }

    void okButton_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = true;
    }

    void cancelButton_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = false;
    }
  }
}
