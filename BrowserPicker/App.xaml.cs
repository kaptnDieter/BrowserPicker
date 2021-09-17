using BrowserPicker.Helpers;
using BrowserPicker.Models;
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
        public static LogWriter logWriter = new LogWriter(true);
        public static List<Setting> globalSettings = new List<Setting>();
        public static List<Models.Rule> globalRules = new List<Models.Rule>();

        private void App_Startup(object sender, StartupEventArgs e)
        {
            //when registry key writeLog is false, LogWriter gets set to false
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\User\Settings"))
            {
                if (key.GetValue("writeLog", "True").ToString() == "False")
                {
                    logWriter.useLog = false;
                }
            }
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SimpleBlue\BrowserPicker\Enterprise\Settings"))
            {
                if (key.GetValue("writeLog", "True").ToString() == "False")
                {
                    logWriter.useLog = false;
                }
            }

            logWriter.WriteLog("++++++++++++++++++++++++++++++++++++++++++++++++");
            logWriter.WriteLog("Program Started");


            //Get user and enterprise settings, merge settings and set as global
            List<Setting> userSettings = Services.Settings.getUserSettings();
            List<Setting> enterpriseSettings = Services.Settings.getEnterpriseSettings();
            globalSettings = Services.Settings.mergeSettings(userSettings, enterpriseSettings);

            //Get user and enterprise rules, merge rules and set as global
            List<Models.Rule> userRules = Services.Rules.getUserRules();
            List<Models.Rule> enterpriseRules = Services.Rules.getEnterpriseRules();
            globalRules = Services.Rules.mergeRules(userRules, enterpriseRules);


            //if software startet with arguments (happens when opend as default browser by windows) open url from args in specific browser
            //if no arguments submitted (.exe started manually by user), open the settings window
            if (e.Args.Length > 0)
            {
                string url = e.Args[0];
                logWriter.WriteLog("Submitted URL: " + url);


                if (App.globalSettings.Find(x => x.Name.Equals("alwaysAsk")).Value == "True")
                {
                    //open browser select menu
                    logWriter.WriteLog("alwaysAsk = True, open browser select");
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
