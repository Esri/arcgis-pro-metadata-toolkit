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
using proapp_sdk_Wizard.ConfigureAddins;
using proapp_sdk_Wizard.Helpers;
using proapp_sdk_Wizard.ViewModel;
using proapp_sdk_Wizard.View;

namespace proapp_sdk_Wizard {
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
