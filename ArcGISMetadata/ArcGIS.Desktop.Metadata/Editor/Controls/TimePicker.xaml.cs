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
using System.Xml;
using System.Threading;

namespace ArcGIS.Desktop.Metadata.Editor.Controls
{
  /// <summary>
  /// Interaction logic for TimePicker.xaml
  /// </summary>
  public partial class TimePicker : UserControl
  {
    public TimePicker()
    {
      _focusChanged = false;
      _loosingFocus = false;
      _gainingFocus = false;
      InitializeComponent();
    }

    private bool _focusChanged;
    private string _timeSelection;

    // bound on the xaml side by XML
    public DateTime? Value
    {
      get { return (DateTime?)GetValue(ValueProperty); }
      set { SetValue(ValueProperty, value); }
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(DateTime?), typeof(TimePicker), new FrameworkPropertyMetadata());

    // bound on the xaml side by XML
    public DisplayOptions? Display
    {
      get { return (DisplayOptions?)GetValue(DisplayProperty); }
      set { SetValue(DisplayProperty, value); }
    }

    public enum DisplayOptions { DateOnly, TimeOnly, DateTime };

    public static readonly DependencyProperty DisplayProperty =
    DependencyProperty.Register("Display", typeof(DisplayOptions?), typeof(TimePicker), new FrameworkPropertyMetadata(DisplayOptions.DateTime));

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      DateTimeComponent component = DateTimeComponent.unknown;
      switch (((FrameworkElement)sender).Name)
      {
        case "seconds":
          component = DateTimeComponent.seconds;
          break;
        case "minutes":
          component = DateTimeComponent.minutes;
          break;
        case "hours":
          component = DateTimeComponent.hours;
          break;
        case "day":
          component = DateTimeComponent.day;
          break;
        case "month":
          component = DateTimeComponent.month;
          break;
        case "year":
          component = DateTimeComponent.year;
          break;
        case "postMeridian":
          component = DateTimeComponent.post_meridian;
          break;
        case "preMeridian":
          component = DateTimeComponent.pre_meridian;
          break;
      }
      
      if (DateTimeComponent.unknown != component)
        ChangeTime(component, e.Key);

      e.Handled = true;
    }

    private enum DateTimeComponent {unknown, seconds, minutes, hours, day, month, year, pre_meridian, post_meridian };
    private enum DateTimeModDirection { inc, dec }
    delegate DateTime ModDate(DateTime dt);

