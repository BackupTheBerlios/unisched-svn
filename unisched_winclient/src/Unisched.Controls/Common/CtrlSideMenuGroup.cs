using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Unisched.Controls.Common
{
    public partial class CtrlSideMenuGroup : UserControl
    {
        private bool isExpanded;
        private Control ctrlBottom;
        
        public CtrlSideMenuGroup(string header)
        {
            InitializeComponent();
            isExpanded = false;
            lblHeader.Image = Properties.Resources.expand;
            ctrlBottom = null;
            lblHeader.Text = header;
            Height = lblHeader.Bottom;
        }

        public CtrlSideMenuGroup(string header, bool expanded)
        {
            InitializeComponent();
            isExpanded = true;
            lblHeader.Image = Properties.Resources.collapse;
            ctrlBottom = null;
            lblHeader.Text = header;
            Height = lblHeader.Bottom;
        }

        public void AddLinkItem(string itemName, string itemText, EventHandler clickEvent)
        {
            LinkLabel linkLabel = new LinkLabel();
            linkLabel.Name = itemName;
            linkLabel.Text = itemText;
            linkLabel.Click += clickEvent;
            AddControl(linkLabel);
        }

        public void AddItem(string itemName, string itemText)
        {
            Label label = new Label();
            label.Name = itemName;
            label.Text = itemText;
            AddControl(label);
        }

        private void AddControl(Control control)
        {
            control.AutoSize = true;
            control.Padding = new Padding(3);
            if (ctrlBottom == null)
            {
                control.Top = 1;
            }
            else
            {
                control.Top = ctrlBottom.Bottom + 1;
            }
            pnlItems.Controls.Add(control);
            ctrlBottom = control;
            if (isExpanded)
            {
                Height = pnlItems.Top + ctrlBottom.Bottom + 5;
            }
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            if (isExpanded)
            {
                lblHeader.Image = Properties.Resources.collapse;
                Height = pnlItems.Top + ctrlBottom.Bottom + 5;
            }
            else
            {
                lblHeader.Image = Properties.Resources.expand;
                Height = lblHeader.Bottom;
            }
        }
    }
}
