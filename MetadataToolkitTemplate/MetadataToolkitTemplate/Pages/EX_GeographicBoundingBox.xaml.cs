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
using System.Text;
using System.Xml;

using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace $safeprojectname$
{
  /// <summary>
  /// Interaction logic for MTK_EX_GeographicBoundingBox.xaml
  /// </summary>
  internal partial class MTK_EX_GeographicBoundingBox : EditorPage
  {
    public MTK_EX_GeographicBoundingBox()
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

        StringBuilder sb = new StringBuilder();
        foreach (XmlNode root in data)
        {
          // west
          XmlNode node = root.SelectSingleNode("GeoBndBox/westBL");
          if (null != node && 0 < node.InnerText.Length)
          {
            sb.Append(node.InnerText);
            sb.Append(", ");
          }

          // east
          node = root.SelectSingleNode("GeoBndBox/eastBL");
          if (null != node && 0 < node.InnerText.Length)
          {
            sb.Append(node.InnerText);
            sb.Append(", ");
          }

          // south
          node = root.SelectSingleNode("GeoBndBox/southBL");
          if (null != node && 0 < node.InnerText.Length)
          {
            sb.Append(node.InnerText);
            sb.Append(", ");
          }

          // north
          node = root.SelectSingleNode("GeoBndBox/northBL");
          if (null != node && 0 < node.InnerText.Length)
          {
            sb.Append(node.InnerText);
            sb.Append(", ");
          }
          break;
        }

        if (0 < sb.Length)
          return $safeprojectname$.Properties.Resources.LBL_EXTENTS_BBOX + sb.ToString().Substring(0, 30) + "...";
        else
          return String.Empty; // Properties.Resources.LBL_EXTENTS_BBOX_EMPTY;
      }
      set
      {
        // NOOP
      }
    }
  }
}
