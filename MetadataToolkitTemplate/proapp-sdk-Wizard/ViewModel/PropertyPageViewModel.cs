﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proapp_sdk_Wizard.Helpers;
using System.Windows.Media.Imaging;

namespace proapp_sdk_Wizard.ViewModel
{
    internal class PropertyPageViewModel : AddinViewModelBase
    {

        private ProjectHelper _hlpr = null;

        private string _caption;
        private string _condition;
        private BitmapImage _smallImage;
        private BitmapImage _largeImage;

        public PropertyPageViewModel(ProjectHelper projectHelper)
        {
            _hlpr = projectHelper;

            var baseNameAndId = _hlpr.BaseNameAndId;
            Caption = string.Format("{0} {1}", baseNameAndId.Item1, baseNameAndId.Item2);
            Condition = Defaults.ConditionMap.Values.First();
        }

        public override string DisplayName
        {
            get
            {
                return "PropertyPage";
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                SetProperty(ref _caption, value, () => Caption);
                _hlpr.ReplacementsDictionary["$caption$"] = value;
            }
        }

        public string Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                SetProperty(ref _condition, value, () => Condition);
                foreach (KeyValuePair<string, string> kvp in Defaults.ConditionMap)
                {
                    if (kvp.Value.CompareTo(value) == 0)
                    {
                        _hlpr.ReplacementsDictionary["$controlcondition$"] = kvp.Key;
                    }
                }
            }
        }

        public List<string> Conditions
        {
            get
            {
                return Defaults.ConditionMap.Select(kvp => kvp.Value).ToList<string>();
            }
        }

        public BitmapImage SmallImage
        {
            get
            {
                if (_smallImage == null)
                {
                    string imageUri = string.Format(@"pack://application:,,,/proapp-sdk-Wizard;component/Images/{0}",
                        _hlpr.ReplacementsDictionary["$defaultimage16$"]);
                    try
                    {
                        Uri uri = new Uri(imageUri);
                        _smallImage = new BitmapImage(uri);
                    }
                    catch { }
                }
                return _smallImage;
            }
            set
            {
                SetProperty(ref _smallImage, value, () => SmallImage);
            }
        }

        public BitmapImage LargeImage
        {
            get
            {
                if (_largeImage == null)
                {
                    string imageUri = string.Format(@"pack://application:,,,/proapp-sdk-Wizard;component/Images/{0}",
                        _hlpr.ReplacementsDictionary["$defaultimage32$"]);
                    try
                    {
                        Uri uri = new Uri(imageUri);
                        _largeImage = new BitmapImage(uri);
                    }
                    catch { }
                }
                return _largeImage;
            }
            set
            {
                SetProperty(ref _largeImage, value, () => LargeImage);
            }
        }
    }
}
