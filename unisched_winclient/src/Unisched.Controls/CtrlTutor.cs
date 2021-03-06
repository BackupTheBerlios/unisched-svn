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
    /// Control for accessing the lecturer master data.
    /// </summary>
    public partial class CtrlTutor : UserControl, IDataUserControl
    {

        private bool edit;
        private int id;
        
        /// <summary>
        /// Constructor, initializes the control.
        /// </summary>
        public CtrlTutor()
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

        private void CtrlTutor_Load(object sender, EventArgs e)
        {
            string tutorselect = "select * from unisched.lecturer";
            tutorDgv.DataSource = MySQLHelper.ExecuteQuery(tutorselect);
            tutorDgv.Columns[0].Visible = false;
            tutorDgv.Columns[3].Visible = false;
            tutorDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CtrlTutor_Load()
        {
            edit = false;
            id = 0;
            string tutorselect = "select * from unisched.lecturer";
            tutorDgv.DataSource = MySQLHelper.ExecuteQuery(tutorselect);
            tutorDgv.Columns[0].Visible = false;
            tutorDgv.Columns[3].Visible = false;
            tutorDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void tutorDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(tutorDgv[0, e.RowIndex].Value);
                edit = true;
                tutorFnTb.Text = tutorDgv[2, e.RowIndex].Value.ToString();
                tutorLnTb.Text = tutorDgv[1, e.RowIndex].Value.ToString();
                telNrTb.Text = tutorDgv[4, e.RowIndex].Value.ToString();
                delBtn.Enabled = true;
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            CtrlTutor_Load();
            tutorFnTb.Enabled = true;
            tutorFnTb.Text = "";
            tutorLnTb.Text = "";
            telNrTb.Text = "";
            tutorLnTb.Enabled = false;
            telNrTb.Enabled = false;
            addBtn.Enabled = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string inserttutor;
            if (!edit)
                inserttutor = "insert into unisched.lecturer  (`LEC_ID` ,`LEC_LNAME` ,`LEC_GNAME` ,`LEC_TEL`) values (NULL,'" + tutorLnTb.Text + "','" + tutorFnTb.Text + "','" + telNrTb.Text + "');";
            else
                inserttutor = "update unisched.lecturer set LEC_GNAME='" + tutorFnTb.Text + "' ,LEC_LNAME='" + tutorLnTb.Text + "' ,LEC_TEL='" + telNrTb.Text + "' where lecturer.LEC_ID =" + id + ";";
            MySQLHelper.ExecuteQuery(inserttutor);
            tutorLnTb.Enabled = false;
            telNrTb.Enabled = false;
            addBtn.Enabled = false;
            edit = false;
            tutorFnTb.Enabled = true;
            CtrlTutor_Load();
            delBtn.Enabled = false;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            string deltutor = "delete from unisched.lecturer where LEC_ID =" + id + ";";
            MySQLHelper.ExecuteQuery(deltutor);
            CtrlTutor_Load();
            tutorFnTb.Enabled = true;
            edit = false;
        }
    }
}
