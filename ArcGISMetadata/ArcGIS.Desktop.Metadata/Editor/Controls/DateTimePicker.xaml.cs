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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace ArcGIS.Desktop.Metadata.Editor.Controls
{
  /// <summary>
  /// Interaction logic for DateTimePicker.xaml
  /// </summary>
  public partial class DateTimePicker : UserControl
  {
    public DateTimePicker()
    {
      InitializeComponent();
    }

    [DefaultValue(true)]
    public bool? DisplayTime
    {
      get { return (bool)GetValue(DisplayTimeProperty) || (null != SelectedDate && null != SelectedDate.Value); }
      set { SetValue(DisplayTimeProperty, value); }
    }

    public static readonly DependencyProperty DisplayTimeProperty =
      DependencyProperty.Register("DisplayTime", typeof(bool?), typeof(DateTimePicker), new PropertyMetadata(true));

    public DateTime? CalendarDate
    {
      get { return (DateTime?)GetValue(CalendarDateProperty); }
      set { SetValue(CalendarDateProperty, value); }
    }

    public static readonly DependencyProperty CalendarDateProperty =
       DependencyProperty.Register("CalendarDate", typeof(DateTime?), typeof(DateTimePicker), new PropertyMetadata(null, new PropertyChangedCallback(CalendarDateChanged)));

    private static void CalendarDateChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
    {
      if (null != args.NewValue)
      {
        // new date
        DateTime? value = (DateTime?)args.NewValue; // element.GetValue(DateTimePicker.SelectedDateProperty);

        // old date
        DateTime? oldTime = (DateTime?)element.GetValue(DateTimePicker.SelectedDateProperty);
        if (null == oldTime)
          oldTime = new DateTime();

        // set the dependent dates      
        var newDate = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, oldTime.Value.Hour, oldTime.Value.Minute, oldTime.Value.Second, DateTimeKind.Local);
        element.SetValue(DateTimePicker.SelectedDateProperty, newDate);
      }
    }

    public DateTime? CalendarTime
    {
      get { return (DateTime?)GetValue(CalendarTimeProperty); }
      set { SetValue(CalendarTimeProperty, value); }
    }

    public static readonly DependencyProperty CalendarTimeProperty =
       DependencyProperty.Register("CalendarTime", typeof(DateTime?), typeof(DateTimePicker), new PropertyMetadata(null, new PropertyChangedCallback(CalendarTimeChanged)));

    private static void CalendarTimeChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
    {
      if (null != args.NewValue)
      {
        // new time
        DateTime? value = (DateTime?)args.NewValue; // element.GetValue(DateTimePicker.SelectedDateProperty);

        // old date
        DateTime? oldDate = (DateTime?)element.GetValue(DateTimePicker.SelectedDateProperty);

        // set the dependent dates      
        var newDate = new DateTime(oldDate.Value.Year, oldDate.Value.Month, oldDate.Value.Day, value.Value.Hour, value.Value.Minute, value.Value.Second, DateTimeKind.Local);
        element.SetValue(DateTimePicker.SelectedDateProperty, newDate);
      }     
    }

    public DateTime? SelectedDate
    {
      get { return (DateTime?)GetValue(SelectedDateProperty); }
      set { SetValue(SelectedDateProperty, value); }
    }

    public static readonly DependencyProperty SelectedDateProperty =
        DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(DateTimePicker), new PropertyMetadata(null, new PropertyChangedCallback(SelectedDateChanged)));

    private static void SelectedDateChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
    {

      if (null != args.NewValue)
      {
        DateTime? value = (DateTime?)args.NewValue; // element.GetValue(DateTimePicker.SelectedDateProperty);

        // set the dependent dates      
        var calDate = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, value.Value.Hour, value.Value.Minute, value.Value.Second, DateTimeKind.Local);
        var calTime = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, value.Value.Hour, value.Value.Minute, value.Value.Second, DateTimeKind.Local);
        element.SetValue(DateTimePicker.CalendarDateProperty, calDate);
        element.SetValue(DateTimePicker.CalendarTimeProperty, calTime);
      }
    }
  }
}
