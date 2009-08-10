using System;
using MySql.Data.MySqlClient;
using Unisched.Logging;
using System.Data;

namespace Unisched.Data
{
    /// <summary>
    /// Interne Klasse, die eine MySQL-Verbindung aufbaut und Datenzugriffselemente erstellt
    /// </summary>
    public class MySQLHelper
    {
        private static MySqlConnection Connection;

        private static void Init()
        {
            try
            {
                Connection = new MySqlConnection(Properties.Resources.Db4FreeConnectionString);
            }
            catch (Exception ex)
            {
                Logger.Error("Fehler beim Aufbau der Datenbankverbindung", ex);
            }
        }

        private static MySqlConnection GetConnection()
        {
            if (Connection == null)
            {
                Init();
            }
            return Connection;
        }

        /// <summary>
        /// Erstellt ein Datenzugriffselement, nur für projektinterne Verwendung gedacht
        /// </summary>
        /// <param name="sourceTable">Zu verwendende Tabelle</param>
        /// <param name="selectCommand">Select-Command zum Zugriff auf die Tabelle</param>
        /// <param name="gridViewSettings">Einstellungen eines DataGridViews, das aus den Daten erstellt werden kann</param>
        /// <returns>Datenzugriffselement oder bei Fehler null</returns>
        internal static DataAccess GetDataAccess(string sourceTable, string selectCommand, DataGridViewSettings gridViewSettings)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(selectCommand, GetConnection());
                new MySqlCommandBuilder(da);
                DataAccess dsap = new DataAccess(ds, da, sourceTable, gridViewSettings);
                return dsap;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Fehler beim Erstellen eines Datasets. SelectCommand: '{0}', Tabelle: '{1}", selectCommand, sourceTable), ex);
            }
            return null;
        }

        /// <summary>
        /// Führt eine Abfrage aus und liefert das Ergebnis der Abfrage zurück (ggf. leere Datatable)
        /// </summary>
        /// <param name="query">Abfrage</param>
        /// <returns>Datatable mit dem resultierenden Ergebnis</returns>
        public static DataTable ExecuteQuery(string query)
        {
            try
            {
                MySqlCommand readCommand = new MySqlCommand(query, GetConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter(readCommand);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                return datatable;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Fehler bei einer Abfrage: {0}", query), ex);
                return new DataTable();
            }
        }
    }
}
