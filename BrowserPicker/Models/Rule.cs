using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserPicker.Models
{
    public class Rule
    {
        public string Url { get; set; }
        public string Browser { get; set; }

        public Rule(string submittedUrl, string submittedBrowser)
        {
            Url = submittedUrl;
            Browser = submittedBrowser;
        }


    }
}
