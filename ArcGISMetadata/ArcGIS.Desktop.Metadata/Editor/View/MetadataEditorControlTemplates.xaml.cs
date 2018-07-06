/*
COPYRIGHT 1995-2012 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States and applicable international
laws, treaties, and conventions.
 
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts and Legal Services Department
380 New York Street
Redlands, California, 92373
USA
 
email: contracts@esri.com
*/
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Input;
using ArcGIS.Desktop.Metadata.Editor.Controls;

namespace ArcGIS.Desktop.Metadata.Editor.Themes
{
  public partial class GenericDictionary : ResourceDictionary
  {
    /// <summary>
    /// handle the tooltip opening
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void UpdateStatusOpenTip(object sender, ToolTipEventArgs e)
    {
      e.Handled = true;

      if (e.Source is FrameworkElement)
      {
        FrameworkElement fe = e.Source as FrameworkElement;
        string tooltip = fe.ToolTip as string;

        // do nothing if null
        if (null == tooltip)
          return;       

        var mevm = Utils.GetMetadataEditorViewModel(fe);
        mevm.UpdateStatus(tooltip);
      }
    }

    private void PART_Grip_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ClickCount == 1)
      {
        (sender as FrameworkElement).CaptureMouse();
        Resizer.StartResizeCommand.Execute(sender as FrameworkElement, sender as FrameworkElement);
        e.Handled = true;
      }
    }

    private void PART_Grip_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      FrameworkElement resizeGrip = sender as FrameworkElement;
      Debug.Assert(resizeGrip != null);

      if (resizeGrip.IsMouseCaptured)
      {
        Resizer.EndResizeCommand.Execute(null, sender as FrameworkElement);
        resizeGrip.ReleaseMouseCapture();
        e.Handled = true;
      }
    }

    private void PART_Grip_MouseMove(object sender, MouseEventArgs e)
    {
      if ((sender as FrameworkElement).IsMouseCaptured)
      {
        Resizer.UpdateSizeCommand.Execute(null, sender as FrameworkElement);
        e.Handled = true;
      }
    }

    private void PART_Grip_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        Resizer.AutoSizeCommand.Execute(null, sender as FrameworkElement);
        e.Handled = true;
      }
    }
  }

  internal sealed class GripAlignmentConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      Orientation orientation = (Orientation)parameter;
      ResizeDirection resizeDirection = (ResizeDirection)value;

      switch (orientation)
      {
        case Orientation.Horizontal:
          if (resizeDirection == ResizeDirection.NorthEast || resizeDirection == ResizeDirection.SouthEast)
          {
            return HorizontalAlignment.Right;
          }
          else
          {
            return HorizontalAlignment.Left;
          }
        case Orientation.Vertical:
          if (resizeDirection == ResizeDirection.NorthEast || resizeDirection == ResizeDirection.NorthWest)
          {
            return VerticalAlignment.Top;
          }
          else
          {
            return VerticalAlignment.Bottom;
          }
      }
      return DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      return DependencyProperty.UnsetValue;
    }
  }

  internal sealed class GripCursorConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      ResizeDirection resizeDirection = (ResizeDirection)value;
      switch (resizeDirection)
      {
        case ResizeDirection.NorthEast:
        case ResizeDirection.SouthWest:
          return Cursors.SizeNESW;
        case ResizeDirection.NorthWest:
        case ResizeDirection.SouthEast:
          return Cursors.SizeNWSE;
      }
      return DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      return DependencyProperty.UnsetValue;
    }
  }

  internal sealed class GripRotationConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      ResizeDirection resizeDirection = (ResizeDirection)value;
      switch (resizeDirection)
      {
        case ResizeDirection.SouthWest:
          return 90;
        case ResizeDirection.NorthWest:
          return 180;
        case ResizeDirection.NorthEast:
          return 270;
      }
      return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      return DependencyProperty.UnsetValue;
    }
  }
}
