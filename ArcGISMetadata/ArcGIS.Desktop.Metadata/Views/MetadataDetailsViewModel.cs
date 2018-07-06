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

using Microsoft.Win32;
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

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Internal.Metadata;
using ArcGIS.Desktop.Internal.DesktopService;
using ESRI.ArcGIS.ItemIndex;
using ArcGIS.Desktop.Metadata.Editor;
using ArcGIS.Desktop.Core.Events;
using ArcGIS.Desktop.Internal.Core.Events;
using ArcGIS.Desktop.Internal.Core;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Internal.Models.Utilities;
using ArcGIS.Desktop.Metadata;
using ArcGIS.Desktop.Internal.Metadata.Events;

namespace ArcGIS.Desktop.Internal.Metadata
{
  #pragma warning disable 1591  //This line will prevent the API Build Warning report from displaying these "internal" items as missing doc members.

  public class XSLTProcessingException : Exception
  {
    public XSLTProcessingException(string message)
      : base(message)
    {
      // NOOP
    }
  }

  internal class MetadataDetailsViewModel : ViewModelBase
  {
    private string _currentUntransformedXML = string.Empty;
    private string _currentTransformedXML = string.Empty;
    private List<string> _tempFiles = new List<string>();

    public string Path { get; set; }
    public string LastEditedMetadata { get; set; }
    public string LastEditedPath { get; set; }
    public FlowDirection FlowDirection { get; set; }
    public bool Synchronize { get; set; }
    public Item Item { get; set; }
    public uint PaneID { get; set; }
    public string SelectedItemDisplayType { get; set; }
    
    public MetadataDetailsViewModel()
    {
    }

    internal void EditMetadata()
    {
      MetadataEditorViewModel editorViewModel = null;
      MetadataEditPaneViewModel pane = null;
      foreach (Pane p in ArcGIS.Desktop.Framework.FrameworkApplication.Panes)
      {
        MetadataEditPaneViewModel metadataEditPaneVm = p as MetadataEditPaneViewModel;
        if (null != metadataEditPaneVm)
        {
          editorViewModel = metadataEditPaneVm.EditorViewModel;
          if (editorViewModel == null)
            continue;

          if (this.Item.Name == editorViewModel.Item.Name &&
              this.Item.Path == editorViewModel.Item.Path &&
              this.Item.TypeID == editorViewModel.Item.TypeID)
          {
            pane = metadataEditPaneVm;
            break;
          }
        }
      }

      if (null == pane)
      {
        editorViewModel = EditorViewModel;
        editorViewModel.Item = this.Item;
        editorViewModel.Path = this.Path;

        pane = FrameworkApplication.Panes.Create("esri_metadata_metadataPane") as MetadataEditPaneViewModel;
        if (pane == null)
          return;

        pane.Caption = this.Item.Name;
        pane.EditorViewModel = editorViewModel;

        // Notify the data context has change and so Save button can be updated
        var argsEdit = new MetadataEditEventArgs(MetadataEditEventAction.Select);
        argsEdit.Item = this.Item;
        argsEdit.TypeID = this.Item.TypeID;
        MetadataEditEvent.Publish(argsEdit);
      }

      pane.Activate();
    }

    /// <summary>
    /// from event: OnMetadataEdit
    /// </summary>
    /// <param name="args"></param>
    private void OnMetadataEvent(MetadataEditEventArgs args)
    {
      // test for the correct pane
      if ((args.PaneID != this.PaneID && args.Action != MetadataEditEventAction.Close) && args.Action != MetadataEditEventAction.Reload)
        return; // this is not the pane you're looking for

      switch (args.Action)
      {
        case MetadataEditEventAction.Edit:
          EditMetadata();

          break;

        case MetadataEditEventAction.Close:
          if (args.Path != this.Path)   // Only take action if the being edited item is the one being displayed --- we could have multiple editors
          {
            this.LastEditedMetadata = "";
            this.LastEditedPath = "";
            break;
          }

          this.LastEditedMetadata = args.Metadata;
          this.LastEditedPath = args.Path;

          break;

        case MetadataEditEventAction.Reload:
          if (args.IsFromEditor)
          {
            if (args.Path != this.Path)   // Only take action if the being edited item is the one being displayed --- we could have multiple editors
            {
              this.LastEditedMetadata = "";
              this.LastEditedPath = "";
              break;
            }

            this.LastEditedMetadata = args.Metadata;
            this.LastEditedPath = args.Path;
          }

          break;

        case MetadataEditEventAction.Print:
          break;

        default:
          break;
      }
    }

