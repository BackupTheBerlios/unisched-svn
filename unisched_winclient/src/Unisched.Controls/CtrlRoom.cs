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
    public partial class CtrlRoom : UserControl, IDataUserControl
    {

        private bool roomTyp;
        private bool edit;
        private int id;

        public CtrlRoom()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                id = Convert.ToInt32(roomDgv[0, e.RowIndex].Value);
                edit = true;
                roomNrTb.Text = roomDgv[1, e.RowIndex].Value.ToString();
                roomNrTb.Enabled = false;
                roomDescTb.Text = roomDgv[2, e.RowIndex].Value.ToString();
                roomCountTb.Text = roomDgv[3, e.RowIndex].Value.ToString();
                if (Convert.ToInt32(roomDgv[4, e.RowIndex].Value) == 0)
                    roomTyp2.Checked = true;
                else
                    roomTyp1.Checked = true;
            }
        }

        private void CtrlRoom_Load(object sender, EventArgs e)
        {
            string roomselect = "select * from unisched.room";
            try
            {
                roomDgv.DataSource = MySQLHelper.ExecuteQuery(roomselect);
                roomDgv.Columns[0].Visible = false;
                roomDgv.Columns[4].Visible = false;
                roomDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CtrlRoom_Load()
        {
            roomTyp = false;
            edit = false;
            id = 0;
            string roomselect = "select * from unisched.room";
            try
            {
                roomDgv.DataSource = MySQLHelper.ExecuteQuery(roomselect);
                roomDgv.Columns[0].Visible = false;
                roomDgv.Columns[4].Visible = false;
                roomDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            string insertroom;
            if (!edit)
                insertroom = "insert into unisched.room  (`ROOM_ID` ,`ROOM_NR` ,`ROOM_NAME` ,`ROOM_SEAT` ,`room_type`) values (NULL,'" + roomNrTb.Text + "','" + roomDescTb.Text + "','" + roomCountTb.Text + "','" + Convert.ToInt32(roomTyp) + "');";
            else
                insertroom = "update unisched.room set ROOM_NAME='" + roomDescTb.Text + "' ,ROOM_SEAT='" + roomCountTb.Text + "' ,room_type='" + Convert.ToInt32(roomTyp) + "' where ROOM_ID =" + id + ";";
            MySQLHelper.ExecuteQuery(insertroom);
            roomDescTb.Enabled = false;
            roomCountTb.Enabled = false;
            addBtn.Enabled = false;
            edit = false;
            roomNrTb.Enabled = true;
            CtrlRoom_Load();

        }

        private void roomNrTb_TextChanged(object sender, EventArgs e)
        {

            roomDescTb.Enabled = true;
        }

        private void roomDescTb_TextChanged(object sender, EventArgs e)
        {

            roomCountTb.Enabled = true;
        }

        private void roomCountTb_TextChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
        }

        private void roomTyp2_CheckedChanged(object sender, EventArgs e)
        {
            roomTyp = false;
        }

        private void roomTyp1_CheckedChanged(object sender, EventArgs e)
        {
            roomTyp = true;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            string delroom = "delete from unisched.room where ROOM_ID =" + id+";";
            MySQLHelper.ExecuteQuery(delroom);
            CtrlRoom_Load();
            roomNrTb.Enabled = true;
            edit = false;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            CtrlRoom_Load();
            roomNrTb.Enabled = true;
            roomNrTb.Text = "";
            roomDescTb.Text = "";
            roomCountTb.Text = "";
            roomDescTb.Enabled = false;
            roomCountTb.Enabled = false;
        }
    }
}
