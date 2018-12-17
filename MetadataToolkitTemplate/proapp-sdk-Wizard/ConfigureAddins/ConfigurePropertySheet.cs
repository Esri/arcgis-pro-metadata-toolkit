using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using metadata_toolkit_wizard.Helpers;
using metadata_toolkit_wizard.ViewModel;
using EnvDTE;
using System.Xml.Linq;

namespace metadata_toolkit_wizard.ConfigureAddins
{
    internal class ConfigurePropertySheet : ConfigureControlBase, IWizardConfig
    {

        private PropertyPageViewModel _vm = null;

        public override void RunStarted(ProjectHelper helper)
        {
            //set some defaults
            helper.ReplacementsDictionary["$sheetid$"] = helper.GenerateID().Replace("Page", "Sheet");
            helper.ReplacementsDictionary["$pageid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$sheetcaption$"] = helper.MakeCaption(helper.BaseNameAndId).Replace("Page", "Sheet");
            helper.ReplacementsDictionary["$pagecaption$"] = helper.MakeCaption(helper.BaseNameAndId);


            helper.ReplacementsDictionary["$propertysheetbuttonid$"] = helper.ReplacementsDictionary["$sheetid$"] + "_ShowPropertySheet";

            //"PropertyPage" class name
            helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
            //"PropertyPageViewModel" class name
            helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";
            //"PropertySheetShowButton" class name
            helper.ReplacementsDictionary["$showbuttonclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "_ShowButton";


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
            if (projectItem.Name.CompareTo(helper.ReplacementsDictionary["$viewmodelclass$"] + language) == 0)
            {
                //yes....first, add in any user selected images
                foreach (var imageFile in helper.UserSelectedImages)
                {
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
                }

                //get the propertysheets element
                //if not found, add it
                XElement propertySheets = configXML.GetPropertySheetsElement(true);

                //create the sheet element
                XElement sheetElement = new XElement(DAMLHelper.DefaultNS + "insertSheet");
                sheetElement.SetAttributeValue("id", helper.ReplacementsDictionary["$sheetid$"]);
                sheetElement.SetAttributeValue("caption", helper.ReplacementsDictionary["$sheetcaption$"]);
                sheetElement.SetAttributeValue("hasGroups", "true");

                //page
                XElement pageElement = new XElement(DAMLHelper.DefaultNS + "page");
                pageElement.SetAttributeValue("id", helper.ReplacementsDictionary["$pageid$"]);
                pageElement.SetAttributeValue("caption", helper.ReplacementsDictionary["$pagecaption$"]);
                pageElement.SetAttributeValue("className", helper.ReplacementsDictionary["$viewmodelclass$"]);
                pageElement.SetAttributeValue("group", helper.ReplacementsDictionary["$groupcaption$"]);

                // page content
                XElement pageContent = new XElement(DAMLHelper.DefaultNS + "content");
                pageContent.SetAttributeValue("className", helper.ReplacementsDictionary["$viewclass$"]);

                //add the content to the page
                pageElement.Add(pageContent);
                //add the page to the sheet
                sheetElement.Add(pageElement);
                // add the new sheet into the sheet collection
                propertySheets.Add(sheetElement);

                helper.SaveConfigXML(configXML.ToString());

                //get the controls collection
                //if not found, add it
                XElement controls = configXML.GetControlsElement(true);

                //create the show property sheet button
                XElement button = new XElement(DAMLHelper.DefaultNS + "button");
                button.SetAttributeValue("id", helper.ReplacementsDictionary["$propertysheetbuttonid$"]);
                button.SetAttributeValue("caption", "Show " + helper.ReplacementsDictionary["$sheetcaption$"]);
                button.SetAttributeValue("className", helper.ReplacementsDictionary["$showbuttonclass$"]);
                button.SetAttributeValue("loadOnClick", "true");
                button.SetAttributeValue("smallImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image16$"]));
                button.SetAttributeValue("largeImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image32$"]));

                //Tooltip
                XElement tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip");
                tooltip.SetAttributeValue("heading", helper.ReplacementsDictionary["$showbutton_tooltip_heading$"]);
                tooltip.Value = helper.ReplacementsDictionary["$showbutton_tooltip_heading$"];

                XElement disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
                tooltip.Add(disabledText);
                //add the tooltip to the button
                button.Add(tooltip);
                controls.Add(button);

                //Add the button to a group that has the addintab true attribute set
                XElement group = configXML.GetGroupElement(helper, true, true);
                //create the button element to be added
                button = new XElement(DAMLHelper.DefaultNS + "button");
                button.SetAttributeValue("refID", helper.ReplacementsDictionary["$propertysheetbuttonid$"]);
                button.SetAttributeValue("size", "large");
                group.Add(button);

                helper.SaveConfigXML(configXML.ToString());

            }
            return true;
        }

        public List<AddinViewModelBase> ReturnPages(ProjectHelper helper)
        {
            _vm = new PropertyPageViewModel(helper);
            return new List<AddinViewModelBase>() { _vm };
        }

        public void BeforeWizardOpens(ProjectHelper helper)
        {
            //set some defaults
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];

            //"PropertyPageView" class name
            helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
            //"PropertyPageViewViewModel" class name
            helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";
        }

        public void WizardFinished(ProjectHelper helper, bool cancelled)
        {
            //were any images picked by the user?
            foreach (var img in new string[] { "16", "32" })
            {
                string imageKey = string.Format("$image{0}$", img);
                string defaultImageKey = string.Format("$defaultimage{0}$", img);
                if (!helper.ReplacementsDictionary.ContainsKey(imageKey))
                {
                    //add in default
                    helper.ReplacementsDictionary.Add(imageKey, helper.ReplacementsDictionary[defaultImageKey]);
                }
                else
                {
                    //user made a selection, save it
                    helper.UserSelectedImages.Add(helper.ReplacementsDictionary[imageKey]);
                    //truncate
                    helper.ReplacementsDictionary[imageKey] = System.IO.Path.GetFileName(helper.ReplacementsDictionary[imageKey]);
                }
            }

            //was anything blanked out?
            if (helper.ReplacementsDictionary["$caption$"].Length == 0)
            {
                helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
            }
        }

        public override void RunFinished()
        {
            _vm = null;
        }
    }
}
