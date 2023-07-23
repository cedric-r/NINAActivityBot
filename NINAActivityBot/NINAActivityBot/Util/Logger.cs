using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Util
{
    public static class Logger
    {
        public static void Log(string message)
        {
            if (Constants.LogToConsole) Console.WriteLine(DateTime.Now + " " + message);
        }
    }
}
