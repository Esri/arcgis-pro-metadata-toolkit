using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proapp_sdk_Wizard.Helpers;
using proapp_sdk_Wizard.ViewModel;
using EnvDTE;
using System.Xml.Linq;

namespace proapp_sdk_Wizard.ConfigureAddins
{
    class ConfigureBackstageTab : ConfigureControlBase, IWizardConfig
    {
        private PaneViewModel _vm = null;

        public override void RunStarted(ProjectHelper helper)
        {
            //set some defaults
            helper.ReplacementsDictionary["$tabid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$tabbuttonid$"] = helper.GenerateID("Button");
            helper.ReplacementsDictionary["$tabcaption$"] = helper.MakeCaption(helper.BaseNameAndId);

            //"BackstageTab" class name
            helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
            //"BackstageTabViewModel" class name
            helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";
            //"BackstageTabButton" class name
            helper.ReplacementsDictionary["$tabbuttonclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "Button";

            helper.ReplacementsDictionary["$tabbuttoncaption$"] = helper.MakeCaption(helper.ReplacementsDictionary["$tabbuttonclass$"]);

            base.RunStarted(helper);
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
                    helper.ReplacementsDictionary["$tabbuttonclass$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$tabbuttonclass$"]);
                }


                //get the controls collection
                //if not found, add it
                XElement controls = configXML.GetControlsElement(true);

                //create the tab button
                XElement button = new XElement(DAMLHelper.DefaultNS + "button");
                button.SetAttributeValue("id", helper.ReplacementsDictionary["$tabbuttonid$"]);
                button.SetAttributeValue("caption", helper.ReplacementsDictionary["$tabbuttoncaption$"]);
                button.SetAttributeValue("className", helper.ReplacementsDictionary["$tabbuttonclass$"]);
                button.SetAttributeValue("loadOnClick", "true");

                //Tooltip
                XElement tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip");
                tooltip.SetAttributeValue("heading", "BackstageTab Button Heading");
                tooltip.Value = "BackstageTab button tool tip text.";

                XElement disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
                tooltip.Add(disabledText);
                //add the tooltip to the button
                button.Add(tooltip);
                controls.Add(button);

                helper.SaveConfigXML(configXML.ToString());

                //get the backstage element
                //if not found, add it
                XElement backstageElement = configXML.GetBackstageElement(true);

                //create the tab button element - referencing the element created above
                XElement tabButtonElement = new XElement(DAMLHelper.DefaultNS + "insertButton");
                tabButtonElement.SetAttributeValue("refID", helper.ReplacementsDictionary["$tabbuttonid$"]);
                tabButtonElement.SetAttributeValue("insert", "before");
                tabButtonElement.SetAttributeValue("placeWith", "esri_core_exitApplicationButton");
                tabButtonElement.SetAttributeValue("separator", "true");

                // tab element
                XElement tabElement = new XElement(DAMLHelper.DefaultNS + "insertTab");
                tabElement.SetAttributeValue("id", helper.ReplacementsDictionary["$tabid$"]);
                tabElement.SetAttributeValue("caption", helper.ReplacementsDictionary["$tabcaption$"]);
                tabElement.SetAttributeValue("className", helper.ReplacementsDictionary["$viewmodelclass$"]);
                tabElement.SetAttributeValue("insert", "before");
                tabElement.SetAttributeValue("placeWith", "esri_core_exitApplicationButton");

                // tab content
                XElement tabContent = new XElement(DAMLHelper.DefaultNS + "content");
                tabContent.SetAttributeValue("className", helper.ReplacementsDictionary["$viewclass$"]);

                //add the content to the tab
                tabElement.Add(tabContent);

                // add the new tab button to the backstage
                backstageElement.Add(tabButtonElement);
                //add the tab to the backstage
                backstageElement.Add(tabElement);

                helper.SaveConfigXML(configXML.ToString());

            }
            return true;
        }

        public void BeforeWizardOpens(ProjectHelper helper)
        {

            //set some defaults
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];

            //"BackstageTabView" class name
            helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
            //"BackstageTabViewModel" class name
            helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";
        }

        public List<AddinViewModelBase> ReturnPages(ProjectHelper helper)
        {
            _vm = new PaneViewModel(helper);
            return new List<AddinViewModelBase>() { _vm };
        }

        public void WizardFinished(ProjectHelper helper, bool cancelled)
        {
            if (!cancelled)
            {
                //Make sure user choices get applied
                //if (!helper.ReplacementsDictionary.ContainsKey("$controlcondition$") || helper.ReplacementsDictionary["$controlcondition$"].Length == 0)
                //{
                //  helper.ReplacementsDictionary["$controlcondition$"] = Defaults.ConditionMap.Keys.First();
                //}

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
        }
    }
}
