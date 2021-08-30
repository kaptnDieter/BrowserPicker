using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserPicker.Models
{
    class Browser
    {
        public string Name { get; set; }
        public string Exec { get; set; }
        public string Icon { get; set; }


        public Browser(string submittedName, string submittedExec, string submittedIcon)
        {
            Name = submittedName;
            Exec = submittedExec;
            Icon = submittedIcon;
        }


    }
}
