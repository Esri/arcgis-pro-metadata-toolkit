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
using System.Windows.Controls;
using System.Xml;

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  /// <summary>
  /// Interaction logic for MD_Identifier.xaml
  /// </summary>
  internal partial class MD_Identifier : EditorPage
  {
    public MD_Identifier()
    {
      InitializeComponent();
    }

    public override string DefaultValue
    {
      get
      {
        IEnumerable<XmlNode> data = GetXmlDataContext();
        if (null == data)
          return String.Empty;

        foreach (XmlNode root in data)
        {
          // Person
          XmlNode node = root.SelectSingleNode("identCode");
          if (null != node && 0 < node.InnerText.Length)
          {
            return node.InnerText;
          }

          break;
        }

        return String.Empty; // Properties.Resources.LBL_IDENTIFIER_EMPTY;
      }
      set
      {
        // NOOP
      }
    }

  }
}
