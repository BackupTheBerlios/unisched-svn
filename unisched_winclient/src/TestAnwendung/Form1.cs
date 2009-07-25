using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Unisched.Calendar;

namespace TestAnwendung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments.Add(new Appointment("Test", DateTime.Now, DateTime.Now));
            appointments.Add(new Appointment("Test", DateTime.Now, DateTime.Now));
            appointments.Add(new Appointment("Test", DateTime.Now, DateTime.Now));
            appointments.Add(new Appointment("Test", DateTime.Now, DateTime.Now));
            CtrlDay ctrlDay = new CtrlDay(DateTime.Now, appointments);
            ctrlDay.Dock = DockStyle.Fill;
            Controls.Add(ctrlDay);
        }
    }
}