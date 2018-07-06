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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ArcGIS.Desktop.Metadata.Editor.Convert
{
  public class XmlNodeToLabelConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string strValue = value as string;

      if (!string.IsNullOrEmpty(strValue))
      {
        try
        {
          var t = Type.GetType(strValue + "SidebarLabel");
          
          // No lightweight SidebarLabe object available
          // fallback to default object if available.
          if (null == t)
          {
            t = Utils.GetType(ArcGIS.Desktop.Internal.Metadata.Properties.Settings.Default.MetadataStyle, strValue);
          }

          if (t != null)
          {
            var node = System.Activator.CreateInstance(t) as ISidebarLabel;
            return (null != node) ? node.SidebarLabel : strValue;
          }
        }
        catch (Exception)
        {
          // Swallow
        }
      }

      return strValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value;
    }
  }
}
