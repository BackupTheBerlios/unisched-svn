/*
 *   This file is part of Unisched Winclient.
 *
 *   Unisched Winclient is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   Unisched Winclient is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with Unisched Winclient.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace Unisched.User
{
    partial class EditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditUser));
            this.pwTb2 = new System.Windows.Forms.TextBox();
            this.pwTb1 = new System.Windows.Forms.TextBox();
            this.userNametb = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.pwlbl2 = new System.Windows.Forms.Label();
            this.pwlbl1 = new System.Windows.Forms.Label();
            this.userNamelbl = new System.Windows.Forms.Label();
            this.adminCb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
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
            // pwTb1
            // 
            this.pwTb1.AccessibleDescription = null;
            this.pwTb1.AccessibleName = null;
            resources.ApplyResources(this.pwTb1, "pwTb1");
            this.pwTb1.BackgroundImage = null;
            this.pwTb1.Font = null;
            this.pwTb1.Name = "pwTb1";
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
            // pwlbl2
            // 
            this.pwlbl2.AccessibleDescription = null;
            this.pwlbl2.AccessibleName = null;
            resources.ApplyResources(this.pwlbl2, "pwlbl2");
            this.pwlbl2.Font = null;
            this.pwlbl2.Name = "pwlbl2";
            // 
            // pwlbl1
            // 
            this.pwlbl1.AccessibleDescription = null;
            this.pwlbl1.AccessibleName = null;
            resources.ApplyResources(this.pwlbl1, "pwlbl1");
            this.pwlbl1.Font = null;
            this.pwlbl1.Name = "pwlbl1";
            this.pwlbl1.Click += new System.EventHandler(this.pwlbl1_Click);
            // 
            // userNamelbl
            // 
            this.userNamelbl.AccessibleDescription = null;
            this.userNamelbl.AccessibleName = null;
            resources.ApplyResources(this.userNamelbl, "userNamelbl");
            this.userNamelbl.Font = null;
            this.userNamelbl.Name = "userNamelbl";
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
            // EditUser
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
            this.Name = "EditUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pwTb2;
        private System.Windows.Forms.TextBox pwTb1;
        private System.Windows.Forms.TextBox userNametb;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label pwlbl2;
        private System.Windows.Forms.Label pwlbl1;
        private System.Windows.Forms.Label userNamelbl;
        private System.Windows.Forms.CheckBox adminCb;
    }
}
