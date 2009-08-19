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
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Unisched.Logging;

namespace Unisched.Core
{
    /// <summary>
    /// Represents static application properties.
    /// </summary>
    public class AppSettings
    {
        private static AppSettings AppSets;
        private readonly Dictionary<string, string> Settings = new Dictionary<string, string>();

        /// <summary>
        /// Path and name of the property file.
        /// </summary>
        public static readonly string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Unisched\configs\";

        private static AppSettings GetInstance()
        {
            if(AppSets == null)
            {
                AppSets = new AppSettings();
            }
            return AppSets;
        }

        /// <summary>
        /// Returns a named property or string.Empty if the property doesn't exist.
        /// </summary>
        /// <param name="key">Key of the property.</param>
        /// <returns>Property or string.Empty.</returns>
        public static string GetSetting(string key)
        {
            if(GetInstance().Settings.ContainsKey(key))
            {
                return GetInstance().Settings[key];
            }
            Logger.Warn(string.Format("Es wurde eine nicht vorhandene Eigenschaft abgerufen: {0}", key));
            return string.Empty;
        }

        /// <summary>
        /// Adds a property or changes it if the property already exists.
        /// </summary>
        /// <param name="key">Key of the property.</param>
        /// <param name="value">Value of the property.</param>
        public static void SetSetting(string key, string value)
        {
            if(GetInstance().Settings.ContainsKey(key))
            {
                GetInstance().Settings[key] = value;
            }
            else
            {
                GetInstance().Settings.Add(key, value);
            }
        }

        /// <summary>
        /// Loads the properties from a xml-file.
        /// </summary>
        /// <param name="filename">Path and name of the xml-file.</param>
        public static void LoadSettings(string filename)
        {
            if(!File.Exists(filename))
            {
                LoadDefaultSettings();
                return;
            }
            GetInstance().Settings.Clear();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                XmlElement root = doc.DocumentElement;
                if(root == null)
                {
                    return;
                }
                foreach (XmlElement childNode in root.ChildNodes)
                {
                    if (!string.IsNullOrEmpty(childNode.Name) && !string.IsNullOrEmpty(childNode.InnerText))
                    {
                        GetInstance().Settings.Add(childNode.Name, childNode.InnerText);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Fehler beim Lesen der Anwendungseinstellungsdatei.", ex);
                LoadDefaultSettings();
            }
        }

        /// <summary>
        /// Saves the properties to a xml-file.
        /// </summary>
        /// <param name="filename">Path and name of the xml-file.</param>
        public static void SaveSettings(string filename)
        {
            try
            {
                FileInfo fi = new FileInfo(filename);
                if (fi.Directory != null)
                {
                    if (!fi.Directory.Exists)
                    {
                        fi.Directory.Create();
                    }
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlTextWriter.WriteStartDocument(false);
                    xmlTextWriter.WriteStartElement("appSettings");
                    foreach (string key in GetInstance().Settings.Keys)
                    {
                        xmlTextWriter.WriteElementString(key, GetInstance().Settings[key]);
                    }
                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.Flush();
                    xmlTextWriter.Close();
                }
            }
            catch(Exception ex)
            {
                Logger.Error("Fehler beim Schreiben der Anwendungseinstellungsdatei.", ex);
            }
        }

        private static void LoadDefaultSettings()
        {
            GetInstance().Settings.Clear();
            GetInstance().Settings.Add("culture", "de-DE");
        }
    }
}
