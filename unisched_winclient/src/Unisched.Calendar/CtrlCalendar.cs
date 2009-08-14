using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Unisched.Core;
using Unisched.Data;
using System.Data;
using Unisched.Core.Common;

namespace Unisched.Calendar
{
    public partial class CtrlCalendar : UserControl
    {
        private const int DayWidth = 100;
        private const int DayHeight = 104;

        public CtrlCalendar()
        {
            string culture = AppSettings.GetSetting("culture");
            if (!string.IsNullOrEmpty(culture))
            {
                Properties.Resources.Culture = new System.Globalization.CultureInfo(culture);
            }
            InitializeComponent();
            InitControls();
        }

        public void SetAccess(bool adminMode)
        {
            grbAppointments.Visible = adminMode;
            grbOptions.Visible = adminMode;
            pnlMain.Enabled = adminMode;
        }

        private void InitControls()
        {
            cbMatrikel.Items.Clear();
            cbSemester.Items.Clear();
            cbSemester.Enabled = false;
            DataTable dt = MySQLHelper.ExecuteQuery("SELECT CLASS_ID, CLASS_NAME FROM class");
            foreach (DataRow dr in dt.Rows)
            {
                int id = Int32.Parse(dr["CLASS_ID"].ToString());
                string name = dr["CLASS_NAME"].ToString();
                cbMatrikel.Items.Add(new TaggedItem(name, id));
            }
        }

        private void RefreshCalendar()
        {
            // alles raushauen
            pnlMain.Controls.Clear();
            // Tagbeschreibung und -zeiten einfügen
            Dictionary<DateTime, TimeSpan> units = InitWeekDayDescriptionControls();
            // berechnen, wie viele leere Tage eingefügt werden müssen, wenn nach erster Termin nach Montag ist
            DateTime date = DateTime.Parse(lblStartDate.Text);
            DateTime endDate = DateTime.Parse(lblEndDate.Text);
            int weeks = 0;
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
            for (int i = 0; i < daysToMonday; i++)
            {
                Panel pnlDummy = new Panel();
                pnlDummy.Width = DayWidth;
                pnlDummy.Height = DayHeight;
                pnlDummy.Margin = new Padding(0);
                pnlDummy.Padding = new Padding(0);
                pnlMain.Controls.Add(pnlDummy);
            }
            if (daysToMonday > 0)
            {
                weeks++;
            }
            // Tagcontrols einfügen
            do
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    CtrlDay ctrlDay = new CtrlDay(date, units, RefreshUsedSubjects);
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
            while (date <= endDate);
            // Breite anpassen
            pnlMain.ClientSize = new Size((weeks + 1) * DayWidth, DayHeight * 5);
        }

        private Dictionary<DateTime, TimeSpan> InitWeekDayDescriptionControls()
        {
            Dictionary<DateTime, TimeSpan> units = new Dictionary<DateTime, TimeSpan>();
            // Zeiteinheiten holen
            List<Timeunit> timeunits = new List<Timeunit>();
            DataTable dt = MySQLHelper.ExecuteQuery("SELECT TU_START, TU_DURATION FROM timeunits WHERE TU_TYP=1 ORDER BY TU_START");
            foreach (DataRow row in dt.Rows)
            {
                int start = Int32.Parse(row["TU_START"].ToString());
                int duration = Int32.Parse(row["TU_DURATION"].ToString());
                Timeunit tu = new Timeunit(start, duration);
                units.Add(tu.StartTime, tu.Duration);
                timeunits.Add(tu);
            }
            // für jeden Tag ein Control einfügen
            for (int i = 1; i < 6; i++)
            {
                string dayName = Properties.Resources.Culture.DateTimeFormat.DayNames[i];
                CtrlDayDescription ctrlDayDesc = new CtrlDayDescription(dayName, timeunits);
                ctrlDayDesc.Size = new Size(DayWidth, DayHeight);
                pnlMain.Controls.Add(ctrlDayDesc);
            }
            return units;
        }

        private void cbMatrikel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SuspendLayout();
            cbSemester.Items.Clear();
            TaggedItem item = (TaggedItem)cbMatrikel.SelectedItem;
            if (item == null)
            {
                cbSemester.Enabled = false;
            }
            else
            {
                int classId = Int32.Parse(item.Tag.ToString());
                DataTable dt = MySQLHelper.ExecuteQuery(string.Format("SELECT CLASS_PERIOD_ID, TERM_ID FROM class_period WHERE CLASS_ID={0} AND CLASS_PERIOD_TYP=0", classId));
                foreach(DataRow dr in dt.Rows)
                {
                    int periodId = Int32.Parse(dr["CLASS_PERIOD_ID"].ToString());
                    int semester = Int32.Parse(dr["TERM_ID"].ToString());
                    cbSemester.Items.Add(new TaggedItem(semester.ToString(), periodId));
                }
                cbSemester.Enabled = true;
            }
            ResumeLayout();
            Cursor = Cursors.Default;
        }

