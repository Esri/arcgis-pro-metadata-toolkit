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

namespace ArcGIS.Desktop.Metadata.Editor.Sections
{
  internal class Metadata : ISidebarLabel
  {
    public string SidebarLabel
    {
      get { return Internal.Metadata.Properties.Resources.CFG_LBL_METADATA; }
    }
  }
}
