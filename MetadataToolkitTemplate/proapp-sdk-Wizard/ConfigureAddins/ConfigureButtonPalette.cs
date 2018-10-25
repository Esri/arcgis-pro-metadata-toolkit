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

namespace proapp_sdk_Wizard.ConfigureAddins
{

    internal class ConfigureButtonPalette : ConfigureControlBase, IWizardConfig
    {

        private ButtonPaletteViewModel _vm = null;

        public override void RunStarted(ProjectHelper helper)
        {
            //set some defaults
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
            //Set ID for Buttons in the palette
            helper.ReplacementsDictionary["$buttonpaletteid$"] = String.Join("_", helper.ReplacementsDictionary["$controlid$"], "Items");
            //This is the filename for the Button (without the '.cs')
            helper.ReplacementsDictionary["$addinclassname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$menustyle$"] = "true";
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

                //Get the Palettes collection
                //if not found, add it
                XElement palettes = configXML.GetPalettesElement(true);
                //create buttonPalette
                XElement buttonPalette = new XElement(DAMLHelper.DefaultNS + "buttonPalette");
                buttonPalette.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);
                //buttonPalette.SetAttributeValue("caption", "Button Palette" + helper.BaseNameAndId.Item2);
                buttonPalette.SetAttributeValue("caption", helper.ReplacementsDictionary["$addinclassname$"]);
                
                buttonPalette.SetAttributeValue("dropDown", "false");
                buttonPalette.SetAttributeValue("menuStyle", helper.ReplacementsDictionary["$menustyle$"]);                

                //get the controls collection
                //if not found, add it
                XElement controls = configXML.GetControlsElement(true);

                //loop to create 3 buttons. Add them to the Controls collection.
                //Creating and adding buttons for palette menus
                for (int i = 0; i < 3; i++)
                {
                    string PaletteBtnID = "";
                    string PaletteBtnClass = "";
                    string PaletteBtnCaption = "";
                    PaletteBtnID = string.Format("{0}_Button{1}", helper.ReplacementsDictionary["$buttonpaletteid$"], (i + 1).ToString());
                    PaletteBtnClass = string.Format("{0}_button{1}", helper.ReplacementsDictionary["$addinclassname$"], (i + 1).ToString());
                    PaletteBtnCaption = string.Format("Palette Button {0}", (i + 1).ToString());

                    XElement Palettebutton = new XElement(DAMLHelper.DefaultNS + "button");
                    Palettebutton.SetAttributeValue("id", PaletteBtnID);
                    Palettebutton.SetAttributeValue("caption", PaletteBtnCaption);
                    //Test if the button's namespace is the same as the default namespace in the config, if they are not we need to use the fully qualified class name
                    if (helper.ReplacementsDictionary["$rootnamespace$"] != helper.ReplacementsDictionary["$defaultNamespace$"])
                        PaletteBtnClass = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], PaletteBtnClass);
                    Palettebutton.SetAttributeValue("className", PaletteBtnClass);
                    Palettebutton.SetAttributeValue("loadOnClick", "true");
                    Palettebutton.SetAttributeValue("smallImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image16$"]));
                    Palettebutton.SetAttributeValue("largeImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image32$"]));

                    //Tooltip
                    string TooltipHeading = "";
                    TooltipHeading = string.Format("Palette Button {0}", (i + 1).ToString());
                    XElement Palette_tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip");
                    Palette_tooltip.SetAttributeValue("heading", TooltipHeading);
                    Palette_tooltip.Value = "ToolTip";

                    XElement Palette_disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
                    Palette_tooltip.Add(Palette_disabledText);
                    //add the tooltip to the button
                    Palettebutton.Add(Palette_tooltip);
                    //add the button to the controls collection
                    controls.Add(Palettebutton);

                    //Create Palette button reference (for buttonPalette)
                    XElement PalettebuttonRef = new XElement(DAMLHelper.DefaultNS + "button");
                    PalettebuttonRef.SetAttributeValue("refID", PaletteBtnID);
                    //Add Palette button reference to buttonPalette
                    buttonPalette.Add(PalettebuttonRef);
                }

                //Add buttonpalette to palettes
                palettes.Add(buttonPalette);

                //Add the buttonPalette to a group that has the addintab true attribute set
                XElement group = configXML.GetGroupElement(helper, true, true);
                //create the button element to be added
                XElement buttonPaletteRef = new XElement(DAMLHelper.DefaultNS + "buttonPalette");
                buttonPaletteRef.SetAttributeValue("refID", helper.ReplacementsDictionary["$controlid$"]);
                group.Add(buttonPaletteRef);

                helper.SaveConfigXML(configXML.ToString());
            }
            return true;
        }

        public List<AddinViewModelBase> ReturnPages(ProjectHelper helper)
        {
            _vm = new ButtonPaletteViewModel(helper);
            return new List<AddinViewModelBase>() { _vm };
        }

        public void BeforeWizardOpens(ProjectHelper helper)
        {            
            //set some defaults
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
            //Set ID for Buttons in the palette
            helper.ReplacementsDictionary["$buttonpaletteid$"] = String.Join("_", helper.ReplacementsDictionary["$controlid$"], "Items");
            //This is the filename for the Button (without the '.cs')
            helper.ReplacementsDictionary["$addinclassname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
        }

        public void WizardFinished(ProjectHelper helper, bool cancelled)
        {
            if (!cancelled)
            {
                //Make sure user choices get applied
                if (!helper.ReplacementsDictionary.ContainsKey("$menustyle$") || helper.ReplacementsDictionary["$menustyle$"].Length == 0)
                {
                    helper.ReplacementsDictionary["$menustyle$"] = "true";
                }

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
