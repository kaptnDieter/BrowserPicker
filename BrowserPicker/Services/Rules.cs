using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserPicker.Models;
using Microsoft.Win32;

namespace BrowserPicker.Services
{
    class Rules
    {
        public static List<Rule> getRules()
        {
            //List of rules
            List<Rule> listOfRules = new List<Rule>();

            //Add Rules
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\BrowserPicker\Rules"))
            {
                App.logWriter.WriteLog("Read registry keys for rules...");
                foreach (string entryName in key.GetValueNames())
                {
                    string entryData = key.GetValue(entryName, "").ToString();
                    listOfRules.Add(new Rule(entryName, entryData));
                }
            }

            listOfRules.Sort((x, y) => string.Compare(x.Browser, y.Browser));

            return listOfRules;
        }

    }
}
