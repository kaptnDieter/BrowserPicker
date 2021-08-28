using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BrowserPicker.Helpers
{
    public class LogWriter
    {
        public bool useLog { get; set; }
        public LogWriter(bool submittedUseLog)
        {
            useLog = submittedUseLog;
        }

        public void WriteLog(string strLog)
        {
            if (useLog)
            {
                StreamWriter log;
                FileStream fileStream = null;
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;

                //string logFilePath = @"C:\Logs\";
                //C: \Users\xxxxxx\AppData\Roaming\BrowserPicker
                string logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BrowserPicker\\");

                logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
                logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                log = new StreamWriter(fileStream);
                log.WriteLine(strLog);
                log.Close();
            }
        }
    }
}
