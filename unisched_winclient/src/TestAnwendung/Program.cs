using System;
using System.Windows.Forms;
using Unisched.Core;
using Unisched.Logging;

namespace TestAnwendung
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Logger.Initialize("main.config");
            AppSettings.LoadSettings(string.Format("{0}application.config", AppSettings.SettingsPath));
            Application.Run(new Form1());
            AppSettings.SaveSettings(string.Format("{0}application.config", AppSettings.SettingsPath));
        }
    }
}