using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Unisched.Data;
using Unisched.Core.Interfaces;

namespace Unisched.Controls
{
    public partial class CtrlSemGrp : UserControl, IDataUserControl
    {
        private bool edit = false;
        private int classid = 0;
        private int fieldid = 0;

        public CtrlSemGrp()
        {
            InitializeComponent();
        }

        #region interface implements
        public void Initialize(bool admin)
        {
            // nothing to do
        }

        public void Edit()
        {
            // nothing to do
        }

        public void Abort()
        {
            // nothing to do
        }

        public void Save()
        {
            // nothing to do
        }

        public bool IsEditable()
        {
            return false;
        }

        public Control GetControl()
        {
            return this;
        }
        #endregion

        private void CtrlSemGrp_Load(object sender, EventArgs e)
        {
            string semgrpselect = "select C.CLASS_ID,C.CLASS_NAME,C.CLASS_COUNT,F.FIELD_NAME,F.FIELD_ID,C.CLASS_TYP from unisched.class C, unisched.field F where C.FIELD_ID = F.FIELD_ID";
            semGrpDgv.DataSource = MySQLHelper.ExecuteQuery(semgrpselect);
            semGrpDgv.DataSource = MySQLHelper.ExecuteQuery(semgrpselect);
            semGrpDgv.Columns[0].Visible = false;
            semGrpDgv.Columns[4].Visible = false;
            semGrpDgv.Columns[5].Visible = false;
            semGrpDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string fieldStudyselect = "select * from unisched.field";
            fieldStudyDgv.DataSource = MySQLHelper.ExecuteQuery(fieldStudyselect);
            fieldStudyDgv.Columns[0].Visible = false;
            fieldStudyDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CtrlSemGrp_Load()
        {
            string semgrpselect = "select C.CLASS_ID,C.CLASS_NAME,C.CLASS_COUNT,F.FIELD_NAME,F.FIELD_ID,C.CLASS_TYP from unisched.class C, unisched.field F where C.FIELD_ID = F.FIELD_ID";
            semGrpDgv.DataSource = MySQLHelper.ExecuteQuery(semgrpselect);
            semGrpDgv.Columns[0].Visible = false;
            semGrpDgv.Columns[4].Visible = false;
            semGrpDgv.Columns[5].Visible = false;
            semGrpDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string fieldStudyselect = "select * from unisched.field";
            fieldStudyDgv.DataSource = MySQLHelper.ExecuteQuery(fieldStudyselect);
            fieldStudyDgv.Columns[0].Visible = false;
            fieldStudyDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            classid = 0;
            fieldid = 0;
            edit = false;
        }

        private void fieldStudyDgv_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            fieldid = Convert.ToInt32(semGrpDgv[0, e.RowIndex].Value);
        }

        private void semGrpDgv_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                fieldid = Convert.ToInt32(semGrpDgv[4, e.RowIndex].Value);
                semGrpTb.Text = semGrpDgv[1, e.RowIndex].Value.ToString();
                semGrpCount.Text = semGrpDgv[2, e.RowIndex].Value.ToString();
                classid = Convert.ToInt32(semGrpDgv[0, e.RowIndex].Value);
                semGrpCount.Enabled = true;
                addBtn.Enabled = true;
                delBtn.Enabled = true;
                if (Convert.ToInt32(semGrpDgv[5, e.RowIndex].Value) == 0)
                    classTyp1.Checked = true;
                else
                    classTyp2.Checked = true;
                edit = true;
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            addBtn.Enabled = false;
            delBtn.Enabled = false;
            edit = false;
            fieldid = 0;
            classid = 0;
            semGrpTb.Text = "";
            semGrpCount.Text = "";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (fieldid == 0)
                fieldid = 1;
            string insertsemgrp;
            if (!edit)
                insertsemgrp = "insert into unisched.class  (`CLASS_ID` ,`FIELD_ID`,`CLASS_NAME`,`CLASS_COUNT`,`CLASS_TYP`) values (NULL,'" + fieldid + "','"+ semGrpTb.Text +"','"+semGrpCount.Text+"','"+Convert.ToInt32(classTyp2.Checked)+"');";
            else
                insertsemgrp = "update unisched.class set FIELD_ID='" + fieldid + "',CLASS_NAME='" + semGrpTb.Text + "',CLASS_COUNT='" + semGrpCount.Text + "',CLASS_TYP='" + Convert.ToInt32(classTyp2.Checked) + "' where class.CLASS_ID =" + classid + ";";
            MySQLHelper.ExecuteQuery(insertsemgrp);
            addBtn.Enabled = false;
            edit = false;
            CtrlSemGrp_Load();
            delBtn.Enabled = false;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            string delfieldstudy = "delete from unisched.class where CLASS_ID =" + classid + ";";
            MySQLHelper.ExecuteQuery(delfieldstudy);
            CtrlSemGrp_Load();
            edit = false;
            addBtn.Enabled = true;
        }

        private void semGrpTb_TextChanged(object sender, EventArgs e)
        {
            semGrpCount.Enabled = true;
        }

        private void semGrpCount_TextChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
        }

        private void classTyp1_CheckedChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
        }

        private void classTyp2_CheckedChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
        }
    }
}
