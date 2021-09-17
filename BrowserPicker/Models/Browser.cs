using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BrowserPicker.Models
{
    class Browser
    {
        public string Name { get; set; }
        public string Exec { get; set; }
        public ImageSource Icon { get; set; }


        public Browser(string submittedName, string submittedExec, ImageSource submittedIcon)
        {
            Name = submittedName;
            Exec = submittedExec;
            Icon = submittedIcon;
        }


    }
}
