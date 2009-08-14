namespace Unisched.Controls.Curriculum
{
    partial class CtrlCurEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlCurEntry));
            this.cbFach = new System.Windows.Forms.ComboBox();
            this.cbDozent = new System.Windows.Forms.ComboBox();
            this.nudStunden = new System.Windows.Forms.NumericUpDown();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudStunden)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFach
            // 
            this.cbFach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFach.FormattingEnabled = true;
            resources.ApplyResources(this.cbFach, "cbFach");
            this.cbFach.Name = "cbFach";
            // 
            // cbDozent
            // 
            this.cbDozent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDozent.FormattingEnabled = true;
            resources.ApplyResources(this.cbDozent, "cbDozent");
            this.cbDozent.Name = "cbDozent";
            // 
            // nudStunden
            // 
            resources.ApplyResources(this.nudStunden, "nudStunden");
            this.nudStunden.Name = "nudStunden";
            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.White;
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColor.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.pnlColor, "pnlColor");
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlColor_MouseClick);
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // CtrlCurEntry
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.nudStunden);
            this.Controls.Add(this.cbDozent);
            this.Controls.Add(this.cbFach);
            this.Name = "CtrlCurEntry";
            ((System.ComponentModel.ISupportInitialize)(this.nudStunden)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFach;
        private System.Windows.Forms.ComboBox cbDozent;
        private System.Windows.Forms.NumericUpDown nudStunden;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnDelete;
    }
}
