/*
COPYRIGHT 2013-2016 ESRI

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
using System.Threading.Tasks;

namespace $safeprojectname$.Utils
{
  internal class MetadataException : Exception
  {
    public MetadataException(string message) : base(message)
    {
    }

    public MetadataException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
