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

using EnvDTE;
using System;
using System.Windows.Media.Imaging;
using VSLangProj80;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using EnvDTE80;
using System.Collections;
using System.Web;

namespace metadata_toolkit_wizard.Helpers {
    /// <summary>
    /// Utility methods and accessors for working with the IDE <b>EnvDTE.Project</b> class.
    /// Also includes a global reference to the current replacementsDictionary
    /// </summary>
    public class ProjectHelper : IDisposable {

        private DTE2 _visualStudio = null;
        public List<string> UserSelectedImages = null;

        /// <summary>
        /// Provide the existing replacements Dictionary and handle to Visual Studio
        /// </summary>
        /// <param name="automationObject"></param>
        /// <param name="replacements"></param>
        public ProjectHelper(object automationObject, Dictionary<string, string> replacements) {
            ReplacementsDictionary = replacements;
            //save the reference to Visual Studio
            if (automationObject is DTE2) {
                _visualStudio = (DTE2)automationObject;
            }
            UserSelectedImages = new List<string>();
        }

        //public static string GenerateUniqueID(string organization, string idType)
        //{
        //    string tempID = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
        //    return organization.ToLower() + "_" + idType + "_" + tempID;
        //}

        //public string GenerateUniqueID(string idType)
        //{
        //    return GenerateUniqueID(ReplacementsDictionary["$registeredorganization$"], idType);
        //}

        public string GenerateID(String idAddition = "")
        {
            String newID = "safe_pro_id";

            if (String.IsNullOrEmpty(idAddition))
                newID = String.Join("_", this.ReplacementsDictionary["$rootnamespace$"], this.ReplacementsDictionary["$safeitemname$"]).Replace(".", "_");
            else
                newID = String.Join("_", this.ReplacementsDictionary["$rootnamespace$"], this.ReplacementsDictionary["$safeitemname$"], idAddition).Replace(".", "_");

            return newID;
        }

        public Dictionary<string, string> ReplacementsDictionary { get; set; }
        public Tuple<string,string> BaseNameAndId {
            get {
                string item = "";
                if (this.ReplacementsDictionary.ContainsKey("$addinclassname$")) {
                    item = this.ReplacementsDictionary["$addinclassname$"];
                }
                else {
                    item = this.ReplacementsDictionary["$safeitemname$"];
                }
                string baseName = "";
                char[] nameArray = item.TakeWhile(c => Char.IsLetter(c)).ToArray();
                if (nameArray.Length == 0)
                {
                    //the user has entered a numer as the first character
                    baseName = "_";
                }
                else
                {
                    baseName = new string(item.TakeWhile(c => Char.IsLetter(c)).ToArray());
                }
                string id = item.Replace(baseName, "");
                return new Tuple<string, string>(baseName, id);
            }
        }

        public string MakeCaption(Tuple<string, string> baseNameAndId)
        {
            string caption = null;
            //if ID is null, then don't use it.
            caption = baseNameAndId.Item2.Length > 0 
                ? $"{baseNameAndId.Item1} {baseNameAndId.Item2}"
                : baseNameAndId.Item1;

            return caption;
        }

        public string MakeCaption(string safeName) {
            string baseName = new string(safeName.Where(c => Char.IsLetter(c)).ToArray());
            string id = new string(safeName.Where(c => Char.IsDigit(c)).ToArray());
            return string.Format("{0} {1}", baseName, id).Trim();
        }
        
        public string FixSafeItemName(string safeItemName)
        {
            if (safeItemName == "@fixed")
                safeItemName = "fixed";
            return safeItemName;

        }

        public string SolutionFilePath {
            get {
                EnvDTE._DTE dte = _visualStudio as EnvDTE._DTE;
                return dte.Solution.Properties.Item("Path").Value.ToString();
            }
        }

        public string SolutionDirectoryName {
            get {
                return System.IO.Path.GetDirectoryName(this.SolutionFilePath);
            }
        }

        public Project ActiveProjectInSolution {
            get {
                DTE dte = (DTE)_visualStudio;
                Array activeProjects = (Array)dte.ActiveSolutionProjects;
                return (Project)activeProjects.GetValue(0);
            }
        }
        /// <summary>
        /// The containing folder for the project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public string GetProjectDirectoryName(Project project) {
            return System.IO.Path.GetDirectoryName(project.FullName);
        }

        public string BrowseFor(string Filter, string defaultEXT) {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = defaultEXT;
            dlg.Filter = Filter;

            //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
                return dlg.FileName;

            return null;
        }

        public string BrowseForImage() {
            return BrowseFor("Image Files(*.PNG;*.JPG;*.GIF)|*.PNG;*.JPG;*.GIF|All files (*.*)|*.* ", ".png");
        }

        public string BrowseForCursor() {

            return BrowseFor("Cursor Files(*.CUR)|*.CUR|All files (*.*)|*.* ", ".cur");
        }

