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
    partial class CtrlFieldStudy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlFieldStudy));
            this.fieldStudyDgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.fieldStudyTb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fieldStudyDgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldStudyDgv
            // 
            this.fieldStudyDgv.AllowUserToAddRows = false;
            this.fieldStudyDgv.AllowUserToDeleteRows = false;
            this.fieldStudyDgv.AllowUserToResizeColumns = false;
            this.fieldStudyDgv.AllowUserToResizeRows = false;
            this.fieldStudyDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.fieldStudyDgv, "fieldStudyDgv");
            this.fieldStudyDgv.Name = "fieldStudyDgv";
            this.fieldStudyDgv.ReadOnly = true;
            this.fieldStudyDgv.RowHeadersVisible = false;
            this.fieldStudyDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fieldStudyDgv_CellClick);
            this.fieldStudyDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fieldStudyDgv_CellClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.delBtn);
            this.panel1.Controls.Add(this.addBtn);
            this.panel1.Controls.Add(this.newBtn);
            this.panel1.Controls.Add(this.fieldStudyTb);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // delBtn
            // 
            resources.ApplyResources(this.delBtn, "delBtn");
            this.delBtn.Name = "delBtn";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addBtn
            // 
            resources.ApplyResources(this.addBtn, "addBtn");
            this.addBtn.Name = "addBtn";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // newBtn
            // 
            resources.ApplyResources(this.newBtn, "newBtn");
            this.newBtn.Name = "newBtn";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // fieldStudyTb
            // 
            resources.ApplyResources(this.fieldStudyTb, "fieldStudyTb");
            this.fieldStudyTb.Name = "fieldStudyTb";
            this.fieldStudyTb.TextChanged += new System.EventHandler(this.fieldStudyTb_TextChanged);
            this.fieldStudyTb.Enter += new System.EventHandler(this.fieldStudyTb_Enter);
            // 
            // CtrlFieldStudy
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fieldStudyDgv);
            this.Controls.Add(this.panel1);
            this.Name = "CtrlFieldStudy";
            this.Load += new System.EventHandler(this.CtrlFieldStudy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fieldStudyDgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        void fieldStudyTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
                fieldStudyTb.Text = "";
        }

        #endregion

        private System.Windows.Forms.DataGridView fieldStudyDgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.TextBox fieldStudyTb;
    }
}
