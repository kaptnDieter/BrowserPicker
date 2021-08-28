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
            Services.Setup.setDefaultSettings();


            //if software startet with arguments (happens when opend as default browser by windows) open url from args in specific browser
            //if no arguments submitted (.exe started manually by user), open the settings window
            if (e.Args.Length > 0)
            {
                url = e.Args[0];
                logWriter.WriteLog("Submitted URL: " + url);



                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\BrowserPicker\Settings"))
                {
                    if (key.GetValue("alwaysAsk", "false").ToString() == "true")
                    {
                        logWriter.WriteLog("alwaysAsk = true, open browser select");
                        /*open browser select menu
                        *
                        *
                        *
                        *
                        */
                        return;
                    }
                }


                if (Services.UrlProcessor.handleURL(url))
                {
                    logWriter.WriteLog("url handled successfull");
                    System.Windows.Application.Current.Shutdown();
                    return;
                }
                else
                {
                    logWriter.WriteLog("could not handle url, open browser select");

                    /*open browser select menu
                     *
                     *
                     *
                     *
                     */
                    System.Windows.Application.Current.Shutdown();
                }
            }
            else
            {
                logWriter.WriteLog("No URL submitted. open settings...");

                /*open settings
                *
                *
                *
                *
                */
                System.Windows.Application.Current.Shutdown();
            }


        }


    }
}
