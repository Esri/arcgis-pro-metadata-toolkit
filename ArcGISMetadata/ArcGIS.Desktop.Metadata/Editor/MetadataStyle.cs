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
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace ArcGIS.Desktop.Metadata.Editor
{
  internal class MetadataStyle : ContentControl
  {
    private string _onlyList;
    private string _exceptList;

    public static readonly DependencyProperty OnlyProfilesProperty = DependencyProperty.RegisterAttached(
      "OnlyProfiles",
      typeof(string),
      typeof(MetadataStyle),
      new PropertyMetadata(String.Empty, new PropertyChangedCallback(OnOnlyProfilesChanged)));

    public static void SetOnlyProfiles(UIElement element, string value)
    {
      element.SetValue(OnlyProfilesProperty, value);
    }
    public static string GetOnlyProfiles(UIElement element)
    {
      return (string)element.GetValue(OnlyProfilesProperty);
    }

    private static void OnOnlyProfilesChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
    {
      FrameworkElement fe = element as FrameworkElement;
      if (null != fe)
      {
        // get current profile
        string currentProfile = Utils.GetCurrentProfile(element);
        if (null == currentProfile)
          return;

        string _onlyList = args.NewValue as string;

        // only list
        //
        if (null != _onlyList && 0 < _onlyList.Length)
        {
          string[] parts = _onlyList.Split(',');
          bool avail = false;
          foreach (string part in parts)
          {
            if (currentProfile.Equals(part, StringComparison.InvariantCultureIgnoreCase))
            {
              avail = true;
              break;
            }
          }

          // if there were profiles listed in the 'only' list
          // and the current profile was NOT on that list
          // then don't show the control
          if (!avail)
          {
            fe.Visibility = Visibility.Collapsed;
            return;
          }
        }

        // show it
        fe.Visibility = Visibility.Visible;

      }
    }

    public string Only
    {
      get { return _onlyList; }
      set { this._onlyList = value; }
    }

    public string Except
    {
      get { return _exceptList; }
      set { this._exceptList = value; }
    }

    public MetadataStyle()
    {
      this.Loaded += DetermineStyle;
    }

    public void DetermineStyle(object sender, RoutedEventArgs e)
    {

      // get current profile
      string currentProfile = Utils.GetCurrentProfile(sender as DependencyObject);
      if (null == currentProfile)
        return;

      // only list
      //
      if (null != _onlyList && 0 < _onlyList.Length)
      {
        string[] parts = _onlyList.Split(',');
        bool avail = false;
        foreach (string part in parts)
        {
          if (currentProfile.Equals(part, StringComparison.InvariantCultureIgnoreCase))
          {
            avail = true;
            break;
          }
        }

        // if there were profiles listed in the 'only' list
        // and the current profile was NOT on that list
        // then don't show the control
        if (!avail)
        {
          this.Visibility = Visibility.Collapsed;
          return;
        }
      }

      // so far, this will be visible...

      // except list
      //
      if (null != _exceptList && 0 < _exceptList.Length)
      {
        string[] parts = _exceptList.Split(',');
        foreach (string part in parts)
        {
          if (currentProfile.Equals(part, StringComparison.InvariantCultureIgnoreCase))
          {
            this.Visibility = Visibility.Collapsed;
            return;
          }
        }
      }

      // show it
      this.Visibility = Visibility.Visible;
    }
  }
}
