using System;
using System.Collections.Generic;
using System.Text;

namespace Unisched.Data
{
    /// <summary>
    /// Hilfsklasse, die Zugriffsobjekte erzeugt, die speziell auf das Projekt Unisched zugeschnitten sind
    /// </summary>
    public class UnischedAccessHelper
    {
        public static DataAccess GetTestTableAccess()
        {
            DataAccess access = MySQLHelper.GetDataAccess("testtable", "SELECT * FROM testtable", null);
            if (access != null)
            {
                access.Fill();
                return access;
            }
            else
            {
                return null;
            }
        }
    }
}
