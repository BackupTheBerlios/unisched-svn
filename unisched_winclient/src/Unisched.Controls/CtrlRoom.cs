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
    public partial class CtrlRoom : UserControl, IDataUserControl
    {

        private bool roomTyp = false;
        private bool edit = false;
        private int id = 0;

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

        private void addBtn_Click(object sender, EventArgs e)
        {
            string insertroom;
            if (!edit)
                insertroom = "insert into unisched.room  (`ROOM_ID` ,`ROOM_NR` ,`ROOM_NAME` ,`ROOM_SEAT` ,`room_type`) values (NULL,'" + roomNrTb.Text + "','" + roomDescTb.Text + "','" + roomCountTb.Text + "','" + Convert.ToInt32(roomTyp).ToString() + "');";
            else
                insertroom = "update unisched.room set ROOM_NAME='" + roomDescTb.Text + "' ,ROOM_SEAT='" + roomCountTb.Text + "' ,room_type='" + Convert.ToInt32(roomTyp).ToString() + "' where ROOM_ID =" + id + ";";
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
