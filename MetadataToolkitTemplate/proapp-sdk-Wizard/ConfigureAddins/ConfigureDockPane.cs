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
using System.Text.RegularExpressions;

namespace metadata_toolkit_wizard.ConfigureAddins {

    internal class ConfigureDockPane : ConfigureControlBase, IWizardConfig {

        private DockPaneViewModel _vm = null;

        public override void RunStarted(ProjectHelper helper)
        {
            //set some defaults
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);

            //This is the ID for the dockpane button
            helper.ReplacementsDictionary["$dockpanebuttonid$"] = helper.ReplacementsDictionary["$controlid$"] + "_ShowButton";
            helper.ReplacementsDictionary["$burgermenuid$"] = helper.ReplacementsDictionary["$controlid$"] + "_Menu";
            helper.ReplacementsDictionary["$burgermenubuttonid$"] = helper.ReplacementsDictionary["$burgermenuid$"] + "Button";

            //"DockPaneView" class name
            helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
            //"DockPaneViewModel" class name
            helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";
            //"DockPaneShowButton" class name
            helper.ReplacementsDictionary["$showbuttonclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "_ShowButton";
            //"DockPaneBurgerMenuButton" class name
            helper.ReplacementsDictionary["$burgermenubuttonclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "_MenuButton";

            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$dockwith$"] = Defaults.DockWithOptionsMap.Keys.First();
            helper.ReplacementsDictionary["$dockoption$"] = Defaults.DockMap.Keys.First();

            foreach (var img in new string[] { "16", "32" })
            {
                string imageKey = string.Format("$image{0}$", img);
                string defaultImageKey = string.Format("$defaultimage{0}$", img);
                //add in default
                helper.ReplacementsDictionary.Add(imageKey, helper.ReplacementsDictionary[defaultImageKey]);
            }
        }

        public override bool ProjectItemFinishedGenerating(ProjectHelper helper, ProjectItem projectItem) {
            if (base.ProjectItemFinishedGenerating(helper, projectItem))
                return true;
            string filePath = projectItem.Name;
            //we have to handle these ones
            string ext = System.IO.Path.GetExtension(filePath);
            //is this the default addin file?
            string language = helper.ReplacementsDictionary["language"];
            if (projectItem.Name.CompareTo(helper.ReplacementsDictionary["$viewmodelclass$"] + language) == 0)
            {  
                //yes....first, add in any user selected images
                foreach (var imageFile in helper.UserSelectedImages) {
                    //add them to the project
                    ImageHelper.AddImageFile(projectItem.ContainingProject, imageFile, true);
                }
                helper.UserSelectedImages.Clear();
                //now handle the DAML
                 XDocument configXML = helper.GetConfigXml(projectItem.ContainingProject);
                 helper.ReplacementsDictionary["$defaultNamespace$"] = configXML.GetDefaultNamespace();
                 //Test if the button's namespace is the same as the default namespace in the config, if they are not we need to use the fully qualified class name
                 if (helper.ReplacementsDictionary["$rootnamespace$"] != helper.ReplacementsDictionary["$defaultNamespace$"])
                 {
                     helper.ReplacementsDictionary["$viewmodelclass$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$viewmodelclass$"]);
                     helper.ReplacementsDictionary["$viewclass$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$viewclass$"]);
                     helper.ReplacementsDictionary["$showbuttonclass$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$showbuttonclass$"]);
                     helper.ReplacementsDictionary["$burgermenubuttonclass$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$burgermenubuttonclass$"]);
                 }

                 //get the DockPanes collection
                 //if not found, add it
                 XElement dockPanes = configXML.GetDockPanesElement(true);

