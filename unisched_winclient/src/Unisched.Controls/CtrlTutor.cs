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
    public partial class CtrlTutor : UserControl, IDataUserControl
    {

        private bool edit = false;
        private int id = 0;
        
        public CtrlTutor()
        {
            InitializeComponent();
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

        private void CtrlTutor_Load(object sender, EventArgs e)
        {
            string tutorselect = "select * from unisched.lecturer";
            tutorDgv.DataSource = MySQLHelper.ExecuteQuery(tutorselect);
            tutorDgv.Columns[0].Visible = false;
            tutorDgv.Columns[3].Visible = false;
            tutorDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CtrlTutor_Load()
        {
            edit = false;
            id = 0;
            string tutorselect = "select * from unisched.lecturer";
            tutorDgv.DataSource = MySQLHelper.ExecuteQuery(tutorselect);
            tutorDgv.Columns[0].Visible = false;
            tutorDgv.Columns[3].Visible = false;
            tutorDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void tutorDgv_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(tutorDgv[0, e.RowIndex].Value);
                edit = true;
                tutorFnTb.Text = tutorDgv[2, e.RowIndex].Value.ToString();
                tutorLnTb.Text = tutorDgv[1, e.RowIndex].Value.ToString();
                telNrTb.Text = tutorDgv[4, e.RowIndex].Value.ToString();
                delBtn.Enabled = true;
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            CtrlTutor_Load();
            tutorFnTb.Enabled = true;
            tutorFnTb.Text = "";
            tutorLnTb.Text = "";
            telNrTb.Text = "";
            tutorLnTb.Enabled = false;
            telNrTb.Enabled = false;
            addBtn.Enabled = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string inserttutor;
            if (!edit)
                inserttutor = "insert into unisched.lecturer  (`LEC_ID` ,`LEC_LNAME` ,`LEC_GNAME` ,`LEC_TEL`) values (NULL,'" + tutorLnTb.Text + "','" + tutorFnTb.Text + "','" + telNrTb.Text + "');";
            else
                inserttutor = "update unisched.lecturer set LEC_GNAME='" + tutorFnTb.Text + "' ,LEC_LNAME='" + tutorLnTb.Text + "' ,LEC_TEL='" + telNrTb.Text + "' where lecturer.LEC_ID =" + id + ";";
            MySQLHelper.ExecuteQuery(inserttutor);
            tutorLnTb.Enabled = false;
            telNrTb.Enabled = false;
            addBtn.Enabled = false;
            edit = false;
            tutorFnTb.Enabled = true;
            CtrlTutor_Load();
            delBtn.Enabled = false;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            string deltutor = "delete from unisched.lecturer where LEC_ID =" + id + ";";
            MySQLHelper.ExecuteQuery(deltutor);
            CtrlTutor_Load();
            tutorFnTb.Enabled = true;
            edit = false;
        }
    }
}
