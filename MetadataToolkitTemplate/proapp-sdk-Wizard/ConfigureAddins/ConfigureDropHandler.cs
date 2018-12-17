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

    internal class ConfigureDropHandler : ConfigureControlBase 
    {
        public override void RunStarted(ProjectHelper helper)
        {
            //set some defaults         
            helper.ReplacementsDictionary["$controlid$"] = helper.GenerateID();
            //This is the filename for the Button (without the '.cs' or '.vb')
            helper.ReplacementsDictionary["$addinclassname$"] = helper.ReplacementsDictionary["$safeitemname$"];
            helper.ReplacementsDictionary["$addinitemname$"] = helper.ReplacementsDictionary["$safeitemname$"];
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
                //Handle the DAML
                XDocument configXML = helper.GetConfigXml(projectItem.ContainingProject);
                helper.ReplacementsDictionary["$defaultNamespace$"] = configXML.GetDefaultNamespace();               
                
                //get the dropHanlders collection
                //if not found, add it
                XElement dropHandlers = configXML.GetDropHandlersElement(true);

                //Create comments
                XComment commentDropHandler = new XComment("specific file extensions can be set like so: dataTypes=\".XLS|.xls\"");
                dropHandlers.Add(commentDropHandler);

                //create the insertHandler
                XElement insertHandler = new XElement(DAMLHelper.DefaultNS + "insertHandler");
                insertHandler.SetAttributeValue("id", helper.ReplacementsDictionary["$controlid$"]);
                //Test if the button's namespace is the same as the default namespace in the config, if they are not we need to use the fully qualified class name
                if (helper.ReplacementsDictionary["$rootnamespace$"] != helper.ReplacementsDictionary["$defaultNamespace$"])
                  helper.ReplacementsDictionary["$addinclassname$"] = String.Join(".", helper.ReplacementsDictionary["$rootnamespace$"], helper.ReplacementsDictionary["$addinclassname$"]);
                insertHandler.SetAttributeValue("className", helper.ReplacementsDictionary["$addinclassname$"]);  
                insertHandler.SetAttributeValue("dataTypes", "*");
                
                //add the insertHandler to the dropHandler collection
                dropHandlers.Add(insertHandler);

                helper.SaveConfigXML(configXML.ToString());
            }
            return true;
        }
    }
}
