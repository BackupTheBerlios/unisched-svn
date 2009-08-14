namespace Unisched.Controls
{
    partial class CtrlCurriculum
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cbMatrikel = new System.Windows.Forms.ComboBox();
            this.lblMatrikel = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cbMatrikel);
            this.pnlTop.Controls.Add(this.lblMatrikel);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(659, 31);
            this.pnlTop.TabIndex = 3;
            // 
            // cbMatrikel
            // 
            this.cbMatrikel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatrikel.FormattingEnabled = true;
            this.cbMatrikel.Location = new System.Drawing.Point(55, 3);
            this.cbMatrikel.Name = "cbMatrikel";
            this.cbMatrikel.Size = new System.Drawing.Size(117, 21);
            this.cbMatrikel.TabIndex = 1;
            this.cbMatrikel.SelectedIndexChanged += new System.EventHandler(this.cbMatrikel_SelectedIndexChanged);
            // 
            // lblMatrikel
            // 
            this.lblMatrikel.AutoSize = true;
            this.lblMatrikel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMatrikel.Location = new System.Drawing.Point(2, 6);
            this.lblMatrikel.Name = "lblMatrikel";
            this.lblMatrikel.Size = new System.Drawing.Size(47, 13);
            this.lblMatrikel.TabIndex = 0;
            this.lblMatrikel.Text = "Matrikel:";
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 31);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(659, 438);
            this.pnlMain.TabIndex = 4;
            // 
            // CtrlCurriculum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "CtrlCurriculum";
            this.Size = new System.Drawing.Size(659, 469);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ComboBox cbMatrikel;
        private System.Windows.Forms.Label lblMatrikel;
        private System.Windows.Forms.Panel pnlMain;
    }
}
