using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BrowserPicker.Models;

namespace BrowserPicker
{
    /// <summary>
    /// Interaktionslogik für SelectView.xaml
    /// </summary>
    public partial class SelectView : Window
    {
        public string url;
        public SelectView(string submittedUrl)
        {
            InitializeComponent();

            url = submittedUrl;

            List<Browser> browsers = new List<Browser>();
            browsers = Services.Browsers.getBrowsers();

            foreach(Browser browser in browsers)
            {
                string cleanIconSource = browser.Exec.Replace("\"", "");
                browser.Icon = Helpers.IconHandler.GetIcon(cleanIconSource);
            }

            ItemsControl_listOfBrowsers.ItemsSource = browsers;
            Label_url.Content = url;
        }



        void browserSelected_Click(object sender, RoutedEventArgs e)
        {
            string exec = (string)((Button)sender).Tag;
            Process.Start(exec, url);
            //System.Windows.Application.Current.Shutdown();
            Close();
        }


        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            try
            {
                Close();
            }
            catch
            {

            }
        }


    }
}
