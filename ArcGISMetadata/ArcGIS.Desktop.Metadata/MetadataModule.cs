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

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Xml;
using System.IO;
using System.Text;

using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Core.Events;
using ArcGIS.Desktop.Internal.Core;
using ArcGIS.Desktop.Internal.Core.Events;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Events;
using ArcGIS.Desktop.Internal.Core.Metadata;
using ArcGIS.Desktop.Internal.Metadata;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Core.Internal.Threading.Tasks;
using ArcGIS.Desktop.Metadata.Editor;
using ArcGIS.Desktop.Internal.Metadata.Events;
using ESRI.ArcGIS.ItemIndex;

namespace ArcGIS.Desktop.Metadata
{
  // The Module class
  internal sealed partial class MetadataModule : Module, IArcGISMetadata, IMetadataEditorHost
  {
    private static XsltExtFunctions _xsltFunctions = new XsltExtFunctions();
    private static MetadataDetailsView _metadataDetailsView = null;
    private static MetadataDetailsViewModel _meadataDetailsViewModel = null;
    private string _editRequestCatalogPath = string.Empty;

    static private MetadataModule _thisModule = null;      
    static public MetadataModule GetModule()
    {
      if (null == _thisModule)
        _thisModule = FrameworkApplication.FindModule("esri_metadata_module") as MetadataModule;

      return _thisModule;
    }

    internal MetadataModule()
    {
    }

    protected override void Uninitialize()
    {
      base.Uninitialize();
    }

    protected override bool Initialize()
    {
      if (!base.Initialize())
        return false;      

      return true;
    }
    
    #region IArcGISMetadata Members

    public FrameworkElement GetMetadataDetailsPane(string path, ItemInfoValue iiv, string selectedItemDisplayType, uint paneID)
    {
      // Viewmodel for metadata details view
      if (_meadataDetailsViewModel == null)
        _meadataDetailsViewModel = new MetadataDetailsViewModel();

      _meadataDetailsViewModel.Path = path;
      _meadataDetailsViewModel.Item = Internal.Core.ItemCacheFactory.Current.CreateCachedProjectItem(iiv);
      _meadataDetailsViewModel.PaneID = paneID;

      _meadataDetailsViewModel.SelectedItemDisplayType = selectedItemDisplayType;

      // Prepare to listen to metadata edit events
      _meadataDetailsViewModel.PrepareBrowsing();

      // Metadata details view
      if (_metadataDetailsView == null)
        _metadataDetailsView = new MetadataDetailsView();

      _metadataDetailsView.DataContext = _meadataDetailsViewModel;
      _metadataDetailsView.Synchronize = true;

      // Navigate
      _metadataDetailsView.PrepareBrowsing();
      _metadataDetailsView.Navigate(path, iiv);

      return _metadataDetailsView;
    }

    public string StripHTML(string xmlString) { return _xsltFunctions.striphtml(xmlString); }
    public void CancelBrowsing(string catalogPath, string typeID) { if (_metadataDetailsView != null) _metadataDetailsView.CancelBrowsing(catalogPath, typeID); }

