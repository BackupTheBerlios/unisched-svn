using System;
using System.Windows.Forms;

namespace Unisched.Controls.Common
{
    /// <summary>
    /// A control, that represents a side menu group.
    /// </summary>
    public partial class CtrlSideMenuGroup : UserControl
    {
        private bool IsExpanded;
        private Control CtrlBottom;
        
        ///<summary>
        /// Constructor. Initializes the control.
        ///</summary>
        ///<param name="header">Text that is shown in the header.</param>
        public CtrlSideMenuGroup(string header)
        {
            InitializeComponent();
            IsExpanded = false;
            lblHeader.Image = Properties.Resources.expand;
            CtrlBottom = null;
            lblHeader.Text = header;
            Height = lblHeader.Bottom;
        }

        ///<summary>
        /// Constructor. Initializes the control.
        ///</summary>
        ///<param name="header">Text that is shown in the header.</param>
        ///<param name="expanded">Indicates, whether the group should be expanded.</param>
        public CtrlSideMenuGroup(string header, bool expanded)
        {
            InitializeComponent();
            IsExpanded = expanded;
            lblHeader.Image = Properties.Resources.collapse;
            CtrlBottom = null;
            lblHeader.Text = header;
            Height = lblHeader.Bottom;
        }

        /// <summary>
        /// Adds an item to the group, that handles a click event.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="itemText">Shown text of the item.</param>
        /// <param name="clickEvent">Event that is fired by clicking the item.</param>
        public void AddLinkItem(string itemName, string itemText, EventHandler clickEvent)
        {
            LinkLabel linkLabel = new LinkLabel();
            linkLabel.Name = itemName;
            linkLabel.Text = itemText;
            linkLabel.Click += clickEvent;
            linkLabel.ForeColor = pnlItems.ForeColor;
            linkLabel.ActiveLinkColor = pnlItems.ForeColor;
            linkLabel.LinkColor = pnlItems.ForeColor;
            AddControl(linkLabel);
        }

        /// <summary>
        /// Adds an item to the group that just consists of a text element.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="itemText">Shown text of the item.</param>
        public void AddItem(string itemName, string itemText)
        {
            Label label = new Label();
            label.Name = itemName;
            label.Text = itemText;
            label.ForeColor = pnlItems.ForeColor;
            AddControl(label);
        }

        private void AddControl(Control control)
        {
            control.AutoSize = true;
            control.Padding = new Padding(3);
            if (CtrlBottom == null)
            {
                control.Top = 1;
            }
            else
            {
                control.Top = CtrlBottom.Bottom + 1;
            }
            pnlItems.Controls.Add(control);
            CtrlBottom = control;
            if (IsExpanded)
            {
                Height = pnlItems.Top + CtrlBottom.Bottom + 5;
            }
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            IsExpanded = !IsExpanded;
            if (IsExpanded)
            {
                lblHeader.Image = Properties.Resources.collapse;
                Height = pnlItems.Top + CtrlBottom.Bottom + 5;
            }
            else
            {
                lblHeader.Image = Properties.Resources.expand;
                Height = lblHeader.Bottom;
            }
        }
    }
}
