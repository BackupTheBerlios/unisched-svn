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
    public partial class CtrlstandardRoom : UserControl, IDataUserControl
    {
        public CtrlstandardRoom()
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
            cbSemGrp.Items.Clear();
            DataTable dt = MySQLHelper.ExecuteQuery("SELECT CLASS_ID, CLASS_NAME FROM unisched.class");
            foreach (DataRow dr in dt.Rows)
            {
                int id = Int32.Parse(dr["CLASS_ID"].ToString());
                string name = dr["CLASS_NAME"].ToString();
                cbSemGrp.Items.Add(new TaggedItem(name, id));
            }
        }

        private void cbSemGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SuspendLayout();
            cbRoom.Items.Clear();
            TaggedItem item = (TaggedItem)cbSemGrp.SelectedItem;
            if (item == null)
            {
                cbRoom.Enabled = false;
            }
            else
            {
                int classId = Int32.Parse(item.Tag.ToString());
                DataTable dt = MySQLHelper.ExecuteQuery(string.Format("SELECT ROOM_ID, ROOM_NAME FROM room WHERE CLASS_ID={0} AND ROOM_ID=0", classId));
                foreach (DataRow dr in dt.Rows)
                {
                    int periodId = Int32.Parse(dr["ROOM_ID"].ToString());
                    int semester = Int32.Parse(dr["ROOM_NAME"].ToString());
                    cbRoom.Items.Add(new TaggedItem(semester.ToString(), periodId));
                }
                cbRoom.Enabled = true;
            }
            ResumeLayout();
            Cursor = Cursors.Default;
        }


        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }

        private void delBtn_Click(object sender, EventArgs e)
        {

        }

        private void CtrlstandardRoom_Load(object sender, EventArgs e)
        {
            string defaultroom = "select D.priority,C.CLASS_NAME,R.ROOM_NAME from unisched.defaultrooms D, unisched.class C, unisched.room R where R.ROOM_ID = D.ROOM_ID and D.CLASS_ID = C.CLASS_ID";
            dgvDefRoom.DataSource = MySQLHelper.ExecuteQuery(defaultroom);
            dgvDefRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
