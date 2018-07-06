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
using System.Windows.Markup;
using System.Windows;

namespace ArcGIS.Desktop.Metadata.Editor.Controls
{
  public class TimeConverter : IValueConverter
  {
    private const string dateSep = "-"; // ISO prefered, otherwise you could do this => culture.DateTimeFormat.DateSeparator;
    private const string timeSep = ":"; // ISO prefered, otherwise you could do this => culture.DateTimeFormat.TimeSeparator;
    private const string nullValue = "";
    private const string exceptionValue = "?";

    private bool IsRTL
    {
      get { return System.Threading.Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft; }
    }

    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {


      if (value is Nullable<TimePicker.DisplayOptions>)
      {
        TimePicker.DisplayOptions displayOptions = (value as Nullable<TimePicker.DisplayOptions>).Value;

        switch ((string)parameter)
        {
          case "Date":
            if (TimePicker.DisplayOptions.DateOnly == displayOptions || TimePicker.DisplayOptions.DateTime == displayOptions)
              return Visibility.Visible;
            else
              return Visibility.Collapsed;

          case "Time":
            if (TimePicker.DisplayOptions.TimeOnly == displayOptions || TimePicker.DisplayOptions.DateTime == displayOptions)
              return Visibility.Visible;
            else
              return Visibility.Collapsed;

          default:
            return Visibility.Visible;
        }
      }
      else if (null == value)
      {
        return nullValue;
        //switch ((string)parameter)
        //{
        //  case "dateSep":
        //    return dateSep;

        //  case "sep":
        //    return timeSep;

        //  default:
        //    return nullValue;
        //}
      }
      else
      {
        DateTime dTime = ((DateTime?)value).Value;
        int hc = dTime.GetHashCode();
        switch ((string)parameter)
        {
          case "year":
            return dTime.ToString("yyyy");

          case "month":
            return dTime.ToString("MM");

          case "day":
            return dTime.ToString("dd");

          case "hour":
            return dTime.ToString(IsRTL ? "ss" : "HH");

          case "min":
            return dTime.ToString("mm");

          case "sec":
            return dTime.ToString(IsRTL ? "HH" : "ss");

          case "dateSep":
            return dateSep;

          case "sep":
            return timeSep;

          //case "ampm":
          //  return dTime.ToString(_formats['t']);

          //case "ampmsep":
          //  return _merdianSeparator;

          //case "pre":
          //  return _preMeridian ? Visibility.Visible : Visibility.Collapsed;

          //case "post":
          //  return _postMeridian ? Visibility.Visible : Visibility.Collapsed;
        }
      }

      // fallback
      return exceptionValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
