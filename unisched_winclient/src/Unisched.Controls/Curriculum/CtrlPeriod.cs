using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Unisched.Data;

namespace Unisched.Controls.Curriculum
{
    /// <summary>
    /// Control that represents a period of a class and all their curriculum entries.
    /// </summary>
    public partial class CtrlPeriod : UserControl
    {
        private readonly int ClassId;
        private readonly int PeriodId;

        /// <summary>
        /// Constructor, initializes the control.
        /// </summary>
        /// <param name="classId">Id of the class to be used.</param>
        /// <param name="periodId">Id of the period.</param>
        public CtrlPeriod(int classId, int periodId)
        {
            InitializeComponent();
            ClassId = classId;
            PeriodId = periodId;
            Init();
        }

        private void Init()
        {
            SuspendLayout();
            pnlMain.Controls.Clear();
            string query = string.Format("SELECT * FROM class_period WHERE CLASS_PERIOD_ID={0}", PeriodId);
            DataTable dt = MySQLHelper.ExecuteQuery(query);
            if(dt.Rows.Count > 0)
            {
                int semester = Int32.Parse(dt.Rows[0]["TERM_ID"].ToString());
                DateTime begin = DateTime.Parse(dt.Rows[0]["CLASS_PERIOD_BEGIN"].ToString());
                DateTime end = DateTime.Parse(dt.Rows[0]["CLASS_PERIOD_END"].ToString());
                bool praxis = Int32.Parse(dt.Rows[0]["CLASS_PERIOD_TYP"].ToString()).Equals("1");
                string praxisString = praxis ? Properties.Resources.Praxisphase : Properties.Resources.Theoriephase;
                gbSemester.Text = string.Format("{0} {1}: {2} - {3} ({4})", Properties.Resources.Semester, semester, begin.ToShortDateString(), end.ToShortDateString(), praxisString);
            }
            query = string.Format("SELECT CUR_ID FROM curriculum WHERE CLASS_ID={0} AND CLASS_PERIOD_ID={1} AND MOD_GROUP_ID IS NULL", ClassId, PeriodId);
            dt = MySQLHelper.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                int curId = Int32.Parse(dr["CUR_ID"].ToString());
                CtrlCurEntry ctrlEntry = new CtrlCurEntry(curId, EntryRemoved);
                ctrlEntry.Dock = DockStyle.Top;
                ctrlEntry.Width = pnlMain.ClientSize.Width;
                pnlMain.Controls.Add(ctrlEntry);
                ctrlEntry.BringToFront();
            }
            ResizeControl();
            ResumeLayout();
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            CtrlCurEntry ctrlEntry = new CtrlCurEntry(ClassId, PeriodId, EntryRemoved);
            ctrlEntry.Dock = DockStyle.Top;
            ctrlEntry.Width = pnlMain.ClientSize.Width;
            pnlMain.Controls.Add(ctrlEntry);
            ctrlEntry.BringToFront();
            ResizeControl();
        }

        private void ResizeControl()
        {
            int entryHeight = 0;
            foreach (Control control in pnlMain.Controls)
            {
                entryHeight += control.Height;
            }
            int height = pnlHeader.Top + pnlHeader.Height + entryHeight + pnlBottom.Height + 15;
            ClientSize = new Size(450, height);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Control control in pnlMain.Controls)
            {
                CtrlCurEntry ctrlEntry = (CtrlCurEntry) control;
                ctrlEntry.Save();
            }
            Init();
        }

        private void EntryRemoved(Control entry)
        {
            pnlMain.Controls.Remove(entry);
            ResizeControl();
        }
    }
}
