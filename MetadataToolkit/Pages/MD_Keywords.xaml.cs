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

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml;
using ArcGIS.Desktop.Framework;
using Newtonsoft.Json.Linq;

using ArcGIS.Desktop.Metadata.Editor.Pages;
using System.Windows.Controls;
using ArcGIS.Desktop.Metadata.Editor.Validation;
using ArcGIS.Desktop.Metadata;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_MD_Keywords.xaml
  /// </summary>
  internal partial class MTK_MD_Keywords : EditorPage
  {
    public MTK_MD_Keywords()
    {
      InitializeComponent();

      Loaded += MD_Keywords_Loaded;
    }

    public static readonly DependencyProperty DefaultTitleProperty = DependencyProperty.Register(
      "DefaultTitle",
      typeof(string),
      typeof(MTK_MD_Keywords));

    public static readonly DependencyProperty DefaultLinkageProperty = DependencyProperty.Register(
      "DefaultLinkage",
      typeof(string),
      typeof(MTK_MD_Keywords));

    public string DefaultTitle
    {
      get { return (string)this.GetValue(DefaultTitleProperty); }
      set { this.SetValue(DefaultTitleProperty, value); }
    }

    public string DefaultLinkage
    {
      get { return (string)this.GetValue(DefaultLinkageProperty); }
      set { this.SetValue(DefaultLinkageProperty, value); }
    }

    private void MD_Keywords_Loaded(object sender, RoutedEventArgs e)
    {
      string profile = null;

      var mdModule = FrameworkApplication.FindModule("esri_metadata_module") as IMetadataEditorHost;
      if (mdModule != null)
        profile = mdModule.GetCurrentProfile(this);

      if (profile == null)
        return;

      bool bINSPIRE = profile.Equals("INSPIRE", System.StringComparison.InvariantCultureIgnoreCase);
      DefaultTitle = bINSPIRE ? "GEMET - INSPIRE themes, version 1.0" : string.Empty;
      DefaultLinkage = bINSPIRE ? "http://www.eionet.europa.eu/gemet/inspire_themes" : string.Empty;
    }

    private MTK_MD_ThemeKeywords _themekeywords = null;

    private void Lookup_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      //already open?
      if (_themekeywords != null)
        return;
      _themekeywords = new MTK_MD_ThemeKeywords();
      _themekeywords.Owner = FrameworkApplication.Current.MainWindow;
      _themekeywords.Closed += (o, args) => { KeywordsWindowClosed(); };
      _themekeywords.Show();
    }

    private void KeywordsWindowClosed()
    {
      var selectedKeywords = _themekeywords.SelectedKeywords;
      if (selectedKeywords != null && selectedKeywords.Count > 0)
      {
        var keywords = selectedKeywords.Select((k) => k.Label).ToList();
        object context = Utils.Utils.GetDataContext(this);
        IEnumerable<XmlNode> nodes = Utils.Utils.GetXmlDataContext(context);
        if (nodes != null)
        {
          var node = nodes.First();
          var bag = node.SelectSingleNode("bag");

          if (string.IsNullOrWhiteSpace(bag.InnerText))
          {
            string newKeywords = string.Join("\n", keywords);
            bag.InnerText = newKeywords;

            _themekeywords = null;

            return;
          }

          string newText = bag.InnerText;
          var originalTextList = newText.Split('\n').ToList();
          foreach (string kw in keywords)
          {
            if (originalTextList.Contains(kw))
              continue;

            newText += $"\n" + kw;
          }

          bag.InnerText = newText;
        }
      }

      _themekeywords = null;
    }

    private void OnKeywordsChanged(object sender, TextChangedEventArgs args)
    {
      TextBox tb = sender as TextBox;
      if (tb is null)
        return;

      bool hasIssue = string.IsNullOrEmpty(tb.Text);
      tb.SetValue(MetadataRules.HasIssueProperty, hasIssue);
    }
  }
}
