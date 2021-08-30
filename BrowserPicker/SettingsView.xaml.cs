using BrowserPicker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BrowserPicker
{
    /// <summary>
    /// Interaktionslogik für SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        List<Rule> listOfRules;
        List<Browser> listOfBrowsers;

        public SettingsView()
        {
            InitializeComponent();

            listOfRules = new List<Rule>();
            listOfBrowsers = new List<Browser>();

            //Get list of available rules
            listOfRules = Services.Rules.getRules();


            //Get list of available browsers
            listOfBrowsers = Services.Browsers.getBrowsers();

            listOfRules_ListView.DataContext = listOfRules;
        }
    }
}
