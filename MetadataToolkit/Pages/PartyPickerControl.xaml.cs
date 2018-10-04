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
using System.Xml;

using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_PartyPickerControl.xaml
  /// </summary>
  internal partial class MTK_PartyPickerControl : EditorPage
  {
    public string ContainerElement { get; set; }

    public MTK_PartyPickerControl()
    {
      InitializeComponent();
    }

    public void LoadList(object sender, EventArgs e)
    {
      XmlDocument _contactsDoc = new XmlDocument();

      var list = Utils.Utils.GenerateContactsList(_contactsDoc, this.DataContext);
      if (list == null)
        return;

      foreach (XmlNode node in list)
      {
        // get ONE good name for display
        //var nameNode = node.SelectSingleNode("rpIndName | rpOrgName | rpPosName");
        //var nameString = "unknown";
        //if (null != nameNode && 0 < nameNode.InnerText.Length) {
        //  nameString = nameNode.InnerText;
        //}

        var nameString = Utils.Utils.ExtractResponsiblePartyLabel(node, MetadataToolkit.Properties.Resources.LBL_CI_PARTY_ADD_FORMAT);

        // create new node for display in the list control
        var newNode = _contactsDoc.CreateElement("displayName");
        newNode.InnerText = nameString;
        node.AppendChild(newNode);   
      }

      // return list
      PartyList.ItemsSource = list;
    }

    public void LoadParty(object sender, EventArgs e)
    {
      // new xml to be inserted
      XmlNode selectedNode = PartyList.SelectedItem as XmlNode;
      if (null == selectedNode)
        return; // nothing selected

      string newXml = selectedNode.InnerXml;

      // get the context node
      var dataContextXml = Utils.Utils.GetXmlDataContext(this.DataContext);
      if (null == dataContextXml)
        return;

      XmlNode contextNode = null;
      foreach (XmlNode node in dataContextXml)
      {
        contextNode = node;
        break;
      }

      // add new xml to a container element, then add the container to the datacontext node
      if (contextNode != null &&  null != newXml && 0 < newXml.Length && null != ContainerElement && 0 < ContainerElement.Length)
      {

        // create container node
        var containerNode = contextNode.OwnerDocument.CreateElement(ContainerElement);
        containerNode.InnerXml = newXml;

        // add to data context
        contextNode.AppendChild(containerNode);
      }
    }
  }
}
