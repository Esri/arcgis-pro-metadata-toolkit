using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace proapp_sdk_Wizard.Helpers {
    internal class MSIHelper {

        [DllImport("msi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern UInt32 MsiEnumRelatedProducts(string strUpgradeCode, int reserved, int iIndex, StringBuilder productCode);

        [DllImport("msi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern Int32 MsiGetProductInfo(string product, string property, [Out] StringBuilder valueBuf, ref int len);

        private ProjectHelper _hlpr = null;

        /// <summary>
        /// This identifier should never change for the lifetime of Pro
        /// </summary>
        public static readonly string ArcGISProUpgradeId = "{353C8253-C237-46A7-9124-88EFBF4A0C3E}";
        /// <summary>
        /// Used if the Msi fails on a release install
        /// </summary>
        public static readonly string RegisrtyKeyUseInCaseOfEmergencyOnly = "ArcGISPro";        

        public static Tuple<string, string> GetInstallDirAndVersion() {

            StringBuilder productCode = new StringBuilder(255);

            if (MsiEnumRelatedProducts(ArcGISProUpgradeId, 0, 0, productCode) != 0) {
                //Houston, we have a problem
                Debug.Assert(false, "DEBUG: DEBUG: The Msi could not resolve the current installed version of Pro!");
                //release - fallback on the hardcoded reg key
                return GetInstallDirAndVersionFromReg();
            }
            string[] properties = new string[] {"InstallLocation","VersionString"} ;
            string[] results = new string[properties.Length];
            int size = 1024;
            StringBuilder buffer = new StringBuilder(size);
            int i = 0;
            foreach (string prop in properties) {
                if (MsiGetProductInfo(productCode.ToString(), prop, buffer, ref size) != 0) {
                    //Houston, we have a problem
                    Debug.Assert(false, string.Format("DEBUG: DEBUG: The Msi could not resolve {0} for Pro!", prop));
                    return GetInstallDirAndVersionFromReg();
                }
                results[i++] = buffer.ToString();
                buffer.Clear();
                size = buffer.Capacity;//reset size
            }

            return new Tuple<string, string>(results[0], results[1]);
        }

        private static Tuple<string, string> GetInstallDirAndVersionFromReg() {
            string regKeyName = RegisrtyKeyUseInCaseOfEmergencyOnly;
            string regPath = string.Format(@"SOFTWARE\ESRI\{0}", regKeyName);

            string err1 = string.Format(Properties.Resource1.InstallDirMissing, string.Format(@"HKLM\{0}\{1}", regPath, "InstallDir"));            
            string err2 = string.Format(Properties.Resource1.VersionMissing, string.Format(@"HKLM\{0}\{1}", regPath, "Version"));
            

            string path = "";
            string version = "";
            try {
                RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey esriKey = localKey.OpenSubKey(regPath);

                if (esriKey == null) {
                    localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
                    esriKey = localKey.OpenSubKey(regPath);
                }
                if (esriKey == null) {
                    //this is an error
                    throw new System.InvalidOperationException(err1);
                }
                path = esriKey.GetValue("InstallDir") as string;
                if (path == null || path == string.Empty)
                    //this is an error
                    throw new InvalidOperationException(err1);

                version = esriKey.GetValue("Version") as string;
                if (version == null || version == string.Empty)
                    //this is an error
                    throw new InvalidOperationException(err2);
                
                //uncomment for major and minor only
                //var versionArr = version.Split(new char[] { '.' });
                //version = versionArr[0] + "." + versionArr[1];
            }
            catch (InvalidOperationException ie) {
                //this is ours
                throw ie;
            }
            catch (Exception ex) {
                throw new System.Exception(err1, ex);
            }
            return new Tuple<string, string>(path, version);
        }
    }
}
