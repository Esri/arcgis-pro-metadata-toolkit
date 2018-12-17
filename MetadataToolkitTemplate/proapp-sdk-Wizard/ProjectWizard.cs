using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TemplateWizard;
using Microsoft.Win32;
using System.IO;
using EnvDTE80;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using metadata_toolkit_wizard.Helpers;
using metadata_toolkit_wizard.ConfigureAddins;
using System.Windows;

namespace metadata_toolkit_wizard
{
    /// <summary>
    /// PublicKeyToken: 0ea314499ff521aa
    /// </summary>
    public class ProjectWizard: IWizard {

        private ProjectHelper _hlpr = null;
        private IAddinConfig _config = null;

        private List<Tuple<string, bool>> _imagesToBeAdded = new List<Tuple<string,bool>>();
        private string _itemFileName = "";

        private string sdkMajorMinor = "";

        //List to hold all project items that have buildAction set to "AddInContent".
        private List<ProjectItem> _projectItems = new List<ProjectItem>();

        public void GlobalConfig() {
            if (_hlpr == null)
                throw new Exception("Method called out of sequence. Helper is not initialized");
            //For ALL template types
            //Keep all replacementsDictionary key names lowercase - no Mixed Case, UpperCase
            if (_hlpr.ReplacementsDictionary["$registeredorganization$"] == string.Empty) {
                _hlpr.ReplacementsDictionary["$registeredorganization$"] = Defaults.DefaultOrganization;
            }
            Defaults.Organization = _hlpr.ReplacementsDictionary["$registeredorganization$"];

            //GitHub issue # 201. Adding an item fixed changes it to @fixed
            if (_hlpr.ReplacementsDictionary.ContainsKey("$safeitemname$"))
                _hlpr.ReplacementsDictionary["$safeitemname$"] = _hlpr.FixSafeItemName(_hlpr.ReplacementsDictionary["$safeitemname$"]);
            //get the Arcgis install location and version
            try {
                var productInfo = MSIHelper.GetInstallDirAndVersion();
                _hlpr.ReplacementsDictionary.Add("$arcgis$", productInfo.Item1);
                _hlpr.ReplacementsDictionary.Add("$version$", productInfo.Item2);
                CheckSupportedProVersion();

            }
            catch (System.InvalidOperationException ioe) {
                //this is ours - likely means that we cannot find Pro
                //throw new WizardBackoutException(ioe.Message);
                //throw new Microsoft.VisualStudio.TemplateWizard.WizardCancelledException(Properties.Resource1.WizardCancelled);
                string err1 = string.Format(Properties.Resource1.ArcGISProMissing, sdkMajorMinor);
                string errTitle = string.Format(Properties.Resource1.ArcGISProMissingTitle, sdkMajorMinor);
                System.Windows.MessageBox.Show(err1, errTitle);
                throw new Microsoft.VisualStudio.TemplateWizard.WizardCancelledException(err1);
            }  
            catch (ApplicationException ex)
            {
                System.Windows.MessageBox.Show(ex.Message, Properties.Resource1.SupportedVersionTitle);
                throw new Microsoft.VisualStudio.TemplateWizard.WizardCancelledException(ex.Message);
            } 

        }
        /// <summary>
        /// This method is called when the template has been selected by the user and he/she has clicked the Ok button 
        /// on the New project template dialog. This method is called <b>First</b>
        /// </summary>
        /// <param name="automationObject">This is the visual studio instance</param>
        /// <param name="replacementsDictionary"></param>
        /// <param name="runKind"></param>
        /// <param name="customParams"></param>
        public void RunStarted(object automationObject, Dictionary<string, string> replacements, WizardRunKind runKind, object[] customParams) {
            System.Diagnostics.Debug.WriteLine("RunStarted");

            //save the reference to Visual Studio and replacements dictionary
            _hlpr = new ProjectHelper(automationObject, replacements);

            //Global config (for all...)
             GlobalConfig();

             if (_hlpr.ReplacementsDictionary["templatetype"] == "item")
             {
               try
               {
                 _hlpr.GetConfigXml(_hlpr.ActiveProjectInSolution);
               }
               catch (System.IO.FileNotFoundException) { throw new System.InvalidOperationException(Properties.Resource1.AddItemConfigFileNotFound); }
             }
          
            //Create the config
            _config = MakeAddinConfig.Create( _hlpr.ReplacementsDictionary["templatetype"],
                                              _hlpr.ReplacementsDictionary["addintype"]);
            //Runstarted Config
            _config.RunStarted(_hlpr);

            if (_config.NeedsWizard) {
                //show the wizard
                ProjectView projView = new ProjectView(
                      new ProjectViewModel(_hlpr, (IWizardConfig)_config));
                //show it
                bool? ok = projView.ShowDialog();
                if (!(bool)ok) {
                    throw new Microsoft.VisualStudio.TemplateWizard.WizardCancelledException(Properties.Resource1.WizardCancelled);
                }
            }
            
        }
        /// <summary>
        /// This method is called for each item that is to be copied out of the template and into the new project. This is called <b>Second</b>
        /// </summary>
        /// <remarks>This method is called once for <b>every</b> item to be added. Return <b>false</b> if an item should NOT be added.
        /// <para>
        /// Note: This method is called iteratively in conjunction with ProjectItemFinishedGenerating for Item templates. So, if
        /// 3 files are to be added for the item template then their will be a call to ShouldAddProjectItem immediately followed
        /// by a call to ProjectItemFinishedGenerating and this &quot;pair&quot; of calls is repeated 3 times - one pair of
        /// calls for each individual file</para></remarks>
        /// <param name="projectItem"></param>
        public bool ShouldAddProjectItem(string filePath) {
            return _config.ShouldAddProjectItem(_hlpr, filePath);
        }
        /// <summary>
        /// This method is only called for Item Templates. 
        /// </summary>
        /// <remarks>This method is called <b>Third</b> for item templates. It is NOT called for project templates.
        /// <para>
        /// When the method is called, Visual Studio has already replaced all replaceable string parameters 
        /// found in the project's source code with their values and has added all files defined by the 
        /// template to the project. 
        /// </para></remarks>
        /// <param name="projectItem"></param>
        public void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem) {
            //This means we are an item template and we are adding the item
            System.Diagnostics.Debug.WriteLine(string.Format("{0}", "ProjectItemFinishedGenerating"));
            _config.ProjectItemFinishedGenerating(_hlpr, projectItem);

            // Save off the items with file extensions containing .xaml or .png into a dictionary. 
            //Item is added to a ProjectItem collection.
            Property pBuildAction = projectItem.Properties.Item("ItemType");
            Property pFileName = projectItem.Properties.Item("FileName");
            Property pFullPath = projectItem.Properties.Item("FullPath");
            if (pFileName != null)
            {
                string itemTypeBuildAction = pBuildAction.Value as string;
                string itemTypeFileName = pFileName.Value as string;
                string itemTypeFullPath = pFullPath.Value as string; //since the same image is in Images and DarkImage folders, we have to use the FullPath of the item

                System.Diagnostics.Debug.WriteLine($"{itemTypeFullPath}");
                foreach (var fileExt in Defaults.FileExtensions)
                {
                    FileInfo fi = new FileInfo(itemTypeFileName);
                    string ext = fi.Extension;
                    if (ext.Equals(fileExt))
                    {
                        
                        _projectItems.Add(projectItem);
                        
                        Defaults.FileNameBuildActionMap.Add(itemTypeFullPath, itemTypeBuildAction);
                    }
                }
                
            }


        }
        /// <summary>
        /// Called right after the .csproj has been created. All files have been copied out of the template into the new project.
        /// This is called <b>Third</b> for projects. It is NOT called for items.
        /// </summary>
        /// <param name="project"></param>
        public void ProjectFinishedGenerating(EnvDTE.Project project) {
            ////System.Diagnostics.Debug.WriteLine("ProjectFinishedGenerating");

            _config.ProjectFinishedGenerating(_hlpr, project);
           

        }

