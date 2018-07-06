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
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.IO;
using Microsoft.Win32;

using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Core.Events;
using ArcGIS.Desktop.Internal.Core;
using ArcGIS.Desktop.Internal.Core.Events;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Events;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Internal.Core.Metadata;
using ArcGIS.Desktop.Internal.Metadata;
using ArcGIS.Desktop.Internal.Metadata.Events;
using ArcGIS.Desktop.Internal.Metadata.Properties;
using ArcGIS.Desktop.Metadata.Editor;
using ESRI.ArcGIS.ItemIndex;

namespace ArcGIS.Desktop.Metadata
{
  internal enum SaveAsOptions
  {
    esriMDSaveAsHTML = 0,
    esriMDSaveAsXML = 1,
    esriMDSaveAsXMRemoveMachineNames = 2,
    esriSaveAsRemoveAllSensitive = 3,
    esriSaveAsTemplate = 4
  }

  internal sealed class MetadataSaveAsHTMLCmd : MetadataSaveAsCmdBase
  {
    public MetadataSaveAsHTMLCmd() : base(SaveAsOptions.esriMDSaveAsHTML) { }
  }

  internal sealed class MetadataSaveAsXMLCmd : MetadataSaveAsCmdBase
  {
    public MetadataSaveAsXMLCmd() : base(SaveAsOptions.esriMDSaveAsXML) { }
  }

  internal sealed class MetadataSaveAsXMLRemoveMachineNamesCmd : MetadataSaveAsCmdBase
  {
    public MetadataSaveAsXMLRemoveMachineNamesCmd() : base(SaveAsOptions.esriMDSaveAsXMRemoveMachineNames) { }
  }

  internal sealed class MetadataSaveAsXMLRemoveSensitiveInfoCmd : MetadataSaveAsCmdBase
  {
    public MetadataSaveAsXMLRemoveSensitiveInfoCmd() : base(SaveAsOptions.esriSaveAsRemoveAllSensitive) { }
  }

  internal sealed class MetadataSaveAsTemplateCmd : MetadataSaveAsCmdBase
  {
    public MetadataSaveAsTemplateCmd() : base(SaveAsOptions.esriSaveAsTemplate) { }
  }

  internal class MetadataSaveAsCmdBase : Button
  {
    private SaveAsOptions _option = SaveAsOptions.esriMDSaveAsHTML;

    public MetadataSaveAsCmdBase(SaveAsOptions option) 
    {
      _option = option;
    }

    private void SaveMetadataAs(Item item, string filePath)
    {
      if (_option == SaveAsOptions.esriSaveAsTemplate)
      {
        try
        {
          string xslt = Utils.InstallPath + @"\Resources\Metadata\Stylesheets\gpTools\generate metadata template.xslt";
          ItemInfoHelper.SaveMetadataAsUsingCustomXSLT(item.ItemInfoValue, xslt, filePath);
        }
        catch { }
      }
      else if (_option == SaveAsOptions.esriMDSaveAsHTML)
        ItemInfoHelper.SaveMetadataAsHTML(item.ItemInfoValue, filePath, MDSaveAsHTMLOption.esriCurrentMetadataStyle);
      else if (_option == SaveAsOptions.esriMDSaveAsXML)
        ItemInfoHelper.SaveMetadataAsXML(item.ItemInfoValue, filePath, MDSaveAsXMLOption.esriExactCopy);
      else if (_option == SaveAsOptions.esriMDSaveAsXMRemoveMachineNames)
        ItemInfoHelper.SaveMetadataAsXML(item.ItemInfoValue, filePath, MDSaveAsXMLOption.esriRemoveMachineNames);
      else if (_option == SaveAsOptions.esriSaveAsRemoveAllSensitive)
        ItemInfoHelper.SaveMetadataAsXML(item.ItemInfoValue, filePath, MDSaveAsXMLOption.esriRemoveAllSensitive);
    }

    private async Task SaveMetadataAsAsync(IEnumerable<Item> items, string path)
    {
      await QueuedTask.Run(() =>
      {
        if (items.Count() > 1)
        {
          foreach (var item in items)
          {
            if (item != null)
            {
              string filePath = GetValidFilePath(path, item.Name);
              SaveMetadataAs(item, filePath);
            }
          }
        }
        else
        {
          Item item = items.FirstOrDefault();
          if (item != null)
            SaveMetadataAs(item, path);
        }
      });
    }

