using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using proapp_sdk_Wizard.ConfigureAddins;
using proapp_sdk_Wizard.Helpers;
using proapp_sdk_Wizard.ViewModel;

namespace proapp_sdk_Wizard {
    internal class ProjectViewModel {

        #region Fields

        AddinViewModelBase _currentPage;
        IWizardConfig _config = null;

        RelayCommand _cancelCommand;
        RelayCommand _moveNextCommand;
        RelayCommand _movePreviousCommand;
        RelayCommand _finishCommand;

        ReadOnlyCollection<AddinViewModelBase> _pages;

        #endregion // Fields

        #region Events

        /// <summary>
        /// Raised when the wizard should be removed from the UI.
        /// </summary>
        public event EventHandler RequestClose = delegate { };
        public event EventHandler RequestCancelled = delegate { };

        #endregion // Events

        #region Constructor

        public ProjectViewModel(ProjectHelper helper, IWizardConfig config) {
            _pages = new ReadOnlyCollection<AddinViewModelBase>(config.ReturnPages(helper));
            config.BeforeWizardOpens(helper);

            Helper = helper;
            _config = config;
            this.CurrentPage = this.Pages[0];
        }

        #endregion // Constructor

        #region Commands

        #region CancelCommand

        /// <summary>
        /// Returns the command which, when executed, cancels the order 
        /// and causes the Wizard to be removed from the user interface.
        /// </summary>
        public ICommand CancelCommand {
            get {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand(() => this.CancelOrder());

                return _cancelCommand;
            }
        }

        void CancelOrder() {
            this.OnRequestCancelled();
        }

        #endregion // CancelCommand

        #region MovePreviousCommand

        /// <summary>
        /// Returns the command which, when executed, causes the CurrentPage 
        /// property to reference the previous page in the workflow.
        /// </summary>
        public ICommand MovePreviousCommand {
            get {
                if (_movePreviousCommand == null)
                    _movePreviousCommand = new RelayCommand(
                        () => this.MoveToPreviousPage(),
                        () => this.CanMoveToPreviousPage);

                return _movePreviousCommand;
            }
        }

        bool CanMoveToPreviousPage {
            get { return 0 < this.CurrentPageIndex; }
        }

        void MoveToPreviousPage() {
            if (this.CanMoveToPreviousPage)
                this.CurrentPage = this.Pages[this.CurrentPageIndex - 1];
        }

        #endregion // MovePreviousCommand

        #region MoveNextCommand

        /// <summary>
        /// Returns the command which, when executed, causes the CurrentPage 
        /// property to reference the next page in the workflow.  If the user
        /// is viewing the last page in the workflow, this causes the Wizard
        /// to finish and be removed from the user interface.
        /// </summary>
        public ICommand MoveNextCommand {
            get {
                if (_moveNextCommand == null)
                    _moveNextCommand = new RelayCommand(
                        () => this.MoveToNextPage(),
                        () => this.CanMoveToNextPage);

                return _moveNextCommand;
            }
        }

        bool CanMoveToNextPage {
            get { return this.CurrentPage != null; }
        }

        void MoveToNextPage() {
            if (this.CanMoveToNextPage) {
                if (this.CurrentPageIndex < this.Pages.Count - 1) {
                    this.CurrentPage = this.Pages[this.CurrentPageIndex + 1];
                }
                else
                    this.OnRequestClose();
            }
        }

        #endregion // MoveNextCommand

        #region FinishCommand

        /// <summary>
        /// Returns the command which, when executed, causes the CurrentPage 
        /// property to reference the next page in the workflow.  If the user
        /// is viewing the last page in the workflow, this causes the Wizard
        /// to finish and be removed from the user interface.
        /// </summary>
        public ICommand FinishCommand {
            get {
                if (_finishCommand == null)
                    _finishCommand = new RelayCommand(
                        () => this.Finish(),
                        () => this.CanFinish);

                return _finishCommand;
            }
        }

        bool CanFinish {
            get { return this.CurrentPage != null;  }
        }

        void Finish() {
            if (this.CanFinish)
                this.OnRequestClose();
        }

        #endregion // MoveNextCommand

        #endregion // Commands

        #region Properties

        public ProjectHelper Helper { get; set; }
        /// <summary>
        /// Returns the page ViewModel that the user is currently viewing.
        /// </summary>
        public AddinViewModelBase CurrentPage {
            get { return _currentPage; }
            private set {
                if (value == _currentPage)
                    return;

                if (_currentPage != null)
                    _currentPage.IsCurrentPage = false;

                _currentPage = value;

                if (_currentPage != null)
                    _currentPage.IsCurrentPage = true;

                this.OnPropertyChanged("CurrentPage");
                this.OnPropertyChanged("IsOnLastPage");
            }
        }

        /// <summary>
        /// Returns true if the user is currently viewing the last page 
        /// in the workflow.  This property is used by CoffeeWizardView
        /// to switch the Next button's text to "Finish" when the user
        /// has reached the final page.
        /// </summary>
        public bool IsOnLastPage {
            get { return this.CurrentPageIndex == this.Pages.Count - 1; }
        }

        /// <summary>
        /// Returns a read-only collection of all page ViewModels.
        /// </summary>
        public ReadOnlyCollection<AddinViewModelBase> Pages {
            get {
                return _pages;
            }
        }

        #endregion // Properties

        int CurrentPageIndex {
            get {

                if (this.CurrentPage == null) {
                    Debug.Fail("Why is the current page null?");
                    return -1;
                }
                return this.Pages.IndexOf(this.CurrentPage);
            }
        }

        void OnRequestClose() {
            EventHandler handler = this.RequestClose;
            handler(this, EventArgs.Empty);
            _config.WizardFinished(this.Helper, false);
            _config = null;
        }

        void OnRequestCancelled() {
            EventHandler handler = this.RequestCancelled;
            handler(this, EventArgs.Empty);
            _config.WizardFinished(this.Helper, true);
            _config = null;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}
