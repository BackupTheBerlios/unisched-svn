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
namespace Unisched.Calendar
{
    partial class CtrlCalendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlCalendar));
            this.pnlMain = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grbAppointments = new System.Windows.Forms.GroupBox();
            this.lvSubject = new System.Windows.Forms.ListView();
            this.colAppointment = new System.Windows.Forms.ColumnHeader();
            this.colLecturer = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.colUsed = new System.Windows.Forms.ColumnHeader();
            this.grbOptions = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbSelection = new System.Windows.Forms.GroupBox();
            this.lblMatrikel = new System.Windows.Forms.Label();
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.cbMatrikel = new System.Windows.Forms.ComboBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.grbSchedule = new System.Windows.Forms.GroupBox();
            this.pnlTop.SuspendLayout();
            this.grbAppointments.SuspendLayout();
            this.grbOptions.SuspendLayout();
            this.grbSelection.SuspendLayout();
            this.pnlMainContainer.SuspendLayout();
            this.grbSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grbAppointments);
            this.pnlTop.Controls.Add(this.grbOptions);
            this.pnlTop.Controls.Add(this.grbSelection);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // grbAppointments
            // 
            this.grbAppointments.Controls.Add(this.lvSubject);
            resources.ApplyResources(this.grbAppointments, "grbAppointments");
            this.grbAppointments.Name = "grbAppointments";
            this.grbAppointments.TabStop = false;
            // 
            // lvSubject
            // 
            this.lvSubject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAppointment,
            this.colLecturer,
            this.colAmount,
            this.colUsed});
            resources.ApplyResources(this.lvSubject, "lvSubject");
            this.lvSubject.FullRowSelect = true;
            this.lvSubject.GridLines = true;
            this.lvSubject.MultiSelect = false;
            this.lvSubject.Name = "lvSubject";
            this.lvSubject.ShowItemToolTips = true;
            this.lvSubject.UseCompatibleStateImageBehavior = false;
            this.lvSubject.View = System.Windows.Forms.View.Details;
            this.lvSubject.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvSubject_ItemDrag);
            // 
            // colAppointment
            // 
            resources.ApplyResources(this.colAppointment, "colAppointment");
            // 
            // colLecturer
            // 
            resources.ApplyResources(this.colLecturer, "colLecturer");
            // 
            // colAmount
            // 
            resources.ApplyResources(this.colAmount, "colAmount");
            // 
            // colUsed
            // 
            resources.ApplyResources(this.colUsed, "colUsed");
            // 
            // grbOptions
            // 
            this.grbOptions.Controls.Add(this.btnSave);
            this.grbOptions.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.grbOptions, "grbOptions");
            this.grbOptions.Name = "grbOptions";
            this.grbOptions.TabStop = false;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grbSelection
            // 
            this.grbSelection.Controls.Add(this.lblMatrikel);
            this.grbSelection.Controls.Add(this.cbSemester);
            this.grbSelection.Controls.Add(this.lblStart);
            this.grbSelection.Controls.Add(this.lblSemester);
            this.grbSelection.Controls.Add(this.lblStartDate);
            this.grbSelection.Controls.Add(this.cbMatrikel);
            this.grbSelection.Controls.Add(this.lblEnd);
            this.grbSelection.Controls.Add(this.lblEndDate);
            resources.ApplyResources(this.grbSelection, "grbSelection");
            this.grbSelection.Name = "grbSelection";
            this.grbSelection.TabStop = false;
            // 
            // lblMatrikel
            // 
            resources.ApplyResources(this.lblMatrikel, "lblMatrikel");
            this.lblMatrikel.Name = "lblMatrikel";
            // 
            // cbSemester
            // 
            this.cbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemester.FormattingEnabled = true;
            resources.ApplyResources(this.cbSemester, "cbSemester");
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.SelectedIndexChanged += new System.EventHandler(this.cbSemester_SelectedIndexChanged);
            // 
            // lblStart
            // 
            resources.ApplyResources(this.lblStart, "lblStart");
            this.lblStart.Name = "lblStart";
            // 
            // lblSemester
            // 
            resources.ApplyResources(this.lblSemester, "lblSemester");
            this.lblSemester.Name = "lblSemester";
            // 
            // lblStartDate
            // 
            resources.ApplyResources(this.lblStartDate, "lblStartDate");
            this.lblStartDate.Name = "lblStartDate";
            // 
            // cbMatrikel
            // 
            this.cbMatrikel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatrikel.FormattingEnabled = true;
            resources.ApplyResources(this.cbMatrikel, "cbMatrikel");
            this.cbMatrikel.Name = "cbMatrikel";
            this.cbMatrikel.SelectedIndexChanged += new System.EventHandler(this.cbMatrikel_SelectedIndexChanged);
            // 
            // lblEnd
            // 
            resources.ApplyResources(this.lblEnd, "lblEnd");
            this.lblEnd.Name = "lblEnd";
            // 
            // lblEndDate
            // 
            resources.ApplyResources(this.lblEndDate, "lblEndDate");
            this.lblEndDate.Name = "lblEndDate";
            // 
            // pnlMainContainer
            // 
            resources.ApplyResources(this.pnlMainContainer, "pnlMainContainer");
            this.pnlMainContainer.Controls.Add(this.pnlMain);
            this.pnlMainContainer.Name = "pnlMainContainer";
            // 
            // grbSchedule
            // 
            this.grbSchedule.Controls.Add(this.pnlMainContainer);
            resources.ApplyResources(this.grbSchedule, "grbSchedule");
            this.grbSchedule.Name = "grbSchedule";
            this.grbSchedule.TabStop = false;
            // 
            // CtrlCalendar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbSchedule);
            this.Controls.Add(this.pnlTop);
            this.Name = "CtrlCalendar";
            this.pnlTop.ResumeLayout(false);
            this.grbAppointments.ResumeLayout(false);
            this.grbOptions.ResumeLayout(false);
            this.grbSelection.ResumeLayout(false);
            this.grbSelection.PerformLayout();
            this.pnlMainContainer.ResumeLayout(false);
            this.grbSchedule.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.GroupBox grbAppointments;
        private System.Windows.Forms.ListView lvSubject;
        private System.Windows.Forms.ColumnHeader colAppointment;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colUsed;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cbMatrikel;
        private System.Windows.Forms.Label lblMatrikel;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.ColumnHeader colLecturer;
        private System.Windows.Forms.GroupBox grbSelection;
        private System.Windows.Forms.GroupBox grbOptions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grbSchedule;
    }
}
