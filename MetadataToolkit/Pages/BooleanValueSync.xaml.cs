/*
Copyright 2019 Esri
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.​
*/
﻿using System;
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

using ArcGIS.Desktop.Metadata.Editors.ClassicEditor.Pages;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_BooleanValueSync.xaml
  /// </summary>
  internal partial class MTK_BooleanValueSync : EditorPage
  {
    private string _syncedElement = null;
    private string _originalContent = null;
    private bool _originalSync = false;
    private bool _usedString = true;
    private string _content = String.Empty;

    public MTK_BooleanValueSync()
    {
      InitializeComponent();
    }

    public string Label {
      get { return _content; }
      set { _content = value; }
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

    public void ControlLoaded(object sender, RoutedEventArgs e)
    {
      // XML is ready, trigger the GET method to re-read the XML again...
      var v = DefaultValue;      
    }

    public new bool DefaultValue
    {
      get
      {
        IEnumerable<XmlNode> data = GetXmlDataContext();
        if (null == data)
          return false;

        foreach (XmlNode root in data)
        {
          XmlNode node = root.SelectSingleNode(_syncedElement);

          //
          // get 'usedString' attribute if present
          //
          if (null != node)
          {
            XmlAttribute xmlAtt = node.Attributes["editorBoolIsString"];
            if (null != xmlAtt)
            {
              if ("true".Equals(xmlAtt.Value, StringComparison.InvariantCultureIgnoreCase))
                _usedString = true;
              else
                _usedString = false;
            }
          }

          //
          // if there is content...
          //
          if (null != node && 0 < node.InnerText.Length)
          {
            // save this for the setter
            if (null == _originalContent)
            {
              _originalContent = node.InnerText;
              XmlAttribute syncNode = GetSyncAttribute(node);
              _originalSync = (null != syncNode && "true".Equals(syncNode.Value, StringComparison.InvariantCultureIgnoreCase));
            }

            if ("true".Equals(node.InnerText, StringComparison.InvariantCultureIgnoreCase) ||
              "false".Equals(node.InnerText, StringComparison.InvariantCultureIgnoreCase))
            {
              this._usedString = true;
              return "true".Equals(node.InnerText, StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
              this._usedString = false;
              return "1".Equals(node.InnerText);
            }
          }
        }
        return false;
      }

      set
      {
        IEnumerable<XmlNode> data = GetXmlDataContext();
        if (null == data)
          return;

        foreach (XmlNode root in data)
        {
          XmlNode node = root.SelectSingleNode(_syncedElement);

          // set the value
          if (this._usedString)
            node.InnerText = value ? "True" : "False";
          else
            node.InnerText = value ? "1" : "0";

          bool modified = (null != _originalContent) && (_originalContent != node.InnerText);

          // get sync
          XmlAttribute syncNode = GetSyncAttribute(node);
          if (null != syncNode && modified && "true".Equals(syncNode.Value, StringComparison.InvariantCultureIgnoreCase))
          {
            syncNode.Value = "FALSE";
          }
          else if (null != syncNode && _originalSync && !modified)
          {
            syncNode.Value = "TRUE";
          }

          break; // just one
        }
      }
    }
  }
}
