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

namespace metadata_toolkit_wizard.ConfigureAddins {

    internal class ConfigureEmbeddableControl : ConfigureControlBase, IWizardConfig {

      private PaneViewModel _vm = null;

      public override void RunStarted(ProjectHelper helper)
      {
        //set some defaults
        helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
        helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];

        //"EmbeddableControlView" class name
        helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
        //"EmbeddableControlViewModel" class name
        helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";
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
              }

              //get the categories element
              //if not found, add it
              XElement category = configXML.GetEmbeddableControlsUpdateCategory(true);

              //create the embeddable control
              XElement control = new XElement(DAMLHelper.DefaultNS + "insertComponent");
              control.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);
              control.SetAttributeValue("className", helper.ReplacementsDictionary["$viewmodelclass$"]);
               
              //content
              XElement content = new XElement(DAMLHelper.DefaultNS + "content") ;
              content.SetAttributeValue("className", helper.ReplacementsDictionary["$viewclass$"]);
              //add the content to the control
              control.Add(content);
              //add the component to the category
              category.Add(control);

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

          //"EmbeddableControlView" class name
          helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
          //"EmbeddableControlViewModel" class name
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
