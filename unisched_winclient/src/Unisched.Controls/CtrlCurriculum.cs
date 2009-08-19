/*
 *   This file is part of Unisched Winclient.
 *
 *   Unisched Winclient is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   Unisched Winclient is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with Unisched Winclient.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Data;
using System.Windows.Forms;
using Unisched.Controls.Curriculum;
using Unisched.Core.Common;
using Unisched.Core.Interfaces;
using Unisched.Data;

namespace Unisched.Controls
{
    /// <summary>
    /// Control for accessing the curriculum master data.
    /// </summary>
    public partial class CtrlCurriculum : UserControl, IDataUserControl
    {
        private int ClassId = -1;

        /// <summary>
        /// Contructor, initializes the control.
        /// </summary>
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
