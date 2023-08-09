using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Util
{
    public static class Logger
    {
        public static List<string> LogHistory = new List<string>();

        public static void Log(string message)
        {
            if (Constants.LogToConsole) Console.WriteLine(DateTime.Now + " " + message);
            if (Constants.LogToFile)
            {
                Config.CreateFolder();
                try
                {
                    string strPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                    strPath = Path.Combine(strPath, Constants.Name);
                    strPath = Path.Combine(strPath, "app.log");
                    System.IO.File.AppendAllText(strPath, DateTime.Now + " " + message + "\n");
                }
                catch (Exception) { }
            }
            if (Constants.LogToTextBox)
            {
                LogHistory.Add(DateTime.Now.ToString("HH:mm:ss")+ " " + message);
            }
        }
    }
}
