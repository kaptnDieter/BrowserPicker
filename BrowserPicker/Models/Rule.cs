using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserPicker.Models
{
    class Rule
    {
        public string url;
        public string browser;

        public Rule(string submittedUrl, string submittedBrowser)
        {
            url = submittedUrl;
            browser = submittedBrowser;
        }


    }
}
