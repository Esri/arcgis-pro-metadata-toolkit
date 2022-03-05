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
using System.IO;
using System.Web;
using System.Xml;
using System.Windows.Markup;
using System.Collections;

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Metadata;
using ArcGIS.Desktop.Metadata.Editor.Pages;
using ArcGIS.Desktop.Metadata.Editor.Convert;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for ImageAttachement.xaml
  /// </summary>
  internal partial class MTK_ImageAttachement : EditorPage
  {
    private static Image _thumbnailImage = null;
    private static object _dataContext = null;
    private bool _isDefault = false;

    public string XPath { get; set; }
    public string Rel { get; set; }
    public new string Parent { get; set; }

    public MTK_ImageAttachement()
    {
      InitializeComponent();
    }

    public void DeleteThumbnail(object sender, EventArgs e)
    {
      UseDefaultImage();

      var mdModule = FrameworkApplication.FindModule("esri_metadata_module") as IMetadataEditorHost;
      if (mdModule != null)
      {
        CommitChanges();
        mdModule.OnUpdateThumbnail(this);
      }
    }

    public void UpdateThumbnail(object sender, EventArgs e)
    {
      Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
      dlg.FileName = ""; // Default file name
      dlg.DefaultExt = ".png"; // Default file extension
      dlg.Filter = "Image Files(*.PNG;*.JPG;*.BMP;*.GIF)|*.PNG;*.JPG;*.BMP;*.GIF|All files (*.*)|*.*";

      Nullable<bool> result = dlg.ShowDialog();
      if (true == result)
      {
        if (null != dlg.FileName && 0 < dlg.FileName.Length && File.Exists(dlg.FileName))
        {
          // loadimage
          try
          {
            // fetch via URL
            Uri imageUri = new Uri(dlg.FileName);
            BitmapDecoder bmd = BitmapDecoder.Create(imageUri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            // set the source
            _thumbnailImage.Source = bmd.Frames[0];
            _isDefault = false;

            var mdModule = FrameworkApplication.FindModule("esri_metadata_module") as IMetadataEditorHost;
            if (mdModule != null)
            {
              CommitChanges();
              mdModule.OnUpdateThumbnail(this);
            }
          }
          catch (Exception) { /* noop */ }
        }
      }
    }

    private void CreateThumbnailNode()
    {
      if (_dataContext == null)
        _dataContext = Utils.Utils.GetDataContext(this);

      IEnumerable<XmlNode> nodes = Utils.Utils.GetXmlDataContext(_dataContext);
      if (null != nodes)
      {
        var node = nodes.First().OwnerDocument;

        // get the skeleton XML, and replace the 'rel' attribute
        XmlDataProvider provider = Resources["ImageXml"] as XmlDataProvider;
        string xmlString = provider.Document.InnerXml;
        xmlString = xmlString.Replace("{rel}", Rel);
        XmlDocument newDoc = new XmlDocument();
        newDoc.LoadXml(xmlString);

        // copy new XML into document
        XmlDocument owner = (null == node?.OwnerDocument) ? node : node.OwnerDocument;
        if (owner != null)
          Utils.Utils.CopyElements(owner, newDoc.FirstChild, true, false);
      }
    }

    private XmlNode GetBinaryThumbnailNode(object sender, bool is_empty_ok)
    {
      if (_dataContext == null)
        _dataContext = Utils.Utils.GetDataContext(this);

      var nodes = Utils.Utils.GetXmlDataContext(_dataContext);

      if (null != nodes)
      {
        var node = nodes.First().OwnerDocument;
        // fetch base64 image
        //  <Binary><Thumbnail><Data EsriPropertyType="Picture">... 
        XmlNode dataNode = node?.SelectSingleNode(XPath);
        if (null != dataNode && (is_empty_ok || 0 < dataNode.InnerText.Trim().Length))
          return dataNode;        
      }

      return null;
    }

    private void CleanThumbnailNodes(bool cleanAll)
    {
      if (_dataContext == null)
        _dataContext = Utils.Utils.GetDataContext(this);

      var nodes = Utils.Utils.GetXmlDataContext(_dataContext);

      if (null != nodes)
      {
        var node = nodes.First().OwnerDocument;

        // fetch base64 image
        //  <Binary><Thumbnail><Data EsriPropertyType="Picture">... 
        XmlNode dataNode = node?.SelectSingleNode(XPath);
        if (null != dataNode)
          dataNode.ParentNode.RemoveChild(dataNode);

        if (cleanAll)
        {
          dataNode = node?.SelectSingleNode(XPath);
          if (null != dataNode)
            dataNode.ParentNode.RemoveChild(dataNode);
        }

      }
    }

    private void UpdateThumbnail()
    {
      // fetch base64 image
      //  <Binary><Thumbnail><Data EsriPropertyType="Picture">... 
      XmlNode base64imageNode = GetBinaryThumbnailNode(this, false);
      if (null != base64imageNode)
      {
        try
        {
          // get base64 data and convert
          string base64 = base64imageNode.InnerText;
          byte[] base64bytes = System.Convert.FromBase64String(base64);

          MemoryStream ms = new MemoryStream(base64bytes);
          BitmapDecoder bmd = BitmapDecoder.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.None);

          if (null != _thumbnailImage)
          {
            _thumbnailImage.Source = bmd.Frames[0];
            _isDefault = false;
          }
        }
        catch (Exception)
        {
          /* noop */
        }
      }
    }

    private void UseDefaultImage()
    {
      var obj = this.Resources["EmptyImage"];
      if (null != obj)
      {
        BitmapImage emptyImage = obj as BitmapImage;
        _thumbnailImage.Source = emptyImage;
        ThumbnailImage.Width = 32;
      }
      else
      {
        _thumbnailImage.Source = null;
      }

      // now using default
      _isDefault = true;
    }

    override public void CommitChanges()
    {
      if (null == _thumbnailImage?.Source || _isDefault)
      {
        CleanThumbnailNodes(true);
        return;
      }

      JpegBitmapEncoder jbe = new JpegBitmapEncoder();
      jbe.Frames.Add(BitmapFrame.Create(_thumbnailImage.Source as BitmapSource));

      MemoryStream ms = new MemoryStream();
      jbe.Save(ms);

      string base64 = System.Convert.ToBase64String(ms.ToArray(), Base64FormattingOptions.InsertLineBreaks);

      // clean nodes
      CleanThumbnailNodes(false);

      // get the insert node
      XmlNode base64imageNode = GetBinaryThumbnailNode(this, true);
      if (null == base64imageNode)
        CreateThumbnailNode();

      // try again:
      base64imageNode = GetBinaryThumbnailNode(this, true);

      if (null != base64imageNode)
      {
        base64imageNode.InnerText = base64;
      }
    }

    public void LoadedThumbnailImage(object sender, RoutedEventArgs e)
    {
      // add me, so I can be called later
      var mdModule = FrameworkApplication.FindModule("esri_metadata_module") as IMetadataEditorHost;
      if (mdModule != null)
        mdModule.AddCommitPage(this);

      _thumbnailImage = sender as Image;
      UpdateThumbnail();
    }
  }
}

