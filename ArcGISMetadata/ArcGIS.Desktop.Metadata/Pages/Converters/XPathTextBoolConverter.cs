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

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  public class XPathTextBoolConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // convert to string and trim
      string p = parameter as string;
      if (null == p)
        return false;
      p = p.Trim();

      // get mode
      bool mode = "true".Equals(p, StringComparison.InvariantCultureIgnoreCase) ||
        "1".Equals(p);

      // from string in xml element to DateTime
      string tagText = value as string;
      if (null == tagText || 0 == tagText.Trim().Length)
        return !mode;
      else
        return mode;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      return null;
    }
  
  }
}
