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
using System.IO;
using System.Xml;

namespace ArcGIS.Desktop.Metadata.Editor
{
  internal class CodelistResourceReader : IResourceReader
  {

    Hashtable dict = new Hashtable();

    public CodelistResourceReader(string fileName)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(fileName);

      // substitute resouce strings
      Utils.SubstituteXsltResourceStrings(xmlDocument);

      XmlNodeList nodes = xmlDocument.SelectNodes("//codelist");
      foreach (XmlNode node in nodes)
      {
        // get ID 
        XmlAttribute idAtt = node.Attributes["id"];
        if (null != idAtt)
        {
          string id = idAtt.Value;
          if (null != id && 0 < id.Length)
          {
            dict.Add(id, node);
          }
        }
      }
    }

    public CodelistResourceReader(Stream stream)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(stream);

      // substitute resouce strings
      Utils.SubstituteXsltResourceStrings(xmlDocument);

      XmlNodeList nodes = xmlDocument.SelectNodes("//codelist");
      foreach (XmlNode node in nodes)
      {
        // get ID 
        XmlAttribute idAtt = node.Attributes["id"];
        if (null != idAtt)
        {
          string id = idAtt.Value;
          if (null != id && 0 < id.Length)
          {
            dict.Add(id, node);
          }
        }
      }
    }

    public System.Collections.IDictionaryEnumerator GetEnumerator()
    {
      return dict.GetEnumerator();
    }

    public void Close()
    {
      // dispose?
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    void IDisposable.Dispose()
    {
      // dispose?
    }

  }
}
