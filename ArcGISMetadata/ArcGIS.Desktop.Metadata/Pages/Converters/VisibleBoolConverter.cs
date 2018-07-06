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
using System.Windows.Data;
using System.Windows;

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  [ValueConversion(typeof(Visibility), typeof(string))]
  public class VisibleBoolConverter : IValueConverter
  {

    public bool Collapse { get; set; }

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (value is bool)
      {
        return (bool)value ? Visibility.Visible : (Collapse ? Visibility.Collapsed : Visibility.Hidden);
      }
      else if (value is string)
      {
        if (String.Empty.Equals(value) || "False".Equals((string)value, StringComparison.InvariantCultureIgnoreCase))
          return Collapse ? Visibility.Collapsed : Visibility.Hidden;
        else
          return Visibility.Visible;
      }
      else
      {
        // default
        return Visibility.Visible;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // NOOP
      return null;
    }
  }
}
