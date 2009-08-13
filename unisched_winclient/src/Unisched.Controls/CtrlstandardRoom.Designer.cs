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
            this.cbSemGrp = new System.Windows.Forms.ComboBox();
            this.gbSemGrp = new System.Windows.Forms.GroupBox();
            this.gbRoom = new System.Windows.Forms.GroupBox();
            this.cbRoom = new System.Windows.Forms.ComboBox();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.dgvDefRoom = new System.Windows.Forms.DataGridView();
            this.gbSemGrp.SuspendLayout();
            this.gbRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSemGrp
            // 
            this.cbSemGrp.FormattingEnabled = true;
            this.cbSemGrp.Location = new System.Drawing.Point(6, 16);
            this.cbSemGrp.Name = "cbSemGrp";
            this.cbSemGrp.Size = new System.Drawing.Size(121, 21);
            this.cbSemGrp.TabIndex = 0;
            this.cbSemGrp.SelectedIndexChanged += new System.EventHandler(this.cbSemGrp_SelectedIndexChanged);
            // 
            // gbSemGrp
            // 
            this.gbSemGrp.Controls.Add(this.cbSemGrp);
            this.gbSemGrp.Location = new System.Drawing.Point(233, 3);
            this.gbSemGrp.Name = "gbSemGrp";
            this.gbSemGrp.Size = new System.Drawing.Size(136, 50);
            this.gbSemGrp.TabIndex = 2;
            this.gbSemGrp.TabStop = false;
            this.gbSemGrp.Text = "Seminargruppe";
            // 
            // gbRoom
            // 
            this.gbRoom.Controls.Add(this.cbPriority);
            this.gbRoom.Controls.Add(this.cbRoom);
            this.gbRoom.Location = new System.Drawing.Point(233, 59);
            this.gbRoom.Name = "gbRoom";
            this.gbRoom.Size = new System.Drawing.Size(136, 72);
            this.gbRoom.TabIndex = 3;
            this.gbRoom.TabStop = false;
            this.gbRoom.Text = "Standardraum";
            // 
            // cbRoom
            // 
            this.cbRoom.Enabled = false;
            this.cbRoom.FormattingEnabled = true;
            this.cbRoom.Location = new System.Drawing.Point(6, 15);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(121, 21);
            this.cbRoom.TabIndex = 0;
            this.cbRoom.SelectedIndexChanged += new System.EventHandler(this.cbRoom_SelectedIndexChanged);
            // 
            // cbPriority
            // 
            this.cbPriority.Enabled = false;
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Location = new System.Drawing.Point(6, 42);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(121, 21);
            this.cbPriority.TabIndex = 1;
            this.cbPriority.SelectedIndexChanged += new System.EventHandler(this.cbPriority_SelectedIndexChanged);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(233, 137);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(63, 23);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Speichern";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(302, 137);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(67, 23);
            this.delBtn.TabIndex = 5;
            this.delBtn.Text = "Löschen";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // dgvDefRoom
            // 
            this.dgvDefRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefRoom.Location = new System.Drawing.Point(3, 3);
            this.dgvDefRoom.Name = "dgvDefRoom";
            this.dgvDefRoom.Size = new System.Drawing.Size(224, 159);
            this.dgvDefRoom.TabIndex = 6;
            // 
            // CtrlstandardRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDefRoom);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.gbRoom);
            this.Controls.Add(this.gbSemGrp);
            this.Name = "CtrlstandardRoom";
            this.Size = new System.Drawing.Size(377, 165);
            this.Load += new System.EventHandler(this.CtrlstandardRoom_Load);
            this.gbSemGrp.ResumeLayout(false);
            this.gbRoom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSemGrp;
        private System.Windows.Forms.GroupBox gbSemGrp;
        private System.Windows.Forms.GroupBox gbRoom;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.ComboBox cbRoom;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.DataGridView dgvDefRoom;
    }
}
