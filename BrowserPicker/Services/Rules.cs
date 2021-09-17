using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BrowserPicker.Models;
using Microsoft.Win32;

namespace BrowserPicker.Services
{
    class Rules
    {
        public static List<Rule> getUserRules()
        {
            //List of rules
            List<Rule> listOfRules = new List<Rule>();

            //Add Rules
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\User\Rules"))
            {
                App.logWriter.WriteLog("--");
                App.logWriter.WriteLog("Read registry keys for user rules...");
                foreach (string entryName in key.GetValueNames())
                {
                    string entryData = key.GetValue(entryName, "").ToString();
                    listOfRules.Add(new Rule(entryName, entryData));

                    App.logWriter.WriteLog("browser: " + entryName + ", " + "url: " + entryData);
                }
            }

            listOfRules.Sort((x, y) => string.Compare(x.Browser, y.Browser));

            return listOfRules;
        }

        public static List<Rule> getEnterpriseRules()
        {
            //List of rules
            List<Rule> listOfRules = new List<Rule>();

            //Add Rules
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\Enterprise\Rules"))
            {
                App.logWriter.WriteLog("--");
                App.logWriter.WriteLog("Read registry keys for enterprise rules...");
                foreach (string entryName in key.GetValueNames())
                {
                    string entryData = key.GetValue(entryName, "").ToString();
                    listOfRules.Add(new Rule(entryName, entryData));

                    App.logWriter.WriteLog("browser: " + entryName + ", " + "url: " + entryData);
                }
            }

            listOfRules.Sort((x, y) => string.Compare(x.Browser, y.Browser));

            return listOfRules;
        }

        //Adds user rules not existend in enterprise rules to the end
        public static List<Rule> mergeRules(List<Rule> userRules, List<Rule> enterpriseRules)
        {
            //overwrite userRules with enterpriseRules
            foreach (Rule userRule in userRules)
            {
               if(enterpriseRules.Find(x => x.Url.Equals(userRule.Url)) == null)
               {
                    enterpriseRules.Add(userRule);
               }
            }

            //Log globalSettings
            App.logWriter.WriteLog("--");
            App.logWriter.WriteLog("Logging global rules...");
            foreach (Rule rule in enterpriseRules)
            {
                App.logWriter.WriteLog("Url: " + rule.Url + ", " + "Browser: " + rule.Browser);
            }

            return enterpriseRules;
        }


        public static bool deleteUserRule(string url)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\User\Rules"))
                {
                    key.DeleteValue(url);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool addUserRule(string url, string browser)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\User\Rules"))
                {
                    key.SetValue(url, browser);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

      

    }
}
