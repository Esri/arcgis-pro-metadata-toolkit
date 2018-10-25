using System;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Linq;
using System.Xml.Linq;

namespace proapp_sdk_MSBuild
{
    /// <summary>
    /// See <a href="http://www.developerfusion.com/article/84411/customising-your-build-process-with-msbuild/"/>
    /// <a href="http://thomasardal.com/msbuild-tutorial/"/>
    /// </summary>
    public class PackageAddIn : Task {

        #region MSBuild Task Parameters

        [Required]
        public string ZipIntermediatePath { get; set; }

        [Required]
        public string AssemblyName { get; set; }

        [Required]
        public string TargetFolder { get; set; }

        [Required]
        public string PackageType { get; set; }

        private string _packageAction;
        [Required]
        public string PackageAction { get { return _packageAction; } set { _packageAction = value.ToLower(); } }

        [Output]
        public string PackageOutputPath { get; set; }

        [Output]
        public string ArcGISFolder { get; set; }


        #endregion MSBuild Task Parameters

        public override bool Execute()
        {

            if (PackageAction.Equals("buildnopostprocess"))
                return true;
            if (PackageAction != "buildzippostprocess")
                ArcGISFolder = Path.Combine(MSIHelper.GetInstallDirAndVersion().Item1, "bin");

            // Check if Config.daml exists in ZipFolder
            ZipIntermediatePath = Path.GetFullPath(ZipIntermediatePath);
            if (!Directory.Exists(ZipIntermediatePath))
                return false;

            var addInXML = Path.Combine(ZipIntermediatePath, Constants.AddInConfigArchiveFile);
            if (!File.Exists(addInXML)) {
                Log.LogError(MSBuildResource.ConfigDamlNotFound, Constants.AddInConfigArchiveFile);
                return false;
            }

            ConfigurationDAML cfg = new ConfigurationDAML(addInXML);
            var addInID = cfg.ID;
            var ConfigName = System.IO.Path.GetFileNameWithoutExtension(AssemblyName);

            //Verfiy that an assembly with the name defined in the Config.daml does exist in the install folder.
            string addInAssembly = Path.Combine(ZipIntermediatePath, "Install", cfg.DefaultAssembly);
            if (!File.Exists(addInAssembly)) {
                Log.LogWarning(MSBuildResource.DefaultAssemblyNotFound, cfg.DefaultAssembly,
                    Constants.AddInConfigArchiveFile);
            }

            if (!Directory.Exists(TargetFolder))
                Directory.CreateDirectory(TargetFolder);

            // TODO: Check "Name" if it contains invalid characters for zip file
            string archiveName = AssemblyName +
                                 (PackageType.ToLower() == "addin"
                                     ? Constants.AddinExtension
                                     : Constants.ConfigExtension);
            //CleanInfo = (PackageType.ToLower() == "addin" ? addInID : ConfigName + Constants.ConfigExtension);

            try {

                string file = Path.Combine(TargetFolder, archiveName);

                if (File.Exists(file))
                    File.Delete(file);

                ZipFile.CreateFromDirectory(ZipIntermediatePath, file);
                PackageOutputPath = Path.GetFullPath(file);
                return true;
            }
            catch (Exception) {
                return false; // TODO: Log error from exception
            }

        }
    }

    public class CleanAddIn : Task {
        #region MSBuild Task Parameters
        [Required]
        public string ProjectDir { get; set; }

        [Required]
        public string AssemblyName { get; set; }

        [Required]
        public string PackageType { get; set; }
        private string _packageAction;
        [Required]
        public string PackageAction { get { return _packageAction; } set { _packageAction = value.ToLower(); } }

        [Output]
        public string ArcGISFolder { get; set; }

        [Output]
        public string CleanInfo { get; set; }

        #endregion

        public override bool Execute() {
            if (PackageAction.Equals("buildnopostprocess"))
                return true;
            if (PackageAction != "buildzippostprocess")
                ArcGISFolder = Path.Combine(MSIHelper.GetInstallDirAndVersion().Item1, "bin");

            var addInXML = Path.Combine(ProjectDir, Constants.AddInConfigArchiveFile);
            if (!File.Exists(addInXML)) {
                Log.LogError(MSBuildResource.ConfigDamlNotFound, Constants.AddInConfigArchiveFile);
                return false;
            }

            ConfigurationDAML cfg = new ConfigurationDAML(addInXML);
            var addInID = cfg.ID;
            var ConfigName = System.IO.Path.GetFileNameWithoutExtension(AssemblyName);
            CleanInfo = (PackageType.ToLower() == "addin" ? addInID : ConfigName + Constants.ConfigExtension);
            return true;
        }

    }

