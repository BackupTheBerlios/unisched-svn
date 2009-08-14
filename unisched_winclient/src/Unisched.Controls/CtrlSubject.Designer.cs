namespace Unisched.Controls
{
    partial class CtrlSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlSubject));
            this.panel1 = new System.Windows.Forms.Panel();
            this.newBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.roomTypGb = new System.Windows.Forms.GroupBox();
            this.subTyp1 = new System.Windows.Forms.RadioButton();
            this.subTyp2 = new System.Windows.Forms.RadioButton();
            this.addBtn = new System.Windows.Forms.Button();
            this.subDescTb = new System.Windows.Forms.TextBox();
            this.subShortDescTb = new System.Windows.Forms.TextBox();
            this.subjectDgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.roomTypGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.newBtn);
            this.panel1.Controls.Add(this.delBtn);
            this.panel1.Controls.Add(this.roomTypGb);
            this.panel1.Controls.Add(this.addBtn);
            this.panel1.Controls.Add(this.subDescTb);
            this.panel1.Controls.Add(this.subShortDescTb);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // newBtn
            // 
            this.newBtn.AccessibleDescription = null;
            this.newBtn.AccessibleName = null;
            resources.ApplyResources(this.newBtn, "newBtn");
            this.newBtn.BackgroundImage = null;
            this.newBtn.Font = null;
            this.newBtn.Name = "newBtn";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.AccessibleDescription = null;
            this.delBtn.AccessibleName = null;
            resources.ApplyResources(this.delBtn, "delBtn");
            this.delBtn.BackgroundImage = null;
            this.delBtn.Font = null;
            this.delBtn.Name = "delBtn";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // roomTypGb
            // 
            this.roomTypGb.AccessibleDescription = null;
            this.roomTypGb.AccessibleName = null;
            resources.ApplyResources(this.roomTypGb, "roomTypGb");
            this.roomTypGb.BackgroundImage = null;
            this.roomTypGb.Controls.Add(this.subTyp1);
            this.roomTypGb.Controls.Add(this.subTyp2);
            this.roomTypGb.Font = null;
            this.roomTypGb.Name = "roomTypGb";
            this.roomTypGb.TabStop = false;
            // 
            // subTyp1
            // 
            this.subTyp1.AccessibleDescription = null;
            this.subTyp1.AccessibleName = null;
            resources.ApplyResources(this.subTyp1, "subTyp1");
            this.subTyp1.BackgroundImage = null;
            this.subTyp1.Checked = true;
            this.subTyp1.Font = null;
            this.subTyp1.Name = "subTyp1";
            this.subTyp1.TabStop = true;
            this.subTyp1.UseVisualStyleBackColor = true;
            // 
            // subTyp2
            // 
            this.subTyp2.AccessibleDescription = null;
            this.subTyp2.AccessibleName = null;
            resources.ApplyResources(this.subTyp2, "subTyp2");
            this.subTyp2.BackgroundImage = null;
            this.subTyp2.Font = null;
            this.subTyp2.Name = "subTyp2";
            this.subTyp2.UseVisualStyleBackColor = true;
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
            // subDescTb
            // 
            this.subDescTb.AccessibleDescription = null;
            this.subDescTb.AccessibleName = null;
            resources.ApplyResources(this.subDescTb, "subDescTb");
            this.subDescTb.BackgroundImage = null;
            this.subDescTb.Font = null;
            this.subDescTb.Name = "subDescTb";
            this.subDescTb.TextChanged += new System.EventHandler(this.subDescTb_TextChanged);
            this.subDescTb.Enter += new System.EventHandler(this.subDescTb_Enter);
            // 
            // subShortDescTb
            // 
            this.subShortDescTb.AccessibleDescription = null;
            this.subShortDescTb.AccessibleName = null;
            resources.ApplyResources(this.subShortDescTb, "subShortDescTb");
            this.subShortDescTb.BackgroundImage = null;
            this.subShortDescTb.Font = null;
            this.subShortDescTb.Name = "subShortDescTb";
            this.subShortDescTb.TextChanged += new System.EventHandler(this.subShortDescTb_TextChanged);
            this.subShortDescTb.Enter += new System.EventHandler(this.subShortDescTb_Enter);
            // 
            // subjectDgv
            // 
            this.subjectDgv.AccessibleDescription = null;
            this.subjectDgv.AccessibleName = null;
            this.subjectDgv.AllowUserToAddRows = false;
            this.subjectDgv.AllowUserToDeleteRows = false;
            this.subjectDgv.AllowUserToResizeColumns = false;
            this.subjectDgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.subjectDgv, "subjectDgv");
            this.subjectDgv.BackgroundImage = null;
            this.subjectDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.subjectDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.subjectDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectDgv.Font = null;
            this.subjectDgv.MultiSelect = false;
            this.subjectDgv.Name = "subjectDgv";
            this.subjectDgv.ReadOnly = true;
            this.subjectDgv.RowHeadersVisible = false;
            this.subjectDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subjectDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.subjectDgv_CellClick);
            this.subjectDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.subjectDgv_CellClick);
            // 
            // CtrlSubject
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.subjectDgv);
            this.Controls.Add(this.panel1);
            this.Font = null;
            this.Name = "CtrlSubject";
            this.Load += new System.EventHandler(this.CtrlSubject_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roomTypGb.ResumeLayout(false);
            this.roomTypGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectDgv)).EndInit();
            this.ResumeLayout(false);

        }
        void subShortDescTb_TextChanged(object sender, System.EventArgs e)
        {
            this.subDescTb.Enabled = true;
        }

        void subDescTb_TextChanged(object sender, System.EventArgs e)
        {
            addBtn.Enabled = true;
        }

        void subShortDescTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
                this.subShortDescTb.Text = "";
        }

        void subDescTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
                subDescTb.Text = "";
        }


        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.GroupBox roomTypGb;
        private System.Windows.Forms.RadioButton subTyp1;
        private System.Windows.Forms.RadioButton subTyp2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox subDescTb;
        private System.Windows.Forms.TextBox subShortDescTb;
        private System.Windows.Forms.DataGridView subjectDgv;
    }
}
