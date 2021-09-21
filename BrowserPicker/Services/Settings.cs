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
                    listOfSettings.Add(new Setting(entryName, entryData, false));

                    App.logWriter.WriteLog("settingName: " + entryName + ", " + "settingValue: " + entryData);
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
                    listOfSettings.Add(new Setting(entryName, entryData, true));

                    App.logWriter.WriteLog("settingName: " + entryName + ", " + "settingValue: " + entryData);
                }
            }

            return listOfSettings;
        }

        //User settings get overwritten by possible enterprise settings
        public static List<Setting> mergeSettings(List<Setting> userSettings, List<Setting> enterpriseSettings)
        {
            //overwrite userSettings with enterpriseSettings
            foreach (Setting enterpriseSetting in enterpriseSettings)
            {
                int index = userSettings.FindIndex(x => x.Name.Equals(enterpriseSetting.Name));
                if (index != -1)
                {
                    userSettings[index].Value = enterpriseSetting.Value;
                    userSettings[index].Enterprise = true;
                }
                else
                {
                    userSettings.Add(new Setting(enterpriseSetting.Name, enterpriseSetting.Value, true));
                }
            }

            //Log globalSettings
            App.logWriter.WriteLog("Logging global settings...");
            foreach (Setting setting in userSettings)
            {
                App.logWriter.WriteLog("settingName: " + setting.Name + ", " + "settingValue: " + setting.Value + " Enterprise: " + setting.Enterprise);
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
