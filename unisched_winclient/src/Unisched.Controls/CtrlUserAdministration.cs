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
using Unisched.User;

namespace Unisched.Controls
{
    /// <summary>
    /// Control for accessing the user administration.
    /// </summary>
    public partial class CtrlUserAdministration : UserControl, IDataUserControl
    {
        /// <summary>
        /// Constructor, initializes the control.
        /// </summary>
        public CtrlUserAdministration()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CtrlUserAdministration_Load(object sender, EventArgs e)
        {
            string userselect = "select USER_LOGIN , USER_ADMIN from unisched.user";
            try
            {
                ctrlUserDGV.DataSource = MySQLHelper.ExecuteQuery(userselect);
                ctrlUserDGV.Columns[0].HeaderText = "Benutzername";
                ctrlUserDGV.Columns[1].HeaderText = "Admin";
                ctrlUserDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CtrlUserAdministration_Load()
        {
            string userselect = "select USER_LOGIN , USER_ADMIN from unisched.user";
            try
            {
                ctrlUserDGV.DataSource = MySQLHelper.ExecuteQuery(userselect);
                ctrlUserDGV.Columns[0].HeaderText = "Benutzername";
                ctrlUserDGV.Columns[1].HeaderText = "Admin";
                ctrlUserDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            NewUser nu = new NewUser();
            nu.ShowDialog();
            CtrlUserAdministration_Load();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvsrc = ctrlUserDGV.SelectedRows;
            string uName = dgvsrc[0].Cells[0].Value.ToString();
            string admin = dgvsrc[0].Cells[1].Value.ToString();
            EditUser eu = new EditUser(uName, admin.Equals("1"));
            eu.ShowDialog();
            CtrlUserAdministration_Load();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvsrc = ctrlUserDGV.SelectedRows;
            string uName = dgvsrc[0].Cells[0].Value.ToString();
            string deleteUser = "delete from unisched.user where USER_LOGIN = '" + uName + "';";
            DataTable dt = MySQLHelper.ExecuteQuery(deleteUser);
            dt.Dispose();
            CtrlUserAdministration_Load();
        }

        public void Initialize(bool admin)
        {
            // nothing to do
        }

        public Control GetControl()
        {
            return this;
        }
    }
}
