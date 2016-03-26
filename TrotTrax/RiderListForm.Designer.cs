/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */
 
 namespace TrotTrax
{
    partial class RiderListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RiderListForm));
            this.riderLabel = new System.Windows.Forms.Label();
            this.riderListGroup = new System.Windows.Forms.GroupBox();
            this.riderListBox = new System.Windows.Forms.ListView();
            this.noHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.riderFirstHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.riderLastHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addRiderBtn = new System.Windows.Forms.Button();
            this.viewRiderBtn = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.commentsBox = new System.Windows.Forms.TextBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.memberCheckBox = new System.Windows.Forms.CheckBox();
            this.ageBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.birthdayLabel = new System.Windows.Forms.Label();
            this.birthdayPicker = new System.Windows.Forms.DateTimePicker();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.showNoLabel = new System.Windows.Forms.Label();
            this.horseBox = new System.Windows.Forms.GroupBox();
            this.backNoLabel = new System.Windows.Forms.Label();
            this.backNoBox = new System.Windows.Forms.TextBox();
            this.horseComboBox = new System.Windows.Forms.ComboBox();
            this.addBackNoBtn = new System.Windows.Forms.Button();
            this.horseListBox = new System.Windows.Forms.ListView();
            this.backNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.horseNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewBackNoBtn = new System.Windows.Forms.Button();
            this.riderListGroup.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.horseBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // riderLabel
            // 
            this.riderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.riderLabel.Location = new System.Drawing.Point(12, 9);
            this.riderLabel.Name = "riderLabel";
            this.riderLabel.Size = new System.Drawing.Size(225, 80);
            this.riderLabel.TabIndex = 0;
            this.riderLabel.Text = "New Rider Setup";
            this.riderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // riderListGroup
            // 
            this.riderListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.riderListGroup.Controls.Add(this.riderListBox);
            this.riderListGroup.Controls.Add(this.addRiderBtn);
            this.riderListGroup.Controls.Add(this.viewRiderBtn);
            this.riderListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.riderListGroup.Location = new System.Drawing.Point(12, 92);
            this.riderListGroup.Name = "riderListGroup";
            this.riderListGroup.Size = new System.Drawing.Size(225, 386);
            this.riderListGroup.TabIndex = 10;
            this.riderListGroup.TabStop = false;
            this.riderListGroup.Text = "Rider List";
            // 
            // riderListBox
            // 
            this.riderListBox.AllowColumnReorder = true;
            this.riderListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.riderListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.noHeader,
            this.riderFirstHeader,
            this.riderLastHeader});
            this.riderListBox.FullRowSelect = true;
            this.riderListBox.LabelWrap = false;
            this.riderListBox.Location = new System.Drawing.Point(7, 21);
            this.riderListBox.MultiSelect = false;
            this.riderListBox.Name = "riderListBox";
            this.riderListBox.Size = new System.Drawing.Size(212, 328);
            this.riderListBox.TabIndex = 0;
            this.riderListBox.UseCompatibleStateImageBehavior = false;
            this.riderListBox.View = System.Windows.Forms.View.Details;
            this.riderListBox.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortRiderList);
            this.riderListBox.DoubleClick += new System.EventHandler(this.ViewRider);
            // 
            // noHeader
            // 
            this.noHeader.Width = 0;
            // 
            // riderFirstHeader
            // 
            this.riderFirstHeader.Text = "First Name";
            this.riderFirstHeader.Width = 86;
            // 
            // riderLastHeader
            // 
            this.riderLastHeader.Text = "Last Name";
            this.riderLastHeader.Width = 95;
            // 
            // addRiderBtn
            // 
            this.addRiderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addRiderBtn.Location = new System.Drawing.Point(109, 355);
            this.addRiderBtn.Name = "addRiderBtn";
            this.addRiderBtn.Size = new System.Drawing.Size(110, 25);
            this.addRiderBtn.TabIndex = 0;
            this.addRiderBtn.TabStop = false;
            this.addRiderBtn.Text = "New Rider";
            this.addRiderBtn.UseVisualStyleBackColor = true;
            this.addRiderBtn.Click += new System.EventHandler(this.NewRider);
            // 
            // viewRiderBtn
            // 
            this.viewRiderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewRiderBtn.Location = new System.Drawing.Point(7, 355);
            this.viewRiderBtn.Name = "viewRiderBtn";
            this.viewRiderBtn.Size = new System.Drawing.Size(95, 25);
            this.viewRiderBtn.TabIndex = 0;
            this.viewRiderBtn.TabStop = false;
            this.viewRiderBtn.Text = "View Rider";
            this.viewRiderBtn.UseVisualStyleBackColor = true;
            this.viewRiderBtn.Click += new System.EventHandler(this.ViewRider);
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.commentsLabel);
            this.infoBox.Controls.Add(this.commentsBox);
            this.infoBox.Controls.Add(this.emailBox);
            this.infoBox.Controls.Add(this.emailLabel);
            this.infoBox.Controls.Add(this.cancelBtn);
            this.infoBox.Controls.Add(this.phoneBox);
            this.infoBox.Controls.Add(this.phoneLabel);
            this.infoBox.Controls.Add(this.memberCheckBox);
            this.infoBox.Controls.Add(this.ageBox);
            this.infoBox.Controls.Add(this.label1);
            this.infoBox.Controls.Add(this.birthdayLabel);
            this.infoBox.Controls.Add(this.birthdayPicker);
            this.infoBox.Controls.Add(this.lastNameBox);
            this.infoBox.Controls.Add(this.lastNameLabel);
            this.infoBox.Controls.Add(this.deleteBtn);
            this.infoBox.Controls.Add(this.modifyBtn);
            this.infoBox.Controls.Add(this.firstNameBox);
            this.infoBox.Controls.Add(this.firstNameLabel);
            this.infoBox.Controls.Add(this.numberBox);
            this.infoBox.Controls.Add(this.showNoLabel);
            this.infoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.Location = new System.Drawing.Point(243, 12);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(422, 466);
            this.infoBox.TabIndex = 11;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Rider Information";
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(7, 223);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(72, 16);
            this.commentsLabel.TabIndex = 0;
            this.commentsLabel.Text = "Comments";
            // 
            // commentsBox
            // 
            this.commentsBox.Location = new System.Drawing.Point(9, 242);
            this.commentsBox.Multiline = true;
            this.commentsBox.Name = "commentsBox";
            this.commentsBox.Size = new System.Drawing.Size(407, 187);
            this.commentsBox.TabIndex = 8;
            this.commentsBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(156, 189);
            this.emailBox.MaxLength = 255;
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(260, 22);
            this.emailBox.TabIndex = 7;
            this.emailBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(153, 170);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(45, 16);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "E Mail";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(284, 435);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(132, 25);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelChanges);
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(9, 189);
            this.phoneBox.MaxLength = 255;
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(141, 22);
            this.phoneBox.TabIndex = 6;
            this.phoneBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(6, 170);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(98, 16);
            this.phoneLabel.TabIndex = 0;
            this.phoneLabel.Text = "Phone Number";
            // 
            // memberCheckBox
            // 
            this.memberCheckBox.AutoSize = true;
            this.memberCheckBox.Location = new System.Drawing.Point(308, 136);
            this.memberCheckBox.Name = "memberCheckBox";
            this.memberCheckBox.Size = new System.Drawing.Size(108, 20);
            this.memberCheckBox.TabIndex = 5;
            this.memberCheckBox.Text = "Paid Member";
            this.memberCheckBox.UseVisualStyleBackColor = true;
            this.memberCheckBox.CheckedChanged += new System.EventHandler(this.DataChanged);
            this.memberCheckBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToggleMember);
            // 
            // ageBox
            // 
            this.ageBox.Location = new System.Drawing.Point(203, 138);
            this.ageBox.MaxLength = 255;
            this.ageBox.Name = "ageBox";
            this.ageBox.ReadOnly = true;
            this.ageBox.Size = new System.Drawing.Size(86, 22);
            this.ageBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Age on Jan. 1";
            // 
            // birthdayLabel
            // 
            this.birthdayLabel.AutoSize = true;
            this.birthdayLabel.Location = new System.Drawing.Point(6, 117);
            this.birthdayLabel.Name = "birthdayLabel";
            this.birthdayLabel.Size = new System.Drawing.Size(66, 16);
            this.birthdayLabel.TabIndex = 0;
            this.birthdayLabel.Text = "Birth Date";
            // 
            // birthdayPicker
            // 
            this.birthdayPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdayPicker.Location = new System.Drawing.Point(9, 136);
            this.birthdayPicker.Name = "birthdayPicker";
            this.birthdayPicker.Size = new System.Drawing.Size(188, 22);
            this.birthdayPicker.TabIndex = 4;
            this.birthdayPicker.Value = new System.DateTime(2015, 8, 10, 20, 26, 32, 0);
            this.birthdayPicker.ValueChanged += new System.EventHandler(this.DataChanged);
            // 
            // lastNameBox
            // 
            this.lastNameBox.BackColor = System.Drawing.SystemColors.Window;
            this.lastNameBox.Location = new System.Drawing.Point(203, 88);
            this.lastNameBox.MaxLength = 255;
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(213, 22);
            this.lastNameBox.TabIndex = 3;
            this.lastNameBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(200, 69);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(78, 16);
            this.lastNameLabel.TabIndex = 0;
            this.lastNameLabel.Text = "Last Name*";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(146, 435);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(132, 25);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteRider);
            // 
            // modifyBtn
            // 
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.modifyBtn.Location = new System.Drawing.Point(6, 435);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(134, 25);
            this.modifyBtn.TabIndex = 9;
            this.modifyBtn.Text = "Save Changes";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.SaveRider);
            // 
            // firstNameBox
            // 
            this.firstNameBox.BackColor = System.Drawing.SystemColors.Window;
            this.firstNameBox.Location = new System.Drawing.Point(9, 88);
            this.firstNameBox.MaxLength = 255;
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(188, 22);
            this.firstNameBox.TabIndex = 2;
            this.firstNameBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(6, 69);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(78, 16);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First Name*";
            // 
            // numberBox
            // 
            this.numberBox.BackColor = System.Drawing.SystemColors.Control;
            this.numberBox.Location = new System.Drawing.Point(9, 44);
            this.numberBox.Name = "numberBox";
            this.numberBox.ReadOnly = true;
            this.numberBox.Size = new System.Drawing.Size(89, 22);
            this.numberBox.TabIndex = 1;
            // 
            // showNoLabel
            // 
            this.showNoLabel.AutoSize = true;
            this.showNoLabel.Location = new System.Drawing.Point(6, 25);
            this.showNoLabel.Name = "showNoLabel";
            this.showNoLabel.Size = new System.Drawing.Size(92, 16);
            this.showNoLabel.TabIndex = 0;
            this.showNoLabel.Text = "Rider Number";
            // 
            // horseBox
            // 
            this.horseBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.horseBox.Controls.Add(this.backNoLabel);
            this.horseBox.Controls.Add(this.backNoBox);
            this.horseBox.Controls.Add(this.horseComboBox);
            this.horseBox.Controls.Add(this.addBackNoBtn);
            this.horseBox.Controls.Add(this.horseListBox);
            this.horseBox.Controls.Add(this.viewBackNoBtn);
            this.horseBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horseBox.Location = new System.Drawing.Point(671, 12);
            this.horseBox.Name = "horseBox";
            this.horseBox.Size = new System.Drawing.Size(226, 466);
            this.horseBox.TabIndex = 14;
            this.horseBox.TabStop = false;
            this.horseBox.Text = "Horses Shown";
            // 
            // backNoLabel
            // 
            this.backNoLabel.AutoSize = true;
            this.backNoLabel.Location = new System.Drawing.Point(6, 380);
            this.backNoLabel.Name = "backNoLabel";
            this.backNoLabel.Size = new System.Drawing.Size(63, 16);
            this.backNoLabel.TabIndex = 4;
            this.backNoLabel.Text = "Back No.";
            // 
            // backNoBox
            // 
            this.backNoBox.Location = new System.Drawing.Point(75, 377);
            this.backNoBox.Name = "backNoBox";
            this.backNoBox.Size = new System.Drawing.Size(145, 22);
            this.backNoBox.TabIndex = 12;
            this.backNoBox.TextChanged += new System.EventHandler(this.HorseChanged);
            // 
            // horseComboBox
            // 
            this.horseComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.horseComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.horseComboBox.FormattingEnabled = true;
            this.horseComboBox.Location = new System.Drawing.Point(7, 405);
            this.horseComboBox.Name = "horseComboBox";
            this.horseComboBox.Size = new System.Drawing.Size(213, 24);
            this.horseComboBox.TabIndex = 13;
            this.horseComboBox.SelectedIndexChanged += new System.EventHandler(this.HorseChanged);
            // 
            // addBackNoBtn
            // 
            this.addBackNoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addBackNoBtn.Location = new System.Drawing.Point(7, 435);
            this.addBackNoBtn.Name = "addBackNoBtn";
            this.addBackNoBtn.Size = new System.Drawing.Size(213, 25);
            this.addBackNoBtn.TabIndex = 14;
            this.addBackNoBtn.Text = "Add Back No.";
            this.addBackNoBtn.UseVisualStyleBackColor = true;
            this.addBackNoBtn.Click += new System.EventHandler(this.AddBackNo);
            // 
            // horseListBox
            // 
            this.horseListBox.AllowColumnReorder = true;
            this.horseListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.horseListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.backNoHeader,
            this.horseNameHeader});
            this.horseListBox.FullRowSelect = true;
            this.horseListBox.LabelWrap = false;
            this.horseListBox.Location = new System.Drawing.Point(7, 21);
            this.horseListBox.MultiSelect = false;
            this.horseListBox.Name = "horseListBox";
            this.horseListBox.Size = new System.Drawing.Size(213, 319);
            this.horseListBox.TabIndex = 0;
            this.horseListBox.TabStop = false;
            this.horseListBox.UseCompatibleStateImageBehavior = false;
            this.horseListBox.View = System.Windows.Forms.View.Details;
            this.horseListBox.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortHorseList);
            this.horseListBox.DoubleClick += new System.EventHandler(this.ViewBackNo);
            // 
            // backNoHeader
            // 
            this.backNoHeader.Text = "No.";
            this.backNoHeader.Width = 40;
            // 
            // horseNameHeader
            // 
            this.horseNameHeader.Text = "Name";
            this.horseNameHeader.Width = 145;
            // 
            // viewBackNoBtn
            // 
            this.viewBackNoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewBackNoBtn.Location = new System.Drawing.Point(7, 346);
            this.viewBackNoBtn.Name = "viewBackNoBtn";
            this.viewBackNoBtn.Size = new System.Drawing.Size(213, 25);
            this.viewBackNoBtn.TabIndex = 0;
            this.viewBackNoBtn.TabStop = false;
            this.viewBackNoBtn.Text = "View Back No. Detail";
            this.viewBackNoBtn.UseVisualStyleBackColor = true;
            this.viewBackNoBtn.Click += new System.EventHandler(this.ViewBackNo);
            // 
            // RiderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.horseBox);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.riderListGroup);
            this.Controls.Add(this.riderLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RiderListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Rider - TrotTrax";
            this.riderListGroup.ResumeLayout(false);
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.horseBox.ResumeLayout(false);
            this.horseBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label riderLabel;
        private System.Windows.Forms.GroupBox riderListGroup;
        private System.Windows.Forms.ListView riderListBox;
        private System.Windows.Forms.ColumnHeader riderFirstHeader;
        private System.Windows.Forms.ColumnHeader riderLastHeader;
        private System.Windows.Forms.Button addRiderBtn;
        private System.Windows.Forms.Button viewRiderBtn;
        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.Label showNoLabel;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.CheckBox memberCheckBox;
        private System.Windows.Forms.TextBox ageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label birthdayLabel;
        private System.Windows.Forms.DateTimePicker birthdayPicker;
        private System.Windows.Forms.GroupBox horseBox;
        private System.Windows.Forms.ListView horseListBox;
        private System.Windows.Forms.ColumnHeader horseNameHeader;
        private System.Windows.Forms.Button viewBackNoBtn;
        private System.Windows.Forms.ColumnHeader noHeader;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.TextBox commentsBox;
        private System.Windows.Forms.ColumnHeader backNoHeader;
        private System.Windows.Forms.Button addBackNoBtn;
        private System.Windows.Forms.Label backNoLabel;
        private System.Windows.Forms.TextBox backNoBox;
        private System.Windows.Forms.ComboBox horseComboBox;
    }
}