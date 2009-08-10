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
    public partial class Uuser : Form
    {
        public string uName = "";
        public bool validated = false;
        public bool admin = false;

        public Uuser()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            uName = userTextBox.Text;
            string password = pwTextBox.Text;
            string userselect = "Select * from unisched.user where USER_LOGIN ='"+uName+"' and USER_PASSWORD ='"+password+"'";
            DataTable usdt = MySQLHelper.ExecuteQuery(userselect);
            if (usdt.Rows.Count == 1)
            {
                admin = Convert.ToBoolean(usdt.Rows[0]["USER_ADMIN"]);
                validated = true;
            }
            else
                validated = false;
        }
    }
}