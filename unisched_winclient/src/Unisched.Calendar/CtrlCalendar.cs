using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Unisched.Calendar.Properties;
using Unisched.Core;
using System.Drawing;
using Unisched.Data;
using System.Data;

namespace Unisched.Calendar
{
    public partial class CtrlCalendar : UserControl
    {
        private readonly int DayWidth = 120;
        private readonly int DayHeight = 104;
        private DataAccess BookingAccess;
        private DataAccess CurriculumAccess;

        public CtrlCalendar()
        {
            InitializeComponent();
            string culture = AppSettings.GetSetting("culture");
            if (!string.IsNullOrEmpty(culture))
            {
                Resources.Culture = new CultureInfo(culture);
            }
            BookingAccess = UnischedAccessHelper.GetBookingTableAccess();
            CurriculumAccess = UnischedAccessHelper.GetCurriculumTableAccess();
            CurriculumAccess.InitListView(lstSubject);
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
            // alles raushauen
            pnlMain.Controls.Clear();
            // Tagbeschreibung und -zeiten einfügen
            InitWeekDayDescriptionControls();
            // berechnen, wie viele leere Tage eingefügt werden müssen, wenn nach erster Termin nach Montag ist
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
            // Dummypanels einfügen
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
            // Tagcontrols einfügen
            int weeks = 0;
            do
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    // TODO: initial leere Appointments zur gewünschten Zeit einfügen
                    List<Appointment> appointments = new List<Appointment>();
                    CtrlDay ctrlDay = new CtrlDay(date, appointments);
                    ctrlDay.Size = new Size(DayWidth, DayHeight);
                    pnlMain.Controls.Add(ctrlDay);
                    // Wochen zählen
                    if (date.DayOfWeek == DayOfWeek.Monday)
                    {
                        weeks++;
                    }
                }
                date = date.AddDays(1);
            }
            while (date <= dtpEnd.Value);
            // Breite anpassen
            pnlMain.ClientSize = new Size((weeks + 1) * DayWidth, DayHeight * 5);
            pnlMain.ResumeLayout();
        }

        private void InitWeekDayDescriptionControls()
        {
            // Zeiteinheiten holen
            List<Timeunit> timeunits = new List<Timeunit>();
            DataTable dt = MySQLHelper.ExecuteQuery("SELECT TU_START, TU_DURATION FROM timeunits WHERE TU_TYP=1 ORDER BY TU_START");
            foreach (DataRow row in dt.Rows)
            {
                int start = Int32.Parse(row["TU_START"].ToString());
                int duration = Int32.Parse(row["TU_DURATION"].ToString());
                timeunits.Add(new Timeunit(start, duration));
            }
            // für jeden Tag ein Control einfügen
            for (int i = 1; i < 6; i++)
            {
                string dayName = Resources.Culture.DateTimeFormat.DayNames[i];
                CtrlDayDescription ctrlDayDesc = new CtrlDayDescription(dayName, timeunits);
                ctrlDayDesc.Size = new Size(DayWidth, DayHeight);
                pnlMain.Controls.Add(ctrlDayDesc);
            }
        }
    }
}
