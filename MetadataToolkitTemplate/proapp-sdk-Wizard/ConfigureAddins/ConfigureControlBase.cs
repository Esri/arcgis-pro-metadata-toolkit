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
using EnvDTE;
using metadata_toolkit_wizard.Helpers;

namespace metadata_toolkit_wizard.ConfigureAddins {
    internal class ConfigureControlBase : IAddinConfig {

        public string TemplateType { get; set; }
        public string AddinType { get; set; }
        public virtual bool NeedsWizard { get { return false; } }

        public virtual void RunStarted(ProjectHelper helper) {
            
        }

        public virtual bool ShouldAddProjectItem(ProjectHelper helper, string filePath) {
            bool add = true ;

            string ext = System.IO.Path.GetExtension(filePath);
            string projectFolder = helper.GetProjectDirectoryName(helper.ActiveProjectInSolution);
            string itemName = System.IO.Path.GetFileName(filePath);

            //is this an image?
            if (Defaults.ImageExtensions.Contains(ext.ToLower())) {
                
                //yes. See if it is already in the project.
                if (ImageHelper.ImageExistsInProject(helper.ActiveProjectInSolution, filePath)) {
                    return false;
                }
                //it is not in the project. Add it if we are using default images for the
                //control
                if (filePath.CompareTo(helper.ReplacementsDictionary["$defaultimage16$"]) == 0 ||
                    filePath.CompareTo(helper.ReplacementsDictionary["$defaultimage32$"]) == 0) {
                    //this is one of our default images
                    //see if it is one of the images that should be added. 
                    //add will be TRUE if the user did not pick any images him or
                    //herself on the item wizard
                    add = (filePath.CompareTo(helper.ReplacementsDictionary["$image16$"]) == 0 ||
                       filePath.CompareTo(helper.ReplacementsDictionary["$image32$"]) == 0);
                }
            }
            return add;
        }

        public virtual bool ProjectItemFinishedGenerating(ProjectHelper helper, ProjectItem projectItem) {
            string filePath = projectItem.Name;
            string ext = System.IO.Path.GetExtension(filePath);
            if (Defaults.ImageExtensions.Contains(ext.ToLower()))
                //This is an image AND it must be one of the defaults otherwise
                //Visual Studio would not have invoked this callback
                //Visual Studio will be handling any copy file, config, etc.
                return true;
            return false;
        }

        public virtual void ProjectFinishedGenerating(ProjectHelper helper, Project project) {
            //No-op, will never be called
        }

        public virtual void RunFinished() {
            //final cleanup
        }

    }
}
