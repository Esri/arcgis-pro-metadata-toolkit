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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using metadata_toolkit_wizard.Helpers;

namespace metadata_toolkit_wizard.ViewModel {
    internal class DockPaneViewModel : AddinViewModelBase {

        private ProjectHelper _hlpr = null;
        private string _caption;
        private BitmapImage _smallImage;
        private BitmapImage _largeImage;        
        private string _dockoption;
        private string _dockwith;
        private bool _isdockwithgroup;

        public DockPaneViewModel(ProjectHelper projectHelper) {
            _hlpr = projectHelper;

            var baseNameAndId = _hlpr.BaseNameAndId;
            Caption = string.Format("{0} {1}", baseNameAndId.Item1, baseNameAndId.Item2);
            DockWithOption = Defaults.DockWithOptionsMap.Values.First();
            DockOption = Defaults.DockMap.Values.First();
        }

        public override string DisplayName {
            get {
                return "DockPane";
            }
        }

        public string Caption {
            get {
                return _caption;
            }
            set {
                SetProperty(ref _caption, value, () => Caption);
                _hlpr.ReplacementsDictionary["$caption$"] = value;
            }
        }                

        public BitmapImage SmallImage {
            get {
                if (_smallImage == null) {
                    string imageUri = string.Format(@"pack://application:,,,/metadata_toolkit_wizard;component/Images/{0}",
                        _hlpr.ReplacementsDictionary["$defaultimage16$"]);
                    try {
                        Uri uri = new Uri(imageUri);
                        _smallImage = new BitmapImage(uri);
                    }
                    catch { }
                }
                return _smallImage;
            }
            set {
                SetProperty(ref _smallImage, value, () => SmallImage);
            }
        }

        public BitmapImage LargeImage {
            get {
                if (_largeImage == null) {
                    string imageUri = string.Format(@"pack://application:,,,/metadata_toolkit_wizard;component/Images/{0}",
                        _hlpr.ReplacementsDictionary["$defaultimage32$"]);
                    try {
                        Uri uri = new Uri(imageUri);
                        _largeImage = new BitmapImage(uri);
                    }
                    catch { }
                }
                return _largeImage;
            }
            set {
                SetProperty(ref _largeImage, value, () => LargeImage);
            }
        }

        public List<string> DockOptions //top, bottom..
        {
            get
            {
                return Defaults.DockMap.Select(kvp => kvp.Value).ToList<string>();
            }
            
        }

        public string DockOption
        {
            get
            {
                return _dockoption;
            }
             set
            {
                SetProperty(ref _dockoption, value, () => DockOption);
               if (Defaults.DockMap.ContainsValue(value))
                    _hlpr.ReplacementsDictionary["$dockoption$"] = Defaults.DockMap.First(kvp => kvp.Value == value).Key;

                IsDockWithGroup = (_dockoption == "Group"); //Sets this property to true and this will cause the DockWith combo to display in the View
            }
        }

        public List<string> DockWithOptions //Content or Project pane
        {
            get
            {
                return Defaults.DockWithOptionsMap.Select(kvp => kvp.Value).ToList<string>();
            }
        }

       
        public string DockWithOption
        {
            get
            {
                return _dockwith; ;
            }
            set
            {
                SetProperty(ref _dockwith, value, () => DockWithOption);
                foreach (KeyValuePair<string, string> kvp in Defaults.DockWithOptionsMap)
                {
                    if (kvp.Value.CompareTo(value) == 0)
                    {
                        _hlpr.ReplacementsDictionary["$dockwith$"] = kvp.Key;
                    }
                }
            }
        }

        public bool IsDockWithGroup
        {
            get { return _isdockwithgroup; }
            set
            {
                SetProperty(ref _isdockwithgroup, value, () => IsDockWithGroup);
            }
        }
            

        public ICommand BrowseForImageCmd {
            get {
                return new RelayCommand(() => this.BrowseForImage());
            }
        }

        public ICommand BrowseForLargeImageCmd {
            get {
                return new RelayCommand(() => this.BrowseForLargeImage());
            }
        }

        private void BrowseForImage() {
            string filename = _hlpr.BrowseForImage();

            if (string.IsNullOrEmpty(filename))
                return;

            Uri uri = new Uri(filename);
            BitmapImage image = new BitmapImage(uri);
            SmallImage = image;
            _hlpr.ReplacementsDictionary["$image16$"] = filename ;
        }

        private void BrowseForLargeImage() {
            string filename = _hlpr.BrowseForImage();

            if (string.IsNullOrEmpty(filename))
                return;

            Uri uri = new Uri(filename);
            BitmapImage image = new BitmapImage(uri);
            LargeImage = image;
            _hlpr.ReplacementsDictionary["$image32$"] = filename;
        }
    }
}
