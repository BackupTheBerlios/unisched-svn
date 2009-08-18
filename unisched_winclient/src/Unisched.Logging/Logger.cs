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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace Unisched.Logging
{
    /// <summary>
    /// Bietet statische Methoden zum Logging an.
    /// Zur Verwendung muss zuerst die Methode <c>Logger.Initialize(string configuration)</c> aufgerufen werden.
    /// Das Feld <c>IsInitialized</c> gibt an, ob der Logger initialisiert wurde.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Interner Log4net-Logger.
        /// </summary>
        protected static ILog InternalLogger;

        /// <summary>
        /// Interne Variable die speichert, ob initalisiert wurde.
        /// </summary>
        protected static bool Initialized;

        /// <summary>
        /// Pfad zur Konfigurationsdatei.
        /// </summary>
        protected static string ConfigurationFile = string.Empty;

        /// <summary>
        /// Feld, das ausgibt, ob initialisiert wurde.
        /// </summary>
        public static bool IsInitialized
        {
            get
            {
                return Initialized;
            }
        }

        /// <summary>
        /// Gibt den Pfad zur Konfigurationsdatei aus.
        /// </summary>
        public static string ConfigFile
        {
            get
            {
                return ConfigurationFile;
            }
        }

        /// <summary>
        /// Initialisiert den Logger mit einer Konfigurationsdatei.
        /// </summary>
        /// <param name="configuration">Konfigurationsdateipfad</param>
        /// <returns></returns>
        public static bool Initialize(string configuration)
        {
            try
            {
                ConfigurationFile = configuration;

                if (File.Exists(configuration))
                {
                    FileInfo configFileInfo = new FileInfo(configuration);
                    XmlConfigurator.Configure(configFileInfo);

                    Initialized = true;

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                Initialized = false;

                return false;
            }
        }

        /// <summary>
        /// Initialisiert den Logger ohne Konfigurationsdatei und liest die Werte aus der Web.config/App.config.
        /// </summary>
        /// <returns></returns>
        public static bool Initialize()
        {
            try
            {
                XmlConfigurator.Configure();
                Initialized = true;

                return true;
            }
            catch (Exception)
            {
                Initialized = false;

                return false;
            }
        }

        /// <summary>
        /// Holt den Logger, der zur Assembly passt.
        /// </summary>
        private static void GetLogger()
        {
            StackFrame callStack = new StackFrame(2, true);
            try
            {
                InternalLogger =
                    LogManager.GetLogger(string.Format("{0} - {1}", Assembly.GetEntryAssembly().GetName().Name,
                                                       Path.GetFileName(callStack.GetFileName())));
            }
            catch
            {
                InternalLogger = LogManager.GetLogger("DefaultLogger");
            }
        }

        /// <summary>
        /// Gibt eine Debug-Meldung aus.
        /// </summary>
        /// <param name="message">Die Debug-Nachricht.</param>
        public static void Debug(object message)
        {
            GetLogger();
            InternalLogger.Debug(message);
        }

        /// <summary>
        /// Gibt eine Debug-Meldung mit Exception aus.
        /// </summary>
        /// <param name="message">Die Debug-Meldung</param>
        /// <param name="ex">Ausnahme</param>
        public static void Debug(object message, Exception ex)
        {
            GetLogger();
            InternalLogger.Debug(message, ex);
        }

        /// <summary>
        /// Gibt eine Fehler-Meldung aus.
        /// </summary>
        /// <param name="message">Die Fehler-Meldung.</param>
        public static void Error(object message)
        {
            GetLogger();
            InternalLogger.Error(message);
        }

        /// <summary>
        /// Gibt eine Fehlermeldung mit Exception aus.
        /// </summary>
        /// <param name="message">Die Fehler-Meldung.</param>
        /// <param name="ex">Ausnahme</param>
        public static void Error(object message, Exception ex)
        {
            GetLogger();
            InternalLogger.Error(message, ex);
        }

        /// <summary>
        /// Gibt einen fatalen Fehler aus.
        /// </summary>
        /// <param name="message">Der fatale Fehler.</param>
        public static void Fatal(object message)
        {
            GetLogger();
            InternalLogger.Fatal(message);
        }

        /// <summary>
        /// Gibt einen fatalen Fehler mit Exception aus.
        /// </summary>
        /// <param name="message">Der fatale Fehler.</param>
        /// <param name="ex">Ausnahme</param>
        public static void Fatal(object message, Exception ex)
        {
            GetLogger();
            InternalLogger.Fatal(message, ex);
        }

        /// <summary>
        /// Gibt eine Information aus.
        /// </summary>
        /// <param name="message">Info.</param>
        public static void Info(object message)
        {
            GetLogger();
            InternalLogger.Info(message);
        }

        /// <summary>
        /// Gibt einen Information mit Exception aus.
        /// </summary>
        /// <param name="message">Info.</param>
        /// <param name="ex">Ausnahme</param>
        public static void Info(object message, Exception ex)
        {
            GetLogger();
            InternalLogger.Info(message, ex);
        }

        /// <summary>
        /// Gibt eine Warnung aus.
        /// </summary>
        /// <param name="message">Die Warn-Meldung.</param>
        public static void Warn(object message)
        {
            GetLogger();
            InternalLogger.Warn(message);
        }

        /// <summary>
        /// Gibt eine Warnung mit Exception aus.
        /// </summary>
        /// <param name="message">Die Warn-Meldung.</param>
        /// <param name="ex">Ausnahme.</param>
        public static void Warn(object message, Exception ex)
        {
            GetLogger();
            InternalLogger.Warn(message, ex);
        }
    }
}
