using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserPicker.Models
{
    class Browser
    {
        public string name;
        public string exec;
        public string icon;


        public Browser(string submittedName, string submittedExec, string submittedIcon)
        {
            name = submittedName;
            exec = submittedExec;
            icon = submittedIcon;
        }


    }
}
