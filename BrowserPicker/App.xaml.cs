using BrowserPicker.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace BrowserPicker
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string url { get; set; } = "https://www.google.com";

        public static LogWriter logWriter = new LogWriter(true);


        private void App_Startup(object sender, StartupEventArgs e)
        {

            //when registry key writeLog is false, LogWriter gets set to false
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\BrowserPicker\Settings"))
            {
                if (key.GetValue("writeLog", "true").ToString() == "false")
                {
                    logWriter.useLog = false;
                }
            }

            logWriter.WriteLog("++++++++++++++++++++++++++++++++++++++++++++++++");
            logWriter.WriteLog("Program Started");


            Services.Setup.RegisterAsBrowser();

            //only set default settings if no settings in registry
            if (!Services.Setup.checkForDefaultSettings())
            {
                logWriter.WriteLog("No settings found, creating default settings");
                Services.Setup.setDefaultSettings();
            }

            //if software startet with arguments (happens when opend as default browser by windows) open url from args in specific browser
            //if no arguments submitted (.exe started manually by user), open the settings window
            if (e.Args.Length > 0)
            {
                url = e.Args[0];
                logWriter.WriteLog("Submitted URL: " + url);


                string alwaysAsk = "false";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\BrowserPicker\Settings"))
                {
                    alwaysAsk = key.GetValue("alwaysAsk", "false").ToString();
                }

                if (alwaysAsk == "true")
                {
                    //open browser select menu
                    logWriter.WriteLog("alwaysAsk = true, open browser select");
                    SelectView selectWindow = new SelectView(e.Args[0]);
                    selectWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    selectWindow.Show();
                }
                //handle url and try to find matching rule for url
                else if (Services.UrlProcessor.handleURL(url))
                {
                    logWriter.WriteLog("url handled successfull");
                    System.Windows.Application.Current.Shutdown();
                }
                else
                {
                    //open browser select menu
                    logWriter.WriteLog("could not handle url, open browser select");
                    SelectView selectWindow = new SelectView(e.Args[0]);
                    selectWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    selectWindow.Show();
                }
            }
            else
            {
                logWriter.WriteLog("No URL submitted. open settings...");

                //open settings
                SettingsView settingsWindow = new SettingsView();
                settingsWindow.Show();
            }


        }


    }
}
