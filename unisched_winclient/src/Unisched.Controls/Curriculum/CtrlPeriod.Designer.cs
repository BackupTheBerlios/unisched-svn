namespace Unisched.Controls.Curriculum
{
    partial class CtrlPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlPeriod));
            this.gbSemester = new System.Windows.Forms.GroupBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewEntry = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblDozent = new System.Windows.Forms.Label();
            this.lblStunden = new System.Windows.Forms.Label();
            this.lblFach = new System.Windows.Forms.Label();
            this.gbSemester.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSemester
            // 
            this.gbSemester.AccessibleDescription = null;
            this.gbSemester.AccessibleName = null;
            resources.ApplyResources(this.gbSemester, "gbSemester");
            this.gbSemester.BackgroundImage = null;
            this.gbSemester.Controls.Add(this.pnlMain);
            this.gbSemester.Controls.Add(this.pnlBottom);
            this.gbSemester.Controls.Add(this.pnlHeader);
            this.gbSemester.Font = null;
            this.gbSemester.Name = "gbSemester";
            this.gbSemester.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.AccessibleDescription = null;
            this.pnlMain.AccessibleName = null;
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.BackgroundImage = null;
            this.pnlMain.Font = null;
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnNewEntry);
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
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
            // btnNewEntry
            // 
            this.btnNewEntry.AccessibleDescription = null;
            this.btnNewEntry.AccessibleName = null;
            resources.ApplyResources(this.btnNewEntry, "btnNewEntry");
            this.btnNewEntry.BackgroundImage = null;
            this.btnNewEntry.Font = null;
            this.btnNewEntry.Name = "btnNewEntry";
            this.btnNewEntry.UseVisualStyleBackColor = true;
            this.btnNewEntry.Click += new System.EventHandler(this.btnNewEntry_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AccessibleDescription = null;
            this.pnlHeader.AccessibleName = null;
            resources.ApplyResources(this.pnlHeader, "pnlHeader");
            this.pnlHeader.BackgroundImage = null;
            this.pnlHeader.Controls.Add(this.lblColor);
            this.pnlHeader.Controls.Add(this.lblDozent);
            this.pnlHeader.Controls.Add(this.lblStunden);
            this.pnlHeader.Controls.Add(this.lblFach);
            this.pnlHeader.Font = null;
            this.pnlHeader.Name = "pnlHeader";
            // 
            // lblColor
            // 
            this.lblColor.AccessibleDescription = null;
            this.lblColor.AccessibleName = null;
            resources.ApplyResources(this.lblColor, "lblColor");
            this.lblColor.Font = null;
            this.lblColor.Name = "lblColor";
            // 
            // lblDozent
            // 
            this.lblDozent.AccessibleDescription = null;
            this.lblDozent.AccessibleName = null;
            resources.ApplyResources(this.lblDozent, "lblDozent");
            this.lblDozent.Font = null;
            this.lblDozent.Name = "lblDozent";
            // 
            // lblStunden
            // 
            this.lblStunden.AccessibleDescription = null;
            this.lblStunden.AccessibleName = null;
            resources.ApplyResources(this.lblStunden, "lblStunden");
            this.lblStunden.Font = null;
            this.lblStunden.Name = "lblStunden";
            // 
            // lblFach
            // 
            this.lblFach.AccessibleDescription = null;
            this.lblFach.AccessibleName = null;
            resources.ApplyResources(this.lblFach, "lblFach");
            this.lblFach.Font = null;
            this.lblFach.Name = "lblFach";
            // 
            // CtrlPeriod
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.gbSemester);
            this.Font = null;
            this.Name = "CtrlPeriod";
            this.gbSemester.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSemester;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblDozent;
        private System.Windows.Forms.Label lblStunden;
        private System.Windows.Forms.Label lblFach;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnNewEntry;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblColor;
    }
}
