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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metadata_toolkit_wizard {

    internal static class Defaults {
        public static readonly string DefaultOrganization = "Acme";
        public static readonly string[] ImageExtensions = new string[] { ".png", ".bmp", ".jpg", ".gif" };
        public static readonly string[] controlAddinTypes = new string[] { "button", "buttonpalette", "splitbutton", 
                              "tool","gallery", "inlinegallery", "dockpane", "pane", "menu" , 
                              "constructiontool", "drophandler","combobox", "embeddablecontrol", "customcontrol",
                              "propertysheet", "backstagetab"};//etc.        

        public static readonly string ConfigXML = "Config.daml";


        public static Dictionary<string, string> FileNameBuildActionMap = new Dictionary<string, string>();
        //These are the file extensions (FileExtensions array) that this wizard will "fix". 
        //Visual Studio changes the BuildAction for these file types since this is a WPF project type.        
        public static readonly string[] FileExtensions = new string[] {".png", ".xaml"};

        //Note: These are the rest of the extensions that Visual Studio will fix. 
        //But these are not in a Pro Add-in so we are not "Fixing" these yet.
        /*
        // Treat this as "Page"
        "XAML=Page;" +
        // Treat these as "Resource"
        "XML=Resource;XSL=Resource;XSLT=Resource;TXT=Resource;BMP=Resource;ICO=Resource;CUR=Resource;" +
        "GIF=Resource;JPEG=Resource;JPE=Resource;JPG=Resource;PNG=Resource;DIB=Resource;TIFF=Resource;TIF=Resource;" +
        "INF=Resource;COMPOSITEFONT=Resource;OTF=Resource;TTF=Resource;TTC=Resource;TTE=Resource" ;
       */

        public static string Organization = "";

        public static Dictionary<string, string> ConditionMap = new Dictionary<string, string>() {
            {"esri_mapping_mapPane","A map is the active view"},
            {"esri_layouts_condition","A layout is the active view"},
            {"esri_editing_EditingCondition","Editing is enabled"},
            {"esri_mapping_tableCondition","Feature layer or table selected"}
        };

        public static Dictionary<string, string> DockWithOptionsMap = new Dictionary<string, string>() {
            {"esri_core_contentsDockPane","Content Pane"},
            {"esri_core_projectDockPane","Project Pane"}
        };

        public static Dictionary<string, string> DockMap = new Dictionary<string, string>() {
            {"group","Group"},
            {"top","Top"},
            {"bottom","Bottom"},
            {"left","Left"},
            {"right", "Right"}
        };

    }
}
