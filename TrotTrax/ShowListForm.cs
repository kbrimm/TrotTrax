/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */

using System;
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
        private Show show;
        private bool isChanged;
        private bool isNew;

        public ShowListForm(string clubID, int year)
        {
            show = new Show(clubID, year);
            InitializeComponent();
            PopulateClassList();
            PopulateShowList();
            this.Text = "New Show Detail - TrotTrax";
            modifyBtn.Text = "Add New Show";
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewClassBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = true;
        }

        public ShowListForm(string clubID, int year, int showNo)
        {
            show = new Show(clubID, year, showNo);
            InitializeComponent();
            PopulateClassList();
            PopulateShowList();
            this.Text = show.date + " Show Detail - TrotTrax";
            numberBox.Text = showNo.ToString();
            datePicker.Value = Convert.ToDateTime(show.date);
            descriptionBox.Text = show.description;
            commentsBox.Text = show.comments;
            showLabel.Text = show.date + "\r\nShow Detail";
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = false;
        }

        private void PopulateClassList()
        {
            this.classListBox.Items.Clear();
            foreach (ClassItem entry in show.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateShowList()
        {
            this.showListBox.Items.Clear();
            foreach (ShowItem entry in show.showList)
            {
                string value;
                if (entry.description == "")
                    value = entry.date;
                else
                    value = entry.date + " - " + entry.description;
                showListBox.Items.Add(value);
            }
        }

        private void commentsBox_TextisChanged(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            isChanged = true;
        }

        private void descriptionBox_TextisChanged(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            isChanged = true;
        }

        private void dateBox_ValueisChanged(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            isChanged = true;
        }

        private bool AbandonChanges()
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
           if (showListBox.SelectedItems.Count != 0)
           {
                bool loadNew = true;
                int showNo = -1;

                if (isChanged)
                    loadNew = AbandonChanges();
                if (loadNew)
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
                    ShowListForm showList = new ShowListForm(show.clubID, show.year, showNo);
                    showList.Visible = true;
                    this.Close();
                }
            }
        }

        private void addShowBtn_Click(object sender, EventArgs e)
        {
            bool loadNew = true;
            if (isChanged)
                loadNew = AbandonChanges();
            if (loadNew)
            {
                ShowListForm showList = new ShowListForm(show.clubID, show.year);
                showList.Visible = true;
                this.Close();
            }
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult confirm;
                ShowListForm showList;
                bool success;
                DateTime date = this.datePicker.Value;
                string dateString = date.ToString("MM/dd/yyyy");
                string description = this.descriptionBox.Text;
                string comments = this.commentsBox.Text;

                if (isNew)
                {
                    success = show.AddShow(date, description, comments);
                    if (success)
                    {
                        confirm = MessageBox.Show("Would you like to add another show?",
                            "TrotTrax Alert", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                            showList = new ShowListForm(show.clubID, show.year);
                        else
                            showList = new ShowListForm(show.clubID, show.year, show.number);
                        showList.Visible = true;
                        this.Close();
                    }
                    else
                    {
                        confirm = MessageBox.Show("Unable to add show at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    success = show.ModifyShow(date, description, comments);
                    if (success)
                    {
                        showList = new ShowListForm(show.clubID, show.year, show.number);
                        showList.Visible = true;
                        this.Close();
                    }
                    else
                    {
                        confirm = MessageBox.Show("Unable to add modify show at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                    }
                }
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
                    ShowListForm showList = new ShowListForm(show.clubID, show.year);
                    showList.Visible = true;
                    this.Close();
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if(isChanged)
            {
                bool reload = AbandonChanges();

                if(reload)
                {
                    ShowListForm showList;
                    if(isNew)
                        showList = new ShowListForm(show.clubID, show.year);
                    else
                        showList = new ShowListForm(show.clubID, show.year, show.number);
                    showList.Visible = true;
                    this.Close();
                }
            }
        }

        private void classListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                show.SortClasses("class_no");
            else if (e.Column == 1)
                show.SortClasses("name");
            PopulateClassList();
        }

        private void viewClassBtn_Click(object sender, EventArgs e)
        {
            if (!isNew && classListBox.SelectedItems.Count != 0)
            {
                bool loadNew = true;
                int selectedClass = -1;

                if (isChanged)
                    loadNew = AbandonChanges();
                if (loadNew)
                    selectedClass = Convert.ToInt32(classListBox.SelectedItems[0].Text);

                if (selectedClass >= 0)
                {
                    ClassInstanceForm classInstance = new ClassInstanceForm(show.clubID, show.year, show.number, selectedClass);
                    classInstance.Visible = true;
                }
            }
        }
    }
}