    public async void EditMetadataOnSelectedItem(Item item)
    {
      if (item == null)
        return;

      // Get metadata first
      string metadataXML = await ItemInfoHelper.GetMetadataAsync((item as IItemInternal).ItemInfoValue, true);
      if (string.IsNullOrEmpty(metadataXML))
        return;

      // Check whehther pane / VM exists already
      MetadataEditPaneViewModel pane = null;
      MetadataEditorViewModel editorVM = null;
      foreach (Pane p in ArcGIS.Desktop.Framework.FrameworkApplication.Panes)
      {
        MetadataEditPaneViewModel metadataEditPaneVm = p as MetadataEditPaneViewModel;
        if (null != metadataEditPaneVm)
        {
          editorVM = metadataEditPaneVm.EditorViewModel;
          if (editorVM == null)
            continue;

          if (item.Name == editorVM.Item.Name && item.Path == editorVM.Item.Path && item.TypeID == editorVM.Item.TypeID)
          {
            pane = metadataEditPaneVm;
            break;
          }
        }
      }

      if (null == pane)
      {
        // Create pane
        pane = FrameworkApplication.Panes.Create("esri_metadata_metadataPane") as MetadataEditPaneViewModel;
        if (pane == null)
          return;

        // Create VM
        var currentStyle = ArcGIS.Desktop.Internal.Metadata.Properties.Settings.Default.MetadataStyle;
        editorVM = new MetadataEditorViewModel() { DefaultMetadataStyle = currentStyle };
        editorVM.SelectedItemDisplayType = item.Type;
        editorVM.Item = item;
        editorVM.Path = item.Path;
        editorVM.Initialize(metadataXML, string.Empty);

        // Initialie pane
        pane.Caption = item.Name;
        pane.EditorViewModel = editorVM;

        // Notify the data context has change and so Save button can be updated
        var argsEdit = new MetadataEditEventArgs(MetadataEditEventAction.Select);
        argsEdit.Item = item;
        argsEdit.TypeID = item.TypeID;
        MetadataEditEvent.Publish(argsEdit);
      }
      
      pane.Activate();
    }

    public void OnMetadataSourceChanged(bool bFromSource)
    {
      if (_metadataDetailsView != null)
      {
        if (!bFromSource)
          FrameworkApplication.State.Activate("esri_metadata_canEditMetadata");
        else
          FrameworkApplication.State.Deactivate("esri_metadata_canEditMetadata");
      }
    }

    public void OnSelectionChanged(ItemInfoValue iiv)
    {
      if (_metadataDetailsView == null || !_metadataDetailsView.IsVisible)
      {
        QueuedTask.Run(() =>
        {
          bool bCanEdit = ItemInfoHelper.GetCanEditMetadata(iiv);
          if (bCanEdit)
            FrameworkApplication.State.Activate("esri_metadata_canEditMetadata");
          else
            FrameworkApplication.State.Deactivate("esri_metadata_canEditMetadata");
        });
      }
    }

    public MDImportExportOption GetCurrentImportExportOption()
    {
      MDImportExportOption result = MDImportExportOption.esriIso19139Gml32;

      string styleName = ArcGIS.Desktop.Internal.Metadata.Properties.Settings.Default.MetadataStyle;
      var doc = Utils.GetConfigDocument(styleName);
      if (null != doc)
      {
        XmlNode transformNode = doc.SelectSingleNode("//tranformStyle");
        if (null != transformNode && 0 < transformNode.InnerText.Length)
        {
          string transformStr = (transformNode.InnerText).Trim();
          if (!string.IsNullOrEmpty(transformStr))
          {
            if (transformStr.Equals("ISO19139gml321", StringComparison.CurrentCultureIgnoreCase))
              result = MDImportExportOption.esriIso19139Gml32;
            else if (transformStr.Equals("ISO19139", StringComparison.CurrentCultureIgnoreCase))
              result = MDImportExportOption.esriIso19139;
            else if (transformStr.Equals("FGDC", StringComparison.CurrentCultureIgnoreCase))
              result = MDImportExportOption.esriFgdcCsdgm;
          }
        }
      }

      return result;
    }

    public FlowDirection FlowDirection { get; set; }

