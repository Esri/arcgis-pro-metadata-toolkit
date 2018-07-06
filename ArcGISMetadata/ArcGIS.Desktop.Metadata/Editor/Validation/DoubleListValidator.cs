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
using System.Globalization;

namespace ArcGIS.Desktop.Metadata.Editor.Validation
{
  public class DoubleListValidator : ValidationRule
  {
    private bool _required = false;
    private static CultureInfo culture_en = CultureInfo.CreateSpecificCulture("en");

    public bool IsRequired
    {
      get { return _required; }
      set { _required = value; }
    }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      if ((null == value || 0 == value.ToString().Length) && !_required)
        return new ValidationResult(true, null);

      string doubleStr = value as string;
      if (string.IsNullOrEmpty(doubleStr))
        return new ValidationResult(false, "The value is not a valid");

      string[] parts = doubleStr.Split(' ');
      double result;
      foreach (string dval in parts)
      {
        if (!Double.TryParse(dval as string, NumberStyles.Float, culture_en, out result))
          return new ValidationResult(false, "The value is not a valid");
      }

      // everything validated as a double
      return new ValidationResult(true, null);
    }
  }
}
