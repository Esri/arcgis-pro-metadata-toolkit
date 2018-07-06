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
  public class URLValidator : ValidationRule
  {

    private bool _required = false;

    public bool IsRequired
    {
      get { return _required; }
      set { _required = value; }
    }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      if (_required && (null == value || 0 == value.ToString().Length))
        return new ValidationResult(false, null);
      else
        return new ValidationResult(true, null);

      //    string regex = "^(https?://)"
      //+ "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
      //+ @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
      //+ "|" // allows either IP or domain
      //+ @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
      //+ @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // second level domain
      //+ "[a-z]{2,6})" // first level domain- .com or .museum
      //+ "(:[0-9]{1,4})?" // port number- :80
      //+ "((/?)|" // a slash isn't required if there is no file name
      //+ "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";

      //if ((null == value || 0 == value.ToString().Length) && !_required)
      //  return new ValidationResult(true, null);

      //if (value == null || 0 == value.ToString().Length /*!Regex.IsMatch(value.ToString().ToLower(), regex)*/)
      //  return new ValidationResult(false, "The value is not a valid e-mail address");
      //else
      //  return new ValidationResult(true, null);
    }
  }
}