    private void OnThumbnailUpdatedEvent(ThumbnailUpdatedEventArgs args)
    {
      // Give details view chance to update / not to use cache
      LastEditedMetadata = string.Empty;
      LastEditedPath = string.Empty;        
    }

    public bool IsReturnFromEditing()
    {
      return (!string.IsNullOrEmpty(this.LastEditedMetadata) && this.Path == this.LastEditedPath);
    }

    private bool _bInitialized = false;

    public void PrepareBrowsing() 
    {
      if (!_bInitialized)
      {
        MetadataEditEvent.Subscribe(OnMetadataEvent);
        ThumbnailUpdatedEvent.Subscribe(OnThumbnailUpdatedEvent);
        FrameworkApplication.Panes.ActivePane.State.Deactivate("esri_metadata_metadataEditing");

        _bInitialized = true;
      }
    }

    private bool _isEditorActive = false;
    public bool IsEditorActive
    {
      get { return _isEditorActive; }
      set { SetProperty(ref _isEditorActive, value, () => IsEditorActive); }
    }

    private MetadataEditorViewModel _editorViewModel;
    private bool _isBusy = false;
    public bool IsBusy
    {
      get { return _isBusy; }
      set { SetProperty(ref _isBusy, value, () => IsBusy); }
    }

    private static IAGOItemInfoService _agoItemInfoService = null;
    private static IAGOItemInfoService AGOItemInfoService
    {
      get
      {
        if (_agoItemInfoService == null)
          _agoItemInfoService = ArcGIS.Desktop.Internal.Framework.Utilities.ServiceManager.Find<IAGOItemInfoService>();

        return _agoItemInfoService;
      }
    }

    public MetadataEditorViewModel EditorViewModel
    {
      get
      {
        // create viewmodel
        var currentStyle = ArcGIS.Desktop.Internal.Metadata.Properties.Settings.Default.MetadataStyle;
        _editorViewModel = new MetadataEditorViewModel() { DefaultMetadataStyle = currentStyle };

        IsBusy = true;

        _editorViewModel.SelectedItemDisplayType = this.SelectedItemDisplayType;

        // get HTML, then init the viewmodel
        if (!string.IsNullOrEmpty(_currentUntransformedXML))
        {
          _editorViewModel.Item = this.Item;
          _editorViewModel.Path = this.Path;
          _editorViewModel.Initialize(_currentUntransformedXML, null);
        }

        // return view model, don't wait for initialization (don't block UI)
        return _editorViewModel;
      }
    }

    private bool IsImportingDocLog(string catalogPath)
    {
      if (string.IsNullOrEmpty(catalogPath))
        return false;

      try
      {
        if (string.IsNullOrEmpty(Project.Current.URI)) // URI can be empty string in untitled mode
          return false;

        string importLogFolderPath = System.IO.Path.Combine(System.IO.Directory.GetParent(Project.Current.URI).FullName, "ImportLog");
        if (catalogPath.StartsWith(importLogFolderPath, StringComparison.CurrentCultureIgnoreCase))
          return catalogPath.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase);
      }
      catch { }

      return false;
    }

