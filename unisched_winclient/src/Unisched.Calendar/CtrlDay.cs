using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Unisched.Calendar
{
    public partial class CtrlDay : UserControl
    {
        public CtrlDay()
        {
            InitializeComponent();
        }

        public CtrlDay(DateTime date, List<Appointment> appointments)
        {
            InitializeComponent();
            lvDay.Columns[0].Text = date.ToShortDateString();
            // TODO: leere Dummyitems entfernen
            foreach (Appointment appointment in appointments)
            {
                ListViewItem lvi = new ListViewItem(appointment.Name);
                lvi.Tag = appointment;
                lvDay.Items.Add(lvi);
                
            }
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = (lvDay.SelectedItems.Count == 0);
        }

        private void lvDay_Resize(object sender, EventArgs e)
        {
            colDay.Width = lvDay.Width;
        }

        private void lvDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvDay.SelectedItems.Count > 0)
            {
                Appointment appointment = (Appointment)lvDay.SelectedItems[0].Tag;
                lvDay.LabelEdit = appointment != null && appointment.Custom;
            }
        }
    }
}
