using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EnvDTE;
using proapp_sdk_Wizard.Helpers;

namespace proapp_sdk_Wizard.ConfigureAddins {
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
