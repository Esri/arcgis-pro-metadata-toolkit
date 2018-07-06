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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Xml.Linq;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using mshtml;
using System.Web;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Reflection;

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Internal.Framework.Utilities;
using ArcGIS.Desktop.Framework.Events;
using ArcGIS.Desktop.Core.Events;
using ArcGIS.Desktop.Internal.Core;
using ArcGIS.Desktop.Internal.Core.Events;
using ArcGIS.Desktop.Internal.DesktopService;
using ArcGIS.Desktop.Internal.Metadata;
using ArcGIS.Desktop.Internal.Metadata.Events;
using ArcGIS.Desktop.Metadata.Editor.Pages;
using ArcGIS.Desktop.Metadata.Editor.Validation;
using ArcGIS.Desktop.Metadata.Editor.Controls;
using ArcGIS.Desktop.Metadata.Editor;
using ESRI.ArcGIS.ItemIndex;
using System.Windows.Input;

namespace ArcGIS.Desktop.Metadata.Editor
{
  internal enum UpdateValiationModes { CommitPages, NoCommit };

  internal class MetadataEditorViewModel : PropertyChangedBase, IDisposable
  {
    private XmlDocument _sourceMetadata;
    private XmlDocument _workingSourceMetadata;
    private XmlDataProvider _sourceMetadataProvider;
    private EditorPage _currentPage = null;
    private IInputElement _lastToLoseFocus;
    private XmlNode _firstPageNode = null;
    private XmlNode _currentInterviewNode;
    private XmlDocument _configDocument = null;
    //private Exception _configDocumentError = null;

    private Dictionary<string, EditorPage> _pageCache = new Dictionary<string, EditorPage>();
    //private XslCompiledTransform _cachedXslTransform = null;
    private EditorError _editorErrors = new EditorError();

    // need to keep a list of the current rich text boxes,
    // so that a commit operation can be called to save it's XAML into HTML into 
    // its current data context
    private List<string> _richTextboxPages = new List<string>();

    // date and numbers are all parsed in english culture/locale
    private static CultureInfo culture_en = CultureInfo.CreateSpecificCulture("en");

    public static bool _forceEditable = false; // debug hack
    public bool _canEdit = false;

    private bool _bIsLoadingPage = false;
    private bool _bIsMetadataDirty = false;
    private bool _bThumbnailUpdated = false;
    private bool _isProjectClosing = false;
    private bool _isUpgraded = false;
    private bool _miniUpgradePerformed = false;
    private bool _fgdcContentCopied = false;
    private bool _disposed = false;

    private string _currentMetadataStyle = null;
    private string _currentMetadata = string.Empty;
    private string _originalMetadata = string.Empty;
    private string _prevPageName = string.Empty;

    private const string _formatVersion = "1.0";
    private const string _fgdcRequiredStringCheck = "REQUIRED";
    private const string PROFILE_ITEM_DESCRIPTION = "ItemDescription";

    // profile name from the current configuration
    private string _profileName = null;
    private const string _profileNameXPath = "/metadataConfig/@ArcGISProfile";
    private const string _profileIsValidatingPath = "/metadataConfig/@ValidatePages";
    private string _defaultMetadataStyle = "Item Description";

    private bool _isGpTool = false;    
    
    // debug member
    public string _xmlFile;
    private static MetadataEditorViewModel _instance = null;
    private XmlDocument _xmlRecordForView;
    private XmlDocument _defaultXml;
    private string _thumbnailPath;

    #region Constructor/Destructor/Dispose

    /// <summary>
    /// create a new metadata editor control
    /// </summary>
    public MetadataEditorViewModel()
    {
      // static instance
      MetadataEditorViewModel._instance = this;

      // load XmlRecordForView
      var assembly = Assembly.GetExecutingAssembly();
      var name = @"ArcGIS.Desktop.Metadata.Editor.Templates.XmlRecordForView.xml";
      using (Stream stream = assembly.GetManifestResourceStream(name))
      {
        StreamReader tr = new StreamReader(stream);
        var xml = tr.ReadToEnd();
        _xmlRecordForView = new XmlDocument();
        _xmlRecordForView.LoadXml(xml);
      }

      // load DefaultXML
      name = @"ArcGIS.Desktop.Metadata.Editor.Templates.DefaultXml.xml";
      using (Stream stream = assembly.GetManifestResourceStream(name))
      {
        StreamReader tr = new StreamReader(stream);
        var xml = tr.ReadToEnd();
        _defaultXml = new XmlDocument();
        _defaultXml.LoadXml(xml);
      }      
    }

    ~MetadataEditorViewModel()
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
        ProjectClosingEvent.Unsubscribe(OnProjectClosing);
        ProjectCloseCanceledEvent.Unsubscribe(OnProjectCloseCanceled);
        MetadataEditEvent.Unsubscribe(OnMetadataEvent);

