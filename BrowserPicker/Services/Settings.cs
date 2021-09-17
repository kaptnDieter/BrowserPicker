using System;
using System.Collections.Generic;
using System.Text;
using BrowserPicker.Models;
using Microsoft.Win32;

namespace BrowserPicker.Services
{
    class Settings
    {
        public static List<Setting> getUserSettings()
        {
            //List of settings
            List<Setting> listOfSettings = new List<Setting>();

            //Add setting
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\User\Settings"))
            {
                App.logWriter.WriteLog("Read registry keys for user settings...");
                foreach (string entryName in key.GetValueNames())
                {
                    string entryData = key.GetValue(entryName, "").ToString();
                    listOfSettings.Add(new Setting(entryName, entryData));

                    App.logWriter.WriteLog("ruleName: " + entryName + ", " + "ruleValue: " + entryData);
                }
            }

            return listOfSettings;
        }

        public static List<Setting> getEnterpriseSettings()
        {
            //List of settings
            List<Setting> listOfSettings = new List<Setting>();

            //Add setting
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\Enterprise\Settings"))
            {
                App.logWriter.WriteLog("Read registry keys for enterprise settings...");
                foreach (string entryName in key.GetValueNames())
                {
                    string entryData = key.GetValue(entryName, "").ToString();
                    listOfSettings.Add(new Setting(entryName, entryData));

                    App.logWriter.WriteLog("ruleName: " + entryName + ", " + "ruleValue: " + entryData);
                }
            }

            return listOfSettings;
        }

        public static List<Setting> mergeSettings(List<Setting> userSettings, List<Setting> enterpriseSettings)
        {
            //overwrite userSettings with enterpriseSettings
            foreach (Setting enterpriseSetting in enterpriseSettings)
            {
                int index = userSettings.FindIndex(ind => ind.Equals(enterpriseSetting.Name));
                if (index != -1)
                {
                    userSettings[index].Value = enterpriseSetting.Value;
                }
                else
                {
                    userSettings.Add(new Setting(enterpriseSetting.Name, enterpriseSetting.Value));
                }
            }

            //Log globalSettings
            App.logWriter.WriteLog("Logging global settings...");
            foreach (Setting setting in userSettings)
            {
                App.logWriter.WriteLog("ruleName: " + setting.Name + ", " + "ruleValue: " + setting.Value);
            }

            return userSettings;
        }

        public static bool updateUserSetting(string name, string value)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\User\Settings"))
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
