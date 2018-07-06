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
using System.Text.RegularExpressions;
using System.Windows;
using System.Globalization;

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  public class DateConverter : IValueConverter
  {

    private const string ISO_FORMAT = "s";
    private const string FGDC_FORMAT = "yyyyMMdd";
    private static CultureInfo enCulture = new CultureInfo("en-US");

    public DateConverter() { }

    public DateConverter(string format)
    {
      this.Format = format;
    }

    /// <summary>
    /// date time format string
    /// </summary>
    public string Format { get; set; }

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // in: XML tag text
      // out: DateTime?

      string ds = value as string;
      if ( ! string.IsNullOrEmpty(ds))
      {
        // if matching YYYYMMDD, transform into ISO, something that DateTime can parse...
        if (Regex.Match(ds, @"^\d{8}$").Success) // YYYYMMDD
          ds = Regex.Replace(ds, @"^(\d\d\d\d)(\d\d)(\d\d)$", @"$1-$2-$3");
        else if (Regex.Match(ds, @"^\d{6}$").Success) // YYYYMM
          ds = Regex.Replace(ds, @"^(\d\d\d\d)(\d\d)$", @"$1-$2-01");
        else if (Regex.Match(ds, @"^\d{4}$").Success) // YYYY
          ds = Regex.Replace(ds, @"^(\d\d\d\d)$", @"$1-01-01");

        try
        {
          // DateTime tagDateTime = DateTime.Parse(ds);
          DateTime? ndt = new DateTime?(DateTime.Parse(ds, enCulture));
          int hc = ndt.GetHashCode();
          DateTime ldt = DateTime.SpecifyKind(ndt.Value, DateTimeKind.Local);
          return ldt;
        }
        catch (FormatException) { /* noop */ }
      }

      // fallback
      return new DateTime?();
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // in: DateTime?      
      // out: XML tag text

      DateTime? dateTime = value as DateTime?;

      if (null == value || dateTime == null || (null != dateTime && null == dateTime.Value))
      {
        return String.Empty;
      }
      else
      {
        if (null == this.Format || string.Empty.Equals(this.Format))
          return dateTime.Value.ToString(FGDC_FORMAT, enCulture);
        else
          return dateTime.Value.ToString(this.Format, enCulture);
      }
    }
  }
}
