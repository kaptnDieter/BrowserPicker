using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace BrowserPicker.Helpers
{
    class IconHandler
    {







        public static Image String2Icon(string icon)
        {
            byte[] byteArray = Convert.FromBase64String(icon);
            Bitmap newIcon;
            using (System.IO.MemoryStream stream = new MemoryStream(byteArray))
            {
                newIcon = new Bitmap(stream);
            }
            return newIcon;
        }

        public static string Icon2String(Icon myIcon)
        {
            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                myIcon.ToBitmap().Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                bytes = ms.ToArray();
            }
            string iconString = Convert.ToBase64String(bytes);
            return iconString;
        }


        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern UInt32 PrivateExtractIcons(String lpszFile, int nIconIndex, int cxIcon, int cyIcon, IntPtr[] phicon, IntPtr[] piconid, UInt32 nIcons, UInt32 flags);
        
        static public Icon FromFile(string filename)
        {
            IntPtr[] phicon = new IntPtr[] { IntPtr.Zero };
            IntPtr[] piconid = new IntPtr[] { IntPtr.Zero };

            PrivateExtractIcons(filename, 0, 128, 128, phicon, piconid, 1, 0);

            if (phicon[0] != IntPtr.Zero)
            {
                return System.Drawing.Icon.FromHandle(phicon[0]);
            }

            return null;
        }




    }

}
