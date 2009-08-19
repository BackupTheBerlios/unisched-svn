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
    /// Delivers static methods for logging.
    /// Has to be initialized by using Logger.Initialize(string configuration).
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Internal Log4net-Logger.
        /// </summary>
        protected static ILog InternalLogger;

        /// <summary>
        /// Internal attribute that saves the init state.
        /// </summary>
        protected static bool Initialized;

        /// <summary>
        /// Path to configuration file.
        /// </summary>
        protected static string ConfigurationFile = string.Empty;

        /// <summary>
        /// Returns if Logger is initialized.
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
        /// Initializes the Logger with a configuration file.
        /// </summary>
        /// <param name="configuration">configuration file path</param>
        /// <returns>Success</returns>
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
        /// Initializes the Logger without config file and uses value at Web.config or App.config
        /// </summary>
        /// <returns>Success</returns>
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
        /// Gets the Logger for the suitable assembly.
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
        /// Saves a debug message.s
        /// </summary>
        /// <param name="message">The debug message.</param>
        public static void Debug(object message)
        {
            GetLogger();
            InternalLogger.Debug(message);
        }

        /// <summary>
        /// Saves a debug message with exception.
        /// </summary>
        /// <param name="message">The debug message.</param>
        /// <param name="ex">The exception.</param>
        public static void Debug(object message, Exception ex)
        {
            GetLogger();
            InternalLogger.Debug(message, ex);
        }

        /// <summary>
        /// Saves a error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public static void Error(object message)
        {
            GetLogger();
            InternalLogger.Error(message);
        }

        /// <summary>
        /// Saves a error message with exception.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="ex">The exception.</param>
        public static void Error(object message, Exception ex)
        {
            GetLogger();
            InternalLogger.Error(message, ex);
        }

        /// <summary>
        /// Saves a fatal error.
        /// </summary>
        /// <param name="message">The fatal error.</param>
        public static void Fatal(object message)
        {
            GetLogger();
            InternalLogger.Fatal(message);
        }

        /// <summary>
        /// Saves a fatal error with exception.
        /// </summary>
        /// <param name="message">The fatal error.</param>
        /// <param name="ex">The exception.</param>
        public static void Fatal(object message, Exception ex)
        {
            GetLogger();
            InternalLogger.Fatal(message, ex);
        }

        /// <summary>
        /// Saves an information.
        /// </summary>
        /// <param name="message">The information.</param>
        public static void Info(object message)
        {
            GetLogger();
            InternalLogger.Info(message);
        }

        /// <summary>
        /// Saves an information with exception.
        /// </summary>
        /// <param name="message">The information.</param>
        /// <param name="ex">The exception.</param>
        public static void Info(object message, Exception ex)
        {
            GetLogger();
            InternalLogger.Info(message, ex);
        }

        /// <summary>
        /// Saves a warning.
        /// </summary>
        /// <param name="message">The warning.</param>
        public static void Warn(object message)
        {
            GetLogger();
            InternalLogger.Warn(message);
        }

        /// <summary>
        /// Saves a warning with exception.
        /// </summary>
        /// <param name="message">The warning.</param>
        /// <param name="ex">The exception.</param>
        public static void Warn(object message, Exception ex)
        {
            GetLogger();
            InternalLogger.Warn(message, ex);
        }
    }
}
