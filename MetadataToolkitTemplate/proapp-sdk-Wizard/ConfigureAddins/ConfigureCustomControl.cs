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

    internal class ConfigureCustomControl : ConfigureControlBase, IWizardConfig {

      private PaneViewModel _vm = null;

      public override void RunStarted(ProjectHelper helper)
      {
        //set some defaults
        helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
        helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);
        helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];

        //"CustomControlView" class name
        helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
        //"CustomControlViewModel" class name
        helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";

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

              //get the controls collection
              //if not found, add it
              XElement controls = configXML.GetControlsElement(true);

              //create the button
              XElement control = new XElement(DAMLHelper.DefaultNS + "customControl");
              control.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);
              control.SetAttributeValue("caption", helper.ReplacementsDictionary["$caption$"]);

              //Test if the controls's namespace is the same as the default namespace in the config, if they are not we need to use the fully qualified class name
              helper.ReplacementsDictionary["$defaultNamespace$"] = configXML.GetDefaultNamespace();
              if (helper.ReplacementsDictionary["$rootnamespace$"] != helper.ReplacementsDictionary["$defaultNamespace$"])
              {
                helper.ReplacementsDictionary["$viewmodelclass$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$viewmodelclass$"]);
                helper.ReplacementsDictionary["$viewclass$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$viewclass$"]);
              }
              control.SetAttributeValue("className", helper.ReplacementsDictionary["$viewmodelclass$"]);
              control.SetAttributeValue("loadOnClick", "true");
              control.SetAttributeValue("smallImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image16$"]));
              control.SetAttributeValue("largeImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image32$"]));

              //content
              XElement content = new XElement(DAMLHelper.DefaultNS + "content");
              content.SetAttributeValue("className", helper.ReplacementsDictionary["$viewclass$"]);
              //add the content to the control
              control.Add(content);

              //tooltip
              XElement tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip");
              tooltip.SetAttributeValue("heading", "Tooltip Heading");
              tooltip.Value = "Tooltip text";

              XElement disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
              tooltip.Add(disabledText);
              //add the tooltip to the control
              control.Add(tooltip);
              //add the control to the controls collection
              controls.Add(control);

              //Add the control to a group that has the addintab true attribute set
              XElement group = configXML.GetGroupElement(helper, true, true);
              //create the control element to be added
              control = new XElement(DAMLHelper.DefaultNS + "customControl");
              control.SetAttributeValue("refID", helper.ReplacementsDictionary["$controlid$"]);
              control.SetAttributeValue("size", "large");
              group.Add(control);

              helper.SaveConfigXML(configXML.ToString());
      }
          return true;
      }

      public List<AddinViewModelBase> ReturnPages(ProjectHelper helper)
      {
        _vm = new PaneViewModel(helper);
        return new List<AddinViewModelBase>() { _vm };
      }

      public void BeforeWizardOpens( ProjectHelper helper) {

          //set some defaults
          helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
          helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
          helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);

          //"CustomControlView" class name
          helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
          //"CustomControlViewModel" class name
          helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";
      }

      public void WizardFinished(ProjectHelper helper, bool cancelled) {
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

      public override void RunFinished() {
          _vm = null;
      }
    }
}
