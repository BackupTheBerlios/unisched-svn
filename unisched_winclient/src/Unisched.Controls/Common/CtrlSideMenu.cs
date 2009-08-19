using System.Collections.Generic;
using System.Windows.Forms;

namespace Unisched.Controls.Common
{
    /// <summary>
    /// A side menu user control, that can consist of several side menu groups.
    /// </summary>
    public partial class CtrlSideMenu : UserControl
    {
        readonly List<CtrlSideMenuGroup> MenuGroups;

        /// <summary>
        /// Constructor. Initializes the control.
        /// </summary>
        public CtrlSideMenu()
        {
            InitializeComponent();
            MenuGroups = new List<CtrlSideMenuGroup>();
        }

        /// <summary>
        /// Adds a side menu group to the control.
        /// </summary>
        /// <param name="smg">Side menu control to add.</param>
        public void AddSideMenuGroup(CtrlSideMenuGroup smg)
        {
            smg.Dock = DockStyle.Top;
            Controls.Add(smg);
            smg.BringToFront();
            MenuGroups.Add(smg);
        }

    }
}
