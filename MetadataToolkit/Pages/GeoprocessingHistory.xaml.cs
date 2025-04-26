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
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Metadata.Editors.ClassicEditor.Pages.Converters;
using ArcGIS.Desktop.Metadata.Editors.ClassicEditor;
using ArcGIS.Desktop.Metadata.Events;
using ArcGIS.Desktop.Metadata.Editors.ClassicEditor.Pages;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml;

namespace MetadataToolkit.Pages
{
  internal class GeoprocessingHistorySidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return GeoprocessingHistorySidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return MetadataToolkit.Properties.Resources.CFG_LBL_GEOPROCESSING; }
    }
  }

  /// <summary>
  /// Interaction logic for GeoprocessingHistory.xaml
  /// </summary>
  internal partial class MTK_GeoprocessingHistory : EditorPage
  {
    #region fields
    private RelayCommand _deleteCommand;
    private RelayCommand _clearSelectionCommand;
    private RelayCommand _selectAllCommand;
    private Dictionary<GridViewColumnHeader, ListSortDirection> _dictSorting = new Dictionary<GridViewColumnHeader, ListSortDirection>();
    private bool _canDeleteGPHistory = true;

    private static readonly DependencyProperty SortDirectionProperty = DependencyProperty.Register("SortDirection", typeof(ListSortDirection), typeof(MTK_GeoprocessingHistory));
    private static readonly DependencyProperty CurrentSortColumnHeaderProperty = DependencyProperty.Register("CurrentSortColumnHeader", typeof(GridViewColumnHeader), typeof(MTK_GeoprocessingHistory));
    private static readonly DependencyProperty ProcessListViewVisibilityProperty = DependencyProperty.Register("ProcessListViewVisibility", typeof(Visibility), typeof(MTK_GeoprocessingHistory));

    #endregion fields

    #region construction / destruction  

    public MTK_GeoprocessingHistory()
    {
      InitializeComponent();

      _deleteCommand = new RelayCommand(() => DeleteCommandExecute(), () => DeleteCommandCanExecute());
      _clearSelectionCommand = new RelayCommand(() => ClearSelectionCommandExecute(), () => ClearSelectionCommandCanExecute());
      _selectAllCommand = new RelayCommand(() => SelectAllCommandExecute(), () => SelectAllCommandCanExecute());  

      //There is no sort to start with (just as the metadata xml is sorted).
      NameGridViewColumnHeader.ContentTemplate = Resources["HeaderTemplateDefault"] as DataTemplate;
      DatetimeGridViewColumnHeader.ContentTemplate = Resources["HeaderTemplateDefault"] as DataTemplate;
      ExportGridViewColumnHeader.ContentTemplate = Resources["HeaderTemplateDefault"] as DataTemplate;
      ToolExecutionGridViewColumnHeader.ContentTemplate = Resources["HeaderTemplateDefault"] as DataTemplate;

      //Check to see if the user is allowed to delete GP history (user setting and admin setting)
      UpdateCanDeleteGPHistory();

      MetadataSettingsChangedEvent.Subscribe(OnMetadataSettingsChanged);
    }

    ~MTK_GeoprocessingHistory()
    {
      MetadataSettingsChangedEvent.Unsubscribe(OnMetadataSettingsChanged);
    }

    #endregion construction


    #region properties    

    public override string SidebarLabel
    {
      get { return GeoprocessingHistorySidebarLabel.SidebarLabel; }
    }

    public RelayCommand DeleteCommand
    {
      get { return _deleteCommand; }
    }

    public RelayCommand ClearSelectionCommand
    {
      get { return _clearSelectionCommand; }
    }

    public RelayCommand SelectAllCommand
    {
      get { return _selectAllCommand; }
    }

    public ListSortDirection SortDirection
    {
      get { return (ListSortDirection) GetValue(MTK_GeoprocessingHistory.SortDirectionProperty); }
      set { SetValue(MTK_GeoprocessingHistory.SortDirectionProperty, value); }
    }

    public GridViewColumnHeader CurrentSortColumnHeader
    {
      get { return GetValue(MTK_GeoprocessingHistory.CurrentSortColumnHeaderProperty) as GridViewColumnHeader; }
      set { SetValue(MTK_GeoprocessingHistory.CurrentSortColumnHeaderProperty, value); }
    }

    public Visibility ProcessListViewVisibility
    {
      get { return (Visibility)GetValue(MTK_GeoprocessingHistory.ProcessListViewVisibilityProperty); }
      set { SetValue(MTK_GeoprocessingHistory.ProcessListViewVisibilityProperty, value); }
    }
    #endregion properties

    #region private methods

    private bool DeleteCommandCanExecute()
    { 
      return _canDeleteGPHistory && (ProcessListView.SelectedItems.Count > 0);
    }

    private void DeleteCommandExecute()
    {
      try
      {
        //Create a list of selected XmlNodes (so we don't modify a collection we are enumerating.
        List<XmlNode> selectedItems = new List<XmlNode>();
        foreach (XmlNode selectedItem in ProcessListView.SelectedItems)
        {
          selectedItems.Add(selectedItem);
        }

        foreach (XmlNode item in selectedItems)
        {
          List<XmlNode> newList = new List<XmlNode>();
          newList.Add(item);          

          DeleteItem(newList, false);
        }
      }
      finally
      {
        UpdateProcessListViewVisibility();
      }
    }

    private bool ClearSelectionCommandCanExecute()
    {
      return ProcessListView.SelectedItems.Count > 0;
    }

    private void ClearSelectionCommandExecute()
    {
      ProcessListView.SelectedItems.Clear();
    }

    private bool SelectAllCommandCanExecute()
    {
      return (ProcessListView.SelectedItems.Count < ProcessListView.Items.Count) && ProcessListViewVisibility == Visibility.Visible;
    }

    private void SelectAllCommandExecute()
    {
      ProcessListView.SelectAll();
      ProcessListView.Focus();
    }

    private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
    {
      GridViewColumnHeader gridViewColumnHeader = sender as GridViewColumnHeader;
      ListSortDirection newSortDirection = ListSortDirection.Ascending; //default

      //Do we have a current sort column yet? If not, just sort ascending on the column
      if (CurrentSortColumnHeader != null)
      {
        //If the user is clicking the currently sorted column, the new direction should be opposite to what is in
        //our tracking dict. If the user is clicking a column header which has been clicked previously, sort
        //using the last used sort direction for that column.
        if (gridViewColumnHeader == CurrentSortColumnHeader)
        {
          newSortDirection = _dictSorting[gridViewColumnHeader] == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
        }
        else
        {
          if (_dictSorting.ContainsKey(gridViewColumnHeader))
          {
            newSortDirection = _dictSorting[gridViewColumnHeader];
          }
        }
      }

      Sort(gridViewColumnHeader, newSortDirection);

    }

    private void Sort(GridViewColumnHeader gridViewColumnHeader, ListSortDirection sortDirection)
    {
      //Perform the sort

      if (ProcessListView.Items.SortDescriptions.Count > 0)
      {
        ProcessListView.Items.SortDescriptions.Clear();
      }

      
      ListCollectionView listCollectionView = CollectionViewSource.GetDefaultView(ProcessListView.ItemsSource) as ListCollectionView;
      if (listCollectionView != null)
      {
        if (gridViewColumnHeader == NameGridViewColumnHeader)
        {
          listCollectionView.CustomSort = new GeoprocessingHistoryComparerName(sortDirection);
        }
        else if (gridViewColumnHeader == DatetimeGridViewColumnHeader)
        {
          listCollectionView.CustomSort = new GeoprocessingHistoryComparerDateTime(sortDirection);
        }
        else if (gridViewColumnHeader == ExportGridViewColumnHeader)
        {
          listCollectionView.CustomSort = new GeoprocessingHistoryComparerExport(sortDirection);
        }
        else if (gridViewColumnHeader == ToolExecutionGridViewColumnHeader)
        {
          listCollectionView.CustomSort = new GeoprocessingHistoryComparerToolExecution(sortDirection);
        }
        else
        {
          listCollectionView.CustomSort = null;
        }
      }

      //cache the current header
      GridViewColumnHeader oldColumnHeader = CurrentSortColumnHeader;
     
      //Set the current tracking values for the sort.
      CurrentSortColumnHeader = gridViewColumnHeader;
      SortDirection = sortDirection;
      _dictSorting[gridViewColumnHeader] = sortDirection;

      //Update templates for affected columns
      if (oldColumnHeader != null && oldColumnHeader != CurrentSortColumnHeader)
      {
        //Set template to one that doesn't show an arrow
        oldColumnHeader.ContentTemplate = Resources["HeaderTemplateDefault"] as DataTemplate;
      }

      if (SortDirection == ListSortDirection.Ascending)
      {
        CurrentSortColumnHeader.ContentTemplate = Resources["HeaderTemplateArrowUp"] as DataTemplate;
      }
      else
      {
        CurrentSortColumnHeader.ContentTemplate = Resources["HeaderTemplateArrowDown"] as DataTemplate;
      }

    }

    private void UpdateProcessListViewVisibility()
    {
      if (ProcessListView.Items.Count == 0 ||
          (ProcessListView.Items.Count == 1 && string.IsNullOrEmpty((ProcessListView.Items[0] as XmlNode)?.InnerText)))
      {
        //Our Datacontext is an xml document. If there is no geoprocessin history, the xml node in the metadata is still populated with an empty "Process"
        //node. We are going to treat that as a list of zero items.
        ProcessListViewVisibility = Visibility.Collapsed;
      }
      else
      {
        ProcessListViewVisibility = Visibility.Visible;
      }
    }
    #endregion private methods

    private void GeoprocessingHistory_Loaded(object sender, RoutedEventArgs e)
    {
      FillXml(sender, e);
      UpdateProcessListViewVisibility();
    }

    private void CopyToolExecutionButton_Click(object sender, RoutedEventArgs e)
    {
      XmlNode toolExecutionNode = ((FrameworkElement)sender).DataContext as XmlNode;
      Clipboard.SetText(toolExecutionNode.InnerText);
    }

    private void UpdateCanDeleteGPHistory()
    {
      ArcGIS.Desktop.Internal.Framework.AdministratorSetting<bool> adminSettingCanDeleteGPHistory = ArcGIS.Desktop.Internal.Framework.CatalogSettings.MetadataCanDeleteGPHistory;
      if (adminSettingCanDeleteGPHistory != null)
      {
        if (adminSettingCanDeleteGPHistory.IsLocked)
          _canDeleteGPHistory = adminSettingCanDeleteGPHistory.GetValue();
      }
    }

    private void OnMetadataSettingsChanged(MetadataSettingsChangedEventArgs args)
    {
      _canDeleteGPHistory = args.MetadataSettings.CanDeleteGPHistory;
      if (_canDeleteGPHistory)
      {
        UpdateCanDeleteGPHistory();
        CommandManager.InvalidateRequerySuggested();
      }
    }
  }

  //For each of the comparers used to sort the view, we have to duplicate the logic used in the xaml to generate the display values before we can sort.

  internal class GeoprocessingHistoryComparerName : IComparer
  {
    private ListSortDirection _sortDirection = ListSortDirection.Ascending;

    public GeoprocessingHistoryComparerName(ListSortDirection sortDirection)
    {
      _sortDirection = sortDirection;
    }

    public int Compare(object x, object y)
    {
      int retVal = 0;
      XmlElement xElement = x as XmlElement;
      XmlElement yElement = y as XmlElement;

      if (xElement != null && yElement != null)
      {
        string xToolSource = xElement.GetAttribute("ToolSource");
        string yToolSource = yElement.GetAttribute("ToolSource");

        GeoprocessingHistoryToolSourceToNameConverter converter = new GeoprocessingHistoryToolSourceToNameConverter();
        string xName = converter.Convert(xToolSource, typeof(string), null, CultureInfo.CurrentCulture) as string;
        string yName = converter.Convert(yToolSource, typeof(string), null, CultureInfo.CurrentCulture) as string;

        StringComparer comparer = StringComparer.FromComparison(StringComparison.CurrentCulture);
        if (_sortDirection == ListSortDirection.Ascending)
        {
          retVal = comparer.Compare(xName, yName);
        }
        else
        {
          retVal = comparer.Compare(yName, xName);
        }
      }

      return retVal;
    }
  }

  internal class GeoprocessingHistoryComparerDateTime : IComparer
  {
    private ListSortDirection _sortDirection = ListSortDirection.Ascending;

    public GeoprocessingHistoryComparerDateTime(ListSortDirection sortDirection)
    {
      _sortDirection = sortDirection;
    }

    public int Compare(object x, object y)
    {
      int retVal = 0;

      XmlElement xElement = x as XmlElement;
      XmlElement yElement = y as XmlElement;

      if (xElement != null && yElement != null)
      {
        string xDateString = xElement.GetAttribute("Date");
        string xTimeString = xElement.GetAttribute("Time");
        string yDateString = yElement.GetAttribute("Date");
        string yTimeString = yElement.GetAttribute("Time");

        GeoprocessingHistoryDatetimeConverter converter = new GeoprocessingHistoryDatetimeConverter();
        string xDateTimeString = converter.Convert(new object[] { xDateString, xTimeString }, typeof(string), null, CultureInfo.CurrentCulture) as string;
        string yDateTimeString = converter.Convert(new object[] { yDateString, yTimeString }, typeof(string), null, CultureInfo.CurrentCulture) as string;

        //The converter could return an empty string as a result of a bad parse attempt, and we need to protect against that possibility in these parse calls as well.
        DateTime xDateTime = DateTime.MinValue;
        DateTime yDateTime = DateTime.MinValue;
        try
        {
          xDateTime = DateTime.Parse(xDateTimeString, CultureInfo.GetCultureInfo("en-US"));
          yDateTime = DateTime.Parse(yDateTimeString, CultureInfo.GetCultureInfo("en-US"));
        }
        catch(Exception)
        {
          //If there is a problem with parsing, just return 0 for the compare.
          return retVal;
        }

        if (_sortDirection == ListSortDirection.Ascending)
        {
          retVal = DateTime.Compare(xDateTime, yDateTime);
        }
        else
        {
          retVal = DateTime.Compare(yDateTime, xDateTime);
        }

      }

      return retVal;
    }
  }

  internal class GeoprocessingHistoryComparerExport : IComparer
  {
    private ListSortDirection _sortDirection = ListSortDirection.Ascending;

    public GeoprocessingHistoryComparerExport(ListSortDirection sortDirection)
    {
      _sortDirection = sortDirection;
    }
    public int Compare(object x, object y)
    {
      int retVal = 0;

      XmlElement xElement = x as XmlElement;
      XmlElement yElement = y as XmlElement;

      if (xElement != null && yElement != null)
      {
        string xExport = xElement.GetAttribute("export");
        string yExport = yElement.GetAttribute("export");

        StringComparer comparer = StringComparer.FromComparison(StringComparison.InvariantCulture);
        if (_sortDirection == ListSortDirection.Ascending)
        {
          retVal = comparer.Compare(xExport, yExport);
        }
        else
        {
          retVal = comparer.Compare(yExport, xExport);
        }
      }

      return retVal;
    }
  }

  internal class GeoprocessingHistoryComparerToolExecution : IComparer
  {
    private ListSortDirection _sortDirection = ListSortDirection.Ascending;

    public GeoprocessingHistoryComparerToolExecution(ListSortDirection sortDirection)
    {
      _sortDirection = sortDirection;
    }
    public int Compare(object x, object y)
    {
      int retVal = 0;

      XmlElement xElement = x as XmlElement;
      XmlElement yElement = y as XmlElement;

      if (xElement != null && yElement != null)
      {
        string xToolExecution = xElement.InnerText;
        string yToolExecution = yElement.InnerText;

        StringComparer comparer = StringComparer.FromComparison(StringComparison.InvariantCulture);
        if (_sortDirection == ListSortDirection.Ascending)
        {
          retVal = comparer.Compare(xToolExecution, yToolExecution);
        }
        else
        {
          retVal = comparer.Compare(yToolExecution, xToolExecution);
        }
      }

      return retVal;
    }
  }
}
