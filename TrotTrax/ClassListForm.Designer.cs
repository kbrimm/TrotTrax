﻿/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */

namespace TrotTrax
{
    partial class ClassListForm
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
            this.showLabel = new System.Windows.Forms.Label();
            this.classListGroup = new System.Windows.Forms.GroupBox();
            this.newClassBtn = new System.Windows.Forms.Button();
            this.classListBox = new System.Windows.Forms.ListView();
            this.classNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewClassBtn = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.catBox = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.catLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.showNoLabel = new System.Windows.Forms.Label();
            this.catGroup = new System.Windows.Forms.GroupBox();
            this.newCatBtn = new System.Windows.Forms.Button();
            this.catListBox = new System.Windows.Forms.ListView();
            this.catNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catDescHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catTimedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catPayHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catPotHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catFeeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catViewBtn = new System.Windows.Forms.Button();
            this.viewShowBtn = new System.Windows.Forms.Button();
            this.showListBox = new System.Windows.Forms.ListView();
            this.showNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.showListGroup = new System.Windows.Forms.GroupBox();
            this.classListGroup.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.catGroup.SuspendLayout();
            this.showListGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // showLabel
            // 
            this.showLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLabel.Location = new System.Drawing.Point(12, 9);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(250, 80);
            this.showLabel.TabIndex = 7;
            this.showLabel.Text = "New Class \r\nSetup";
            this.showLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // classListGroup
            // 
            this.classListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classListGroup.Controls.Add(this.newClassBtn);
            this.classListGroup.Controls.Add(this.classListBox);
            this.classListGroup.Controls.Add(this.viewClassBtn);
            this.classListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classListGroup.Location = new System.Drawing.Point(12, 92);
            this.classListGroup.Name = "classListGroup";
            this.classListGroup.Size = new System.Drawing.Size(250, 383);
            this.classListGroup.TabIndex = 10;
            this.classListGroup.TabStop = false;
            this.classListGroup.Text = "Class List";
            // 
            // newClassBtn
            // 
            this.newClassBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newClassBtn.Location = new System.Drawing.Point(129, 352);
            this.newClassBtn.Name = "newClassBtn";
            this.newClassBtn.Size = new System.Drawing.Size(115, 25);
            this.newClassBtn.TabIndex = 13;
            this.newClassBtn.Text = "New Class";
            this.newClassBtn.UseVisualStyleBackColor = true;
            // 
            // classListBox
            // 
            this.classListBox.AllowColumnReorder = true;
            this.classListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.classListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.classNoHeader,
            this.classNameHeader});
            this.classListBox.FullRowSelect = true;
            this.classListBox.LabelWrap = false;
            this.classListBox.Location = new System.Drawing.Point(6, 25);
            this.classListBox.MultiSelect = false;
            this.classListBox.Name = "classListBox";
            this.classListBox.Size = new System.Drawing.Size(237, 321);
            this.classListBox.TabIndex = 12;
            this.classListBox.UseCompatibleStateImageBehavior = false;
            this.classListBox.View = System.Windows.Forms.View.Details;
            // 
            // classNoHeader
            // 
            this.classNoHeader.Text = "No.";
            this.classNoHeader.Width = 35;
            // 
            // classNameHeader
            // 
            this.classNameHeader.Text = "Class Name";
            this.classNameHeader.Width = 176;
            // 
            // viewClassBtn
            // 
            this.viewClassBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewClassBtn.Location = new System.Drawing.Point(6, 352);
            this.viewClassBtn.Name = "viewClassBtn";
            this.viewClassBtn.Size = new System.Drawing.Size(115, 25);
            this.viewClassBtn.TabIndex = 7;
            this.viewClassBtn.Text = "View Class";
            this.viewClassBtn.UseVisualStyleBackColor = true;
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.catBox);
            this.infoBox.Controls.Add(this.cancelBtn);
            this.infoBox.Controls.Add(this.deleteBtn);
            this.infoBox.Controls.Add(this.modifyBtn);
            this.infoBox.Controls.Add(this.catLabel);
            this.infoBox.Controls.Add(this.nameBox);
            this.infoBox.Controls.Add(this.descriptionLabel);
            this.infoBox.Controls.Add(this.numberBox);
            this.infoBox.Controls.Add(this.showNoLabel);
            this.infoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.Location = new System.Drawing.Point(268, 12);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(403, 220);
            this.infoBox.TabIndex = 11;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Class Information";
            // 
            // catBox
            // 
            this.catBox.FormattingEnabled = true;
            this.catBox.Location = new System.Drawing.Point(9, 158);
            this.catBox.Name = "catBox";
            this.catBox.Size = new System.Drawing.Size(388, 24);
            this.catBox.TabIndex = 11;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(277, 188);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 25);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(148, 188);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(123, 25);
            this.deleteBtn.TabIndex = 9;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(6, 188);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(136, 25);
            this.modifyBtn.TabIndex = 8;
            this.modifyBtn.Text = "Save Changes";
            this.modifyBtn.UseVisualStyleBackColor = true;
            // 
            // catLabel
            // 
            this.catLabel.AutoSize = true;
            this.catLabel.Location = new System.Drawing.Point(6, 139);
            this.catLabel.Name = "catLabel";
            this.catLabel.Size = new System.Drawing.Size(63, 16);
            this.catLabel.TabIndex = 6;
            this.catLabel.Text = "Category";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(9, 101);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(388, 22);
            this.nameBox.TabIndex = 5;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(6, 80);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(82, 16);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "Class Name";
            // 
            // numberBox
            // 
            this.numberBox.BackColor = System.Drawing.SystemColors.Window;
            this.numberBox.Location = new System.Drawing.Point(9, 44);
            this.numberBox.Name = "numberBox";
            this.numberBox.Size = new System.Drawing.Size(89, 22);
            this.numberBox.TabIndex = 1;
            // 
            // showNoLabel
            // 
            this.showNoLabel.AutoSize = true;
            this.showNoLabel.Location = new System.Drawing.Point(6, 25);
            this.showNoLabel.Name = "showNoLabel";
            this.showNoLabel.Size = new System.Drawing.Size(93, 16);
            this.showNoLabel.TabIndex = 0;
            this.showNoLabel.Text = "Class Number";
            // 
            // catGroup
            // 
            this.catGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.catGroup.Controls.Add(this.newCatBtn);
            this.catGroup.Controls.Add(this.catListBox);
            this.catGroup.Controls.Add(this.catViewBtn);
            this.catGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catGroup.Location = new System.Drawing.Point(268, 238);
            this.catGroup.Name = "catGroup";
            this.catGroup.Size = new System.Drawing.Size(623, 237);
            this.catGroup.TabIndex = 12;
            this.catGroup.TabStop = false;
            this.catGroup.Text = "Category Details";
            // 
            // newCatBtn
            // 
            this.newCatBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newCatBtn.Location = new System.Drawing.Point(314, 206);
            this.newCatBtn.Name = "newCatBtn";
            this.newCatBtn.Size = new System.Drawing.Size(303, 25);
            this.newCatBtn.TabIndex = 13;
            this.newCatBtn.Text = "New Category";
            this.newCatBtn.UseVisualStyleBackColor = true;
            // 
            // catListBox
            // 
            this.catListBox.AllowColumnReorder = true;
            this.catListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.catListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.catNoHeader,
            this.catDescHeader,
            this.catTimedHeader,
            this.catPayHeader,
            this.catPotHeader,
            this.catFeeHeader});
            this.catListBox.FullRowSelect = true;
            this.catListBox.LabelWrap = false;
            this.catListBox.Location = new System.Drawing.Point(6, 25);
            this.catListBox.MultiSelect = false;
            this.catListBox.Name = "catListBox";
            this.catListBox.Size = new System.Drawing.Size(611, 175);
            this.catListBox.TabIndex = 12;
            this.catListBox.UseCompatibleStateImageBehavior = false;
            this.catListBox.View = System.Windows.Forms.View.Details;
            // 
            // catNoHeader
            // 
            this.catNoHeader.Text = "No.";
            this.catNoHeader.Width = 35;
            // 
            // catDescHeader
            // 
            this.catDescHeader.Text = "Category Description";
            this.catDescHeader.Width = 290;
            // 
            // catTimedHeader
            // 
            this.catTimedHeader.Text = "Timed";
            // 
            // catPayHeader
            // 
            this.catPayHeader.Text = "Payout";
            // 
            // catPotHeader
            // 
            this.catPotHeader.Text = "Jackpot";
            this.catPotHeader.Width = 65;
            // 
            // catFeeHeader
            // 
            this.catFeeHeader.Text = "Entry Fee";
            this.catFeeHeader.Width = 75;
            // 
            // catViewBtn
            // 
            this.catViewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.catViewBtn.Location = new System.Drawing.Point(6, 206);
            this.catViewBtn.Name = "catViewBtn";
            this.catViewBtn.Size = new System.Drawing.Size(303, 25);
            this.catViewBtn.TabIndex = 7;
            this.catViewBtn.Text = "View Category";
            this.catViewBtn.UseVisualStyleBackColor = true;
            // 
            // viewShowBtn
            // 
            this.viewShowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewShowBtn.Location = new System.Drawing.Point(7, 189);
            this.viewShowBtn.Name = "viewShowBtn";
            this.viewShowBtn.Size = new System.Drawing.Size(207, 25);
            this.viewShowBtn.TabIndex = 7;
            this.viewShowBtn.Text = "View Class for Show";
            this.viewShowBtn.UseVisualStyleBackColor = true;
            // 
            // showListBox
            // 
            this.showListBox.AllowColumnReorder = true;
            this.showListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.showListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.showNameHeader});
            this.showListBox.FullRowSelect = true;
            this.showListBox.LabelWrap = false;
            this.showListBox.Location = new System.Drawing.Point(7, 21);
            this.showListBox.MultiSelect = false;
            this.showListBox.Name = "showListBox";
            this.showListBox.Size = new System.Drawing.Size(207, 162);
            this.showListBox.TabIndex = 13;
            this.showListBox.UseCompatibleStateImageBehavior = false;
            this.showListBox.View = System.Windows.Forms.View.Details;
            // 
            // showNameHeader
            // 
            this.showNameHeader.Text = "Show Date";
            this.showNameHeader.Width = 181;
            // 
            // showListGroup
            // 
            this.showListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.showListGroup.Controls.Add(this.showListBox);
            this.showListGroup.Controls.Add(this.viewShowBtn);
            this.showListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showListGroup.Location = new System.Drawing.Point(677, 12);
            this.showListGroup.Name = "showListGroup";
            this.showListGroup.Size = new System.Drawing.Size(220, 220);
            this.showListGroup.TabIndex = 13;
            this.showListGroup.TabStop = false;
            this.showListGroup.Text = "Show List";
            // 
            // ClassListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.showListGroup);
            this.Controls.Add(this.catGroup);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.classListGroup);
            this.Controls.Add(this.showLabel);
            this.Name = "ClassListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrotTrax";
            this.classListGroup.ResumeLayout(false);
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.catGroup.ResumeLayout(false);
            this.showListGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label showLabel;
        private System.Windows.Forms.GroupBox classListGroup;
        private System.Windows.Forms.ListView classListBox;
        private System.Windows.Forms.ColumnHeader classNoHeader;
        private System.Windows.Forms.ColumnHeader classNameHeader;
        private System.Windows.Forms.Button viewClassBtn;
        private System.Windows.Forms.Button newClassBtn;
        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.ComboBox catBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Label catLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.Label showNoLabel;
        private System.Windows.Forms.GroupBox catGroup;
        private System.Windows.Forms.Button newCatBtn;
        private System.Windows.Forms.ListView catListBox;
        private System.Windows.Forms.ColumnHeader catNoHeader;
        private System.Windows.Forms.ColumnHeader catDescHeader;
        private System.Windows.Forms.Button catViewBtn;
        private System.Windows.Forms.ColumnHeader catTimedHeader;
        private System.Windows.Forms.ColumnHeader catPayHeader;
        private System.Windows.Forms.ColumnHeader catPotHeader;
        private System.Windows.Forms.ColumnHeader catFeeHeader;
        private System.Windows.Forms.Button viewShowBtn;
        private System.Windows.Forms.ListView showListBox;
        private System.Windows.Forms.ColumnHeader showNameHeader;
        private System.Windows.Forms.GroupBox showListGroup;
    }
}