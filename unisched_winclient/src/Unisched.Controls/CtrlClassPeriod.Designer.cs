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
    partial class CtrlClassPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlClassPeriod));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cbMatrikel = new System.Windows.Forms.ComboBox();
            this.lblMatrikel = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvPeriods = new System.Windows.Forms.DataGridView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbArt = new System.Windows.Forms.GroupBox();
            this.rbTheorie = new System.Windows.Forms.RadioButton();
            this.rbPraxis = new System.Windows.Forms.RadioButton();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriods)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.gbArt.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.cbMatrikel);
            this.pnlTop.Controls.Add(this.lblMatrikel);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // cbMatrikel
            // 
            this.cbMatrikel.AccessibleDescription = null;
            this.cbMatrikel.AccessibleName = null;
            resources.ApplyResources(this.cbMatrikel, "cbMatrikel");
            this.cbMatrikel.BackgroundImage = null;
            this.cbMatrikel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatrikel.Font = null;
            this.cbMatrikel.FormattingEnabled = true;
            this.cbMatrikel.Name = "cbMatrikel";
            this.cbMatrikel.SelectedIndexChanged += new System.EventHandler(this.cbMatrikel_SelectedIndexChanged);
            // 
            // lblMatrikel
            // 
            this.lblMatrikel.AccessibleDescription = null;
            this.lblMatrikel.AccessibleName = null;
            resources.ApplyResources(this.lblMatrikel, "lblMatrikel");
            this.lblMatrikel.Font = null;
            this.lblMatrikel.Name = "lblMatrikel";
            // 
            // pnlMain
            // 
            this.pnlMain.AccessibleDescription = null;
            this.pnlMain.AccessibleName = null;
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.BackgroundImage = null;
            this.pnlMain.Controls.Add(this.dgvPeriods);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Font = null;
            this.pnlMain.Name = "pnlMain";
            // 
            // dgvPeriods
            // 
            this.dgvPeriods.AccessibleDescription = null;
            this.dgvPeriods.AccessibleName = null;
            this.dgvPeriods.AllowUserToAddRows = false;
            this.dgvPeriods.AllowUserToDeleteRows = false;
            this.dgvPeriods.AllowUserToResizeColumns = false;
            this.dgvPeriods.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgvPeriods, "dgvPeriods");
            this.dgvPeriods.BackgroundImage = null;
            this.dgvPeriods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPeriods.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvPeriods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriods.Font = null;
            this.dgvPeriods.MultiSelect = false;
            this.dgvPeriods.Name = "dgvPeriods";
            this.dgvPeriods.ReadOnly = true;
            this.dgvPeriods.RowHeadersVisible = false;
            this.dgvPeriods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeriods.SelectionChanged += new System.EventHandler(this.dgvPeriods_SelectionChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.AccessibleDescription = null;
            this.pnlRight.AccessibleName = null;
            resources.ApplyResources(this.pnlRight, "pnlRight");
            this.pnlRight.BackgroundImage = null;
            this.pnlRight.Controls.Add(this.btnDel);
            this.pnlRight.Controls.Add(this.btnNew);
            this.pnlRight.Controls.Add(this.btnSave);
            this.pnlRight.Controls.Add(this.gbArt);
            this.pnlRight.Controls.Add(this.dtpEnd);
            this.pnlRight.Controls.Add(this.dtpStart);
            this.pnlRight.Controls.Add(this.lblEnd);
            this.pnlRight.Controls.Add(this.lblStart);
            this.pnlRight.Controls.Add(this.lblSemester);
            this.pnlRight.Controls.Add(this.cbSemester);
            this.pnlRight.Font = null;
            this.pnlRight.Name = "pnlRight";
            // 
            // btnDel
            // 
            this.btnDel.AccessibleDescription = null;
            this.btnDel.AccessibleName = null;
            resources.ApplyResources(this.btnDel, "btnDel");
            this.btnDel.BackgroundImage = null;
            this.btnDel.Font = null;
            this.btnDel.Name = "btnDel";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnNew
            // 
            this.btnNew.AccessibleDescription = null;
            this.btnNew.AccessibleName = null;
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.BackgroundImage = null;
            this.btnNew.Font = null;
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = null;
            this.btnSave.AccessibleName = null;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackgroundImage = null;
            this.btnSave.Font = null;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbArt
            // 
            this.gbArt.AccessibleDescription = null;
            this.gbArt.AccessibleName = null;
            resources.ApplyResources(this.gbArt, "gbArt");
            this.gbArt.BackgroundImage = null;
            this.gbArt.Controls.Add(this.rbTheorie);
            this.gbArt.Controls.Add(this.rbPraxis);
            this.gbArt.Font = null;
            this.gbArt.Name = "gbArt";
            this.gbArt.TabStop = false;
            // 
            // rbTheorie
            // 
            this.rbTheorie.AccessibleDescription = null;
            this.rbTheorie.AccessibleName = null;
            resources.ApplyResources(this.rbTheorie, "rbTheorie");
            this.rbTheorie.BackgroundImage = null;
            this.rbTheorie.Checked = true;
            this.rbTheorie.Font = null;
            this.rbTheorie.Name = "rbTheorie";
            this.rbTheorie.TabStop = true;
            this.rbTheorie.UseVisualStyleBackColor = true;
            // 
            // rbPraxis
            // 
            this.rbPraxis.AccessibleDescription = null;
            this.rbPraxis.AccessibleName = null;
            resources.ApplyResources(this.rbPraxis, "rbPraxis");
            this.rbPraxis.BackgroundImage = null;
            this.rbPraxis.Font = null;
            this.rbPraxis.Name = "rbPraxis";
            this.rbPraxis.UseVisualStyleBackColor = true;
            // 
            // dtpEnd
            // 
            this.dtpEnd.AccessibleDescription = null;
            this.dtpEnd.AccessibleName = null;
            resources.ApplyResources(this.dtpEnd, "dtpEnd");
            this.dtpEnd.BackgroundImage = null;
            this.dtpEnd.CalendarFont = null;
            this.dtpEnd.CustomFormat = null;
            this.dtpEnd.Font = null;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Name = "dtpEnd";
            // 
            // dtpStart
            // 
            this.dtpStart.AccessibleDescription = null;
            this.dtpStart.AccessibleName = null;
            resources.ApplyResources(this.dtpStart, "dtpStart");
            this.dtpStart.BackgroundImage = null;
            this.dtpStart.CalendarFont = null;
            this.dtpStart.CustomFormat = null;
            this.dtpStart.Font = null;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Name = "dtpStart";
            // 
            // lblEnd
            // 
            this.lblEnd.AccessibleDescription = null;
            this.lblEnd.AccessibleName = null;
            resources.ApplyResources(this.lblEnd, "lblEnd");
            this.lblEnd.Font = null;
            this.lblEnd.Name = "lblEnd";
            // 
            // lblStart
            // 
            this.lblStart.AccessibleDescription = null;
            this.lblStart.AccessibleName = null;
            resources.ApplyResources(this.lblStart, "lblStart");
            this.lblStart.Font = null;
            this.lblStart.Name = "lblStart";
            // 
            // lblSemester
            // 
            this.lblSemester.AccessibleDescription = null;
            this.lblSemester.AccessibleName = null;
            resources.ApplyResources(this.lblSemester, "lblSemester");
            this.lblSemester.Font = null;
            this.lblSemester.Name = "lblSemester";
            // 
            // cbSemester
            // 
            this.cbSemester.AccessibleDescription = null;
            this.cbSemester.AccessibleName = null;
            resources.ApplyResources(this.cbSemester, "cbSemester");
            this.cbSemester.BackgroundImage = null;
            this.cbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemester.Font = null;
            this.cbSemester.FormattingEnabled = true;
            this.cbSemester.Items.AddRange(new object[] {
            resources.GetString("cbSemester.Items"),
            resources.GetString("cbSemester.Items1"),
            resources.GetString("cbSemester.Items2"),
            resources.GetString("cbSemester.Items3"),
            resources.GetString("cbSemester.Items4"),
            resources.GetString("cbSemester.Items5")});
            this.cbSemester.Name = "cbSemester";
            // 
            // CtrlClassPeriod
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Font = null;
            this.Name = "CtrlClassPeriod";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriods)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.gbArt.ResumeLayout(false);
            this.gbArt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ComboBox cbMatrikel;
        private System.Windows.Forms.Label lblMatrikel;
        private System.Windows.Forms.DataGridView dgvPeriods;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.GroupBox gbArt;
        private System.Windows.Forms.RadioButton rbTheorie;
        private System.Windows.Forms.RadioButton rbPraxis;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
    }
}
