using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Unisched.Calendar
{
    public partial class CtrlDay : UserControl
    {
        public CtrlDay()
        {
            InitializeComponent();
        }

        public CtrlDay(DateTime date)
        {
            InitializeComponent();
            lvDay.Columns[0].Text = date.ToShortDateString();
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
            //lv.GetItemAt(p.X, p.Y).SubItems["id"].Text = e.Data.GetData(typeof(string)).ToString();
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
                    lviDragged.Text = string.Empty;
                    lviDragged.Tag = null;
                    lviDragged.ToolTipText = string.Empty;
                }
                else
                {
                    // aus Veranstaltungsauswahl
                    lvi.Text = lviDragged.Text;
                    lvi.Tag = lviDragged.Tag;
                    lvi.ToolTipText = lviDragged.ToolTipText;
                }
            }
        }

        private void lvDay_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //lv.DoDragDrop(((ListViewItem)e.Item).SubItems["id"].Text, DragDropEffects.Copy);
            lvDay.DoDragDrop((ListViewItem)e.Item, DragDropEffects.Copy);
        }
    }
}
