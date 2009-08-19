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
using Unisched.Core.Common;
using Unisched.Core.Interfaces;
using Unisched.Data;

namespace Unisched.Controls
{
    /// <summary>
    /// Control for accessing the class period master data.
    /// </summary>
    public partial class CtrlClassPeriod : UserControl, IDataUserControl
    {
        private bool AdminMode;
        private bool LoadingContent;
        private int SelectedId = -1;
        private int ClassId = -1;

        /// <summary>
        /// Contructor, initializes the control.
        /// </summary>
        public CtrlClassPeriod()
        {
            InitializeComponent();
            InitComboBox();
            pnlRight.Enabled = false;
        }

        private void InitComboBox()
        {
            cbMatrikel.Items.Clear();
            DataTable dt = MySQLHelper.ExecuteQuery("SELECT CLASS_ID, CLASS_NAME FROM class;");
            foreach (DataRow dr in dt.Rows)
            {
                int classId = Int32.Parse(dr["CLASS_ID"].ToString());
                string className = dr["CLASS_NAME"].ToString();
                cbMatrikel.Items.Add(new TaggedItem(className, classId));
            }
        }

        public void Initialize(bool admin)
        {
            AdminMode = admin;
        }

        public Control GetControl()
        {
            return this;
        }

        private void cbMatrikel_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaggedItem ti = cbMatrikel.SelectedItem as TaggedItem;
            if (ti != null)
            {
                ClassId = Int32.Parse(ti.Tag.ToString());
                LoadPeriods();
                pnlRight.Enabled = AdminMode;
            }
            else
            {
                ClassId = -1;
                pnlRight.Enabled = false;
            }
        }


        private void LoadPeriods()
        {
            SelectedId = -1;
            if (ClassId != -1)
            {
                LoadingContent = true;
                dgvPeriods.DataSource = MySQLHelper.ExecuteQuery(string.Format("SELECT * FROM class_period WHERE CLASS_ID={0}", ClassId));
                dgvPeriods.Columns[0].Visible = false;
                dgvPeriods.Columns[1].Visible = false;
                dgvPeriods.Columns[2].HeaderText = Properties.Resources.Semester;
                dgvPeriods.Columns[3].HeaderText = Properties.Resources.Beginn;
                dgvPeriods.Columns[4].HeaderText = Properties.Resources.Ende;
                dgvPeriods.Columns[5].Visible = false;
                dgvPeriods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                LoadingContent = false;
                ProcessSelection();
            }
        }

        private void dgvPeriods_SelectionChanged(object sender, EventArgs e)
        {
            ProcessSelection();
        }

        private void ProcessSelection()
        {
            if(!LoadingContent)
            {
                if(dgvPeriods.SelectedRows.Count > 0)
                {
                    int index = dgvPeriods.SelectedRows[0].Index;
                    SelectedId = Int32.Parse(dgvPeriods[0, index].Value.ToString());
                    int period = Int32.Parse(dgvPeriods[2, index].Value.ToString());
                    DateTime begin = DateTime.Parse(dgvPeriods[3, index].Value.ToString());
                    DateTime end = DateTime.Parse(dgvPeriods[4, index].Value.ToString());
                    bool praxis = dgvPeriods[5, index].Value.ToString().Equals("1");
                    if(period <= cbSemester.Items.Count)
                    {
                        cbSemester.SelectedIndex = period - 1;
                    }
                    else
                    {
                        cbSemester.SelectedIndex = -1;
                    }
                    dtpStart.Value = begin;
                    dtpEnd.Value = end;
                    if(praxis)
                    {
                        rbPraxis.Checked = true;
                    }
                    else
                    {
                        rbTheorie.Checked = true;
                    }
                    cbSemester.Enabled = false;
                    btnDel.Enabled = true;
                }
                else
                {
                    SelectedId = -1;
                    cbSemester.SelectedIndex = -1;
                    dtpStart.Value = DateTime.Now;
                    dtpEnd.Value = DateTime.Now;
                    rbTheorie.Checked = true;
                    cbSemester.Enabled = true;
                    btnDel.Enabled = false;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SelectedId = -1;
            cbSemester.SelectedIndex = -1;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            rbTheorie.Checked = true;
            cbSemester.Enabled = true;
            btnDel.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int termId = cbSemester.SelectedIndex + 1;
            int typ = rbTheorie.Checked ? 0 : 1;
            string begin = dtpStart.Value.ToString("yyyy-MM-dd");
            string end = dtpEnd.Value.ToString("yyyy-MM-dd");
            if (SelectedId == -1 && termId > 0)
            {
                // new entry
                string query = string.Format("INSERT INTO class_period (CLASS_ID, TERM_ID, CLASS_PERIOD_TYP, CLASS_PERIOD_BEGIN, CLASS_PERIOD_END) VALUES ({0}, {1}, {2}, '{3}', '{4}')", ClassId, termId, typ, begin, end);
                MySQLHelper.ExecuteQuery(query);
            }
            else
            {
                // changed entry
                string query = string.Format("UPDATE class_period SET CLASS_PERIOD_TYP={0}, CLASS_PERIOD_BEGIN='{1}', CLASS_PERIOD_END='{2}' WHERE CLASS_ID={3} AND TERM_ID={4}", typ, begin, end, ClassId, termId);
                MySQLHelper.ExecuteQuery(query);
            }
            LoadPeriods();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int termId = cbSemester.SelectedIndex + 1;
            int typ = rbTheorie.Checked ? 0 : 1;
            string query = string.Format("DELETE FROM class_period WHERE CLASS_ID={0} AND TERM_ID={1} AND CLASS_PERIOD_TYP={2}", ClassId, termId, typ);
            MySQLHelper.ExecuteQuery(query);
            LoadPeriods();
        }
    }
}
