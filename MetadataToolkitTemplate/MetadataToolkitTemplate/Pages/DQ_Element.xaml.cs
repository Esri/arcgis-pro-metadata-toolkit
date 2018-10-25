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

using System.Collections.Generic;
using System.Windows.Controls;
using System.Xml;

using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace $safeprojectname$
{
  /// <summary>
  /// Interaction logic for MTK_DQ_Element.xaml
  /// </summary>
  internal partial class MTK_DQ_Element : EditorPage
  {
    public MTK_DQ_Element()
    {
      InitializeComponent();
    }

    public override string DefaultValue
    {
      get
      {
        IEnumerable<XmlNode> data = GetXmlDataContext();
        if (null == data)
          return null;

        foreach (XmlNode root in data)
        {
          // MEASURE NAME
          XmlNode node = root.SelectSingleNode("*/measName");
          if (null != node && 0 < node.InnerText.Length)
          {
            return node.InnerText;
          }

          break;
        }

        return null;
      }
      set
      {
        // DO NOTHING
      }

    }
  }
}
