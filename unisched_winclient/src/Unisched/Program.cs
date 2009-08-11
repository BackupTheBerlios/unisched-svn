using System;
using System.Windows.Forms;
using Unisched.Core;
using Unisched.Logging;
using Unisched.User;

namespace Unisched
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
            Uuser login = new Uuser();
            while(!login.validated)
                if(login.ShowDialog()==DialogResult.Cancel)
                    break;
            if (login.validated)
            {
                Application.Run(new FormMain(login.admin,login.uName));
                AppSettings.SaveSettings(string.Format("{0}application.config", AppSettings.SettingsPath));
            }
        }
    }
}