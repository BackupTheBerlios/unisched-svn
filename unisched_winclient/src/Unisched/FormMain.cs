using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Unisched.Controls;
using Unisched.Core.Interfaces;

namespace Unisched
{
    public partial class FormMain : Form
    {
        private IDataUserControl CurrentControl;
        private readonly bool AdminMode;

        public FormMain(bool adminMode)
        {
            InitializeComponent();
            AdminMode = adminMode;
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            btnAbort.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = AdminMode;
            CtrlStart ctrlStart = new CtrlStart();
            SetActiveControl(ctrlStart);
        }

        private void SetActiveControl(IDataUserControl control)
        {
            // TODO: Prüfung, ob noch was offen
            if(CurrentControl != null)
            {
                
            }
            control.Initialize(AdminMode);
            CurrentControl = control;
            CurrentControl.GetControl().Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(CurrentControl.GetControl());
            btnEdit.Enabled = (AdminMode && CurrentControl.IsEditable());
        }
    }
}