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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Internal.Core.Events;
using ArcGIS.Desktop.Internal.Core;
using ArcGIS.Desktop.Metadata.Editor;
using ArcGIS.Desktop.Internal.Metadata.Events;

namespace ArcGIS.Desktop.Metadata
{
  internal class MetadataOptionsViewModel : ArcGIS.Desktop.Framework.Contracts.Page
  {
    #region Private fields

    private List<string> _stylesheetsLists;
    private bool _bPopup = true;
    private string _currentStyle = string.Empty;
    private static string _installDir = string.Empty;
    public const string DEFAULT_METADATA_STYLE = @"Item Description";

    #endregion

    #region Constructor / destructor

    public MetadataOptionsViewModel()
    {
      // Load stylesheet configurations from resources
      _stylesheetsLists = Utils.GetStylesheetNames();

      // Load the settings 
      Core.CoreModule coreModule = FrameworkApplication.FindModule("esri_core_module") as Core.CoreModule;
      _bPopup = coreModule.ShowItemPopups;
      _currentStyle = ArcGIS.Desktop.Internal.Metadata.Properties.Settings.Default.MetadataStyle;
      if (string.IsNullOrEmpty(_currentStyle))
        _currentStyle = DEFAULT_METADATA_STYLE;
    }

    #endregion

    #region Binding

    public List<string> StyleSheets
    {
      get { return _stylesheetsLists; }
      set
      {
        SetProperty(ref _stylesheetsLists, value, () => StyleSheets);
      }
    }

    public string CurrentStyleSheet
    {
      get { return _currentStyle; }
      set
      {
        if (SetProperty(ref _currentStyle, value, () => CurrentStyleSheet))
        {
          this.IsModified = true;
        }
      }
    }

    public bool AlwaysShowPopup
    {
      get { return _bPopup; }
      set
      {
        if (SetProperty(ref _bPopup, value, () => AlwaysShowPopup))
        {
          this.IsModified = true;
        }
      }
    }

    #endregion 

    #region Override methods

    protected override Task InitializeAsync()
    {
      try
      {
        CurrentStyleSheet = _currentStyle;
      }
      catch (Exception ex)
      {
        Trace.WriteLine(ex.Message);
      }

      return Task.FromResult(0);
    }

    protected override Task CommitAsync()
    {
      if (this.IsModified)
      {
        // Save the settings
        ArcGIS.Desktop.Internal.Metadata.Properties.Settings.Default.MetadataStyle = _currentStyle;
        ArcGIS.Desktop.Internal.Metadata.Properties.Settings.Default.Save();

        Core.CoreModule coreModule = FrameworkApplication.FindModule("esri_core_module") as Core.CoreModule;
        if (coreModule != null)
        {
          IInternalCoreModule internalCore = coreModule as IInternalCoreModule;
          internalCore.OnMetadataBackstageOptionChanged(null);
          coreModule.ShowItemPopups = _bPopup;
        }

        // Notify details page to reload
        var argsEdit = new MetadataEditEventArgs(MetadataEditEventAction.Reload);
        argsEdit.IsFromEditor = false;

        MetadataEditEvent.Publish(argsEdit);
      }

      return Task.FromResult(0);
    }

    #endregion

    #region  methods / properties

    public bool IsMetadataStyleSelectionEnabled
    {
      get { return !FrameworkApplication.Panes.OfType<MetadataEditPaneViewModel>().Any(); }
    }

    public ICommand HelpCmd
    {
      get
      {
        return new RelayCommand(() => ArcGIS.Desktop.Framework.FrameworkApplication.ShowHelpTopic("120001004#ESRI_SECTION1_0FAB123C7C3C4CD49894272A899490ED"), false);
      }
    }
    #endregion 

    #region Internal / Private methods
    #endregion
  }
}