    private string GetValidFilePath(string parentFolderPath, string srcFileName)
    {
      string result = string.Empty;
      string ext = (_option == SaveAsOptions.esriMDSaveAsHTML) ? ".html" : ".xml";

      try
      {
        result = Path.Combine(parentFolderPath, string.Format("{0}{1}", srcFileName, ext));

        int count = 0;
        while (File.Exists(result))
          result = Path.Combine(parentFolderPath, string.Format("{0}_{1}{2}", srcFileName, count++, ext));
      }
      catch { }

      return result;
    }

    protected override async void OnClick()
    {
      ArcGIS.Desktop.Core.IProjectWindow projectWindow = Project.GetActiveCatalogWindow();
      if (projectWindow == null || projectWindow.SelectionCount == 0 || projectWindow.SelectedItems == null)
        return;

      try
      {
        if (projectWindow.SelectionCount > 1)
        {
          BrowseEnvironment browseEnv = new BrowseEnvironment("esri_browseDialogFilters_folders");
          browseEnv.Title = Resources.BROWSER_TITLE_DESTINATION;

          bool? dialogResult = ArcGIS.Desktop.Internal.Core.BrowseDialog.ShowDialog(browseEnv);
          if (dialogResult == null || !dialogResult.Value)
            return;

          Item prjItem = browseEnv.SelectedItems.FirstOrDefault();
          if (prjItem == null || string.IsNullOrEmpty(prjItem.Path))
            return;

          await SaveMetadataAsAsync(projectWindow.SelectedItems, prjItem.Path);
        }
        else
        {
          Item item = projectWindow.SelectedItems.FirstOrDefault();
          if (item == null)
            return;

          string selectedText = (_option == SaveAsOptions.esriMDSaveAsHTML) ? item.Name + ".html" : item.Name + ".xml";

          var filter = BrowseProjectFilter.GetFilter("esri_browseDialogFilters_browseFiles");
          filter.Name = (_option == SaveAsOptions.esriMDSaveAsHTML) ? "HTML (*.html;*.htm)" : "XML (*.xml)";
          filter.FileExtension = (_option == SaveAsOptions.esriMDSaveAsHTML) ? "*.html;*.htm" : "*.xml";
          filter.BrowsingFilesMode = true;

          BrowseEnvironment browseEnv = new BrowseEnvironment(filter);
          browseEnv.Title = Resources.BROWSER_SAVEAS_TITLE;
          browseEnv.IsMultipleSelect = false;
          browseEnv.OverwritePrompt = true;
          browseEnv.IsSaveMode = true;
          browseEnv.InitialLocation = "esri_browsePlaces_Computer";
          browseEnv.SelectedText = selectedText;

          bool? dialogResult = ArcGIS.Desktop.Internal.Core.BrowseDialog.ShowDialog(browseEnv);
          if (dialogResult == null || !dialogResult.Value || string.IsNullOrEmpty(browseEnv.SelectedText))
            return;

          await SaveMetadataAsAsync(projectWindow.SelectedItems, browseEnv.SelectedText);
        }
      }
      catch (Exception ex)
      {
        string caption = Internal.Metadata.Properties.Resources.MDSaveAsFailureTitle;
        ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox(ex.Message, caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);
      }

      base.OnClick();
    }
  }

  internal sealed class MetadataImportCurrentStyleCmd : ImportMetadataCmdBase
  {
    public MetadataImportCurrentStyleCmd() : base(MDImportExportOption.esriCurrentMetadataStyle) { }
  }

  internal sealed class MetadataImportISO19115_19139Cmd : ImportMetadataCmdBase
  {
    public MetadataImportISO19115_19139Cmd() : base(MDImportExportOption.esriIso19139Gml32) { }
  }

  internal sealed class MetadataImportFGDCCmd : ImportMetadataCmdBase
  {
    public MetadataImportFGDCCmd() : base(MDImportExportOption.esriFgdcCsdgm) { }
  }

  internal sealed class MetadataCopyFromCmd : ImportMetadataCmdBase
  {
    public MetadataCopyFromCmd() : base(MDImportExportOption.esriMetadataStyleNone) { }
  }

  internal class ImportMetadataCmdBase : Button
  {
    private MDImportExportOption _option = MDImportExportOption.esriCurrentMetadataStyle;

