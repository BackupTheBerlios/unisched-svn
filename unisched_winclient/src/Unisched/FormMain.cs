using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Unisched.Controls;
using Unisched.Controls.Common;
using Unisched.Core.Interfaces;
using Unisched.Core;

namespace Unisched
{
    public partial class FormMain : Form
    {
        private IDataUserControl CurrentControl;
        private readonly bool AdminMode;

        public FormMain(bool adminMode, string user)
        {
            string culture = AppSettings.GetSetting("culture");
            if (!string.IsNullOrEmpty(culture))
            {
                Properties.Resources.Culture = new System.Globalization.CultureInfo(culture);
            }
            InitializeComponent();
            tslblUser.Text = user;
            AdminMode = adminMode;
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void userAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetActiveControl(new CtrlUserAdministration());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (AdminMode)
            {
                extrasToolStripMenuItem.DropDownItems.Add(userAdminToolStripMenuItem);
            }
            BuildSideMenu();
            SetActiveControl(new CtrlStart());
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
        }

        private void BuildSideMenu()
        {
            CtrlSideMenuGroup smg1 = new CtrlSideMenuGroup("Stammdatenpflege", true);
            smg1.AddLinkItem("raum", "Raum", DummyMethod);
            smg1.AddLinkItem("standardraum", "Standardraum", DummyMethod);
            smg1.AddLinkItem("dozent", "Dozent", DummyMethod);
            smg1.AddLinkItem("fach", "Fach", DummyMethod);
            smg1.AddLinkItem("studienrichtung", "Studienrichtung", DummyMethod);
            smg1.AddLinkItem("seminargruppe", "Seminargruppe", DummyMethod);
            smg1.AddLinkItem("studienzeitraum", "Studienzeitraum", DummyMethod);
            smg1.AddLinkItem("curriculum", "Curriculum", DummyMethod);
            CtrlSideMenuGroup smg2 = new CtrlSideMenuGroup("Planerstellung", true);
            smg2.AddLinkItem("planerstellung", "Plan erstellen", planErstellenToolStripMenuItem_Click);
            ctrlSideMenu.AddSideMenuGroup(smg1);
            ctrlSideMenu.AddSideMenuGroup(smg2);
        }

        private void DummyMethod(object sender, EventArgs e)
        {
            MessageBox.Show("Hier muss noch was passieren");
        }

        private void deutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppSettings.SetSetting("culture", "de-DE");
            ShowRestartMessage();
        }

        private void englischToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppSettings.SetSetting("culture", "en-GB");
            ShowRestartMessage();
        }

        private static void ShowRestartMessage()
        {
            if (MessageBox.Show(Properties.Resources.RestartMessage, Properties.Resources.RestartMessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void planErstellenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetActiveControl(new CtrlScheduling());
        }

    }
}