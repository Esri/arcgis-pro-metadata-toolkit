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

namespace metadata_toolkit_wizard.ConfigureAddins {

    internal class ConfigurePane : ConfigureControlBase, IWizardConfig {

      private PaneViewModel _vm = null;

      public override void RunStarted(ProjectHelper helper)
      {
          //set some defaults
          helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
          helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);

          //This is the ID for the pane button
          helper.ReplacementsDictionary["$panebuttonid$"] = helper.ReplacementsDictionary["$controlid$"] + "_OpenButton";

          helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];

          //"PaneView" class name
          helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
          //"PaneViewModel" class name
          helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";
          //"PaneButton" class name
          helper.ReplacementsDictionary["$buttonclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "_OpenButton";

          helper.ReplacementsDictionary["$controlcondition$"] = Defaults.ConditionMap.Keys.First();

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
                  helper.ReplacementsDictionary["$buttonclass$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$buttonclass$"]);
              }

              //get the controls, panes collection
              //if not found, add it
              XElement controls = configXML.GetControlsElement(true);
              XElement panes = configXML.GetPanesElement(true);

              //create the pane
              XElement pane = new XElement(DAMLHelper.DefaultNS + "pane");
              pane.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);
              pane.SetAttributeValue("caption", helper.ReplacementsDictionary["$caption$"]);
              pane.SetAttributeValue("className", helper.ReplacementsDictionary["$viewmodelclass$"]);
              pane.SetAttributeValue("smallImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image16$"]));
              //pane.SetAttributeValue("isClosable", "true"); this attribute is not available anymore.
              pane.SetAttributeValue("defaultTab", "esri_mapping_homeTab");
              pane.SetAttributeValue("defaultTool", "esri_mapping_navigateTool");
               
              //content
              XElement content = new XElement(DAMLHelper.DefaultNS + "content") ;
              content.SetAttributeValue("className", helper.ReplacementsDictionary["$viewclass$"]);
              //add the content to the pane
              pane.Add(content);
              //add the pane to the panes collection
              panes.Add(pane);

              //create the button
              XElement button = new XElement(DAMLHelper.DefaultNS + "button");
              button.SetAttributeValue("id", helper.ReplacementsDictionary["$panebuttonid$"]);
              button.SetAttributeValue("caption", "Open " + helper.ReplacementsDictionary["$caption$"]);
              button.SetAttributeValue("className", helper.ReplacementsDictionary["$buttonclass$"]);
              button.SetAttributeValue("loadOnClick", "true");
              button.SetAttributeValue("smallImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image16$"]));
              button.SetAttributeValue("largeImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image32$"]));
              //Add condition attribute to the button only if it is a Map Pane impersonation
              if (helper.ReplacementsDictionary["addintype"] == "map_pane_impersonate")
                    button.SetAttributeValue("condition", helper.ReplacementsDictionary["$controlcondition$"]);

                //Tooltip
                XElement tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip");
              tooltip.SetAttributeValue("heading", "Open Pane");
              tooltip.Value = "Open Pane";

              XElement disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
              tooltip.Add(disabledText);
              //add the tooltip to the button
              button.Add(tooltip);
              //add the button to the controls collection
              controls.Add(button);

              //Add the button to a group that has the addintab true attribute set
              XElement group = configXML.GetGroupElement(helper, true, true);
              //create the button element to be added
              button = new XElement(DAMLHelper.DefaultNS + "button");
              button.SetAttributeValue("refID", helper.ReplacementsDictionary["$panebuttonid$"]);
              button.SetAttributeValue("size", "large");
              group.Add(button);

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
          helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);

          //This is the ID for the pane button
          helper.ReplacementsDictionary["$panebuttonid$"] = helper.ReplacementsDictionary["$controlid$"] + "_OpenButton";

          helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];

          //"PaneView" class name
          helper.ReplacementsDictionary["$viewclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "View";
          //"PaneViewModel" class name
          helper.ReplacementsDictionary["$viewmodelclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "ViewModel";
          //"PaneButton" class name
          helper.ReplacementsDictionary["$buttonclass$"] = helper.ReplacementsDictionary["$safeitemname$"] + "_OpenButton";
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
