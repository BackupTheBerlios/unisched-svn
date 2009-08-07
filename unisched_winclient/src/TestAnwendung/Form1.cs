using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Unisched.Data;

namespace TestAnwendung
{
    public partial class Form1 : Form
    {
        private DataAccess daTest = null;

        public Form1()
        {
            InitializeComponent();

            daTest = UnischedAccessHelper.GetTestTableAccess();
            if (daTest != null)
            {
                daTest.InitDataGridView(dataGridView1);
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (daTest != null)
            {
                daTest.Update();
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (daTest != null)
            {
                daTest.Cancel();
            }
        }
    }
}