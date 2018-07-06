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
using System.Xml;

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  [ValueConversion(typeof(Visibility), typeof(string))]
  public class VisibleEmptyConverter : IValueConverter
  {

    public bool Collapse { get; set; }

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // in: value of xml node
      // out: Visibility

      // null and strings
      if (null == value || (value is string && string.Empty.Equals(value as string)))
        return Visibility.Collapsed;

      // xml nodes
      if (value is XmlElement && String.Empty.Equals(((XmlElement)value).InnerText.Trim()))
        return Visibility.Collapsed;

      // xml attributes
      if (value is XmlAttribute && String.Empty.Equals(((XmlAttribute)value).Value.Trim()))
        return Visibility.Collapsed;

      // fallback
      return Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
