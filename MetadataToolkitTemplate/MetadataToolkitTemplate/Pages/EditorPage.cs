/*
Copyright 2019 Esri
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.​
*/

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Xml;
using System.ComponentModel;
using System.Windows.Input;
using ArcGIS.Desktop.Metadata.Editor.Validation;
using ArcGIS.Desktop.Metadata.Editor;

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  /// <summary>
  /// Base class for all Metadata Editor pages
  /// </summary>
  public partial class EditorPage : UserControl, INotifyPropertyChanged, ISidebarLabel
  {  
    public event PropertyChangedEventHandler PropertyChanged;
    private string _validators = null;
    private bool _loadedValidators = false;
    private bool _bRootPage = false;
    private Dictionary<object, SyncTag> _syncItems = new Dictionary<object, SyncTag>();

    public EditorPage()
    {
      this.Loaded += delegate
      {
        MetadataEditorViewModel vm = Utils.GetMetadataEditorViewModel(this) as MetadataEditorViewModel;
        if (vm != null)
          vm.IsLoadingPage = false;
      };
    }

    internal bool RootPage
    {
      set
      {
        _bRootPage = value;
        if (this.IsLoaded)
          MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        else
          this.Loaded += (sender, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
      }
    }

    public string Validators
    {
      get { return _validators; }
      set { _validators = value; }
    }

    /// <summary>
    /// call UpdateBinding during a Loaded event to add various validation rules at runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void UpdateBinding(object sender, RoutedEventArgs e)
    {
      if (_loadedValidators)
        return;

      FrameworkElement el = sender as FrameworkElement;
      Binding binding = BindingOperations.GetBinding(sender as DependencyObject, TextBox.TextProperty);
      if (null != binding)
      {
        ICollection<ValidationRule> list = GetValidators();
        foreach (ValidationRule rule in list)
        {
          binding.ValidationRules.Add(rule);
        }

        _loadedValidators = true; // don't add the same things again...
      }
    }

    protected ICollection<ValidationRule> GetValidators()
    {
      ICollection<ValidationRule> list = new List<ValidationRule>();
      if (null == _validators || 0 == _validators.Length)
          return list;

      string[] items = _validators.Split(new char[] { ' ', ',' });
      foreach (string item in items)
      {
        if ("required".Equals(item, StringComparison.InvariantCultureIgnoreCase))
        {
          ValidationRule rule = new Required();
          rule.ValidatesOnTargetUpdated = true;          
          list.Add(rule);
        }
        else if ("integer".Equals(item, StringComparison.InvariantCultureIgnoreCase))
        {
          ValidationRule rule = new IntegerValidator();
          rule.ValidatesOnTargetUpdated = true;
          list.Add(rule);
        }
        else if ("real".Equals(item, StringComparison.InvariantCultureIgnoreCase))
        {
          ValidationRule rule = new RealValidator();
          rule.ValidatesOnTargetUpdated = true;
          list.Add(rule);
        }
      }

      return list;
    }

    public virtual string DefaultValue
    {
      get { return String.Empty; }
      set { }
    }

    /// <summary>
    /// Sends a 'PropertyChangedEvent' for the property value 'DefaultValue
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void DefaultValueChanged(Object sender, DataTransferEventArgs args)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs("DefaultValue"));
      }
    }

    /// <summary>
    /// Sends a 'PropertyChangedEvent' for the property value 'DefaultValue
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void DefaultTargetValueChanged(Object sender, DataTransferEventArgs args)
    {
      //PropertyChangedEventHandler handler = PropertyChanged;
      //if (handler != null)
      //{
      //  handler(this, new PropertyChangedEventArgs("DefaultValue"));
      //}
    }
    
    /// <summary>
    /// Override this in subclasses
    /// </summary>
    public virtual string SidebarLabel
    {
      get { throw new MetadataException("Class must implement SidebarLabel!"); }
    }

    /// <summary>
    /// Called before saving the XML
    /// </summary>
    virtual public void CommitChanges()
    {
      // NOOP
    }

    /// <summary>
    /// Gets the current data context
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<XmlNode> GetXmlDataContext()
    {
      return Utils.GetXmlDataContext(this.DataContext);
    }

    /// <summary>
    /// Use the sender's xml data context to add the record to
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void AddRecordByTagToLocal(Object sender, RoutedEventArgs e)
    {
      string tag = Utils.GetStringTag(sender);
      ArcGIS.Desktop.Metadata.Editor.Utils.FillXml(sender, this, false, true, tag);
      MetadataEditorViewModel.UpdateDataContext(this as DependencyObject);
    }

    /// <summary>
    /// Add an XML Node by Tag
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void AddRecordByTag(Object sender, RoutedEventArgs e)
    {
      string tag = Utils.GetStringTag(sender);
      ArcGIS.Desktop.Metadata.Editor.Utils.FillXml(this, false, true, tag);
      MetadataEditorViewModel.UpdateDataContext(this as DependencyObject);
    }

    /// <summary>
    /// Add XML Node
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void AddRecord(Object sender, RoutedEventArgs e)
    {
      ArcGIS.Desktop.Metadata.Editor.Utils.FillXml(this, false, false);
      MetadataEditorViewModel.UpdateDataContext(this as DependencyObject);
    }   

    /// <summary>
    /// Delete an XML node
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void DeleteItem(Object sender, RoutedEventArgs e)
    {
      string message = Internal.Metadata.Properties.Resources.MSGBOX_DELETE_MSG;
      string caption = Internal.Metadata.Properties.Resources.MSGBOX_DELETE_CAPTION;
      MessageBoxButton button = MessageBoxButton.OKCancel;
      MessageBoxImage icon = MessageBoxImage.Question;

      // show dialog
      MessageBoxResult result = ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show(message, caption, button, icon);

      switch (result)
      {
        case MessageBoxResult.Cancel:
          return;
      }

      // Mark metadata dirty first
      MetadataEditorViewModel vm = Utils.GetMetadataEditorViewModel(this) as MetadataEditorViewModel;
      if (vm != null)
        vm.Metadata_NodeChanged(null, null);

      // get tag
      string tag = Utils.GetStringTag(sender);

      // get the data context and apply fill to each element
      IEnumerable<XmlNode> data = Utils.GetXmlDataContext(Utils.GetDataContext(sender));
      if (null != data)
      {
        foreach (XmlNode node in data)
        {
          if ("deleteParent".Equals(tag))
          {
            // get the root control first, b/c the data context
            // to which the current control is bound
            // will be deleted,
            // then updateDataContext will fail, b/c
            // the root MetadataEditorControl can't be found in the tree anymore
            var mec = Utils.GetMetadataEditorControl(this);

            XmlNode parentNode = node.ParentNode;
            XmlNode deletedNode = parentNode.ParentNode.RemoveChild(parentNode);
            if (null == deletedNode || deletedNode != parentNode)
              throw new MetadataException("Error deleting node!");

            MetadataEditorViewModel.UpdateDataContext(mec);
            break; ;
          }
          else
          {
            // remove the element from the tree
            XmlNode deletedNode = node.ParentNode.RemoveChild(node);
            if (null == deletedNode || deletedNode != node)
              throw new Exception("Error deleting node!");

            MetadataEditorViewModel.UpdateDataContext(this as DependencyObject);
            break;
          }
        }
      }
    }

    /// <summary>
    /// Delete an XML node
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ClearItem(Object sender, RoutedEventArgs e)
    {
      string message = Internal.Metadata.Properties.Resources.MSGBOX_DELETE_MSG;
      string caption = Internal.Metadata.Properties.Resources.MSGBOX_DELETE_CAPTION;
      MessageBoxButton button = MessageBoxButton.OKCancel;
      MessageBoxImage icon = MessageBoxImage.Question;

      // show dialog
      MessageBoxResult result = ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show(message, caption, button, icon);
      switch (result)
      {
        case MessageBoxResult.Cancel:
          return;
      }

      // get tag
      string tag = Utils.GetStringTag(sender);

      // get the data context and apply fill to each element
      IEnumerable<XmlNode> data = Utils.GetXmlDataContext(Utils.GetDataContext(sender));
      if (null != data)
      {
        foreach (XmlNode node in data)
        {
          // remove the element from the tree
          node.InnerXml = String.Empty;
          MetadataEditorViewModel.UpdateDataContext(this as DependencyObject);
          break;
        }
      }
    }

    public void ValidateAll(object sender)
    {   
      // update sidebar
      var mec = Utils.GetMetadataEditorControl(this);
      if (null != mec)
      {
        var vm = mec.DataContext as MetadataEditorViewModel;
        vm.UpdateSidebar();
      }
    }

    public void ValidateAll(object sender, RoutedEventArgs e)
    {   
      // update sidebar
      var mec = Utils.GetMetadataEditorControl(this);
      if (null != mec)
      {
        var vm = mec.DataContext as MetadataEditorViewModel;
        vm.UpdateSidebar();
      }
    }

    /// <summary>
    /// Fill the XML structure for this page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void FillXml(object sender, RoutedEventArgs e)
    {
      // utils does the work
      ArcGIS.Desktop.Metadata.Editor.Utils.FillXml(sender, true, false);

      // update sidebar
      var mec = Utils.GetMetadataEditorControl(this);
      if (null != mec)
      {
        var vm = mec.DataContext as MetadataEditorViewModel;
        vm.UpdateSidebar();
      }
    }

    public void FillXml()
    {
      FillXml(this, null);
    }

    public void ComboBoxSyncSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      // get the combo box
      ComboBox cb = sender as ComboBox;

      // get xpath source property
      var sourcexpath = cb.GetValue(SourceXPathProperty) as string;
      if (null == sourcexpath || 0 == sourcexpath.Length)
        sourcexpath = "*[1]/@value";

      // get data context
      Object dc = Utils.GetDataContext(cb);
      IEnumerable<XmlNode> contextNodes = Utils.GetXmlDataContext(dc);
      if (null == contextNodes)
        return;

      // get code value
      XmlNode valueNode = contextNodes.First().SelectSingleNode(sourcexpath);
      string valueNodeString = String.Empty;
      if (null != valueNode)
        valueNodeString = valueNode.Value;

      // check sync status
      XmlAttribute syncAtt = GetSyncAtt(cb);
      if (null == syncAtt)
        return;

      // handle sync status
      bool isSynced = "true".Equals(syncAtt.Value, StringComparison.InvariantCultureIgnoreCase);

      // get cached value
      if (!_syncItems.ContainsKey(cb))
        return;

      SyncTag cache = _syncItems[cb];
      if (null != cache && valueNode != null)
      {
        bool modified = (null != cache.tagValue) && (cache.tagValue != valueNode.Value);

        // get sync
        if (isSynced && modified)
        {
          syncAtt.Value = "FALSE";
        }
        else if (cache.syncValue && !modified)
        {
          syncAtt.Value = "TRUE";
        }
      }
    }

    public class SyncTag
    {
      public string tagValue = null;
      public bool syncValue = false;

      public SyncTag(string tagValue, bool syncValue)
      {
        this.tagValue = tagValue;
        this.syncValue = syncValue;
      }
    }

    public static readonly DependencyProperty SourceXPathProperty = DependencyProperty.RegisterAttached(
        "SourceXPath",
        typeof(string),
        typeof(EditorPage),
        new PropertyMetadata(String.Empty));

    public static void SetSourceXPath(UIElement element, string value)
    {
      element.SetValue(SourceXPathProperty, value);
    }
    public static string GetSourceXPath(UIElement element)
    {
      return (string)element.GetValue(SourceXPathProperty);
    }


    public void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private XmlAttribute GetSyncAtt(FrameworkElement el)
    {
      // get xpath source property
      var sourcexpath = el.GetValue(SourceXPathProperty) as string;
      if (null == sourcexpath || 0 == sourcexpath.Length)
        sourcexpath = "*[1]/@value";

      // get data context
      Object dc = Utils.GetDataContext(el);
      IEnumerable<XmlNode> contextNodes = Utils.GetXmlDataContext(dc);
      if (null == contextNodes)
        return null;

      // get code value
      XmlNode valueNode = contextNodes.First().SelectSingleNode(sourcexpath);
      if (null == valueNode)
        return null;

      // check sync status
      // if valueNode is an attribute, then grab the parent
      // else, go with valueNode
      XmlAttribute syncAtt = null;
      XmlNode valueNodeParent = null;
      if (XmlNodeType.Attribute == valueNode.NodeType)
      {
        valueNodeParent = valueNode.SelectSingleNode("parent::*");
      }
      else
      {
        valueNodeParent = valueNode;
      }
      syncAtt = Utils.GetSyncNode(valueNodeParent);
      return syncAtt;
    }

    /// <summary>
    /// Test if the code in the metadata doesn't match a code in the codelist. 
    /// If such a value exists, then present that value at the top of the pick list
    /// 
    /// Also check the @Sync attribute and change its value to FALSE if another item is selected in the combo box
    /// 
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void PostProcessComboBoxValues(object sender, EventArgs e)
    {
      // get the combo box
      ComboBox cb = sender as ComboBox;

      // get xpath source property
      var sourcexpath = cb.GetValue(SourceXPathProperty) as string;
      if (null == sourcexpath || 0 == sourcexpath.Length)
        sourcexpath = "*[1]/@value";

      // get data context
      Object dc = Utils.GetDataContext(cb);
      IEnumerable<XmlNode> contextNodes = Utils.GetXmlDataContext(dc);
      if (null == contextNodes)
        return;

      // get code value
      XmlNode valueNode = contextNodes.First().SelectSingleNode(sourcexpath);
      string valueNodeString = String.Empty;
      if (null != valueNode)
        valueNodeString = valueNode.Value;

      // check sync status
      XmlAttribute syncAtt = GetSyncAtt(cb);

      // handle sync
      if (null != syncAtt)
      {
        bool isSynced = "true".Equals(syncAtt.Value, StringComparison.InvariantCultureIgnoreCase);

        // add to hash for later retrieval
        if (_syncItems.ContainsKey(cb))
          _syncItems.Remove(cb);
        SyncTag item = new SyncTag(valueNodeString, isSynced);
        _syncItems.Add(cb, item);
      }

      // get combox values
      XmlNodeList nodes = cb.ItemsSource as XmlNodeList;
      object selectedValue = cb.SelectedValue;

      if (!String.IsNullOrEmpty(valueNodeString))
      {
        if (null == selectedValue)
        {
          try
          {

            // get first node in codelist
            XmlNode firstNode = nodes[0];

            // exit if alread added this node
            if (null == firstNode.Attributes.GetNamedItem("added"))
            {

              XmlNode clone = firstNode.CloneNode(true);

              clone.InnerText = Internal.Metadata.Properties.Resources.CMB_UNRECOGNIZED_VALUE + valueNodeString;
              clone.Attributes.GetNamedItem("value").Value = valueNodeString;

              XmlAttribute att = firstNode.OwnerDocument.CreateAttribute("added");
              att.Value = "True";
              clone.Attributes.SetNamedItem(att);

              // insert temporary value
              firstNode.ParentNode.InsertBefore(clone, firstNode);

              // give the combobox a new list, reselect
              cb.ItemsSource = firstNode.SelectNodes("../*");

              // and a new value
              cb.SelectedValue = valueNodeString;
            }
          }
          catch (Exception)
          {
            // NO-OP
          }
        }

      }
      else
      {
        //cb.SelectedValue = valueNodeString;
      }
    }

    public IInputElement LastKeyboardFocusElement { get; private set; }
    protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
    {
      LastKeyboardFocusElement = e.NewFocus;
      base.OnGotKeyboardFocus(e);
    }
  }
}
