using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Unisched.Core.Common;
using Unisched.Data;

namespace Unisched.Controls.Curriculum
{
    public partial class CtrlCurEntry : UserControl
    {
        private readonly int CurId;
        private readonly int ClassId;
        private readonly int PeriodId;
        public delegate void ControlRemovedDelegate(Control removedControl);
        private readonly ControlRemovedDelegate Removed;

        public CtrlCurEntry(int classId, int periodId, ControlRemovedDelegate removed)
        {
            InitializeComponent();
            Removed += removed;
            CurId = -1;
            ClassId = classId;
            PeriodId = periodId;
            InitCombos();
        }

        public CtrlCurEntry(int curId, ControlRemovedDelegate removed)
        {
            InitializeComponent();
            Removed += removed;
            CurId = curId;
            ClassId = -1;
            PeriodId = -1;
            InitCombos();
        }

        private void InitCombos()
        {
            DataTable dt = MySQLHelper.ExecuteQuery("SELECT SUB_ID, SUB_NAME FROM subject WHERE SUB_TYP < 2 ORDER BY SUB_NAME");
            foreach (DataRow dr in dt.Rows)
            {
                int id = Int32.Parse(dr["SUB_ID"].ToString());
                TaggedItem ti = new TaggedItem(dr["SUB_NAME"].ToString(), id);
                cbFach.Items.Add(ti);
            }
            dt = MySQLHelper.ExecuteQuery("SELECT LEC_ID, LEC_LNAME FROM lecturer ORDER BY LEC_LNAME");
            foreach (DataRow dr in dt.Rows)
            {
                int id = Int32.Parse(dr["LEC_ID"].ToString());
                TaggedItem ti = new TaggedItem(dr["LEC_LNAME"].ToString(), id);
                cbDozent.Items.Add(ti);
            }
            if(CurId != -1)
            {
                dt = MySQLHelper.ExecuteQuery(string.Format("SELECT SUB_ID, lec_id, CUR_CNT_SUB, CUR_COLOR FROM curriculum WHERE CUR_ID={0}", CurId));
                if(dt.Rows.Count > 0)
                {
                    int subId = Int32.Parse(dt.Rows[0]["SUB_ID"].ToString());
                    int lecId = Int32.Parse(dt.Rows[0]["lec_id"].ToString());
                    int subCount = Int32.Parse(dt.Rows[0]["CUR_CNT_SUB"].ToString());
                    Color curColor;
                    if(dt.Rows[0]["CUR_COLOR"] == DBNull.Value)
                    {
                        curColor = Color.White;
                    }
                    else
                    {
                        string colorString = dt.Rows[0]["CUR_COLOR"].ToString();
                        int r = Int32.Parse(colorString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                        int g = Int32.Parse(colorString.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                        int b = Int32.Parse(colorString.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                        curColor = Color.FromArgb(r, g, b);
                    }
                    pnlColor.BackColor = curColor;
                    foreach (object item in cbFach.Items)
                    {
                        if(GetIdFromComboItem(item) == subId)
                        {
                            cbFach.SelectedItem = item;
                            break;
                        }
                    }
                    foreach (object item in cbDozent.Items)
                    {
                        if (GetIdFromComboItem(item) == lecId)
                        {
                            cbDozent.SelectedItem = item;
                            break;
                        }
                    }
                    nudStunden.Value = subCount;
                }
            }
        }

        public void Save()
        {
            if(CurId == -1)
            {
                // neuer Eintrag
                if (cbFach.SelectedItem != null && cbDozent.SelectedItem != null)
                {
                    int subId = GetIdFromComboItem(cbFach.SelectedItem);
                    int lecId = GetIdFromComboItem(cbDozent.SelectedItem);
                    decimal subCount = nudStunden.Value;
                    string color = string.Format("{0:x2}{1:x2}{2:x2}", pnlColor.BackColor.R, pnlColor.BackColor.G, pnlColor.BackColor.B);
                    string query = string.Format("INSERT INTO curriculum (CLASS_PERIOD_ID, CLASS_ID, SUB_ID, CUR_CNT_SUB, lec_id, CUR_COLOR) VALUES ({0}, {1}, {2}, {3}, {4}, '{5}')", PeriodId, ClassId, subId, subCount, lecId, color);
                    MySQLHelper.ExecuteQuery(query);
                }
            }
            else
            {
                // aktualisierter Eintrag
                int subId = GetIdFromComboItem(cbFach.SelectedItem);
                int lecId = GetIdFromComboItem(cbDozent.SelectedItem);
                decimal subCount = nudStunden.Value;
                string color = string.Format("{0:x2}{1:x2}{2:x2}", pnlColor.BackColor.R, pnlColor.BackColor.G, pnlColor.BackColor.B);
                string query = string.Format("UPDATE curriculum SET SUB_ID={0}, CUR_CNT_SUB={1}, lec_id={2}, CUR_COLOR='{3}' WHERE CUR_ID={4}", subId, subCount, lecId, color, CurId);
                MySQLHelper.ExecuteQuery(query);

            }
        }

        private void pnlColor_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog.Color = pnlColor.BackColor;
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                pnlColor.BackColor = colorDialog.Color;
            }
        }

        private static int GetIdFromComboItem(object item)
        {
            TaggedItem ti = item as TaggedItem;
            if(ti == null)
            {
                return -1;
            }
            return Int32.Parse(ti.Tag.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(CurId != -1)
            {
                MySQLHelper.ExecuteQuery(string.Format("DELETE FROM curriculum WHERE CUR_ID={0}", CurId));
            }
            Removed(this);
        }
    }
}
