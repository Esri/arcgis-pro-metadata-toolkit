/*
COPYRIGHT 1995-2009 ESRI
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArcGIS.Desktop.Metadata.Editor.Validation;

namespace ArcGIS.Desktop.Metadata.Editor
{
  /// <summary>
  /// Interaction logic for MetadataEditorControl.xaml
  /// </summary>
  ///
  internal partial class MetadataEditorControl : UserControl
  {    
    //private MetadataEditorViewModel _mevm;
    //private List<ListBox> _sectionListBoxes = new List<ListBox>();

    public MetadataEditorControl()
    {
      InitializeComponent();

      // notified when user click outside window,
      // to save field values when they come
      // back asked: "Do you want to save?"
      this.LostKeyboardFocus += EditorLostKeyboardFocus;

      //// setup locale
      //// set flow direction
      //if (agsLocale.RightToLeftUI)
      //  this.FlowDirection = FlowDirection.RightToLeft;
      //else
      //  this.FlowDirection = FlowDirection.LeftToRight;

      // handlers for metadata issues
      AddHandler(MetadataRules.MetadataIssueEvent, new RoutedEventHandler(OnMetadataIssueFound));
      AddHandler(Nav.MetadataAnchorFoundEvent, new RoutedEventHandler(OnMetadataAnchorFound));
      AddHandler(MetadataRules.MetadataCheckRulesEvent, new RoutedEventHandler(OnMetadataCheckRulesEvent));

      // set the flow direction statically
      MetadataEditorViewModel.FlowDirection = this.FlowDirection;
    }

    private MetadataEditorViewModel ViewModel
    {
      get
      {
        return this.DataContext as MetadataEditorViewModel;
      }
    }

    /// <summary>
    /// keep track of the old focus, to handle it possibly later...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void EditorLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (ViewModel != null)
        ViewModel.LastToLoseFocus = e.OldFocus;
    }

    public void OnMetadataIssueFound(object sender, RoutedEventArgs e)
    {
      // get the issue
      MetadataValidationIssue issue = e.OriginalSource as MetadataValidationIssue;
      if (null == issue)
        return;

      // do nothing if this is a child issue
      if (issue.IsChildError)
      return;

    // add to collection

      // set page name first
      issue.PageClass = ViewModel.CurrentPage.GetType().FullName.ToString();

      if (!ViewModel.IssueList.Contains(issue))
        ViewModel.IssueList.Add(issue);
    }

    /// <summary>
    /// found an metadata element anchor in the XAML
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnMetadataAnchorFound(object sender, RoutedEventArgs e)
    {
      // get the issue
      var anchor = e.OriginalSource as MetadataAnchor;

      if (null == anchor.ExpandedAnchor)
        return; // nothing to do

      ViewModel.AddAnchorName(anchor.ExpandedAnchor, anchor.Source as FrameworkElement);
    }


    private void OnMetadataCheckRulesEvent(object sender, RoutedEventArgs e)
    {
      ViewModel.UpdateValidation(UpdateValiationModes.NoCommit);
    }

    //public void ClickPrint(object sender, EventArgs e)
    //{
    //  object obj = webBrowser.Document;
    //  if (obj is HTMLDocument)
    //  {
    //    HTMLDocument doc = webBrowser.Document as HTMLDocument;
    //    doc.execCommand("Print", true, null);
    //  }
    //}

    /// <summary>
    /// click [cancel]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ClickExit(object sender, EventArgs e)
    {
      DoCancel();
    }

    private void DoCancel()
    {
      // clear status
      ViewModel.ClearStatus();

      //tabControl.SelectedIndex = 0;
    }

    private void editorGrid_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
    {
      e.Handled = true;
    }

    /// <summary>
    /// click [validate]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //public void ClickValidate(object sender, EventArgs e)
    //{
    //  // run validate
    //  _editorSource.Gp.Validate();

    //  // test state and update tool buttons
    //  UpdateButtons();

    //  // update stylesheet
    //  UpdateStylesheet();
    //}

    /// <summary>
    /// click [export]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //public void ClickExport(object sender, EventArgs e)
    //{
    //  // run export
    //  _editorSource.Gp.Export();

    //  // test state and update tool buttons
    //  UpdateButtons();

    //  // update stylesheet
    //  UpdateStylesheet();
    //}

    /// <summary>
    /// click [import]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //public void ClickImport(object sender, EventArgs e)
    //{
    //  // run import
    //  _editorSource.Gp.Import();

    //  // test state and update tool buttons
    //  _mevm.UpdateButtons();

    //  // update stylesheet
    //  _mevm.UpdateStylesheet();
    //}

    /// <summary>
    /// click [upgrade]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //public void ClickUpgrade(object sender, EventArgs e)
    //{
    //  Upgrade();
    //}

    //private void Upgrade()
    //{
    //  Upgrade(null);
    //}

    //private void Upgrade(string upgradeType)
    //{
    //  // run upgrade
    //  _editorSource.Gp.Upgrade(upgradeType);

    //  // test state and update tool buttons
    //  UpdateButtons();

    //  // update stylesheet
    //  UpdateStylesheet();
    //}

    /// <summary>
    /// Click a page in the TOC
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //public void TocClick(object sender, EventArgs e)
    //{
    //  // get the selected item
    //  ListBox lb = sender as ListBox;
    //  XmlNode el = lb.SelectedItem as XmlNode;
    //  if (null == el)
    //    return;

    //  // load the page
    //  try
    //  {
    //    // commit the current elemtent with focus
    //    // and the commit pages
    //    CommitFocusedElements();
    //    CommitPages();

    //    // trim the XML
    //    TrimXml(_workingSourceMetadata);

    //    // clear status
    //    ClearStatus();

    //    // clear selected items
    //    ClearSelectedTOCItems(_configDocument);

    //    // load the referenced page
    //    LoadPage(el);

    //    // disable OTHER highlighted/selected list items on OTHER listboxes
    //    foreach (ListBox other in _sectionListBoxes)
    //    {
    //      if (other != lb)
    //      {
    //        other.SelectedIndex = -1;
    //      }
    //    }
    //  }
    //  catch (Exception) { /* NOOP */ }
    //}

    /// <summary>
    /// click an issue hyperlink
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //public void OnIssueClick(object sender, EventArgs e)
    //{

    //  // get the metadata issue value
    //  //
    //  var issue = ((DependencyObject)sender).GetValue(MetadataRules.MetadataIssueProperty) as MetadataValidationIssue;
    //  if (null == issue)
    //    return; // problem

    //  ViewModel.OnIssueClick(issue);
    //}
  }
}