        ////public static ImageSource ConvertFromWindowFormCursor(System.Windows.Forms.Cursor cursor) {
        ////    int width = 64;
        ////    int height = 64;
        ////    System.Drawing.Bitmap b = new System.Drawing.Bitmap(width, height);
        ////    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b);
        ////    cursor.Draw(g, new System.Drawing.Rectangle(0, 0, width, height));
        ////    ImageSource img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(b.GetHicon(), new Int32Rect(0, 0, width, height), BitmapSizeOptions.FromEmptyOptions());
        ////    return img;
        ////}

        /// <summary>
        /// Return the project DAML file as an XDocument
        /// </summary>
        /// <param name="project">The project being generated or the project to which the addin is being added</param>
        /// <returns></returns>
        public XDocument GetConfigXml(Project project) {
            ProjectItem addinsXml = null;  
            try
            {
              addinsXml = project.ProjectItems.Item(Defaults.ConfigXML);
            }
            catch{}
  
            //No Config - throw!
            if (addinsXml == null) {
                throw new System.IO.FileNotFoundException(Properties.Resource1.ConfigFileNotFoundException);
            }
            //Issue 74 - IDE Wizard overwrites unsaved changes in the config.daml
            //CM 6/05/2014
            if (!addinsXml.Saved)
                //save it now
                addinsXml.Save();
            return XDocument.Load(addinsXml.FileNames[0]);
        }
        /// <summary>
        /// Return the project DAML file as an XDocument from the project containing the item
        /// </summary>
        /// <param name="projectItem"></param>
        /// <returns></returns>
        public XDocument GetConfigXml(ProjectItem projectItem) {
            return GetConfigXml(projectItem.ContainingProject);
        }

        /// <summary>
        /// This method addresses Issue #261: If daml file has edits and you add a new item template, the 
        /// changes from the template are not shown in the daml.
        /// </summary>
        /// <param name="xmlContent">The xml that will be written out to the config daml</param>
        internal void SaveConfigXML(string xmlContent) {
            ProjectItem configDotDaml = this.FindConfigDamlItem();
            if (configDotDaml == null) {
                throw new System.IO.FileNotFoundException(Properties.Resource1.ConfigFileNotFoundException);
            }

            //Get the Config content from the visual studio pane and update it
            TextDocument visualStudioDoc = configDotDaml.ActivateCodeDocument(false);

            EditPoint insertPt = visualStudioDoc.StartPoint.CreateEditPoint();
            insertPt.ReplaceText(visualStudioDoc.EndPoint, xmlContent,
              (int)vsEPReplaceTextOptions.vsEPReplaceTextAutoformat);
            //save it
            configDotDaml.Save();
        }

        /// <summary>
        /// Get the Config.daml ProjectItem
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        internal ProjectItem FindConfigDamlItem() {
            return FindProjectItem(Defaults.ConfigXML);
        }
        /// <summary>
        /// Search for a project item by name recursively.
        /// </summary>
        public EnvDTE.ProjectItem FindProjectItem(string name) {
            
            foreach (ProjectItem pi in this.ActiveProjectInSolution.ProjectItems.GetProjectItems())
                if (string.Compare(pi.Name, name, true) == 0)
                    return pi;

            return null;
        }

        public void Dispose() {
            _visualStudio = null;
            ReplacementsDictionary = null;
        }

        /// <summary>
        /// Returns the Path passed to it as a URI
        /// </summary>
        /// <param name="configDoc"></param>
        /// <returns></returns>

        public string EncodeURL(string path)
        {
            HttpUtility.UrlPathEncode(path); //Encodes paths (replaces spaces, etc)
            var uri = new System.Uri(path);
            return uri.AbsoluteUri; //returns URI style paths with forwards slashes.
        }

        public string GetRelativePathToProjectItem(ProjectItem projectItem)
        {
            string projectItemPath = projectItem.Properties.Item("FullPath").Value.ToString();
            string projectPath = projectItem.ContainingProject.Properties.Item("FullPath").Value.ToString();
            string relativePath = System.IO.Path.GetDirectoryName(projectItemPath.Replace(projectPath, ""));
            return relativePath.Replace("\\", "/") + "/";
        }
    }

    /// <summary>
    /// Extend the Visual Studio Project Items class
    /// </summary>
    internal static class ProjectItemExtensions {

        public static IEnumerable<ProjectItem> GetProjectItems(this ProjectItem projectItem) {
            foreach (ProjectItem pi in projectItem.ProjectItems.GetProjectItems())
                yield return pi;

            yield return projectItem;
        }

        public static IEnumerable<ProjectItem> GetProjectItems(this ProjectItems items) {
            foreach (ProjectItem pi in items) {
                foreach (ProjectItem subitem in pi.GetProjectItems())
                    yield return subitem;
            }
        }

        /// <summary>
        /// Get the TextDocument object of a project item (to insert code). Note this changes 
        /// DTE.SelectedItems property.
        /// </summary>
        public static EnvDTE.TextDocument ActivateCodeDocument(this ProjectItem pi, bool open) {
            if (pi == null)
                return null;

            try {
                EnvDTE.Window w = pi.Open(EnvDTE.Constants.vsViewKindCode);
                if (w == null)
                    return null;

                if (open)
                    w.Activate();
                return (TextDocument)pi.Document.Object("TextDocument");
            }
            catch {
                return null;
            }
        }
    }
}
