using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Unisched.Logging;

namespace Unisched.Data
{
    public class DataAccess
    {
        private DataSet dataSet;
        private MySqlDataAdapter dataAdapter;
        private string srcTable;
        private DataGridViewSettings gridViewSettings;

        public DataSet DataSet
        {
            get { return dataSet; }
        }

        public string SrcTable
        {
            get { return srcTable; }
        }

        public DataAccess(DataSet dataSet, MySqlDataAdapter dataAdapter, string srcTable, DataGridViewSettings gridViewSettings)
        {
            this.dataSet = dataSet;
            this.dataAdapter = dataAdapter;
            this.srcTable = srcTable;
            this.gridViewSettings = gridViewSettings;
        }

        public void Fill()
        {
            try
            {
                dataAdapter.Fill(dataSet, srcTable);
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Fehler bei Fill. Tabelle: {0}", srcTable), ex);
            }
        }

        public void Update()
        {
            try
            {
                dataAdapter.Update(dataSet, srcTable);
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Fehler bei Update. Tabelle: {0}", srcTable), ex);
            }
        }

        public void Cancel()
        {
            try
            {
                DataSet.RejectChanges();
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Fehler bei Reject. Tabelle: {0}", srcTable), ex);
            }
        }

        public void InitDataGridView(DataGridView dgv)
        {
            if (dgv != null)
            {
                dgv.DataSource = DataSet;
                dgv.DataMember = SrcTable;
                /*foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (invisibleColumns.Contains(col.DataPropertyName))
                    {
                        col.Visible = false;
                    }
                }*/
            }
            else
            {
                Logger.Warn(string.Format("Kein Gridview übergeben. Tabelle: {0}", srcTable));
            }
        }
    }
}
