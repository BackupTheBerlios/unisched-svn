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

﻿namespace Unisched.Controls
{
    partial class CtrlRoom
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlRoom));
            this.roomDgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.newBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.roomTypGb = new System.Windows.Forms.GroupBox();
            this.roomTyp2 = new System.Windows.Forms.RadioButton();
            this.roomTyp1 = new System.Windows.Forms.RadioButton();
            this.addBtn = new System.Windows.Forms.Button();
            this.roomCountTb = new System.Windows.Forms.TextBox();
            this.roomDescTb = new System.Windows.Forms.TextBox();
            this.roomNrTb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.roomDgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.roomTypGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomDgv
            // 
            this.roomDgv.AllowUserToAddRows = false;
            this.roomDgv.AllowUserToDeleteRows = false;
            this.roomDgv.AllowUserToResizeColumns = false;
            this.roomDgv.AllowUserToResizeRows = false;
            this.roomDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.roomDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.roomDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.roomDgv, "roomDgv");
            this.roomDgv.MultiSelect = false;
            this.roomDgv.Name = "roomDgv";
            this.roomDgv.ReadOnly = true;
            this.roomDgv.RowHeadersVisible = false;
            this.roomDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.roomDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.roomDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.newBtn);
            this.panel1.Controls.Add(this.delBtn);
            this.panel1.Controls.Add(this.roomTypGb);
            this.panel1.Controls.Add(this.addBtn);
            this.panel1.Controls.Add(this.roomCountTb);
            this.panel1.Controls.Add(this.roomDescTb);
            this.panel1.Controls.Add(this.roomNrTb);
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
            this.roomTypGb.Controls.Add(this.roomTyp2);
            this.roomTypGb.Controls.Add(this.roomTyp1);
            resources.ApplyResources(this.roomTypGb, "roomTypGb");
            this.roomTypGb.Name = "roomTypGb";
            this.roomTypGb.TabStop = false;
            // 
            // roomTyp2
            // 
            resources.ApplyResources(this.roomTyp2, "roomTyp2");
            this.roomTyp2.Checked = true;
            this.roomTyp2.Name = "roomTyp2";
            this.roomTyp2.TabStop = true;
            this.roomTyp2.UseVisualStyleBackColor = true;
            this.roomTyp2.CheckedChanged += new System.EventHandler(this.roomTyp2_CheckedChanged);
            // 
            // roomTyp1
            // 
            resources.ApplyResources(this.roomTyp1, "roomTyp1");
            this.roomTyp1.Name = "roomTyp1";
            this.roomTyp1.UseVisualStyleBackColor = true;
            this.roomTyp1.CheckedChanged += new System.EventHandler(this.roomTyp1_CheckedChanged);
            // 
            // addBtn
            // 
            resources.ApplyResources(this.addBtn, "addBtn");
            this.addBtn.Name = "addBtn";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // roomCountTb
            // 
            resources.ApplyResources(this.roomCountTb, "roomCountTb");
            this.roomCountTb.Name = "roomCountTb";
            this.roomCountTb.TextChanged += new System.EventHandler(this.roomCountTb_TextChanged);
            this.roomCountTb.Enter += new System.EventHandler(this.roomCountTb_Enter);
            // 
            // roomDescTb
            // 
            resources.ApplyResources(this.roomDescTb, "roomDescTb");
            this.roomDescTb.Name = "roomDescTb";
            this.roomDescTb.TextChanged += new System.EventHandler(this.roomDescTb_TextChanged);
            this.roomDescTb.Enter += new System.EventHandler(this.roomDescTb_Enter);
            // 
            // roomNrTb
            // 
            resources.ApplyResources(this.roomNrTb, "roomNrTb");
            this.roomNrTb.Name = "roomNrTb";
            this.roomNrTb.TextChanged += new System.EventHandler(this.roomNrTb_TextChanged);
            this.roomNrTb.Enter += new System.EventHandler(this.roomNrTb_Enter);
            // 
            // CtrlRoom
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roomDgv);
            this.Controls.Add(this.panel1);
            this.Name = "CtrlRoom";
            this.Load += new System.EventHandler(this.CtrlRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomDgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roomTypGb.ResumeLayout(false);
            this.roomTypGb.PerformLayout();
            this.ResumeLayout(false);

        }

        void roomNrTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
            roomNrTb.Text = "";
        }

        void roomDescTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
            roomDescTb.Text = "";
        }

        void roomCountTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
            roomCountTb.Text = "";
        }

        #endregion

        private System.Windows.Forms.DataGridView roomDgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox roomCountTb;
        private System.Windows.Forms.TextBox roomDescTb;
        private System.Windows.Forms.TextBox roomNrTb;
        private System.Windows.Forms.GroupBox roomTypGb;
        private System.Windows.Forms.RadioButton roomTyp2;
        private System.Windows.Forms.RadioButton roomTyp1;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button newBtn;
    }
}
