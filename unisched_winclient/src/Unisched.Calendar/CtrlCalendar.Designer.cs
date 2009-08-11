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
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cbMatrikel = new System.Windows.Forms.ComboBox();
            this.lblMatrikel = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grbAppointments = new System.Windows.Forms.GroupBox();
            this.lvSubject = new System.Windows.Forms.ListView();
            this.colAppointment = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.colUsed = new System.Windows.Forms.ColumnHeader();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.colLecturer = new System.Windows.Forms.ColumnHeader();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grbAppointments.SuspendLayout();
            this.pnlMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cbSemester);
            this.pnlTop.Controls.Add(this.lblSemester);
            this.pnlTop.Controls.Add(this.cbMatrikel);
            this.pnlTop.Controls.Add(this.lblMatrikel);
            this.pnlTop.Controls.Add(this.lblEndDate);
            this.pnlTop.Controls.Add(this.lblEnd);
            this.pnlTop.Controls.Add(this.lblStartDate);
            this.pnlTop.Controls.Add(this.lblStart);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // cbSemester
            // 
            this.cbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemester.FormattingEnabled = true;
            resources.ApplyResources(this.cbSemester, "cbSemester");
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.SelectedIndexChanged += new System.EventHandler(this.cbSemester_SelectedIndexChanged);
            // 
            // lblSemester
            // 
            resources.ApplyResources(this.lblSemester, "lblSemester");
            this.lblSemester.Name = "lblSemester";
            // 
            // cbMatrikel
            // 
            this.cbMatrikel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatrikel.FormattingEnabled = true;
            resources.ApplyResources(this.cbMatrikel, "cbMatrikel");
            this.cbMatrikel.Name = "cbMatrikel";
            this.cbMatrikel.SelectedIndexChanged += new System.EventHandler(this.cbMatrikel_SelectedIndexChanged);
            // 
            // lblMatrikel
            // 
            resources.ApplyResources(this.lblMatrikel, "lblMatrikel");
            this.lblMatrikel.Name = "lblMatrikel";
            // 
            // lblEnd
            // 
            resources.ApplyResources(this.lblEnd, "lblEnd");
            this.lblEnd.Name = "lblEnd";
            // 
            // lblStart
            // 
            resources.ApplyResources(this.lblStart, "lblStart");
            this.lblStart.Name = "lblStart";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grbAppointments);
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Name = "pnlLeft";
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
            // colAmount
            // 
            resources.ApplyResources(this.colAmount, "colAmount");
            // 
            // colUsed
            // 
            resources.ApplyResources(this.colUsed, "colUsed");
            // 
            // pnlMainContainer
            // 
            resources.ApplyResources(this.pnlMainContainer, "pnlMainContainer");
            this.pnlMainContainer.Controls.Add(this.pnlMain);
            this.pnlMainContainer.Name = "pnlMainContainer";
            // 
            // lblStartDate
            // 
            resources.ApplyResources(this.lblStartDate, "lblStartDate");
            this.lblStartDate.Name = "lblStartDate";
            // 
            // lblEndDate
            // 
            resources.ApplyResources(this.lblEndDate, "lblEndDate");
            this.lblEndDate.Name = "lblEndDate";
            // 
            // colLecturer
            // 
            resources.ApplyResources(this.colLecturer, "colLecturer");
            // 
            // CtrlCalendar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Name = "CtrlCalendar";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.grbAppointments.ResumeLayout(false);
            this.pnlMainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlLeft;
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
    }
}
