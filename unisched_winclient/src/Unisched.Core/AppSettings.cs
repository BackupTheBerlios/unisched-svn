using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Unisched.Logging;

namespace Unisched.Core
{
    /// <summary>
    /// Repräsentiert statische Anwendungseinstellungen
    /// </summary>
    public class AppSettings
    {
        private static AppSettings AppSets;
        private readonly Dictionary<string, string> Settings = new Dictionary<string, string>();
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
        /// Gibt eine Einstellung zurück oder string.Empty, wenn die Einstellung nicht existiert
        /// </summary>
        /// <param name="key">Schlüssel der Einstellung</param>
        /// <returns>Wert der Einstellung oder string.Empty</returns>
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
        /// Fügt eine Einstellung hinzu oder aktualisiert sie, wenn sie bereits vorhanden ist
        /// </summary>
        /// <param name="key">Schlüssel der Einstellung</param>
        /// <param name="value">Wert der Einstellung</param>
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
        /// Lädt die Einstellungen aus einer xml-Datei
        /// </summary>
        /// <param name="filename">Pfad zur xml-Datei</param>
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
        /// Speichert die Einstellungen in eine xml-Datei
        /// </summary>
        /// <param name="filename">Pfad zur xml-Datei</param>
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
            GetInstance().Settings.Add("culture", "en-GB");
        }
    }
}
