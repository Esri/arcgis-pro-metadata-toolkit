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
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ArcGIS.Desktop.Metadata.Pages.Converters
{
  public class LocaleConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      String locale = value as String;

      if (string.IsNullOrEmpty(locale))
        return string.Empty;

      if (3 == locale.Length)
        return value;

      try
      {
        CultureInfo cinfo = new CultureInfo(locale);
        return cinfo.ThreeLetterISOLanguageName;
      }
      catch
      {
        // Swallow
      }

      return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      return value;
    }
  }
}
