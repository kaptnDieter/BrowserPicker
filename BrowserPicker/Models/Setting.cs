using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserPicker.Models
{
    public class Setting
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public Setting(string submittedName, string submittedValue)
        {
            Name = submittedName;
            Value = submittedValue;
        }
    }
}
