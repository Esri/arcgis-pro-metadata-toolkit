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

using System.Threading.Tasks;
using System.Windows;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Internal.Core;
using ArcGIS.Desktop.Internal.Core.Events;
using ArcGIS.Desktop.Internal.DesktopService;
using ArcGIS.Desktop.Internal.Framework.Utilities;
using ArcGIS.Desktop.Metadata.Editor;
using ESRI.ArcGIS.ItemIndex;
using ArcGIS.Desktop.Internal.Metadata;
using ArcGIS.Desktop.Internal.Metadata.Events;

namespace ArcGIS.Desktop.Metadata
{
  internal class MetadataEditPaneViewModel : ViewStatePane, IContentsProvider
  {
    private MetadataEditorViewModel _editorViewModel;
    private OperationManager _metadataOperationManager = new OperationManager();
    private bool _disposed = false;
    private bool _bClosingAfterSourceDeleted = false;

    public MetadataEditPaneViewModel() : base(null)
    {
    }

    public MetadataEditPaneViewModel(CIMView view) : base(view)
    {
    }

    ~MetadataEditPaneViewModel()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
    }

    private void Dispose(bool disposing)
    {
      if (!_disposed)
      {
        ProjectItemDeletedEvent.Unsubscribe(OnProjectItemDeleted);
        _disposed = true;
      }
    }

    #region ViewStatePane

    private static IItemInfoService _itemInfoService = null;
    private static IItemInfoService ItemInfoService
    {
      get
      {
        if (_itemInfoService == null)
          _itemInfoService = ArcGIS.Desktop.Internal.Framework.Utilities.ServiceManager.Find<IItemInfoService>();

        return _itemInfoService;
      }
    }

    public override CIMView ViewState
    {
      get
      {
        if (_editorViewModel == null || string.IsNullOrEmpty(_editorViewModel.Item.Path))
          return null;

        var metadataGenericView = new CIMGenericView();

        try
        {
          metadataGenericView.InstanceID = (int)this.InstanceID;
          metadataGenericView.ViewType = "esri_metadata_metadataPane";
          metadataGenericView.ViewProperties = new Dictionary<string, object>();
          var iiv = (_editorViewModel.Item as ArcGIS.Desktop.Internal.Core.IItemInternal).ItemInfoValue;

          metadataGenericView.ViewXML = ItemInfoService.SerializeItemInfo(iiv);

          string className = "ArcGIS.Desktop.Metadata.Editor.Pages.ItemInfo";
          if (_editorViewModel.CurrentPage != null)
          {
            var type = _editorViewModel.CurrentPage.GetType();
            if (type != null)
              className = type.ToString();
          }

          metadataGenericView.ViewProperties.Add("_pageName_", className);
          metadataGenericView.ViewProperties.Add("_selectedItemDisplayType_", EditorViewModel.SelectedItemDisplayType);
        }
        catch (Exception) 
        { 
          return null;
        } 

        return metadataGenericView;
      }
    }

    #endregion

    public override OperationManager OperationManager { get { return _metadataOperationManager; } }

    public MetadataEditorViewModel EditorViewModel
    {
      get { return _editorViewModel; }
      set
      {
        _editorViewModel = value;
        if (_editorViewModel != null)
          _editorViewModel.OperationManager = OperationManager;

        this.Contents.ContentsView.DataContext = _editorViewModel;

        NotifyPropertyChanged(() => EditorViewModel);
      }
    }

    protected override void OnClosed()
    {
      if (EditorViewModel != null)
      {
        EditorViewModel.OnClosed();
        _bClosingAfterSourceDeleted = false;
      }
    }

    protected override void OnClosing(Framework.Events.CancelRoutedEventArgs e)
    {
      if (EditorViewModel != null && !_bClosingAfterSourceDeleted)
        EditorViewModel.OnClosing(e);
    }

