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

namespace Unisched.Controls
{
    partial class CtrlScheduling
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
            this.ctrlCalendar = new Unisched.Calendar.CtrlCalendar();
            this.SuspendLayout();
            // 
            // ctrlCalendar
            // 
            this.ctrlCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCalendar.Location = new System.Drawing.Point(0, 0);
            this.ctrlCalendar.Name = "ctrlCalendar";
            this.ctrlCalendar.Size = new System.Drawing.Size(624, 488);
            this.ctrlCalendar.TabIndex = 0;
            // 
            // CtrlScheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlCalendar);
            this.Name = "CtrlScheduling";
            this.Size = new System.Drawing.Size(624, 488);
            this.ResumeLayout(false);

        }

        #endregion

        private Unisched.Calendar.CtrlCalendar ctrlCalendar;
    }
}
