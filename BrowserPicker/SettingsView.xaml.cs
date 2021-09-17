using BrowserPicker.Models;
using BrowserPicker.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

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

            Checkbox_globalSettings_alwaysAsk.IsChecked = (App.globalSettings.Find(x => x.Name.Equals("alwaysAsk")).Value == "True");
            Checkbox_globalSettings_writeLog.IsChecked = (App.globalSettings.Find(x => x.Name.Equals("writeLog")).Value == "True");



            Combobox_defaultBrowser.Items.Add("");
            foreach (Browser browser in browsers)
            {
                Combobox_defaultBrowser.Items.Add(browser.Name);
            }
            Combobox_defaultBrowser.SelectedItem = App.globalSettings.Find(x => x.Name.Equals("defaultBrowser")).Value;


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
                //DELETE ROW HERE
            }
        }



    }



}