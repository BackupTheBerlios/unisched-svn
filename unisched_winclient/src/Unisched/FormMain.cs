/*
 *   This file is part of Unisched Winclient.
 *
 *   Unisched Winclient is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   Unisched Winclient is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with Unisched Winclient.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Windows.Forms;
using Unisched.Controls;
using Unisched.Controls.Common;
using Unisched.Core.Interfaces;
using Unisched.Core;

namespace Unisched
{
    /// <summary>
    /// The main form of the application.
    /// With the help of this Form the user can navigate to every subform of the application.
    /// </summary>
    public partial class FormMain : Form
    {
        private IDataUserControl CurrentControl;
        private readonly bool AdminMode;

        /// <summary>
        /// Constructor, initializes the application
        /// </summary>
        /// <param name="adminMode">Determines whether the user has administration privilegs.</param>
        /// <param name="user">The username, that should be shown.</param>
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
            userAdminToolStripMenuItem.Visible = AdminMode;
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
            pnlMainContent.Controls.Add(CurrentControl.GetControl());
            CurrentControl.GetControl().Dock = DockStyle.Fill;
        }

        private void BuildSideMenu()
        {
            if (AdminMode)
            {
                CtrlSideMenuGroup smg1 = new CtrlSideMenuGroup(Properties.Resources.Stammdatenpflege, true);
                smg1.AddLinkItem("raum", Properties.Resources.Raum, RaumCtrl);
                smg1.AddLinkItem("standardraum", Properties.Resources.Standardraum, StandardRoomCtrl);
                smg1.AddLinkItem("dozent", Properties.Resources.Dozent, TutorCtrl);
                smg1.AddLinkItem("fach", Properties.Resources.Fach, SubjectCtrl);
                smg1.AddLinkItem("studienrichtung", Properties.Resources.Studienrichtung, FieldStudyCtrl);
                smg1.AddLinkItem("seminargruppe", Properties.Resources.Seminargruppe, SemGrpCtrl);
                smg1.AddLinkItem("studienzeitraum", Properties.Resources.Studienzeitraum, ClassPeriodCtrl);
                smg1.AddLinkItem("curriculum", Properties.Resources.Curriculum, CurriculumCtrl);
                ctrlSideMenu.AddSideMenuGroup(smg1);
                CtrlSideMenuGroup smg2 = new CtrlSideMenuGroup(Properties.Resources.Planerstellung, true);
                smg2.AddLinkItem("planerstellung", Properties.Resources.Plan_erstellen, SchedulingCtrl);
                ctrlSideMenu.AddSideMenuGroup(smg2);
            }
            else
            {
                CtrlSideMenuGroup smg = new CtrlSideMenuGroup(Properties.Resources.Stundenplaene, true);
                smg.AddLinkItem("planerstellung", Properties.Resources.Stundenplaene_ansehen, SchedulingCtrl);
                ctrlSideMenu.AddSideMenuGroup(smg);
            }
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

        private void SchedulingCtrl(object sender, EventArgs e)
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

        private void ClassPeriodCtrl(object sender, EventArgs e)
        {
            SetActiveControl(new CtrlClassPeriod());
        }

        private void CurriculumCtrl(object sender, EventArgs e)
        {
            SetActiveControl(new CtrlCurriculum());
        }
    }
}
