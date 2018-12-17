using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metadata_toolkit_wizard.ConfigureAddins {
    internal class MakeAddinConfig {
        /// <summary>
        /// Create the confiuration module relevant to the addintype
        /// </summary>
        /// <param name="addinType"></param>
        /// <returns></returns>
        public static IAddinConfig Create(string templateType, string addinType) {
            if (addinType == "module") {
                return new ConfigureModule() {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }
            else if (addinType == "configuration")
            {
                return new ConfigureConfiguration()
                {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }
            else if (addinType == "button") {
                return new ConfigureButton() {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }
            else if (addinType == "buttonpalette")
            {
                return new ConfigureButtonPalette()
                {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }
            else if (addinType == "splitbutton")
            {
                return new ConfigureSplitButton()
                {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }

            else if (addinType == "gallery") {
                return new ConfigureGallery() {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }
            else if (addinType == "inlinegallery")
            {
              return new ConfigureInlineGallery()
              {
                TemplateType = templateType,
                AddinType = addinType
              };
            }
            else if (addinType == "dockpane")
            {
                return new ConfigureDockPane()
                {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }
            else if (addinType == "dockpane_burgerbutton")
            {
              return new ConfigureDockPane()
              {
                TemplateType = templateType,
                AddinType = addinType
              };
            }
            else if (addinType == "tool")
            {
             return new ConfigureTool()
                {
                    TemplateType = templateType,
                    AddinType = addinType
                };
             }

            else if (addinType == "pane")
            {
              return new ConfigurePane()
              {
                TemplateType = templateType,
                AddinType = addinType
              };
            }
            else if (addinType == "menu")
            {
              return new ConfigureMenu()
              {
                TemplateType = templateType,
                AddinType = addinType
              };
            }
            else if (addinType == "map_pane_impersonate")
            {
                return new ConfigurePane()
                {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }
            else if (addinType == "constructiontool")
            {
              return new ConfigureConstructionTool()
              {
                TemplateType = templateType,
                AddinType = addinType
              };
            }
            else if (addinType == "drophandler")
            {
              return new ConfigureDropHandler()
              {
                TemplateType = templateType,
                AddinType = addinType
              };
            }
            else if (addinType == "combobox")
            {
                return new ConfigureComboBox()
                {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }
            else if (addinType == "embeddablecontrol")
            {
              return new ConfigureEmbeddableControl()
              {
                TemplateType = templateType,
                AddinType = addinType
              };
            }
            else if (addinType == "customcontrol")
            {
              return new ConfigureCustomControl()
              {
                TemplateType = templateType,
                AddinType = addinType
              };
            }
            else if (addinType == "propertysheet")
            {
                return new ConfigurePropertySheet()
                {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }
            else if (addinType == "backstagetab")
            {
                return new ConfigureBackstageTab()
                {
                    TemplateType = templateType,
                    AddinType = addinType
                };
            }

            throw new NotImplementedException(string.Format("Configuration not supported for {0}", addinType)) ;
        }
    }
}