    private void OnProjectItemDeleted(ProjectItemDeletedEventArgs args)
    {
      if (args?.Item != null && args.Item?.Path == this.EditorViewModel?.Item?.Path && args.Item.TypeID == this.EditorViewModel.Item.TypeID)
      {
        _bClosingAfterSourceDeleted = true;

        System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)(() => this.Close()));
      }
    }

    public bool ContentsReady { get { return true; } }

    private Contents _contents;
    public Contents Contents
    {
      get
      {
        return _contents ?? (_contents = new Contents { ContentsViewModel = this, ContentsView = new MetadataEditorContentsView() });
      }
    }

    protected async override Task InitializeAsync()
    {
      await base.InitializeAsync();

      if (_cimView != null)
      {
        try
        {
          CIMGenericView metadataGenericView = _cimView as CIMGenericView;
          if (metadataGenericView == null | metadataGenericView.ViewProperties == null || metadataGenericView.ViewProperties.Count == 0 || string.IsNullOrEmpty(metadataGenericView.ViewXML))
            return;

          // Get ItemInfoValue and page name
          ItemInfoValue iiv = new ItemInfoValue();
          ItemInfoService.DeserializeItemInfo(metadataGenericView.ViewXML, ref iiv);

          string currentPageName = (string)metadataGenericView.ViewProperties["_pageName_"];

          // Get untransformed xml
          string untransformedXML = await ItemInfoHelper.GetMetadataAsync(iiv, true);

          if (string.IsNullOrEmpty(untransformedXML))
          {
            string caption = Internal.Metadata.Properties.Resources.MD_SOURCE_NOT_EXIST_TITLE;
            string message = string.Format(Internal.Metadata.Properties.Resources.MD_SOURCE_NOT_EXIST_MSG, iiv.catalogPath);
            if (string.IsNullOrEmpty(iiv.catalogPath))
              message = string.Format(Internal.Metadata.Properties.Resources.MD_SOURCE_NOT_EXIST_MSG, iiv.name);           

            ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox(message, caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);

            this.Close();
          }

          // Create editor view model
          var currentStyle = ArcGIS.Desktop.Internal.Metadata.Properties.Settings.Default.MetadataStyle;
          MetadataEditorViewModel metadataEditorVM = new MetadataEditorViewModel() { DefaultMetadataStyle = currentStyle };

          // get cached item for iiv
          Item item = ItemCacheFactory.Current.CreateCachedProjectItem(iiv);

          metadataEditorVM.Item = item;
          metadataEditorVM.Path = iiv.catalogPath;

          metadataEditorVM.Initialize(untransformedXML, string.Empty, currentPageName);

          this.Caption = iiv.name;

          if (metadataGenericView.ViewProperties.ContainsKey("_selectedItemDisplayType_"))
            metadataEditorVM.SelectedItemDisplayType = (string)metadataGenericView.ViewProperties["_selectedItemDisplayType_"];
          else
            metadataEditorVM.SelectedItemDisplayType = iiv.type;
          
          EditorViewModel = metadataEditorVM;
        }
        catch (Exception e)
        {
          System.Diagnostics.Trace.WriteLine("InitializeAsync - Exception encountered. Ex: " + e);
        }
      }

      ProjectItemDeletedEvent.Subscribe(OnProjectItemDeleted);
    }

    #region ClipBoard Functions

    private bool HasValidSelectionForClipboard()
    {
      if (null == EditorViewModel ||
          null == EditorViewModel.CurrentPage ||
          null == EditorViewModel.CurrentPage.LastKeyboardFocusElement) return false;

      IInputElement fe = EditorViewModel.CurrentPage.LastKeyboardFocusElement;
      if (fe is TextBox)
      {
        TextBox tb = fe as TextBox;
        if (!string.IsNullOrEmpty(tb.SelectedText))
          return true;
      }
      else if (fe is RichTextBox)
      {
        RichTextBox rtb = fe as RichTextBox;
        if (!string.IsNullOrEmpty(rtb.Selection.Text))
          return true;
      }

      return false;
    }

    protected override Task<bool> CanCutAsync()
    {
      if (HasValidSelectionForClipboard())
        return Task.FromResult(true);

      return base.CanCutAsync();
    }

    protected override Task CutAsync()
    {
      if (null == EditorViewModel ||
          null == EditorViewModel.CurrentPage ||
          null == EditorViewModel.CurrentPage.LastKeyboardFocusElement)
        return base.CutAsync();

      IInputElement fe = EditorViewModel.CurrentPage.LastKeyboardFocusElement;
      if (fe is TextBox)
      {
        ((TextBox)fe).Cut();
        return Task.FromResult(0);
      }
      else if (fe is RichTextBox)
      {
        ((RichTextBox)fe).Cut();
        return Task.FromResult(0);
      }

      return base.CutAsync();
    }

    protected override Task<bool> CanCopyAsync()
    {
      if (HasValidSelectionForClipboard())
        return Task.FromResult(true);

      return base.CanCopyAsync();
    }

    protected override Task CopyAsync()
    {
      if (null == EditorViewModel ||
          null == EditorViewModel.CurrentPage ||
          null == EditorViewModel.CurrentPage.LastKeyboardFocusElement)
        return base.CopyAsync();

      IInputElement fe = EditorViewModel.CurrentPage.LastKeyboardFocusElement;
      if (fe is TextBox)
      {
        ((TextBox)fe).Copy();
        return Task.FromResult(0);
      }
      else if (fe is RichTextBox)
      {
        ((RichTextBox)fe).Copy();
        return Task.FromResult(0);
      }

      return base.CopyAsync();
    }

    protected override Task<bool> CanPasteAsync()
    {
      if (Clipboard.ContainsText(TextDataFormat.Text) ||
          Clipboard.ContainsText(TextDataFormat.Rtf) ||
          Clipboard.ContainsText(TextDataFormat.UnicodeText))
        return Task.FromResult(true);

      return base.CanPasteAsync();
    }

    protected override Task PasteAsync()
    {
      if (null == EditorViewModel ||
          null == EditorViewModel.CurrentPage ||
          null == EditorViewModel.CurrentPage.LastKeyboardFocusElement)
        return base.PasteAsync();

      IInputElement fe = EditorViewModel.CurrentPage.LastKeyboardFocusElement;
      if (fe is TextBox)
      {
        ((TextBox)fe).Paste();
        return Task.FromResult(0);
      }
      else if (fe is RichTextBox)
      {
        ((RichTextBox)fe).Paste();
        return Task.FromResult(0);
      }

      return base.PasteAsync();
    }

    #endregion
  }
}
