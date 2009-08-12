namespace Unisched.User
{
    partial class NewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUser));
            this.adminCb = new System.Windows.Forms.CheckBox();
            this.userNamelbl = new System.Windows.Forms.Label();
            this.pwlbl1 = new System.Windows.Forms.Label();
            this.pwlbl2 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.userNametb = new System.Windows.Forms.TextBox();
            this.pwTb1 = new System.Windows.Forms.TextBox();
            this.pwTb2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // adminCb
            // 
            this.adminCb.AccessibleDescription = null;
            this.adminCb.AccessibleName = null;
            resources.ApplyResources(this.adminCb, "adminCb");
            this.adminCb.BackgroundImage = null;
            this.adminCb.Font = null;
            this.adminCb.Name = "adminCb";
            this.adminCb.UseVisualStyleBackColor = true;
            // 
            // userNamelbl
            // 
            this.userNamelbl.AccessibleDescription = null;
            this.userNamelbl.AccessibleName = null;
            resources.ApplyResources(this.userNamelbl, "userNamelbl");
            this.userNamelbl.Font = null;
            this.userNamelbl.Name = "userNamelbl";
            // 
            // pwlbl1
            // 
            this.pwlbl1.AccessibleDescription = null;
            this.pwlbl1.AccessibleName = null;
            resources.ApplyResources(this.pwlbl1, "pwlbl1");
            this.pwlbl1.Font = null;
            this.pwlbl1.Name = "pwlbl1";
            // 
            // pwlbl2
            // 
            this.pwlbl2.AccessibleDescription = null;
            this.pwlbl2.AccessibleName = null;
            resources.ApplyResources(this.pwlbl2, "pwlbl2");
            this.pwlbl2.Font = null;
            this.pwlbl2.Name = "pwlbl2";
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
            // userNametb
            // 
            this.userNametb.AccessibleDescription = null;
            this.userNametb.AccessibleName = null;
            resources.ApplyResources(this.userNametb, "userNametb");
            this.userNametb.BackgroundImage = null;
            this.userNametb.Font = null;
            this.userNametb.Name = "userNametb";
            // 
            // pwTb1
            // 
            this.pwTb1.AccessibleDescription = null;
            this.pwTb1.AccessibleName = null;
            resources.ApplyResources(this.pwTb1, "pwTb1");
            this.pwTb1.BackgroundImage = null;
            this.pwTb1.Font = null;
            this.pwTb1.Name = "pwTb1";
            // 
            // pwTb2
            // 
            this.pwTb2.AccessibleDescription = null;
            this.pwTb2.AccessibleName = null;
            resources.ApplyResources(this.pwTb2, "pwTb2");
            this.pwTb2.BackgroundImage = null;
            this.pwTb2.Font = null;
            this.pwTb2.Name = "pwTb2";
            // 
            // NewUser
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pwTb2);
            this.Controls.Add(this.pwTb1);
            this.Controls.Add(this.userNametb);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.pwlbl2);
            this.Controls.Add(this.pwlbl1);
            this.Controls.Add(this.userNamelbl);
            this.Controls.Add(this.adminCb);
            this.Font = null;
            this.Icon = null;
            this.Name = "NewUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox adminCb;
        private System.Windows.Forms.Label userNamelbl;
        private System.Windows.Forms.Label pwlbl1;
        private System.Windows.Forms.Label pwlbl2;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox userNametb;
        private System.Windows.Forms.TextBox pwTb1;
        private System.Windows.Forms.TextBox pwTb2;
    }
}