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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
using System.Xml.Xsl;

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Core.Internal.Threading.Tasks;
using ArcGIS.Desktop.Internal.Metadata;
using ArcGIS.Desktop.Internal.Core;
using ArcGIS.Desktop.Internal.Core.Events;
using ESRI.ArcGIS.ItemIndex;
using ArcGIS.Desktop.Internal.Metadata.Events;

namespace ArcGIS.Desktop.Metadata
{
  /// <summary>
  /// Interaction logic for MetadataDetailsView.xaml
  /// </summary>
  internal partial class MetadataDetailsView : UserControl, IDisposable
  {
    private bool _bIsStopped = false;
    private bool _bFromBrowser = false;
    private bool _lastObjectMDEditable = false;
    private string _lastPath = string.Empty;
    private string _currentCatalogPath = string.Empty;
    private string _currentTypeID = string.Empty;
    private List<string> _tempFiles = new List<string>();
    private WebBrowser _webBrowser = null;
    private bool _launchNewBrowerWindow = true;
    private CancelableProgressorSource _cbs = null;
    private Task _task = null;
    private static ItemInfoValue _lastIIV = new ItemInfoValue();

    public MetadataDetailsView()
    {
      InitializeComponent();
      //this.IsVisibleChanged += OnVisibleChanged;
      MetadataEditEvent.Subscribe(OnMetadataUpdated);
      ThumbnailUpdatedEvent.Subscribe(OnThumbnailUpdatedEvent);
    }

    ~MetadataDetailsView()
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
        foreach (string filePath in _tempFiles)
          File.Delete(filePath);

        MetadataEditEvent.Unsubscribe(OnMetadataUpdated);
        ThumbnailUpdatedEvent.Unsubscribe(OnThumbnailUpdatedEvent);

