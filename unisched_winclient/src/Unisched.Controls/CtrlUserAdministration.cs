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
            ctrlUserDGV.DataSource = MySQLHelper.ExecuteQuery(userselect);
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
