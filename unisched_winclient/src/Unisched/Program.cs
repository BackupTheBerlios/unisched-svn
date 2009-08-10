using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unisched.Core;

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
            // hier Passwortabfrage nach dem Motto:
            //  LoginForm form = new LoginForm();
            //  if(form.ShowDialog() == DialogResult.OK)
            //  { das darunter machen, sonst passiert hier nix mehr
            Application.Run(new FormMain(true));
            AppSettings.SaveSettings(string.Format("{0}application.config", AppSettings.SettingsPath));
        }
    }
}