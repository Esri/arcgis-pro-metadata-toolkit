/*
COPYRIGHT 1995-2009 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States.
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts Dept
380 New York Street
Redlands, California, USA 92373
email: contracts@esri.com
*/

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;
using MetadataToolkit.Properties;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MD_ThemeKeywords.xaml
  /// </summary>
  internal partial class MTK_MD_ThemeKeywords : ArcGIS.Desktop.Framework.Controls.ProWindow
  {
    internal struct GemetKeyword
    {
      public string Label { get; set; }
      public string Description { get; set; }

      public GemetKeyword(string label, string description)
      {
        Label = label;
        Description = description;
      }
    };

    static readonly HttpClient _client = new HttpClient();
    private Dictionary<string, List<GemetKeyword>> CachedKeywords { get; set; } = new Dictionary<string, List<GemetKeyword>>();
    public List<GemetKeyword> SelectedKeywords { get; private set; } = new List<GemetKeyword>();

    public Dictionary<string, string> LangDict { get; set; } = new Dictionary<string, string>()
        {
            { "bg", Properties.Resources.LangName_Bulgarian },
            { "hr", Properties.Resources.LangName_Croatian },
            { "cz", Properties.Resources.LangName_Czech},
            { "da", Properties.Resources.LangName_Danish },
            { "nl", Properties.Resources.LangName_Dutch },
            { "en", Properties.Resources.LangName_English },
            { "et", Properties.Resources.LangName_Estonian },
            { "fi", Properties.Resources.LangName_Finnish },
            { "fr", Properties.Resources.LangName_French },
            { "de", Properties.Resources.LangName_German },
            { "el", Properties.Resources.LangName_Greek },
            { "hu", Properties.Resources.LangName_Hungarian },
            { "it", Properties.Resources.LangName_Italian },
            { "lv", Properties.Resources.LangName_Latvian },
            { "lt", Properties.Resources.LangName_Lithuanian },
            { "mt", Properties.Resources.LangName_Maltese },
            { "pl", Properties.Resources.LangName_Polish },
            { "pt", Properties.Resources.LangName_Portuguese },
            { "ro", Properties.Resources.LangName_Romanian },
            { "sk", Properties.Resources.LangName_Slovak },
            { "sl", Properties.Resources.LangName_Slovenian },
            { "es", Properties.Resources.LangName_Spanish },
            { "sv", Properties.Resources.LangName_Swedish }
        }.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

    public ObservableCollection<GemetKeyword> Keywords { get; set; } = new ObservableCollection<GemetKeyword>();

    public MTK_MD_ThemeKeywords()
    {
      InitializeComponent();
      DataContext = this;
    }

    private async Task Lookup(string selectedLanguageCode)
    {
      if (CachedKeywords.ContainsKey(selectedLanguageCode))
      {
        Keywords.Clear();

        foreach (var keyword in CachedKeywords[selectedLanguageCode])
          Keywords.Add(keyword);

        return;
      }

      searchingText.Text = Properties.Resources.THEME_KEYWORD_SEARCHING_TEXT;
      var url = $"https://www.eionet.europa.eu/gemet/getConceptsMatchingRegexByThesaurus?thesaurus_uri=http://inspire.ec.europa.eu/theme/&language={selectedLanguageCode}&regex=.";
      HttpResponseMessage response;

      try
      {
        response = await _client.GetAsync(url);
      }
      catch
      {
        MessageBox.Show(Properties.Resources.UNABLETO_RETRIEVE_THEME_KEYWORD);
        return;
      }

      if (response == null)
        return;

      var responseText = await response.Content.ReadAsStringAsync();
      var jsonArr = JArray.Parse(responseText);
      var keywords = new List<GemetKeyword>();

      Keywords.Clear();
      foreach (var item in jsonArr.Children())
      {
        var def = item.Value<JToken>("definition").Value<string>("string");
        var label = item.Value<JToken>("preferredLabel").Value<string>("string");
        var gemetKeyword = new GemetKeyword(label, def);
        keywords.Add(gemetKeyword);
        Keywords.Add(gemetKeyword);
      }

      CachedKeywords.Add(selectedLanguageCode, keywords);

      searchingText.Text = "";
    }

    private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var selectedLanguageCode = (string)((ComboBox)sender).SelectedValue;

      // Wait for any current searches to complete
      while (!string.IsNullOrWhiteSpace(searchingText.Text))
      {
        await Task.Delay(1000);
      }

      await Lookup(selectedLanguageCode);
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
      SelectedKeywords = GemetKeywordsList.SelectedItems.Cast<GemetKeyword>().ToList();
      Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