    public void SaveMetadataAsHTML(int projectID, ref ItemInfoValue iiv, string outputFilePath, MDSaveAsHTMLOption outputType)
    {
      string untransformedXML = string.Empty;
      string transformedXML = string.Empty;
      string thumbnailURI = null;
      string resultHTML = string.Empty;

      try
      {
        // Get metadata 
        ItemInfoHelper.GetMetadata(iiv, true, out untransformedXML, out transformedXML);

        // Transform GOOD XML and display
        if (!string.IsNullOrWhiteSpace(untransformedXML))
        {
          string errorMsg = string.Empty;
          if (!Utils.IsValidMetadata(untransformedXML, out errorMsg))
          {
            var outputDoc = TransformMetadata.Transform(errorMsg, this.FlowDirection, iiv.catalogPath, null, string.Empty, true);
            resultHTML = outputDoc.InnerXml;
          }
          else
          {
            // transform
            var outputDoc = TransformMetadata.Transform(transformedXML, this.FlowDirection, iiv.catalogPath, null, thumbnailURI, false);
            resultHTML = outputDoc.InnerXml;
          }
        }
        else
          resultHTML = Utils.GetErrorHtml(Internal.Metadata.Properties.Resources.Browse_Item_MD_Not_Supported);
      }
      catch (XSLTProcessingException ex)
      {
        resultHTML = Utils.GetDetailedErrorHtml(Internal.Metadata.Properties.Resources.MSG_XSLT_ERROR, ex.Message);
      }
      catch (InvalidMetadataException ex)
      {
        resultHTML = Utils.GetDetailedErrorHtml(Internal.Metadata.Properties.Resources.ERROR_INVALID_XML, ex.Message);
      }
      catch (Exception)
      {
        resultHTML = Utils.GetErrorHtml(Internal.Metadata.Properties.Resources.ProjectItemNoMetadata);
      }
      finally
      {
      }

      using (StreamWriter sw = new StreamWriter(outputFilePath, false, Encoding.Unicode))
      {
        sw.Write(resultHTML);
        sw.Close();
      }
    }

    #endregion

    #region IMetadataEditor Members

    public string GetCurrentProfile(DependencyObject dep)
    {
      return Utils.GetCurrentProfile(dep);
    }

    public void AddCommitPage(DependencyObject dep)
    {
      try
      {
        MetadataEditorViewModel mdEditorModel = Utils.GetMetadataEditorViewModel(dep);
        if (mdEditorModel != null)
          mdEditorModel.AddCommitPage(dep as Editor.Pages.EditorPage);
      }
      catch { }
    }

    public void SetIsLoadingPage(DependencyObject dep, bool bLoading)
    {
      MetadataEditorViewModel mdEditorModel = Utils.GetMetadataEditorViewModel(dep);
      if (mdEditorModel != null)
        mdEditorModel.IsLoadingPage = bLoading;
    }

    public void OnUpdateThumbnail(DependencyObject dep)
    {
      MetadataEditorViewModel mdEditorModel = Utils.GetMetadataEditorViewModel(dep);
      if (mdEditorModel != null)
        mdEditorModel.OnUpdateThumbnail();
    }

    public void UpdateDataContext(DependencyObject dep)
    {
      MetadataEditorViewModel.UpdateDataContext(dep);
    }

    #endregion

    #region Commands

    internal void OnMetadataEdit()
    {
      if (_meadataDetailsViewModel != null && _metadataDetailsView != null)
      {
        var args = new MetadataEditEventArgs(MetadataEditEventAction.Edit);
        MetadataEditEvent.Publish(args);
      }
      else
      {
        ArcGIS.Desktop.Core.IProjectWindow projectWindow = Project.GetActiveCatalogWindow();
        if (projectWindow?.SelectionCount != 1 || projectWindow.SelectedItems == null)
          return;

        Item selectedItem = projectWindow.SelectedItems.FirstOrDefault();
        if (selectedItem != null)
          EditMetadataOnSelectedItem(selectedItem);
      }
    }

    internal void OnMetadataEditCancel()
    {
      var args = new MetadataEditEventArgs(MetadataEditEventAction.CancelEdit);
      MetadataEditEvent.Publish(args);
    }

    internal void OnMetadataPrint()
    {
      var args = new MetadataEditEventArgs(MetadataEditEventAction.Print);
      MetadataEditEvent.Publish(args);
    }   

    #endregion
  }
}