        private void cbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCalendar();
        }

        private void LoadCalendar()
        {
            Cursor = Cursors.WaitCursor;
            SuspendLayout();
            TaggedItem semesterItem = (TaggedItem)cbSemester.SelectedItem;
            TaggedItem matrikelItem = (TaggedItem)cbMatrikel.SelectedItem;
            if (semesterItem != null && matrikelItem != null)
            {
                int periodId = Int32.Parse(semesterItem.Tag.ToString());
                DataTable dt = MySQLHelper.ExecuteQuery(string.Format("SELECT CLASS_PERIOD_BEGIN, CLASS_PERIOD_END FROM class_period WHERE CLASS_PERIOD_ID={0}", periodId));
                if (dt.Rows.Count > 0)
                {
                    DateTime begin = DateTime.Parse(dt.Rows[0]["CLASS_PERIOD_BEGIN"].ToString());
                    DateTime end = DateTime.Parse(dt.Rows[0]["CLASS_PERIOD_END"].ToString());
                    lblStartDate.Text = string.Format("{0:d}", begin);
                    lblEndDate.Text = string.Format("{0:d}", end);
                    RefreshCalendar();
                    FillSubjectList(Int32.Parse(matrikelItem.Tag.ToString()), Int32.Parse(semesterItem.Tag.ToString()));
                    FillBooking(Int32.Parse(matrikelItem.Tag.ToString()), Int32.Parse(semesterItem.Tag.ToString()));
                }
            }
            ResumeLayout();
            Cursor = Cursors.Default;
        }

        private void FillSubjectList(int classId, int periodId)
        {
            // Curriculum-Übersicht-Liste füllen anhand gewählter Seminargruppe und Semester
            lvSubject.Items.Clear();
            DataTable dt = MySQLHelper.ExecuteQuery(string.Format("SELECT CUR_ID, CUR_CNT_SUB, CUR_COLOR, SUB_NAME, SUB_LONG_NAME, LEC_LNAME FROM curriculum INNER JOIN subject ON subject.SUB_ID=curriculum.SUB_ID INNER JOIN lecturer ON curriculum.lec_id=lecturer.LEC_ID WHERE CLASS_ID={0} AND CLASS_PERIOD_ID={1}", classId, periodId));
            foreach (DataRow dr in dt.Rows)
            {
                Color backgroundColor = SystemColors.Window;
                if (dr["CUR_COLOR"] != DBNull.Value && dr["CUR_COLOR"].ToString().Length == 6)
                {
                    string colorString = dr["CUR_COLOR"].ToString();
                    int r = Int32.Parse(colorString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                    int g = Int32.Parse(colorString.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    int b = Int32.Parse(colorString.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                    backgroundColor = Color.FromArgb(r,g,b);
                }
                ListViewItem lvi = new ListViewItem(dr["SUB_NAME"].ToString());
                lvi.SubItems.Add(dr["LEC_LNAME"].ToString());
                lvi.SubItems.Add(dr["CUR_CNT_SUB"].ToString());
                lvi.SubItems.Add("0");
                lvi.ToolTipText = dr["SUB_LONG_NAME"].ToString();
                lvi.Tag = Int32.Parse(dr["CUR_ID"].ToString());
                lvi.BackColor = backgroundColor;
                lvSubject.Items.Add(lvi);
            }
        }

        private void FillBooking(int classId, int periodId)
        {
            DataTable dtCurriculum = MySQLHelper.ExecuteQuery(string.Format("SELECT CUR_ID, CUR_COLOR, SUB_NAME, SUB_LONG_NAME FROM curriculum INNER JOIN subject ON subject.SUB_ID=curriculum.SUB_ID WHERE CLASS_ID={0} AND CLASS_PERIOD_ID={1}", classId, periodId));
            foreach (DataRow drCurriculum in dtCurriculum.Rows)
            {
                DataTable dt = MySQLHelper.ExecuteQuery(string.Format("SELECT ROOM_ID, BOOK_BEGIN, BOOK_END FROM booking WHERE CUR_ID={0}", drCurriculum["CUR_ID"]));
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem lvi = new ListViewItem(drCurriculum["SUB_NAME"].ToString());
                    lvi.Tag = Int32.Parse(drCurriculum["CUR_ID"].ToString());
                    lvi.ToolTipText = drCurriculum["SUB_LONG_NAME"].ToString();
                    Color backgroundColor = SystemColors.Window;
                    if (drCurriculum["CUR_COLOR"] != DBNull.Value && drCurriculum["CUR_COLOR"].ToString().Length == 6)
                    {
                        string colorString = drCurriculum["CUR_COLOR"].ToString();
                        int r = Int32.Parse(colorString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                        int g = Int32.Parse(colorString.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                        int b = Int32.Parse(colorString.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                        backgroundColor = Color.FromArgb(r,g,b);
                    }
                    lvi.BackColor = backgroundColor;
                    DateTime begin = DateTime.Parse(dr["BOOK_BEGIN"].ToString());
                    DateTime end = DateTime.Parse(dr["BOOK_END"].ToString());
                    TimeSpan duration = end.Subtract(begin);
                    foreach (Control ctrl in pnlMain.Controls)
                    {
                        CtrlDay ctrlDay = ctrl as CtrlDay;
                        if (ctrlDay != null)
                        {
                            if (ctrlDay.Date.Year == begin.Year && ctrlDay.Date.Month == begin.Month && ctrlDay.Date.Day == begin.Day)
                            {
                                ctrlDay.AddBooking(lvi, begin, duration);
                            }
                        }
                    }
                }
            }
        }

        private void lvSubject_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lvSubject.DoDragDrop(e.Item, DragDropEffects.Copy);
        }

        private void RefreshUsedSubjects()
        {
            Dictionary<int, int> usedSubjects = new Dictionary<int, int>();
            foreach (Control ctrl in pnlMain.Controls)
            {
                CtrlDay ctrlDay = ctrl as CtrlDay;
                if (ctrlDay != null)
                {
                    Dictionary<int, int> usedDaySubjects = ctrlDay.GetUsedSubjects();
                    foreach (int key in usedDaySubjects.Keys)
                    {
                        if (usedSubjects.ContainsKey(key))
                        {
                            usedSubjects[key] += usedDaySubjects[key];
                        }
                        else
                        {
                            usedSubjects.Add(key, usedDaySubjects[key]);
                        }
                    }
                }
            }
            foreach (ListViewItem lvi in lvSubject.Items)
            {
                if (lvi.Tag != null)
                {
                    int curId = Int32.Parse(lvi.Tag.ToString());
                    if (usedSubjects.ContainsKey(curId))
                    {
                        lvi.SubItems[3].Text = usedSubjects[curId].ToString();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadCalendar();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SuspendLayout();
            List<Booking> bookings = new List<Booking>();
            foreach (Control ctrl in pnlMain.Controls)
            {
                CtrlDay ctrlDay = ctrl as CtrlDay;
                if (ctrlDay != null)
                {
                    List<Booking> bookingsDay = ctrlDay.GetBookings();
                    bookings.AddRange(bookingsDay);
                }
            }
            TaggedItem semesterItem = (TaggedItem)cbSemester.SelectedItem;
            TaggedItem matrikelItem = (TaggedItem)cbMatrikel.SelectedItem;
            if (semesterItem != null && matrikelItem != null)
            {
                // alles löschen
                int classId = Int32.Parse(matrikelItem.Tag.ToString());
                int periodId = Int32.Parse(semesterItem.Tag.ToString());
                string query = string.Format("SELECT CUR_ID FROM curriculum WHERE CLASS_ID={0} AND CLASS_PERIOD_ID={1} AND MOD_GROUP_ID IS NULL", classId, periodId);
                DataTable dtCurriculum = MySQLHelper.ExecuteQuery(query);
                foreach (DataRow dr in dtCurriculum.Rows)
                {
                    query = string.Format("DELETE FROM booking WHERE CUR_ID={0}", Int32.Parse(dr["CUR_ID"].ToString()));
                    MySQLHelper.ExecuteQuery(query);
                }
                // Einträge einfügen
                foreach (Booking booking in bookings)
                {
                    // Standardraum suchen
                    DataTable dt = MySQLHelper.ExecuteQuery(string.Format("SELECT defaultrooms.ROOM_ID FROM curriculum INNER JOIN defaultrooms ON curriculum.CLASS_ID = defaultrooms.CLASS_ID WHERE curriculum.CUR_ID={0} ORDER BY defaultrooms.priority ASC", booking.CurId));
                    if (dt.Rows.Count > 0)
                    {
                        int roomId = Int32.Parse(dt.Rows[0]["ROOM_ID"].ToString());
                        string begin = booking.Begin.ToString("yyyy-MM-dd HH:mm:ss");
                        string end = booking.End.ToString("yyyy-MM-dd HH:mm:ss");
                        query = string.Format("INSERT INTO booking (CUR_ID, ROOM_ID, BOOK_BEGIN, BOOK_END, module_sub_id) VALUES ({0},{1},'{2}','{3}', 0);", booking.CurId, roomId, begin, end);
                        MySQLHelper.ExecuteQuery(query);
                    }
                }
            }
            ResumeLayout();
            Cursor = Cursors.Default;
            LoadCalendar();
        }
    }
}
