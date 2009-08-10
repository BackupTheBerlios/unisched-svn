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
    public partial class EditUser : Form
    {
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
                MessageBox.Show("Die Passwörter stimmten nicht überein!");
            }
        }
    }
}