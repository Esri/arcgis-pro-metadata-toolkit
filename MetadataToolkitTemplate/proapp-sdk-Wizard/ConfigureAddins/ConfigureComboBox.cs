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

    internal class ConfigureComboBox : ConfigureControlBase {

        public override void RunStarted(ProjectHelper helper)
        {
            //set some defaults         
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
            //This is the filename for the ComboBox (without the '.cs' or '.vb')
            helper.ReplacementsDictionary["$addinclassname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            //helper.ReplacementsDictionary["$controlcondition$"] = Defaults.ConditionMap.Keys.First();
       }

        public override bool ProjectItemFinishedGenerating(ProjectHelper helper, ProjectItem projectItem) {
            if (base.ProjectItemFinishedGenerating(helper, projectItem))
                return true;
            string filePath = projectItem.Name;
            //we have to handle these ones
            string ext = System.IO.Path.GetExtension(filePath);
            //is this the default addin file?
            string language = helper.ReplacementsDictionary["language"];
            if (projectItem.Name.CompareTo(helper.ReplacementsDictionary["$addinitemname$"] + language) == 0) {               
                //yes....first, add in any user selected images
                foreach (var imageFile in helper.UserSelectedImages) {
                    //add them to the project
                    ImageHelper.AddImageFile(projectItem.ContainingProject, imageFile, true);
                }
                helper.UserSelectedImages.Clear();
                //now handle the DAML
                XDocument configXML = helper.GetConfigXml(projectItem.ContainingProject);
                helper.ReplacementsDictionary["$defaultNamespace$"] = configXML.GetDefaultNamespace();               
                
                //get the controls collection
                //if not found, add it
                XElement controls = configXML.GetControlsElement(true);

                //create the ComboBox
                XElement comboBox = new XElement(DAMLHelper.DefaultNS + "comboBox");
                comboBox.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);
                comboBox.SetAttributeValue("caption", helper.ReplacementsDictionary["$caption$"]);

                //Test if the comboBox's namespace is the same as the default namespace in the config, if they are not we need to use the fully qualified class name
                if (helper.ReplacementsDictionary["$rootnamespace$"] != helper.ReplacementsDictionary["$defaultNamespace$"])
                    helper.ReplacementsDictionary["$addinclassname$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$addinclassname$"]);
                comboBox.SetAttributeValue("className", helper.ReplacementsDictionary["$addinclassname$"]);
                
                //condition
                //if (helper.ReplacementsDictionary.ContainsKey("$controlcondition$")) {
                //    comboBox.SetAttributeValue("condition", helper.ReplacementsDictionary["$controlcondition$"]);
                //}

                comboBox.SetAttributeValue("itemWidth", "140");
                comboBox.SetAttributeValue("extendedCaption", "Extended Caption");
                comboBox.SetAttributeValue("isEditable", "false");
                comboBox.SetAttributeValue("isReadOnly", "true");
                comboBox.SetAttributeValue("resizable", "true");

                //Tooltip
                XElement tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip") ;
                tooltip.SetAttributeValue("heading", "Tooltip Heading");
                tooltip.Value = "Tooltip text";

                XElement disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
                tooltip.Add(disabledText);
                //add the tooltip to the comboBox
                comboBox.Add(tooltip);
                //add the comboBox to the controls collection
                controls.Add(comboBox);

                //Add the comboBox to a group that has the addintab true attribute set
                XElement group = configXML.GetGroupElement(helper, true, true);
                //create the comboBox element to be added
                comboBox = new XElement(DAMLHelper.DefaultNS + "comboBox");
                comboBox.SetAttributeValue("refID", helper.ReplacementsDictionary["$controlid$"]);
                group.Add(comboBox);

                helper.SaveConfigXML(configXML.ToString());
            }
            return true;
        }

       
        public void BeforeWizardOpens( ProjectHelper helper) {

            //set some defaults
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
            //This is the filename for the Button (without the '.cs')
            helper.ReplacementsDictionary["$addinclassname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
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
            }
            
        }

        public override void RunFinished() {
            //final cleanup
        }
    }
}
