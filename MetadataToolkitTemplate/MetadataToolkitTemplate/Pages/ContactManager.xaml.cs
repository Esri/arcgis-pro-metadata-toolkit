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
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Metadata;
using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace $safeprojectname$.Pages
{
  internal class ContactManagerSidebarLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return ContactManagerSidebarLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return $safeprojectname$.Properties.Resources.CFG_LBL_CONTACT_MGR; }
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
        string digest = Utils.GeneratePartyKey(child);
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
      string file = Utils.GetContactsFileLocation();
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
        MessageBoxResult result = ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox($safeprojectname$.Properties.Resources.LBL_CM_Confirm, $safeprojectname$.Properties.Resources.LBL_CM_ConfirmTitle, button, icon);

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
      contactsListBox.ItemsSource = Utils.GenerateContactsList(_contactsDoc, this.DataContext);

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
