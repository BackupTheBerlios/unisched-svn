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
    partial class CtrlTutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlTutor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.newBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.telNrTb = new System.Windows.Forms.TextBox();
            this.tutorLnTb = new System.Windows.Forms.TextBox();
            this.tutorFnTb = new System.Windows.Forms.TextBox();
            this.tutorDgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutorDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.newBtn);
            this.panel1.Controls.Add(this.delBtn);
            this.panel1.Controls.Add(this.addBtn);
            this.panel1.Controls.Add(this.telNrTb);
            this.panel1.Controls.Add(this.tutorLnTb);
            this.panel1.Controls.Add(this.tutorFnTb);
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
            // addBtn
            // 
            resources.ApplyResources(this.addBtn, "addBtn");
            this.addBtn.Name = "addBtn";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // telNrTb
            // 
            resources.ApplyResources(this.telNrTb, "telNrTb");
            this.telNrTb.Name = "telNrTb";
            this.telNrTb.TextChanged += new System.EventHandler(this.telNrTb_TextChanged);
            this.telNrTb.Enter += new System.EventHandler(this.telNrTb_Enter);
            // 
            // tutorLnTb
            // 
            resources.ApplyResources(this.tutorLnTb, "tutorLnTb");
            this.tutorLnTb.Name = "tutorLnTb";
            this.tutorLnTb.TextChanged += new System.EventHandler(this.tutorLnTb_TextChanged);
            this.tutorLnTb.Enter += new System.EventHandler(this.tutorLnTb_Enter);
            // 
            // tutorFnTb
            // 
            resources.ApplyResources(this.tutorFnTb, "tutorFnTb");
            this.tutorFnTb.Name = "tutorFnTb";
            this.tutorFnTb.TextChanged += new System.EventHandler(this.tutorFnTb_TextChanged);
            this.tutorFnTb.Enter += new System.EventHandler(this.tutorFnTb_Enter);
            // 
            // tutorDgv
            // 
            this.tutorDgv.AllowUserToAddRows = false;
            this.tutorDgv.AllowUserToDeleteRows = false;
            this.tutorDgv.AllowUserToResizeColumns = false;
            this.tutorDgv.AllowUserToResizeRows = false;
            this.tutorDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tutorDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.tutorDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.tutorDgv, "tutorDgv");
            this.tutorDgv.MultiSelect = false;
            this.tutorDgv.Name = "tutorDgv";
            this.tutorDgv.ReadOnly = true;
            this.tutorDgv.RowHeadersVisible = false;
            this.tutorDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tutorDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tutorDgv_CellClick);
            this.tutorDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tutorDgv_CellClick);
            // 
            // CtrlTutor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tutorDgv);
            this.Controls.Add(this.panel1);
            this.Name = "CtrlTutor";
            this.Load += new System.EventHandler(this.CtrlTutor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutorDgv)).EndInit();
            this.ResumeLayout(false);

        }

        void tutorFnTb_TextChanged(object sender, System.EventArgs e)
        {
            tutorLnTb.Enabled = true;
        }

        void tutorLnTb_TextChanged(object sender, System.EventArgs e)
        {
            telNrTb.Enabled = true;
        }

        void telNrTb_TextChanged(object sender, System.EventArgs e)
        {
            addBtn.Enabled = true;
        }

        void tutorFnTb_Enter(object sender, System.EventArgs e)
        {
            if(!edit)
            this.tutorFnTb.Text = "";
        }

        void tutorLnTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
            tutorLnTb.Text = "";
        }

        void telNrTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
            telNrTb.Text = "";
        }



        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox telNrTb;
        private System.Windows.Forms.TextBox tutorLnTb;
        private System.Windows.Forms.TextBox tutorFnTb;
        private System.Windows.Forms.DataGridView tutorDgv;

    }
}
