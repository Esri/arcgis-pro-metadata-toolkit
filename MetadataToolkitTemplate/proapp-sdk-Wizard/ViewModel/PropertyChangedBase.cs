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
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace metadata_toolkit_wizard.ViewModel {
    public abstract class PropertyChangedBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Helper method to set a property value, typically used in implementing a setter.
        /// Returns true if the property actually changed.
        /// </summary>
        protected bool SetProperty<T>(ref T backingField, T value, Expression<Func<T>> property) {
            var changed = !EqualityComparer<T>.Default.Equals(backingField, value);
            if (changed) {
                backingField = value;
                NotifyPropertyChanged<T>(property);
            }
            return changed;
        }

        /// <summary>
        /// Raises the PropertyChanged event for the specified property.
        /// </summary>
        public void NotifyPropertyChanged<T>(Expression<Func<T>> property) {
            if (PropertyChanged == null)
                return;

            var lambda = (LambdaExpression)property;

            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression) {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else memberExpression = (MemberExpression)lambda.Body;

            PropertyChanged(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
        }

        /// <summary>
        /// Raises the PropertyChanged event for the specified property.
        /// </summary>
        protected virtual void NotifyPropertyChanged(PropertyChangedEventArgs args) {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, args);
        }
    }
}