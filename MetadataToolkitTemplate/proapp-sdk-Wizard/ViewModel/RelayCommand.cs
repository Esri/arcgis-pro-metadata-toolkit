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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace metadata_toolkit_wizard.ViewModel
{
  /// <summary>
  /// A command whose sole purpose is to 
  /// relay its functionality to other
  /// objects by invoking delegates. The
  /// default return value for the CanExecute
  /// method is 'true'.
  /// </summary>
  internal class RelayCommand<T> : ICommand
  {
    #region Fields

    readonly Action<T> _execute = null;
    readonly Predicate<T> _canExecute = null;

    #endregion // Fields

    #region Constructors

    public RelayCommand(Action<T> execute)
      : this(execute, null)
    {
    }

    /// <summary>
    /// Creates a new command.
    /// </summary>
    /// <param name="execute">The execution logic.</param>
    /// <param name="canExecute">The execution status logic.</param>
    public RelayCommand(Action<T> execute, Predicate<T> canExecute)
    {
      if (execute == null)
        throw new ArgumentNullException("execute");

      _execute = execute;
      _canExecute = canExecute;
    }

    #endregion // Constructors

    #region ICommand Members

    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
      return _canExecute == null ? true : _canExecute((T)parameter);
    }

    public event EventHandler CanExecuteChanged
    {
      add
      {
        if (_canExecute != null)
          CommandManager.RequerySuggested += value;
      }
      remove
      {
        if (_canExecute != null)
          CommandManager.RequerySuggested -= value;
      }
    }

    public void Execute(object parameter)
    {
      _execute((T)parameter);
    }

    #endregion // ICommand Members
  }

  /// <summary>
  /// A command whose sole purpose is to 
  /// relay its functionality to other
  /// objects by invoking delegates. The
  /// default return value for the CanExecute
  /// method is 'true'.
  /// </summary>
  internal class RelayCommand : ICommand
  {
    #region Fields

    readonly Action _execute;
    readonly Func<bool> _canExecute;

    #endregion // Fields

    #region Constructors

    /// <summary>
    /// Creates a new command that can always execute.
    /// </summary>
    /// <param name="execute">The execution logic.</param>
    public RelayCommand(Action execute)
      : this(execute, null)
    {
    }

    /// <summary>
    /// Creates a new command.
    /// </summary>
    /// <param name="execute">The execution logic.</param>
    /// <param name="canExecute">The execution status logic.</param>
    public RelayCommand(Action execute, Func<bool> canExecute)
    {
      if (execute == null)
        throw new ArgumentNullException("execute");

      _execute = execute;
      _canExecute = canExecute;
    }

    #endregion // Constructors

    #region ICommand Members

    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
      return _canExecute == null ? true : _canExecute();
    }

    public event EventHandler CanExecuteChanged
    {
      add
      {
        if (_canExecute != null)
          CommandManager.RequerySuggested += value;
      }
      remove
      {
        if (_canExecute != null)
          CommandManager.RequerySuggested -= value;
      }
    }

    public void Execute(object parameter)
    {
      _execute();
    }

    #endregion // ICommand Members
  }
}

