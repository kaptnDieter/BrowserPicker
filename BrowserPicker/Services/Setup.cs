using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using BrowserPicker.Helpers;
using System.Diagnostics;

namespace BrowserPicker.Services
{
    class Setup
    {
        /*
         * 
        //set the dault values for the settings
        public static void setDefaultUserSettings()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\User\Settings"))
            {
                key.SetValue("writeLog", "true");
                key.SetValue("alwaysAsk", "false");
                key.SetValue("defaultBrowser", "");
            }
        }

        //check if any settings are set
        public static bool checkForDefaultUserSettings()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\User\Settings"))
            {
                if (key.ValueCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        //https://docs.microsoft.com/de-de/windows/win32/shell/start-menu-reg?redirectedfrom=MSDN
        //https://stackoverflow.com/questions/32354861/how-to-find-the-default-browser-via-the-registry-on-windows-10
        //https://www.codeproject.com/Articles/4808/All-you-wanted-to-know-about-the-Registry-with-C-P
        
        
        public static void RegisterAsBrowser()
        {
            string exe = Process.GetCurrentProcess().MainModule.FileName;

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker"))
            {
                key.SetValue("", "BrowserPicker");
            }

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker\Capabilities"))
            {
                string value = exe + ",0";
                key.SetValue("ApplicationName", "BrowserPicker");
                key.SetValue("ApplicationDescription", "Let the user decide which browser to use to open a link");
                key.SetValue("ApplicationIcon", value);
            }

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker\Capabilities\StartMenu"))
            {
                key.SetValue("StartMenuInternet", "BrowserPicker");
            }

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker\Capabilities\URLAssociations"))
            {
                key.SetValue("http", "BrowserPickerURL");
                key.SetValue("https", "BrowserPickerURL");
            }

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker\DefaultIcon"))
            {
                string icon = exe + ",0";
                key.SetValue("", icon);
            }

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker\shell\open\command"))
            {
                key.SetValue("", exe);
            }

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\RegisteredApplications"))
            {
                key.SetValue("BrowserPicker", @"Software\Clients\StartMenuInternet\BrowserPicker\Capabilities");
            }

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\BrowserPickerURL"))
            {
                key.SetValue("", "BrowserPicker Url");
            }

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\BrowserPickerURL\shell\open\command"))
            {
                string value = "\"" + exe + "\"" + " " + "\"" + "%1" + "\"";
                key.SetValue("", value);
            }
        }
        */

    }
}
