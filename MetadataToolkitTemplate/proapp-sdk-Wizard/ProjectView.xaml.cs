using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using metadata_toolkit_wizard.ConfigureAddins;
using metadata_toolkit_wizard.Helpers;
using metadata_toolkit_wizard.ViewModel;
using metadata_toolkit_wizard.View;

namespace metadata_toolkit_wizard {
    /// <summary>
    /// Interaction logic for ProjectView.xaml
    /// </summary>
    internal partial class ProjectView : Window {

        public ProjectView(ProjectViewModel pvm) {
            InitializeComponent();
            //wire up events
            pvm.RequestClose += pvm_RequestClose;
            pvm.RequestCancelled += pvm_RequestCancelled;
            this.DataContext = pvm;
        }

        void pvm_RequestCancelled(object sender, EventArgs e) {
            base.DialogResult = false;
        }

        void pvm_RequestClose(object sender, EventArgs e) {
            base.DialogResult = true;
        }
    }
}
