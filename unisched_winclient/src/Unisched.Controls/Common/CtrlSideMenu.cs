using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Unisched.Controls.Common
{
    public partial class CtrlSideMenu : UserControl
    {
        List<CtrlSideMenuGroup> menuGroups;

        public CtrlSideMenu()
        {
            InitializeComponent();
            menuGroups = new List<CtrlSideMenuGroup>();
        }

        public void AddSideMenuGroup(CtrlSideMenuGroup smg)
        {
            smg.Dock = DockStyle.Top;
            Controls.Add(smg);
            smg.BringToFront();

            menuGroups.Add(smg);
        }

    }
}
