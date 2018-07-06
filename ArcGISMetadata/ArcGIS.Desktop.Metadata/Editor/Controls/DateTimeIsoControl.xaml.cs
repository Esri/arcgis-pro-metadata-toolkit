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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Xml;
using ArcGIS.Desktop.Metadata.Editor.Pages;
using ArcGIS.Desktop.Internal.Metadata;

namespace ArcGIS.Desktop.Metadata.Editor.Controls
{
  /// <summary>
  /// Interaction logic for DateTime.xaml
  /// </summary>
  public partial class DateTimeIsoControl : UserControl
  {
    public DateTimeIsoControl()
    {
      InitializeComponent();
    }

    public IEnumerable Items
    {
      get { return (IEnumerable)GetValue(ItemsProperty); }
      set { SetValue(ItemsProperty, value); }
    }

    public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register("Items", typeof(IEnumerable), typeof(DateTimeIsoControl), new FrameworkPropertyMetadata());

    /// <summary>
    /// Clears an XML element
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ClearItem(Object sender, RoutedEventArgs e)
    {
      string message = Internal.Metadata.Properties.Resources.MSGBOX_DELETE_MSG;
      string caption = Internal.Metadata.Properties.Resources.MSGBOX_DELETE_CAPTION;
      MessageBoxButton button = MessageBoxButton.OKCancel;
      MessageBoxImage icon = MessageBoxImage.Question;

      // show dialog
      MessageBoxResult result = ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox(message, caption, button, icon);
      switch (result)
      {
        case MessageBoxResult.Cancel:
          return;
      }

      // get tag
      string tag = Utils.GetStringTag(sender);

      // get the data context and apply fill to each element
      IEnumerable<XmlNode> data = Utils.GetXmlDataContext(Utils.GetDataContext(sender));
      if (null != data)
      {
        foreach (XmlNode node in data)
        {
          // remove the element from the tree
          node.InnerXml = String.Empty;
          MetadataEditorViewModel.UpdateDataContext(this as DependencyObject);
          break;
        }
      }
    }
  }
}
