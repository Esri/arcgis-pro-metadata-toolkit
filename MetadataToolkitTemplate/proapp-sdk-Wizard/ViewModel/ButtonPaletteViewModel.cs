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
    internal class ButtonPaletteViewModel : AddinViewModelBase {

        private ProjectHelper _hlpr = null;

        private string _caption;
        private BitmapImage _smallImage;
        private BitmapImage _largeImage;
        private bool _isMenuStyle;


        public ButtonPaletteViewModel(ProjectHelper projectHelper) {
            _hlpr = projectHelper;
            IsMenuStyle = true;
            var baseNameAndId = _hlpr.BaseNameAndId;
            Caption = string.Format("{0} {1}", baseNameAndId.Item1, baseNameAndId.Item2);
        }

        public override string DisplayName {
            get {
                return "ButtonPalette";
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
        public bool IsMenuStyle
        {
            get
            {
                return _isMenuStyle;
            }
            set
            {
                SetProperty(ref _isMenuStyle, value, () => IsMenuStyle);
                if (value == false)
                    _hlpr.ReplacementsDictionary["$menustyle$"] = "false";
                else
                    _hlpr.ReplacementsDictionary["$menustyle$"] = "true";
            }
        }        

        public BitmapImage SmallImage {
            get {
                if (_smallImage == null) {
                    string imageUri = string.Format(@"pack://application:,,,/proapp-sdk-Wizard;component/Images/{0}",
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
                    string imageUri = string.Format(@"pack://application:,,,/proapp-sdk-Wizard;component/Images/{0}",
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
