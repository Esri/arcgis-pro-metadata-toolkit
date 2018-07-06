/*
COPYRIGHT 2013-2016 ESRI

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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ArcGIS.Desktop.Metadata.Editor;

namespace ArcGIS.Desktop.Internal.Metadata
{
  /// <summary>
  /// Interaction logic for MetadataEditorContentsView.xaml
  /// </summary>
  public partial class MetadataEditorContentsView : UserControl
  {
    public MetadataEditorContentsView()
    {
      InitializeComponent();
    }

    private void LoadSelectedPage()
    {
      var vm = this.DataContext as MetadataEditorViewModel;
      if (null != vm)
      {
        var page = _metadataContents.SelectedItem as System.Xml.XmlNode;
        if (page != null && page.Name == "page")
        {
          _metadataContents.Dispatcher.Invoke(() =>
          {
            vm.LoadPage(page);
          });
        }
      }
    }

    private void TreeView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      LoadSelectedPage();
    }

    private void TreeView_PreviewKeyUp(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        LoadSelectedPage();
      }
    }
  }
}