        _disposed = true;
      }
    }

    #endregion  

    private bool IsContentsPaneHidden()
    {
      DockPane pane = Framework.FrameworkApplication.DockPaneManager.Find("esri_core_contentsDockPane");
      if (pane == null || pane.IsVisible == false || pane.DockState == DockPaneState.AutoHide || pane.DockState == DockPaneState.Hidden)
        return true;
      else
        return false;
    }

    public void Initialize(string metadataXML, string thumbnailPath, string pageName = "")
    {
      _bIsLoadingPage = true;

      // set xml and thumbnail path
      SetXml(metadataXML);
      _thumbnailPath = thumbnailPath;

      // read configuration
      ReadCurrentConfiguration();

      if (!EditorErrors.HasError)
      {
        // setup provider
        SetupDataProvider();

        // pre-process metadata
        PreProcessMetadata(_workingSourceMetadata);
      }

      // load the first page or the page when Pro was closed
      XmlNode node = _firstPageNode;
      if (!string.IsNullOrEmpty(pageName))
      {
        string query = "//page[@class='" + pageName + "']";
        node = ConfigDocument.SelectSingleNode(query);
        if (null != node)
        {
          if (null != _firstPageNode)
          {
            _firstPageNode.Attributes["IsSelected"].Value = "False";

          }
          node.Attributes["IsSelected"].Value = "True";
        }
      }

      LoadPage(node ?? _firstPageNode);

      _bIsLoadingPage = false;

      FrameworkApplication.State.Activate("esri_metadata_metadataEditing");

      // Notify we have changed
      var args = new MetadataEditEventArgs(MetadataEditEventAction.Select);
      args.Item = this.Item;
      args.TypeID = this.Item?.TypeID;
      MetadataEditEvent.Publish(args);

      // Now subscribe to events
      MetadataEditEvent.Subscribe(OnMetadataEvent);
      ProjectClosingEvent.Subscribe(OnProjectClosing);
      ProjectCloseCanceledEvent.Subscribe(OnProjectCloseCanceled);

      // Put it onto the undo stack
      _originalMetadata = metadataXML;
      _currentMetadata = metadataXML;
    }

    #region Events

    internal void Metadata_NodeChanged(object sender, XmlNodeChangedEventArgs e)
    {
      if (!_bIsLoadingPage)
      {
        // Do not dirty metaData when expanding/collapsing expanders.
        if (e!= null && e.NewParent != null && (e.NewParent is XmlAttribute))
        {
          if ((e.NewParent as XmlAttribute).Name == "editorExpand")
            return;
        }

        _bIsMetadataDirty = true;
        if (Utils.IsProjectItem(Item))
          ArcGIS.Desktop.Core.Project.Current.SetDirty();
      }
    }

    internal void OnUpdateThumbnail()
    {
      _bIsMetadataDirty = true;
      _bThumbnailUpdated = true;
    }

    private MessageBoxResult GetMessageBoxResult(MessageBoxButton msgBtn)
    {
      string nameOrPath = Path;
      string message = string.Format(Internal.Metadata.Properties.Resources.MSGBOX_SAVE_MSG, nameOrPath);
      string caption = Internal.Metadata.Properties.Resources.MSGBOX_SAVE_CAPTION;

      if (!string.IsNullOrEmpty(Item?.Path))
      {
        if (Utils.IsProjectItem(Item))
        {
          nameOrPath = Item.Name;
          message = string.Format(Internal.Metadata.Properties.Resources.MSGBOX_APPLY_MSG, nameOrPath);
        }
        else if (!string.IsNullOrEmpty(Item?.TypeID) && Item.TypeID.StartsWith("portal_"))
          message = string.Format(Internal.Metadata.Properties.Resources.MSGBOX_SAVE_MSG, Item.Name);
      }      

      return ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox(message, caption, msgBtn, MessageBoxImage.Question);
    }

    private void OnProjectCloseCanceled(ProjectEventArgs e)
    {
      _isProjectClosing = false;
    }

    private Task OnProjectClosing(ProjectClosingEventArgs e)
    {
      _isProjectClosing = true;

      if (!_bIsMetadataDirty)
      {
        // Force to fire NodeModified event if user didn't move user to another control
        CommitFocusedElements();

        // Check again
        if (!_bIsMetadataDirty)
          return Task.FromResult(0);
      }

      if (GetMessageBoxResult(MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        ArcGIS.Desktop.Internal.Models.Utilities.Util.NonAwaitCall(() => OnSave());

      return Task.FromResult(0);
    }

    public void OnClosed()
    {
      ProjectClosingEvent.Unsubscribe(OnProjectClosing);
      ProjectCloseCanceledEvent.Unsubscribe(OnProjectCloseCanceled);
      MetadataEditEvent.Unsubscribe(OnMetadataEvent);
    }

    public void OnClosing(Framework.Events.CancelRoutedEventArgs e)
    {
      if (_isProjectClosing) 
        return;

      // For performance reason, send our parent (MetadataDetailsViewModel) what we got
      var args = new MetadataEditEventArgs(MetadataEditEventAction.Close);
      args.Item = this.Item;
      args.TypeID = this.Item?.TypeID;
      args.Path = this.Item?.Path;
      args.Metadata = _currentMetadata; 

      // Now check whether it is dirty or not
      if (!_bIsMetadataDirty)
      {
        // Force to fire NodeModified event if user didn't move user to another control
        CommitFocusedElements();

        // Check again
        if (!_bIsMetadataDirty)
        {
          // Notify parent
          MetadataEditEvent.Publish(args);
          return;
        }
      }     

      MessageBoxResult result = GetMessageBoxResult(MessageBoxButton.YesNoCancel);
      if (result == MessageBoxResult.Yes)
      {
        // Save method back to data source
        ArcGIS.Desktop.Internal.Models.Utilities.Util.NonAwaitCall(() => OnSave());

        args.Metadata = SourceMetadata.InnerXml; 

        ProjectClosingEvent.Unsubscribe(OnProjectClosing);
        ProjectCloseCanceledEvent.Unsubscribe(OnProjectCloseCanceled);
      }
      else if (result == MessageBoxResult.Cancel)
        e.Cancel = true;

      // Notify parent
      MetadataEditEvent.Publish(args);
    }

    private void OnMetadataEvent(MetadataEditEventArgs args)
    {
      if (args.Action == MetadataEditEventAction.Reload && args.IsFromEditor && 
          !string.IsNullOrEmpty(args.Path) && args.Path.Equals(this.Item?.Path) && 
          args.Metadata != _currentMetadata)
      {
        if (args.Sender == MetadataEditEventArgs.SenderEnum.esriMDSenderEditor)
          return;

        ResetUI(args.Metadata);
      }

      // Test for the correct pane
      var pane = FrameworkApplication.Panes.ActivePane as MetadataEditPaneViewModel;
      if (pane?.EditorViewModel != this)
        //if (!(FrameworkApplication.Panes.ActivePane is MetadataEditPaneViewModel) || !_bIsActivePane)
        return; // this is not the pane you're looking for

      switch (args.Action)
      {
        case MetadataEditEventAction.CancelEdit:
          FrameworkApplication.State.Deactivate("esri_metadata_metadataEditing");
          FrameworkApplication.State.Deactivate("esri_metadata_metadataPane");
          FrameworkApplication.Panes.ActivePane.State.Deactivate("esri_metadata_metadataPane");
          MetadataEditEvent.Unsubscribe(OnMetadataEvent);
          this.Close();
          break;

        case MetadataEditEventAction.Save:
          ArcGIS.Desktop.Internal.Models.Utilities.Util.NonAwaitCall(() => OnSave());
          break;

        default:
          break;
      }
    }

    private async Task OnSave()
    {
      try
      {
        // Commit changes in UI to xml
        CommitXAMLChangesToMetadata();

        // Persist
        await SaveMetadataAsync(SourceMetadata.InnerXml);
        _bIsMetadataDirty = false;

        if (_bThumbnailUpdated)
        {
          _bThumbnailUpdated = false;

          var args = new ThumbnailUpdatedEventArgs(true);
          ThumbnailUpdatedEvent.Publish(args);
        }

        _originalMetadata = _currentMetadata;
        _currentMetadata = SourceMetadata.InnerXml;

        // Refresh the metadata view
        var argsEdit = new MetadataEditEventArgs(MetadataEditEventAction.Reload);
        argsEdit.Path = this.Path;
        argsEdit.Metadata = _currentMetadata;
        argsEdit.IsFromEditor = true;
        argsEdit.Sender = MetadataEditEventArgs.SenderEnum.esriMDSenderEditor; 

        MetadataEditEvent.Publish(argsEdit);

        SaveMetadataOperation op = new SaveMetadataOperation(ArcGIS.Desktop.Core.Project.Current.GetID(), this);
        await OperationManager.DoAsync(op);
      }
      catch
      {
        // NOOP
      }
    }

    private static IItemInfoService _itemInfoService = null;
    private static IItemInfoService ItemInfoService
    {
      get
      {
        if (_itemInfoService == null)
          _itemInfoService = ServiceManager.Find<IItemInfoService>();

        return _itemInfoService;
      }
    }

    private void ResetUI(string xmlString)
    {
      SetXml(xmlString);

      SetupDataProvider();
      PreProcessMetadata(_workingSourceMetadata);

      // Now reload the page since data provider is reset
      LoadPage(_currentInterviewNode);

      _sourceMetadataProvider.XPath = "/";
      CurrentPage.DataContext = this._sourceMetadataProvider;
      CurrentPage.FillXml();
    }

    internal Task SaveMetadataAsync(string xmlString)
    {
      return ItemInfoHelper.PutMetadata((this.Item as IItemInternal).ItemInfoValue, xmlString);
    }

    internal Task CommitMetadataAsync(bool bRedo, string metadataXML)
    {
      if (bRedo)
      {
        ResetUI(metadataXML);
        _bIsMetadataDirty = true;
      }

      return Task.FromResult(0);     
    }

    internal Task CommitOriginalMetadataAsync(string metadtaXML)
    {
      ResetUI(metadtaXML);
      _bIsMetadataDirty = true;

      return Task.FromResult(0);     
    }

    #endregion 

    internal bool IsLoadingPage
    {
      get { return _bIsLoadingPage; }
      set { _bIsLoadingPage = value; }
    }

    public IInputElement LastToLoseFocus
    {
      get { return _lastToLoseFocus; }
      set { _lastToLoseFocus = value; }
    }

    public static FlowDirection FlowDirection { get; set; }

    public OperationManager OperationManager { get; set; }

    internal string CurrentMetadata { get { return _currentMetadata; } }

    internal string OriginalMetadata { get { return _originalMetadata; } }

    public string Path { get; set; }

    public Core.Item Item
    {
      get { return _item; }
      set { SetProperty(ref _item, value, () => Item);}
    }

    public EditorPage CurrentPage
    {
      get { return _currentPage; }
      private set { SetProperty(ref _currentPage, value, () => CurrentPage); }
    }

    public string SelectedItemDisplayType { get; set; }

    public static MetadataEditorViewModel Instance
    {
      get { return _instance; }
    }

    /// <summary>
    /// add a page to later call commit on
    /// </summary>
    /// <param name="page"></param>
    public void AddCommitPage(EditorPage page)
    {
      if (page != null)
       _richTextboxPages.Add(page.GetType().ToString());
    }

    /// <summary>
    /// clears all commit pages
    /// </summary>
    private void ClearCommitPages()
    {
      _richTextboxPages.Clear();
    }   

    /// <summary>
    /// initialize the control with an XML string
    /// 
    /// sets the _sourceMetadata member variable
    /// 
    /// </summary>
    /// <param name="xml"></param>
    private void SetXml(string xml)
    {
      // reset
      _sourceMetadata = null;
      _miniUpgradePerformed = false;
      XmlDocument document = null;

      // check and load the XML
      try
      {
        document = new XmlDocument();
        document.LoadXml(xml);
      }
      catch (Exception)
      {
        _editorErrors.IsNotMetadata = true;
        return;
      }

      XmlNode esriOutdatedNode = document.SelectSingleNode(Utils.GoodOutdatedEsriContent);
      XmlNode fgdcOutdatedNode = document.SelectSingleNode(Utils.GoodOutdatedFgdcContent);

      if (null != esriOutdatedNode) /* if there IS good ArcGIS content */
      {
        // IF the document has good ESRI tags, but from a previous release,
        // THEN perform an upgrade behind the scenes...
        XmlNode node = document.SelectSingleNode(Utils.ArcGISFormatTag);
        if (node == null)
        {
          XmlDocument result = UpgradeMetadata(document, MetadataEditorViewModel.FlowDirection);
          if (null != result)
          {
            document = result;
            _miniUpgradePerformed = true;
          }
        }
      }

      // set this as the source
      _sourceMetadata = document;
    }

    /// <summary>
    /// Update the data context for the front page
    /// </summary>
    public static void UpdateDataContext(DependencyObject dep)
    {
      var mec = Utils.GetMetadataEditorControl(dep);
      var mevm = Utils.GetMetadataEditorViewModel(dep);
      if (null != mec) /* paranoid */
      {
        mevm.CurrentPage.FillXml();
        mevm._sourceMetadataProvider.Refresh();

        // raise event, for controls that can't or don't responde to direct WPF XML Binding events
        // like the custom RichTextBox
        RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataXMLUpdatedEvent);
        mec.RaiseEvent(newEventArgs);
      }
    }

    public void RefreshDataContext()
    {
      _sourceMetadataProvider.Refresh();
    }

    /// <summary>
    /// Return the ArcGIS Profile Name as defined in the metadata style configuration document
    /// </summary>
    public string ArcGISProfile
    {
      get { return _profileName; }
    }

    /// <summary>
    /// Return the default metadata style
    /// </summary>
    public string DefaultMetadataStyle
    {
      get { return _defaultMetadataStyle; }
      set { SetProperty(ref _defaultMetadataStyle, value, () => DefaultMetadataStyle); }
    }

    /// <summary>
    /// Return TRUE if the metadata is upgraded
    /// </summary>
    public bool IsUpgraded
    {
      get { return _isUpgraded; }
    }

    private string _statusText;
    public string Status
    {
      get { return _statusText; }
      set
      {
        SetProperty(ref _statusText, value, () => Status);
      }
    }

    /// <summary>
    /// Updates the text in the status dock
    /// </summary>
    /// <param name="text"></param>
    public void UpdateStatus(string text)
    {
      Status = text;
    }

    /// <summary>
    /// Clears the text in the status dock
    /// </summary>
    internal void ClearStatus()
    {
      Status = string.Empty;
    }

    private void DisableAllButtons()
    {
      CanEdit = false;
      CanExport = false;
      CanValidate = false;
      CanUpgrade = false;
      CanPrint = false;
    }

    private bool _canEditButton;
    public bool CanEdit
    {
      get { return _canEditButton; }
      set
      {
        SetProperty(ref _canEditButton, value, () => CanEdit);
      }
    }

    private bool _canExport;
    public bool CanExport
    {
      get { return _canExport; }
      set
      {
        SetProperty(ref _canExport, value, () => CanExport);
      }
    }

    private bool _canValidate;
    public bool CanValidate
    {
      get { return _canValidate; }
      set
      {
        SetProperty(ref _canValidate, value, () => CanValidate);
      }
    }

    private bool _canUpgrade;
    public bool CanUpgrade
    {
      get { return _canUpgrade; }
      set
      {
        SetProperty(ref _canUpgrade, value, () => CanUpgrade);
      }
    }

    private bool _canPrint;
    public bool CanPrint
    {
      get { return _canPrint; }
      set
      {
        SetProperty(ref _canPrint, value, () => CanPrint);
      }
    }

    private bool _canImport;
    public bool CanImport
    {
      get { return _canImport; }
      set
      {
        SetProperty(ref _canImport, value, () => CanImport);
      }
    }

    /// <summary>
    /// Hide buttons that are not valid
    /// </summary>
    internal void UpdateButtons()
    {
      //if (null != _configDocumentError)
      //{
      //  DisableAllButtons();
      //  return;
      //}

      //bool hasDocument = (null != _sourceMetadata);

      ////
      //// test if a GP tool
      ////
      //if (hasDocument)
      //{
      //  XmlNode toolNode = _sourceMetadata.SelectSingleNode("/metadata/tool");
      //  _isGpTool = (null != toolNode);
      //}

      ////
      //// test if upgraded
      ////
      //double arcgisVersion = -1;
      //if (hasDocument)
      //{
      //  XmlNode node = _sourceMetadata.SelectSingleNode(Utils.ArcGISFormatTag);
      //  if (node != null)
      //  {
      //    string version = node.InnerText;
      //    try
      //    {
      //      arcgisVersion = double.Parse(version, culture_en);
      //    }
      //    catch (Exception) { /* NOOP */ }
      //  }
      //}
      //_isUpgraded = (1 <= arcgisVersion);

      ////
      //// has esri-iso
      ////
      //bool hasEsriIso = false;
      //if (hasDocument)
      //{
      //  XmlNode esriNode = _sourceMetadata.SelectSingleNode(_goodEsriContent);
      //  hasEsriIso = (null != esriNode);
      //}

      ////
      //// edit button
      ////
      //if (_isMetadata && hasDocument && (_forceEditable || _canEdit))
      //  CanEdit = true;
      //else
      //  CanEdit = false;

      //// using the rules for export
      //bool exportAndValidate = (_editorSource.CanUseTools && _editorSource.Gp.CanExport && _isMetadata && hasDocument &&
      //  _isUpgraded && !_hideTools && !_isGpTool);
   

      //// export button
      ////
      //// 1) calls synchronize, which need to be readable!
      //// 2) only for upgraded metadata, but an FGDC document has a translator and this would work...
      ////if (_editorSource.CanUseTools && _editorSource.Gp.CanExport && _isMetadata && hasDocument && _isUpgraded && !_hideTools && !_isGpTool)
      //if (exportAndValidate)
      //  CanExport = true;
      //else
      //  CanExport = false;

      ////
      //// validate button
      ////
      //// 1) calls export, which calls synchronize, which need to be readable!
      //// 2) needs to be upgraded because export is called see export 2)
      ////if (_editorSource.CanUseTools && _editorSource.Gp.CanValidate && !CanUpgrade() && _isMetadata && hasDocument && hasEsriIso /*IsUpgraded*/ && !_hideTools && !_isGpTool)
      //if (exportAndValidate)
      //  CanValidate = true;
      //else
      //  CanValidate = false;

      ////
      //// import button
      ////
      //if (_editorSource.CanUseTools && hasDocument && _canEdit && !_isGpTool)
      //  CanImport = true;
      //else
      //  CanImport = false;

      ////
      //// upgrade button
      //// - valid only for FGDC
      ////
      //if (_CanUpgrade())
      //  CanUpgrade = true;
      //else
      //  CanUpgrade = false;

      ////
      //// print button
      ////
      //if (hasDocument)
      //  CanPrint = true;
      //else
      //  CanPrint = false;

      ////
      //// validate page button
      ////
      ////if (_isPageValidating) 
      ////  validatePageButton.Visibility = Visibility.Visible;
      ////else
      ////  validatePageButton.Visibility = Visibility.Collapsed;
    }

    /// <summary>
    /// test if upgrading is possible
    /// </summary>
    /// <returns></returns>
    //private bool _CanUpgrade()
    //{
    //  bool hasDocument = (null != _sourceMetadata);
    //  bool hasFgdc = false;

    //  if (hasDocument)
    //  {
    //    XmlNode fgdcNode = _sourceMetadata.SelectSingleNode(_goodFgdcContent);
    //    hasFgdc = (null != fgdcNode);
    //  }

    //  /**
    //   * + can use tools
    //   * + is metadata
    //   * + not hiding tools
    //   * + is NOT a gp tool
    //   * + has document
    //   * + is NOT upgraded
    //   * + has good FGDC
    //   */
    //  return (_editorSource.CanUseTools && _isMetadata && !_hideTools &&
    //    !_isGpTool && hasDocument && !_isUpgraded && hasFgdc);
    //}

    /// <summary>
    /// upgrade the metadata document to the latest version
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private static XmlDocument UpgradeMetadata(XmlDocument source, FlowDirection flowDirection)
    {
      // Path to xslt file
      try
      {
        string xslt = Utils.InstallPath + @"\Resources\Metadata\Stylesheets\gpTools\upgrade ESRI-ISO to ArcGIS.xslt";

        if (!File.Exists(xslt))
          return null;

        XslCompiledTransform transform = new XslCompiledTransform();
        transform.Load(xslt);

        StringBuilder sb = new StringBuilder();

        XmlWriterSettings writerSettings = new XmlWriterSettings();
        writerSettings.Encoding = Encoding.UTF8;
        writerSettings.Indent = true;
        writerSettings.OmitXmlDeclaration = true;

        // setup extension objects
        XsltArgumentList xslArgs = new XsltArgumentList();
        xslArgs.AddExtensionObject("http://www.esri.com/metadata/", new XsltExtensionFunctions());
        xslArgs.AddExtensionObject("http://www.esri.com/metadata/res/", new XsltExtensionFunctions());
        xslArgs.AddParam("flowdirection", "", (FlowDirection.LeftToRight == flowDirection) ? "LTR" : "RTL");

        // transform
        transform.Transform(new XmlNodeReader(source), xslArgs, XmlWriter.Create(sb, writerSettings));

        // Add back xml declaration
        string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" + sb.ToString();

        // ok
        XmlDocument upgradedxml = new XmlDocument();
        upgradedxml.LoadXml(xml);
        return upgradedxml;
      }
      catch (Exception) { /* NOOP */ }

      return null;
    }

    ///// <summary>
    ///// updates the HTML view with the source document
    ///// </summary>
    //internal void UpdateStylesheet()
    //{
    //  // check if it's an HTML document
    //  if (null != _editorSource.HtmlFile && 0 < _editorSource.HtmlFile.Length) {
    //    webBrowser.Navigate(new Uri(_editorSource.HtmlFile));        
    //    return;
    //  }

    //  // check if there was a config error...
    //  if (_editorErrors.IsConfigError)
    //  {
    //    string html = Utils.NavigateToError(Properties.Resources.MSG_CONFIGFILE_ERROR, _editorErrors);
    //    NavToString(html);
    //    return;
    //  }

    //  // check if object supports metadata
    //  if (_editorErrors.IsNotMetadata)
    //  {
    //    string html = Utils.NavigateToError(Properties.Resources.MSG_UNSUPPORTED_OBJECT, _editorErrors);
    //    NavToString(html);
    //    return;
    //  }

    //  // check if object supports metadata
    //  if (_editorErrors.isMetadataMissing)
    //  {
    //    string html = Utils.NavigateToError(Properties.Resources.MSG_METADATA_MISSING, _editorErrors);
    //    NavToString(html);
    //    return;
    //  }

    //  // check if metadata is not supported
    //  if (_editorErrors.IsSourceXmlError)
    //  {
    //    string html = Utils.NavigateToError(Properties.Resources.MSG_BAD_SOURCE_XML, _editorErrors);
    //    NavToString(html);
    //    return;
    //  }

    //  // check if error in config document
    //  if (null != _configDocumentError)
    //  {
    //    string html = Utils.NavigateToError(Properties.Resources.MSG_BAD_CONFIGDOC, _editorErrors);
    //    NavToString(html);
    //    return;
    //  }

    //  // Style XML with ArcGIS Stylesheet
    //  string xslt = _viewerXsltFilename;

    //  // setup transform
    //  if (null == _cachedXslTransform || xslt != _lastXsltFilename)
    //  {
    //    _cachedXslTransform = new XslCompiledTransform();
    //  }

    //  // remember for caching
    //  _lastXsltFilename = _viewerXsltFilename;

    //  try
    //  {
    //    XmlDocument xsltDoc = new XmlDocument();
    //    xsltDoc.Load (xslt);

    //    // transform it
    //    _cachedXslTransform.Load(xsltDoc);
    //  }
    //  catch (Exception ex)
    //  {
    //    _editorErrors.Cause = ex;
    //    string html = Utils.NavigateToError(ArcGIS.Desktop.Metadata.Properties.Resources.MSG_XSLT_ERROR, _editorErrors);
    //    NavToString(html);
    //    return;
    //  }

    //  // check the source metadata xml
    //  if (null == _sourceMetadata || null == _sourceMetadata.InnerXml || 0 == _sourceMetadata.InnerXml.Length)
    //  {
    //    string html = Utils.NavigateToError(ArcGIS.Desktop.Metadata.Properties.Resources.MSG_BAD_SOURCE_XML, _editorErrors);
    //    NavToString(html);
    //    return;
    //  }

    //  // use the working source XML if getting images fails
    //  string imageXml = _sourceMetadata.InnerXml;

    //  // copy propertyset and get images
    //  try
    //  {
    //    // create copy
    //    IXmlPropertySet2 pXmlPropertySet2 = new XmlPropertySetClass();
    //    pXmlPropertySet2.SetXml(_sourceMetadata.InnerXml);

    //    // transform binary images
    //    string temppath = System.IO.Path.GetTempPath();
    //    object images;
    //    pXmlPropertySet2.TransformImages(temppath, out images);

    //    // set xml to use for viewing
    //    imageXml = pXmlPropertySet2.GetXml("/");
    //  }
    //  catch (Exception) { /* NOOP */ }

    //  // load into new document
    //  XmlDocument styleDoc = new XmlDocument();
    //  styleDoc.LoadXml(imageXml);

    //  // transform
    //  // add custom functions and transform
    //  XsltArgumentList xslArgs = new XsltArgumentList();
    //  xslArgs.AddExtensionObject("http://www.esri.com/metadata/", new XsltExtensionFunctions());
    //  xslArgs.AddExtensionObject("http://www.esri.com/metadata/res/", new XsltExtensionFunctions());
    //  xslArgs.AddParam("flowdirection", "", (FlowDirection.LeftToRight == this.FlowDirection) ? "LTR" : "RTL");

    //  try
    //  {

    //    //DateTime stamp1;
    //    //DateTime stamp2;
       
    //    XmlDocument targetDoc = new XmlDocument();
    //    using (XmlWriter xmlWriter = targetDoc.CreateNavigator().AppendChild())
    //    {           
    //      _cachedXslTransform.Transform(styleDoc.CreateNavigator(), xslArgs, xmlWriter);           
    //    }
        
    //    //stamp1 = System.DateTime.Now;

    //    // substitute resource strings    
    //    Utils.SubstituteXsltResourceStrings(targetDoc);

    //    //stamp2 = System.DateTime.Now;
       
    //    // show it
    //    NavToString(targetDoc.InnerXml);

    //    //DateTime stamp2 = System.DateTime.Now;
    //    //TextWriter tw = new StreamWriter(@"c:\temp\xsl-speed.txt", true);
    //    //TimeSpan duration = stamp2 - stamp1;
    //    //tw.WriteLine(duration);
    //    //tw.Close();
    //  }
    //  catch (Exception ex)
    //  {
    //    _editorErrors.Cause = ex;
    //    string html = Utils.NavigateToError(ArcGIS.Desktop.Metadata.Properties.Resources.MSG_XSLT_TRANSFORM_ERROR, _editorErrors);
    //    NavToString(html);
    //  }
    //}

    /// <summary>
    /// save HTML string to a temp file,
    /// then navigate to that temp file with the webbrowser
    /// </summary>
    /// <param name="html"></param>
    //private void NavToString(string html)
    //{
    //  try
    //  {
    //    // write to temp file
    //    string tempfile = System.IO.Path.GetTempFileName() + ".htm";
    //    StreamWriter sw = new StreamWriter(tempfile, false, Encoding.Unicode);
    //    // prepend mark-of-the-web
    //    sw.Write("<!-- saved from url=(0016)http://localhost -->\r\n");
    //    // write the document
    //    sw.Write(html);
    //    sw.Close();

    //    // navigate
    //    webBrowser.Navigate(new Uri(tempfile));
    //  }
    //  catch (Exception)
    //  {
    //    webBrowser.Navigate(new Uri("about:blank"));
    //  }
    //}

    /// <summary>
    /// record an error with either the XSLT and XML
    /// </summary>
    /// <param name="ex"></param>

    internal XmlDocument SourceMetadata
    {
      get { return _sourceMetadata; }
    }

    internal XmlDocument WorkingSourceMetadata
    {
      get { return _workingSourceMetadata; }
    }

    internal XmlDataProvider SourceMetadataProvider
    {
      get { return _sourceMetadataProvider; }
    }

    internal bool IsMiniUpgradePerformed
    {
      get { return _miniUpgradePerformed; }
    }

    internal bool IsFgdcContentCopied
    {
      get { return _fgdcContentCopied; }
    }

    internal XmlNode FirstPageNode
    {
      get { return _firstPageNode; }
    }

    internal XmlNode CurrentPageNode
    {
      get { return _currentInterviewNode; }
    }

    internal EditorError EditorErrors
    {
      get { return _editorErrors; }
    }

    public XmlDocument ConfigDocument
    {
      get
      {
        return _configDocument;
      }
      set
      {
        SetProperty(ref _configDocument, value, () => ConfigDocument); 
      }
    }

    /// <summary>
    /// setups the data context from the working metadata document,
    /// copies the source to the working,
    /// then sets the data provider from working
    /// </summary>
    ///     
    private void SetupDataProvider(XmlDocument document)
    {
      if (_currentInterviewNode != null)
      {
        try
        {
          _pageCache.Clear();
          CurrentPage = null;          
        }
        catch (Exception) { }
      }

      // Clear first
      if (_workingSourceMetadata != null)
        _workingSourceMetadata.NodeChanged -= Metadata_NodeChanged;

      // Copy source to working document
      _workingSourceMetadata = document;

      // Setup modification events
      _workingSourceMetadata.NodeChanged += Metadata_NodeChanged;

      // Set up data provider
      XmlDataProvider provider = new XmlDataProvider();
      provider.Document = _workingSourceMetadata;
      provider.XPath = "/";

      // Set member
      _sourceMetadataProvider = provider;
    }

    private void SetupDataProvider()
    {
      // copy source to working document
      XmlDocument document = _sourceMetadata.Clone() as XmlDocument;
      SetupDataProvider(document);
    }  

    /// <summary>
    /// return the current metadata profile in use
    /// </summary>
    public string MetadataProfile
    {
      get { return _profileName; }
    }

    public void ClickValidatePage(object sender, EventArgs e)
    {
      UpdateValidation(UpdateValiationModes.CommitPages);
    }

    public void UpdateValidation(UpdateValiationModes mode)
    {
      // commit pages like the rich text boxes
      if (UpdateValiationModes.NoCommit != mode)
        CommitPages();

      // update the entire sidebar (along with this page)
      UpdateSidebar();
    }

    /// <summary>
    /// track the position of controls on each page where an anchor name is set
    /// </summary>
    private Dictionary<string, FrameworkElement> _anchors = new Dictionary<string, FrameworkElement>();

    /// <summary>
    /// add a page "anchor"
    /// </summary>
    /// <param name="name"></param>
    /// <param name="fe"></param>
    public void AddAnchorName(string name, FrameworkElement fe)
    {
      _anchors[name] = fe;
    }

     // list of issues
    HashSet<MetadataValidationIssue> _issueList = new HashSet<MetadataValidationIssue>();

    public HashSet<MetadataValidationIssue> IssueList
    {
      get { return _issueList; }
    }

    public IEnumerable<MetadataValidationIssue> ErrorIssues
    {
      get
      {
        if (null == _currentPage)
          return _issueList;
        else
          return _issueList.Where(x => x.IsError && !x.IsChildError && !x.IsSupressMessage && x.PageClass.Equals(_currentPage.GetType().FullName.ToString()));
      }
    }

    private IEnumerable<MetadataValidationIssue> GetValidationMessages()
    {
      if (null == _currentPage)
        return _issueList;
      else
        return _issueList.Where(x => !x.IsError && x.PageClass.Equals(_currentPage.GetType().FullName.ToString()));
    }

    /// <summary>
    ///  Sets the @IsSelected attribute on each page node to "False".
    /// Creates the attribute if necessary
    /// </summary>          
    private static void ClearSelectedTOCItems(XmlDocument configDocument)
    {
      var pageNodes = configDocument.SelectNodes("//page");
      foreach (XmlNode pageNode in pageNodes)
      {
        if (null != pageNode)
        {
          if (null == pageNode.Attributes["IsSelected"])
          {
            pageNode.Attributes.SetNamedItem(configDocument.CreateAttribute("IsSelected"));
          }
          pageNode.Attributes["IsSelected"].Value = "False";
        }
      }
    }

    /// <summary>
    /// Load a page
    /// </summary>
    /// <param name="node"></param>
    internal void LoadPage(XmlNode node)
    {
      XmlNode classNode = node.Attributes["class"];
      if (null == classNode)
        throw new MetadataException("No class attribute found in page configuration element!");

      string pageClass = classNode.Value;
      if (null == pageClass || 0 == pageClass.Length)
        throw new MetadataException("Can't instantiate page: " + pageClass);

      // Hide previous page
      if (null != this.CurrentPage)
        this.CurrentPage.Visibility = Visibility.Hidden;

      EditorPage page = null;

      try
      {
        Type t = Utils.GetType(_currentMetadataStyle, pageClass);
        if (t != null)
        {
          if (_pageCache.ContainsKey(pageClass))
          {
            page = _pageCache[pageClass];
            page.Visibility = Visibility.Visible;
          }
          else
          {
            // clear anchors
            _anchors.Clear();

            // get an instance
            page = System.Activator.CreateInstance(t) as EditorPage;

            if (null == page)
              return;

            page.RootPage = true;

            // add to cache
            _pageCache.Add(pageClass, page);
          }
        }
        else
        {
          throw new MetadataException("Can't instantiate page: " + pageClass);
        }
      }
      catch (Exception ex)
      {
        throw new MetadataException("Can't create a page with type " + pageClass + "; " + ex.Message);
      }

      if (pageClass != _prevPageName)
        IsLoadingPage = true;  // NOTE: It is the responsibility of individual page to flip to to false (which is done in base class EditorPage)! 

      if (null != _sourceMetadataProvider)
      {
        // set xpath and data context for the page
        _sourceMetadataProvider.XPath = "/";
        page.DataContext = this._sourceMetadataProvider;
      }

      // set the current element
      _currentInterviewNode = node;

      // clear any commit pages
      ClearCommitPages();

      // show validation?
      XmlNode visNode = node.Attributes["validation"];
      if (!_isValidating || (null != visNode && "hide".Equals(visNode.Value, StringComparison.InvariantCultureIgnoreCase)))
        HasValidationMessages = false;
      else
        HasValidationMessages = true;

      bool bHasException = false;
      try
      {
        // set the current page, trigger binding
        this.CurrentPage = page;
      }
      catch (Exception)
      {
        bHasException = true;        
      }

      // Hack: try again if fails and this time it should succeed
      if (bHasException)
      {
        try
        {
          this.CurrentPage = null;
          this.CurrentPage = page;
        }
        catch (Exception) { }
      }

      _prevPageName = pageClass;
    }

    private bool _hasValidationMessages;
    public bool HasValidationMessages
    {
      get { return _hasValidationMessages; }
      set { SetProperty(ref _hasValidationMessages, value, () => HasValidationMessages); }
    }

    private bool _isValidating = false;
    private Core.Item _item;

    public bool IsValidating
    {
      get { return _isValidating; }
      set { SetProperty(ref _isValidating, value, () => IsValidating); }
    }
    
    /// <summary>
    /// Commits any databinding in the currently focused UI element
    /// 
    /// NOTE: doesn't work for fields where validation has failed.
    /// 
    /// See:
    /// http://stackoverflow.com/questions/222839/wpf-changes-to-textbox-with-focus-arent-committed-until-after-the-closing-event
    /// http://stackoverflow.com/questions/57493/wpf-databind-before-saving#58443
    /// 
    /// </summary>
    private void CommitFocusedElements()
    {
      try
      {
        // get previous element
        if (null != _lastToLoseFocus)
          CommitFocusedElement(_lastToLoseFocus);

        // get the current element with focus
        IInputElement x = System.Windows.Input.Keyboard.FocusedElement;
        if (null != x)
          CommitFocusedElement(x);
      }
      catch (Exception)
      {
      }
    }

    private void CommitFocusedElement(IInputElement x)
    {
      if (null == x)
        return;

      // http://stackoverflow.com/questions/57493/wpf-databind-before-saving#58443
      if (x is TextBox)
      {
        TextBox t = x as TextBox;
        BindingExpression bindingExp = t?.GetBindingExpression(TextBox.TextProperty);
        if ((t != null) && (bindingExp != null))
        {
          var tXmlElement = bindingExp.ResolvedSource;
          if (tXmlElement != null && tXmlElement is XmlElement)
          {
            string tText = (tXmlElement as XmlElement).InnerText;
            if (t.Text == tText)
              return;
            
            t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
          }
        }
      }
      else if (x is System.Windows.Controls.ComboBox)
      {
        var c = x as System.Windows.Controls.ComboBox;
        if ((c != null) && (c.GetBindingExpression(System.Windows.Controls.ComboBox.TextProperty) != null))
          c.GetBindingExpression(System.Windows.Controls.ComboBox.TextProperty).UpdateSource();
      }
      else if (x is System.Windows.Controls.RichTextBox)
      {
        var rtb = x as System.Windows.Controls.RichTextBox;
        rtb.MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next));
      }
    }
  
    public void UpdateSidebar()
    {
      if (_isValidating)
      {
        // clear the list
        _issueList.Clear();

        // update the issues from the XML profile configuration
        IList<MetadataValidationIssue> issues = UpdateIssues(_currentPage, _configDocument, _workingSourceMetadata);
        foreach (MetadataValidationIssue issue in issues)
        {
          if (!_issueList.Contains(issue))
            _issueList.Add(issue);
        }      
      }

      // clear the error flag on all controls that have anchors
      foreach (var anchorFe in _anchors.Values)
      {
        anchorFe.SetValue(MetadataRules.HasIssueProperty, false);
        RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataValidatePageEvent);
        anchorFe.RaiseEvent(newEventArgs);
      }

      // set the issue flag on all controls that have issues
      var allErrors = _issueList.Where(x => x.IsError);
      foreach (var issue in allErrors)
      {
        if (_anchors.ContainsKey(issue.AnchorName))
        {
          var fe = _anchors[issue.AnchorName];
          fe.SetValue(MetadataRules.HasIssueProperty, true);
        }
      }

      NotifyPropertyChanged(() => ErrorIssues);
    }  

    private void CommitPages()
    {
      foreach (string name in _richTextboxPages)
      {
        if (_pageCache.ContainsKey(name))
        {
          var page = _pageCache[name];
          page.CommitChanges();
        }
      }
    }

    internal void CommitXAMLChangesToMetadata()
    {
      // Commit the focused element data
      CommitFocusedElements();

      // Call a page's own commit function
      CommitPages();

      // clear status
      ClearStatus();

      // post process
      PostProcessMetadata(_workingSourceMetadata, _isGpTool, _fgdcContentCopied);

      // trim XML
      TrimXml(_workingSourceMetadata);

      // add ArcGISFormat tag if not there AND there is GOOD ArcGIS metadata  
      if (null == _workingSourceMetadata.SelectSingleNode(Utils.ArcGISFormatTag))
      {
        var goodEsriNodes = _workingSourceMetadata.SelectNodes(Utils.GoodOutdatedEsriContent);
        var reallyGoodEsriNodes = _workingSourceMetadata.SelectNodes(Utils.ReallyGoodEsriContent);
        bool isMoreGoodEsriNodes = reallyGoodEsriNodes.Count < goodEsriNodes.Count;

        if ((_fgdcContentCopied && isMoreGoodEsriNodes) || (!_fgdcContentCopied && 0 < goodEsriNodes.Count))
        {
          AddArcGISFormatTag(_workingSourceMetadata);

          //string message = Properties.Resources.MSGBOX_SAVEUPGRADE_MSG;
          //string caption = Properties.Resources.MSGBOX_SAVEUPGRADE_CAPTION;
          //MessageBoxButton button = MessageBoxButton.YesNo;
          //MessageBoxImage icon = MessageBoxImage.Warning;

          //// show dialog
          //MessageBoxResult result = ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox(message, caption, button, icon);
          //switch (result)
          //{
          //  case MessageBoxResult.Yes:
          //    // save it
          //    AddArcGISFormatTag(_workingSourceMetadata);
          //    break;
          //  case MessageBoxResult.No:
          //    // NOOP
          //    break;
          //}
        }
      }

      // clone working document to source version
      XmlDocument document = _workingSourceMetadata.Clone() as XmlDocument;
      _sourceMetadata = document;

      // remove DTD references
      RemoveDTD(_sourceMetadata);

      // --------------- KEEP ON EDITING -------------------

      // set xml and run pre-processing steps
      SetXml(_sourceMetadata.InnerXml);

      if (!EditorErrors.HasError)
      {
        // setup provider
        SetupDataProvider();

        // pre-process metadata
        PreProcessMetadata(_workingSourceMetadata);

        // Now reload the page since data provider is reset
        LoadPage(_currentInterviewNode);
      }

      // reset data context, on current page
      _sourceMetadataProvider.XPath = "/";
      CurrentPage.DataContext = this._sourceMetadataProvider;
      CurrentPage.FillXml();

      // set flag
      _bIsMetadataDirty = false;
    }

    /// <summary>
    /// add ArcGISFormat tag if not there AND there is GOOD ArcGIS metadata
    /// </summary>
    private static void AddArcGISFormatTag(XmlDocument document)
    {
      // add <Esri> node if necessary
      //
      XmlNode esriNode = document.SelectSingleNode("/metadata/Esri");
      if (null == esriNode)
      {
        esriNode = document.CreateElement("Esri");
        document.FirstChild.PrependChild(esriNode);
      }

      // add <ArcGISFormat> node
      //
      var arcGISFormatNode = document.CreateElement("ArcGISFormat");
      var txtNode = document.CreateTextNode(_formatVersion);
      esriNode.AppendChild(arcGISFormatNode);
      arcGISFormatNode.AppendChild(txtNode);
    }    

    /// <summary>
    /// Removes any DTD references in an XML document
    /// </summary>
    /// <param name="doc">XML Document</param>
    private static void RemoveDTD(XmlDocument doc)
    {
      // remove DTD reference
      foreach (XmlNode node in doc.ChildNodes)
      {
        if (XmlNodeType.DocumentType == node.NodeType)
        {
          doc.RemoveChild(node);
          break;
        }
      }

      // remove schema references
      XmlNode metadataEl = doc.SelectSingleNode("/metadata");
      if (null != metadataEl)
      {
        foreach (XmlAttribute attNode in metadataEl.Attributes)
        {
          if (("schemaLocation".Equals(attNode.LocalName) ||
            "noNamespaceSchemaLocation".Equals(attNode.LocalName)) &&
            "http://www.w3.org/2001/XMLSchema-instance".Equals(attNode.NamespaceURI))
          {
            metadataEl.Attributes.Remove(attNode);
            break; // just need either of those, not legal to have both, 
            // deleting two attributes in this loop will crash the iterator
          }
        }
      }
    }

    /// <summary>
    /// debugging helpers
    /// </summary>
    public void DebugXml()
    {
      DebugXml(null, null);
    }

    public void DebugXml(object sender, RoutedEventArgs e)
    {
      // Commit the focused element data
      CommitFocusedElements();

      // Call a page's own commit function
      // Doesn't work on subpages....!
      CommitPages();

      _workingSourceMetadata.Save(@"c:\temp\metadata-out.xml");
    }

    private static void PreProcessItemInfo(XmlDocument document, string isTitleEnabled)
    {
      /* keywords
          <metadata>	                
            <ESRI_ItemInformation>
              <title>item title</title>
              <description>item &lt;font face="Tahoma" size="4"&gt;&lt;font style="background-color: #ffd700"&gt;description&lt;/font&gt;&lt;font size="3"&gt;&lt;font style="background-color: #ffd700"&gt; &lt;/font&gt;can be &lt;/font&gt;&lt;font size="2"&gt;interesting&lt;/font&gt;&lt;/font&gt;</description>
              <tags>
                <tag>item tag1</tag>
                <tag>item tag 2</tag>
                <tag>item tag3</tag>
              </tags>
              <snippet>item summary</snippet>
              <accessinformation>item credits</accessinformation>
            </ESRI_ItemInformation>
       */
      // Add temporary node isTitleEnabled
      XmlNode infoNode = document.SelectSingleNode("//dataIdInfo");
      if (infoNode != null)
      {
        XmlNode newIsTitleEnabledNode = document.CreateElement("isTitleEnabled");
        XmlNode textIsTitleEnabledNode = document.CreateTextNode(isTitleEnabled);
        newIsTitleEnabledNode.AppendChild(textIsTitleEnabledNode);
        infoNode.AppendChild(newIsTitleEnabledNode);
      }

      // TO: tags/tag to tags/bag 
      XmlNode tagsNode = document.SelectSingleNode("//ESRI_ItemInformation/tags");
      if (null != tagsNode)
      {
        XmlNodeList tagNodes = tagsNode.SelectNodes("tag");

        IList<XmlNode> deleteNodes = new List<XmlNode>();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < tagNodes.Count; i++)
        {
          XmlNode tagNode = tagNodes[i];

          // build up text area keywords delimited by carriage return
          string tag = tagNode.InnerText;
          if (null != tag && 0 < tag.Trim().Length)
          {
            sb.Append(tag.Trim());
            sb.Append("\n");
          }

          // remove old node later...
          deleteNodes.Add(tagNode);
        }

        XmlNode newNode = document.CreateElement("bag");
        XmlNode textNode = document.CreateTextNode(sb.ToString());
        newNode.AppendChild(textNode);
        tagsNode.AppendChild(newNode);

        // remove nodes 
        foreach (XmlNode delNode in deleteNodes)
        {
          if (null != delNode.ParentNode)
          {
            delNode.ParentNode.RemoveChild(delNode);
          }
        }
      }
    }

    private static void PreProcessKeywords(XmlDocument document)
    {
      // keywords
      //
      //<descKeys KeyTypCd="002">
      //  <keyTyp>
      //    <KeyTypCd value="002" />
      //  </keyTyp>
      //  <keyword>Yellowstone National Park</keyword>
      //  <keyword>U.S.</keyword>
      //</descKeys>
      //
      //
      // TO: <themeKeywords>keyword1, keyword2, keyword3, ... </themeKeywords>
      //

      XmlNode dataIdInfoNode = document.SelectSingleNode("//dataIdInfo");
      if (null != dataIdInfoNode)
      {
        /*
        <!ELEMENT discKeys %Keywords;>
        <!ELEMENT otherKeys %Keywords;>
        <!ELEMENT placeKeys %Keywords;>                
        <!ELEMENT stratKeys %Keywords;>
        <!ELEMENT tempKeys %Keywords;>
        <!ELEMENT themeKeys %Keywords;>               
        <!ELEMENT searchKeys (keyword+)>
        */
        string[] newTags = { "searchKeys", "themeKeys", "placeKeys", "tempKeys", "discKeys", "stratKeys", "otherKeys", "productKeys", "subTopicCatKeys" };
        //string[] codeLookups = { "005", "002", "004", "001", "003" };
        IList<XmlNode> deleteNodes = new List<XmlNode>();

        for (int i = 0; i < newTags.Length; i++)
        {
          string delimiter = ("searchKeys".Equals(newTags[i])) ? ", " : "\n";
          string newTag = newTags[i];

          // grab all keywords
          XmlNodeList keywordTypeNodes = dataIdInfoNode.SelectNodes(newTags[i]);

          foreach (XmlNode keywordTypeNode in keywordTypeNodes)
          {
            XmlNodeList nodes = keywordTypeNode.SelectNodes("keyword");
            IList<string> keywords = new List<string>();
            XmlNode lastNode = null;

            if (0 < nodes.Count)
            {              
              foreach (XmlNode node in nodes)
              {
                // remove old node later...
                deleteNodes.Add(node);

                // add to keywords list
                string keyword = node.InnerText;
                keywords.Add(keyword);

                lastNode = node;
              }
            }

            if (null != lastNode) // if there were any keywords
            {
              // add new keyword container
              XmlNode newNode = document.CreateElement("bag");

              string[] karray = keywords.ToArray<string>();
              string keywordField = String.Join(delimiter, karray); // comma-separated list

              XmlNode textNode = document.CreateTextNode(keywordField);
              newNode.AppendChild(textNode);

              // add to keyword parent element
              lastNode.ParentNode.AppendChild(newNode);
            }
          }
        }

        // remove nodes 
        foreach (XmlNode delNode in deleteNodes)
        {
          if (null != delNode.ParentNode)
            delNode.ParentNode.RemoveChild(delNode);
        }
      }
    }

    internal struct TimeNodeStruct
    {
      public long ticks;
      public XmlNode node;
    };

    private static void PreProcessLineageProcessSteps(XmlDocument document)
    {
      var dataLineageNode = document.SelectSingleNode("//dqInfo/dataLineage");
      if (null == dataLineageNode)
        return;

      var prcStepNodes = document.SelectNodes("//dqInfo/dataLineage/prcStep[stepDateTm]");
      if (null == prcStepNodes || 0 == prcStepNodes.Count)
        return;

      var stepList = new List<TimeNodeStruct>();
      DateTime dt;

      foreach (XmlNode prcStepNode in prcStepNodes)
      {
        // get date and attempt to parse it
        var stepDateTm = prcStepNode.SelectSingleNode("stepDateTm").InnerText;        
        if (DateTime.TryParse(stepDateTm, culture_en, DateTimeStyles.None, out dt))
        {
          // array data
          var data = new TimeNodeStruct();
          data.ticks = dt.Ticks;
          data.node = prcStepNode;
          stepList.Add(data);
          // delete node
          prcStepNode.ParentNode.RemoveChild(prcStepNode);
        }
      }

      // sort the list based on ticks
      Comparison<TimeNodeStruct> mycomp = (x, y) => x.ticks.CompareTo(y.ticks);
      stepList.Sort(mycomp);

      // put back into XML in order
      foreach (var value in stepList)
      {
        dataLineageNode.AppendChild(value.node);
      }
    }

    private static void PreProcessProcessHistory(XmlDocument document)
    {
      XmlNodeList nodes = document.SelectNodes("/metadata/Esri/DataProperties/lineage/Process");

      foreach (XmlNode node in nodes)
      {
        XmlAttribute at = node.Attributes.GetNamedItem("Name") as XmlAttribute;
        if (null == at)
        {
          // add @Name attribute
          XmlAttribute nameAt = document.CreateAttribute("Name");
          node.Attributes.SetNamedItem(nameAt);
        }

        at = node.Attributes.GetNamedItem("ToolSource") as XmlAttribute;
        if (null == at)
        {
          // add @ToolSource attribute
          XmlAttribute toolSourceAt = document.CreateAttribute("ToolSource");
          node.Attributes.SetNamedItem(toolSourceAt);
        }

        at = node.Attributes.GetNamedItem("export") as XmlAttribute;
        if (null == at)
        {
          // add @ToolSource attribute
          XmlAttribute exportAt = document.CreateAttribute("export");
          node.Attributes.SetNamedItem(exportAt);
        }
      }
    }

    private static void PreProcessTool(XmlDocument document)
    {
      XmlNode absNode = document.SelectSingleNode("/metadata/dataIdInfo/idAbs");
      if (null != absNode && 0 < absNode.InnerText.Trim().Length)
      {
        // copy abstract data into the tool's summary, if it's not already there...
        XmlNode summaryNode = document.SelectSingleNode("/metadata/tool/summary");
        if (null == summaryNode)
        {
          XmlNode toolNode = document.SelectSingleNode("/metadata/tool");
          if (null != toolNode)
          {
            //return; // don't create it -- TODO maybe a bug

            // create summary and copy data from idAbs
            summaryNode = document.CreateElement("summary");
            summaryNode.InnerText = absNode.InnerText;
            toolNode.AppendChild(summaryNode);
          }
        }
        else
        {
          // only if nothing is in there...
          if (0 == summaryNode.InnerText.Trim().Length)
            summaryNode.InnerText = absNode.InnerText;
        }
      }

      // remove old <commandReference> and place inside <pythonReference> IF
      // <pythonReference> doesn't exist or is EMPTY
      XmlNodeList paramList = document.SelectNodes("//param");
      foreach (XmlNode paramNode in paramList)
      {
        // get commandReference
        XmlNode cmdrefNode = paramNode.SelectSingleNode("commandReference");
        if (null != cmdrefNode)
        {
          string cmdHtml = Utils.ConvertToolXML(cmdrefNode.InnerXml).Trim();
          if (0 < cmdHtml.Length)
          {
            // get python reference
            XmlNode prNode = paramNode.SelectSingleNode("pythonReference");
            if (null != prNode)
            {
              string data = HttpUtility.HtmlDecode(prNode.InnerText);
              data = Regex.Replace(data, @"<(.|\n)*?>", "").Trim();
              if (0 == data.Length)
              {
                // put the old command reference in here...
                prNode.InnerText = HttpUtility.HtmlEncode(cmdHtml);
              }
            }
            else
            {
              // create a pythonReference element
              prNode = document.CreateElement("pythonReference");
              paramNode.AppendChild(prNode);

              // put the old command reference in here...
              prNode.InnerText = HttpUtility.HtmlEncode(cmdHtml);
            }
          }
        }
      }
    }

    private static void PreProcessTopics(XmlDocument document)
    {
      // topic categories
      //
      // <TopicCatCd value="006" /> becomes <TopicCatCd_006 value="True" />
      //
      XmlNode dataIdInfoNode = document.SelectSingleNode("//dataIdInfo");
      if (null != dataIdInfoNode)
      {
        // create 'tpCatBag' node if necessary
        XmlNode tpCatBagNode = dataIdInfoNode.SelectSingleNode("tpCatBag");
        if (null == tpCatBagNode)
        {
          tpCatBagNode = document.CreateElement("tpCatBag");
          dataIdInfoNode.AppendChild(tpCatBagNode);
        }

        XmlNodeList nodes = dataIdInfoNode.SelectNodes("tpCat");
        IList<XmlNode> deleteNodes = new List<XmlNode>();
        foreach (XmlNode node in nodes)
        {
          // remove old node later...
          deleteNodes.Add(node);

          XmlNode topicCatCdNode = node.SelectSingleNode("TopicCatCd");
          if (null != topicCatCdNode)
          {
            XmlAttribute at = topicCatCdNode.Attributes.GetNamedItem("value") as XmlAttribute;
            if (null != at)
            {
              try
              {
                ushort value = System.Convert.ToUInt16(at.Value);
                if (0 < value)
                {
                  // create new local name
                  string newLocalName = topicCatCdNode.LocalName + '_' + at.Value;

                  // create new element
                  XmlNode newNode = topicCatCdNode.OwnerDocument.CreateElement(newLocalName);

                  // create new attribute
                  XmlAttribute newAt = topicCatCdNode.OwnerDocument.CreateAttribute("value");
                  newAt.Value = "True";

                  // append new attribute to new element
                  newNode.Attributes.Append(newAt);

                  // append new element to tpCat Bag
                  tpCatBagNode.AppendChild(newNode);
                }
              }
              catch (Exception) { /* NOOP */ }
            }
          }
        }

        // remove nodes 
        foreach (XmlNode delNode in deleteNodes)
        {
          if (null != delNode.ParentNode)
            delNode.ParentNode.RemoveChild(delNode);
        }
      }
    }

    /// <summary>
    /// Modify the incoming XML to support the Editor and Data Binding better
    /// </summary>
    private void PreProcessMetadata(XmlDocument document)
    {
      // apply default XML
      Utils.CopyElements(document, _defaultXml.FirstChild, true, false);

      // topics and keywords
      PreProcessTopics(document);
      PreProcessKeywords(document);

      if (_isGpTool)
        PreProcessTool(document);
       
      // item info
      string strIsTitleEnabled = (string.IsNullOrEmpty(this.Item?.TypeID) || !this.Item.TypeID.StartsWith("portal_")) ? "True" : "False";
      PreProcessItemInfo(document, strIsTitleEnabled);

      // processing history
      PreProcessProcessHistory(document);

      // lineage processing steps
      PreProcessLineageProcessSteps(document);
    }

    private static void PostProcessItemInfo(XmlDocument document)
    {
      /* keywords
<metadata>	                
  <ESRI_ItemInformation>
      <title>item title</title>
      <description>item &lt;font face="Tahoma" size="4"&gt;&lt;font style="background-color: #ffd700"&gt;description&lt;/font&gt;&lt;font size="3"&gt;&lt;font style="background-color: #ffd700"&gt; &lt;/font&gt;can be &lt;/font&gt;&lt;font size="2"&gt;interesting&lt;/font&gt;&lt;/font&gt;</description>
      <tags>
          <tag>item tag1</tag>
          <tag>item tag 2</tag>
          <tag>item tag3</tag>
      </tags>
      <snippet>item summary</snippet>
      <accessinformation>item credits</accessinformation>
  </ESRI_ItemInformation>
*/
      // Delete temporary IsTitleEnabled node
      XmlNode isTitleEnabledNode = document.SelectSingleNode("//dataIdInfo/isTitleEnabled");
      if (isTitleEnabledNode != null)
        isTitleEnabledNode.ParentNode.RemoveChild(isTitleEnabledNode);

      // TO: tags/bag to tags/tag
      XmlNode tagsNode = document.SelectSingleNode("//ESRI_ItemInformation/tags");
      if (null != tagsNode)
      {
        XmlNode bagNode = tagsNode.SelectSingleNode("bag");
        if (null != bagNode)
        {
          string text = bagNode.InnerText;
          string[] parts = text.Split('\n');
          for (int i = 0; i < parts.Length; i++)
          {
            string tag = parts[i].Trim();
            if (0 < tag.Length)
            {
              // create new tag node
              XmlNode tagNode = document.CreateElement("tag");
              tagNode.InnerText = tag;

              // add to parent
              tagsNode.AppendChild(tagNode);
            }
          }

          // remove node
          bagNode.ParentNode.RemoveChild(bagNode);
        }
      }
    }

    /// <summary>
    /// push ESRI content into FGDC
    /// </summary>
    private static void PostProcessFGDC(XmlDocument document)
    {
      // title
      XmlNode isoTitleNode = document.SelectSingleNode("/metadata/dataIdInfo/idCitation/resTitle");
      XmlNode fgdcTitleNode = document.SelectSingleNode("/metadata/idinfo/citation/citeinfo/title");
      if (null != isoTitleNode && null != fgdcTitleNode)
      {
        if (0 < isoTitleNode.InnerText.Length)
          fgdcTitleNode.InnerText = isoTitleNode.InnerText;
      }

      // abstract
      XmlNode isoAbstractNode = document.SelectSingleNode("/metadata/dataIdInfo/idAbs");
      XmlNode fgdcAbstractNode = document.SelectSingleNode("/metadata/idinfo/descript/abstract");
      if (null != isoAbstractNode && null != fgdcAbstractNode)
      {
        string html = isoAbstractNode.InnerText;
        string decoded = HttpUtility.HtmlDecode(html);
        string stripped = Regex.Replace(decoded, @"<(.|\n)*?>", String.Empty);

        if (0 < stripped.Length)
          fgdcAbstractNode.InnerText = stripped;
      }

      // purpose
      XmlNode isoPurposeNode = document.SelectSingleNode("/metadata/dataIdInfo/idPurp");
      XmlNode fgdcPurposeNode = document.SelectSingleNode("/metadata/idinfo/descript/purpose");
      if (null != isoPurposeNode && null != fgdcPurposeNode)
      {
        if (0 < isoPurposeNode.InnerText.Length)
          fgdcPurposeNode.InnerText = isoPurposeNode.InnerText;
      }

      // credit
      XmlNode isoCreditNode = document.SelectSingleNode("/metadata/dataIdInfo/idCredit");
      XmlNode fgdcCreditNode = document.SelectSingleNode("/metadata/idinfo/datacred");
      if (null != isoCreditNode && null != fgdcCreditNode)
      {
        if (0 < isoCreditNode.InnerText.Length)
          fgdcCreditNode.InnerText = isoCreditNode.InnerText;
      }  

      // keywords
      XmlNodeList isoKeys = document.SelectNodes("/metadata/dataIdInfo/themeKeys/bag");
      if (0 < isoKeys.Count)
      {
        // are there FGDC tags to put them into?
        XmlNodeList fgdcKeys = document.SelectNodes("/metadata/idinfo/keywords/theme[themekey]");
        if (0 < fgdcKeys.Count)
        {
          // blow away existing FGDC theme keyword
          // TODO: good idea?          
          
          // goto /keyword level
          XmlNode fgdcKeyword = document.SelectSingleNode("/metadata/idinfo/keywords");
          for (int i = 0; i <  fgdcKeyword.ChildNodes.Count; i++) 
          {
            if ("theme" == fgdcKeyword.ChildNodes[i].LocalName)
              fgdcKeyword.RemoveChild(fgdcKeyword.ChildNodes[i]);
          }
         
          // create new "theme" element
          XmlNode fgdcTheme = document.CreateElement("theme");
          fgdcTheme = fgdcKeyword.AppendChild(fgdcTheme);

          // add new child themekey elements
          foreach (XmlNode isoKey in isoKeys)
          {
            string bag = isoKey.InnerText;
            string[] keys = bag.Split('\n');
            foreach (string key in keys)
            {
              XmlNode newKey = document.CreateElement("themekey");
              newKey.InnerText = key.Trim();
              fgdcTheme.AppendChild(newKey);
            }
          }
        }
      }
    }

    private static void PostProcessKeywords(XmlDocument document)
    {
      // keywords
      //
      //<descKeys KeyTypCd="002">
      //  <keyTyp>
      //    <KeyTypCd value="002" />
      //  </keyTyp>
      //  <keyword>Yellowstone National Park</keyword>
      //  <keyword>U.S.</keyword>
      //</descKeys>
      //
      //
      // FROM: <themeKeywords>keyword1, keyword2, keyword3, ... </themeKeywords>
      //
      XmlNode dataIdInfoNode = document.SelectSingleNode("//dataIdInfo");
      if (null != dataIdInfoNode)
      {
        string[] newTags = { "searchKeys", "themeKeys", "placeKeys", "tempKeys", "discKeys", "stratKeys", "otherKeys", "productKeys", "subTopicCatKeys" };
        IList<XmlNode> deleteNodes = new List<XmlNode>();

        for (int i = 0; i < newTags.Length; i++)
        {         
          string delimiter = ("searchKeys".Equals(newTags[i])) ? "[,\n]" : "\n";

          // select themeKeywords, placeKeywords, etc...
          XmlNodeList nodes = dataIdInfoNode.SelectNodes(newTags[i] + "/bag");

          //IList<string> keywords = new List<string>();
          foreach (XmlNode node in nodes)
          {
            // remove the <bag> node at the end
            deleteNodes.Add(node);

            // create <keyword> tags based on splitting by line
            string keywordArea = node.InnerText;
            string[] keywords = Regex.Split(keywordArea, delimiter);

            foreach (string kw in keywords)
            {
              XmlNode keywordNode = document.CreateElement("keyword");
              keywordNode.InnerText = kw.Trim();
              node.ParentNode.AppendChild(keywordNode); // append
            }
          }
        }

        // remove nodes 
        foreach (XmlNode delNode in deleteNodes)
        {
          if (null != delNode.ParentNode)
            delNode.ParentNode.RemoveChild(delNode);
        }
      }
    }

    private static void PostProcessTool(XmlDocument document, bool isGpTool)
    {
      if (!isGpTool)
        return;

      // copy the tool's summary into the item's abstract (description)
      XmlNode summaryNode = document.SelectSingleNode("/metadata/tool/summary");
      if (null != summaryNode)
      {
        string data = summaryNode.InnerText;
        if (0 == data.Trim().Length)
          data = string.Empty;

        // put into idAbs
        XmlNode absNode = document.SelectSingleNode("/metadata/dataIdInfo[1]/idAbs");
        if (null != absNode)
        {
          absNode.InnerText = data;
        }
        else
        {          
          // TODO: this path not tested b/c the first page writes an idAbs
          XmlNode metadataNode = document.SelectSingleNode("/metadata");

          // look for dataIdInfo, create if necessary
          XmlNode dataIdNode = metadataNode.SelectSingleNode("dataIdInfo");
          if (null != dataIdNode)
          {
            dataIdNode = document.CreateElement("dataIdInfo");
            metadataNode.AppendChild(dataIdNode);

            // create idAbs node and store data
            absNode = document.CreateElement("idAbs");
            absNode.InnerText = data;
            dataIdNode.AppendChild(absNode);
          }
        }
      }
    }

    /// <summary>
    /// post process default tags
    /// </summary>
    /// <param name="document"></param>
    private static void PostProcessDefaultTags(XmlDocument document)
    {
      // <mdDateSt Sync="TRUE">20101122</mdDateSt>
      // <ModDate>20101122</ModDate>
      // <ModTime>14052000</ModTime>

      DateTime now = System.DateTime.Now;

      // metadata date stamp
      UpdateMetadataDateStamp(document);

      // mod date
      XmlNode node = document.SelectSingleNode("/metadata/Esri/ModDate");
      if (null != node)
        node.InnerText = now.ToString("yyyyMMdd");

      // mod time
      node = document.SelectSingleNode("/metadata/Esri/ModTime");
      if (null != node)
        node.InnerText = now.ToString("Hmmss00");
    }

    private static void UpdateMetadataDateStamp(XmlDocument document)
    {
      if (null != document)
      {
        XmlNode metadataDate = document.SelectSingleNode("/metadata/mdDateSt");
        if (null == metadataDate)
        {
          XmlNode rootNode = document.SelectSingleNode("//metadata");
          if (null != rootNode)
          {
            metadataDate = document.CreateElement("mdDateSt");
            rootNode.AppendChild(metadataDate);
          }
        }
        if (null != metadataDate)
        {
          var syncAtt = metadataDate.Attributes["Sync"];
          if (null == syncAtt)
          {
            syncAtt = document.CreateAttribute("Sync");
            syncAtt.Value = "TRUE";
            metadataDate.Attributes.Append(syncAtt);            
          }

          if (string.Equals("TRUE", syncAtt.Value, StringComparison.InvariantCultureIgnoreCase) || 
              string.IsNullOrEmpty(metadataDate.InnerText))
          {
            metadataDate.InnerText = DateTime.Now.ToString("yyyyMMdd");
          }
        }
      }
    }


    private static void PostProcessTopics(XmlDocument document)
    {
      // topic categories
      //
      // <TopicCatCd_006 value="True" /> becomes <TopicCatCd value="006" /> 
      //
      XmlNode dataIdInfoNode = document.SelectSingleNode("//dataIdInfo");
      if (null != dataIdInfoNode)
      {
        XmlNode tpCatBagNode = dataIdInfoNode.SelectSingleNode("tpCatBag");
        if (null != tpCatBagNode)
        {
          XmlNodeList nodes = tpCatBagNode.SelectNodes("*");
          IList<XmlNode> deleteNodes = new List<XmlNode>();
          foreach (XmlNode node in nodes)
          {
            XmlAttribute at = node.Attributes.GetNamedItem("value") as XmlAttribute;
            if ("True".Equals(at.Value))
            {
              // split localname
              string localName = node.LocalName;
              string[] parts = localName.Split('_');
              if (2 == parts.Length)
              {
                // create new element
                XmlNode newNode = node.OwnerDocument.CreateElement("TopicCatCd");

                // create new attribute
                XmlAttribute newAt = node.OwnerDocument.CreateAttribute("value");
                newAt.Value = parts[1];

                // append new attribute to new element
                newNode.Attributes.Append(newAt);

                // create new tpCat element                               
                XmlNode newTpCatNode = node.OwnerDocument.CreateElement("tpCat");
                newTpCatNode.AppendChild(newNode);

                // append new element to document
                dataIdInfoNode.AppendChild(newTpCatNode);

                // remove old node
                //deleteNodes.Add(node.ParentNode);
              }
            }
            else { /* NOOP */ }
          }

          // remove the bag node
          tpCatBagNode.ParentNode.RemoveChild(tpCatBagNode);
        }
      }
    }

    /// <summary>
    /// Modify the outgoing XML (workingSource metadata)
    /// </summary>
    private static void PostProcessMetadata(XmlDocument document, bool isGpTool, bool fgdcContentCopied)
    {
      // tools
      // - before FGDC b/c data is copied between esri tags for tools
      PostProcessTool(document, isGpTool);

      // push to FGDC
      if (fgdcContentCopied)
        PostProcessFGDC(document);

      // keywords & topics
      PostProcessTopics(document);
      PostProcessKeywords(document);

      // item info
      PostProcessItemInfo(document);

      // default tags
      PostProcessDefaultTags(document);
    }

    /// <summary>
    /// trims an XML document of empty elements
    /// </summary>
    /// <param name="node"></param>
    /// <returns>true if element was removed</returns>
    private static bool TrimXmlInsideOut(XmlNode node, IList<XmlNode> deleteNodes)
    {
      // check nested elements first -- go deep first
      bool anySaved = false;
      bool anyText = false;

      foreach (XmlNode child in node.ChildNodes)
      {
        // any text in an element will SAVE it
        if (!anyText && XmlNodeType.Text == child.NodeType && 0 < child.Value.Length)
          anyText = true;

        // OR this value from all children
        if (XmlNodeType.Element == child.NodeType)
          anySaved |= TrimXmlInsideOut(child, deleteNodes);      
      }

      // trim attributes
      bool saveAtt = false;

      // test attributes - elements only
      if (0 < node.Attributes.Count)
      {
        // a list of attributes to be removed
        IList<XmlAttribute> removeAtts = new List<XmlAttribute>();

        foreach (XmlAttribute at in node.Attributes)
        {
          switch (at.LocalName)
          {
            // these attributes are used by the editor only
            // and should be removed...
            case "editorAppend":
            case "editorExpand":
            case "editorFillOnly":
            case "editorBoolIsString":
              removeAtts.Add(at);
              break;

            // check the value for anything interesting to save...
            default:
              if (null != at.Value && 0 < at.Value.Length)
                saveAtt = true;
              break;
          }
        }

        // remove attributes in the remove list...
        foreach (XmlAttribute at in removeAtts)
          node.Attributes.Remove(at);
      }

      // test flags
      if (anySaved || anyText || saveAtt)
        return true;

      // no elements or attributes with values
      deleteNodes.Add(node);

      // delete it
      return false; 
    }

    /// <summary>
    /// remove nodes that were added, but not filled out
    /// </summary>
    private static void TrimXml(XmlDocument document)
    {
      if (null == document)
        return;

      XmlNode firstEl = document.SelectSingleNode("/*");
      IList<XmlNode> deleteNodes = new List<XmlNode>();
      TrimXmlInsideOut(firstEl, deleteNodes);

      // delete the nodes that were returned
      foreach (XmlNode delNode in deleteNodes)
        delNode.ParentNode.RemoveChild(delNode);
    }

    /// <summary>
    /// update the valid flag for each page and return the list of top pages
    /// as a list of xml nodes
    /// </summary>
    /// <param name="configDoc"></param>
    /// <returns></returns>
    private static IList<MetadataValidationIssue> UpdateIssues(FrameworkElement fe, XmlDocument configDoc, XmlNode sourceNode)
    {
      IList<MetadataValidationIssue> issues = new List<MetadataValidationIssue>();

      foreach (XmlNode node in configDoc.SelectNodes("//editor/forms/section/page"))
      {
        //Utils.AppendLog("Validating page " + node.Attributes["class"].Value + " ...");

        // add 'valid' attribute if not already present
        if (null == node.Attributes["valid"]) {
          XmlAttribute at = configDoc.CreateAttribute("valid");
          at.Value = String.Empty;
          node.Attributes.Append(at);
        }

        // validate
        MetadataStyleValidation.ValidatePage(fe, node, sourceNode, issues);
      }

      // return list of issues
      return issues;
    }

    /// <summary>
    /// Retrieve the current metadata "style" configuration
    /// from the registry and store the editor TOC
    /// </summary>
    private void ReadCurrentConfiguration()
    {
      // create a new configuration document
      _profileName = null;

      // get current style
      _currentMetadataStyle = DefaultMetadataStyle;   

      // get config document
      ConfigDocument = Utils.GetConfigDocument(_currentMetadataStyle);    
    
      // get is validating and set property
      var validatingNode = ConfigDocument.SelectSingleNode(_profileIsValidatingPath) as XmlAttribute;
      if (null != validatingNode && 0 < validatingNode.Value.Length)
        IsValidating = "true".Equals(validatingNode.Value, StringComparison.InvariantCultureIgnoreCase);
      else 
        IsValidating = false;

      HasValidationMessages = _isValidating ? true : false;

      // get the profile name
      var profileNameNode = ConfigDocument.SelectSingleNode(_profileNameXPath) as XmlAttribute;
      if (null != profileNameNode && 0 < profileNameNode.Value.Length)
        _profileName = profileNameNode.Value;

      //// clear selected state
      ClearSelectedTOCItems(_configDocument);

      // assign the first page
      _firstPageNode = ConfigDocument.SelectSingleNode("//page");
      if (null != _firstPageNode)
        _firstPageNode.Attributes["IsSelected"].Value = "True";

      //// get the stylesheet
      //XmlNode viewerNode = _configDocument.SelectSingleNode("//viewerXslt");
      //if (null != viewerNode && 0 < viewerNode.InnerText.Length)
      //{
      //  string viewStr = viewerNode.InnerText;
      //  Uri uri = null;
      //  if (Uri.TryCreate(viewStr, UriKind.Absolute, out uri))
      //    _viewerXsltFilename = viewStr;
      //  else
      //    _viewerXsltFilename = Utils.InstallPath + @"\" + viewStr;
      //}
      //else
      //  _viewerXsltFilename = Utils.InstallPath + @"\Metadata\Stylesheets\ArcGIS.xsl";      

      //// is the sidebar visible
      //XmlNode editorNode = _configDocument.SelectSingleNode("//editor/@hideSidebar");
      //_hideSidebar = false;
      //if (null != editorNode)
      //{
      //  _hideSidebar = ("true".Equals(editorNode.Value.ToLower()));
      //}

      //// are the tools visible
      //XmlNode hideToolsNode = _configDocument.SelectSingleNode("//editor/@hideTools");
      //_hideTools = false;
      //if (null != hideToolsNode)
      //{
      //  _hideTools = ("true".Equals(hideToolsNode.Value.ToLower()));
      //}

      //// get the translator
      //XmlNode translatorNode = _configDocument.SelectSingleNode("//translator");
      //if (null != translatorNode && 0 < translatorNode.InnerText.Length)
      //{
      //  string translatorFilename = Utils.InstallPath + @"\" + translatorNode.InnerText;
      //  _editorSource.Gp.Translator = translatorFilename;
      //}

      //// get the schema URL
      //XmlNode validationSchemaURLNode = _configDocument.SelectSingleNode("//validationSchemaURL");
      //if (null != validationSchemaURLNode && 0 < validationSchemaURLNode.InnerText.Length)
      //{
      //  string validationSchemaURL = validationSchemaURLNode.InnerText;
      //  _editorSource.Gp.SchemaURL = validationSchemaURL;
      //}

      //// get the schema URL
      //XmlNode validationSchemaNSNode = _configDocument.SelectSingleNode("//validationNamespaceURI");
      //if (null != validationSchemaNSNode && 0 < validationSchemaNSNode.InnerText.Length)
      //{
      //  string validationSchemaNS = validationSchemaNSNode.InnerText;
      //  _editorSource.Gp.SchemaNamespace = validationSchemaNS;
      //}
    }

    public void Close()
    {
    }

    private void SetNewXml(string xmlString)
    {
      // use this xml
      SetXml(xmlString);

      //// test state and update tool buttons
      //UpdateButtons();

      //// udpate stylesheets
      //UpdateStylesheet();

      //// prompt to upgrade if possible
      //if (_CanUpgrade() && Utils.AllowUpgradeNotification && (!PROFILE_ITEM_DESCRIPTION.Equals(_profileName)))
      //  PromptUpgrade();
    }

    /// <summary>
    /// prompt the user to upgrade metadata
    /// </summary>
    //private void PromptUpgrade()
    //{

    //  UpgradeDialogBox upgradeBox = new UpgradeDialogBox();
    //  upgradeBox.SupressUpgradeDialog.IsChecked = false;
    //  // http://manfredlange.blogspot.com/2009/04/getting-parent-window-for-usercontrol.html
    //  new WindowInteropHelper(upgradeBox).Owner = new IntPtr(this.ParentHwnd);

    //  Point topLeft = this.PointToScreen(new Point(0, 0));
    //  Point bottomRight = this.PointToScreen(new Point(this.ActualWidth, this.ActualHeight));
    //  double width = bottomRight.X - topLeft.X;
    //  double height = bottomRight.Y - topLeft.Y;

    //  if (0 == width && 0 == height)
    //  {
    //    upgradeBox.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    //  }
    //  else
    //  {
    //    upgradeBox.Top = topLeft.Y + (height - 300) / 2;
    //    upgradeBox.Left = topLeft.X + (width - 400) / 2;
    //  }

    //  upgradeBox.ShowDialog();

    //  // show dialog
    //  switch (upgradeBox.DialogResult)
    //  {
    //    case true:
    //      // update registry
    //      if (true == upgradeBox.SupressUpgradeDialog.IsChecked)
    //        Utils.SetUpgradeNotificationKey(false);

    //      // upgrade metadata
    //      Upgrade(GpActions.UPGRADE_TYPE_FGDC_TO_ARCGIS);

    //      // ignore checkbox to supress future messages
    //      break;
    //    case false:
    //      // update registry
    //      if (true == upgradeBox.SupressUpgradeDialog.IsChecked)
    //        Utils.SetUpgradeNotificationKey(false);
    //      break;
    //  }
    //}
  } 

  /// <summary>
  /// Class to encapsulate various errors that can occur with the editor
  /// </summary>
  internal class EditorError
  {
    public bool IsConfigError = false;
    public bool IsSourceXmlError = false;
    public bool IsNotMetadata = false;
    public bool isUnknownError = false;
    public bool isMetadataMissing = false;

    public Exception Cause = null;

    public bool HasError
    {
      get { return IsConfigError || IsSourceXmlError || IsNotMetadata || isUnknownError || isMetadataMissing; }
    }
  }
}