        /// <summary>
        /// Called prior to the newly constructed project or item being opened. This is called <b>Fourth</b>
        /// </summary>
        /// <remarks>
        /// The presence of the OpenInEditor=&quot;true&quot; attribute in the $lt;ProjectItem&gt; tag in a template's .vstemplate file 
        /// determines whether or not that project item is to be opened in the Visual Studio environment once 
        /// Visual Studio has finished generating the project. This method is called for wizards invoked by 
        /// both project templates and by project item templates before Visual Studio actually opens each file
        /// </remarks>
        /// <param name="projectItem"></param>
        public void BeforeOpeningFile(EnvDTE.ProjectItem projectItem) {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: projectItem.Name = '{1}'", "BeforeOpeningFile", projectItem.Name));
        }
        /// <summary>
        /// Do final clean-up here. This method is called <b>Fifth</b>. 
        /// </summary>
        public void RunFinished() {
            System.Diagnostics.Debug.WriteLine("RunFinished");
            _config.RunFinished();
            _hlpr.Dispose();
            // Schedule the FixUpItemType function to run on the main UI thread, after the Add Item operation concludes.
            //IVsTaskSchedulerService scheduler = (IVsTaskSchedulerService)Package.GetGlobalService(typeof(SVsTaskSchedulerService));
            //IVsTaskBody task = VsTaskLibraryHelper.CreateTaskBody(() => FixUpItemType());
            //VsTaskLibraryHelper.CreateAndStartTask(scheduler, VsTaskRunContext.UIThreadIdlePriority, task);
            //**************Important info when VS 2013 is not supported *******************************
            //The commented code below is to be used when we drop VS 2013 Support.
            //This code is to be used instead of the old code above (3 lines)
            //Drop reference to Microsoft.VisaulStudio.Shell.11.0.dll and Microsoft.VisaulStudio.Shell.Interop.11.0.dll also 
            //add Microsoft.VisaulStudio.Shell.14.0.dll 
            VsTaskLibraryHelper.CreateAndStartTask(VsTaskLibraryHelper.ServiceInstance, VsTaskRunContext.UIThreadIdlePriority, FixUpItemType);
            //Above line is commented out in order to allow this to work with VS 2013. 
            //**************Important info when VS 2013 is not supported *******************************
        }
        internal void CheckSupportedProVersion()
        {
            if (_hlpr == null)
                throw new Exception("Method called out of sequence. Helper is not initialized");

            var sdkVersion = _hlpr.ReplacementsDictionary["sdkversion"];


            //this is the installed version for comparison purposes
            var productInfo = MSIHelper.GetInstallDirAndVersion();
            var proVersion = productInfo.Item2;

            //Parsing sdkVersion and proVersion

            var sdkVersionInfo = VersionParser(sdkVersion);
            var proVersionInfo = VersionParser(proVersion);

            //assume both version strings have been parsed...these are the checks
            //Major Version must match (if we assume semantic versioning rules)
            int sdkMajorVersion = sdkVersionInfo.Item1;//parse sdkVersion
            int sdkMinorVersion = sdkVersionInfo.Item2; //parse sdkVersion
            int proMajorVersion = proVersionInfo.Item1; //parse proVersion
            int proMinorVersion = proVersionInfo.Item2; //parse proVersion
            int proBuildNum = proVersionInfo.Item3; //parse proVersion

            sdkMajorMinor = string.Format("{0}.{1}", sdkMajorVersion.ToString(), sdkMinorVersion.ToString());

            string errMsg = string.Format(Properties.Resource1.GeneralVersionError, sdkMajorMinor, proVersion);
            string errMsgBeta = string.Format(Properties.Resource1.BetaError, sdkMajorMinor);

            if (sdkMajorVersion != proMajorVersion) //exit! - eg - you install Pro SDK 2.0 on top of Pro 1.
                throw new ApplicationException(errMsg); //this is an error 

            if (proMinorVersion < sdkMinorVersion) //exit - eg - you install Pro SDK 1.2 on top of Pro 1.1
                throw new ApplicationException(errMsg); //this is an error 
            //legacy - ensure minimum cutoff for 1.1.0.3308 to prevent 1.1 Beta being used
            if (proMajorVersion == 1 && proMinorVersion <= 1)
                    {
                        if (proMinorVersion == 0 || (proMinorVersion == 1 && proBuildNum < 3308))
                        {
                            //The Pro version is Pre 1.1 release
                            //exit! - you cannot use Final Pro SDK 1.1 or better with Beta and earlier
                            throw new ApplicationException(errMsgBeta); //this is an error 
                        }
                    }
            //You are good to go if you got here       
        }

