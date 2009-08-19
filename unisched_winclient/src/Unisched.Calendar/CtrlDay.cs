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
using System.Drawing;

namespace Unisched.Calendar
{
    /// <summary>
    /// This usercontrol represents one day, that can be used by the calendar.
    /// It contains entries, that are called bookings.
    /// </summary>
    public partial class CtrlDay : UserControl
    {
        private DateTime date;
        private readonly SortedDictionary<DateTime, TimeSpan> BookingSlots;
        private readonly OnBookingChangedDelegate OnBookingChangedMethod;
        private readonly bool AdminMode;

        /// <summary>
        /// A delegate, that is used to refresh a list of used bookings.
        /// </summary>
        public delegate void OnBookingChangedDelegate();

        /// <summary>
        /// The date of the day
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Empty constructor. Initializes an empty day, that is not set to a date.
        /// </summary>
        public CtrlDay(bool adminMode)
        {
            AdminMode = adminMode;
            InitializeComponent();
        }

        /// <summary>
        /// Constructor, that initializes a day with the help of a date,
        /// a list of possible booking slots and a delegate,
        /// which can be used to indicate that a booking has changed.
        /// </summary>
        /// <param name="adminMode">Determines whether the calendar can be shown in admin mode.</param>
        /// <param name="date">The date of the day.</param>
        /// <param name="bookingSlots">A list of booking slots, which should be shown by the day.</param>
        /// <param name="onBookingChanged">Delegate for booking change indication.</param>
        public CtrlDay(bool adminMode, DateTime date, Dictionary<DateTime, TimeSpan> bookingSlots, OnBookingChangedDelegate onBookingChanged)
        {
            AdminMode = adminMode;
            InitializeComponent();
            Date = date;
            lvDay.Columns[0].Text = Date.ToShortDateString();
            OnBookingChangedMethod += onBookingChanged;
            BookingSlots = new SortedDictionary<DateTime, TimeSpan>();
            foreach (DateTime start in bookingSlots.Keys)
            {
                // change time to used date
                DateTime correctedStart = new DateTime(Date.Year, Date.Month, Date.Day, start.Hour, start.Minute, start.Second);
                BookingSlots.Add(correctedStart, bookingSlots[start]);
                // add ListViewItem
                lvDay.Items.Add(new ListViewItem());
            }
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !AdminMode || (lvDay.SelectedItems.Count == 0);
        }

        private void lvDay_Resize(object sender, EventArgs e)
        {
            colDay.Width = lvDay.Width;
        }

        private void lvDay_DragEnter(object sender, DragEventArgs e)
        {
            if (AdminMode)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void lvDay_DragDrop(object sender, DragEventArgs e)
        {
            if (AdminMode)
            {
                Point p = lvDay.PointToClient(new Point(e.X, e.Y));
                ListViewItem lvi = lvDay.GetItemAt(p.X, p.Y);
                ListViewItem lviDragged = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                if (lviDragged != null)
                {
                    // determine whether element comes from curriculum list or another CtrlDay-object
                    if (lviDragged.ListView.Parent.Parent == lvDay.Parent.Parent)
                    {
                        // from another CtrlDay-object
                        lvi.Text = lviDragged.Text;
                        lvi.Tag = lviDragged.Tag;
                        lvi.ToolTipText = lviDragged.ToolTipText;
                        lvi.BackColor = lviDragged.BackColor;
                        lviDragged.Text = string.Empty;
                        lviDragged.Tag = null;
                        lviDragged.ToolTipText = string.Empty;
                        lviDragged.BackColor = SystemColors.Window;
                    }
                    else
                    {
                        // from curriculum list
                        lvi.Text = lviDragged.Text;
                        lvi.Tag = lviDragged.Tag;
                        lvi.ToolTipText = lviDragged.ToolTipText;
                        lvi.BackColor = lviDragged.BackColor;

                    }
                    OnBookingChangedMethod();
                }
            }
        }

        private void lvDay_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (AdminMode)
            {
                lvDay.DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        /// <summary>
        /// Removes all bookings.
        /// </summary>
        public void ResetDay()
        {
            foreach (ListViewItem lvi in lvDay.Items)
            {
                lvi.Text = string.Empty;
                lvi.Tag = null;
                lvi.ToolTipText = string.Empty;
                lvi.BackColor = SystemColors.Window;
            }
        }

        /// <summary>
        /// Add a booking to the day.
        /// </summary>
        /// <param name="lvi">ListViewItem, that represents the booking.</param>
        /// <param name="start">Start of the booking.</param>
        /// <param name="duration">Duration of the booking.</param>
        public void AddBooking(ListViewItem lvi, DateTime start, TimeSpan duration)
        {
            // passenden Slot finden
            int slotIndex = -1;
            int i = 0;
            foreach (DateTime bookingStart in BookingSlots.Keys)
            {
                if (bookingStart == start && BookingSlots[bookingStart] == duration)
                {
                    slotIndex = i;
                    break;
                }
                i++;
            }
            if (slotIndex != -1 && slotIndex < lvDay.Items.Count)
            {
                lvDay.Items[slotIndex].Text = lvi.Text;
                lvDay.Items[slotIndex].Tag = lvi.Tag;
                lvDay.Items[slotIndex].ToolTipText = lvi.ToolTipText;
                lvDay.Items[slotIndex].BackColor = lvi.BackColor;
                OnBookingChangedMethod();
            }
        }

        /// <summary>
        /// Retrieves all bookings, which where made.
        /// </summary>
        /// <returns>List of booking objects.</returns>
        public List<Booking> GetBookings()
        {
            List<Booking> bookings = new List<Booking>();
            int i = 0;
            foreach(DateTime begin in BookingSlots.Keys)
            {

                ListViewItem lvi = lvDay.Items[i];
                if (lvi.Tag != null)
                {
                    int curId = Int32.Parse(lvi.Tag.ToString());
                    DateTime end = begin.Add(BookingSlots[begin]);
                    bookings.Add(new Booking(curId, begin, end));
                }
                i++;
            }
            return bookings;
        }

        /// <summary>
        /// Retrieves a dictionary, that gives information about uses subjects.
        /// </summary>
        /// <returns>Subject dictionary, that consist of the the curriculum id as key and its use count as value.</returns>
        public Dictionary<int, int> GetUsedSubjects()
        {
            Dictionary<int, int> usedSubjects = new Dictionary<int, int>();
            foreach (ListViewItem lvi in lvDay.Items)
            {
                if (lvi.Tag != null)
                {
                    int curId = Int32.Parse(lvi.Tag.ToString());
                    if (usedSubjects.ContainsKey(curId))
                    {
                        usedSubjects[curId]++;
                    }
                    else
                    {
                        usedSubjects.Add(curId, 1);
                    }
                }
            }
            return usedSubjects;
        }

        private void entfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AdminMode && lvDay.SelectedItems.Count > 0)
            {
                lvDay.SelectedItems[0].Text = string.Empty;
                lvDay.SelectedItems[0].Tag = null;
                lvDay.SelectedItems[0].ToolTipText = string.Empty;
                lvDay.SelectedItems[0].BackColor = SystemColors.Window;
                OnBookingChangedMethod();
            }
        }

        private void lvDay_KeyUp(object sender, KeyEventArgs e)
        {
            if(AdminMode && e.KeyCode == Keys.Delete)
            {
                entfernenToolStripMenuItem_Click(sender, new EventArgs());
            }
        }
    }
}
