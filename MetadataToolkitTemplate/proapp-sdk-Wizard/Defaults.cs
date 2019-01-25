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
