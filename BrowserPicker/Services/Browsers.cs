using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserPicker.Helpers;
using BrowserPicker.Models;
using Microsoft.Win32;

namespace BrowserPicker.Services
{
    class Browsers
    {
        public static List<Browser> getBrowsers()
        {
            //List of browsers
            List<Browser> listOfBrowsers = new List<Browser>();

            //Add browsers (OpenSubKey because user only read rights)
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Clients\StartMenuInternet"))
            {
                App.logWriter.WriteLog("Read registry keys for browsers...");
                foreach (string subkeyName in key.GetSubKeyNames())
                {
                    var subKey = key.OpenSubKey(subkeyName);
                    string name = subKey.GetValue("", "").ToString();
                    string exec = subKey.OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue("", "").ToString();

                    App.logWriter.WriteLog("name: " + name + ", " + "exec: " + exec);

                    listOfBrowsers.Add(new Browser(name, exec, ""));
                }
            }

            listOfBrowsers.Sort((x, y) => string.Compare(x.Name, y.Name));

            return listOfBrowsers;
        }


    }
}