    public ImportMetadataCmdBase(MDImportExportOption option)
    {
      _option = option;
    }

    protected override void OnClick()
    {
      ArcGIS.Desktop.Core.IProjectWindow projectWindow = Project.GetActiveCatalogWindow();
      if (projectWindow == null || projectWindow.SelectionCount != 1 || projectWindow.SelectedItems == null)
        return;

      Item item = projectWindow.SelectedItems.FirstOrDefault();
      if (item == null)
        return;

      var parentFilter = new BrowseProjectFilter();
      parentFilter.Filters.Add(BrowseProjectFilter.GetFilter("esri_browseDialogFilters_all"));

      BrowseEnvironment browseEnv = new BrowseEnvironment(parentFilter);
      browseEnv.Title = Resources.IMPORT_MD_TITLE;
      browseEnv.IsMultipleSelect = false;

      bool? dialogResult = ArcGIS.Desktop.Internal.Core.BrowseDialog.ShowDialog(browseEnv);
      if (dialogResult == null || !dialogResult.Value || string.IsNullOrEmpty(browseEnv.SelectedText))
        return;

      Item srcItem = browseEnv.SelectedItems.FirstOrDefault();

      try
      {
        Task t = QueuedTask.Run(() =>
        {
          ItemInfoHelper.ImportMetadata(item.ItemInfoValue, srcItem.ItemInfoValue, _option);
        });

        t.ContinueWith((r) =>
        {
          System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)(() =>
          {
            // Notify details page to reload
            var argsEdit = new MetadataEditEventArgs(MetadataEditEventAction.Reload);
            argsEdit.IsFromEditor = false;

            MetadataEditEvent.Publish(argsEdit);
          }));
        }, QueuedTask.UIScheduler);
      }
      catch (Exception ex)
      {
        string caption = Internal.Metadata.Properties.Resources.MDImportMetadataFailureTitle;
        ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox(ex.Message, caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);
      }

