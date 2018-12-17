using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace metadata_toolkit_wizard.Helpers {
    public static class DAMLHelper {
        //http://schemas.esri.com/DADF/Registry

        public static XNamespace DefaultNS = "http://schemas.esri.com/DADF/Registry";
        
        public static string GetDefaultNamespace(this XDocument configDoc)
        {
            return configDoc.Root.Attribute("defaultNamespace").Value;
        }

        public static string GetDefaultAssembly(this XDocument configDoc)
        {
            return System.IO.Path.GetFileNameWithoutExtension(configDoc.Root.Attribute("defaultAssembly").Value);
        }

        /// <summary>
        /// Returns the modules (plural) element from the DAML config
        /// </summary>
        /// <param name="configDoc"></param>
        /// <returns></returns>
        public static XElement GetModulesElement(this XDocument configDoc) {
            IEnumerable<XElement> modules = from seg in configDoc.Root.Elements(DefaultNS + "modules") select seg;
            if (modules.Count() == 0)
                return null;
            return modules.First();
        }

        /// <summary>
        /// Returns the categories (plural) element from the DAML config
        /// </summary>
        /// <param name="configDoc"></param>
        /// <returns></returns>
        public static XElement GetCategoriesElement(this XDocument configDoc, bool create = true)
        {

            XElement category = configDoc.Root.Elements(DefaultNS + "categories").FirstOrDefault();
            if (category == null)
            {
                category = new XElement(DefaultNS + "categories");
                configDoc.Root.Add(category);
            }
            return category;
        }

        /// <summary>
        /// Returns the propertySheets (plural) element from the DAML config
        /// </summary>
        /// <param name="configDoc"></param>
        /// <returns></returns>
        public static XElement GetPropertySheetsElement(this XDocument configDoc, bool create = true)
        {

            XElement propertySheets = configDoc.Root.Elements(DefaultNS + "propertySheets").FirstOrDefault();
            if (propertySheets == null)
            {
                propertySheets = new XElement(DefaultNS + "propertySheets");
                configDoc.Root.Add(propertySheets);
            }
            return propertySheets;
        }

        /// <summary>
        /// Returns the backstage element from the DAML config
        /// </summary>
        /// <param name="configDoc"></param>
        /// <returns></returns>
        public static XElement GetBackstageElement(this XDocument configDoc, bool create = true)
        {

            XElement propertySheets = configDoc.Root.Elements(DefaultNS + "backstage").FirstOrDefault();
            if (propertySheets == null)
            {
                propertySheets = new XElement(DefaultNS + "backstage");
                configDoc.Root.Add(propertySheets);
            }
            return propertySheets;
        }

        /// <summary>
        /// Returns the categories (plural) element from the DAML config
        /// </summary>
        /// <param name="configDoc"></param>
        /// <returns></returns>
        public static XElement GetDropHandlersElement(this XDocument configDoc, bool create = true)
        {

          XElement dropHandlers = configDoc.Root.Elements(DefaultNS + "dropHandlers").FirstOrDefault();
          if (dropHandlers == null)
          {
            dropHandlers = new XElement(DefaultNS + "dropHandlers");
            configDoc.Root.Add(dropHandlers);
          }
          return dropHandlers;
        }


        /// <summary>
        /// Returns the module element from the DAML config.
        /// </summary>
        /// <remarks>May also be called &quot;insertModule&quot;</remarks>
        /// <param name="configDoc"></param>
        /// <returns></returns>
        public static XElement GetModuleElement(this XDocument configDoc) {
            XElement modules = configDoc.GetModulesElement();
            if (modules == null)
                return null;//throw?
            XElement module = modules.Element(DefaultNS + "module") ;
            if (module == null)
                module = modules.Element(DefaultNS + "insertModule");
            return module;
        }

        public static XElement GetControlsElement(this XDocument configDoc, bool create = false) {
            return GetChildofModuleElement(configDoc.Document.GetModuleElement(), "controls", create);
        }

        public static XElement GetGalleriesElement(this XDocument configDoc, bool create = false)
        {
          return GetChildofModuleElement(configDoc.Document.GetModuleElement(), "galleries", create);
        }
        public static XElement GetDockPanesElement(this XDocument configDoc, bool create = false)
        {
            return GetChildofModuleElement(configDoc.Document.GetModuleElement(), "dockPanes", create);
        }
        public static XElement GetPanesElement(this XDocument configDoc, bool create = false)
        {
          return GetChildofModuleElement(configDoc.Document.GetModuleElement(), "panes", create);
        }
        public static XElement GetMenusElement(this XDocument configDoc, bool create = false)
        {
            return GetChildofModuleElement(configDoc.Document.GetModuleElement(), "menus", create);
        }
        public static XElement GetPalettesElement(this XDocument configDoc, bool create = false)
        {
            return GetChildofModuleElement(configDoc.Document.GetModuleElement(), "palettes", create);
        }
        public static XElement GetSplitButtonsElement(this XDocument configDoc, bool create = false)
        {
            return GetChildofModuleElement(configDoc.Document.GetModuleElement(), "splitButtons", create);
        }

        public static XElement GetGroupsElement(this XDocument configDoc, bool create = false) {
            return GetChildofModuleElement(configDoc.Document.GetModuleElement(), "groups", create);
        }

        public static XElement GetGroupElement(this XDocument configDoc, string id, bool create = false) {
            XElement groupsElem = configDoc.GetGroupsElement();
            IEnumerable<XElement> groupChildren = groupsElem.Elements(DefaultNS + "group").Where(elem => (string)elem.Attribute("id") == id) ;
            if (groupChildren.Count() > 0)
                return groupChildren.First();
            XElement group = null ;
            if (create) {
                group = new XElement(DefaultNS + "group");
                group.SetAttributeValue("id", id) ;
                groupsElem.Add(group) ;
            }
            return group;
        }

        public static XElement GetGroupElement(this XDocument configDoc, ProjectHelper helper, bool appearsOnAddInTab = true, bool create = false) {
            XElement groupsElem = configDoc.GetGroupsElement(true);
            IEnumerable<XElement> groupChildren = groupsElem.Elements(DefaultNS + "group");
            XElement group = null;
            if (groupChildren.Count() > 0)
            {
                if (appearsOnAddInTab)
                {
                    group = groupsElem.Elements(DefaultNS + "group").FirstOrDefault(elem => elem.Attribute("appearsOnAddInTab") != null);
                    if (group != null)
                        return group;
                }
                return groupChildren.First();
            }
            if (create)
            {
                group = new XElement(DefaultNS + "group");
                group.SetAttributeValue("id", helper.ReplacementsDictionary["$rootnamespace$"] + "_Group1");
                group.SetAttributeValue("caption", "Group 1");
                group.SetAttributeValue("appearsOnAddInTab", "true");           
                groupsElem.Add(group);
            }
            return group;
        }

        public static XElement GetEmbeddableControlsUpdateCategory(this XDocument configDoc, bool create = false)
        {
            XElement categories = configDoc.GetCategoriesElement(true);
            var element = categories.Elements(DefaultNS + "updateCategory").FirstOrDefault(elem => elem.Attribute("refID") != null && elem.Attribute("refID").Value == "esri_embeddableControls");
            if (element == null && create)
            {
                element = new XElement(DAMLHelper.DefaultNS + "updateCategory");
                element.SetAttributeValue("refID", "esri_embeddableControls");
                categories.Add(element);
            }
            return element;
        }

        private static XElement GetChildofModuleElement(XElement module, string elementName, bool create = false) {
            if (module == null)
                return null;//throw?

            XElement child = module.Element(DefaultNS + elementName);
            if (child == null && create) {
                child = new XElement(DefaultNS + elementName);
                module.Add(child);
            }

            return child;
        }
    }
}
