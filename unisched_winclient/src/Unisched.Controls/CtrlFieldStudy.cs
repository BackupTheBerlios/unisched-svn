using System;
using System.Windows.Forms;
using Unisched.Data;
using Unisched.Core.Interfaces;

namespace Unisched.Controls
{
    public partial class CtrlFieldStudy : UserControl, IDataUserControl
    {
        private bool edit;
        private int id;

        public CtrlFieldStudy()
        {
            InitializeComponent();
        }

        #region interface implements
        public void Initialize(bool admin)
        {
            // nothing to do
        }

        public Control GetControl()
        {
            return this;
        }
        #endregion

        private void CtrlFieldStudy_Load(object sender, EventArgs e)
        {
            edit = false;
            id = 0;
            string fieldStudyselect = "select * from unisched.field";
            fieldStudyDgv.DataSource = MySQLHelper.ExecuteQuery(fieldStudyselect);
            fieldStudyDgv.Columns[0].Visible = false;
            fieldStudyDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CtrlFieldStudy_Load()
        {
            edit = false;
            id = 0;
            string fieldStudyselect = "select * from unisched.field";
            fieldStudyDgv.DataSource = MySQLHelper.ExecuteQuery(fieldStudyselect);
            fieldStudyDgv.Columns[0].Visible = false;
            fieldStudyDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void fieldStudyDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(fieldStudyDgv[0, e.RowIndex].Value);
                edit = true;
                fieldStudyTb.Text = fieldStudyDgv[1, e.RowIndex].Value.ToString();
                delBtn.Enabled = true;
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            addBtn.Enabled = false;
            delBtn.Enabled = false;
            edit = false;
            id = 0;
            fieldStudyTb.Text = "";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string insertfieldstudy;
            if (!edit)
                insertfieldstudy = "insert into unisched.field  (`FIELD_ID` ,`FIELD_NAME`) values (NULL,'" + fieldStudyTb.Text + "');";
            else
                insertfieldstudy = "update unisched.field set FIELD_NAME='" + fieldStudyTb.Text + "' where field.FIELD_ID =" + id + ";";
            MySQLHelper.ExecuteQuery(insertfieldstudy);
            addBtn.Enabled = false;
            edit = false;
            CtrlFieldStudy_Load();
            delBtn.Enabled = false;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            string delfieldstudy = "delete from unisched.field where FIELD_ID =" + id + ";";
            MySQLHelper.ExecuteQuery(delfieldstudy);
            CtrlFieldStudy_Load();
            edit = false;
            addBtn.Enabled = true;
        }

        private void fieldStudyTb_TextChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
        }

    }
}
