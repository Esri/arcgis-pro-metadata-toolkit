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
using System.Windows.Media;

namespace ArcGIS.Desktop.Metadata.Pages.Converters
{
  public class ListBoxItemToAutomationIdConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      var lbi = value as ListBoxItem;
      if (null != lbi)
      {
        string autoId = parameter as String;
        if (string.IsNullOrEmpty(autoId))
          autoId = string.Empty;

        ListBox lb = ItemsControl.ItemsControlFromItemContainer(lbi) as ListBox;
        if (null != lb)
        {
          int index = lb.ItemContainerGenerator.IndexFromContainer(lbi);
          if (index >= 0)
          {
            return autoId + "_" + index;
          }
        }
      }

      //if there is no listbox and parameter is valid, just return it.
      return parameter as String;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // NOOP
      return null;
    }
  }
}
