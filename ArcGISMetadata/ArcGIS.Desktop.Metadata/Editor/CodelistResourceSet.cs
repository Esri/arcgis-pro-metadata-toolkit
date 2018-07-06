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
using System.Globalization;
using System.IO;
using System.Collections;

namespace ArcGIS.Desktop.Metadata.Editor
{
  internal class CodelistResourceSet : ResourceSet
  {

    public CodelistResourceSet(string fileName)
    {
      Reader = new CodelistResourceReader(fileName);
      Table = new Hashtable();
      base.ReadResources();
    }

    public CodelistResourceSet(Stream steam)
    {
      Reader = new CodelistResourceReader(steam);
      Table = new Hashtable();
      base.ReadResources();
    }

    public override Type GetDefaultReader()
    {
      return typeof(CodelistResourceReader);
    }   
  }
}
