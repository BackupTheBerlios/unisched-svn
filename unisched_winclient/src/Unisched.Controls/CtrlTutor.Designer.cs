namespace Unisched.Controls
{
    partial class CtrlTutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlTutor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.newBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.telNrTb = new System.Windows.Forms.TextBox();
            this.tutorLnTb = new System.Windows.Forms.TextBox();
            this.tutorFnTb = new System.Windows.Forms.TextBox();
            this.tutorDgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutorDgv)).BeginInit();
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
            this.panel1.Controls.Add(this.addBtn);
            this.panel1.Controls.Add(this.telNrTb);
            this.panel1.Controls.Add(this.tutorLnTb);
            this.panel1.Controls.Add(this.tutorFnTb);
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
            // telNrTb
            // 
            this.telNrTb.AccessibleDescription = null;
            this.telNrTb.AccessibleName = null;
            resources.ApplyResources(this.telNrTb, "telNrTb");
            this.telNrTb.BackgroundImage = null;
            this.telNrTb.Font = null;
            this.telNrTb.Name = "telNrTb";
            this.telNrTb.TextChanged += new System.EventHandler(this.telNrTb_TextChanged);
            this.telNrTb.Enter += new System.EventHandler(this.telNrTb_Enter);
            // 
            // tutorLnTb
            // 
            this.tutorLnTb.AccessibleDescription = null;
            this.tutorLnTb.AccessibleName = null;
            resources.ApplyResources(this.tutorLnTb, "tutorLnTb");
            this.tutorLnTb.BackgroundImage = null;
            this.tutorLnTb.Font = null;
            this.tutorLnTb.Name = "tutorLnTb";
            this.tutorLnTb.TextChanged += new System.EventHandler(this.tutorLnTb_TextChanged);
            this.tutorLnTb.Enter += new System.EventHandler(this.tutorLnTb_Enter);
            // 
            // tutorFnTb
            // 
            this.tutorFnTb.AccessibleDescription = null;
            this.tutorFnTb.AccessibleName = null;
            resources.ApplyResources(this.tutorFnTb, "tutorFnTb");
            this.tutorFnTb.BackgroundImage = null;
            this.tutorFnTb.Font = null;
            this.tutorFnTb.Name = "tutorFnTb";
            this.tutorFnTb.TextChanged += new System.EventHandler(this.tutorFnTb_TextChanged);
            this.tutorFnTb.Enter += new System.EventHandler(this.tutorFnTb_Enter);
            // 
            // tutorDgv
            // 
            this.tutorDgv.AccessibleDescription = null;
            this.tutorDgv.AccessibleName = null;
            this.tutorDgv.AllowUserToAddRows = false;
            this.tutorDgv.AllowUserToDeleteRows = false;
            this.tutorDgv.AllowUserToResizeColumns = false;
            this.tutorDgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.tutorDgv, "tutorDgv");
            this.tutorDgv.BackgroundImage = null;
            this.tutorDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tutorDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.tutorDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tutorDgv.Font = null;
            this.tutorDgv.MultiSelect = false;
            this.tutorDgv.Name = "tutorDgv";
            this.tutorDgv.ReadOnly = true;
            this.tutorDgv.RowHeadersVisible = false;
            this.tutorDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tutorDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tutorDgv_CellClick);
            // 
            // CtrlTutor
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tutorDgv);
            this.Font = null;
            this.Name = "CtrlTutor";
            this.Load += new System.EventHandler(this.CtrlTutor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutorDgv)).EndInit();
            this.ResumeLayout(false);

        }

        void tutorFnTb_TextChanged(object sender, System.EventArgs e)
        {
            tutorLnTb.Enabled = true;
        }

        void tutorLnTb_TextChanged(object sender, System.EventArgs e)
        {
            telNrTb.Enabled = true;
        }

        void telNrTb_TextChanged(object sender, System.EventArgs e)
        {
            addBtn.Enabled = true;
        }

        void tutorFnTb_Enter(object sender, System.EventArgs e)
        {
            if(!edit)
            this.tutorFnTb.Text = "";
        }

        void tutorLnTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
            tutorLnTb.Text = "";
        }

        void telNrTb_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
            telNrTb.Text = "";
        }



        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox telNrTb;
        private System.Windows.Forms.TextBox tutorLnTb;
        private System.Windows.Forms.TextBox tutorFnTb;
        private System.Windows.Forms.DataGridView tutorDgv;

    }
}
