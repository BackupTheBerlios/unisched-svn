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
    /// Login form.
    /// </summary>
    public partial class Uuser : Form
    {
        ///<summary>
        /// Username.
        ///</summary>
        public string uName = string.Empty;
        /// <summary>
        /// Validated
        /// </summary>
        public bool validated;
        /// <summary>
        /// Admin state
        /// </summary>
        public bool admin;

        /// <summary>
        /// Constructor, initializes the form.
        /// </summary>
        public Uuser()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            uName = userTextBox.Text;
            string password = pwTextBox.Text;
            string userselect = "Select * from unisched.user where USER_LOGIN ='"+uName+"'";
            DataTable usdt = MySQLHelper.ExecuteQuery(userselect);
            if (usdt.Rows.Count == 1)
            {
                admin = Convert.ToBoolean(usdt.Rows[0]["USER_ADMIN"]);
                if (password.Equals(Convert.ToString(usdt.Rows[0]["USER_PASSWORD"])))
                    validated = true;
                else
                    validated = false;
            }
            else
                validated = false;
        }
    }
}
