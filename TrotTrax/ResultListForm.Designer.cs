/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */

namespace TrotTrax
{
    partial class ResultListForm
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
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.classListBox = new System.Windows.Forms.ListView();
            this.classNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewClassBtn = new System.Windows.Forms.Button();
            this.entryGroup = new System.Windows.Forms.GroupBox();
            this.totalBox = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.entryListBox = new System.Windows.Forms.ListView();
            this.backNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.riderHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.horseHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeEntryBtn = new System.Windows.Forms.Button();
            this.viewNumber = new System.Windows.Forms.Button();
            this.addEntryGroup = new System.Windows.Forms.GroupBox();
            this.listBtn = new System.Windows.Forms.Button();
            this.manualBtn = new System.Windows.Forms.Button();
            this.entryBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.manualBox = new System.Windows.Forms.TextBox();
            this.manualEntryLabel = new System.Windows.Forms.Label();
            this.placingGroup = new System.Windows.Forms.GroupBox();
            this.placeBtn = new System.Windows.Forms.Button();
            this.sixthLabel = new System.Windows.Forms.Label();
            this.fifthLabel = new System.Windows.Forms.Label();
            this.fourthLabel = new System.Windows.Forms.Label();
            this.thirdLabel = new System.Windows.Forms.Label();
            this.secondLabel = new System.Windows.Forms.Label();
            this.payoutBox6 = new System.Windows.Forms.TextBox();
            this.payoutBox5 = new System.Windows.Forms.TextBox();
            this.payoutBox4 = new System.Windows.Forms.TextBox();
            this.payoutBox3 = new System.Windows.Forms.TextBox();
            this.payoutBox2 = new System.Windows.Forms.TextBox();
            this.ptsBox6 = new System.Windows.Forms.TextBox();
            this.ptsBox5 = new System.Windows.Forms.TextBox();
            this.ptsBox4 = new System.Windows.Forms.TextBox();
            this.ptsBox3 = new System.Windows.Forms.TextBox();
            this.ptsBox2 = new System.Windows.Forms.TextBox();
            this.timeBox6 = new System.Windows.Forms.TextBox();
            this.timeBox5 = new System.Windows.Forms.TextBox();
            this.timeBox4 = new System.Windows.Forms.TextBox();
            this.timeBox3 = new System.Windows.Forms.TextBox();
            this.timeBox2 = new System.Windows.Forms.TextBox();
            this.numberBox6 = new System.Windows.Forms.TextBox();
            this.numberBox5 = new System.Windows.Forms.TextBox();
            this.numberBox4 = new System.Windows.Forms.TextBox();
            this.numberBox3 = new System.Windows.Forms.TextBox();
            this.numberBox2 = new System.Windows.Forms.TextBox();
            this.nameBox6 = new System.Windows.Forms.TextBox();
            this.nameBox5 = new System.Windows.Forms.TextBox();
            this.nameBox4 = new System.Windows.Forms.TextBox();
            this.nameBox3 = new System.Windows.Forms.TextBox();
            this.nameBox2 = new System.Windows.Forms.TextBox();
            this.payoutLabel = new System.Windows.Forms.Label();
            this.payoutBox1 = new System.Windows.Forms.TextBox();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.ptsBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.backNoLabel = new System.Windows.Forms.Label();
            this.timeBox1 = new System.Windows.Forms.TextBox();
            this.nameBox1 = new System.Windows.Forms.TextBox();
            this.numberBox1 = new System.Windows.Forms.TextBox();
            this.firstLabel = new System.Windows.Forms.Label();
            this.classListGroup.SuspendLayout();
            this.entryGroup.SuspendLayout();
            this.addEntryGroup.SuspendLayout();
            this.placingGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // showLabel
            // 
            this.showLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLabel.Location = new System.Drawing.Point(12, 9);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(250, 100);
            this.showLabel.TabIndex = 8;
            this.showLabel.Text = "Show Date\r\nNumber\r\nClass Name";
            this.showLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // classListGroup
            // 
            this.classListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classListGroup.Controls.Add(this.prevBtn);
            this.classListGroup.Controls.Add(this.nextBtn);
            this.classListGroup.Controls.Add(this.classListBox);
            this.classListGroup.Controls.Add(this.viewClassBtn);
            this.classListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classListGroup.Location = new System.Drawing.Point(12, 116);
            this.classListGroup.Name = "classListGroup";
            this.classListGroup.Size = new System.Drawing.Size(250, 359);
            this.classListGroup.TabIndex = 11;
            this.classListGroup.TabStop = false;
            this.classListGroup.Text = "Class List";
            // 
            // prevBtn
            // 
            this.prevBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevBtn.Location = new System.Drawing.Point(6, 328);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(55, 25);
            this.prevBtn.TabIndex = 14;
            this.prevBtn.TabStop = false;
            this.prevBtn.Text = "Prev";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextBtn.Location = new System.Drawing.Point(188, 328);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(55, 25);
            this.nextBtn.TabIndex = 13;
            this.nextBtn.TabStop = false;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
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
            this.classListBox.Size = new System.Drawing.Size(237, 297);
            this.classListBox.TabIndex = 12;
            this.classListBox.TabStop = false;
            this.classListBox.UseCompatibleStateImageBehavior = false;
            this.classListBox.View = System.Windows.Forms.View.Details;
            this.classListBox.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.classListBox_ColumnClick);
            this.classListBox.DoubleClick += new System.EventHandler(this.viewClassBtn_Click);
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
            this.viewClassBtn.Location = new System.Drawing.Point(67, 328);
            this.viewClassBtn.Name = "viewClassBtn";
            this.viewClassBtn.Size = new System.Drawing.Size(115, 25);
            this.viewClassBtn.TabIndex = 7;
            this.viewClassBtn.TabStop = false;
            this.viewClassBtn.Text = "View Class";
            this.viewClassBtn.UseVisualStyleBackColor = true;
            this.viewClassBtn.Click += new System.EventHandler(this.viewClassBtn_Click);
            // 
            // entryGroup
            // 
            this.entryGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryGroup.Controls.Add(this.totalBox);
            this.entryGroup.Controls.Add(this.totalLabel);
            this.entryGroup.Controls.Add(this.entryListBox);
            this.entryGroup.Controls.Add(this.removeEntryBtn);
            this.entryGroup.Controls.Add(this.viewNumber);
            this.entryGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryGroup.Location = new System.Drawing.Point(268, 12);
            this.entryGroup.Name = "entryGroup";
            this.entryGroup.Size = new System.Drawing.Size(443, 210);
            this.entryGroup.TabIndex = 12;
            this.entryGroup.TabStop = false;
            this.entryGroup.Text = "Registered Entries";
            // 
            // totalBox
            // 
            this.totalBox.Location = new System.Drawing.Point(367, 180);
            this.totalBox.Name = "totalBox";
            this.totalBox.ReadOnly = true;
            this.totalBox.Size = new System.Drawing.Size(69, 22);
            this.totalBox.TabIndex = 13;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(275, 183);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(86, 16);
            this.totalLabel.TabIndex = 12;
            this.totalLabel.Text = "Total Entries:";
            // 
            // entryListBox
            // 
            this.entryListBox.AllowColumnReorder = true;
            this.entryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.backNoHeader,
            this.riderHeader,
            this.horseHeader});
            this.entryListBox.FullRowSelect = true;
            this.entryListBox.LabelWrap = false;
            this.entryListBox.Location = new System.Drawing.Point(6, 25);
            this.entryListBox.MultiSelect = false;
            this.entryListBox.Name = "entryListBox";
            this.entryListBox.Size = new System.Drawing.Size(430, 148);
            this.entryListBox.TabIndex = 11;
            this.entryListBox.TabStop = false;
            this.entryListBox.UseCompatibleStateImageBehavior = false;
            this.entryListBox.View = System.Windows.Forms.View.Details;
            this.entryListBox.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.entryListBox_ColumnClick);
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
            // removeEntryBtn
            // 
            this.removeEntryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeEntryBtn.Location = new System.Drawing.Point(125, 179);
            this.removeEntryBtn.Name = "removeEntryBtn";
            this.removeEntryBtn.Size = new System.Drawing.Size(123, 25);
            this.removeEntryBtn.TabIndex = 6;
            this.removeEntryBtn.TabStop = false;
            this.removeEntryBtn.Text = "Remove Entry";
            this.removeEntryBtn.UseVisualStyleBackColor = true;
            this.removeEntryBtn.Click += new System.EventHandler(this.removeEntryBtn_Click);
            // 
            // viewNumber
            // 
            this.viewNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewNumber.Location = new System.Drawing.Point(6, 179);
            this.viewNumber.Name = "viewNumber";
            this.viewNumber.Size = new System.Drawing.Size(113, 25);
            this.viewNumber.TabIndex = 5;
            this.viewNumber.TabStop = false;
            this.viewNumber.Text = "View Number";
            this.viewNumber.UseVisualStyleBackColor = true;
            // 
            // addEntryGroup
            // 
            this.addEntryGroup.Controls.Add(this.listBtn);
            this.addEntryGroup.Controls.Add(this.manualBtn);
            this.addEntryGroup.Controls.Add(this.entryBox);
            this.addEntryGroup.Controls.Add(this.label1);
            this.addEntryGroup.Controls.Add(this.manualBox);
            this.addEntryGroup.Controls.Add(this.manualEntryLabel);
            this.addEntryGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEntryGroup.Location = new System.Drawing.Point(717, 12);
            this.addEntryGroup.Name = "addEntryGroup";
            this.addEntryGroup.Size = new System.Drawing.Size(180, 210);
            this.addEntryGroup.TabIndex = 13;
            this.addEntryGroup.TabStop = false;
            this.addEntryGroup.Text = "Add Entries";
            // 
            // listBtn
            // 
            this.listBtn.Location = new System.Drawing.Point(9, 179);
            this.listBtn.Name = "listBtn";
            this.listBtn.Size = new System.Drawing.Size(165, 25);
            this.listBtn.TabIndex = 4;
            this.listBtn.Text = "Add Entry";
            this.listBtn.UseVisualStyleBackColor = true;
            this.listBtn.Click += new System.EventHandler(this.listBtn_Click);
            // 
            // manualBtn
            // 
            this.manualBtn.Location = new System.Drawing.Point(9, 72);
            this.manualBtn.Name = "manualBtn";
            this.manualBtn.Size = new System.Drawing.Size(165, 25);
            this.manualBtn.TabIndex = 2;
            this.manualBtn.Text = "Add Entry";
            this.manualBtn.UseVisualStyleBackColor = true;
            this.manualBtn.Click += new System.EventHandler(this.manualBtn_Click);
            // 
            // entryBox
            // 
            this.entryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entryBox.DropDownWidth = 265;
            this.entryBox.FormattingEnabled = true;
            this.entryBox.Location = new System.Drawing.Point(9, 149);
            this.entryBox.Name = "entryBox";
            this.entryBox.Size = new System.Drawing.Size(165, 24);
            this.entryBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "OR\r\nSelect From Drop Down:";
            // 
            // manualBox
            // 
            this.manualBox.Location = new System.Drawing.Point(9, 44);
            this.manualBox.Name = "manualBox";
            this.manualBox.Size = new System.Drawing.Size(165, 22);
            this.manualBox.TabIndex = 1;
            // 
            // manualEntryLabel
            // 
            this.manualEntryLabel.AutoSize = true;
            this.manualEntryLabel.Location = new System.Drawing.Point(6, 25);
            this.manualEntryLabel.Name = "manualEntryLabel";
            this.manualEntryLabel.Size = new System.Drawing.Size(127, 16);
            this.manualEntryLabel.TabIndex = 0;
            this.manualEntryLabel.Text = "Enter Back Number:";
            // 
            // placingGroup
            // 
            this.placingGroup.Controls.Add(this.placeBtn);
            this.placingGroup.Controls.Add(this.sixthLabel);
            this.placingGroup.Controls.Add(this.fifthLabel);
            this.placingGroup.Controls.Add(this.fourthLabel);
            this.placingGroup.Controls.Add(this.thirdLabel);
            this.placingGroup.Controls.Add(this.secondLabel);
            this.placingGroup.Controls.Add(this.payoutBox6);
            this.placingGroup.Controls.Add(this.payoutBox5);
            this.placingGroup.Controls.Add(this.payoutBox4);
            this.placingGroup.Controls.Add(this.payoutBox3);
            this.placingGroup.Controls.Add(this.payoutBox2);
            this.placingGroup.Controls.Add(this.ptsBox6);
            this.placingGroup.Controls.Add(this.ptsBox5);
            this.placingGroup.Controls.Add(this.ptsBox4);
            this.placingGroup.Controls.Add(this.ptsBox3);
            this.placingGroup.Controls.Add(this.ptsBox2);
            this.placingGroup.Controls.Add(this.timeBox6);
            this.placingGroup.Controls.Add(this.timeBox5);
            this.placingGroup.Controls.Add(this.timeBox4);
            this.placingGroup.Controls.Add(this.timeBox3);
            this.placingGroup.Controls.Add(this.timeBox2);
            this.placingGroup.Controls.Add(this.numberBox6);
            this.placingGroup.Controls.Add(this.numberBox5);
            this.placingGroup.Controls.Add(this.numberBox4);
            this.placingGroup.Controls.Add(this.numberBox3);
            this.placingGroup.Controls.Add(this.numberBox2);
            this.placingGroup.Controls.Add(this.nameBox6);
            this.placingGroup.Controls.Add(this.nameBox5);
            this.placingGroup.Controls.Add(this.nameBox4);
            this.placingGroup.Controls.Add(this.nameBox3);
            this.placingGroup.Controls.Add(this.nameBox2);
            this.placingGroup.Controls.Add(this.payoutLabel);
            this.placingGroup.Controls.Add(this.payoutBox1);
            this.placingGroup.Controls.Add(this.pointsLabel);
            this.placingGroup.Controls.Add(this.ptsBox1);
            this.placingGroup.Controls.Add(this.label2);
            this.placingGroup.Controls.Add(this.nameLabel);
            this.placingGroup.Controls.Add(this.backNoLabel);
            this.placingGroup.Controls.Add(this.timeBox1);
            this.placingGroup.Controls.Add(this.nameBox1);
            this.placingGroup.Controls.Add(this.numberBox1);
            this.placingGroup.Controls.Add(this.firstLabel);
            this.placingGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placingGroup.Location = new System.Drawing.Point(268, 228);
            this.placingGroup.Name = "placingGroup";
            this.placingGroup.Size = new System.Drawing.Size(629, 247);
            this.placingGroup.TabIndex = 14;
            this.placingGroup.TabStop = false;
            this.placingGroup.Text = "Placings";
            // 
            // placeBtn
            // 
            this.placeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.placeBtn.Location = new System.Drawing.Point(458, 215);
            this.placeBtn.Name = "placeBtn";
            this.placeBtn.Size = new System.Drawing.Size(165, 25);
            this.placeBtn.TabIndex = 35;
            this.placeBtn.Text = "Assign Placings";
            this.placeBtn.UseVisualStyleBackColor = true;
            // 
            // sixthLabel
            // 
            this.sixthLabel.AutoSize = true;
            this.sixthLabel.Location = new System.Drawing.Point(6, 190);
            this.sixthLabel.Name = "sixthLabel";
            this.sixthLabel.Size = new System.Drawing.Size(25, 16);
            this.sixthLabel.TabIndex = 40;
            this.sixthLabel.Text = "6th";
            // 
            // fifthLabel
            // 
            this.fifthLabel.AutoSize = true;
            this.fifthLabel.Location = new System.Drawing.Point(6, 162);
            this.fifthLabel.Name = "fifthLabel";
            this.fifthLabel.Size = new System.Drawing.Size(25, 16);
            this.fifthLabel.TabIndex = 39;
            this.fifthLabel.Text = "5th";
            // 
            // fourthLabel
            // 
            this.fourthLabel.AutoSize = true;
            this.fourthLabel.Location = new System.Drawing.Point(6, 134);
            this.fourthLabel.Name = "fourthLabel";
            this.fourthLabel.Size = new System.Drawing.Size(25, 16);
            this.fourthLabel.TabIndex = 38;
            this.fourthLabel.Text = "4th";
            // 
            // thirdLabel
            // 
            this.thirdLabel.AutoSize = true;
            this.thirdLabel.Location = new System.Drawing.Point(6, 106);
            this.thirdLabel.Name = "thirdLabel";
            this.thirdLabel.Size = new System.Drawing.Size(27, 16);
            this.thirdLabel.TabIndex = 37;
            this.thirdLabel.Text = "3rd";
            // 
            // secondLabel
            // 
            this.secondLabel.AutoSize = true;
            this.secondLabel.Location = new System.Drawing.Point(6, 78);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(30, 16);
            this.secondLabel.TabIndex = 36;
            this.secondLabel.Text = "2nd";
            // 
            // payoutBox6
            // 
            this.payoutBox6.Location = new System.Drawing.Point(539, 187);
            this.payoutBox6.Name = "payoutBox6";
            this.payoutBox6.Size = new System.Drawing.Size(84, 22);
            this.payoutBox6.TabIndex = 34;
            // 
            // payoutBox5
            // 
            this.payoutBox5.Location = new System.Drawing.Point(539, 159);
            this.payoutBox5.Name = "payoutBox5";
            this.payoutBox5.Size = new System.Drawing.Size(84, 22);
            this.payoutBox5.TabIndex = 29;
            // 
            // payoutBox4
            // 
            this.payoutBox4.Location = new System.Drawing.Point(539, 131);
            this.payoutBox4.Name = "payoutBox4";
            this.payoutBox4.Size = new System.Drawing.Size(84, 22);
            this.payoutBox4.TabIndex = 24;
            // 
            // payoutBox3
            // 
            this.payoutBox3.Location = new System.Drawing.Point(539, 103);
            this.payoutBox3.Name = "payoutBox3";
            this.payoutBox3.Size = new System.Drawing.Size(84, 22);
            this.payoutBox3.TabIndex = 19;
            // 
            // payoutBox2
            // 
            this.payoutBox2.Location = new System.Drawing.Point(539, 75);
            this.payoutBox2.Name = "payoutBox2";
            this.payoutBox2.Size = new System.Drawing.Size(84, 22);
            this.payoutBox2.TabIndex = 14;
            // 
            // ptsBox6
            // 
            this.ptsBox6.Location = new System.Drawing.Point(506, 187);
            this.ptsBox6.Name = "ptsBox6";
            this.ptsBox6.Size = new System.Drawing.Size(27, 22);
            this.ptsBox6.TabIndex = 33;
            // 
            // ptsBox5
            // 
            this.ptsBox5.Location = new System.Drawing.Point(506, 159);
            this.ptsBox5.Name = "ptsBox5";
            this.ptsBox5.Size = new System.Drawing.Size(27, 22);
            this.ptsBox5.TabIndex = 28;
            // 
            // ptsBox4
            // 
            this.ptsBox4.Location = new System.Drawing.Point(506, 131);
            this.ptsBox4.Name = "ptsBox4";
            this.ptsBox4.Size = new System.Drawing.Size(27, 22);
            this.ptsBox4.TabIndex = 23;
            // 
            // ptsBox3
            // 
            this.ptsBox3.Location = new System.Drawing.Point(506, 103);
            this.ptsBox3.Name = "ptsBox3";
            this.ptsBox3.Size = new System.Drawing.Size(27, 22);
            this.ptsBox3.TabIndex = 18;
            // 
            // ptsBox2
            // 
            this.ptsBox2.Location = new System.Drawing.Point(506, 75);
            this.ptsBox2.Name = "ptsBox2";
            this.ptsBox2.Size = new System.Drawing.Size(27, 22);
            this.ptsBox2.TabIndex = 13;
            // 
            // timeBox6
            // 
            this.timeBox6.Location = new System.Drawing.Point(442, 187);
            this.timeBox6.Name = "timeBox6";
            this.timeBox6.Size = new System.Drawing.Size(58, 22);
            this.timeBox6.TabIndex = 32;
            // 
            // timeBox5
            // 
            this.timeBox5.Location = new System.Drawing.Point(442, 159);
            this.timeBox5.Name = "timeBox5";
            this.timeBox5.Size = new System.Drawing.Size(58, 22);
            this.timeBox5.TabIndex = 27;
            // 
            // timeBox4
            // 
            this.timeBox4.Location = new System.Drawing.Point(442, 131);
            this.timeBox4.Name = "timeBox4";
            this.timeBox4.Size = new System.Drawing.Size(58, 22);
            this.timeBox4.TabIndex = 22;
            // 
            // timeBox3
            // 
            this.timeBox3.Location = new System.Drawing.Point(442, 103);
            this.timeBox3.Name = "timeBox3";
            this.timeBox3.Size = new System.Drawing.Size(58, 22);
            this.timeBox3.TabIndex = 17;
            // 
            // timeBox2
            // 
            this.timeBox2.Location = new System.Drawing.Point(442, 75);
            this.timeBox2.Name = "timeBox2";
            this.timeBox2.Size = new System.Drawing.Size(58, 22);
            this.timeBox2.TabIndex = 12;
            // 
            // numberBox6
            // 
            this.numberBox6.Location = new System.Drawing.Point(37, 187);
            this.numberBox6.Name = "numberBox6";
            this.numberBox6.Size = new System.Drawing.Size(60, 22);
            this.numberBox6.TabIndex = 30;
            // 
            // numberBox5
            // 
            this.numberBox5.Location = new System.Drawing.Point(37, 159);
            this.numberBox5.Name = "numberBox5";
            this.numberBox5.Size = new System.Drawing.Size(60, 22);
            this.numberBox5.TabIndex = 25;
            // 
            // numberBox4
            // 
            this.numberBox4.Location = new System.Drawing.Point(37, 131);
            this.numberBox4.Name = "numberBox4";
            this.numberBox4.Size = new System.Drawing.Size(60, 22);
            this.numberBox4.TabIndex = 20;
            // 
            // numberBox3
            // 
            this.numberBox3.Location = new System.Drawing.Point(37, 103);
            this.numberBox3.Name = "numberBox3";
            this.numberBox3.Size = new System.Drawing.Size(60, 22);
            this.numberBox3.TabIndex = 15;
            // 
            // numberBox2
            // 
            this.numberBox2.Location = new System.Drawing.Point(37, 75);
            this.numberBox2.Name = "numberBox2";
            this.numberBox2.Size = new System.Drawing.Size(60, 22);
            this.numberBox2.TabIndex = 10;
            // 
            // nameBox6
            // 
            this.nameBox6.Location = new System.Drawing.Point(103, 187);
            this.nameBox6.Name = "nameBox6";
            this.nameBox6.ReadOnly = true;
            this.nameBox6.Size = new System.Drawing.Size(333, 22);
            this.nameBox6.TabIndex = 31;
            // 
            // nameBox5
            // 
            this.nameBox5.Location = new System.Drawing.Point(103, 159);
            this.nameBox5.Name = "nameBox5";
            this.nameBox5.ReadOnly = true;
            this.nameBox5.Size = new System.Drawing.Size(333, 22);
            this.nameBox5.TabIndex = 26;
            // 
            // nameBox4
            // 
            this.nameBox4.Location = new System.Drawing.Point(103, 131);
            this.nameBox4.Name = "nameBox4";
            this.nameBox4.ReadOnly = true;
            this.nameBox4.Size = new System.Drawing.Size(333, 22);
            this.nameBox4.TabIndex = 21;
            // 
            // nameBox3
            // 
            this.nameBox3.Location = new System.Drawing.Point(103, 103);
            this.nameBox3.Name = "nameBox3";
            this.nameBox3.ReadOnly = true;
            this.nameBox3.Size = new System.Drawing.Size(333, 22);
            this.nameBox3.TabIndex = 16;
            // 
            // nameBox2
            // 
            this.nameBox2.Location = new System.Drawing.Point(103, 75);
            this.nameBox2.Name = "nameBox2";
            this.nameBox2.ReadOnly = true;
            this.nameBox2.Size = new System.Drawing.Size(333, 22);
            this.nameBox2.TabIndex = 11;
            // 
            // payoutLabel
            // 
            this.payoutLabel.AutoSize = true;
            this.payoutLabel.Location = new System.Drawing.Point(539, 28);
            this.payoutLabel.Name = "payoutLabel";
            this.payoutLabel.Size = new System.Drawing.Size(50, 16);
            this.payoutLabel.TabIndex = 10;
            this.payoutLabel.Text = "Payout";
            // 
            // payoutBox1
            // 
            this.payoutBox1.Location = new System.Drawing.Point(539, 47);
            this.payoutBox1.Name = "payoutBox1";
            this.payoutBox1.Size = new System.Drawing.Size(84, 22);
            this.payoutBox1.TabIndex = 9;
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(503, 28);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(30, 16);
            this.pointsLabel.TabIndex = 8;
            this.pointsLabel.Text = "Pts.";
            // 
            // ptsBox1
            // 
            this.ptsBox1.Location = new System.Drawing.Point(506, 47);
            this.ptsBox1.Name = "ptsBox1";
            this.ptsBox1.Size = new System.Drawing.Size(27, 22);
            this.ptsBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(103, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(88, 16);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Rider / Horse";
            // 
            // backNoLabel
            // 
            this.backNoLabel.AutoSize = true;
            this.backNoLabel.Location = new System.Drawing.Point(34, 28);
            this.backNoLabel.Name = "backNoLabel";
            this.backNoLabel.Size = new System.Drawing.Size(63, 16);
            this.backNoLabel.TabIndex = 4;
            this.backNoLabel.Text = "Back No.";
            // 
            // timeBox1
            // 
            this.timeBox1.Location = new System.Drawing.Point(442, 47);
            this.timeBox1.Name = "timeBox1";
            this.timeBox1.Size = new System.Drawing.Size(58, 22);
            this.timeBox1.TabIndex = 7;
            // 
            // nameBox1
            // 
            this.nameBox1.Location = new System.Drawing.Point(103, 47);
            this.nameBox1.Name = "nameBox1";
            this.nameBox1.ReadOnly = true;
            this.nameBox1.Size = new System.Drawing.Size(333, 22);
            this.nameBox1.TabIndex = 6;
            // 
            // numberBox1
            // 
            this.numberBox1.Location = new System.Drawing.Point(37, 47);
            this.numberBox1.Name = "numberBox1";
            this.numberBox1.Size = new System.Drawing.Size(60, 22);
            this.numberBox1.TabIndex = 5;
            // 
            // firstLabel
            // 
            this.firstLabel.AutoSize = true;
            this.firstLabel.Location = new System.Drawing.Point(6, 50);
            this.firstLabel.Name = "firstLabel";
            this.firstLabel.Size = new System.Drawing.Size(25, 16);
            this.firstLabel.TabIndex = 0;
            this.firstLabel.Text = "1st";
            // 
            // ClassInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.placingGroup);
            this.Controls.Add(this.addEntryGroup);
            this.Controls.Add(this.entryGroup);
            this.Controls.Add(this.classListGroup);
            this.Controls.Add(this.showLabel);
            this.Name = "ClassInstanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TrotTrax";
            this.classListGroup.ResumeLayout(false);
            this.entryGroup.ResumeLayout(false);
            this.entryGroup.PerformLayout();
            this.addEntryGroup.ResumeLayout(false);
            this.addEntryGroup.PerformLayout();
            this.placingGroup.ResumeLayout(false);
            this.placingGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label showLabel;
        private System.Windows.Forms.GroupBox classListGroup;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.ListView classListBox;
        private System.Windows.Forms.ColumnHeader classNoHeader;
        private System.Windows.Forms.ColumnHeader classNameHeader;
        private System.Windows.Forms.Button viewClassBtn;
        private System.Windows.Forms.GroupBox entryGroup;
        private System.Windows.Forms.ListView entryListBox;
        private System.Windows.Forms.ColumnHeader backNoHeader;
        private System.Windows.Forms.ColumnHeader riderHeader;
        private System.Windows.Forms.ColumnHeader horseHeader;
        private System.Windows.Forms.Button removeEntryBtn;
        private System.Windows.Forms.Button viewNumber;
        private System.Windows.Forms.GroupBox addEntryGroup;
        private System.Windows.Forms.Button listBtn;
        private System.Windows.Forms.Button manualBtn;
        private System.Windows.Forms.ComboBox entryBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox manualBox;
        private System.Windows.Forms.Label manualEntryLabel;
        private System.Windows.Forms.GroupBox placingGroup;
        private System.Windows.Forms.Label sixthLabel;
        private System.Windows.Forms.Label fifthLabel;
        private System.Windows.Forms.Label fourthLabel;
        private System.Windows.Forms.Label thirdLabel;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.TextBox payoutBox6;
        private System.Windows.Forms.TextBox payoutBox5;
        private System.Windows.Forms.TextBox payoutBox4;
        private System.Windows.Forms.TextBox payoutBox3;
        private System.Windows.Forms.TextBox payoutBox2;
        private System.Windows.Forms.TextBox ptsBox6;
        private System.Windows.Forms.TextBox ptsBox5;
        private System.Windows.Forms.TextBox ptsBox4;
        private System.Windows.Forms.TextBox ptsBox3;
        private System.Windows.Forms.TextBox ptsBox2;
        private System.Windows.Forms.TextBox timeBox6;
        private System.Windows.Forms.TextBox timeBox5;
        private System.Windows.Forms.TextBox timeBox4;
        private System.Windows.Forms.TextBox timeBox3;
        private System.Windows.Forms.TextBox timeBox2;
        private System.Windows.Forms.TextBox numberBox6;
        private System.Windows.Forms.TextBox numberBox5;
        private System.Windows.Forms.TextBox numberBox4;
        private System.Windows.Forms.TextBox numberBox3;
        private System.Windows.Forms.TextBox numberBox2;
        private System.Windows.Forms.TextBox nameBox6;
        private System.Windows.Forms.TextBox nameBox5;
        private System.Windows.Forms.TextBox nameBox4;
        private System.Windows.Forms.TextBox nameBox3;
        private System.Windows.Forms.TextBox nameBox2;
        private System.Windows.Forms.Label payoutLabel;
        private System.Windows.Forms.TextBox payoutBox1;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.TextBox ptsBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label backNoLabel;
        private System.Windows.Forms.TextBox timeBox1;
        private System.Windows.Forms.TextBox nameBox1;
        private System.Windows.Forms.TextBox numberBox1;
        private System.Windows.Forms.Label firstLabel;
        private System.Windows.Forms.Button placeBtn;
        private System.Windows.Forms.TextBox totalBox;
        private System.Windows.Forms.Label totalLabel;
    }
}