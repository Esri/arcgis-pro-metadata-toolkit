using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proapp_sdk_Wizard.ViewModel {
    internal abstract class AddinViewModelBase : PropertyChangedBase  {

        #region Fields

        bool _isCurrentPage;

        #endregion // Fields

        #region Properties

        public abstract string DisplayName { get; }

        public bool IsCurrentPage {
            get { return _isCurrentPage; }
            set {
                SetProperty(ref _isCurrentPage, value, () => IsCurrentPage);
            }
        }

        #endregion Properties

        #region Methods

         #endregion // Methods
    }
}