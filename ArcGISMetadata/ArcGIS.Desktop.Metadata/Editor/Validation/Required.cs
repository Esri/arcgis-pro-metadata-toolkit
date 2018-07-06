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
using System.Windows.Controls;
using System.Globalization;
using System.Windows;
using System.ComponentModel;
using ArcGIS.Desktop.Metadata.Editor.Pages;
using System.Windows.Data;

namespace ArcGIS.Desktop.Metadata.Editor.Validation
{
  public class Required : ValidationRule
  {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    { 
      if ((null == value || 0 == value.ToString().Length))
        return new ValidationResult(false, null);
      else
        return new ValidationResult(true, null);
    }
  }
}
