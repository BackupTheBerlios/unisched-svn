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
    /// <summary>
    /// Control for accessing the default room master data.
    /// </summary>
    public partial class CtrlstandardRoom : UserControl, IDataUserControl
    {
        private bool LoadingContent;
        private int ClassId = -1;
        private int RoomId = -1;
        private bool AdminMode;

        /// <summary>
        /// Constructor, initializes the control.
        /// </summary>
        public CtrlstandardRoom()
        {
            InitializeComponent();
            InitComboBoxes();
            pnlRight.Enabled = false;
        }

        #region interface implements
        public void Initialize(bool admin)
        {
            AdminMode = admin;
        }

        public Control GetControl()
        {
            return this;
        }
        #endregion

        private void InitComboBoxes()
        {
            cbMatrikel.Items.Clear();
            DataTable dt = MySQLHelper.ExecuteQuery("SELECT CLASS_ID, CLASS_NAME FROM class;");
            foreach (DataRow dr in dt.Rows)
            {
                int classId = Int32.Parse(dr["CLASS_ID"].ToString());
                string className = dr["CLASS_NAME"].ToString();
                cbMatrikel.Items.Add(new TaggedItem(className, classId));
            }
            cbRoom.Items.Clear();
            dt = MySQLHelper.ExecuteQuery("SELECT ROOM_ID, ROOM_NR, ROOM_NAME FROM room;");
            foreach (DataRow dr in dt.Rows)
            {
                int roomId = Int32.Parse(dr["ROOM_ID"].ToString());
                string roomName = string.Format("{0} ({1})", dr["ROOM_NR"], dr["ROOM_NAME"]);
                cbRoom.Items.Add(new TaggedItem(roomName, roomId));
            }
            cbPriority.Items.Clear();
            for (int i = 1; i < 6; i++)
            {
                cbPriority.Items.Add(i);
            }
        }

        private void cbMatrikel_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaggedItem ti = cbMatrikel.SelectedItem as TaggedItem;
            if (ti != null)
            {
                ClassId = Int32.Parse(ti.Tag.ToString());
                LoadStdRooms();
                pnlRight.Enabled = AdminMode;
            }
            else
            {
                ClassId = -1;
                pnlRight.Enabled = false;
            }
        }

        private void LoadStdRooms()
        {
            if (ClassId != -1)
            {
                LoadingContent = true;
                string query = string.Format("SELECT defaultrooms.ROOM_ID, defaultrooms.priority, room.ROOM_NR, room.ROOM_NAME FROM defaultrooms LEFT OUTER JOIN room ON room.ROOM_ID=defaultrooms.ROOM_ID WHERE CLASS_ID={0}", ClassId);
                dgvStdRooms.DataSource = MySQLHelper.ExecuteQuery(query);
                dgvStdRooms.Columns[0].Visible = false;
                dgvStdRooms.Columns[1].HeaderText = Properties.Resources.Prioritaet;
                dgvStdRooms.Columns[2].HeaderText = Properties.Resources.Raumnummer;
                dgvStdRooms.Columns[3].HeaderText = Properties.Resources.Raumname;
                dgvStdRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                LoadingContent = false;
                ProcessSelection();
                cbRoom.Enabled = false;
            }
        }

        private void ProcessSelection()
        {
            if (!LoadingContent)
            {
                if (dgvStdRooms.SelectedRows.Count > 0)
                {
                    int index = dgvStdRooms.SelectedRows[0].Index;
                    RoomId = Int32.Parse(dgvStdRooms[0, index].Value.ToString());
                    int priority = Int32.Parse(dgvStdRooms[1, index].Value.ToString());
                    cbRoom.SelectedIndex = GetRoomSelectionIndex(RoomId);
                    if (priority <= cbPriority.Items.Count)
                    {
                        cbPriority.SelectedIndex = priority - 1;
                    }
                    else
                    {
                        cbPriority.SelectedIndex = -1;
                    }
                    btnDel.Enabled = true;
                }
                else
                {
                    cbRoom.SelectedIndex = -1;
                    cbPriority.SelectedIndex = -1;
                    RoomId = -1;
                    btnDel.Enabled = false;
                }
            }
        }

        private void dgvStdRooms_SelectionChanged(object sender, EventArgs e)
        {
            ProcessSelection();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbRoom.SelectedIndex = -1;
            cbPriority.SelectedIndex = -1;
            cbRoom.Enabled = true;
            RoomId = -1;
            btnDel.Enabled = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            TaggedItem ti = (TaggedItem)cbRoom.SelectedItem;
            string roomIdString;
            if (ti != null)
            {
                int roomId = Int32.Parse(ti.Tag.ToString());
                roomIdString = string.Format("={0}", roomId);
            }
            else
            {
                roomIdString = " IS NULL";
            }
            string query = string.Format("DELETE FROM defaultrooms WHERE CLASS_ID={0} AND ROOM_ID{1}", ClassId, roomIdString);
            MySQLHelper.ExecuteQuery(query);
            LoadStdRooms();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int priority = cbPriority.SelectedIndex + 1;
            TaggedItem ti = (TaggedItem)cbRoom.SelectedItem;
            if (ti != null)
            {
                int roomId = Int32.Parse(ti.Tag.ToString());

                if (RoomId == -1)
                {
                    // neuer Eintrag
                    string query = string.Format("INSERT INTO defaultrooms (CLASS_ID, ROOM_ID, priority) VALUES ({0}, {1}, {2})", ClassId, roomId, priority);
                    MySQLHelper.ExecuteQuery(query);
                }
                else
                {
                    // geänderter Eintrag
                    string query = string.Format("UPDATE defaultrooms SET priority={0} WHERE CLASS_ID={1} AND ROOM_ID={2}", priority, ClassId, RoomId);
                    MySQLHelper.ExecuteQuery(query);
                }

                LoadStdRooms();
            }
        }

        private int GetRoomSelectionIndex(int roomId)
        {
            int roomSel = -1;
            for (int i = 0; i < cbRoom.Items.Count; i++)
            {
                TaggedItem ti = (TaggedItem)cbRoom.Items[i];
                if (Int32.Parse(ti.Tag.ToString()) == roomId)
                {
                    roomSel = i;
                    break;
                }
            }
            return roomSel;
        }
    }
}