    /// <summary>
    /// The reverse of ConvertToAbsolutePath task
    /// </summary>
    public class ConvertToRelativePath : Task {
        #region MSBuild Task Parameters
        [Required]
        public ITaskItem[] Paths { get; set; }
        [Required]
        public string RelativeTo { get; set; }
        [Output]
        public ITaskItem[] RelativePaths { get; private set; }
        #endregion

        public override bool Execute() {
            var result = new List<ITaskItem>();
            System.Uri relativeTo = new Uri(this.RelativeTo);
            foreach (var i in Paths) {
                try {
                    System.Uri itemFullPath = new Uri(i.GetMetadata("FullPath"));
                    var relativeUri = relativeTo.MakeRelativeUri(itemFullPath);

                    result.Add(new TaskItem(Uri.UnescapeDataString(relativeUri.ToString())));
                }
                catch {
                    return false;
                }
            }

            RelativePaths = result.ToArray();
            return true;
        }
    }

    internal static class Constants {
        public const string StringConcatIDFormat = "{0}_{1}";
        public const string StringConcatDotFormat = "{0}.{1}";
        public const string StringConcatUidFormat = "{0}:{1}";

        public const string AddInFactory = "ESRI.ArcGIS.Desktop.AddIns";  //default factory assembly name
        public const string AddInTargetsFile = "Esri.ProApp.SDK.Desktop.targets";
        public const string AddInBuildTargetName = "PackageArcGISAddInContents";
        public const string AddInContentBuildAction = "AddInContent";
        public const string AddInConfigProjFile = "Config.esriaddinx";  // name of add-in xml in vs project
        public const string AddInConfigArchiveFile = "Config.daml";      // name of add-in xml in .esriaddin archive
        public const string AddInElementName = "AddInInfo";     //daml element that stores the add-ins GUID
        public const string AddInElementIDAttributeName = "id";   //daml elements attribute that stores the add-ins GUID

        public const string AddinExtension = ".esriAddinX";
        public const string ConfigExtension = ".proConfigX";


        public const string ConfigXMLRoot = "ESRI.Configuration";
        public const string ConfigNamespace = "http://schemas.esri.com/Desktop/AddIns";
        public const string ConfigServerNamespace = "http://schemas.esri.com/Server/AddIns";
        public const string ConfigXMLAddin = "AddIn";

        public const string ReplacementAppHost = "$AddInHostApplication$";
        public const string ReplacementWizardData = "$ESRIAddinWizardData$";
        public const string ReplacementSupportFolder = "$AddInResourceFolder$";
        public const string ReplacementConfigContent = "$AddInConfigXMLContent$";
        public const string ReplacementConfigName = "$AddInConfigFileName$";
        public const string ReplacementProduct = "$TargetProduct$";
        public const string ReplacementVersion = "$TargetVersion$";
        public const string ReplacementAddInIcon = "$AddInIcon$";

        public const string ImageFileFilter = "*.png; *.bmp; *.jpg; *.gif";
        public const string CursorFileFilter = "*.cur; *.ani;";
        public const string HelpFileFilter = "*.chm; *.pdf; *.doc; *.docx; *.txt; *.htm; *.html";
    }

    internal class ConfigurationDAML {
        public string ID { get; set; }

        public string DefaultAssembly { get; set; }

        public ConfigurationDAML(string path) {
            if (File.Exists(path)) {
                XDocument xdoc = XDocument.Load(path);
                this.DefaultAssembly = xdoc.Root.Attribute("defaultAssembly").Value;
                var addInInfoElement = from aiElm in xdoc.Root.Nodes().Where(d => (d is XElement && ((XElement)d).Name.LocalName == Constants.AddInElementName)) select aiElm;
                this.ID = ((XElement)addInInfoElement.First()).Attribute(Constants.AddInElementIDAttributeName).Value;
            }
        }
    }
}