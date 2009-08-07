using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Unisched.Logging;
using System.Data;
using System.Data.SqlClient;

namespace Unisched.Data
{
    /// <summary>
    /// Interne Klasse, die eine MySQL-Verbindung aufbaut und Datenzugriffselemente erstellt
    /// </summary>
    internal class MySQLHelper
    {
        private static MySqlConnection connection = null;

        private static void Init()
        {
            try
            {
                string myConnectionString = "SERVER=www.db4free.net;" +
                            "DATABASE=unisched;" +
                            "UID=unisched;" +
                            "PASSWORD=unisched;";

                connection = new MySqlConnection(myConnectionString);
            }
            catch (Exception ex)
            {
                Logger.Error("Fehler beim Aufbau der Datenbankverbindung", ex);
            }
        }

        private static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                Init();
            }
            return connection;
        }

        /// <summary>
        /// Erstellt ein Datenzugriffselement
        /// </summary>
        /// <param name="sourceTable">Zu verwendende Tabelle</param>
        /// <param name="selectCommand">Select-Command zum Zugriff auf die Tabelle</param>
        /// <param name="gridViewSettings">Einstellungen eines DataGridViews, das aus den Daten erstellt werden kann</param>
        /// <returns>Datenzugriffselement oder bei Fehler null</returns>
        public static DataAccess GetDataAccess(string sourceTable, string selectCommand, DataGridViewSettings gridViewSettings)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(selectCommand, GetConnection());
                MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(da);
                DataAccess dsap = new DataAccess(ds, da, sourceTable, gridViewSettings);
                return dsap;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Fehler beim Erstellen eines Datasets. SelectCommand: '{0}', Tabelle: '{1}", selectCommand, sourceTable), ex);
            }
            return null;
        }

    }
}