    /// <summary>
    /// MUST BE CALLED ON A WORKER THREAD!
    /// </summary>
    /// <returns></returns>
    public string GetHtml(ref bool bSuccessful)
    {
      string untransformedXML = string.Empty;
      string transformedXML = string.Empty;
      string thumbnailURI = null;

      IsBusy = true;
      bSuccessful = false;

      try
      {
        if (!string.IsNullOrEmpty(this.Item?.Path) && IsImportingDocLog(this.Item.Path))
        {
          var xmlDoc = Util.TransformByDoc(this.Item.Path);
          if (xmlDoc != null)
            return xmlDoc.InnerXml;
          else
            return "";
        }
        else if (!IsReturnFromEditing())
        {
          // Give us chance to reload. We don't want to cache it forever
          this.LastEditedMetadata = string.Empty;
          this.LastEditedPath = string.Empty;

          // get metadata 
          ItemInfoHelper.GetMetadata((this.Item as IItemInternal).ItemInfoValue, true, out untransformedXML, out transformedXML);

          // transform GOOD XML and display
          if (string.IsNullOrWhiteSpace(untransformedXML))
            return Utils.GetErrorHtml(Internal.Metadata.Properties.Resources.Browse_Item_MD_Not_Supported);
        }
        else
        {
          untransformedXML = this.LastEditedMetadata;
          transformedXML = ItemInfoHelper.TransformMetadata(untransformedXML);
        }

        string errorMsg = string.Empty;
        if (!Utils.IsValidMetadata(untransformedXML, out errorMsg))
          return Utils.GetErrorHtmlWithLink(errorMsg, GenerateHTMLXMLFile(untransformedXML));

        _currentUntransformedXML = untransformedXML;
        _currentTransformedXML = transformedXML;

        // transform
        var outputDoc = TransformMetadata.Transform(_currentTransformedXML, this.FlowDirection, this.Path, null, thumbnailURI, false);
        var html = outputDoc.InnerXml;

        // Notify we have changed
        var args = new MetadataEditEventArgs(MetadataEditEventAction.Select);
        args.Item = this.Item;
        args.TypeID = this.Item.TypeID;
        MetadataEditEvent.Publish(args);

        bSuccessful = true;

        return html;
      }
      catch (XSLTProcessingException ex)
      {
        Debug.WriteLine(ex);
        return Utils.GetDetailedErrorHtml(Internal.Metadata.Properties.Resources.MSG_XSLT_ERROR, ex.Message);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
        return Utils.GetErrorHtml(Properties.Resources.ProjectItemNoMetadata);
      }
      finally
      {
        IsBusy = false;
      }
    }

    public void Reset()
    {
      // Give us chance to reload. We don't want to cache it forever
      this.LastEditedMetadata = string.Empty;
      this.LastEditedPath = string.Empty;
    }

