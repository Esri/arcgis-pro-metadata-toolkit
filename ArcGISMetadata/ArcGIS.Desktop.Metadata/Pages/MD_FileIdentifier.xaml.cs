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
using System.Windows.Controls;

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  /// <summary>
  /// Interaction logic for MD_FileIdentifier.xaml
  /// </summary>
  internal partial class MD_FileIdentifier : EditorPage
  {
    public MD_FileIdentifier()
    {
      InitializeComponent();
    }
    public void GenerateGuid(object sender, EventArgs e)
    {
      var guid = System.Guid.NewGuid().ToString().ToUpper();
      fileIDField.Text = guid;
      fileIDField.GetBindingExpression(TextBox.TextProperty).UpdateSource();
    }
  }
}
