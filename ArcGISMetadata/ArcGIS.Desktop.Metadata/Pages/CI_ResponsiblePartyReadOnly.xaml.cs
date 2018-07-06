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

using System.Windows.Controls;

namespace ArcGIS.Desktop.Metadata.Editor.Pages
{
  /// <summary>
  /// Interaction logic for CI_ResponsiblePartyReadOnly.xaml
  /// </summary>
  internal partial class CI_ResponsiblePartyReadOnly : EditorPage
  {
    public CI_ResponsiblePartyReadOnly()
    {
      InitializeComponent();
    }

    public override string DefaultValue
    {
      get
      {
        return Utils.ExtractResponsiblePartyLabel(this, Internal.Metadata.Properties.Resources.LBL_CI_PARTY_READONLY_FORMAT);
      }

      set
      {
        // NOOP
      }
    }
  }
}
