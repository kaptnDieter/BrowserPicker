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
        //set the dault values for the settings
        public static void setDefaultSettings()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\BrowserPicker\Settings"))
            {
                key.SetValue("version", "1.0");
                key.SetValue("writeLog", "true");
                key.SetValue("alwaysAsk", "false");
                key.SetValue("defaultBrowser", "Microsoft Edge");
            }
        }

        //check if any settings are set
        public static bool checkForDefaultSettings()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\BrowserPicker\Settings"))
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




        public static void RegisterAsBrowser()
        //-------------------------------------------------------------------------------------------------------------
        {
            string exe = Process.GetCurrentProcess().MainModule.FileName;


            /*
                [HKEY_CURRENT_USER\SOFTWARE\Clients\StartMenuInternet\BrowserPicker.exe]
                @="Browser Select"
            */
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker"))
            {
                key.SetValue("", "BrowserPicker");
            }

            /*
                [HKEY_CURRENT_USER\SOFTWARE\Clients\StartMenuInternet\BrowserPicker.exe\Capabilities]
                "ApplicationDescription"="Select which browser to open links with"
                "ApplicationIcon"="D:\\DEV\\GitHub\\BrowserPicker\\BrowserPicker\\bin\\Debug\\BrowserPicker.exe,0"
                "ApplicationName"="BrowserPicker"
            */
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker\Capabilities"))
            {
                string value = exe + ",0";
                key.SetValue("ApplicationName", "BrowserPicker");
                key.SetValue("ApplicationDescription", "Select which browser to open links with");
                key.SetValue("ApplicationIcon", value);
            }

            /*
                [HKEY_CURRENT_USER\SOFTWARE\Clients\StartMenuInternet\BrowserPicker.exe\Capabilities\StartMenu]
                "StartMenuInternet"="BrowserPicker.exe"
            */
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker\Capabilities\StartMenu"))
            {
                key.SetValue("StartMenuInternet", "BrowserPicker");
            }

            /*
                [HKEY_CURRENT_USER\SOFTWARE\Clients\StartMenuInternet\BrowserPicker.exe\Capabilities\URLAssociations]
                "http"="BrowserPickerURL"
                "https"="BrowserPickerURL"
            */
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker\Capabilities\URLAssociations"))
            {
                key.SetValue("http", "BrowserPickerURL");
                key.SetValue("https", "BrowserPickerURL");
            }

            /*
                [HKEY_CURRENT_USER\SOFTWARE\Clients\StartMenuInternet\BrowserPicker.exe\DefaultIcon]
                @="D:\\DEV\\GitHub\\BrowserPicker\\BrowserPicker\\bin\\Debug\\BrowserPicker.exe,0"
            */
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker\DefaultIcon"))
            {
                string value = exe + ",0";
                key.SetValue("", value);
            }

            /*
                [HKEY_CURRENT_USER\SOFTWARE\Clients\StartMenuInternet\BrowserPicker.exe\shell]
                [HKEY_CURRENT_USER\SOFTWARE\Clients\StartMenuInternet\BrowserPicker.exe\shell\open]
                [HKEY_CURRENT_USER\SOFTWARE\Clients\StartMenuInternet\BrowserPicker.exe\shell\open\command]
                @="\"D:\\DEV\\GitHub\\BrowserPicker\\BrowserPicker\\bin\\Debug\\BrowserPicker.exe\""
            */
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Clients\StartMenuInternet\BrowserPicker\shell\open\command"))
            {
                key.SetValue("", exe);
            }

            /*
                [HKEY_CURRENT_USER\SOFTWARE\RegisteredApplications]
                "BrowserPicker"="Software\\Clients\\StartMenuInternet\\BrowserPicker.exe\\Capabilities"
            */
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\RegisteredApplications"))
            {
                key.SetValue("BrowserPicker", @"Software\Clients\StartMenuInternet\BrowserPicker\Capabilities");
            }

            /*
                [HKEY_CURRENT_USER\SOFTWARE\Classes\BrowserPickerURL]
                @="BrowserPicker Url"
            */
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\BrowserPickerURL"))
            {
                key.SetValue("", "BrowserPicker Url");
            }

            /*
                [HKEY_CURRENT_USER\SOFTWARE\Classes\BrowserPickerURL\shell]
                [HKEY_CURRENT_USER\SOFTWARE\Classes\BrowserPickerURL\shell\open]
                [HKEY_CURRENT_USER\SOFTWARE\Classes\BrowserPickerURL\shell\open\command]
                @="\"D:\\DEV\\GitHub\\BrowserPicker\\BrowserPicker\\bin\\Debug\\BrowserPicker.exe\" \"%1\""
            */
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\BrowserPickerURL\shell\open\command"))
            {
                string value = "\"" + exe + "\"" + " " + "\"" + "%1" + "\"";
                key.SetValue("", value);
            }
        }

    }
}
