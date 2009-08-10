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