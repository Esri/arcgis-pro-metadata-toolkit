using ArcGIS.Desktop.Metadata.Editor.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation.Peers;
using System.Windows.Data;
using System.Xml;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_INSPIRE_LegalConstraints.xaml
  /// </summary>
  internal partial class MTK_INSPIRE_LegalConstraints : EditorPage
    {
        public MTK_INSPIRE_LegalConstraints()
        {
            InitializeComponent();
            Loaded += INSPIRE_LegalConstraints_Loaded;
        }

        private void INSPIRE_LegalConstraints_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateLegalConstraints();
        }

        private void CreateLegalConstraints()
        {
            object context = Utils.Utils.GetDataContext(this);
            IEnumerable<XmlNode> nodes = Utils.Utils.GetXmlDataContext(context);
            if (null != nodes)
            {
                var node = (XmlDocument) nodes.First();
                var parentNode = node.SelectSingleNode("/metadata/dataIdInfo");
                XmlNode useLimNode = node.SelectSingleNode("/metadata/dataIdInfo/resConst/LegConsts/inspireAccessUseConditions/ConditionsAccUseCd");
                XmlNode accessConstNode = node.SelectSingleNode("/metadata/dataIdInfo/resConst/LegConsts/inspirePublicAccessLimits/PublicAccessCd");
                
                if (useLimNode == null)
                {
                    CreateInspireConstraint(parentNode, "InspireUseLim");
                }
                if (accessConstNode == null)
                {
                    CreateInspireConstraint(parentNode, "InspireAccessConst");
                }
            }
        }

        private void CreateInspireConstraint(XmlNode node, string resourceName)
        {
            // get the skeleton XML, and replace the 'rel' attribute
            XmlDataProvider provider = Resources[resourceName] as XmlDataProvider;
            string xmlString = provider.Document.InnerXml;
            XmlDocument newDoc = new XmlDocument();
            newDoc.LoadXml(xmlString);

            // copy new XML into document
            Utils.Utils.CopyElements(node, newDoc.FirstChild, false, true);
        }
    }
}
