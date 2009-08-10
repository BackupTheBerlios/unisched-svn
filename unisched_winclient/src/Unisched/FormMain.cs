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

        public FormMain(bool adminMode,string User)
        {
            InitializeComponent();
            tslblUser.Text = User;
            AdminMode = adminMode;
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void userAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlUserAdministration cua = new CtrlUserAdministration();
            SetActiveControl(cua);
            Refresh();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            btnAbort.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = AdminMode;
            CtrlStart ctrlStart = new CtrlStart();
            SetActiveControl(ctrlStart);
            if (AdminMode)
                this.dateiToolStripMenuItem.DropDownItems.Add(userAdminToolStripMenuItem);
        }

        private void SetActiveControl(IDataUserControl control)
        {
            // TODO: Prüfung, ob noch was offen
            if(CurrentControl != null)
            {
                pnlMainContent.Controls.Remove(CurrentControl.GetControl());   
            }
            control.Initialize(AdminMode);
            CurrentControl = control;
            CurrentControl.GetControl().Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(CurrentControl.GetControl());
            btnEdit.Enabled = (AdminMode && CurrentControl.IsEditable());
        }
    }
}