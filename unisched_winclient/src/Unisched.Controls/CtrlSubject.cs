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
using System.Windows.Forms;
using Unisched.Data;
using Unisched.Core.Interfaces;

namespace Unisched.Controls
{
    /// <summary>
    /// Control for accessing the subject master data.
    /// </summary>
    public partial class CtrlSubject : UserControl, IDataUserControl
    {

        private bool edit;
        private int id;
        
        /// <summary>
        /// Constructor, initializes the control.
        /// </summary>
        public CtrlSubject()
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

        private void CtrlSubject_Load(object sender, EventArgs e)
        {
            edit = false;
            id = 0;
            string subjectselect = "select * from unisched.subject";
            subjectDgv.DataSource = MySQLHelper.ExecuteQuery(subjectselect);
            subjectDgv.Columns[0].Visible = false;
            subjectDgv.Columns[1].Visible = false;
            subjectDgv.Columns[3].Visible = false;
            subjectDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CtrlSubject_Load()
        {
            edit = false;
            id = 0;
            string subjectselect = "select * from unisched.subject";
            subjectDgv.DataSource = MySQLHelper.ExecuteQuery(subjectselect);
            subjectDgv.Columns[0].Visible = false;
            subjectDgv.Columns[1].Visible = false;
            subjectDgv.Columns[3].Visible = false;
            subjectDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void subjectDgv_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(subjectDgv[0, e.RowIndex].Value);
                edit = true;
                subShortDescTb.Text = subjectDgv[2, e.RowIndex].Value.ToString();
                subDescTb.Text = subjectDgv[4, e.RowIndex].Value.ToString();
                delBtn.Enabled = true;
                if (Convert.ToInt32(subjectDgv[3, e.RowIndex].Value) == 1)
                    subTyp1.Checked = true;
                else
                    subTyp2.Checked = true;
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            CtrlSubject_Load();
            subShortDescTb.Enabled = true;
            subShortDescTb.Text = "";
            subDescTb.Text = "";
            subDescTb.Enabled = false;
            subTyp1.Checked = true;
            addBtn.Enabled = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string insertsubject;
            string modsub;
            string modsubnum;
            if (subTyp1.Checked)
            {
                modsub = "NULL";
                modsubnum = "1";
            }
            else
            {
                modsub = "'1'";
                modsubnum = "2";
            }
            if (!edit)
                insertsubject = "insert into unisched.subject  (`SUB_ID` ,`MOD_ID` ,`SUB_NAME` ,`SUB_TYP`,`SUB_LONG_NAME`) values (NULL," + modsub + ",'" + subShortDescTb.Text + "','" + modsubnum + "','" + subDescTb.Text + "');";
            else
                insertsubject = "update unisched.subject set SUB_NAME='" + subShortDescTb.Text + "' ,SUB_LONG_NAME='" + subDescTb.Text + "' ,SUB_TYP='" + modsubnum + "' where subject.SUB_ID =" + id + ";";
            MySQLHelper.ExecuteQuery(insertsubject);
            subDescTb.Enabled = false;
            addBtn.Enabled = false;
            edit = false;
            subShortDescTb.Enabled = true;
            CtrlSubject_Load();
            delBtn.Enabled = false;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            string delsubject = "delete from unisched.subject where SUB_ID =" + id + ";";
            MySQLHelper.ExecuteQuery(delsubject);
            CtrlSubject_Load();
            subShortDescTb.Enabled = true;
            edit = false;
            addBtn.Enabled = true;
        }

    }
}
