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

namespace Unisched.User
{
    /// <summary>
    /// Form that can edit a user.
    /// </summary>
    public partial class EditUser : Form
    {
        /// <summary>
        /// Constructor, initializes the form.
        /// </summary>
        /// <param name="username">Name of the user.</param>
        /// <param name="admin">Admin state of the user.</param>
        public EditUser(string username,bool admin)
        {            
            InitializeComponent();
            userNametb.Text = username;
            adminCb.Checked = admin;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (pwTb1.Text.Equals(pwTb2.Text))
            {
                string newUser = "update unisched.user set USER_PASSWORD='" + pwTb1.Text + "', USER_ADMIN ='" + Convert.ToInt32(adminCb.Checked) + "' where USER_LOGIN='" + userNametb.Text + "';";
                DataTable dt = MySQLHelper.ExecuteQuery(newUser);
                dt.Dispose();
            }
            else
            {
                MessageBox.Show("Die Passw�rter stimmten nicht �berein!");
            }
        }

        private void pwlbl1_Click(object sender, EventArgs e)
        {

        }
    }
}
