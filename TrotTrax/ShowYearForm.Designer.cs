/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowYearForm));
            this.currentLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openClubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newClubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clubSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.openYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.refreshDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backNumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horsesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ridersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.membershipReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearlyReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsSchemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showListGroup = new System.Windows.Forms.GroupBox();
            this.showListBox = new System.Windows.Forms.ListView();
            this.showNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addShowBtn = new System.Windows.Forms.Button();
            this.viewShowBtn = new System.Windows.Forms.Button();
            this.classListGroup = new System.Windows.Forms.GroupBox();
            this.classListBox = new System.Windows.Forms.ListView();
            this.classNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addClassBtn = new System.Windows.Forms.Button();
            this.viewClassBtn = new System.Windows.Forms.Button();
            this.backNoGroup = new System.Windows.Forms.GroupBox();
            this.backNoListBox = new System.Windows.Forms.ListView();
            this.backNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.riderHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.horseHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.horseListBtn = new System.Windows.Forms.Button();
            this.riderListBtn = new System.Windows.Forms.Button();
            this.viewNumberBtn = new System.Windows.Forms.Button();
            this.addNumberBtn = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.showListGroup.SuspendLayout();
            this.classListGroup.SuspendLayout();
            this.backNoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentLabel
            // 
            this.currentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLabel.Location = new System.Drawing.Point(12, 24);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(225, 150);
            this.currentLabel.TabIndex = 3;
            this.currentLabel.Text = "Welcome to\r\nTrotTrax!";
            this.currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(954, 24);
            this.menuStrip.TabIndex = 4;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openClubToolStripMenuItem,
            this.openYearToolStripMenuItem,
            this.refreshDataToolStripMenuItem,
            this.fileSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openClubToolStripMenuItem
            // 
            this.openClubToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newClubToolStripMenuItem,
            this.clubSeparator});
            this.openClubToolStripMenuItem.Name = "openClubToolStripMenuItem";
            this.openClubToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openClubToolStripMenuItem.Text = "Open Club";
            // 
            // newClubToolStripMenuItem
            // 
            this.newClubToolStripMenuItem.Name = "newClubToolStripMenuItem";
            this.newClubToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.newClubToolStripMenuItem.Text = "New Club";
            this.newClubToolStripMenuItem.Click += new System.EventHandler(this.NewClub);
            // 
            // clubSeparator
            // 
            this.clubSeparator.Name = "clubSeparator";
            this.clubSeparator.Size = new System.Drawing.Size(123, 6);
            // 
            // openYearToolStripMenuItem
            // 
            this.openYearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newYearToolStripMenuItem,
            this.yearSeparator});
            this.openYearToolStripMenuItem.Name = "openYearToolStripMenuItem";
            this.openYearToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openYearToolStripMenuItem.Text = "Open Year";
            // 
            // newYearToolStripMenuItem
            // 
            this.newYearToolStripMenuItem.Name = "newYearToolStripMenuItem";
            this.newYearToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.newYearToolStripMenuItem.Text = "New Year";
            this.newYearToolStripMenuItem.Click += new System.EventHandler(this.NewYear);
            // 
            // yearSeparator
            // 
            this.yearSeparator.Name = "yearSeparator";
            this.yearSeparator.Size = new System.Drawing.Size(121, 6);
            // 
            // refreshDataToolStripMenuItem
            // 
            this.refreshDataToolStripMenuItem.Name = "refreshDataToolStripMenuItem";
            this.refreshDataToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.refreshDataToolStripMenuItem.Text = "Refresh Data";
            this.refreshDataToolStripMenuItem.Click += new System.EventHandler(this.RefreshOnClick);
            // 
            // fileSeparator
            // 
            this.fileSeparator.Name = "fileSeparator";
            this.fileSeparator.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenu);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backNumbersToolStripMenuItem,
            this.horsesToolStripMenuItem,
            this.ridersToolStripMenuItem,
            this.showsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // backNumbersToolStripMenuItem
            // 
            this.backNumbersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backNumbersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.backNumbersToolStripMenuItem.Name = "backNumbersToolStripMenuItem";
            this.backNumbersToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.backNumbersToolStripMenuItem.Text = "Back Numbers";
            // 
            // horsesToolStripMenuItem
            // 
            this.horsesToolStripMenuItem.Name = "horsesToolStripMenuItem";
            this.horsesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.horsesToolStripMenuItem.Text = "Horses";
            this.horsesToolStripMenuItem.Click += new System.EventHandler(this.NewHorse);
            // 
            // ridersToolStripMenuItem
            // 
            this.ridersToolStripMenuItem.Name = "ridersToolStripMenuItem";
            this.ridersToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.ridersToolStripMenuItem.Text = "Riders";
            this.ridersToolStripMenuItem.Click += new System.EventHandler(this.NewRider);
            // 
            // showsToolStripMenuItem
            // 
            this.showsToolStripMenuItem.Name = "showsToolStripMenuItem";
            this.showsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.showsToolStripMenuItem.Text = "Shows";
            this.showsToolStripMenuItem.Click += new System.EventHandler(this.NewShow);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classReportsToolStripMenuItem,
            this.membershipReportsToolStripMenuItem,
            this.showReportsToolStripMenuItem,
            this.yearlyReportsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // classReportsToolStripMenuItem
            // 
            this.classReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.classReportsToolStripMenuItem.Name = "classReportsToolStripMenuItem";
            this.classReportsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.classReportsToolStripMenuItem.Text = "Class Reports";
            // 
            // membershipReportsToolStripMenuItem
            // 
            this.membershipReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.membershipReportsToolStripMenuItem.Name = "membershipReportsToolStripMenuItem";
            this.membershipReportsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.membershipReportsToolStripMenuItem.Text = "Membership Reports";
            // 
            // showReportsToolStripMenuItem
            // 
            this.showReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.showReportsToolStripMenuItem.Name = "showReportsToolStripMenuItem";
            this.showReportsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.showReportsToolStripMenuItem.Text = "Show Reports";
            // 
            // yearlyReportsToolStripMenuItem
            // 
            this.yearlyReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.yearlyReportsToolStripMenuItem.Name = "yearlyReportsToolStripMenuItem";
            this.yearlyReportsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.yearlyReportsToolStripMenuItem.Text = "Yearly Reports";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriesToolStripMenuItem,
            this.classesToolStripMenuItem,
            this.pointsSchemeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.NewCategory);
            // 
            // classesToolStripMenuItem
            // 
            this.classesToolStripMenuItem.Name = "classesToolStripMenuItem";
            this.classesToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.classesToolStripMenuItem.Text = "Class List";
            this.classesToolStripMenuItem.Click += new System.EventHandler(this.NewClass);
            // 
            // pointsSchemeToolStripMenuItem
            // 
            this.pointsSchemeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsSchemeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.pointsSchemeToolStripMenuItem.Name = "pointsSchemeToolStripMenuItem";
            this.pointsSchemeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.pointsSchemeToolStripMenuItem.Text = "Points Scheme";
            // 
            // showListGroup
            // 
            this.showListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.showListGroup.Controls.Add(this.showListBox);
            this.showListGroup.Controls.Add(this.addShowBtn);
            this.showListGroup.Controls.Add(this.viewShowBtn);
            this.showListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showListGroup.Location = new System.Drawing.Point(17, 177);
            this.showListGroup.Name = "showListGroup";
            this.showListGroup.Size = new System.Drawing.Size(220, 348);
            this.showListGroup.TabIndex = 6;
            this.showListGroup.TabStop = false;
            this.showListGroup.Text = "Show List";
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
            this.showListBox.Size = new System.Drawing.Size(207, 290);
            this.showListBox.TabIndex = 13;
            this.showListBox.UseCompatibleStateImageBehavior = false;
            this.showListBox.View = System.Windows.Forms.View.Details;
            this.showListBox.DoubleClick += new System.EventHandler(this.ViewShow);
            // 
            // showNameHeader
            // 
            this.showNameHeader.Text = "Show Date";
            this.showNameHeader.Width = 181;
            // 
            // addShowBtn
            // 
            this.addShowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addShowBtn.Location = new System.Drawing.Point(109, 317);
            this.addShowBtn.Name = "addShowBtn";
            this.addShowBtn.Size = new System.Drawing.Size(105, 25);
            this.addShowBtn.TabIndex = 8;
            this.addShowBtn.Text = "Add Show";
            this.addShowBtn.UseVisualStyleBackColor = true;
            this.addShowBtn.Click += new System.EventHandler(this.NewShow);
            // 
            // viewShowBtn
            // 
            this.viewShowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewShowBtn.Location = new System.Drawing.Point(6, 317);
            this.viewShowBtn.Name = "viewShowBtn";
            this.viewShowBtn.Size = new System.Drawing.Size(95, 25);
            this.viewShowBtn.TabIndex = 7;
            this.viewShowBtn.Text = "View Show";
            this.viewShowBtn.UseVisualStyleBackColor = true;
            this.viewShowBtn.Click += new System.EventHandler(this.ViewShow);
            // 
            // classListGroup
            // 
            this.classListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classListGroup.Controls.Add(this.classListBox);
            this.classListGroup.Controls.Add(this.addClassBtn);
            this.classListGroup.Controls.Add(this.viewClassBtn);
            this.classListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classListGroup.Location = new System.Drawing.Point(243, 27);
            this.classListGroup.Name = "classListGroup";
            this.classListGroup.Size = new System.Drawing.Size(250, 498);
            this.classListGroup.TabIndex = 7;
            this.classListGroup.TabStop = false;
            this.classListGroup.Text = "This Year\'s Class List";
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
            this.classListBox.Size = new System.Drawing.Size(237, 436);
            this.classListBox.TabIndex = 12;
            this.classListBox.UseCompatibleStateImageBehavior = false;
            this.classListBox.View = System.Windows.Forms.View.Details;
            this.classListBox.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortClassList);
            this.classListBox.DoubleClick += new System.EventHandler(this.ViewClass);
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
            // addClassBtn
            // 
            this.addClassBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addClassBtn.Location = new System.Drawing.Point(129, 467);
            this.addClassBtn.Name = "addClassBtn";
            this.addClassBtn.Size = new System.Drawing.Size(115, 25);
            this.addClassBtn.TabIndex = 8;
            this.addClassBtn.Text = "Add Class";
            this.addClassBtn.UseVisualStyleBackColor = true;
            this.addClassBtn.Click += new System.EventHandler(this.NewClass);
            // 
            // viewClassBtn
            // 
            this.viewClassBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewClassBtn.Location = new System.Drawing.Point(6, 467);
            this.viewClassBtn.Name = "viewClassBtn";
            this.viewClassBtn.Size = new System.Drawing.Size(115, 25);
            this.viewClassBtn.TabIndex = 7;
            this.viewClassBtn.Text = "View Class";
            this.viewClassBtn.UseVisualStyleBackColor = true;
            this.viewClassBtn.Click += new System.EventHandler(this.ViewClass);
            // 
            // backNoGroup
            // 
            this.backNoGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backNoGroup.Controls.Add(this.addNumberBtn);
            this.backNoGroup.Controls.Add(this.backNoListBox);
            this.backNoGroup.Controls.Add(this.horseListBtn);
            this.backNoGroup.Controls.Add(this.riderListBtn);
            this.backNoGroup.Controls.Add(this.viewNumberBtn);
            this.backNoGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backNoGroup.Location = new System.Drawing.Point(499, 27);
            this.backNoGroup.Name = "backNoGroup";
            this.backNoGroup.Size = new System.Drawing.Size(443, 498);
            this.backNoGroup.TabIndex = 9;
            this.backNoGroup.TabStop = false;
            this.backNoGroup.Text = "Registered Back Numbers";
            // 
            // backNoListBox
            // 
            this.backNoListBox.AllowColumnReorder = true;
            this.backNoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backNoListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.backNoHeader,
            this.riderHeader,
            this.horseHeader});
            this.backNoListBox.FullRowSelect = true;
            this.backNoListBox.LabelWrap = false;
            this.backNoListBox.Location = new System.Drawing.Point(6, 25);
            this.backNoListBox.MultiSelect = false;
            this.backNoListBox.Name = "backNoListBox";
            this.backNoListBox.Size = new System.Drawing.Size(430, 436);
            this.backNoListBox.TabIndex = 11;
            this.backNoListBox.UseCompatibleStateImageBehavior = false;
            this.backNoListBox.View = System.Windows.Forms.View.Details;
            this.backNoListBox.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortBackNoList);
            this.backNoListBox.DoubleClick += new System.EventHandler(this.ViewBackNo);
            // 
            // backNoHeader
            // 
            this.backNoHeader.Text = "Back No.";
            this.backNoHeader.Width = 70;
            // 
            // riderHeader
            // 
            this.riderHeader.Text = "Rider Name";
            this.riderHeader.Width = 150;
            // 
            // horseHeader
            // 
            this.horseHeader.Text = "Horse Name";
            this.horseHeader.Width = 184;
            // 
            // horseListBtn
            // 
            this.horseListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horseListBtn.Location = new System.Drawing.Point(312, 467);
            this.horseListBtn.Name = "horseListBtn";
            this.horseListBtn.Size = new System.Drawing.Size(125, 25);
            this.horseListBtn.TabIndex = 10;
            this.horseListBtn.Text = "Horse List";
            this.horseListBtn.UseVisualStyleBackColor = true;
            this.horseListBtn.Click += new System.EventHandler(this.ViewHorse);
            // 
            // riderListBtn
            // 
            this.riderListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.riderListBtn.Location = new System.Drawing.Point(181, 467);
            this.riderListBtn.Name = "riderListBtn";
            this.riderListBtn.Size = new System.Drawing.Size(125, 25);
            this.riderListBtn.TabIndex = 9;
            this.riderListBtn.Text = "Rider List";
            this.riderListBtn.UseVisualStyleBackColor = true;
            this.riderListBtn.Click += new System.EventHandler(this.ViewRider);
            // 
            // viewNumberBtn
            // 
            this.viewNumberBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewNumberBtn.Location = new System.Drawing.Point(6, 467);
            this.viewNumberBtn.Name = "viewNumberBtn";
            this.viewNumberBtn.Size = new System.Drawing.Size(75, 25);
            this.viewNumberBtn.TabIndex = 7;
            this.viewNumberBtn.Text = "View No.";
            this.viewNumberBtn.UseVisualStyleBackColor = true;
            this.viewNumberBtn.Click += new System.EventHandler(this.ViewBackNo);
            // 
            // addNumberBtn
            // 
            this.addNumberBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addNumberBtn.Location = new System.Drawing.Point(87, 467);
            this.addNumberBtn.Name = "addNumberBtn";
            this.addNumberBtn.Size = new System.Drawing.Size(75, 25);
            this.addNumberBtn.TabIndex = 12;
            this.addNumberBtn.Text = "Add No.";
            this.addNumberBtn.UseVisualStyleBackColor = true;
            // 
            // ShowYearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 537);
            this.Controls.Add(this.backNoGroup);
            this.Controls.Add(this.classListGroup);
            this.Controls.Add(this.showListGroup);
            this.Controls.Add(this.currentLabel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ShowYearForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TrotTrax";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitPrompt);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.showListGroup.ResumeLayout(false);
            this.classListGroup.ResumeLayout(false);
            this.backNoGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openClubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newClubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.GroupBox showListGroup;
        private System.Windows.Forms.Button addShowBtn;
        private System.Windows.Forms.Button viewShowBtn;
        private System.Windows.Forms.GroupBox classListGroup;
        private System.Windows.Forms.Button addClassBtn;
        private System.Windows.Forms.Button viewClassBtn;
        private System.Windows.Forms.GroupBox backNoGroup;
        private System.Windows.Forms.Button viewNumberBtn;
        private System.Windows.Forms.Button horseListBtn;
        private System.Windows.Forms.Button riderListBtn;
        private System.Windows.Forms.ListView backNoListBox;
        private System.Windows.Forms.ColumnHeader backNoHeader;
        private System.Windows.Forms.ColumnHeader riderHeader;
        private System.Windows.Forms.ColumnHeader horseHeader;
        private System.Windows.Forms.ListView classListBox;
        private System.Windows.Forms.ColumnHeader classNoHeader;
        private System.Windows.Forms.ColumnHeader classNameHeader;
        private System.Windows.Forms.ListView showListBox;
        private System.Windows.Forms.ColumnHeader showNameHeader;
        private System.Windows.Forms.ToolStripMenuItem classReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membershipReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearlyReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backNumbersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horsesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ridersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointsSchemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator clubSeparator;
        private System.Windows.Forms.ToolStripSeparator yearSeparator;
        private System.Windows.Forms.ToolStripMenuItem refreshDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileSeparator;
        private System.Windows.Forms.Button addNumberBtn;
    }
}