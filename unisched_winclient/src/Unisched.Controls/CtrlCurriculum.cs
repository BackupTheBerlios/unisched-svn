using System;
using System.Data;
using System.Windows.Forms;
using Unisched.Controls.Curriculum;
using Unisched.Core.Common;
using Unisched.Core.Interfaces;
using Unisched.Data;

namespace Unisched.Controls
{
    public partial class CtrlCurriculum : UserControl, IDataUserControl
    {
        private int ClassId = -1;

        public CtrlCurriculum()
        {
            InitializeComponent();
            InitComboBox();
        }

        public void Initialize(bool admin)
        {
        }

        public Control GetControl()
        {
            return this;
        }

        private void InitComboBox()
        {
            cbMatrikel.Items.Clear();
            DataTable dt = MySQLHelper.ExecuteQuery("SELECT CLASS_ID, CLASS_NAME FROM class;");
            foreach (DataRow dr in dt.Rows)
            {
                int classId = Int32.Parse(dr["CLASS_ID"].ToString());
                string className = dr["CLASS_NAME"].ToString();
                cbMatrikel.Items.Add(new TaggedItem(className, classId));
            }
        }

        private void cbMatrikel_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaggedItem ti = cbMatrikel.SelectedItem as TaggedItem;
            if (ti != null)
            {
                pnlMain.Controls.Clear();
                ClassId = Int32.Parse(ti.Tag.ToString());
                DataTable dt = MySQLHelper.ExecuteQuery(string.Format("SELECT CLASS_PERIOD_ID FROM class_period WHERE CLASS_ID={0} ORDER BY CLASS_PERIOD_BEGIN ASC", ClassId));
                foreach (DataRow dr in dt.Rows)
                {
                    int periodId = Int32.Parse(dr["CLASS_PERIOD_ID"].ToString());
                    CtrlPeriod ctrlPeriod = new CtrlPeriod(ClassId, periodId);
                    ctrlPeriod.Width = pnlMain.ClientSize.Width;
                    ctrlPeriod.Dock = DockStyle.Top;
                    pnlMain.Controls.Add(ctrlPeriod);
                }
            }
            else
            {
                ClassId = -1;
            }
        }
    }
}
