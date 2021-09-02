using System;
using System.Collections.Generic;
using System.Text;
using BrowserPicker.Models;
using Microsoft.Win32;

namespace BrowserPicker.Services
{
    class Settings
    {
        public static List<Setting> getSettings()
        {
            //List of rules
            List<Setting> listOfSettings = new List<Setting>();

            //Add Rules
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\Settings"))
            {
                App.logWriter.WriteLog("Read registry keys for settings...");
                foreach (string entryName in key.GetValueNames())
                {
                    string entryData = key.GetValue(entryName, "").ToString();
                    listOfSettings.Add(new Setting(entryName, entryData));
                }
            }

            return listOfSettings;
        }


        public static bool updateSetting(string name, string value)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\Settings"))
                {
                    key.SetValue(name, value);
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
