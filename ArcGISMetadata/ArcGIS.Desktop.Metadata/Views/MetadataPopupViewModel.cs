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

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ESRI.ArcGIS.ItemIndex;
using ItemInfoServiceContract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Xsl;

namespace ArcGIS.Desktop.Internal.Core.Metadata
{
  internal class MetadataPopupViewModel : ViewModelBase
  {
    private static IItemInfoService _itemInfoService;

    public MetadataPopupViewModel()
    {
      // NOOP
    }

    public string Path { get; set; }
    public FlowDirection FlowDirection { get; set; }
    public bool IsPopup { get; set; }
    public bool Synchronize { get; set; }
    public ItemInfoValue ItemInfo { get; set; }

    private string GetErrorHtml(string error)
    {
      var xml = @"<nometadata></nometadata>";

      // use a standard error message
      error = ArcGIS.Desktop.Internal.Core.Properties.Resources.ProjectItemNoMetadata;

      // transform GOOD XML and display
      try
      {
        // get the view name
        var name = this.IsPopup ? "project_popup" : "project_view";

        // transform
        var outputDoc = TransformMetadata.Transform(name, xml, this.FlowDirection, string.Empty, error, null);
        var html = outputDoc.InnerXml;

        // return result!
        return html;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
        return ex.ToString();
      }
    }

    public string GetHtml()
    {

      string xml = null;
      string thumbnailURI = null;

      try
      {

        // get XML
        if (null == _itemInfoService)
          _itemInfoService = ArcGIS.Desktop.Framework.Utilities.ServiceManager.Find<IItemInfoService>();
        if (null == _itemInfoService)
          return GetErrorHtml("unable to get iteminfo service");

        // sync if a path is set
        if (this.Synchronize && !string.IsNullOrWhiteSpace(this.Path))
        {
          try
          {
            xml = _itemInfoService.Synchronize(ProjectModule.CurrentProject.ID, this.Path, 1 /*esriMSAAlways*/, 0);
          }
          catch (Exception ex)
          {
            // * GULP *
            Debug.WriteLine(ex);
          }
        }

        // get metadata OR use item info to generate metadata
        if (string.IsNullOrEmpty(xml))
        {
          if (string.IsNullOrWhiteSpace(this.Path) || (null != this.ItemInfo.typeID && this.ItemInfo.typeID.StartsWith("portal_")))
          {

            xml = ItemInfoHelp.ItemInfoToMetadataXML(this.ItemInfo);
            thumbnailURI = this.ItemInfo.thumbnailPath;

          }
          else
          {
            xml = _itemInfoService.GetMetadata(ProjectModule.CurrentProject.ID, this.Path);
            if (!string.IsNullOrEmpty(xml))
              thumbnailURI = _itemInfoService.GetThumbnailURI(xml);
          }
        }

        // transform GOOD XML and display

        if (string.IsNullOrWhiteSpace(xml))
          throw new Exception("XML was null!");

        // get the view name
        var name = this.IsPopup ? "project_popup" : "project_view";

        // transform
        var outputDoc = TransformMetadata.Transform(name, xml, this.FlowDirection, this.Path, null, thumbnailURI);
        var html = outputDoc.InnerXml;

        // return result!
        return html;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
        return GetErrorHtml(ex.ToString());
      }
    }
  }


  class TransformMetadata
  {

    private static Dictionary<string, XslCompiledTransform> _transforms;

    static TransformMetadata()
    {

      // cache transforms
      _transforms = new Dictionary<string, XslCompiledTransform>();

      LoadTransform("project_view", @"res://ArcGIS.Desktop.Core?Metadata.Xslt.ArcGISPro.xsl");
      //LoadTransform("project_popup", @"res://ArcGIS.Desktop.Core?Metadata.Xslt.ProPopup.xsl");
    }

    private static void LoadTransform(string name, string source) {
        // create a new compiled transform
        var transform = new XslCompiledTransform();
        XsltSettings xslSettings = new XsltSettings(false, true);
        var resolver = new XmlResourceResolver();
        
        try
        {
          transform.Load(source, xslSettings, resolver);
          _transforms.Add(name, transform);
        }
        catch (Exception ex)
        {
          Debug.WriteLine(ex);
        }
    }

    public static XmlDocument Transform(string name, string xml, FlowDirection flowDirection, string catalogPath, string error, string thumbnailURI)
    {   
      // get named transform
      var transform = _transforms.ContainsKey(name) ? _transforms[name] : null;
      if (null == transform)
        return null;

      // reader
      var sourceDoc = new XmlDocument();
      sourceDoc.LoadXml(xml);

      // write to DOM
      var targetDoc = new XmlDocument();

      // add custom functions
      XsltArgumentList xslArgs = new XsltArgumentList();
      xslArgs.AddExtensionObject("http://www.esri.com/metadata/", new XsltExtFunctions());
      xslArgs.AddExtensionObject("http://www.esri.com/metadata/res/", new XsltExtFunctions());

      // add flow direction
      xslArgs.AddParam("flowdirection", "", (FlowDirection.LeftToRight == flowDirection) ? "LTR" : "RTL");

      // add catalog path
      if (null != catalogPath)
        xslArgs.AddParam("catalogPath", "", catalogPath);

      // attempt to add thumbnail from metadata if nothing was passed
      if (string.IsNullOrWhiteSpace(thumbnailURI))
        thumbnailURI = Thumbnails.GetThumbnailDataURI(sourceDoc);

      // add thumbnail URI as xslt param
      if (null != thumbnailURI)
        xslArgs.AddParam("thumbnailURI", "", thumbnailURI);

      // add any errors
      if (!string.IsNullOrWhiteSpace(error))
        xslArgs.AddParam("metadataError", "", error);

      // execute the transformation
      using (XmlWriter xmlWriter = targetDoc.CreateNavigator().AppendChild())
      {
        transform.Transform(sourceDoc.CreateNavigator(), xslArgs, xmlWriter);
      }

      // substitute strings
      XsltExtFunctions.SubstituteXsltResourceStrings(targetDoc);

      // return target doc
      return targetDoc;
    }

  }
}
