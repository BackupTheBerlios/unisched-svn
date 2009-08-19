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

namespace Unisched
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblLoggedInAs = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.ctrlSideMenu = new Unisched.Controls.Common.CtrlSideMenu();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spracheWählenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deutschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englischToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.AccessibleDescription = null;
            this.toolStripContainer.AccessibleName = null;
            resources.ApplyResources(this.toolStripContainer, "toolStripContainer");
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.AccessibleDescription = null;
            this.toolStripContainer.BottomToolStripPanel.AccessibleName = null;
            this.toolStripContainer.BottomToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainer.BottomToolStripPanel, "toolStripContainer.BottomToolStripPanel");
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            this.toolStripContainer.BottomToolStripPanel.Font = null;
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.AccessibleDescription = null;
            this.toolStripContainer.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.toolStripContainer.ContentPanel, "toolStripContainer.ContentPanel");
            this.toolStripContainer.ContentPanel.BackgroundImage = null;
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer);
            this.toolStripContainer.ContentPanel.Font = null;
            this.toolStripContainer.Font = null;
            // 
            // toolStripContainer.LeftToolStripPanel
            // 
            this.toolStripContainer.LeftToolStripPanel.AccessibleDescription = null;
            this.toolStripContainer.LeftToolStripPanel.AccessibleName = null;
            this.toolStripContainer.LeftToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainer.LeftToolStripPanel, "toolStripContainer.LeftToolStripPanel");
            this.toolStripContainer.LeftToolStripPanel.Font = null;
            this.toolStripContainer.Name = "toolStripContainer";
            // 
            // toolStripContainer.RightToolStripPanel
            // 
            this.toolStripContainer.RightToolStripPanel.AccessibleDescription = null;
            this.toolStripContainer.RightToolStripPanel.AccessibleName = null;
            this.toolStripContainer.RightToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainer.RightToolStripPanel, "toolStripContainer.RightToolStripPanel");
            this.toolStripContainer.RightToolStripPanel.Font = null;
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.AccessibleDescription = null;
            this.toolStripContainer.TopToolStripPanel.AccessibleName = null;
            this.toolStripContainer.TopToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainer.TopToolStripPanel, "toolStripContainer.TopToolStripPanel");
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStripMain);
            this.toolStripContainer.TopToolStripPanel.Font = null;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleDescription = null;
            this.statusStrip1.AccessibleName = null;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackgroundImage = null;
            this.statusStrip1.Font = null;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblLoggedInAs,
            this.tslblUser});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // tslblLoggedInAs
            // 
            this.tslblLoggedInAs.AccessibleDescription = null;
            this.tslblLoggedInAs.AccessibleName = null;
            resources.ApplyResources(this.tslblLoggedInAs, "tslblLoggedInAs");
            this.tslblLoggedInAs.BackgroundImage = null;
            this.tslblLoggedInAs.Name = "tslblLoggedInAs";
            // 
            // tslblUser
            // 
            this.tslblUser.AccessibleDescription = null;
            this.tslblUser.AccessibleName = null;
            resources.ApplyResources(this.tslblUser, "tslblUser");
            this.tslblUser.BackgroundImage = null;
            this.tslblUser.Name = "tslblUser";
            // 
            // splitContainer
            // 
            this.splitContainer.AccessibleDescription = null;
            this.splitContainer.AccessibleName = null;
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.BackgroundImage = null;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Font = null;
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AccessibleDescription = null;
            this.splitContainer.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.splitContainer.Panel1.BackgroundImage = null;
            this.splitContainer.Panel1.Controls.Add(this.pnlSideBar);
            this.splitContainer.Panel1.Font = null;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AccessibleDescription = null;
            this.splitContainer.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.Panel2.BackgroundImage = null;
            this.splitContainer.Panel2.Controls.Add(this.pnlMainContent);
            this.splitContainer.Panel2.Font = null;
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.AccessibleDescription = null;
            this.pnlSideBar.AccessibleName = null;
            resources.ApplyResources(this.pnlSideBar, "pnlSideBar");
            this.pnlSideBar.BackgroundImage = null;
            this.pnlSideBar.Controls.Add(this.ctrlSideMenu);
            this.pnlSideBar.Controls.Add(this.pbLogo);
            this.pnlSideBar.Font = null;
            this.pnlSideBar.Name = "pnlSideBar";
            // 
            // ctrlSideMenu
            // 
            this.ctrlSideMenu.AccessibleDescription = null;
            this.ctrlSideMenu.AccessibleName = null;
            resources.ApplyResources(this.ctrlSideMenu, "ctrlSideMenu");
            this.ctrlSideMenu.BackgroundImage = null;
            this.ctrlSideMenu.Font = null;
            this.ctrlSideMenu.Name = "ctrlSideMenu";
            // 
            // pbLogo
            // 
            this.pbLogo.AccessibleDescription = null;
            this.pbLogo.AccessibleName = null;
            resources.ApplyResources(this.pbLogo, "pbLogo");
            this.pbLogo.BackgroundImage = null;
            this.pbLogo.Font = null;
            this.pbLogo.Image = global::Unisched.Properties.Resources.logo;
            this.pbLogo.ImageLocation = null;
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.TabStop = false;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.AccessibleDescription = null;
            this.pnlMainContent.AccessibleName = null;
            resources.ApplyResources(this.pnlMainContent, "pnlMainContent");
            this.pnlMainContent.BackgroundImage = null;
            this.pnlMainContent.Font = null;
            this.pnlMainContent.Name = "pnlMainContent";
            // 
            // menuStripMain
            // 
            this.menuStripMain.AccessibleDescription = null;
            this.menuStripMain.AccessibleName = null;
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.BackgroundImage = null;
            this.menuStripMain.Font = null;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.extrasToolStripMenuItem});
            this.menuStripMain.Name = "menuStripMain";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.AccessibleDescription = null;
            this.dateiToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.dateiToolStripMenuItem, "dateiToolStripMenuItem");
            this.dateiToolStripMenuItem.BackgroundImage = null;
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.AccessibleDescription = null;
            this.beendenToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.beendenToolStripMenuItem, "beendenToolStripMenuItem");
            this.beendenToolStripMenuItem.BackgroundImage = null;
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.AccessibleDescription = null;
            this.extrasToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.extrasToolStripMenuItem, "extrasToolStripMenuItem");
            this.extrasToolStripMenuItem.BackgroundImage = null;
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spracheWählenToolStripMenuItem,
            this.userAdminToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // spracheWählenToolStripMenuItem
            // 
            this.spracheWählenToolStripMenuItem.AccessibleDescription = null;
            this.spracheWählenToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.spracheWählenToolStripMenuItem, "spracheWählenToolStripMenuItem");
            this.spracheWählenToolStripMenuItem.BackgroundImage = null;
            this.spracheWählenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deutschToolStripMenuItem,
            this.englischToolStripMenuItem});
            this.spracheWählenToolStripMenuItem.Name = "spracheWählenToolStripMenuItem";
            this.spracheWählenToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // deutschToolStripMenuItem
            // 
            this.deutschToolStripMenuItem.AccessibleDescription = null;
            this.deutschToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.deutschToolStripMenuItem, "deutschToolStripMenuItem");
            this.deutschToolStripMenuItem.BackgroundImage = null;
            this.deutschToolStripMenuItem.Name = "deutschToolStripMenuItem";
            this.deutschToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.deutschToolStripMenuItem.Click += new System.EventHandler(this.deutschToolStripMenuItem_Click);
            // 
            // englischToolStripMenuItem
            // 
            this.englischToolStripMenuItem.AccessibleDescription = null;
            this.englischToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.englischToolStripMenuItem, "englischToolStripMenuItem");
            this.englischToolStripMenuItem.BackgroundImage = null;
            this.englischToolStripMenuItem.Name = "englischToolStripMenuItem";
            this.englischToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.englischToolStripMenuItem.Click += new System.EventHandler(this.englischToolStripMenuItem_Click);
            // 
            // userAdminToolStripMenuItem
            // 
            this.userAdminToolStripMenuItem.AccessibleDescription = null;
            this.userAdminToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.userAdminToolStripMenuItem, "userAdminToolStripMenuItem");
            this.userAdminToolStripMenuItem.BackgroundImage = null;
            this.userAdminToolStripMenuItem.Name = "userAdminToolStripMenuItem";
            this.userAdminToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.userAdminToolStripMenuItem.Click += new System.EventHandler(this.userAdminToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.toolStripContainer);
            this.Font = null;
            this.Icon = null;
            this.Name = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.pnlSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userAdminToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblLoggedInAs;
        private System.Windows.Forms.ToolStripStatusLabel tslblUser;
        private System.Windows.Forms.Panel pnlSideBar;
        private Unisched.Controls.Common.CtrlSideMenu ctrlSideMenu;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spracheWählenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deutschToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englischToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}

