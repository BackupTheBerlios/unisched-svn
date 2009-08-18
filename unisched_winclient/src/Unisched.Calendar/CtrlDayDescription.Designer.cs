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
namespace Unisched.Calendar
{
    partial class CtrlDayDescription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlDayDescription));
            this.lvDayDescription = new System.Windows.Forms.ListView();
            this.colDayDescription = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvDayDescription
            // 
            this.lvDayDescription.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDayDescription});
            resources.ApplyResources(this.lvDayDescription, "lvDayDescription");
            this.lvDayDescription.GridLines = true;
            this.lvDayDescription.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDayDescription.Name = "lvDayDescription";
            this.lvDayDescription.Scrollable = false;
            this.lvDayDescription.ShowGroups = false;
            this.lvDayDescription.UseCompatibleStateImageBehavior = false;
            this.lvDayDescription.View = System.Windows.Forms.View.Details;
            this.lvDayDescription.Resize += new System.EventHandler(this.lvDayDescription_Resize);
            // 
            // colDayDescription
            // 
            resources.ApplyResources(this.colDayDescription, "colDayDescription");
            // 
            // CtrlDayDescription
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvDayDescription);
            this.Name = "CtrlDayDescription";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDayDescription;
        private System.Windows.Forms.ColumnHeader colDayDescription;
    }
}