        _disposed = true;
      }
    }

    protected void OnVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      bool newVal = e.NewValue.ToString().Equals("true", StringComparison.CurrentCultureIgnoreCase);
      if (newVal && !string.IsNullOrEmpty(_lastPath))
      {
        if (_lastObjectMDEditable)
          FrameworkApplication.State.Activate("esri_metadata_canEditMetadata");
        else
          FrameworkApplication.State.Deactivate("esri_metadata_canEditMetadata");
      }
      else       
        FrameworkApplication.State.Deactivate("esri_metadata_canEditMetadata");
    }

    public bool Synchronize { get; set; }

    public void CancelBrowsing(string catalogPath, string typeID)
    {
      if (!string.IsNullOrEmpty(catalogPath) && catalogPath.Equals(_currentCatalogPath, StringComparison.CurrentCultureIgnoreCase) && 
          !string.IsNullOrEmpty(typeID) && typeID.Equals(_currentTypeID, StringComparison.CurrentCultureIgnoreCase))
        _bIsStopped = true;

      if (_webBrowser != null)
        this.InternalNavigate(new Uri(@"about:blank"));
    }

    public void PrepareBrowsing()
    {
      _bIsStopped = false;
    }

    public void Navigate(string path, ItemInfoValue iiv)
    {
      Navigate(_webBrowser, iiv);

      if (_webBrowser != null)
      {
        _bFromBrowser = false;
        _lastPath = path;
      }
    }
   
    private void WebBrowser_DocumentCompleted(object sender, NavigationEventArgs e)
    {
      if (_bIsStopped)
        return;

      var webBrowser = sender as WebBrowser;

      mshtml.HTMLDocument doc = (mshtml.HTMLDocument)webBrowser.Document;
      if (null == doc)
        return;

      try
      {
        // Assign background color
        var brush = FindResource("Esri_Gray100");
        if (brush is SolidColorBrush)
        {
          var mybrush = brush as SolidColorBrush;
          doc.bgColor = ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(mybrush.Color.R, mybrush.Color.G, mybrush.Color.B));
        }
      }
      catch (Exception)
      {
      }

      mshtml.HTMLDocumentEvents2_Event docEvents = ((mshtml.HTMLDocumentEvents2_Event) doc);
      ////docEvents.onmouseover += new mshtml.HTMLDocumentEvents2_onmouseoverEventHandler(OnDocumentMouseOver);
      ////docEvents.onmouseout += new mshtml.HTMLDocumentEvents2_onmouseoutEventHandler(OnDocumentMouseOut);
    }

    //private void OnDocumentMouseOut(mshtml.IHTMLEventObj e)
    //{
    //  MouseEventArgs args = new MouseEventArgs(Mouse.PrimaryDevice, 0);
    //  args.RoutedEvent = UserControl.MouseLeaveEvent;
    //  args.Source = this;
    //  RaiseEvent(args);
    //}

    //private void OnDocumentMouseOver(mshtml.IHTMLEventObj e)
    //{
    //  MouseEventArgs args = new MouseEventArgs(Mouse.PrimaryDevice, 0);
    //  args.RoutedEvent = UserControl.MouseEnterEvent;
    //  args.Source = this;
    //  RaiseEvent(args);      
    //}

    private void WebBrowser_Loaded(object sender, RoutedEventArgs e)
    {
      var webBrowser = sender as WebBrowser;
      _webBrowser = webBrowser;

      var mdvm = webBrowser.DataContext as MetadataDetailsViewModel;
      if (!_bFromBrowser && null != mdvm && null != _lastPath && _lastPath.Equals(mdvm.Path, StringComparison.CurrentCultureIgnoreCase))
        return; // We are just browsed from outside!

      _bFromBrowser = true;

      if (null != mdvm)
        Navigate(_webBrowser, (mdvm.Item as IItemInternal).ItemInfoValue);
    }

    private void OnMetadataUpdated(MetadataEditEventArgs args)
    {
      if (_webBrowser == null || args.Action != MetadataEditEventAction.Reload)
        return;

      var mdvm = _webBrowser.DataContext as MetadataDetailsViewModel;
      if (null == mdvm)
        return;

      if (args.Action != MetadataEditEventAction.Reload && !args.IsFromEditor)
        mdvm.Reset();

      Navigate(_webBrowser, (mdvm.Item as IItemInternal).ItemInfoValue, true);
    }

    private void OnThumbnailUpdatedEvent(ThumbnailUpdatedEventArgs args)
    {
      if (args.FromMetadataEditor)
        return;

      if (_webBrowser == null)
        return;

      var mdvm = _webBrowser.DataContext as MetadataDetailsViewModel;
      if (null == mdvm)
        return;

      mdvm.Reset();
      Navigate(_webBrowser, (mdvm.Item as IItemInternal).ItemInfoValue);
    }

    private bool IsSDE(string typeID)
    {
      if (string.IsNullOrEmpty(typeID))
        return false;
      else
        return (typeID.Contains("egdb_") || typeID.Contains("_egdb"));
    }
        
    private async void Navigate(WebBrowser webBrowser, ItemInfoValue iiv, bool bRefresh = false)
    {
      if (webBrowser == null || _bIsStopped)
        return;

      // Check whether same thing has been called multiple times: DelayedInvoker doesn't work well at the case when you double click a container like a folder
      if (!bRefresh && iiv.catalogPath == _lastIIV.catalogPath && iiv.typeID == _lastIIV.typeID)
        return;

      _lastIIV = iiv;

      // hide until ready to show...
      webBrowser.Visibility = System.Windows.Visibility.Collapsed;

      if (null != webBrowser)
      {
        var mdvm = webBrowser.DataContext as MetadataDetailsViewModel;
        if (null == mdvm)
          return; // we're done here

        _currentCatalogPath = iiv.catalogPath;
        _currentTypeID = iiv.typeID;
        _lastObjectMDEditable = false;

        mdvm.FlowDirection = this.FlowDirection;
        mdvm.Synchronize = this.Synchronize;

        // content returned from async method
        string html = null; 
        bool bSuccessful = false;
        bool bCanEditMetadata = false;
        bool bIsReturnFromEditing = mdvm.IsReturnFromEditing();

        _lastObjectMDEditable = bIsReturnFromEditing;

        try
        {
          if (_cbs != null && _task != null)
          {
            _cbs.CancellationTokenSource.Cancel();
            await _task;
          }
        }
        catch (TaskCanceledException ex)
        {
          System.Diagnostics.Debug.WriteLine(ex.Message);
        }

        _cbs = new CancelableProgressorSource();

        if (IsSDE(iiv.typeID))
        {
          _task = QueuedTask.Run(() => 
          {
            if (_bIsStopped || (_cbs?.CancellationTokenSource?.IsCancellationRequested ?? false))
              return;

            try
            {
              html = mdvm.GetHtml(ref bSuccessful);
              if (_bIsStopped || (_cbs?.CancellationTokenSource?.IsCancellationRequested ?? false))
                return;

              if (bSuccessful && !bIsReturnFromEditing && !string.IsNullOrEmpty(html))
              {
                bCanEditMetadata = ItemInfoHelper.GetCanEditMetadata(iiv);

                _lastObjectMDEditable = bCanEditMetadata;
                _lastPath = iiv.catalogPath;
              }
            }
            catch (Exception ex)
            {
              System.Diagnostics.Debug.WriteLine(ex.Message);
            }
          }, _cbs.Progressor);
        }
        else
        {
          _task = BackgroundTask.Run(TaskPriority.single, () =>
          {
            if (_bIsStopped || (_cbs?.CancellationTokenSource?.IsCancellationRequested ?? false))
              return;

            try
            {
              html = mdvm.GetHtml(ref bSuccessful);
              if (_bIsStopped || (_cbs?.CancellationTokenSource?.IsCancellationRequested ?? false))
                return;

              if (bSuccessful && !bIsReturnFromEditing && !string.IsNullOrEmpty(html))
              {
                bCanEditMetadata = ItemInfoHelper.GetCanEditMetadata(iiv);

                _lastObjectMDEditable = bCanEditMetadata;
                _lastPath = iiv.catalogPath;
              }
            }
            catch (Exception ex)
            {
              System.Diagnostics.Debug.WriteLine(ex.Message);
            }
          }, BackgroundProgressor.None);
        }
          
        await _task.ContinueWith((t) =>
        {
          if (t.IsCanceled || _bIsStopped)
            return;

          if (!string.IsNullOrWhiteSpace(html))
          {
            // show web browser
            webBrowser.Visibility = System.Windows.Visibility.Visible;

            // set the HTML in the web browser
            NavToString(webBrowser, html);
          }

          // We are returned from saved editing on same item. No need to update Edit button
          if (bIsReturnFromEditing || _bIsStopped)
            return;

          // Enable the Edit button which is a Fire and forget
          if (bSuccessful)
          {
            if (this.IsVisible)
              FrameworkApplication.State.Activate("esri_metadata_hasMetadata");
            else
              FrameworkApplication.State.Deactivate("esri_metadata_hasMetadata");

            if (bCanEditMetadata && this.IsVisible)
              FrameworkApplication.State.Activate("esri_metadata_canEditMetadata");
            else
              FrameworkApplication.State.Deactivate("esri_metadata_canEditMetadata");
          }
          else
          {
            FrameworkApplication.State.Deactivate("esri_metadata_hasMetadata");
            FrameworkApplication.State.Deactivate("esri_metadata_canEditMetadata");
          }

        }, QueuedTask.UIScheduler); // NOTE: MUST BE ON THE UI THREAD HERE!

        _cbs = null;
        _task = null;
      }      
    }

    private void NavToString(WebBrowser webBrowser, string html)
    {
      try
      {
        // write to temp file
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

        //  navigate to HTML on the UI thread
        this.InternalNavigate(new Uri(tempfile));
      }
      catch (Exception)
      {
        this.InternalNavigate(new Uri(@"about:blank"));
      }
    }

    private void InternalNavigate(Uri uriSource)
    {
      // Do not launch new brower window
      try
      {
        _launchNewBrowerWindow = false;
        _webBrowser.Navigate(uriSource);
      }
      catch (Exception)
      {
      }
    }

    private void WebBrower_Navigating(object sender, NavigatingCancelEventArgs e)
    {
      if (_launchNewBrowerWindow)
      {
        if (e == null || e.Uri == null || null == _webBrowser.Source || string.Equals(e.Uri.AbsolutePath, _webBrowser.Source.AbsolutePath)) return;

        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
        e.Cancel = true;
      }
      else
        _launchNewBrowerWindow = true;
    }
  } 
}
