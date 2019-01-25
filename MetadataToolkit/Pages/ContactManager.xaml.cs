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
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Metadata;
using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace MetadataToolkit.Pages
{
  internal class ContactManagerSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ContactManagerSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return MetadataToolkit.Properties.Resources.CFG_LBL_CONTACT_MGR; }
    }    
  }
  /// <summary>
  /// Interaction logic for MTK_ContactManager.xaml
  /// </summary>
  internal partial class MTK_ContactManager : EditorPage
  {
    private XmlDocument _contactsDoc = null;

    public MTK_ContactManager()
    {
      InitializeComponent();

      LostFocus += ContactManager_LostFocus;
    }

    bool _isContactsListDirty = false;
    void ContactManager_LostFocus(object sender, RoutedEventArgs e)
    {
      CommitChanges();
      ReloadContacts();
      _isContactsListDirty = false;
    }

    /// <summary>
    /// unload form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    override public void CommitChanges()
    {
      if (!_isContactsListDirty)
        return;

      if (null == _contactsDoc)
        return;

      // new document
      XmlDocument clone = new XmlDocument();
      XmlNode contactsNode = clone.CreateElement("contacts");
      clone.AppendChild(contactsNode);

      // write back out the contacts marked saved
      var list = _contactsDoc.SelectNodes("//contact[editorSave='True']");
      StringBuilder sb = new StringBuilder();

      foreach (XmlNode child in list)
      {
        // remove elements
        //
        XmlNode e = child.SelectSingleNode("editorSource");
        if (null != e)
        {
          child.RemoveChild(e);
        }

        e = child.SelectSingleNode("editorDigest");
        if (null != e)
        {
          child.RemoveChild(e);
        }

        // remove role
        //
        e = child.SelectSingleNode("role");
        if (null != e)
        {
          child.RemoveChild(e);
        }

        // save back unique key
        string digest = Utils.Utils.GeneratePartyKey(child);
        sb.Append("<contact>");
        sb.Append("<editorSource>external</editorSource>");
        sb.Append("<editorDigest>");
        sb.Append(digest);
        sb.Append("</editorDigest>");
        sb.Append(child.InnerXml);
        sb.Append("</contact>");
      }

      // append to clone
      contactsNode.InnerXml = sb.ToString();

      // save to file
      string file = Utils.Utils.GetContactsFileLocation();
      clone.Save(file);
    }


    public void OnCheck(object sender, RoutedEventArgs e)
    {
      _isContactsListDirty = true; 
    }

    public void OnUnCheck(object sender, RoutedEventArgs e)
    {
      CheckBox cb = sender as CheckBox;
      if (null == cb)
        return;
      Nullable<bool> check = cb.IsChecked;

      XmlNode tagNode = cb.Tag as XmlNode;
      if (null == tagNode)
        return;

      if (false == check && "external".Equals(tagNode.InnerText))
      {
        //string message = Properties.Resources.MSGBOX_SAVE_MSG;
        //string caption = Properties.Resources.MSGBOX_SAVE_CAPTION;
        MessageBoxButton button = MessageBoxButton.YesNo;
        MessageBoxImage icon = MessageBoxImage.Warning;

        // show dialog
        MessageBoxResult result = ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox(MetadataToolkit.Properties.Resources.LBL_CM_Confirm, MetadataToolkit.Properties.Resources.LBL_CM_ConfirmTitle, button, icon);

        switch (result)
        {
          case MessageBoxResult.Yes:
            _isContactsListDirty = true;            
            break;
          //DoSave();
          //break;
          case MessageBoxResult.No:
            cb.IsChecked = true;
            break;
          //DoCancel();
          //break;
        }
      }
    }

    /// <summary>
    /// load form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void LoadContacts(object sender, RoutedEventArgs e)
    {
      ReloadContacts();
    }

    private void ReloadContacts()
    {
      _contactsDoc = new XmlDocument();
      contactsListBox.ItemsSource = Utils.Utils.GenerateContactsList(_contactsDoc, this.DataContext);

      var mdModule = FrameworkApplication.FindModule("esri_metadata_module") as IMetadataEditorHost;
      if (mdModule != null)
        mdModule.AddCommitPage(this);
    }

    #region ISidebarLabel Members

    public override string SidebarLabel
    {
      get { return ContactManagerSidebarLabel.SidebarLabel; }
    }

    #endregion
  }
}
