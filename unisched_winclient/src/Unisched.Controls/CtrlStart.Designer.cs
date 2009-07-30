namespace Unisched.Controls
{
    partial class CtrlStart
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
            this.lblStartText = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStartText
            // 
            this.lblStartText.AutoEllipsis = true;
            this.lblStartText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartText.Location = new System.Drawing.Point(0, 34);
            this.lblStartText.Name = "lblStartText";
            this.lblStartText.Size = new System.Drawing.Size(150, 116);
            this.lblStartText.TabIndex = 3;
            this.lblStartText.Text = "Willkommen im \"University Scheduling System\", einem Plaungswerkzeug für Stunden- " +
                "und Raumpläne für die Berufsakademie Leipzig. Es soll die Arbeitsabläufe in der " +
                "BA unterstützen und vereinfachen.";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblWelcome.Size = new System.Drawing.Size(119, 34);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Willkommen ";
            // 
            // CtrlStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStartText);
            this.Controls.Add(this.lblWelcome);
            this.Name = "CtrlStart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStartText;
        private System.Windows.Forms.Label lblWelcome;
    }
}
