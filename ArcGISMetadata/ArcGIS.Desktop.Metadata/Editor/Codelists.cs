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
using System.Xml;
using System.Resources;
using System.Reflection;
using System.Windows;

namespace ArcGIS.Desktop.Metadata.Editor
{
  public class Codelists
  {
    private string _codelistname;
    private ResourceManager _rm;

    public Codelists() { }

    public string CodelistName
    {
      get { return _codelistname; }
      set { _codelistname = value; }
    }

    public object List
    {
      get
      {
        if (null == _codelistname || 0 == _codelistname.Length)
          return null;

        // get the current metadata style/profile identifier    
        string profile = null;
        var mec = MetadataEditorViewModel.Instance;
        if (null != mec)
        {
          profile = mec.ArcGISProfile;
        }

        // create a manager when needed
        if (null == _rm)
        {
          if (null != profile && 0 < profile.Length)
          {
            try
            {
              _rm = new CodelistResourceManager("ArcGIS.Desktop.Metadata.Properties.Codelists." + profile,
                          Assembly.GetExecutingAssembly(), typeof(CodelistResourceSet));
              object obj = _rm.GetObject("");
            }
            catch (Exception)
            {
              _rm = null;
            }
          }

          if (null == _rm)
          {
            _rm = new CodelistResourceManager("ArcGIS.Desktop.Metadata.Properties.Codelists",
                Assembly.GetExecutingAssembly(), typeof(CodelistResourceSet));
          }
        }

        object res = _rm.GetObject(_codelistname);
        if (null != res && res is XmlNode)
        {
          XmlNodeList nodes = ((XmlNode)res).SelectNodes("code");
          return nodes;
        }

        return null;
      }      
    }
  }
}