                //create the dockpane
                 XElement dockpane = new XElement(DAMLHelper.DefaultNS + "dockPane");
                 dockpane.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);
                 dockpane.SetAttributeValue("caption", helper.ReplacementsDictionary["$caption$"]);               
                 dockpane.SetAttributeValue("className", helper.ReplacementsDictionary["$viewmodelclass$"]);                 
                 //dockpane.SetAttributeValue("keytip", "DockPane");
                 //dockpane.SetAttributeValue("initiallyVisible", "true"); This attribute is not needed anymore.
                 // Dock Top, Bottom, Left, Right or Group
                 if (helper.ReplacementsDictionary.ContainsKey("$dockoption$"))
                 {
                     dockpane.SetAttributeValue("dock", helper.ReplacementsDictionary["$dockoption$"]);
                 }
                 // Dock With attribute only written if Dock Option = Group.
                 if (helper.ReplacementsDictionary.ContainsKey("$dockwith$") && helper.ReplacementsDictionary["$dockoption$"] == "group")
                 {
                     dockpane.SetAttributeValue("dockWith", helper.ReplacementsDictionary["$dockwith$"]);
                 }
                 //Dockpane content
                 XElement content = new XElement(DAMLHelper.DefaultNS + "content");
                 content.SetAttributeValue("className", helper.ReplacementsDictionary["$viewclass$"]);
                //add the content to dockpane
                 dockpane.Add(content);

                //add dockpane to Dockpane
                 dockPanes.Add(dockpane);
              
                //get the controls collection
                //if not found, add it
                XElement controls = configXML.GetControlsElement(true);

                //create the button
                XElement button = new XElement(DAMLHelper.DefaultNS + "button");
                button.SetAttributeValue("id", helper.ReplacementsDictionary["$dockpanebuttonid$"]);
                button.SetAttributeValue("caption", "Show " + helper.ReplacementsDictionary["$caption$"]);
                button.SetAttributeValue("className", helper.ReplacementsDictionary["$showbuttonclass$"]);
                button.SetAttributeValue("loadOnClick", "true");
                button.SetAttributeValue("smallImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image16$"]));
                button.SetAttributeValue("largeImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image32$"]));

                //Tooltip
                XElement tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip") ;
                tooltip.SetAttributeValue("heading", "Show Dockpane");
                tooltip.Value = "Show Dockpane";

                XElement disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
                tooltip.Add(disabledText);
                //add the tooltip to the button
                button.Add(tooltip) ;
                //add the button to the controls collection
                controls.Add(button) ;

                //Add the button to a group that has the addintab true attribute set
                XElement group = configXML.GetGroupElement(helper, true, true);
                //create the button element to be added
                button = new XElement(DAMLHelper.DefaultNS + "button");
                button.SetAttributeValue("refID", helper.ReplacementsDictionary["$dockpanebuttonid$"]);
                button.SetAttributeValue("size", "large");
                group.Add(button);

                //Add burger menu and menu button if add-in type contains a burger button
                if (helper.ReplacementsDictionary["addintype"] == "dockpane_burgerbutton")
                {
                  //Get the menu elements
                  XElement menus = configXML.GetMenusElement(true);
                  //create menu
                  XElement menu = new XElement(DAMLHelper.DefaultNS + "menu");
                  menu.SetAttributeValue("id", helper.ReplacementsDictionary["$burgermenuid$"]);
                  menu.SetAttributeValue("caption", "Options");
                  menu.SetAttributeValue("contextMenu", "true");

                  //Add menu to menus
                  menus.Add(menu);

                  string BurgerBtnID = "";
                  string BurgerBtnClass = "";
                  string BurgerBtnCaption = "";
                  BurgerBtnID = helper.ReplacementsDictionary["$burgermenubuttonid$"];
                  BurgerBtnClass = helper.ReplacementsDictionary["$burgermenubuttonclass$"];
                  BurgerBtnCaption = "Burger Menu Button";
                    
                  XElement burgerbutton = new XElement(DAMLHelper.DefaultNS + "button");
                  burgerbutton.SetAttributeValue("id", BurgerBtnID);
                  burgerbutton.SetAttributeValue("caption", BurgerBtnCaption);
                  burgerbutton.SetAttributeValue("className", BurgerBtnClass);
                  burgerbutton.SetAttributeValue("loadOnClick", "true");
                  burgerbutton.SetAttributeValue("smallImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image16$"]));
                  burgerbutton.SetAttributeValue("largeImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image32$"]));
                    
                  //Tooltip
                  string TooltipHeading = "";
                  TooltipHeading = "Burger Menu Button";
                  XElement burger_tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip");
                  burger_tooltip.SetAttributeValue("heading", TooltipHeading);
                  burger_tooltip.Value = "ToolTip";

                  XElement burger_disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
                  burger_tooltip.Add(burger_disabledText);
                  //add the tooltip to the button
                  burgerbutton.Add(burger_tooltip);
                  //add the button to the controls collection
                  controls.Add(burgerbutton);

                  //Create Burger button reference (for menu )
                  XElement burgerbuttonRef = new XElement(DAMLHelper.DefaultNS + "button");
                  burgerbuttonRef.SetAttributeValue("refID", BurgerBtnID);
                  //Add burger button reference to menu
                  menu.Add(burgerbuttonRef);
                }

                helper.SaveConfigXML(configXML.ToString());
            }
            return true;
        }

        public List<AddinViewModelBase> ReturnPages(ProjectHelper helper) {
            _vm = new DockPaneViewModel(helper);
            return new List<AddinViewModelBase>() { _vm };
        }

        public void BeforeWizardOpens( ProjectHelper helper) {

          //set some defaults
          helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
          helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);

          //This is the ID for the dockpane button
          helper.ReplacementsDictionary["$dockpanebuttonid$"] = helper.ReplacementsDictionary["$controlid$"] + "_ShowButton";
          helper.ReplacementsDictionary["$burgermenuid$"] = helper.ReplacementsDictionary["$controlid$"] + "_Menu";
          helper.ReplacementsDictionary["$burgermenubuttonid$"] = helper.ReplacementsDictionary["$burgermenuid$"] + "Button";

          //"DockPaneView" class name
          helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
          //"DockPaneViewModel" class name
          helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";
          //"DockPaneShowButton" class name
          helper.ReplacementsDictionary["$showbuttonclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "_ShowButton";
          //"DockPaneBurgerMenuButton" class name
          helper.ReplacementsDictionary["$burgermenubuttonclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "_MenuButton";

          helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
          helper.ReplacementsDictionary["$dockwith$"] = Defaults.DockWithOptionsMap.Keys.First();
          helper.ReplacementsDictionary["$dockoption$"] = Defaults.DockMap.Keys.First();

        }

        public void WizardFinished(ProjectHelper helper, bool cancelled) {
            if (!cancelled) {
 
                //Make sure user choices get applied
                if (!helper.ReplacementsDictionary.ContainsKey("$dockwith$") || helper.ReplacementsDictionary["$dockwith$"].Length == 0)
                {
                    helper.ReplacementsDictionary["$dockwith$"] = Defaults.DockWithOptionsMap.Keys.First();
                }
                if (!helper.ReplacementsDictionary.ContainsKey("$dockoption$") || helper.ReplacementsDictionary["$dockoption$"].Length == 0)
                {
                    helper.ReplacementsDictionary["$dockoption$"] = Defaults.DockMap.Keys.First();
                }
                //were any images picked by the user?
                foreach(var img in new string[] {"16","32"}) {
                    string imageKey = string.Format("$image{0}$",img) ;
                    string defaultImageKey = string.Format("$defaultimage{0}$",img) ;
                    if (!helper.ReplacementsDictionary.ContainsKey(imageKey)) {
                        //add in default
                        helper.ReplacementsDictionary.Add(imageKey, helper.ReplacementsDictionary[defaultImageKey]);
                    }
                    else {
                        //user made a selection, save it
                        helper.UserSelectedImages.Add(helper.ReplacementsDictionary[imageKey]);
                        //truncate
                        helper.ReplacementsDictionary[imageKey] = System.IO.Path.GetFileName(helper.ReplacementsDictionary[imageKey]);
                    }
                }

                //was anything blanked out?
                if (helper.ReplacementsDictionary["$caption$"].Length == 0) {
                    helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
                }
            }
            
        }

        public override void RunFinished() {
            _vm = null;
        }
    }
}
