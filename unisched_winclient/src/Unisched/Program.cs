/*
 *   This file is part of Unisched Winclient.
 *
 *   Unisched Winclient is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   Unisched Winclient is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with Unisched Winclient.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Globalization;
using System.Threading;
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
            string culture = AppSettings.GetSetting("culture");
            if (!string.IsNullOrEmpty(culture))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }
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
