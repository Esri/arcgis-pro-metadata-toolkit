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
  public class StringToBoolConverter : IValueConverter
  {
    private bool _isString = true;

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // convert to string and trim
      string v = value as string;
      if (null == v)
        return false;

      v = v.Trim();

      // is a string representation of boolean?
      _isString = "true".Equals(v, StringComparison.InvariantCultureIgnoreCase) || "false".Equals(v, StringComparison.InvariantCultureIgnoreCase);

      // default
      bool bValue = false;

      if (_isString)
        bValue = "true".Equals(v, StringComparison.InvariantCultureIgnoreCase);
      else if ("1".Equals(v))
        bValue = true;

      return bValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // convert to boolean
      Boolean b = (Boolean) value;

      if (b.Equals(true))
        return (_isString ? "True" : "1");
      else
        return (_isString ? "False" : "0");
    }  
  }
}
