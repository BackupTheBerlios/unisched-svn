namespace Unisched.Calendar
{
    partial class CtrlDay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlDay));
            this.lvDay = new System.Windows.Forms.ListView();
            this.colDay = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.einfügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ausCurriculumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.benutzerdefiniertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entfernenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvDay
            // 
            this.lvDay.AllowDrop = true;
            this.lvDay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDay});
            this.lvDay.ContextMenuStrip = this.contextMenuStrip;
            resources.ApplyResources(this.lvDay, "lvDay");
            this.lvDay.FullRowSelect = true;
            this.lvDay.GridLines = true;
            this.lvDay.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDay.HideSelection = false;
            this.lvDay.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvDay.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvDay.Items1"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvDay.Items2"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvDay.Items3"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvDay.Items4"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvDay.Items5")))});
            this.lvDay.MultiSelect = false;
            this.lvDay.Name = "lvDay";
            this.lvDay.Scrollable = false;
            this.lvDay.ShowGroups = false;
            this.lvDay.ShowItemToolTips = true;
            this.lvDay.UseCompatibleStateImageBehavior = false;
            this.lvDay.View = System.Windows.Forms.View.Details;
            this.lvDay.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvDay_DragEnter);
            this.lvDay.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvDay_DragDrop);
            this.lvDay.Resize += new System.EventHandler(this.lvDay_Resize);
            this.lvDay.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvDay_ItemDrag);
            // 
            // colDay
            // 
            resources.ApplyResources(this.colDay, "colDay");
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einfügenToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.entfernenToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // einfügenToolStripMenuItem
            // 
            this.einfügenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ausCurriculumToolStripMenuItem,
            this.benutzerdefiniertToolStripMenuItem});
            this.einfügenToolStripMenuItem.Name = "einfügenToolStripMenuItem";
            resources.ApplyResources(this.einfügenToolStripMenuItem, "einfügenToolStripMenuItem");
            // 
            // ausCurriculumToolStripMenuItem
            // 
            this.ausCurriculumToolStripMenuItem.Name = "ausCurriculumToolStripMenuItem";
            resources.ApplyResources(this.ausCurriculumToolStripMenuItem, "ausCurriculumToolStripMenuItem");
            // 
            // benutzerdefiniertToolStripMenuItem
            // 
            this.benutzerdefiniertToolStripMenuItem.Name = "benutzerdefiniertToolStripMenuItem";
            resources.ApplyResources(this.benutzerdefiniertToolStripMenuItem, "benutzerdefiniertToolStripMenuItem");
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            resources.ApplyResources(this.bearbeitenToolStripMenuItem, "bearbeitenToolStripMenuItem");
            // 
            // entfernenToolStripMenuItem
            // 
            this.entfernenToolStripMenuItem.Name = "entfernenToolStripMenuItem";
            resources.ApplyResources(this.entfernenToolStripMenuItem, "entfernenToolStripMenuItem");
            // 
            // CtrlDay
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvDay);
            this.Name = "CtrlDay";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDay;
        private System.Windows.Forms.ColumnHeader colDay;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem einfügenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ausCurriculumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem benutzerdefiniertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entfernenToolStripMenuItem;
    }
}
