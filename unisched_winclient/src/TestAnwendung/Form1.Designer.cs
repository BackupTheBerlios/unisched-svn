namespace TestAnwendung
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlCalendar1 = new Unisched.Calendar.CtrlCalendar();
            this.SuspendLayout();
            // 
            // ctrlCalendar1
            // 
            this.ctrlCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCalendar1.Location = new System.Drawing.Point(0, 0);
            this.ctrlCalendar1.Name = "ctrlCalendar1";
            this.ctrlCalendar1.Size = new System.Drawing.Size(889, 730);
            this.ctrlCalendar1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 730);
            this.Controls.Add(this.ctrlCalendar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Unisched.Calendar.CtrlCalendar ctrlCalendar1;

    }
}

