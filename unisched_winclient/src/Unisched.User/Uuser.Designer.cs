namespace Unisched.User
{
    partial class Uuser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uuser));
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.pwTextBox = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.pwLabel = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userTextBox
            // 
            this.userTextBox.AccessibleDescription = null;
            this.userTextBox.AccessibleName = null;
            resources.ApplyResources(this.userTextBox, "userTextBox");
            this.userTextBox.BackgroundImage = null;
            this.userTextBox.Font = null;
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.TextChanged += new System.EventHandler(this.userTextBox_TextChanged);
            // 
            // pwTextBox
            // 
            this.pwTextBox.AccessibleDescription = null;
            this.pwTextBox.AccessibleName = null;
            resources.ApplyResources(this.pwTextBox, "pwTextBox");
            this.pwTextBox.BackgroundImage = null;
            this.pwTextBox.Font = null;
            this.pwTextBox.Name = "pwTextBox";
            this.pwTextBox.TextChanged += new System.EventHandler(this.pwTextBox_TextChanged);
            // 
            // userLabel
            // 
            this.userLabel.AccessibleDescription = null;
            this.userLabel.AccessibleName = null;
            resources.ApplyResources(this.userLabel, "userLabel");
            this.userLabel.Font = null;
            this.userLabel.Name = "userLabel";
            // 
            // pwLabel
            // 
            this.pwLabel.AccessibleDescription = null;
            this.pwLabel.AccessibleName = null;
            resources.ApplyResources(this.pwLabel, "pwLabel");
            this.pwLabel.Font = null;
            this.pwLabel.Name = "pwLabel";
            // 
            // okBtn
            // 
            this.okBtn.AccessibleDescription = null;
            this.okBtn.AccessibleName = null;
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.BackgroundImage = null;
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Font = null;
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleDescription = null;
            this.cancelBtn.AccessibleName = null;
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.BackgroundImage = null;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = null;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // Uuser
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.cancelBtn;
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.pwLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.pwTextBox);
            this.Controls.Add(this.userTextBox);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Uuser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void pwTextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (pwTextBox.TextLength > 0)
            {
                okBtn.Enabled = true;
            }
            else
                okBtn.Enabled = false;
        }

        void userTextBox_TextChanged(object sender, System.EventArgs e)
        {
                pwTextBox.Enabled = true;
        }

        #endregion

        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox pwTextBox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label pwLabel;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}

