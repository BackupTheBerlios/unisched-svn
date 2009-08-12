namespace Unisched.Controls
{
    partial class CtrlUserAdministration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlUserAdministration));
            this.ctrlUserDGV = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlUserDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlUserDGV
            // 
            this.ctrlUserDGV.AccessibleDescription = null;
            this.ctrlUserDGV.AccessibleName = null;
            resources.ApplyResources(this.ctrlUserDGV, "ctrlUserDGV");
            this.ctrlUserDGV.BackgroundImage = null;
            this.ctrlUserDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlUserDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.ctrlUserDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlUserDGV.Font = null;
            this.ctrlUserDGV.Name = "ctrlUserDGV";
            this.ctrlUserDGV.RowHeadersVisible = false;
            this.ctrlUserDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrlUserDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // addBtn
            // 
            this.addBtn.AccessibleDescription = null;
            this.addBtn.AccessibleName = null;
            resources.ApplyResources(this.addBtn, "addBtn");
            this.addBtn.BackgroundImage = null;
            this.addBtn.Font = null;
            this.addBtn.Name = "addBtn";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.AccessibleDescription = null;
            this.editBtn.AccessibleName = null;
            resources.ApplyResources(this.editBtn, "editBtn");
            this.editBtn.BackgroundImage = null;
            this.editBtn.Font = null;
            this.editBtn.Name = "editBtn";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.AccessibleDescription = null;
            this.deleteBtn.AccessibleName = null;
            resources.ApplyResources(this.deleteBtn, "deleteBtn");
            this.deleteBtn.BackgroundImage = null;
            this.deleteBtn.Font = null;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // CtrlUserAdministration
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.ctrlUserDGV);
            this.Font = null;
            this.Name = "CtrlUserAdministration";
            this.Load += new System.EventHandler(this.CtrlUserAdministration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlUserDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ctrlUserDGV;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
    }
}
