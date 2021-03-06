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
using MySql.Data.MySqlClient;
using Unisched.Logging;
using System.Data;

namespace Unisched.Data
{
    /// <summary>
    /// Static class that can establish a MySQL connection and create data access objects.
    /// </summary>
    public static class MySQLHelper
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
                Logger.Error("Error while connecting to database.", ex);
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
        /// Executes a query and returns the result of the query (or an empty table).
        /// </summary>
        /// <param name="query">Sql-Query.</param>
        /// <returns>Datatable with the result.</returns>
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
                Logger.Error(string.Format("Error at query: {0}", query), ex);
                return new DataTable();
            }
        }
    }
}
