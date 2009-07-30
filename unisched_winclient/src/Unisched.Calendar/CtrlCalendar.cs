using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Unisched.Calendar.Properties;
using Unisched.Core;

namespace Unisched.Calendar
{
    public partial class CtrlCalendar : UserControl
    {
        public CtrlCalendar()
        {
            InitializeComponent();
            string culture = AppSettings.GetSetting("culture");
            if (!string.IsNullOrEmpty(culture))
            {
                Resources.Culture = new CultureInfo(culture);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
            {
                MessageBox.Show(Resources.DateErrorText, Resources.DateErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // TODO: alte Eingaben verarbeiten
            RefreshCalendar();
        }

        private void RefreshCalendar()
        {
            pnlMain.SuspendLayout();
            pnlMain.Controls.Clear();
            DateTime date = dtpStart.Value;
            int daysToMonday;
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Tuesday:
                    daysToMonday = 1;
                    break;
                case DayOfWeek.Wednesday:
                    daysToMonday = 2;
                    break;
                case DayOfWeek.Thursday:
                    daysToMonday = 3;
                    break;
                case DayOfWeek.Friday:
                    daysToMonday = 4;
                    break;
                default:
                    // da Wochenende nicht angezeigt wird, sind es bei Sa, So und Mo 0 Tage
                    daysToMonday = 0;
                    break;
            }
            // Dummypanels
            CtrlDay ctrlDayReference = new CtrlDay();
            for (int i = 0; i < daysToMonday; i++)
            {
                Panel pnlDummy = new Panel();
                pnlDummy.Width = ctrlDayReference.Width;
                pnlDummy.Height = ctrlDayReference.Height;
                pnlDummy.Margin = new Padding(0);
                pnlDummy.Padding = new Padding(0);
                pnlMain.Controls.Add(pnlDummy);
            }
            do
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    // TODO: initial leere Appointments zur gewünschten Zeit einfügen
                    List<Appointment> appointments = new List<Appointment>();
                    CtrlDay ctrlDay = new CtrlDay(date, appointments);
                    pnlMain.Controls.Add(ctrlDay);
                }
                date = date.AddDays(1);
            }
            while (date <= dtpEnd.Value);
            RefreshCalendarSize();
            pnlMain.ResumeLayout();
        }

        private void RefreshCalendarSize()
        {
            int width = pnlMain.ClientSize.Width/5;
            foreach (Control control in pnlMain.Controls)
            {
                control.Width = width;
            }
        }

        private void pnlMain_Resize(object sender, EventArgs e)
        {
            RefreshCalendarSize();
        }
    }
}
