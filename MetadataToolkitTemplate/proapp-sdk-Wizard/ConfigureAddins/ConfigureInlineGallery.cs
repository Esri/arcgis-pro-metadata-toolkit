using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using EnvDTE;
using proapp_sdk_Wizard.Helpers;
using proapp_sdk_Wizard.ViewModel;

namespace proapp_sdk_Wizard.ConfigureAddins {

    internal class ConfigureInlineGallery : ConfigureControlBase, IWizardConfig {

        private GalleryViewModel _vm = null;

        public override void RunStarted(ProjectHelper helper)
        {
            //set some defaults
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
            //This is the filename for the Button (without the '.cs')
            helper.ReplacementsDictionary["$addinclassname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$addinitemtemplatename$"] = helper.ReplacementsDictionary["$safeitemname$"] + "Template.xaml";
            helper.ReplacementsDictionary["$controlitemsperrow$"] = "3";
            //helper.ReplacementsDictionary["$controlcondition$"] = Defaults.ConditionMap.Keys.First();
            foreach (var img in new string[] { "16", "32" })
            {
                string imageKey = string.Format("$image{0}$", img);
                string defaultImageKey = string.Format("$defaultimage{0}$", img);
                if (!helper.ReplacementsDictionary.ContainsKey(imageKey))
                {
                    //add in default
                    helper.ReplacementsDictionary.Add(imageKey, helper.ReplacementsDictionary[defaultImageKey]);
                }
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
            if (projectItem.Name.CompareTo(helper.ReplacementsDictionary["$addinitemname$"] + language) == 0)
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
                helper.ReplacementsDictionary["$defaultAssembly$"] = configXML.GetDefaultAssembly();
                helper.ReplacementsDictionary["$relativePath$"] = helper.GetRelativePathToProjectItem(projectItem);

                //get the galleries collection
                //if not found, add it
                XElement controls = configXML.GetGalleriesElement(true);

                //create the item
                XElement item = new XElement(DAMLHelper.DefaultNS + "gallery");
                item.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);
                item.SetAttributeValue("caption", helper.ReplacementsDictionary["$caption$"]);

                //Test if the button's namespace is the same as the default namespace in the config, if they are not we need to use the fully qualified class name
                if (helper.ReplacementsDictionary["$rootnamespace$"] != helper.ReplacementsDictionary["$defaultNamespace$"])
                    helper.ReplacementsDictionary["$addinclassname$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$addinclassname$"]);
                item.SetAttributeValue("className", helper.ReplacementsDictionary["$addinclassname$"]);           
                item.SetAttributeValue("itemsInRow", helper.ReplacementsDictionary["$controlitemsperrow$"]);
                item.SetAttributeValue("dataTemplateFile", "pack://application:,,,/" + helper.ReplacementsDictionary["$defaultAssembly$"] +
                                        ";component/" + helper.ReplacementsDictionary["$relativePath$"] + helper.ReplacementsDictionary["$addinitemtemplatename$"]);
                item.SetAttributeValue("templateID", helper.ReplacementsDictionary["$addinitemname$"] + "ItemTemplate");
                item.SetAttributeValue("resizable", "true");
                item.SetAttributeValue("largeImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image32$"]));
                //condition
                //if (helper.ReplacementsDictionary.ContainsKey("$controlcondition$")) {
                //  item.SetAttributeValue("condition", helper.ReplacementsDictionary["$controlcondition$"]);
                //}
                //Tooltip
                XElement tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip") ;
                tooltip.SetAttributeValue("heading", "Tooltip Heading");
                tooltip.Value = "Tooltip text";

                XElement disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
                tooltip.Add(disabledText);
                //add the tooltip to the button
                item.Add(tooltip);
                //add the button to the controls collection
                controls.Add(item);

                //Add the button to a group that has the addintab true attribute set
                XElement group = configXML.GetGroupElement(helper, true, true);
                //create the gallery element to be added
                item = new XElement(DAMLHelper.DefaultNS + "gallery");
                item.SetAttributeValue("refID", helper.ReplacementsDictionary["$controlid$"]);
                item.SetAttributeValue("inline", "true");
                item.SetAttributeValue("size", "large");
                group.Add(item);

                helper.SaveConfigXML(configXML.ToString());
            }
            return true;
        }

        public List<AddinViewModelBase> ReturnPages(ProjectHelper helper)
        {
          _vm = new GalleryViewModel(helper, 6);    // 6 = default items per row
          return new List<AddinViewModelBase>() { _vm };
        }

        public void BeforeWizardOpens( ProjectHelper helper) {

            //set some defaults
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
            //This is the filename for the Button (without the '.cs')
            helper.ReplacementsDictionary["$addinclassname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$addinitemtemplatename$"] = helper.ReplacementsDictionary["$safeitemname$"] + "Template.xaml";
        }

        public void WizardFinished(ProjectHelper helper, bool cancelled) {
            if (!cancelled) {
                //Make sure user choices get applied
                if (!helper.ReplacementsDictionary.ContainsKey("$controlcondition$") || helper.ReplacementsDictionary["$controlcondition$"].Length == 0) {
                    helper.ReplacementsDictionary["$controlcondition$"] = Defaults.ConditionMap.Keys.First();
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

                // set default for ItemsPerRow
                if (helper.ReplacementsDictionary["$controlitemsperrow$"].Length == 0) {
                    helper.ReplacementsDictionary["$controlitemsperrow$"] = "3";
                }
            }
            
        }

        public override void RunFinished() {
            _vm = null;
        }
    }
}
