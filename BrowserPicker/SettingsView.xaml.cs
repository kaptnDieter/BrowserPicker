using BrowserPicker.Models;
using BrowserPicker.Services;
using System.Collections.Generic;
using System.Windows;

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

            List<Rule> rules = new List<Rule>();
            rules = Services.Rules.getRules();

            List<Browser> browsers = new List<Browser>();
            browsers = Services.Browsers.getBrowsers();

            ListView_listOfRules.ItemsSource = rules;
            ListView_listOfBrowsers.ItemsSource = browsers;
        }
    }
}
