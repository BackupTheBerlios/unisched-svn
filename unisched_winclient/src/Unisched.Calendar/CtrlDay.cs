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
    public partial class CtrlDay : UserControl
    {
        private DateTime date;
        private SortedDictionary<DateTime, TimeSpan> bookingSlots;
        public delegate void OnBookingChangedDelegate();
        private OnBookingChangedDelegate OnBookingChangedMethod;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public CtrlDay()
        {
            InitializeComponent();
        }

        public CtrlDay(DateTime date, Dictionary<DateTime, TimeSpan> bookingSlots, OnBookingChangedDelegate onBookingChanged)
        {
            InitializeComponent();
            Date = date;
            lvDay.Columns[0].Text = Date.ToShortDateString();
            OnBookingChangedMethod += onBookingChanged;
            this.bookingSlots = new SortedDictionary<DateTime, TimeSpan>();
            foreach (DateTime start in bookingSlots.Keys)
            {
                // Zeit auf aktuelles Datum umsetzen
                DateTime correctedStart = new DateTime(Date.Year, Date.Month, Date.Day, start.Hour, start.Minute, start.Second);
                this.bookingSlots.Add(correctedStart, bookingSlots[start]);
                // ListViewItem hinzufügen
                lvDay.Items.Add(new ListViewItem());
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

        private void lvDay_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lvDay_DragDrop(object sender, DragEventArgs e)
        {
            Point p = lvDay.PointToClient(new Point(e.X, e.Y));
            ListViewItem lvi = lvDay.GetItemAt(p.X, p.Y);
            ListViewItem lviDragged = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            if (lviDragged != null)
            {
                // unterscheiden, ob Element von Veranstaltungsauswahl oder anderem Tag kommt (anhand gemeinsamen Listviewparents)
                if (lviDragged.ListView.Parent.Parent == lvDay.Parent.Parent)
                {
                    // aus anderem Tagcontrol
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
                    // aus Veranstaltungsauswahl
                    lvi.Text = lviDragged.Text;
                    lvi.Tag = lviDragged.Tag;
                    lvi.ToolTipText = lviDragged.ToolTipText;
                    lvi.BackColor = lviDragged.BackColor;

                }
                OnBookingChangedMethod();
            }
        }

        private void lvDay_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lvDay.DoDragDrop((ListViewItem)e.Item, DragDropEffects.Copy);
        }

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

        public void AddBooking(ListViewItem lvi, DateTime start, TimeSpan duration)
        {
            // passenden Slot finden
            int slotIndex = -1;
            int i = 0;
            foreach (DateTime bookingStart in bookingSlots.Keys)
            {
                if (bookingStart == start && bookingSlots[bookingStart] == duration)
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

        public List<Booking> GetBookings()
        {
            List<Booking> bookings = new List<Booking>();
            int i = 0;
            foreach(DateTime begin in bookingSlots.Keys)
            {

                ListViewItem lvi = lvDay.Items[i];
                if (lvi.Tag != null)
                {
                    int curId = Int32.Parse(lvi.Tag.ToString());
                    DateTime end = begin.Add(bookingSlots[begin]);
                    bookings.Add(new Booking(curId, begin, end));
                }
                i++;
            }
            return bookings;
        }

        public Dictionary<int, int> GetUsedSubjects()
        {
            Dictionary<int, int> usedSubjects = new Dictionary<int, int>();
            foreach (ListViewItem lvi in lvDay.Items)
            {
                if (lvi.Tag != null)
                {
                    int cur_id = Int32.Parse(lvi.Tag.ToString());
                    if (usedSubjects.ContainsKey(cur_id))
                    {
                        usedSubjects[cur_id]++;
                    }
                    else
                    {
                        usedSubjects.Add(cur_id, 1);
                    }
                }
            }
            return usedSubjects;
        }

        private void entfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDay.SelectedItems.Count > 0)
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
            if(e.KeyCode == Keys.Delete)
            {
                entfernenToolStripMenuItem_Click(sender, new EventArgs());
            }
        }
    }
}