    private void ChangeTime(DateTimeComponent component, Key key )
    {
      if (null == Value || null == Value.Value)
        return;

      int hours = Value.Value.Hour;
      int minutes = Value.Value.Minute;
      int seconds = Value.Value.Second;

      ModDate modDate = null;
      bool use24HourTime = true; ///*string.IsNullOrEmpty(preMeridian.Text) && */ string.IsNullOrEmpty(postMeridian.Text);

      if (Key.Up == key)
      {
        switch (component)
        {
          case DateTimeComponent.seconds:
            if (seconds + 1 >= 60)
            {
              seconds = 0;
              goto case DateTimeComponent.minutes;
            }
            else
              seconds++;
            break;

          case DateTimeComponent.minutes:
            if (minutes + 1 >= 60)
            {
              minutes = 0;
              goto case DateTimeComponent.hours;
            }
            else
              minutes++;
            break;

          case DateTimeComponent.hours:
            if (hours + 1 >= 24)
            {
              hours = 0;
              goto case DateTimeComponent.day;
            }
            else
              hours++;
            break;

          case DateTimeComponent.day:
            // inc day
            modDate = (dt) => { return dt.AddDays(1); };
            break;

          case DateTimeComponent.month:
            // inc month
            modDate = (dt) => { return dt.AddMonths(1); };
            break;

          case DateTimeComponent.year:
            // inc year
            modDate = (dt) => { return dt.AddYears(1); };
            break;

          case DateTimeComponent.pre_meridian:
          case DateTimeComponent.post_meridian:
            if (hours < 12)
              hours += 12;
            else
              hours -= 12;
            break;
        }
       
      }
      else if (Key.Down == key)
      {
        switch (component)
        {
          case DateTimeComponent.seconds:
            if (seconds - 1 < 0)
            {
              seconds = 59;
              goto case DateTimeComponent.minutes;
            }
            else
              seconds--;
            break;

          case DateTimeComponent.minutes:
            if (minutes - 1 < 0)
            {
              minutes = 59;
              goto case DateTimeComponent.hours;
            }
            else
              minutes--;
            break;

          case DateTimeComponent.hours:
            if (hours - 1 < 0)
            {
              hours = 23;
              goto case DateTimeComponent.day;
            }
            else
              hours--;
            break;

          case DateTimeComponent.day:
            // dec day
            modDate = (dt) => { return dt.AddDays(-1); };
            break;

          case DateTimeComponent.month:
            // dec month
            modDate = (dt) => { return dt.AddMonths(-1); };
            break;

          case DateTimeComponent.year:
            // dec year
            modDate = (dt) => { return dt.AddYears(-1); };
            break;

          case DateTimeComponent.pre_meridian:
          case DateTimeComponent.post_meridian:
            if (hours < 12)
              hours += 12;
            else
              hours -= 12;
            break;
        }
      }
      else if ((key >= Key.D0 && key <= Key.D9) || (key >= Key.NumPad0 && key <= Key.NumPad9))
      {
        int number = (int)key - ((key >= Key.D0 && key <= Key.D9) ? (int)Key.D0 : (int)Key.NumPad0);

        bool tryToAdd = !_focusChanged;
        _focusChanged = false;

        switch (component)
        {
          case DateTimeComponent.seconds:
            if (tryToAdd && seconds < 6)
              number += seconds * 10;
            seconds = number;
            break;

          case DateTimeComponent.minutes:
            if (tryToAdd && minutes < 6)
              number += minutes * 10;
            minutes = number;
            break;

          case DateTimeComponent.hours:
            if (use24HourTime)
            {
              if (tryToAdd && (hours == 1 || (hours == 2 && number <= 3)))
                number += hours * 10;
              hours = number;
            }
            else
            {
              if (tryToAdd && (hours % 12) == 1 && number <= 2)
                number += 10;
              else if (number == 0)
                break; // In 12 hour time, 0 is only value after a 1.
              hours = number + (hours >= 12 ? 12 : 0) + (number == 12 ? -12 : 0);
            }
            break;
        }
      }
      else if ((( DateTimeComponent.pre_meridian == component ) || ( DateTimeComponent.post_meridian == component) && (key == Key.A || key == Key.P)))
      {
        if (key== Key.A && hours >= 12)
        {
          hours -= 12;
        }
        else if (key == Key.P && hours < 12)
        {
          hours += 12;
        }
      }

      if (hours != Value.Value.Hour || minutes != Value.Value.Minute || seconds != Value.Value.Second)
        Value = new DateTime(Value.Value.Year, Value.Value.Month, Value.Value.Day, hours, minutes, seconds);
      if (null != modDate)
        Value = modDate(Value.Value);    
    }

    private void OnTimeInc(object sender, RoutedEventArgs e)
    {
      ChangeTime(DateTimeComponent.hours, Key.Up);
    }

    private void OnTimeDec(object sender, RoutedEventArgs e)
    {
      ChangeTime(DateTimeComponent.hours, Key.Down);
    }

    // Suppress focus change events when moving between internal controls.
    private bool _loosingFocus;
    private bool _gainingFocus;
    private void OnPreviewLostKFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (e.NewFocus != null)
        _loosingFocus = true;
    }

    private void OnPreviewGotKFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (e.OldFocus != null)
        _gainingFocus = true;
    }

    private void OnGotFocus(object sender, RoutedEventArgs e)
    {
      var textBlock = sender as TextBlock;
      _timeSelection = textBlock.Name;

      //textBlock.Background = new SolidColorBrush(Colors.LightBlue);
      _focusChanged = true;
      if (_loosingFocus)
      {
        e.Handled = true;
        _loosingFocus = false;
      }
      else
        _gainingFocus = false;
    }

    private void OnLostFocus(object sender, RoutedEventArgs e)
    {
      var textBlock = sender as TextBlock;
      _timeSelection = null;
      //textBlock.Background = new SolidColorBrush(Colors.White);
      if (_gainingFocus)
      {
        e.Handled = true;
        _gainingFocus = false;
      }
      else
        _loosingFocus = false;
    }

    private void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
      var textBlock = sender as TextBlock;
      textBlock.Focus();
    }
  }
}
