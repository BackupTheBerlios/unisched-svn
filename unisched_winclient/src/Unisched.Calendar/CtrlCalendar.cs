using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unisched.Core;
using System.Drawing;
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
            pnlLeft.Visible = adminMode;
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
            InitWeekDayDescriptionControls();
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
                    CtrlDay ctrlDay = new CtrlDay(date);
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
                string dayName = Properties.Resources.Culture.DateTimeFormat.DayNames[i];
                CtrlDayDescription ctrlDayDesc = new CtrlDayDescription(dayName, timeunits);
                ctrlDayDesc.Size = new Size(DayWidth, DayHeight);
                pnlMain.Controls.Add(ctrlDayDesc);
            }
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
            DataTable dt = MySQLHelper.ExecuteQuery(string.Format("SELECT CUR_ID, CUR_CNT_SUB, SUB_NAME, SUB_LONG_NAME, LEC_LNAME FROM curriculum INNER JOIN subject ON subject.SUB_ID=curriculum.SUB_ID INNER JOIN lecturer ON curriculum.lec_id=lecturer.LEC_ID WHERE CLASS_ID={0} AND CLASS_PERIOD_ID={1}", classId, periodId));
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem lvi = new ListViewItem(dr["SUB_NAME"].ToString());
                lvi.SubItems.Add(dr["LEC_LNAME"].ToString());
                lvi.SubItems.Add(dr["CUR_CNT_SUB"].ToString());
                lvi.SubItems.Add("0");
                lvi.ToolTipText = dr["SUB_LONG_NAME"].ToString();
                lvi.Tag = Int32.Parse(dr["CUR_ID"].ToString());
                lvSubject.Items.Add(lvi);
            }
        }

        private void FillBooking(int classId, int periodId)
        {
            DataTable dtCurriculum = MySQLHelper.ExecuteQuery(string.Format("SELECT CUR_ID, SUB_NAME, SUB_LONG_NAME FROM curriculum INNER JOIN subject ON subject.SUB_ID=curriculum.SUB_ID WHERE CLASS_ID={0} AND CLASS_PERIOD_ID={1}", classId, periodId));
            foreach (DataRow drCurriculum in dtCurriculum.Rows)
            {
                DataTable dt = MySQLHelper.ExecuteQuery(string.Format("SELECT ROOM_ID, BOOK_BEGIN, BOOK_END FROM booking WHERE CUR_ID={0}", drCurriculum["CUR_ID"]));
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem lvi = new ListViewItem(drCurriculum["SUB_NAME"].ToString());
                    lvi.Tag = Int32.Parse(drCurriculum["CUR_ID"].ToString());
                    lvi.ToolTipText = drCurriculum["SUB_LONG_NAME"].ToString();

                    // TODO: anhand der Booking-Zeiten weiterverarbeiten
                }
            }
        }

        private void lvSubject_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lvSubject.DoDragDrop(e.Item, DragDropEffects.Copy);
        }
    }
}
