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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml;

namespace ArcGIS.Desktop.Internal.Metadata
{
  internal class Thumbnails
  {
   
    // example of base64 data URI for images
    //src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUA
    //AAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO
    //9TXL0Y4OHwAAAABJRU5ErkJggg=="

    public static string GetThumbnailDataURI(XmlDocument doc)
    {
      // fetch base64 image
      //  <Binary><Thumbnail><Data EsriPropertyType="Picture">... 

      var imgType= "png";
      var node = doc.SelectSingleNode("/metadata/Binary/Thumbnail/Data[@EsriPropertyType=\"PictureX\"]");
      if (null == node)
      {
        imgType = "bmp";
        node = doc.SelectSingleNode("/metadata/Binary/Thumbnail/Data[@EsriPropertyType=\"Picture\"]");
      }

      if (null != node)
      {
        try
        {
          // get base64 data
          string base64 = node.InnerText;
          return string.Format("data:image/{0};base64,{1}", imgType, base64);
        }
        catch (Exception)
        {
          /* NOOP */
        }
      }

      return null;
    }
  }
}
