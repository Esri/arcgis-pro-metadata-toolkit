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
using metadata_toolkit_wizard.ViewModel;

namespace metadata_toolkit_wizard.ConfigureAddins {
    interface IAddinConfig {

        string TemplateType { get; set; }
        string AddinType { get; set; }
        bool NeedsWizard { get; }

        /// <summary>
        /// Called when the Project Wizard is invoked from Visual Studio
        /// </summary>
        /// <param name="replacements"></param>
        void RunStarted(ProjectHelper helper);
        /// <summary>
        /// Returns true if the item should be added, otherwise false
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool ShouldAddProjectItem(ProjectHelper helper, string filePath);
        /// <summary>
        /// The item has been constructed by Visual Studio. String replacement HAS occured
        /// </summary>
        /// <param name="projectItem"></param>
        /// <param name="filePath"></param>
        bool ProjectItemFinishedGenerating(ProjectHelper helper, ProjectItem projectItem);
        /// <summary>
        /// The project has been constructed by Visual Studio. Strng replacement has occured
        /// </summary>
        /// <param name="project"></param>
        void ProjectFinishedGenerating(ProjectHelper helper, Project project);
        /// <summary>
        /// Last chance for final clean-up or config
        /// </summary>
        void RunFinished();
    }

    interface IWizardConfig {
        List<AddinViewModelBase> ReturnPages(ProjectHelper helper);
        /// <summary>
        /// Consume the replacementsDictionary. Make any updates required before the Wizard is
        /// shown to the user
        /// </summary>
        /// <param name="replacements"></param>
        void BeforeWizardOpens(ProjectHelper helper);
        /// <summary>
        /// Ensure that the replacementsDictionary is updated with the user selections
        /// from the wizard UI
        /// </summary>
        void WizardFinished(ProjectHelper helper, bool cancelled);

    }
}
