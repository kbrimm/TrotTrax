/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */

namespace TrotTrax
{
    partial class ShowYearForm
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
            this.modifyGroup = new System.Windows.Forms.GroupBox();
            this.modifyMemberBtn = new System.Windows.Forms.Button();
            this.modifyClassBtn = new System.Windows.Forms.Button();
            this.modifyShowsBtn = new System.Windows.Forms.Button();
            this.enterShowBtn = new System.Windows.Forms.Button();
            this.showsList = new System.Windows.Forms.ListBox();
            this.currentLabel = new System.Windows.Forms.Label();
            this.classList = new System.Windows.Forms.ListBox();
            this.toolBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeClubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyShowListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyClassListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyMemberListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horseListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backNumberListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.financialSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yearToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.riderList = new System.Windows.Forms.ListBox();
            this.modifyGroup.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // modifyGroup
            // 
            this.modifyGroup.Controls.Add(this.modifyMemberBtn);
            this.modifyGroup.Controls.Add(this.modifyClassBtn);
            this.modifyGroup.Controls.Add(this.modifyShowsBtn);
            this.modifyGroup.Location = new System.Drawing.Point(12, 358);
            this.modifyGroup.Name = "modifyGroup";
            this.modifyGroup.Size = new System.Drawing.Size(233, 192);
            this.modifyGroup.TabIndex = 0;
            this.modifyGroup.TabStop = false;
            this.modifyGroup.Text = "Modify Data";
            // 
            // modifyMemberBtn
            // 
            this.modifyMemberBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modifyMemberBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.modifyMemberBtn.Location = new System.Drawing.Point(6, 131);
            this.modifyMemberBtn.Name = "modifyMemberBtn";
            this.modifyMemberBtn.Size = new System.Drawing.Size(220, 50);
            this.modifyMemberBtn.TabIndex = 2;
            this.modifyMemberBtn.Text = "Member List";
            this.modifyMemberBtn.UseVisualStyleBackColor = true;
            this.modifyMemberBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // modifyClassBtn
            // 
            this.modifyClassBtn.Location = new System.Drawing.Point(7, 75);
            this.modifyClassBtn.Name = "modifyClassBtn";
            this.modifyClassBtn.Size = new System.Drawing.Size(220, 50);
            this.modifyClassBtn.TabIndex = 1;
            this.modifyClassBtn.Text = "Class List";
            this.modifyClassBtn.UseVisualStyleBackColor = true;
            // 
            // modifyShowsBtn
            // 
            this.modifyShowsBtn.Location = new System.Drawing.Point(7, 19);
            this.modifyShowsBtn.Name = "modifyShowsBtn";
            this.modifyShowsBtn.Size = new System.Drawing.Size(220, 50);
            this.modifyShowsBtn.TabIndex = 0;
            this.modifyShowsBtn.Text = "Show List";
            this.modifyShowsBtn.UseVisualStyleBackColor = true;
            // 
            // enterShowBtn
            // 
            this.enterShowBtn.Location = new System.Drawing.Point(12, 302);
            this.enterShowBtn.Name = "enterShowBtn";
            this.enterShowBtn.Size = new System.Drawing.Size(233, 50);
            this.enterShowBtn.TabIndex = 1;
            this.enterShowBtn.Text = "Show";
            this.enterShowBtn.UseVisualStyleBackColor = true;
            // 
            // showsList
            // 
            this.showsList.FormattingEnabled = true;
            this.showsList.Location = new System.Drawing.Point(12, 134);
            this.showsList.Name = "showsList";
            this.showsList.ScrollAlwaysVisible = true;
            this.showsList.Size = new System.Drawing.Size(233, 160);
            this.showsList.TabIndex = 2;
            // 
            // currentLabel
            // 
            this.currentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLabel.Location = new System.Drawing.Point(12, 24);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(233, 107);
            this.currentLabel.TabIndex = 3;
            this.currentLabel.Text = "ShowYear.club\r\n\r\nShowYear.year Show Year";
            this.currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // classList
            // 
            this.classList.FormattingEnabled = true;
            this.classList.Location = new System.Drawing.Point(251, 37);
            this.classList.Name = "classList";
            this.classList.ScrollAlwaysVisible = true;
            this.classList.Size = new System.Drawing.Size(233, 511);
            this.classList.TabIndex = 4;
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(970, 24);
            this.toolBar.TabIndex = 5;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeYearToolStripMenuItem,
            this.changeClubToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // changeYearToolStripMenuItem
            // 
            this.changeYearToolStripMenuItem.Name = "changeYearToolStripMenuItem";
            this.changeYearToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.changeYearToolStripMenuItem.Text = "Change Year";
            // 
            // changeClubToolStripMenuItem
            // 
            this.changeClubToolStripMenuItem.Name = "changeClubToolStripMenuItem";
            this.changeClubToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.changeClubToolStripMenuItem.Text = "Change Club";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyShowListToolStripMenuItem,
            this.modifyClassListToolStripMenuItem,
            this.modifyMemberListToolStripMenuItem,
            this.horseListToolStripMenuItem,
            this.backNumberListToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // modifyShowListToolStripMenuItem
            // 
            this.modifyShowListToolStripMenuItem.Name = "modifyShowListToolStripMenuItem";
            this.modifyShowListToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.modifyShowListToolStripMenuItem.Text = "Show List";
            // 
            // modifyClassListToolStripMenuItem
            // 
            this.modifyClassListToolStripMenuItem.Name = "modifyClassListToolStripMenuItem";
            this.modifyClassListToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.modifyClassListToolStripMenuItem.Text = "Class List";
            // 
            // modifyMemberListToolStripMenuItem
            // 
            this.modifyMemberListToolStripMenuItem.Name = "modifyMemberListToolStripMenuItem";
            this.modifyMemberListToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.modifyMemberListToolStripMenuItem.Text = "Rider List";
            // 
            // horseListToolStripMenuItem
            // 
            this.horseListToolStripMenuItem.Name = "horseListToolStripMenuItem";
            this.horseListToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.horseListToolStripMenuItem.Text = "Horse List";
            // 
            // backNumberListToolStripMenuItem
            // 
            this.backNumberListToolStripMenuItem.Name = "backNumberListToolStripMenuItem";
            this.backNumberListToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.backNumberListToolStripMenuItem.Text = "Back Number List";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classListToolStripMenuItem,
            this.showSummaryToolStripMenuItem,
            this.pointSummaryToolStripMenuItem,
            this.financialSummaryToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // classListToolStripMenuItem
            // 
            this.classListToolStripMenuItem.Name = "classListToolStripMenuItem";
            this.classListToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.classListToolStripMenuItem.Text = "Class List";
            // 
            // showSummaryToolStripMenuItem
            // 
            this.showSummaryToolStripMenuItem.Name = "showSummaryToolStripMenuItem";
            this.showSummaryToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.showSummaryToolStripMenuItem.Text = "Show Summary";
            // 
            // pointSummaryToolStripMenuItem
            // 
            this.pointSummaryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backNumberToolStripMenuItem,
            this.horseToolStripMenuItem,
            this.showToolStripMenuItem,
            this.yearToolStripMenuItem1});
            this.pointSummaryToolStripMenuItem.Name = "pointSummaryToolStripMenuItem";
            this.pointSummaryToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.pointSummaryToolStripMenuItem.Text = "Point Summary";
            // 
            // backNumberToolStripMenuItem
            // 
            this.backNumberToolStripMenuItem.Name = "backNumberToolStripMenuItem";
            this.backNumberToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.backNumberToolStripMenuItem.Text = "Back Number";
            // 
            // horseToolStripMenuItem
            // 
            this.horseToolStripMenuItem.Name = "horseToolStripMenuItem";
            this.horseToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.horseToolStripMenuItem.Text = "Horse";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // yearToolStripMenuItem1
            // 
            this.yearToolStripMenuItem1.Name = "yearToolStripMenuItem1";
            this.yearToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.yearToolStripMenuItem1.Text = "Year";
            // 
            // financialSummaryToolStripMenuItem
            // 
            this.financialSummaryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memberToolStripMenuItem,
            this.baToolStripMenuItem,
            this.showToolStripMenuItem1,
            this.yearToolStripMenuItem2});
            this.financialSummaryToolStripMenuItem.Name = "financialSummaryToolStripMenuItem";
            this.financialSummaryToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.financialSummaryToolStripMenuItem.Text = "Financial Summary";
            // 
            // memberToolStripMenuItem
            // 
            this.memberToolStripMenuItem.Name = "memberToolStripMenuItem";
            this.memberToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.memberToolStripMenuItem.Text = "Back Number";
            // 
            // baToolStripMenuItem
            // 
            this.baToolStripMenuItem.Name = "baToolStripMenuItem";
            this.baToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.baToolStripMenuItem.Text = "Member";
            // 
            // showToolStripMenuItem1
            // 
            this.showToolStripMenuItem1.Name = "showToolStripMenuItem1";
            this.showToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.showToolStripMenuItem1.Text = "Show";
            // 
            // yearToolStripMenuItem2
            // 
            this.yearToolStripMenuItem2.Name = "yearToolStripMenuItem2";
            this.yearToolStripMenuItem2.Size = new System.Drawing.Size(146, 22);
            this.yearToolStripMenuItem2.Text = "Year";
            // 
            // riderList
            // 
            this.riderList.FormattingEnabled = true;
            this.riderList.Location = new System.Drawing.Point(490, 37);
            this.riderList.MultiColumn = true;
            this.riderList.Name = "riderList";
            this.riderList.ScrollAlwaysVisible = true;
            this.riderList.Size = new System.Drawing.Size(468, 511);
            this.riderList.TabIndex = 6;
            // 
            // ShowYearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 562);
            this.Controls.Add(this.riderList);
            this.Controls.Add(this.classList);
            this.Controls.Add(this.currentLabel);
            this.Controls.Add(this.showsList);
            this.Controls.Add(this.enterShowBtn);
            this.Controls.Add(this.modifyGroup);
            this.Controls.Add(this.toolBar);
            this.MainMenuStrip = this.toolBar;
            this.Name = "ShowYearForm";
            this.Text = "TrotTrax";
            this.modifyGroup.ResumeLayout(false);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox modifyGroup;
        private System.Windows.Forms.Button modifyMemberBtn;
        private System.Windows.Forms.Button modifyClassBtn;
        private System.Windows.Forms.Button modifyShowsBtn;
        private System.Windows.Forms.Button enterShowBtn;
        private System.Windows.Forms.ListBox showsList;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.ListBox classList;
        private System.Windows.Forms.MenuStrip toolBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeClubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyShowListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyClassListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyMemberListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem financialSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yearToolStripMenuItem2;
        private System.Windows.Forms.ListBox riderList;
        private System.Windows.Forms.ToolStripMenuItem horseListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backNumberListToolStripMenuItem;

    }
}