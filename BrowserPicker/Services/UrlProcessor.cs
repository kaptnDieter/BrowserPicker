using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using BrowserPicker.Models;
using Microsoft.Win32;

namespace BrowserPicker.Services
{
    class UrlProcessor
    {
        public static bool handleURL(string url)
        {
            //Get list of rules
            List<Rule> listOfRules = new List<Rule>();
            listOfRules = Services.Rules.getRules();

            //write data to log
            App.logWriter.WriteLog("List of rules:");
            foreach (var rule in listOfRules)
            {
                App.logWriter.WriteLog("browser: " + rule.browser + ", " + "url: " + rule.url);
            }


            //Get list of available browsers
            List<Browser> listOfBrowsers = new List<Browser>();
            listOfBrowsers = Services.Browsers.getBrowsers();

            //write data to log
            App.logWriter.WriteLog("List of Browsers:");
            foreach (var browser in listOfBrowsers)
            {
                App.logWriter.WriteLog("name: " + browser.name + ", " + "exec: " + browser.exec);
            }

            //check if submitted url matches any rule in listOfRules
            foreach (var rule in listOfRules)
            {
                if (UrlMatch(url, rule.url))
                {
                    App.logWriter.WriteLog("Found a matching rule: " + rule.url + ", browser: " + rule.browser);
                    //openURL in browser
                    //string browserExec = listOfBrowsers.First(item => item.name == rule.browser).exec;

                    string browserExec = findBrowserInList(rule.browser, listOfBrowsers);
                    if (browserExec != null)
                    {
                        openURL(browserExec, url);
                        //exit loop after first match
                        return true;
                    }
                    else
                    {
                        App.logWriter.WriteLog("There is a rule für this url, but the browser does not exist on your system. Browser from rule: " + rule.browser);
                        MessageBox.Show("There is a rule für this url, but the browser does not exist on your system", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }

                }
            }

            //Check if a default browser is defined in settings
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\BrowserPicker\Settings"))
            {
                string defaultBrowser = key.GetValue("defaultBrowser", "").ToString();
                if (defaultBrowser != "")
                {
                    string browserExec = findBrowserInList(defaultBrowser, listOfBrowsers);
                    if (browserExec != null)
                    {
                        openURL(browserExec, url);
                        //exit function
                        return true;
                    }
                    else
                    {
                        App.logWriter.WriteLog("No rule for URL defined, the defined default browser is '" + defaultBrowser + "' but this browser does not exist on the system");
                        MessageBox.Show("No rule for URL defined, the defined default browser is '" + defaultBrowser + "' but this browser does not exist on the system", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }



        public static bool UrlMatch(string url, string rule)
        {
            //add ^ and $ to the rule string to make sure thow whole string has to match
            //replace * with [^ ]* which is an asterix for zero or more non space characters
            string regexPattern = Regex.Replace("^" + rule + "$", "\\*", "[^ ]*");
            var regex = new Regex(regexPattern);
            return regex.Match(url).Success;
        }


        //Opens browser. Needs the path to the browser.exe and the url to open
        public static void openURL(string exec, string url)
        {
            Process.Start(exec, url);
        }

        public static string findBrowserInList(string browser, List<Browser> list)
        {
            try
            {
                string browserExec = list.First(item => item.name == browser).exec;
                return browserExec;
            }
            catch
            {
                return null;
            }
        }
    }
}