    internal string GenerateHTMLXMLFile(string mdString)
    {
      var outputDoc = TransformMetadata.Transform(mdString, this.FlowDirection, this.Path, null, string.Empty, true);
      var html = outputDoc.InnerXml;

      string tempfile = string.Format("{0}.htm", System.IO.Path.GetTempFileName());
      using (StreamWriter sw = new StreamWriter(tempfile, false, Encoding.Unicode))
      {
        // prepend mark-of-the-web
        sw.Write("<!-- saved from url=(0016)http://localhost -->\r\n");
        // write the document
        sw.Write(html);
        sw.Close();
      }

      _tempFiles.Add(tempfile);

      return tempfile;
    }
  }

  class TransformMetadata
  {
    private static Dictionary<string, XslCompiledTransform> _transforms;
    private static void EnsureTransforms()
    {
      // cache transforms
      if (null == _transforms)
      {
        _transforms = new Dictionary<string, XslCompiledTransform>();
      }
    }

    private static void LoadTransform(MDSaveAsHTMLOption outputType, string metadataStyle)
    {

      if (outputType == MDSaveAsHTMLOption.esriCurrentMetadataStyle)
      {
        var editor = Utils.GetEditor(metadataStyle);
        var path = editor?.AssemblyLocation ?? "";
        var doc = Utils.GetConfigDocument(metadataStyle);
        if (null != doc)
        {
          XmlNode viewerNode = doc.SelectSingleNode("//viewerXslt");
          if (null != viewerNode && 0 < viewerNode.InnerText.Length)
          {
            string viewStr = (viewerNode.InnerText).Trim();
            string xslt = string.Empty;

            if (!string.IsNullOrEmpty(viewStr))
            {
              //First, look for the xslt in the AssemblyLocation (whereever that is)
              xslt = System.IO.Path.Combine(path, viewStr);
              if (!System.IO.File.Exists(xslt))
              {
                //Second, look for it in the Pro Resources
                xslt = Utils.InstallPath + "\\Resources\\" + viewStr;
                if (!System.IO.File.Exists(xslt))
                {
                  //Third, default to MDSaveAsHTMLOption.esriArcGISBrief
                  xslt = Utils.InstallPath + @"\Resources\Metadata\Stylesheets\ArcGISPro.xsl";
                }
              }
            }
            else
            {
              //default to MDSaveAsHTMLOption.esriArcGISBrief
              xslt = Utils.InstallPath + @"\Resources\Metadata\Stylesheets\ArcGISPro.xsl";
            }
            LoadXSLT(metadataStyle, xslt);
          }
        }
      }
      else if (outputType == MDSaveAsHTMLOption.esriArcGISFull)
      {
        var xslt = Utils.InstallPath + @"\Resources\Metadata\Stylesheets\ArcGISProFull.xsl";
        LoadXSLT(metadataStyle, xslt);
      }
      else if (outputType == MDSaveAsHTMLOption.esriArcGISBrief)
      {
        var xslt = Utils.InstallPath + @"\Resources\Metadata\Stylesheets\ArcGISPro.xsl";
        LoadXSLT(metadataStyle, xslt);
      }
    }

    private static void LoadXSLT(string styleName, string xsltFilePath)
    {
      EnsureTransforms();

      var transform = new XslCompiledTransform();
      XsltSettings xslSettings = new XsltSettings(false, true);
      var resolver = new XmlUrlResolver();

      try
      {
        transform.Load(xsltFilePath, xslSettings, resolver);
        _transforms.Add(styleName, transform);
      }
      catch { }
    }

    public static XmlDocument Transform(string xml, FlowDirection flowDirection, string catalogPath, string error, string thumbnailURI, bool transformToHTMLXML)
    {
      return Transform(xml, MDSaveAsHTMLOption.esriCurrentMetadataStyle, flowDirection, catalogPath, error, thumbnailURI, transformToHTMLXML);
    }

    public static XmlDocument Transform(string xml, MDSaveAsHTMLOption outputType, FlowDirection flowDirection, string catalogPath, string error, string thumbnailURI, bool transformToHTMLXML)
    {
      // get named transform
      EnsureTransforms();

      // TODO: storing current style in Properties.Settings.Default.MetadataStyle may not be correct.
      var currentStyle = ArcGIS.Desktop.Internal.Metadata.Properties.Settings.Default.MetadataStyle;
      if (outputType == MDSaveAsHTMLOption.esriArcGISFull)
        currentStyle = "SDK_Full";
      else if (outputType == MDSaveAsHTMLOption.esriArcGISBrief)
        currentStyle = "SDK_Brief";

      var transform = _transforms.ContainsKey(currentStyle) ? _transforms[currentStyle] : null;
      if (transformToHTMLXML)
      {
        var xslt = Utils.InstallPath + @"\Resources\Metadata\Stylesheets\XML.XSL";
        
        transform = new XslCompiledTransform();
        XsltSettings xslSettings = new XsltSettings(false, true);
        var resolver = new XmlUrlResolver();

        transform.Load(xslt, xslSettings, resolver);
      }

      if (null == transform)
      {
        try
        {
          LoadTransform(outputType, currentStyle);
          transform = _transforms.ContainsKey(currentStyle) ? _transforms[currentStyle] : null;
        }
        catch (Exception ex)
        {
          throw new XSLTProcessingException(ex.Message);   
        }       
      }

      if (null == transform)
      {
        throw new XSLTProcessingException(string.Empty);   
      }

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
        try
        {
          transform.Transform(sourceDoc.CreateNavigator(), xslArgs, xmlWriter);
        }
        catch (Exception ex)
        {
          throw new XSLTProcessingException(ex.Message);
        }       
      }

      // substitute strings
      XsltExtFunctions.SubstituteXsltResourceStrings(targetDoc);

      // return target doc
      return targetDoc;
    }
  }
  #pragma warning restore 1591
}
