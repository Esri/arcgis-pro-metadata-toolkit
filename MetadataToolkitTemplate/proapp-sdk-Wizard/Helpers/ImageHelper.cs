using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;
using VSLangProj80;

namespace proapp_sdk_Wizard.Helpers {
    internal static class ImageHelper {

        //public static readonly string ImageFolderName = "Images";
        public static readonly string DefaultImageFolderName = "Images";

        /// <summary>
        /// Does the image file already exist in the project?
        /// </summary>
        /// <param name="project"></param>
        /// <param name="imageFile"></param>
        /// <returns></returns>
        public static bool ImageExistsInProject(Project project, string imageFile) {
            ProjectItem imagesFolder = null;
            
            string imgFolder = imageFile.StartsWith("DarkImages") ? "DarkImages" : "Images"; //support for dark theme.

            string imageFileName = System.IO.Path.GetFileName(imageFile);

            bool exists = false;
            try {

                imagesFolder = project.ProjectItems.Item(imgFolder);
                foreach (ProjectItem item in imagesFolder.ProjectItems) {
                    if (item.Name.ToLower().CompareTo(imageFileName.ToLower()) == 0) {
                        exists = true;
                        break;
                    }
                }
            }
            catch {
                foreach (ProjectItem item in project.ProjectItems) {
                    if (item.Name.ToLower().CompareTo(imageFileName.ToLower()) == 0) {
                        exists = true;
                        break;
                    }
                }
            }
            return exists;
        }
        /// <summary>
        /// Process the image file to be added to the project
        /// </summary>
        /// <param name="project"></param>
        /// <param name="imageFile"></param>
        /// <param name="addToProject"></param>
        public static void AddImageFile(Project project, string imageFile, bool addToProject = false) {
            if (addToProject) 
                AddUserPickedImageFile(project, imageFile);
            else
                AddDefaultImageFile(project, imageFile);
        }

        private static void AddDefaultImageFile(Project project, string imageFile) {
            //in this scenario we already know that the IDE is handling the image add

            //currently, there is nothing we need to do..
        }

        private static void AddUserPickedImageFile(Project project, string imageFile) {
            ProjectItem imagesFolder = null;
            string imgFolder = imageFile.StartsWith("DarkImages") ? "DarkImages" : "Images";
            try {
                imagesFolder = project.ProjectItems.Item(imgFolder);
            }
            catch {
            }
            if (imagesFolder == null) {
                imagesFolder = project.ProjectItems.AddFolder(imgFolder, "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}");
            }

            var imagesFolderPath = (string)imagesFolder.Properties.Item("FullPath").Value;

            if (File.Exists(imageFile)) {
                //we add it
                string newFileName = System.IO.Path.GetFileName(imageFile);
                newFileName = Path.Combine(imagesFolderPath, newFileName);
                //So, the edge condition here is that the user added the image file to
                //the project then removed it from the project but it is still in the folder
                //on disk...
                //the file exists and so the copy is not performed AND...the item is not
                //added into the project. The user thinks his or her image, therefore, was
                //not copied over because of some bug or what not in the wizard.....
                if (!File.Exists(newFileName)) {
                    File.Copy(imageFile, newFileName, true);
                    // Add it to the project
                    ProjectItem imageItem = imagesFolder.ProjectItems.AddFromFile(newFileName);
                    imageItem.Properties.Item("ItemType").Value = "AddInContent";
                    SetCopyToOutPut(imageItem, "none");
                }
            }
        }

        private static void SetCopyToOutPut(ProjectItem pi, string copy) {

            __COPYTOOUTPUTSTATE copyState;
            switch (copy.ToLower()) {
                case "always":
                    copyState = __COPYTOOUTPUTSTATE.COPYTOOUTPUTSTATE_Always;
                    break;
                case "none":
                    copyState = __COPYTOOUTPUTSTATE.COPYTOOUTPUTSTATE_Never;
                    break;
                default:
                    copyState = __COPYTOOUTPUTSTATE.COPYTOOUTPUTSTATE_PreserveNewestFile;
                    break;

            }
            pi.Properties.Item("CopyToOutputDirectory").let_Value(copyState);
        }
    }
}
