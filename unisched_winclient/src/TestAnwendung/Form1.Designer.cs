namespace TestAnwendung
{
    partial class Form1
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
            this.pnlCalendar = new System.Windows.Forms.Panel();
            this.ctrlCalendar1 = new Unisched.Calendar.CtrlCalendar();
            this.pnlTest = new System.Windows.Forms.Panel();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlCalendar.SuspendLayout();
            this.pnlTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.Controls.Add(this.ctrlCalendar1);
            this.pnlCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalendar.Location = new System.Drawing.Point(0, 0);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Size = new System.Drawing.Size(889, 484);
            this.pnlCalendar.TabIndex = 1;
            // 
            // ctrlCalendar1
            // 
            this.ctrlCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCalendar1.Location = new System.Drawing.Point(0, 0);
            this.ctrlCalendar1.Name = "ctrlCalendar1";
            this.ctrlCalendar1.Size = new System.Drawing.Size(889, 484);
            this.ctrlCalendar1.TabIndex = 0;
            // 
            // pnlTest
            // 
            this.pnlTest.Controls.Add(this.btnAbort);
            this.pnlTest.Controls.Add(this.btnSave);
            this.pnlTest.Controls.Add(this.dataGridView1);
            this.pnlTest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTest.Location = new System.Drawing.Point(0, 484);
            this.pnlTest.Name = "pnlTest";
            this.pnlTest.Size = new System.Drawing.Size(889, 246);
            this.pnlTest.TabIndex = 2;
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(615, 171);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 1;
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(615, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(63, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(546, 187);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 730);
            this.Controls.Add(this.pnlCalendar);
            this.Controls.Add(this.pnlTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlCalendar.ResumeLayout(false);
            this.pnlTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Unisched.Calendar.CtrlCalendar ctrlCalendar1;
        private System.Windows.Forms.Panel pnlCalendar;
        private System.Windows.Forms.Panel pnlTest;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAbort;

    }
}

