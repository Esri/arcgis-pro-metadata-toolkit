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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  /// <summary>
  /// Interaction logic for CharacterStringSync.xaml
  /// </summary>
  public partial class CharacterStringSync : EditorPage
  {

    private string _syncedElement = null;
    private string _originalContent = null;
    private bool _originalSync = false;

    public CharacterStringSync()
    {
      InitializeComponent();
    }

    public string SyncedElement
    {
      get { return _syncedElement; }
      set { _syncedElement = value; }
    }

    private XmlAttribute GetSyncAttribute(XmlNode node)
    {
      XmlAttribute syncNode = node.SelectSingleNode("@Sync|@sync|@SYNC") as XmlAttribute;
      return syncNode;
    }

    public override string DefaultValue
    {
      get
      {
        IEnumerable<XmlNode> data = GetXmlDataContext();
        foreach (XmlNode root in data)
        {
          XmlNode node = root.SelectSingleNode(_syncedElement);
          if (null != node && 0 < node.InnerText.Length)
          {
            // save this for the setter
            if (null == _originalContent)
            {
              _originalContent = node.InnerText;
              XmlAttribute syncNode = GetSyncAttribute(node);
              _originalSync = (null != syncNode && "true".Equals(syncNode.Value, StringComparison.InvariantCultureIgnoreCase));

            }
            // return just one
            return node.InnerText;
          }
        }
        return String.Empty;
      }
      set
      {
        IEnumerable<XmlNode> data = GetXmlDataContext();
        foreach (XmlNode root in data)
        {
          // title
          XmlNode node = root.SelectSingleNode(_syncedElement);
          node.InnerText = value;

          bool modified = (null != _originalContent) && (_originalContent != node.InnerText);

          // get sync
          XmlAttribute syncNode = GetSyncAttribute(node);
          if (null != syncNode && modified && "true".Equals(syncNode.Value, StringComparison.InvariantCultureIgnoreCase))
          {
            syncNode.Value = "FALSE";
          }
          else if (null != syncNode  && _originalSync && !modified)
          {
            syncNode.Value = "TRUE";
          }         

          break; // just one
        }
      }
    }
  }
}
