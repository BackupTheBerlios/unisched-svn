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
            this.adminCb.AutoSize = true;
            this.adminCb.Location = new System.Drawing.Point(15, 86);
            this.adminCb.Name = "adminCb";
            this.adminCb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.adminCb.Size = new System.Drawing.Size(61, 17);
            this.adminCb.TabIndex = 0;
            this.adminCb.Text = "?Admin";
            this.adminCb.UseVisualStyleBackColor = true;
            // 
            // userNamelbl
            // 
            this.userNamelbl.AutoSize = true;
            this.userNamelbl.Location = new System.Drawing.Point(12, 9);
            this.userNamelbl.Name = "userNamelbl";
            this.userNamelbl.Size = new System.Drawing.Size(78, 13);
            this.userNamelbl.TabIndex = 1;
            this.userNamelbl.Text = "Benutzername:";
            // 
            // pwlbl1
            // 
            this.pwlbl1.AutoSize = true;
            this.pwlbl1.Location = new System.Drawing.Point(12, 35);
            this.pwlbl1.Name = "pwlbl1";
            this.pwlbl1.Size = new System.Drawing.Size(53, 13);
            this.pwlbl1.TabIndex = 2;
            this.pwlbl1.Text = "Passwort:";
            // 
            // pwlbl2
            // 
            this.pwlbl2.AutoSize = true;
            this.pwlbl2.Location = new System.Drawing.Point(12, 61);
            this.pwlbl2.Name = "pwlbl2";
            this.pwlbl2.Size = new System.Drawing.Size(82, 13);
            this.pwlbl2.TabIndex = 3;
            this.pwlbl2.Text = "Wdh. Passwort:";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(15, 109);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(108, 109);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Abbrechen";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // userNametb
            // 
            this.userNametb.Location = new System.Drawing.Point(93, 6);
            this.userNametb.Name = "userNametb";
            this.userNametb.Size = new System.Drawing.Size(100, 20);
            this.userNametb.TabIndex = 6;
            // 
            // pwTb1
            // 
            this.pwTb1.Location = new System.Drawing.Point(93, 32);
            this.pwTb1.Name = "pwTb1";
            this.pwTb1.PasswordChar = '*';
            this.pwTb1.Size = new System.Drawing.Size(100, 20);
            this.pwTb1.TabIndex = 7;
            // 
            // pwTb2
            // 
            this.pwTb2.Location = new System.Drawing.Point(93, 58);
            this.pwTb2.Name = "pwTb2";
            this.pwTb2.PasswordChar = '*';
            this.pwTb2.Size = new System.Drawing.Size(100, 20);
            this.pwTb2.TabIndex = 8;
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 144);
            this.Controls.Add(this.pwTb2);
            this.Controls.Add(this.pwTb1);
            this.Controls.Add(this.userNametb);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.pwlbl2);
            this.Controls.Add(this.pwlbl1);
            this.Controls.Add(this.userNamelbl);
            this.Controls.Add(this.adminCb);
            this.Name = "NewUser";
            this.Text = "Neuer Benutzer";
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