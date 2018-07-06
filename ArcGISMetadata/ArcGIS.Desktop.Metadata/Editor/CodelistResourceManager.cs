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
using System.Resources;
using System.Collections;
using System.Globalization;
using System.Reflection;

namespace ArcGIS.Desktop.Metadata.Editor
{
  internal class CodelistResourceManager : ResourceManager
  {
    //private string dsn;
    private const string resExtension = ".xml";


    public CodelistResourceManager(string baseName, Assembly assembly, Type usingResourceSet)
      : base(baseName, assembly, usingResourceSet)
    {
      // NOOP
    }

    protected override string GetResourceFileName(CultureInfo culture)
    {
      StringBuilder sb = new StringBuilder(255);
      sb.Append(BaseNameField);
      // If this is the neutral culture, don't append culture name.
      if (!culture.Equals(CultureInfo.InvariantCulture))
      {
        //CultureInfo.VerifyCultureName(culture, true);
        sb.Append('.');
        sb.Append(culture.Name);
      }
      sb.Append(resExtension);
      return sb.ToString();
    }
  }
}
