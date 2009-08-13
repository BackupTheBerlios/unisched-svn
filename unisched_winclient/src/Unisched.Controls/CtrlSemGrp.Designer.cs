namespace Unisched.Controls
{
    partial class CtrlSemGrp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlSemGrp));
            this.semGrpDgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbFieldName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.classTyp2 = new System.Windows.Forms.RadioButton();
            this.classTyp1 = new System.Windows.Forms.RadioButton();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.semGrpCount = new System.Windows.Forms.TextBox();
            this.semGrpTb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.semGrpDgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // semGrpDgv
            // 
            this.semGrpDgv.AllowUserToAddRows = false;
            this.semGrpDgv.AllowUserToDeleteRows = false;
            this.semGrpDgv.AllowUserToResizeColumns = false;
            this.semGrpDgv.AllowUserToResizeRows = false;
            this.semGrpDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.semGrpDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.semGrpDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.semGrpDgv, "semGrpDgv");
            this.semGrpDgv.MultiSelect = false;
            this.semGrpDgv.Name = "semGrpDgv";
            this.semGrpDgv.ReadOnly = true;
            this.semGrpDgv.RowHeadersVisible = false;
            this.semGrpDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.semGrpDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.semGrpDgv_CellClick);
            this.semGrpDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.semGrpDgv_CellClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbFieldName);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.delBtn);
            this.panel1.Controls.Add(this.addBtn);
            this.panel1.Controls.Add(this.newBtn);
            this.panel1.Controls.Add(this.semGrpCount);
            this.panel1.Controls.Add(this.semGrpTb);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // cbFieldName
            // 
            this.cbFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFieldName.FormattingEnabled = true;
            resources.ApplyResources(this.cbFieldName, "cbFieldName");
            this.cbFieldName.Name = "cbFieldName";
            this.cbFieldName.SelectedIndexChanged += new System.EventHandler(this.cbFieldName_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.classTyp2);
            this.groupBox1.Controls.Add(this.classTyp1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // classTyp2
            // 
            resources.ApplyResources(this.classTyp2, "classTyp2");
            this.classTyp2.Name = "classTyp2";
            this.classTyp2.UseVisualStyleBackColor = true;
            this.classTyp2.CheckedChanged += new System.EventHandler(this.classTyp2_CheckedChanged);
            // 
            // classTyp1
            // 
            resources.ApplyResources(this.classTyp1, "classTyp1");
            this.classTyp1.Checked = true;
            this.classTyp1.Name = "classTyp1";
            this.classTyp1.TabStop = true;
            this.classTyp1.UseVisualStyleBackColor = true;
            this.classTyp1.CheckedChanged += new System.EventHandler(this.classTyp1_CheckedChanged);
            // 
            // delBtn
            // 
            resources.ApplyResources(this.delBtn, "delBtn");
            this.delBtn.Name = "delBtn";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addBtn
            // 
            resources.ApplyResources(this.addBtn, "addBtn");
            this.addBtn.Name = "addBtn";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // newBtn
            // 
            resources.ApplyResources(this.newBtn, "newBtn");
            this.newBtn.Name = "newBtn";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // semGrpCount
            // 
            resources.ApplyResources(this.semGrpCount, "semGrpCount");
            this.semGrpCount.Name = "semGrpCount";
            this.semGrpCount.TextChanged += new System.EventHandler(this.semGrpCount_TextChanged);
            this.semGrpCount.Enter += new System.EventHandler(this.semGrpCount_Enter);
            // 
            // semGrpTb
            // 
            resources.ApplyResources(this.semGrpTb, "semGrpTb");
            this.semGrpTb.Name = "semGrpTb";
            this.semGrpTb.TextChanged += new System.EventHandler(this.semGrpTb_TextChanged);
            this.semGrpTb.Enter += new System.EventHandler(this.semGrpTb_Enter);
            // 
            // CtrlSemGrp
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.semGrpDgv);
            this.Name = "CtrlSemGrp";
            this.Load += new System.EventHandler(this.CtrlSemGrp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.semGrpDgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        void semGrpTb_Enter(object sender, System.EventArgs e)
        {
            this.semGrpTb.Text = "";
        }

        void semGrpCount_Enter(object sender, System.EventArgs e)
        {
            if (!edit)
                semGrpCount.Text = "";
            addBtn.Enabled = true;
        }





        #endregion

        private System.Windows.Forms.DataGridView semGrpDgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox semGrpCount;
        private System.Windows.Forms.TextBox semGrpTb;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton classTyp2;
        private System.Windows.Forms.RadioButton classTyp1;
        private System.Windows.Forms.ComboBox cbFieldName;
    }
}
