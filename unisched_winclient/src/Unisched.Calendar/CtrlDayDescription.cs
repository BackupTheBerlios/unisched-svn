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
    /// <summary>
    /// An UserControl, that represents the description of a day, that can be used by the calendar.
    /// </summary>
    public partial class CtrlDayDescription : UserControl
    {
        /// <summary>
        /// Contructor. Initializes the control with the help of the name of the day
        /// and a list of time units, that should be shown.
        /// </summary>
        /// <param name="dayName">The name of the day.</param>
        /// <param name="timeunits">A list of time units.</param>
        public CtrlDayDescription(string dayName, IList<Timeunit> timeunits)
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
