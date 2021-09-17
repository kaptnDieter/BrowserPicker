using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace BrowserPicker.Helpers
{
    class IconHandler
    {

        public static ImageSource GetIcon(string fileName)
        {
            Icon icon = Icon.ExtractAssociatedIcon(fileName);
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, new Int32Rect(0, 0, icon.Width, icon.Height), BitmapSizeOptions.FromEmptyOptions());
        }





    }

}
