using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proapp_sdk_Wizard.Helpers
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
