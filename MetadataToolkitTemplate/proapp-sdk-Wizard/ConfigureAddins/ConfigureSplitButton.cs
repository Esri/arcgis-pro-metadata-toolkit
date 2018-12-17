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

    internal class ConfigureSplitButton : ConfigureControlBase, IWizardConfig
    {

        private SplitButtonViewModel _vm = null;

        public override void RunStarted(ProjectHelper helper)
        {
            //set some defaults
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
            //Set ID for Buttons in the split button
            helper.ReplacementsDictionary["$splitbuttonid$"] = String.Join("_", helper.ReplacementsDictionary["$controlid$"], "Items");
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

                //Get the splitButtons collection
                //if not found, add it
                XElement splitButtons = configXML.GetSplitButtonsElement(true);
                //create splitButton
                XElement splitButton = new XElement(DAMLHelper.DefaultNS + "splitButton");
                splitButton.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);

                //get the controls collection
                //if not found, add it
                XElement controls = configXML.GetControlsElement(true);

                //loop to create 3 buttons. Add them to the Controls collection.
                //Creating and adding buttons for splitButtons menus
                for (int i = 0; i < 3; i++)
                {
                    string SplitBtnID = "";
                    string SplitBtnClass = "";
                    string SplitBtnCaption = "";
                    SplitBtnID = string.Format("{0}_Button{1}", helper.ReplacementsDictionary["$splitbuttonid$"], (i + 1).ToString());
                    SplitBtnClass = string.Format("{0}_button{1}", helper.ReplacementsDictionary["$addinclassname$"], (i + 1).ToString());
                    SplitBtnCaption = string.Format("{0} {1}", helper.ReplacementsDictionary["$addinclassname$"], (i + 1).ToString());

                    XElement Splitbutton = new XElement(DAMLHelper.DefaultNS + "button");
                    Splitbutton.SetAttributeValue("id", SplitBtnID);
                    Splitbutton.SetAttributeValue("caption", SplitBtnCaption);
                    //Test if the button's namespace is the same as the default namespace in the config, if they are not we need to use the fully qualified class name
                    if (helper.ReplacementsDictionary["$rootnamespace$"] != helper.ReplacementsDictionary["$defaultNamespace$"])
                        SplitBtnClass = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], SplitBtnClass);
                    Splitbutton.SetAttributeValue("className", SplitBtnClass);
                    Splitbutton.SetAttributeValue("loadOnClick", "true");
                    Splitbutton.SetAttributeValue("smallImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image16$"]));
                    Splitbutton.SetAttributeValue("largeImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image32$"]));

                    //Tooltip
                    string TooltipHeading = "";
                    TooltipHeading = string.Format("Split Button {0}", (i + 1).ToString());
                    XElement Split_tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip");
                    Split_tooltip.SetAttributeValue("heading", TooltipHeading);
                    Split_tooltip.Value = "ToolTip";

                    XElement Split_disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
                    Split_tooltip.Add(Split_disabledText);
                    //add the tooltip to the button
                    Splitbutton.Add(Split_tooltip);
                    //add the button to the controls collection
                    controls.Add(Splitbutton);

                    //Create Split button reference (Under SplitButton)
                    XElement SplitbuttonRef = new XElement(DAMLHelper.DefaultNS + "button");
                    SplitbuttonRef.SetAttributeValue("refID", SplitBtnID);
                    //Add Split button reference
                    splitButton.Add(SplitbuttonRef);
                }

                //Add splitButton to splitButtons
                splitButtons.Add(splitButton);

                //Add the split button to a group that has the addintab true attribute set
                XElement group = configXML.GetGroupElement(helper, true, true);
                //create the button element to be added
                XElement splitButtonRef = new XElement(DAMLHelper.DefaultNS + "splitButton");
                splitButtonRef.SetAttributeValue("refID", helper.ReplacementsDictionary["$controlid$"]);
                group.Add(splitButtonRef);

                helper.SaveConfigXML(configXML.ToString());
            }
            return true;
        }

        public List<AddinViewModelBase> ReturnPages(ProjectHelper helper)
        {
            _vm = new SplitButtonViewModel(helper);
            return new List<AddinViewModelBase>() { _vm };
        }

        public void BeforeWizardOpens(ProjectHelper helper)
        {            
            //set some defaults
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
            //Set ID for Buttons in the split button
            helper.ReplacementsDictionary["$splitbuttonid$"] = String.Join("_", helper.ReplacementsDictionary["$controlid$"], "Items");
            //This is the filename for the Button (without the '.cs')
            helper.ReplacementsDictionary["$addinclassname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
        }

        public void WizardFinished(ProjectHelper helper, bool cancelled)
        {
            if (!cancelled)
            {
                //Make sure user choices get applied


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

        public override void RunFinished()
        {
            _vm = null;
        }
    }
}
