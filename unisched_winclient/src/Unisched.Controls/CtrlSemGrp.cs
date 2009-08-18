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
using System.Data;
using System.Windows.Forms;
using Unisched.Data;
using Unisched.Core.Interfaces;
using Unisched.Core.Common;

namespace Unisched.Controls
{
    public partial class CtrlSemGrp : UserControl, IDataUserControl
    {
        private bool edit;
        private int classid;
        private int fieldid;

        public CtrlSemGrp()
        {
            InitializeComponent();
            InitCb();
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

        private void InitCb()
        {
            cbFieldName.Items.Clear();
            DataTable dt = MySQLHelper.ExecuteQuery("SELECT FIELD_ID, FIELD_NAME FROM unisched.field");
            foreach (DataRow dr in dt.Rows)
            {
                int id = Int32.Parse(dr["FIELD_ID"].ToString());
                string name = dr["FIELD_NAME"].ToString();
                cbFieldName.Items.Add(new TaggedItem(name, id));
            }
        }

        private void CtrlSemGrp_Load(object sender, EventArgs e)
        {
            string semgrpselect = "select C.CLASS_ID,C.CLASS_NAME,C.CLASS_COUNT,F.FIELD_NAME,F.FIELD_ID,C.CLASS_TYP from unisched.class C, unisched.field F where C.FIELD_ID = F.FIELD_ID";
            semGrpDgv.DataSource = MySQLHelper.ExecuteQuery(semgrpselect);
            semGrpDgv.Columns[0].Visible = false;
            semGrpDgv.Columns[4].Visible = false;
            semGrpDgv.Columns[5].Visible = false;
            semGrpDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CtrlSemGrp_Load()
        {
            string semgrpselect = "select C.CLASS_ID,C.CLASS_NAME,C.CLASS_COUNT,F.FIELD_NAME,F.FIELD_ID,C.CLASS_TYP from unisched.class C, unisched.field F where C.FIELD_ID = F.FIELD_ID";
            semGrpDgv.DataSource = MySQLHelper.ExecuteQuery(semgrpselect);
            semGrpDgv.Columns[0].Visible = false;
            semGrpDgv.Columns[4].Visible = false;
            semGrpDgv.Columns[5].Visible = false;
            semGrpDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            classid = 0;
            edit = false;
        }

        private void semGrpDgv_CellClick(object sender, DataGridViewCellEventArgs e)
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
                for (int i = 0; i < cbFieldName.Items.Count; i++)
                {
                    TaggedItem helpTi = (TaggedItem)cbFieldName.Items[i];
                    if(helpTi.Tag.ToString().Equals(fieldid.ToString()))
                        cbFieldName.SelectedIndex=i;
                }
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

        private void cbFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaggedItem helpTi = (TaggedItem)cbFieldName.SelectedItem;
            fieldid = Convert.ToInt32(helpTi.Tag.ToString());
            addBtn.Enabled = true;
        }
    }
}
