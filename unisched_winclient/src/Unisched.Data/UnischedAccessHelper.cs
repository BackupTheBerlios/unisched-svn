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
            return PrepareAccess(MySQLHelper.GetDataAccess("testtable", "SELECT * FROM testtable"));
        }

        public static DataAccess GetBookingTableAccess()
        {
            return PrepareAccess(MySQLHelper.GetDataAccess("booking", "SELECT * FROM booking"));
        }

        public static DataAccess GetCurriculumTableAccess()
        {
            DataAccess access = PrepareAccess(MySQLHelper.GetDataAccess("curriculum", "SELECT * FROM curriculum LEFT OUTER JOIN subject ON subject.SUB_ID=curriculum.SUB_ID"));
            access.DataViewSettings = new DataViewSettings();
            /*access.DataViewSettings.IsReadonly = false;
            access.DataViewSettings.ColNames = new Dictionary<string, string>();
            access.DataViewSettings.ColReadonly = new Dictionary<string, bool>();
            access.DataViewSettings.ColVisible = new Dictionary<string, bool>();
            access.DataViewSettings.ColNames.Add("CUR_ID", "Id");
            access.DataViewSettings.ColReadonly.Add("CUR_ID", true);
            access.DataViewSettings.ColVisible.Add("CUR_ID", false);
            access.DataViewSettings.ColNames.Add("CLASS_PERIOD_ID", "Period Id");
            access.DataViewSettings.ColReadonly.Add("CLASS_PERIOD_ID", false);
            access.DataViewSettings.ColVisible.Add("CLASS_PERIOD_ID", false);
            access.DataViewSettings.ColNames.Add("SUB_ID", "Period Id");
            access.DataViewSettings.ColReadonly.Add("SUB_ID", false);
            access.DataViewSettings.ColVisible.Add("SUB_ID", false);*/

            return access;
        }

        public static DataAccess GetUserTableAccess()
        {
            DataAccess access = PrepareAccess(MySQLHelper.GetDataAccess("user", "SELECT * FROM user"));
            if (access != null)
            {
                access.DataViewSettings = new DataViewSettings();
                access.DataViewSettings.IsReadonly = false;
                access.DataViewSettings.ColNames = new Dictionary<string, string>();
                access.DataViewSettings.ColReadonly = new Dictionary<string, bool>();
                access.DataViewSettings.ColVisible = new Dictionary<string, bool>();
                access.DataViewSettings.ColNames.Add("USER_ID", "Id");
                access.DataViewSettings.ColReadonly.Add("USER_ID", true);
                access.DataViewSettings.ColVisible.Add("USER_ID", false);
                access.DataViewSettings.ColNames.Add("USER_LOGIN", "Login");
                access.DataViewSettings.ColReadonly.Add("USER_LOGIN", false);
                access.DataViewSettings.ColVisible.Add("USER_LOGIN", true);
                access.DataViewSettings.ColNames.Add("USER_ADMIN", "Admin");
                access.DataViewSettings.ColReadonly.Add("USER_ADMIN", false);
                access.DataViewSettings.ColVisible.Add("USER_ADMIN", true);
                access.DataViewSettings.ColNames.Add("USER_PASSWORD", "Passwort");
                access.DataViewSettings.ColReadonly.Add("USER_PASSWORD", false);
                access.DataViewSettings.ColVisible.Add("USER_PASSWORD", false);
            }
            return access;
        }


        private static DataAccess PrepareAccess(DataAccess access)
        {
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
