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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace metadata_toolkit_wizard.Helpers
{
  internal class StringHelper
  {
    //Gets the base class name from "safeitemname" - eg gets Dockpane from DockpaneViewModel1.

    public static string GetBaseClassName(string className, string contains)
    {
      string[] stringSeparators = new string[] { contains };
      //Check if className contains the "contain" string. 
      if (className.IndexOf(contains, StringComparison.OrdinalIgnoreCase) >= 0)
      {
        //var tempstring = className.Split(stringSeparators, StringSplitOptions.None);
        var tempstring = Regex.Split(className, contains, RegexOptions.IgnoreCase); //split off viewmodel
        return tempstring[0];
      }
      else
        return className;
    }
  }
}
