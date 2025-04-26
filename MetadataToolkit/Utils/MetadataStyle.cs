/*
Copyright 2019 Esri
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.​
*/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;


using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Metadata.Editors.ClassicEditor;

namespace MetadataToolkit.Utils
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
        string currentProfile = null;

        var mdModule = FrameworkApplication.FindModule("esri_metadata_module") as IMetadataEditorHost;
        if (mdModule != null)
          currentProfile = mdModule.GetCurrentProfile(element);

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
      string currentProfile = null;

      var mdModule = FrameworkApplication.FindModule("esri_metadata_module") as IMetadataEditorHost;
      if (mdModule != null)
        currentProfile = mdModule.GetCurrentProfile(sender as DependencyObject);

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
