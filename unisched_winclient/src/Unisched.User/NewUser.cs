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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Unisched.Data;

namespace Unisched.User
{
    public partial class NewUser : Form
    {
        public string uName = "";
        public string pw = "";
        public bool admin = false;
       
        public NewUser()
        {
            if (uName != "")
                userNametb.Text = uName;
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (pwTb1.Text.Equals(pwTb2.Text))
            {
                string newUser = "insert into unisched.user values('" + userNametb.Text + "','" + Convert.ToInt32(adminCb.Checked) + "','" + pwTb1.Text + "');";
                DataTable dt = MySQLHelper.ExecuteQuery(newUser);
                dt.Dispose();
            }
            else
            {
                MessageBox.Show("Die Passwörter stimmten nicht überein!");
                uName = userNametb.Text;
            }
        }
    }
}
