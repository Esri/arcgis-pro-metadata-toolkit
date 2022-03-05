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
using System.Windows;
using System.Windows.Controls;
using System.Xml;

using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_CI_Citation.xaml
  /// </summary>
  internal partial class MTK_CI_Citation : EditorPage, INotifyPropertyChanged
  {
    private Dictionary<string, string> _titles;
    public Dictionary<string, string> Titles
    {
      get { return _titles; }
      set
      {
        _titles = value;
        NotifyPropertyChanged(nameof(Titles));
      }
    }


    private bool _otherSelected;
    public bool OtherSelected
    {
      get { return _otherSelected; }
      set
      {
        _otherSelected = value;
        NotifyPropertyChanged(nameof(OtherSelected));
      }
    }

    public new event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string info)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }

    public MTK_CI_Citation()
    {
      InitializeComponent();

      Titles = new Dictionary<string, string>
            {
                { "Bulgarian  (BG): РЕГЛАМЕНТ (ЕС) № 1089/2010  НА КОМИСИЯТА", "РЕГЛАМЕНТ (ЕС) № 1089/2010 НА КОМИСИЯТА от 23 ноември 2010 година за прилагане на Директива 2007/2/ЕО на Европейския парламент и на Съвета по отношение на оперативната съвместимост на масиви от пространствени данни и услуги за пространствени данни" },
                { "Czech (CS): NAŘÍZENÍ KOMISE (EU) č. 1089/2010", "NAŘÍZENÍ KOMISE (EU) č. 1089/2010 ze dne 23. listopadu 2010, kterým se provádí směrnice Evropského parlamentu a Rady 2007/2/ES, pokud jde o interoperabilitu sad prostorových dat a služeb prostorových dat" },
                { "Danish (DA): KOMMISSIONENS FORORDNING (EU) Nr. 1089/2010", "KOMMISSIONENS FORORDNING (EU) Nr. 1089/2010 af 23. november 2010 om gennemførelse af Europa-Parlamentets og Rådets direktiv 2007/2/EF for så vidt angår interoperabilitet for geodatasæt og -tjenester" },
                { "German (DE): VERORDNUNG (EG) Nr. 1089/2010 DER KOMMISSION", "VERORDNUNG (EG) Nr. 1089/2010 DER KOMMISSION vom 23. November 2010 zur Durchführung der Richtlinie 2007/2/EG des Europäischen Parlaments und des Rates hinsichtlich der Interoperabilität von Geodatensätzen und -diensten" },
                { "Greek (EL): ΚΑΝΟΝΙΣΜΟΣ (ΕΕ) αριθ. 1089/2010 ΤΗΣ ΕΠΙΤΡΟΠΗΣ", "ΚΑΝΟΝΙΣΜΟΣ (ΕΕ) αριθ. 1089/2010 ΤΗΣ ΕΠΙΤΡΟΠΗΣ της 23ης Νοεμβρίου 2010 σχετικά με την εφαρμογή της οδηγίας 2007/2/ΕΚ του Ευρωπαϊκού Κοινοβουλίου και του Συμβουλίου όσον αφορά τη διαλειτουργικότητα των συνόλων και των υπηρεσιών χωρικών δεδομένων" },
                { "English (EN): COMMISSION REGULATION (EU) No 1089/2010", "COMMISSION REGULATION (EU) No 1089/2010 of 23 November 2010 implementing Directive 2007/2/EC of the European Parliament and of the Council as regards interoperability of spatial data sets and services" },
                { "Spanish (ES): REGLAMENTO (UE) N o 1089/2010 DE LA COMISIÓN", "REGLAMENTO (UE) N o 1089/2010 DE LA COMISIÓN de 23 de noviembre de 2010 por el que se aplica la Directiva 2007/2/CE del Parlamento Europeo y del Consejo en lo que se refiere a la interoperabilidad de los conjuntos y los servicios de datos espaciales" },
                { "Estonian (ET): KOMISJONI MÄÄRUS (EL) nr 1089/2010", "KOMISJONI MÄÄRUS (EL) nr 1089/2010, 23. november 2010, millega rakendatakse Euroopa Parlamendi ja nõukogu direktiivi 2007/2/EÜ seoses ruumiandmekogumite ja -teenuste ristkasutatavusega" },
                { "Finnish (FI): KOMISSION ASETUS (EU) N:o 1089/2010", "KOMISSION ASETUS (EU) N:o 1089/2010, annettu 23 päivänä marraskuuta 2010, Euroopan parlamentin ja neuvoston direktiivin 2007/2/EY täytäntöönpanosta paikkatietoaineistojen ja -palvelujen yhteentoimivuuden osalta" },
                { "French (FR): RÈGLEMENT (UE) No 1089/2010 DE LA COMMISSION", "RÈGLEMENT (UE) No 1089/2010 DE LA COMMISSION du 23 novembre 2010 portant modalités d\'application de la directive 2007/2/CE du Parlement européen et du Conseil en ce qui concerne l\'interopérabilité des séries et des services de données géographiques" },
                { "Croatian (HR): UREDBA KOMISIJE (EU) br. 1089/2010", "UREDBA KOMISIJE (EU) br. 1089/2010 od 23. studenoga 2010 o provedbi Direktive 2007/2/EZ Europskog parlamenta i Vijeca o meduoperativnosti skupova prostornih podataka i usluga u vezi s prostornim podacima" },
                { "Hungarian (HU): A BIZOTTSÁG 1089/2010/EU RENDELETE", "A BIZOTTSÁG 1089/2010/EU RENDELETE (2010. november 23.) a 2007/2/EK európai parlamenti és tanácsi irányelv téradatkészletek és -szolgáltatások interoperabilitására vonatkozó rendelkezéseinek végrehajtásáról" },
                { "Italian (IT): REGOLAMENTO (UE) N. 1089/2010 DELLA COMMISSIONE", "REGOLAMENTO (UE) N. 1089/2010 DELLA COMMISSIONE del 23 novembre 2010 recante attuazione della direttiva 2007/2/CE del Parlamento europeo e del Consiglio per quanto riguarda l\'interoperabilità dei set di dati territoriali e dei servizi di dati territoriali" },
                { "Lithuanian (LT): KOMISIJOS REGLAMENTAS (ES) Nr. 1089/2010", "KOMISIJOS REGLAMENTAS (ES) Nr. 1089/2010 2010 m. lapkričio 23 d. kuriuo įgyvendinamos Europos Parlamento ir Tarybos direktyvos 2007/2/EB nuostatos dėl erdvinių duomenų rinkinių ir paslaugų sąveikumo" },
                { "Latvian (LV): KOMISIJAS REGULA (ES) Nr. 1089/2010", "KOMISIJAS REGULA (ES) Nr. 1089/2010 (2010. gada 23. novembris), ar kuru īsteno Eiropas Parlamenta un Padomes Direktīvu 2007/2/EK attiecībā uz telpisko datu kopu un telpisko datu pakalpojumu savstarpējo izmantojamību" },
                { "Maltese (MT): REGOLAMENT TAL-KUMMISSJONI (UE) Nru 1089/2010", "REGOLAMENT TAL-KUMMISSJONI (UE) Nru 1089/2010 tat-23 ta\' Novembru 2010 li jimplimenta d-Direttiva 2007/2/KE tal-Parlament Ewropew u tal-Kunsill fir-rigward tal- interoperabbiltà tas-settijiet ta’ dejta u servizzi ġeografiċi" },
                { "Dutch (NL): VERORDENING (EU) Nr. 1089/2010 VAN DE COMMISSIE", "VERORDENING (EU) Nr. 1089/2010 VAN DE COMMISSIE van 23 november 2010 ter uitvoering van Richtlijn 2007/2/EG van het Europees Parlement en de Raad betreffende de interoperabiliteit van verzamelingen ruimtelijke gegevens en van diensten met betrekking tot ruimtelijke gegevens" },
                { "Polish (PL): ROZPORZĄDZENIE KOMISJI (UE) NR 1089/2010", "ROZPORZĄDZENIE KOMISJI (UE) NR 1089/2010 z dnia 23 listopada 2010 r. w sprawie wykonania dyrektywy 2007/2/WE Parlamentu Europejskiego i Rady w zakresie interoperacyjności zbiorów i usług danych przestrzennych" },
                { "Portuguese (PT): REGULAMENTO (UE) N. o 1089/2010 DA COMISSÃO", "REGULAMENTO (UE) N. o 1089/2010 DA COMISSÃO de 23 de Novembro de 2010 que estabelece as disposições de execução da Directiva 2007/2/CE do Parlamento Europeu e do Conselho relativamente à interoperabilidade dos conjuntos e serviços de dados geográficos" },
                { "Romanian (RO): REGULAMENTUL (UE) NR. 1089/2010 AL COMISIEI", "REGULAMENTUL (UE) NR. 1089/2010 AL COMISIEI din 23 noiembrie 2010 de punere în aplicare a Directivei 2007/2/CE a Parlamentului European şi a Consiliului în ceea ce priveşte interoperabilitatea seturilor şi serviciilor de date spaţiale" },
                { "Slovak (SK): NARIADENIE KOMISIE (EÚ) č. 1089/2010", "NARIADENIE KOMISIE (EÚ) č. 1089/2010 z 23. novembra 2010, ktorým sa vykonáva smernica Európskeho parlamentu a Rady 2007/2/ES, pokiaľ ide o interoperabilitu súborov a služieb priestorových údajov" },
                { "Slovenian (SL): UREDBA KOMISIJE (EU) št. 1089/2010", "UREDBA KOMISIJE (EU) št. 1089/2010 z dne 23. novembra 2010 o izvajanju Direktive 2007/2/ES Evropskega parlamenta in Sveta glede medopravilnosti zbirk prostorskih podatkov in storitev v zvezi s prostorskimi podatki" },
                { "Swedish (SV): KOMMISSIONENS FÖRORDNING (EU) nr 1089/2010", "KOMMISSIONENS FÖRORDNING (EU) nr 1089/2010 av den 23 november 2010 om genomförande av Europaparlamentets och rådets direktiv 2007/2/EG vad gäller interoperabilitet för rumsliga datamängder och datatjänster" },
                { "Other", "Other" }
            }.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

      Loaded += CI_Citation_Loaded;
    }

    public static readonly DependencyProperty SupressPartiesProperty = DependencyProperty.Register(
       "SupressParties",
       typeof(Boolean),
       typeof(MTK_CI_Citation));

    public static readonly DependencyProperty SupressOnlineResourceProperty = DependencyProperty.Register(
       "SupressOnlineResource",
       typeof(Boolean),
       typeof(MTK_CI_Citation));

    public static readonly DependencyProperty DefaultTitleProperty = DependencyProperty.Register(
       "DefaultTitle",
       typeof(string),
       typeof(MTK_CI_Citation));

    public static readonly DependencyProperty DefaultLinkageProperty = DependencyProperty.Register(
       "DefaultLinkage",
       typeof(string),
       typeof(MTK_CI_Citation));

    public static readonly DependencyProperty UseDropdownProperty = DependencyProperty.Register(
       "UseDropdown",
       typeof(bool),
       typeof(MTK_CI_Citation));

    public Boolean SupressParties
    {
      get { return (Boolean)this.GetValue(SupressPartiesProperty); }
      set { this.SetValue(SupressPartiesProperty, value); }
    }

    public Boolean SupressOnlineResource
    {
      get { return (Boolean)this.GetValue(SupressOnlineResourceProperty); }
      set { this.SetValue(SupressOnlineResourceProperty, value); }
    }

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

    public bool UseDropdown
    {
      get { return (bool)this.GetValue(UseDropdownProperty); }
      set { this.SetValue(UseDropdownProperty, value); }
    }

    private void CI_Citation_Loaded(object sender, RoutedEventArgs e)
    {
      SetDefaults();
    }

    private void SetDefaults()
    {
      var titleNode = GetTitleNode();
      if (titleNode != null && !string.IsNullOrWhiteSpace(DefaultTitle) && string.IsNullOrWhiteSpace(titleNode.InnerText))
      {
        titleNode.InnerText = DefaultTitle;
      }

      UseDropdown = false;
    }

    private void CI_Citation_title_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (!UseDropdown)
      {
        return;
      }

      var cb = (ComboBox)sender;
      var selectedVal = (string)cb.SelectedValue;
      OtherSelected = selectedVal == "Other";
      if (!OtherSelected)
      {
        var titleNode = GetTitleNode();
        if (titleNode != null)
        {
          titleNode.InnerText = selectedVal;
        }
      }
    }

    private void CI_Citation_title_combobox_Loaded(object sender, RoutedEventArgs e)
    {
      if (!UseDropdown)
      {
        return;
      }

      var titleNode = GetTitleNode();
      if (titleNode != null)
      {
        var cb = (ComboBox)sender;
        var dict = (Dictionary<string, string>)cb.ItemsSource;
        if (dict.ContainsValue(titleNode.InnerText))
        {
          cb.SelectedValue = titleNode.InnerText;
        }
        else
        {
          cb.SelectedValue = "Other";
        }
      }
    }

    private XmlNode GetTitleNode()
    {
      object context = Utils.Utils.GetDataContext(this);
      IEnumerable<XmlNode> nodes = Utils.Utils.GetXmlDataContext(context);
      if (null != nodes)
      {
        var node = nodes.First();
        return node.SelectSingleNode("resTitle");
      }

      return null;
    }
  }
}