        internal Tuple<int, int, int> VersionParser(string ver)
        {
            //split the version to get the buildnumber
            string[] stringSeparators = new string[] { "." };
            string[] splitResult = ver.Split(stringSeparators, StringSplitOptions.None);
            int buildNo;
            //int spNo; We are not using the SP for now
            int MajorVer = Convert.ToInt32(splitResult[0]);
            int MinorVer = Convert.ToInt32(splitResult[1]);
            
            if (splitResult.Length == 4) //this means the version has four decimal places
                buildNo = Convert.ToInt32(splitResult[3]);
            else   //this means the version has 3 decimal places (MSI Version)
                buildNo = Convert.ToInt32(splitResult[2]);

            return new Tuple<int, int, int>(MajorVer, MinorVer, buildNo);
        }

        //Method to reset all our Project Items to have the correct BuildAction.
        private void FixUpItemType()
        {
            //Reset the ItemType property, as WPF projects improperly overwrite this as the Add Item operation concludes
            if (_projectItems.Count == 0)
                return;
            foreach (ProjectItem projectItem in _projectItems)
            {
                Property propItemType = projectItem.Properties.Item("ItemType");
                //Property propFileName = projectItem.Properties.Item("FileName");
                Property propFullPath = projectItem.Properties.Item("FullPath"); //since the same image is in Images and DarkImage folders, we have to use the FullPath of the item
                if (Defaults.FileNameBuildActionMap.ContainsKey(propFullPath.Value.ToString()))
                    propItemType.Value = Defaults.FileNameBuildActionMap[propFullPath.Value.ToString()]; //Item is reset to AddInContent here.

            }
            _projectItems.Clear();
            Defaults.FileNameBuildActionMap.Clear();
        }


    }
}
