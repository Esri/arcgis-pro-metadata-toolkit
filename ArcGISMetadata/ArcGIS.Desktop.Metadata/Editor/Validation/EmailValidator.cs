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
using System.Text.RegularExpressions;
using System.Globalization;

namespace ArcGIS.Desktop.Metadata.Editor.Validation
{
  public class EmailValidator : ValidationRule
  {

    private bool _required = false;

    public bool IsRequired
    {
      get { return _required; }
      set { _required = value; }
    }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      string regex = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";

      if ((null == value || 0 == value.ToString().Length) && !_required)
        return new ValidationResult(true, null);

      if (value == null || !Regex.IsMatch(value.ToString(), regex))
        return new ValidationResult(false, "The value is not a valid e-mail address");
      else
        return new ValidationResult(true, null);
    }
  }
}
