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
            foreach (Appointment appointment in appointments)
            {
                listView1.Items.Add(appointment.Name);
            }
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
    }
}
