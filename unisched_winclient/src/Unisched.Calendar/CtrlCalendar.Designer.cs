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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grbAppointments = new System.Windows.Forms.GroupBox();
            this.lstSubject = new System.Windows.Forms.ListView();
            this.colAppointment = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.colUsed = new System.Windows.Forms.ColumnHeader();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
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
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.lblEnd);
            this.pnlTop.Controls.Add(this.lblStart);
            this.pnlTop.Controls.Add(this.dtpEnd);
            this.pnlTop.Controls.Add(this.dtpStart);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpEnd, "dtpEnd");
            this.dtpEnd.Name = "dtpEnd";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpStart, "dtpStart");
            this.dtpStart.Name = "dtpStart";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grbAppointments);
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Name = "pnlLeft";
            // 
            // grbAppointments
            // 
            this.grbAppointments.Controls.Add(this.lstSubject);
            resources.ApplyResources(this.grbAppointments, "grbAppointments");
            this.grbAppointments.Name = "grbAppointments";
            this.grbAppointments.TabStop = false;
            // 
            // lstSubject
            // 
            this.lstSubject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAppointment,
            this.colAmount,
            this.colUsed});
            resources.ApplyResources(this.lstSubject, "lstSubject");
            this.lstSubject.FullRowSelect = true;
            this.lstSubject.GridLines = true;
            this.lstSubject.Name = "lstSubject";
            this.lstSubject.UseCompatibleStateImageBehavior = false;
            this.lstSubject.View = System.Windows.Forms.View.Details;
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
        private System.Windows.Forms.ListView lstSubject;
        private System.Windows.Forms.ColumnHeader colAppointment;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colUsed;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Panel pnlMainContainer;
    }
}
