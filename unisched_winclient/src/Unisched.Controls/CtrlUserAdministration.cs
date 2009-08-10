using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Unisched.Data;
using Unisched.Core.Interfaces;
using Unisched.User;

namespace Unisched.Controls
{
    public partial class CtrlUserAdministration : UserControl, IDataUserControl
    {
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
    }
}
