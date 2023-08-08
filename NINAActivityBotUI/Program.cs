using System.Runtime.InteropServices;

namespace NINAActivityBotUI
{
    [Guid("3a7e63ad-c813-44f0-9489-e1744c9c2992")]
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}