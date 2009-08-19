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

namespace Unisched.Controls
{
    partial class CtrlSubject
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlSubject));
            this.panel1 = new System.Windows.Forms.Panel();
            this.newBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.roomTypGb = new System.Windows.Forms.GroupBox();
            this.subTyp1 = new System.Windows.Forms.RadioButton();
            this.subTyp2 = new System.Windows.Forms.RadioButton();
            this.addBtn = new System.Windows.Forms.Button();
            this.subDescTb = new System.Windows.Forms.TextBox();
            this.subShortDescTb = new System.Windows.Forms.TextBox();
            this.subjectDgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.roomTypGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.newBtn);
            this.panel1.Controls.Add(this.delBtn);
            this.panel1.Controls.Add(this.roomTypGb);
            this.panel1.Controls.Add(this.addBtn);
            this.panel1.Controls.Add(this.subDescTb);
            this.panel1.Controls.Add(this.subShortDescTb);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // newBtn
            // 
            resources.ApplyResources(this.newBtn, "newBtn");
            this.newBtn.Name = "newBtn";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // delBtn
            // 
            resources.ApplyResources(this.delBtn, "delBtn");
            this.delBtn.Name = "delBtn";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // roomTypGb
            // 
            this.roomTypGb.Controls.Add(this.subTyp1);
            this.roomTypGb.Controls.Add(this.subTyp2);
            resources.ApplyResources(this.roomTypGb, "roomTypGb");
            this.roomTypGb.Name = "roomTypGb";
            this.roomTypGb.TabStop = false;
            // 
            // subTyp1
            // 
            resources.ApplyResources(this.subTyp1, "subTyp1");
            this.subTyp1.Checked = true;
            this.subTyp1.Name = "subTyp1";
            this.subTyp1.TabStop = true;
            this.subTyp1.UseVisualStyleBackColor = true;
            // 
            // subTyp2
            // 
            resources.ApplyResources(this.subTyp2, "subTyp2");
            this.subTyp2.Name = "subTyp2";
            this.subTyp2.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            resources.ApplyResources(this.addBtn, "addBtn");
            this.addBtn.Name = "addBtn";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // subDescTb
            // 
            resources.ApplyResources(this.subDescTb, "subDescTb");
            this.subDescTb.Name = "subDescTb";
            this.subDescTb.TextChanged += new System.EventHandler(this.subDescTb_TextChanged);
            this.subDescTb.Enter += new System.EventHandler(this.subDescTb_Enter);
            // 
            // subShortDescTb
            // 
            resources.ApplyResources(this.subShortDescTb, "subShortDescTb");
            this.subShortDescTb.Name = "subShortDescTb";
            this.subShortDescTb.TextChanged += new System.EventHandler(this.subShortDescTb_TextChanged);
            this.subShortDescTb.Enter += new System.EventHandler(this.subShortDescTb_Enter);
            // 
            // subjectDgv
            // 
            this.subjectDgv.AllowUserToAddRows = false;
            this.subjectDgv.AllowUserToDeleteRows = false;
            this.subjectDgv.AllowUserToResizeColumns = false;
            this.subjectDgv.AllowUserToResizeRows = false;
            this.subjectDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.subjectDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.subjectDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.subjectDgv, "subjectDgv");
            this.subjectDgv.MultiSelect = false;
            this.subjectDgv.Name = "subjectDgv";
            this.subjectDgv.ReadOnly = true;
            this.subjectDgv.RowHeadersVisible = false;
            this.subjectDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subjectDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.subjectDgv_CellClick);
            this.subjectDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.subjectDgv_CellClick);
            // 
            // CtrlSubject
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.subjectDgv);
            this.Controls.Add(this.panel1);
            this.Name = "CtrlSubject";
            this.Load += new System.EventHandler(this.CtrlSubject_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roomTypGb.ResumeLayout(false);
            this.roomTypGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectDgv)).EndInit();
            this.ResumeLayout(false);

        }
        void subShortDescTb_TextChanged(object sender, System.EventArgs e)
        {
            this.subDescTb.Enabled = true;
        }

        void subDescTb_TextChanged(object sender, System.EventArgs e)
        {
            addBtn.Enabled = true;
        }

        void subShortDescTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
                this.subShortDescTb.Text = "";
        }

        void subDescTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
                subDescTb.Text = "";
        }


        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.GroupBox roomTypGb;
        private System.Windows.Forms.RadioButton subTyp1;
        private System.Windows.Forms.RadioButton subTyp2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox subDescTb;
        private System.Windows.Forms.TextBox subShortDescTb;
        private System.Windows.Forms.DataGridView subjectDgv;
    }
}
