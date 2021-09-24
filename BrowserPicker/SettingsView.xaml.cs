using BrowserPicker.Models;
using BrowserPicker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace BrowserPicker
{
    /// <summary>
    /// Interaktionslogik für SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {

        public SettingsView()
        {
            InitializeComponent();

            List<Browser> browsers = new List<Browser>();
            browsers = Services.Browsers.getBrowsers();


            Datagrid_listOfRules.ItemsSource = App.globalRules;
            ListView_listOfBrowsers.ItemsSource = browsers;


            Checkbox_globalSettings_alwaysAsk.IsChecked = (App.globalSettings.Find(x => x.Name.Equals("alwaysAsk"))?.Value ?? "") == "True";
            Checkbox_globalSettings_alwaysAsk.IsEnabled = (App.globalSettings.Find(x => x.Name.Equals("alwaysAsk"))?.Enterprise ?? false) == false;

            Checkbox_globalSettings_writeLog.IsChecked = (App.globalSettings.Find(x => x.Name.Equals("writeLog"))?.Value ?? "") == "True";
            Checkbox_globalSettings_writeLog.IsEnabled = (App.globalSettings.Find(x => x.Name.Equals("writeLog"))?.Enterprise ?? false) == false;



            Combobox_defaultBrowser.Items.Add("");
            foreach (Browser browser in browsers)
            {
                Combobox_defaultBrowser.Items.Add(browser.Name);
            }





            Combobox_defaultBrowser.SelectedItem = (App.globalSettings.Find(x => x.Name.Equals("defaultBrowser"))?.Value ?? "");
            Combobox_defaultBrowser.IsEnabled = (App.globalSettings.Find(x => x.Name.Equals("defaultBrowser"))?.Enterprise ?? false) == false;


            foreach (Browser browser in browsers)
            {
                Combobox_newRuleBrowser.Items.Add(browser.Name);
            }

            button_AddRule.IsEnabled = (App.globalSettings.Find(x => x.Name.Equals("allowUserRules"))?.Value ?? "") != "False";

        }



        private void alwaysAsk_Changed(object sender, RoutedEventArgs e)
        {
            string value = Checkbox_globalSettings_alwaysAsk.IsChecked.ToString();
            Services.Settings.updateUserSetting("alwaysAsk", value);
        }

        private void writeLog_Changed(object sender, RoutedEventArgs e)
        {
            string value = Checkbox_globalSettings_writeLog.IsChecked.ToString();
            Services.Settings.updateUserSetting("writeLog", value);
        }

        private void Combobox_defaultBrowser_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string value = Combobox_defaultBrowser.SelectedItem.ToString();
            Services.Settings.updateUserSetting("defaultBrowser", value);
        }

        private void deleteRule(object sender, RoutedEventArgs e)
        {
            string url = ((Button)sender).Tag.ToString();

            if (Services.Rules.deleteUserRule(url))
            {
                List<Models.Rule> userRules = Services.Rules.getUserRules();
                List<Models.Rule> enterpriseRules = Services.Rules.getEnterpriseRules();
                App.globalRules = Services.Rules.mergeRules(userRules, enterpriseRules);
                Datagrid_listOfRules.ItemsSource = App.globalRules;
            }
            else
            {
                MessageBox.Show("Error while deleting rule");
            }
        }

        private void addRule(object sender, RoutedEventArgs e)
        {
            string url = Textbox_newRuleUrl.Text ?? "";
            string browser = (string)Combobox_newRuleBrowser.SelectedItem ?? "";

            if (Services.Rules.addUserRule(url, browser))
            {
                List<Models.Rule> userRules = Services.Rules.getUserRules();
                List<Models.Rule> enterpriseRules = Services.Rules.getEnterpriseRules();
                App.globalRules = Services.Rules.mergeRules(userRules, enterpriseRules);
                Datagrid_listOfRules.ItemsSource = App.globalRules;
            }
            else
            {
                MessageBox.Show("Error while creating rule");
            }
        }






    }



}