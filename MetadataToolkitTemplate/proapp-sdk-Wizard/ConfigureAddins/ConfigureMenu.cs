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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using EnvDTE;
using metadata_toolkit_wizard.Helpers;
using metadata_toolkit_wizard.ViewModel;

namespace metadata_toolkit_wizard.ConfigureAddins
{
  class ConfigureMenu : ConfigureControlBase
  {
    public override void RunStarted(Helpers.ProjectHelper helper)
    {
      //set some defaults
      helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
      helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
      helper.ReplacementsDictionary["$size$"] = "middle";
      //Set ID for Buttons in the menu
      helper.ReplacementsDictionary["$menubuttonid$"] = String.Join("_", helper.ReplacementsDictionary["$controlid$"], "Items");
      //This is the filename for the Button (without the '.cs')
      helper.ReplacementsDictionary["$addinclassname$"] = helper.ReplacementsDictionary["$safeitemname$"];
      helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
      foreach (var img in new string[] { "16", "32" })
      {
        string imageKey = string.Format("$image{0}$", img);
        string defaultImageKey = string.Format("$defaultimage{0}$", img);
        //add in default
        helper.ReplacementsDictionary.Add(imageKey, helper.ReplacementsDictionary[defaultImageKey]);
      }
    }

    public override bool ProjectItemFinishedGenerating(ProjectHelper helper, ProjectItem projectItem)
    {
      if (base.ProjectItemFinishedGenerating(helper, projectItem))
        return true;
      string filePath = projectItem.Name;
      //we have to handle these ones
      string ext = System.IO.Path.GetExtension(filePath);
      //is this the default addin file?
      string language = helper.ReplacementsDictionary["language"];
      if (projectItem.Name.CompareTo(helper.ReplacementsDictionary["$addinitemname$"] + language) == 0)
      {  
        //now handle the DAML
        XDocument configXML = helper.GetConfigXml(projectItem.ContainingProject);
        helper.ReplacementsDictionary["$defaultNamespace$"] = configXML.GetDefaultNamespace(); 

        //Get the Menu collection
        //if not found, add it
        XElement menus = configXML.GetMenusElement(true);
        //create menu
        XElement menu = new XElement(DAMLHelper.DefaultNS + "menu");
        menu.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);
        menu.SetAttributeValue("caption", helper.ReplacementsDictionary["$caption$"]);
        menu.SetAttributeValue("smallImage", helper.ReplacementsDictionary["$image16$"]);
        menu.SetAttributeValue("largeImage", helper.ReplacementsDictionary["$image32$"]);

        //get the controls collection
        //if not found, add it
        XElement controls = configXML.GetControlsElement(true);

        //loop to create 3 buttons. Add them to the Controls collection.
        //Creating and adding buttons for menu
        for (int i = 0; i < 3; i++)
        {
          string menuBtnID = "";
          string menuBtnClass = "";
          string menuBtnCaption = "";
          menuBtnID = string.Format("{0}_Button{1}", helper.ReplacementsDictionary["$menubuttonid$"], (i + 1).ToString());
          menuBtnClass = string.Format("{0}_button{1}", helper.ReplacementsDictionary["$addinclassname$"], (i + 1).ToString());
          menuBtnCaption = string.Format("Menu Button {0}", (i + 1).ToString());

          XElement menuButton = new XElement(DAMLHelper.DefaultNS + "button");
          menuButton.SetAttributeValue("id", menuBtnID);
          menuButton.SetAttributeValue("caption", menuBtnCaption);
          //Test if the button's namespace is the same as the default namespace in the config, if they are not we need to use the fully qualified class name
          if (helper.ReplacementsDictionary["$rootnamespace$"] != helper.ReplacementsDictionary["$defaultNamespace$"])
              menuBtnClass = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], menuBtnClass);
          menuButton.SetAttributeValue("className", menuBtnClass);
          menuButton.SetAttributeValue("loadOnClick", "true");
          menuButton.SetAttributeValue("smallImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image16$"]));
          menuButton.SetAttributeValue("largeImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image32$"]));

          //Tooltip
          string TooltipHeading = "";
          TooltipHeading = string.Format("Menu Button {0}", (i + 1).ToString());
          XElement menu_tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip");
          menu_tooltip.SetAttributeValue("heading", TooltipHeading);
          menu_tooltip.Value = "ToolTip";

          XElement menu_disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
          menu_tooltip.Add(menu_disabledText);
          //add the tooltip to the button
          menuButton.Add(menu_tooltip);
          //add the button to the controls collection
          controls.Add(menuButton);

          //Create menu button reference
          XElement menubuttonRef = new XElement(DAMLHelper.DefaultNS + "button");
          menubuttonRef.SetAttributeValue("refID", menuBtnID);
          
          //Add menu button reference to menu
          menu.Add(menubuttonRef);
        }

        //Add menu to menus
        menus.Add(menu);

        //Add the menu to a group that has the addintab true attribute set
        XElement group = configXML.GetGroupElement(helper, true, true);
        //create the menu element to be added
        XElement menuRef = new XElement(DAMLHelper.DefaultNS + "menu");
        menuRef.SetAttributeValue("refID", helper.ReplacementsDictionary["$controlid$"]);
        menuRef.SetAttributeValue("size", helper.ReplacementsDictionary["$size$"]);
        group.Add(menuRef);

        helper.SaveConfigXML(configXML.ToString());
      }
      return true;
    }
  }
}
