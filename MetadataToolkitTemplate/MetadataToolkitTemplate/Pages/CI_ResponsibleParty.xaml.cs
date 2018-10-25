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

using ArcGIS.Desktop.Metadata.Editor.Pages;

namespace $safeprojectname$.Pages
{
  /// <summary>
  /// Interaction logic for CI_ResponsibleParty.xaml
  /// </summary>
  internal partial class MTK_CI_ResponsibleParty : EditorPage
  {
    public MTK_CI_ResponsibleParty()
    {
      InitializeComponent();
    }

    public override string DefaultValue
    {
      get
      {
        return Utils.ExtractResponsiblePartyLabel(this, $safeprojectname$.Properties.Resources.LBL_CI_PARTY_FORMAT);
      }

      set
      {
        // NOOP
      }
    }
  }
}
