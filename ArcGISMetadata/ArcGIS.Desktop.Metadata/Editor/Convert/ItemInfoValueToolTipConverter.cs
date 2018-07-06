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
using System.Globalization;
using System.Windows.Data;
using ESRI.ArcGIS.ItemIndex;

namespace ArcGIS.Desktop.Metadata.Editor.Convert
{
  public class ItemInfoValueToolTipConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var prop = parameter as string;
      if (string.IsNullOrEmpty(prop)) return null;

      Core.Item item = (Core.Item)value;

      if (prop.Equals("Title")) return item.Name;
      if (prop.Equals("Path"))
      {
        if (!string.IsNullOrEmpty(item.Path) && !item.Path.StartsWith("CIMPATH"))
        {
          return item.Path;
        }
      }
      return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value;
    }
  }
}
