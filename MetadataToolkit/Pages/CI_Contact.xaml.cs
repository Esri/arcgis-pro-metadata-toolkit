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
using System.Xml;
using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_CI_Contact.xaml
  /// </summary>
  internal partial class MTK_CI_Contact : EditorPage
  {
    public MTK_CI_Contact()
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
          // URL
          //XmlNode node = root.SelectSingleNode("cntOnlineRes/linkage");
          //if (null != node && 0 < node.InnerText.Length)
          //{
          //    return node.InnerText;
          //}

          // EMAIL
          XmlNode node = root.SelectSingleNode("cntAddress/eMailAdd");
          if (null != node && 0 < node.InnerText.Length)
          {
            return node.InnerText;
          }

          // ADDRESS
          string address = "";
          node = root.SelectSingleNode("cntAddress/delPoint");
          if (null != node && 0 < node.InnerText.Length)
          {
            address += node.InnerText;
            address += " ";
          }
          node = root.SelectSingleNode("cntAddress/city");
          if (null != node && 0 < node.InnerText.Length)
          {
            address += node.InnerText;
            address += ", ";
          }
          node = root.SelectSingleNode("cntAddress/adminArea");
          if (null != node && 0 < node.InnerText.Length)
          {
            address += node.InnerText;
            //address += " ";
          }

          if (0 < address.Length)
            return address;

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
