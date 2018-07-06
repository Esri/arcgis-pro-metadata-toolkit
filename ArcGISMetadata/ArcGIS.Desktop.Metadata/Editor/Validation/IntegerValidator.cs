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

namespace ArcGIS.Desktop.Metadata.Editor.Validation
{
  public class IntegerValidator : ValidationRule
  {
    private bool _required = false;

    public bool IsRequired
    {
      get { return _required; }
      set { _required = value; }
    }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      if ((null == value || 0 == value.ToString().Length) && !_required)
        return new ValidationResult(true, null);

      int result;
      if (value == null || !Int32.TryParse(value as string, out result))
        return new ValidationResult(false, "The value is not a valid");
      else
        return new ValidationResult(true, null);
    }
  }
}
