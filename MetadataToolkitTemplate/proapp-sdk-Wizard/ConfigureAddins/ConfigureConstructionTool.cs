﻿using System;
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

    internal class ConfigureConstructionTool : ConfigureControlBase {

      public override void RunStarted(Helpers.ProjectHelper helper)
      {
        //set some defaults
        helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
        helper.ReplacementsDictionary["$caption$"] = helper.MakeCaption(helper.BaseNameAndId);

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
          //now handle the DAML
          XDocument configXML = helper.GetConfigXml(projectItem.ContainingProject);
          helper.ReplacementsDictionary["$defaultNamespace$"] = configXML.GetDefaultNamespace(); 

          //get the controls collection
          //if not found, add it
          XElement controls = configXML.GetControlsElement(true);

          XElement tool = new XElement(DAMLHelper.DefaultNS + "tool");
          tool.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);
          tool.SetAttributeValue("categoryRefID", "esri_editing_construction_point");
          tool.SetAttributeValue("caption", helper.ReplacementsDictionary["$caption$"]);
          
          //Test if the button's namespace is the same as the default namespace in the config, if they are not we need to use the fully qualified class name
          if (helper.ReplacementsDictionary["$rootnamespace$"] != helper.ReplacementsDictionary["$defaultNamespace$"])
              helper.ReplacementsDictionary["$addinclassname$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$addinclassname$"]);
          tool.SetAttributeValue("className", helper.ReplacementsDictionary["$addinclassname$"]);
          tool.SetAttributeValue("loadOnClick", "true");
          tool.SetAttributeValue("smallImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image16$"]));
          tool.SetAttributeValue("largeImage", System.IO.Path.Combine(ImageHelper.DefaultImageFolderName, helper.ReplacementsDictionary["$image32$"]));
          //condition
          //if (helper.ReplacementsDictionary.ContainsKey("$controlcondition$")) {
          //    tool.SetAttributeValue("condition", helper.ReplacementsDictionary["$controlcondition$"]);
          //}
          //Tooltip
          XElement tooltip = new XElement(DAMLHelper.DefaultNS + "tooltip") ;
          tooltip.SetAttributeValue("heading", "Tooltip Heading");
          tooltip.Value = "Tooltip text";

          XElement disabledText = new XElement(DAMLHelper.DefaultNS + "disabledText");
          //content removed to fix issue #336
          //XElement content = new XElement(DAMLHelper.DefaultNS + "content");
            //content.SetAttributeValue("guid", Guid.NewGuid());
          //content.SetAttributeValue("group", "esri_editing_construction_point");

          //Create comments
          XComment commentTool = new XComment("note: use esri_editing_construction_polyline,  esri_editing_construction_polygon for categoryRefID as needed");
          tool.Add(commentTool);

          tooltip.Add(disabledText);
          //add the tooltip to the tool
          tool.Add(tooltip) ;
          //add the content to the tool
          // removed to fix issue #336
          // tool.Add(content);

          //Create comments
          // removed to due to fix issue #336
          //XComment commentContent = new XComment("note: use esri_editing_EditTools_POLYLINE_Tools,  esri_editing_construction_polygon_Tools for group as needed");
          //tool.Add(commentContent);

          //add the tool to the controls collection
          controls.Add(tool) ;

          helper.SaveConfigXML(configXML.ToString());
        }
        return true;
      }
    }
}
