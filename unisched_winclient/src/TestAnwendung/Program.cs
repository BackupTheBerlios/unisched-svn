using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            Logger.Info("Starte Anwendung.");
            Application.Run(new Form1());
        }
    }
}