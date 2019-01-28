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
using EnvDTE;
using metadata_toolkit_wizard.Helpers;

namespace metadata_toolkit_wizard.ConfigureAddins {
    internal class ConfigureModule : IAddinConfig {

        public string TemplateType { get; set; }
        public string AddinType { get; set; }
        public bool NeedsWizard { get { return false; } }

        public void RunStarted(ProjectHelper helper) {
            //get the Arcgis install location to get path to schema file. ArcGIS.Desktop.Framework.xsd
            var productInfo = MSIHelper.GetInstallDirAndVersion();
            helper.ReplacementsDictionary.Add("$xsdpath$", helper.EncodeURL(productInfo.Item1 + @"bin\"));
        }

        public bool ShouldAddProjectItem(Helpers.ProjectHelper helper, string filePath) {
            return true;
        }

        public bool ProjectItemFinishedGenerating(ProjectHelper helper, ProjectItem projectItem) {
            //no-op - never called
            return false;
        }

        public void ProjectFinishedGenerating(ProjectHelper helper, Project project) {
            //project specific stuff here
        }

        public void RunFinished() {
            //final cleanup
        }
    }
}
