using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unisched.Core;
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
            AppSettings.LoadSettings(string.Format("{0}application.config", AppSettings.SettingsPath));
            Uuser login = new Uuser();
            login.ShowDialog();
            if (login.validated)
            {
                Application.Run(new FormMain(login.admin,login.uName));
                AppSettings.SaveSettings(string.Format("{0}application.config", AppSettings.SettingsPath));
            }
        }
    }
}