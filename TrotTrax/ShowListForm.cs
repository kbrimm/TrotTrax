﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrotTrax
{
    public partial class ShowListForm : Form
    {
        Show show;
        bool changed;
        bool isNew;

        public ShowListForm(int year, string clubID)
        {
            show = new Show(year, clubID);
            InitializeComponent();
            PopulateClassList();
            PopulateShowList(); 
            modifyBtn.Text = "Add New Show";
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            changed = false;
            isNew = true;
        }

        public ShowListForm(int year, string clubID, int showNo)
        {
            show = new Show(year, clubID, showNo);
            InitializeComponent();
            PopulateClassList();
            PopulateShowList();
            numberBox.Text = showNo.ToString();
            datePicker.Value = Convert.ToDateTime(show.date);
            descriptionBox.Text = show.description;
            commentsBox.Text = show.comments;
            showLabel.Text = show.date + "\r\nShow Detail";
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            changed = false;
            isNew = false;
        }

        private void PopulateClassList()
        {
            classListBox.Items.Clear();
            foreach (ClassItem entry in show.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateShowList()
        {
            showListBox.Items.Clear();
            foreach (ShowItem entry in show.showList)
            {
                string value;
                if (entry.description == "")
                    value = entry.date;
                else
                    value = entry.date + " - " + entry.description;
                    value = entry.date + " - " + entry.description;
                showListBox.Items.Add(value);
            }
        }

        private void commentsBox_TextChanged(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            changed = true;
        }

        private void descriptionBox_TextChanged(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            changed = true;
        }

        private void dateBox_ValueChanged(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            changed = true;
        }

        private bool abandonChanges()
        {
            DialogResult confirm = MessageBox.Show("Do you want to abandon your changes?",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void viewShowBtn_Click(object sender, EventArgs e)
        {
            bool loadNew = true;
            int showNo = -1;
            if (changed)
                loadNew = abandonChanges();
            if (loadNew)
            {
                if (showListBox.SelectedItems.Count != 0)
                {
                    string selectedShow = showListBox.SelectedItems[0].ToString();
                    selectedShow = selectedShow.Substring(15, 10);
                    foreach (ShowItem entry in show.showList)
                        if (entry.date == selectedShow)
                        {
                            showNo = entry.no;
                            break;
                        }
                }

                if (showNo >= 0)
                {
                    ShowListForm showList = new ShowListForm(show.year, show.clubID, showNo);
                    showList.Visible = true;
                }
                this.Close();
            }
        }

        private void addShowBtn_Click(object sender, EventArgs e)
        {
            bool loadNew = true;
            if (changed)
                loadNew = abandonChanges();
            if (loadNew)
            {
                ShowListForm showList = new ShowListForm(show.year, show.clubID);
                showList.Visible = true;
                this.Close();
            }
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                DateTime date = this.datePicker.Value;
                string dateString = date.ToString("MM/dd/yyyy");
                string description = this.descriptionBox.Text;
                string comments = this.commentsBox.Text;

                if (isNew)
                    show.AddShow(date, description, comments);
                else
                    show.ModifyShow(date, description, comments);
                ShowListForm showList = new ShowListForm(show.year, show.clubID, show.number);
                showList.Visible = true;
                this.Close();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if(!isNew)
            {
                DialogResult confirm = MessageBox.Show("Do you really want to remove this show and all of its data?",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    show.RemoveShow();
                    ShowListForm showList = new ShowListForm(show.year, show.clubID);
                    showList.Visible = true;
                    this.Close();
                }
            }
        }

        private void InitializeComponent()
        {
            this.showLabel = new System.Windows.Forms.Label();
            this.showListGroup = new System.Windows.Forms.GroupBox();
            this.showListBox = new System.Windows.Forms.ListView();
            this.showNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addShowBtn = new System.Windows.Forms.Button();
            this.viewShowBtn = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.showNoLabel = new System.Windows.Forms.Label();
            this.classListGroup = new System.Windows.Forms.GroupBox();
            this.classListBox = new System.Windows.Forms.ListView();
            this.classNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewClassBtn = new System.Windows.Forms.Button();
            this.commentsBox = new System.Windows.Forms.TextBox();
            this.showListGroup.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.classListGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // showLabel
            // 
            this.showLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLabel.Location = new System.Drawing.Point(12, 9);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(225, 80);
            this.showLabel.TabIndex = 6;
            this.showLabel.Text = "Show \r\nDetail";
            this.showLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // showListGroup
            // 
            this.showListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.showListGroup.Controls.Add(this.showListBox);
            this.showListGroup.Controls.Add(this.addShowBtn);
            this.showListGroup.Controls.Add(this.viewShowBtn);
            this.showListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showListGroup.Location = new System.Drawing.Point(17, 92);
            this.showListGroup.Name = "showListGroup";
            this.showListGroup.Size = new System.Drawing.Size(220, 383);
            this.showListGroup.TabIndex = 7;
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
            this.showListBox.Size = new System.Drawing.Size(207, 325);
            this.showListBox.TabIndex = 13;
            this.showListBox.UseCompatibleStateImageBehavior = false;
            this.showListBox.View = System.Windows.Forms.View.Details;
            this.showListBox.DoubleClick += new System.EventHandler(this.viewShowBtn_Click);
            // 
            // showNameHeader
            // 
            this.showNameHeader.Text = "Show Date";
            this.showNameHeader.Width = 197;
            // 
            // addShowBtn
            // 
            this.addShowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addShowBtn.Location = new System.Drawing.Point(109, 352);
            this.addShowBtn.Name = "addShowBtn";
            this.addShowBtn.Size = new System.Drawing.Size(105, 25);
            this.addShowBtn.TabIndex = 8;
            this.addShowBtn.Text = "New Show";
            this.addShowBtn.UseVisualStyleBackColor = true;
            this.addShowBtn.Click += new System.EventHandler(this.addShowBtn_Click);
            // 
            // viewShowBtn
            // 
            this.viewShowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewShowBtn.Location = new System.Drawing.Point(7, 352);
            this.viewShowBtn.Name = "viewShowBtn";
            this.viewShowBtn.Size = new System.Drawing.Size(95, 25);
            this.viewShowBtn.TabIndex = 7;
            this.viewShowBtn.Text = "View Show";
            this.viewShowBtn.UseVisualStyleBackColor = true;
            this.viewShowBtn.Click += new System.EventHandler(this.viewShowBtn_Click);
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.cancelBtn);
            this.infoBox.Controls.Add(this.deleteBtn);
            this.infoBox.Controls.Add(this.modifyBtn);
            this.infoBox.Controls.Add(this.commentsBox);
            this.infoBox.Controls.Add(this.commentsLabel);
            this.infoBox.Controls.Add(this.descriptionBox);
            this.infoBox.Controls.Add(this.descriptionLabel);
            this.infoBox.Controls.Add(this.dateLabel);
            this.infoBox.Controls.Add(this.datePicker);
            this.infoBox.Controls.Add(this.numberBox);
            this.infoBox.Controls.Add(this.showNoLabel);
            this.infoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.Location = new System.Drawing.Point(243, 12);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(393, 463);
            this.infoBox.TabIndex = 8;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Show Information";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(267, 432);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 25);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(141, 432);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(120, 25);
            this.deleteBtn.TabIndex = 9;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(9, 432);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(126, 25);
            this.modifyBtn.TabIndex = 8;
            this.modifyBtn.Text = "Save Changes";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(6, 139);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(72, 16);
            this.commentsLabel.TabIndex = 6;
            this.commentsLabel.Text = "Comments";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(9, 101);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(378, 22);
            this.descriptionBox.TabIndex = 5;
            this.descriptionBox.TextChanged += new System.EventHandler(this.descriptionBox_TextChanged);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(6, 80);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(76, 16);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "Description";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(120, 25);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(73, 16);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "Show Date";
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(123, 44);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(161, 22);
            this.datePicker.TabIndex = 2;
            this.datePicker.ValueChanged += new System.EventHandler(this.dateBox_ValueChanged);
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
            this.showNoLabel.Text = "Show Number";
            // 
            // classListGroup
            // 
            this.classListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classListGroup.Controls.Add(this.classListBox);
            this.classListGroup.Controls.Add(this.viewClassBtn);
            this.classListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classListGroup.Location = new System.Drawing.Point(642, 12);
            this.classListGroup.Name = "classListGroup";
            this.classListGroup.Size = new System.Drawing.Size(250, 463);
            this.classListGroup.TabIndex = 9;
            this.classListGroup.TabStop = false;
            this.classListGroup.Text = "Show Bill";
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
            this.classListBox.Size = new System.Drawing.Size(237, 401);
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
            this.classNameHeader.Width = 192;
            // 
            // viewClassBtn
            // 
            this.viewClassBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewClassBtn.Location = new System.Drawing.Point(128, 432);
            this.viewClassBtn.Name = "viewClassBtn";
            this.viewClassBtn.Size = new System.Drawing.Size(115, 25);
            this.viewClassBtn.TabIndex = 7;
            this.viewClassBtn.Text = "View Class";
            this.viewClassBtn.UseVisualStyleBackColor = true;
            // 
            // commentsBox
            // 
            this.commentsBox.Location = new System.Drawing.Point(9, 158);
            this.commentsBox.Multiline = true;
            this.commentsBox.Name = "commentsBox";
            this.commentsBox.Size = new System.Drawing.Size(378, 261);
            this.commentsBox.TabIndex = 7;
            this.commentsBox.TextChanged += new System.EventHandler(this.commentsBox_TextChanged);
            // 
            // ShowListForm
            // 
            this.ClientSize = new System.Drawing.Size(904, 487);
            this.Controls.Add(this.classListGroup);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.showListGroup);
            this.Controls.Add(this.showLabel);
            this.Name = "ShowListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.showListGroup.ResumeLayout(false);
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.classListGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
