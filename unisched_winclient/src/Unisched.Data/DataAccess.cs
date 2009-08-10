using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Unisched.Logging;

namespace Unisched.Data
{
    public class DataAccess
    {
        private readonly DataSet dataSet;
        private readonly MySqlDataAdapter dataAdapter;
        private readonly string srcTable;
        private DataViewSettings dataViewSettings;

        public DataViewSettings DataViewSettings
        {
            get { return dataViewSettings; }
            set { dataViewSettings = value; }
        }

        public DataSet DataSet
        {
            get { return dataSet; }
        }

        public string SrcTable
        {
            get { return srcTable; }
        }

        public DataAccess(DataSet dataSet, MySqlDataAdapter dataAdapter, string srcTable)
        {
            this.dataSet = dataSet;
            this.dataAdapter = dataAdapter;
            this.srcTable = srcTable;
            dataViewSettings = new DataViewSettings();
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
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (DataViewSettings.ColNames.ContainsKey(col.DataPropertyName))
                    {
                        col.HeaderText = DataViewSettings.ColNames[col.DataPropertyName];
                    }
                    if (DataViewSettings.ColReadonly.ContainsKey(col.DataPropertyName))
                    {
                        col.ReadOnly = DataViewSettings.ColReadonly[col.DataPropertyName];
                    }
                    if (DataViewSettings.ColVisible.ContainsKey(col.DataPropertyName))
                    {
                        col.Visible = DataViewSettings.ColVisible[col.DataPropertyName];
                    }
                }
            }
            else
            {
                Logger.Warn(string.Format("Kein Gridview übergeben. Tabelle: {0}", srcTable));
            }
        }

        public void InitListView(ListView lv)
        {
            if (lv != null)
            {
                DataTable dt = DataSet.Tables[0];
                if (dt != null)
                {
                    CurrencyManager cm = (CurrencyManager)lv.BindingContext[DataSet, DataSet.Tables[0].TableName];

                    //add an event handler for the Currency Manager       
                    //cm.CurrentChanged += new EventHandler(cm_CurrentChanged);

                    DataView dv = (DataView)cm.List;

                    //Create the column header based on the DataMember

                    foreach (DataColumn dc in dt.Columns)
                    {
                        lv.Columns.Add(dc.ColumnName);
                    }
                    //Add each Row as a ListViewItem        

                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem lvi = new ListViewItem();
                        foreach (DataColumn dc in dt.Columns)
                        {
                            lvi.SubItems.Add(dr[dc.ColumnName].ToString());
                        }
                        /*ListViewItem lvi = new ListViewItem(dr["SUB_ID"].ToString());
                        lvi.Tag = dr;
                        lvi.SubItems.Add(dr["CUR_CNT_SUB"].ToString());*/
                        lv.Items.Add(lvi);
                    }
                    lv.Sorting = SortOrder.Ascending;
                }
            }
        }
    }
}
