using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Unisched.Calendar
{
    public partial class CtrlDayDescription : UserControl
    {
        public CtrlDayDescription(string dayName, List<Timeunit> timeunits)
        {
            InitializeComponent();
            colDayDescription.Text = dayName;
            for (int i = 0; i < timeunits.Count; i++)
            {
                string start = timeunits[i].StartTime.ToShortTimeString();
                string end = timeunits[i].StartTime.Add(timeunits[i].Duration).ToShortTimeString();
                ListViewItem lvi = new ListViewItem(string.Format("{0}-{1}", start, end));
                lvDayDescription.Items.Add(lvi);
            }
        }

        private void lvDayDescription_Resize(object sender, EventArgs e)
        {
            colDayDescription.Width = lvDayDescription.Width;
        }
    }
}