      base.OnClick();
    }
  }

  internal sealed class MetadataExportCurrentStyleCmd : ExportMetadataCmdBase
  {
    public MetadataExportCurrentStyleCmd() : base(MDImportExportOption.esriCurrentMetadataStyle) { }
  }

  internal sealed class MetadataExportISO19115_19139Cmd : ExportMetadataCmdBase
  {
    public MetadataExportISO19115_19139Cmd() : base(MDImportExportOption.esriIso19139Gml32) { }
  }

  internal sealed class MetadataExportFGDCCmd : ExportMetadataCmdBase
  {
    public MetadataExportFGDCCmd() : base(MDImportExportOption.esriFgdcCsdgm) { }
  }

  internal class ExportMetadataCmdBase : Button
  {
    private MDImportExportOption _option = MDImportExportOption.esriCurrentMetadataStyle;

    public ExportMetadataCmdBase(MDImportExportOption option)
    {
      _option = option;
    }

    private string GetValidFilePath(string parentFolderPath, string srcFileName)
    {
      string result = string.Empty;
      string ext = ".xml";

      try
      {
        result = Path.Combine(parentFolderPath, string.Format("{0}{1}", srcFileName, ext));

        int count = 0;
        while (File.Exists(result))
          result = Path.Combine(parentFolderPath, string.Format("{0}_{1}{2}", srcFileName, count++, ext));
      }
      catch { }

      return result;
    }

    protected override async void OnClick()
    {
      ArcGIS.Desktop.Core.IProjectWindow projectWindow = Project.GetActiveCatalogWindow();
      if (projectWindow == null || projectWindow.SelectionCount != 1 || projectWindow.SelectedItems == null)
        return;

      Item item = projectWindow.SelectedItems.FirstOrDefault();
      if (item == null)
        return;

      string selectedText = item.Name + ".xml";

      var parentFilter = new BrowseProjectFilter();
      parentFilter.Filters.Add(BrowseProjectFilter.GetFilter("esri_browseDialogFilters_browseFiles"));
      parentFilter.FileExtension = "*.xml";
      parentFilter.BrowsingFilesMode = true;

      BrowseEnvironment browseEnv = new BrowseEnvironment(parentFilter);
      browseEnv.Title = Resources.EXPORT_MD_TITLE;
      browseEnv.IsMultipleSelect = false;
      browseEnv.OverwritePrompt = true;
      browseEnv.IsSaveMode = true;
      browseEnv.InitialLocation = "esri_browsePlaces_Computer";
      browseEnv.SelectedText = selectedText;

      bool? dialogResult = ArcGIS.Desktop.Internal.Core.BrowseDialog.ShowDialog(browseEnv);
      if (dialogResult == null || !dialogResult.Value || string.IsNullOrEmpty(browseEnv.SelectedText))
        return;

      try
      {
        await QueuedTask.Run(() =>
        {
          ItemInfoHelper.ExportMetadata(item.ItemInfoValue, browseEnv.SelectedText, _option);
        });
      }
      catch (Exception ex)
      {
        string caption = Internal.Metadata.Properties.Resources.MDExportMetadataFailureTitle;
        ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox(ex.Message, caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);
      }

      base.OnClick();
    }
  }

  internal sealed class MetadataSaveCmd : MetadataButtonCmdBase
  {
    public MetadataSaveCmd() : base(false, Internal.Metadata.Properties.Resources.Save_Button_Enabled_ToolTip, Internal.Metadata.Properties.Resources.Save_Button_Disabled_ToolTip) { }
  }

  internal sealed class MetadataApplyCmd : MetadataButtonCmdBase
  {
    public MetadataApplyCmd() : base(true, Internal.Metadata.Properties.Resources.Apply_Button_Enabled_ToolTip, Internal.Metadata.Properties.Resources.Apply_Button_Disabled_ToolTip) { }
  }

  internal class MetadataButtonCmdBase : Button, IDisposable
  {
    private bool _bAssociatedWithProject = false;
    private string _tooltip = string.Empty;
    private string _disabledTooltip = string.Empty;

    public MetadataButtonCmdBase(bool bAssociatedWithProjectItem, string tooltip, string disabledTooltip)
    {
      _bAssociatedWithProject = bAssociatedWithProjectItem;
      _tooltip = tooltip;
      _disabledTooltip = disabledTooltip;

      MetadataEditEvent.Subscribe(OnMetadataEvent);
      ActivePaneChangedEvent.Subscribe(ActivePaneChanged);
      ProjectClosingEvent.Subscribe(OnProjectClosing);
      SyncWithPane(FrameworkApplication.Panes.ActivePane as MetadataEditPaneViewModel);
    }

    ~MetadataButtonCmdBase()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
    }

    private bool _disposed = false;
    private void Dispose(bool disposing)
    {
      if (!_disposed)
      {
        MetadataEditEvent.Unsubscribe(OnMetadataEvent);
        ActivePaneChangedEvent.Unsubscribe(ActivePaneChanged);
        ProjectClosingEvent.Unsubscribe(OnProjectClosing);

        _disposed = true;
      }
    }

    protected override void OnClick()
    {
      var args = new MetadataEditEventArgs(MetadataEditEventAction.Save);
      MetadataEditEvent.Publish(args);

      base.OnClick();
    }

    private void UpdateButton(Item item)
    {
      if (string.IsNullOrEmpty(item.Path))
        return;

      this.Enabled = !(_bAssociatedWithProject ^ Utils.IsProjectItem(item));
      this.Tooltip = _tooltip;
      this.DisabledTooltip = _disabledTooltip;
    }

    private void SyncWithPane(MetadataEditPaneViewModel pane)
    {
      if (pane != null)
      {
        if (pane.EditorViewModel != null)
          UpdateButton(pane.EditorViewModel.Item);
      }
    }

    private void ActivePaneChanged(PaneEventArgs obj)
    {
      SyncWithPane(FrameworkApplication.Panes.ActivePane as MetadataEditPaneViewModel);
    }

    private void OnMetadataEvent(MetadataEditEventArgs args)
    {
      // Test for the correct pane
      if (!(FrameworkApplication.Panes.ActivePane is MetadataEditPaneViewModel))
        return; // this is not the pane you're looking for

      switch (args.Action)
      {
        case MetadataEditEventAction.Select:
          UpdateButton(args.Item);
          break;

        default:
          break;
      }
    }

    private Task OnProjectClosing(ProjectClosingEventArgs e)
    {
      MetadataEditEvent.Unsubscribe(OnMetadataEvent);
      ActivePaneChangedEvent.Unsubscribe(ActivePaneChanged);
      ProjectClosingEvent.Unsubscribe(OnProjectClosing);

      return Task.FromResult(0);
    }
  }
}
