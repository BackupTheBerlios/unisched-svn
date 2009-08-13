using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            CtrlSideMenuGroup smg1 = new CtrlSideMenuGroup(Properties.Resources.Stammdatenpflege, true);
            smg1.AddLinkItem("raum", Properties.Resources.Raum, RaumCtrl);
            smg1.AddLinkItem("standardraum", Properties.Resources.Standardraum, StandardRoomCtrl);
            smg1.AddLinkItem("dozent", Properties.Resources.Dozent, TutorCtrl);
            smg1.AddLinkItem("fach", Properties.Resources.Fach, SubjectCtrl);
            smg1.AddLinkItem("studienrichtung", Properties.Resources.Studienrichtung, FieldStudyCtrl);
            smg1.AddLinkItem("seminargruppe", Properties.Resources.Seminargruppe, SemGrpCtrl);
            smg1.AddLinkItem("studienzeitraum", Properties.Resources.Studienzeitraum, DummyMethod);
            smg1.AddLinkItem("curriculum", Properties.Resources.Curriculum, DummyMethod);
            CtrlSideMenuGroup smg2 = new CtrlSideMenuGroup(Properties.Resources.Planerstellung, true);
            smg2.AddLinkItem("planerstellung", Properties.Resources.Plan_erstellen, planErstellenToolStripMenuItem_Click);
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

        private void RaumCtrl(object sender, EventArgs e)
        {
            SetActiveControl(new CtrlRoom());
        }

        private void TutorCtrl(object sender, EventArgs e)
        {
            SetActiveControl(new CtrlTutor());
        }

        private void SubjectCtrl(object sender, EventArgs e)
        {
            SetActiveControl(new CtrlSubject());
        }

        private void FieldStudyCtrl(object sender, EventArgs e)
        {
            SetActiveControl(new CtrlFieldStudy());
        }

        private void SemGrpCtrl(object sender, EventArgs e)
        {
            SetActiveControl(new CtrlSemGrp());
        }

        private void StandardRoomCtrl(object sender, EventArgs e)
        {
            SetActiveControl(new CtrlstandardRoom());
        }
    }
}