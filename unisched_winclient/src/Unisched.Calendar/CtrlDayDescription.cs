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
