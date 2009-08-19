namespace Unisched.Controls
{
    partial class CtrlstandardRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlstandardRoom));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.cbRoom = new System.Windows.Forms.ComboBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvStdRooms = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cbMatrikel = new System.Windows.Forms.ComboBox();
            this.lblMatrikel = new System.Windows.Forms.Label();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStdRooms)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.AccessibleDescription = null;
            this.pnlRight.AccessibleName = null;
            resources.ApplyResources(this.pnlRight, "pnlRight");
            this.pnlRight.BackgroundImage = null;
            this.pnlRight.Controls.Add(this.lblPriority);
            this.pnlRight.Controls.Add(this.lblRoom);
            this.pnlRight.Controls.Add(this.cbPriority);
            this.pnlRight.Controls.Add(this.cbRoom);
            this.pnlRight.Controls.Add(this.btnDel);
            this.pnlRight.Controls.Add(this.btnNew);
            this.pnlRight.Controls.Add(this.btnSave);
            this.pnlRight.Font = null;
            this.pnlRight.Name = "pnlRight";
            // 
            // lblPriority
            // 
            this.lblPriority.AccessibleDescription = null;
            this.lblPriority.AccessibleName = null;
            resources.ApplyResources(this.lblPriority, "lblPriority");
            this.lblPriority.Font = null;
            this.lblPriority.Name = "lblPriority";
            // 
            // lblRoom
            // 
            this.lblRoom.AccessibleDescription = null;
            this.lblRoom.AccessibleName = null;
            resources.ApplyResources(this.lblRoom, "lblRoom");
            this.lblRoom.Font = null;
            this.lblRoom.Name = "lblRoom";
            // 
            // cbPriority
            // 
            this.cbPriority.AccessibleDescription = null;
            this.cbPriority.AccessibleName = null;
            resources.ApplyResources(this.cbPriority, "cbPriority");
            this.cbPriority.BackgroundImage = null;
            this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriority.Font = null;
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Name = "cbPriority";
            // 
            // cbRoom
            // 
            this.cbRoom.AccessibleDescription = null;
            this.cbRoom.AccessibleName = null;
            resources.ApplyResources(this.cbRoom, "cbRoom");
            this.cbRoom.BackgroundImage = null;
            this.cbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoom.Font = null;
            this.cbRoom.FormattingEnabled = true;
            this.cbRoom.Name = "cbRoom";
            // 
            // btnDel
            // 
            this.btnDel.AccessibleDescription = null;
            this.btnDel.AccessibleName = null;
            resources.ApplyResources(this.btnDel, "btnDel");
            this.btnDel.BackgroundImage = null;
            this.btnDel.Font = null;
            this.btnDel.Name = "btnDel";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnNew
            // 
            this.btnNew.AccessibleDescription = null;
            this.btnNew.AccessibleName = null;
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.BackgroundImage = null;
            this.btnNew.Font = null;
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = null;
            this.btnSave.AccessibleName = null;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackgroundImage = null;
            this.btnSave.Font = null;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvStdRooms
            // 
            this.dgvStdRooms.AccessibleDescription = null;
            this.dgvStdRooms.AccessibleName = null;
            this.dgvStdRooms.AllowUserToAddRows = false;
            this.dgvStdRooms.AllowUserToDeleteRows = false;
            this.dgvStdRooms.AllowUserToResizeColumns = false;
            this.dgvStdRooms.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgvStdRooms, "dgvStdRooms");
            this.dgvStdRooms.BackgroundImage = null;
            this.dgvStdRooms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStdRooms.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvStdRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStdRooms.Font = null;
            this.dgvStdRooms.MultiSelect = false;
            this.dgvStdRooms.Name = "dgvStdRooms";
            this.dgvStdRooms.ReadOnly = true;
            this.dgvStdRooms.RowHeadersVisible = false;
            this.dgvStdRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStdRooms.SelectionChanged += new System.EventHandler(this.dgvStdRooms_SelectionChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.cbMatrikel);
            this.pnlTop.Controls.Add(this.lblMatrikel);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // cbMatrikel
            // 
            this.cbMatrikel.AccessibleDescription = null;
            this.cbMatrikel.AccessibleName = null;
            resources.ApplyResources(this.cbMatrikel, "cbMatrikel");
            this.cbMatrikel.BackgroundImage = null;
            this.cbMatrikel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatrikel.Font = null;
            this.cbMatrikel.FormattingEnabled = true;
            this.cbMatrikel.Name = "cbMatrikel";
            this.cbMatrikel.SelectedIndexChanged += new System.EventHandler(this.cbMatrikel_SelectedIndexChanged);
            // 
            // lblMatrikel
            // 
            this.lblMatrikel.AccessibleDescription = null;
            this.lblMatrikel.AccessibleName = null;
            resources.ApplyResources(this.lblMatrikel, "lblMatrikel");
            this.lblMatrikel.Font = null;
            this.lblMatrikel.Name = "lblMatrikel";
            // 
            // CtrlstandardRoom
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.dgvStdRooms);
            this.Controls.Add(this.pnlTop);
            this.Font = null;
            this.Name = "CtrlstandardRoom";
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStdRooms)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvStdRooms;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ComboBox cbMatrikel;
        private System.Windows.Forms.Label lblMatrikel;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.ComboBox cbRoom;

    }
}
