﻿namespace TrotTrax
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
            this.showLabel = new System.Windows.Forms.Label();
            this.riderListGroup = new System.Windows.Forms.GroupBox();
            this.riderListBox = new System.Windows.Forms.ListView();
            this.addRiderBtn = new System.Windows.Forms.Button();
            this.viewRiderBtn = new System.Windows.Forms.Button();
            this.riderFirstHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.riderLastHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.showNoLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.birthdayLabel = new System.Windows.Forms.Label();
            this.birthdayPicker = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.entryGroup = new System.Windows.Forms.GroupBox();
            this.entryListBox = new System.Windows.Forms.ListView();
            this.backNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.horseHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewNumber = new System.Windows.Forms.Button();
            this.dateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.placeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.horseBox = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.horseNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.riderListGroup.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.entryGroup.SuspendLayout();
            this.horseBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // showLabel
            // 
            this.showLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLabel.Location = new System.Drawing.Point(12, 9);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(225, 80);
            this.showLabel.TabIndex = 9;
            this.showLabel.Text = "New Rider Detail";
            this.showLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // riderListGroup
            // 
            this.riderListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.riderListGroup.Controls.Add(this.riderListBox);
            this.riderListGroup.Controls.Add(this.addRiderBtn);
            this.riderListGroup.Controls.Add(this.viewRiderBtn);
            this.riderListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.riderListGroup.Location = new System.Drawing.Point(17, 92);
            this.riderListGroup.Name = "riderListGroup";
            this.riderListGroup.Size = new System.Drawing.Size(220, 383);
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
            this.riderFirstHeader,
            this.riderLastHeader});
            this.riderListBox.FullRowSelect = true;
            this.riderListBox.LabelWrap = false;
            this.riderListBox.Location = new System.Drawing.Point(7, 21);
            this.riderListBox.MultiSelect = false;
            this.riderListBox.Name = "riderListBox";
            this.riderListBox.Size = new System.Drawing.Size(207, 325);
            this.riderListBox.TabIndex = 13;
            this.riderListBox.UseCompatibleStateImageBehavior = false;
            this.riderListBox.View = System.Windows.Forms.View.Details;
            // 
            // addRiderBtn
            // 
            this.addRiderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addRiderBtn.Location = new System.Drawing.Point(109, 352);
            this.addRiderBtn.Name = "addRiderBtn";
            this.addRiderBtn.Size = new System.Drawing.Size(105, 25);
            this.addRiderBtn.TabIndex = 8;
            this.addRiderBtn.Text = "New Rider";
            this.addRiderBtn.UseVisualStyleBackColor = true;
            // 
            // viewRiderBtn
            // 
            this.viewRiderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewRiderBtn.Location = new System.Drawing.Point(7, 352);
            this.viewRiderBtn.Name = "viewRiderBtn";
            this.viewRiderBtn.Size = new System.Drawing.Size(95, 25);
            this.viewRiderBtn.TabIndex = 7;
            this.viewRiderBtn.Text = "View Rider";
            this.viewRiderBtn.UseVisualStyleBackColor = true;
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
            // infoBox
            // 
            this.infoBox.Controls.Add(this.textBox3);
            this.infoBox.Controls.Add(this.emailLabel);
            this.infoBox.Controls.Add(this.phoneBox);
            this.infoBox.Controls.Add(this.phoneLabel);
            this.infoBox.Controls.Add(this.checkBox1);
            this.infoBox.Controls.Add(this.textBox2);
            this.infoBox.Controls.Add(this.label1);
            this.infoBox.Controls.Add(this.birthdayLabel);
            this.infoBox.Controls.Add(this.birthdayPicker);
            this.infoBox.Controls.Add(this.textBox1);
            this.infoBox.Controls.Add(this.lastNameLabel);
            this.infoBox.Controls.Add(this.cancelBtn);
            this.infoBox.Controls.Add(this.deleteBtn);
            this.infoBox.Controls.Add(this.modifyBtn);
            this.infoBox.Controls.Add(this.descriptionBox);
            this.infoBox.Controls.Add(this.firstNameLabel);
            this.infoBox.Controls.Add(this.numberBox);
            this.infoBox.Controls.Add(this.showNoLabel);
            this.infoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.Location = new System.Drawing.Point(243, 12);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(422, 250);
            this.infoBox.TabIndex = 11;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Rider Information";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(267, 217);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 25);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(141, 217);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(120, 25);
            this.deleteBtn.TabIndex = 9;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(6, 217);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(129, 25);
            this.modifyBtn.TabIndex = 8;
            this.modifyBtn.Text = "Save Changes";
            this.modifyBtn.UseVisualStyleBackColor = true;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(9, 88);
            this.descriptionBox.MaxLength = 255;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(188, 22);
            this.descriptionBox.TabIndex = 5;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(6, 69);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(73, 16);
            this.firstNameLabel.TabIndex = 4;
            this.firstNameLabel.Text = "First Name";
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(203, 88);
            this.textBox1.MaxLength = 255;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 22);
            this.textBox1.TabIndex = 12;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(200, 69);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(73, 16);
            this.lastNameLabel.TabIndex = 11;
            this.lastNameLabel.Text = "Last Name";
            // 
            // birthdayLabel
            // 
            this.birthdayLabel.AutoSize = true;
            this.birthdayLabel.Location = new System.Drawing.Point(6, 117);
            this.birthdayLabel.Name = "birthdayLabel";
            this.birthdayLabel.Size = new System.Drawing.Size(66, 16);
            this.birthdayLabel.TabIndex = 16;
            this.birthdayLabel.Text = "Birth Date";
            // 
            // birthdayPicker
            // 
            this.birthdayPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdayPicker.Location = new System.Drawing.Point(9, 136);
            this.birthdayPicker.Name = "birthdayPicker";
            this.birthdayPicker.Size = new System.Drawing.Size(188, 22);
            this.birthdayPicker.TabIndex = 15;
            this.birthdayPicker.Value = new System.DateTime(2015, 8, 10, 20, 26, 32, 0);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(203, 138);
            this.textBox2.MaxLength = 255;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(86, 22);
            this.textBox2.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Age on Jan. 1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(308, 136);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 20);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Paid Member";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(156, 189);
            this.textBox3.MaxLength = 255;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(260, 22);
            this.textBox3.TabIndex = 23;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(153, 170);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(45, 16);
            this.emailLabel.TabIndex = 22;
            this.emailLabel.Text = "E Mail";
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(9, 189);
            this.phoneBox.MaxLength = 255;
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(141, 22);
            this.phoneBox.TabIndex = 21;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(6, 170);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(98, 16);
            this.phoneLabel.TabIndex = 20;
            this.phoneLabel.Text = "Phone Number";
            // 
            // entryGroup
            // 
            this.entryGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryGroup.Controls.Add(this.entryListBox);
            this.entryGroup.Controls.Add(this.viewNumber);
            this.entryGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryGroup.Location = new System.Drawing.Point(243, 268);
            this.entryGroup.Name = "entryGroup";
            this.entryGroup.Size = new System.Drawing.Size(654, 210);
            this.entryGroup.TabIndex = 13;
            this.entryGroup.TabStop = false;
            this.entryGroup.Text = "Class Entries";
            // 
            // entryListBox
            // 
            this.entryListBox.AllowColumnReorder = true;
            this.entryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.backNoHeader,
            this.horseHeader,
            this.dateHeader,
            this.classHeader,
            this.placeHeader});
            this.entryListBox.FullRowSelect = true;
            this.entryListBox.LabelWrap = false;
            this.entryListBox.Location = new System.Drawing.Point(6, 25);
            this.entryListBox.MultiSelect = false;
            this.entryListBox.Name = "entryListBox";
            this.entryListBox.Size = new System.Drawing.Size(642, 148);
            this.entryListBox.TabIndex = 11;
            this.entryListBox.TabStop = false;
            this.entryListBox.UseCompatibleStateImageBehavior = false;
            this.entryListBox.View = System.Windows.Forms.View.Details;
            // 
            // backNoHeader
            // 
            this.backNoHeader.Text = "Back No.";
            this.backNoHeader.Width = 70;
            // 
            // horseHeader
            // 
            this.horseHeader.Text = "Horse Name";
            this.horseHeader.Width = 184;
            // 
            // viewNumber
            // 
            this.viewNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewNumber.Location = new System.Drawing.Point(435, 179);
            this.viewNumber.Name = "viewNumber";
            this.viewNumber.Size = new System.Drawing.Size(213, 25);
            this.viewNumber.TabIndex = 5;
            this.viewNumber.TabStop = false;
            this.viewNumber.Text = "View Class";
            this.viewNumber.UseVisualStyleBackColor = true;
            // 
            // dateHeader
            // 
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 74;
            // 
            // classHeader
            // 
            this.classHeader.Text = "Class";
            this.classHeader.Width = 228;
            // 
            // placeHeader
            // 
            this.placeHeader.Text = "Place";
            // 
            // horseBox
            // 
            this.horseBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.horseBox.Controls.Add(this.listView1);
            this.horseBox.Controls.Add(this.button2);
            this.horseBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horseBox.Location = new System.Drawing.Point(671, 12);
            this.horseBox.Name = "horseBox";
            this.horseBox.Size = new System.Drawing.Size(226, 250);
            this.horseBox.TabIndex = 14;
            this.horseBox.TabStop = false;
            this.horseBox.Text = "Horses Shown";
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.horseNameHeader});
            this.listView1.FullRowSelect = true;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(7, 21);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(213, 192);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // horseNameHeader
            // 
            this.horseNameHeader.Text = "Name";
            this.horseNameHeader.Width = 188;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(7, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(213, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "View Horse";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // RiderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.horseBox);
            this.Controls.Add(this.entryGroup);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.riderListGroup);
            this.Controls.Add(this.showLabel);
            this.Name = "RiderListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Rider Detail - TrotTrax";
            this.riderListGroup.ResumeLayout(false);
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.entryGroup.ResumeLayout(false);
            this.horseBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label showLabel;
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
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.Label showNoLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label birthdayLabel;
        private System.Windows.Forms.DateTimePicker birthdayPicker;
        private System.Windows.Forms.GroupBox entryGroup;
        private System.Windows.Forms.ListView entryListBox;
        private System.Windows.Forms.ColumnHeader backNoHeader;
        private System.Windows.Forms.ColumnHeader horseHeader;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ColumnHeader classHeader;
        private System.Windows.Forms.ColumnHeader placeHeader;
        private System.Windows.Forms.Button viewNumber;
        private System.Windows.Forms.GroupBox horseBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader horseNameHeader;
        private System.Windows.Forms.Button button2;
    }
}