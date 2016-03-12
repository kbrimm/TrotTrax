/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
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

        // Form methods

        public ShowListForm(string clubID, int year)
        {
            show = new Show(clubID, year);
            InitializeComponent();
            PopulateClassList();
            PopulateShowList();
            this.Text = "New Show - TrotTrax";
            showLabel.Text = "New Show\nSetup";
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
            descriptionBox.Text = show.name;
            commentsBox.Text = show.comments;
            showLabel.Text = show.date + "\r\nShow Detail";
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = false;
        }

        private void RefreshForm(string clubID, int year)
        {
            show = new Show(clubID, year);
            PopulateClassList();
            PopulateShowList();
            this.Text = "New Show Detail - TrotTrax";
            this.ActiveControl = datePicker;
            showLabel.Text = "Adding New Show";
            numberBox.Text = String.Empty;
            descriptionBox.Text = String.Empty;
            commentsBox.Text = String.Empty;
            modifyBtn.Text = "Add New Show";
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewClassBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = true;
        }

        private void RefreshForm(string clubID, int year, int showNo)
        {
            show = new Show(clubID, year, showNo);
            PopulateClassList();
            PopulateShowList();
            this.Text = show.date + " Show Detail - TrotTrax";
            modifyBtn.Text = "Save Changes";
            numberBox.Text = showNo.ToString();
            datePicker.Value = Convert.ToDateTime(show.date);
            descriptionBox.Text = show.name;
            commentsBox.Text = show.comments;
            showLabel.Text = show.date + "\r\nShow Detail";
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = false;
        }

        private void RefreshOnClose(object sender, FormClosingEventArgs e)
        {
            if (AbandonChanges())
                if (isNew)
                    RefreshForm(show.clubID, show.year);
                else
                    RefreshForm(show.clubID, show.year, show.number);
            else
                PopulateClassList();
        }

        private void ChangesMade(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            isChanged = true;
        }

        private bool AbandonChanges()
        {
            if (isChanged)
            {
                DialogResult confirm = MessageBox.Show("Do you want to abandon your changes?",
                        "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        // Show data methods

        private void RemoveShow(object sender, EventArgs e)
        {
            if (!isNew)
            {
                DialogResult confirm = MessageBox.Show("Do you really want to remove this show and all of its data?\n" +
                    "This operation cannot be undone.",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    show.RemoveShow();
                    RefreshForm(show.clubID, show.year);
                }
            }
        }

        private void SaveShow(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult confirm;
                bool success;
                int number = Convert.ToInt32(this.datePicker.Text);
                DateTime date = this.datePicker.Value;
                string description = this.descriptionBox.Text;
                string comments = this.commentsBox.Text;

                if (isNew)
                {
                    success = show.AddShow(number, date, description, comments);
                    if (success)
                    {
                        confirm = MessageBox.Show("Would you like to add another show?",
                            "TrotTrax Alert", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                            RefreshForm(show.clubID, show.year);
                        else
                            RefreshForm(show.clubID, show.year, show.number);
                    }
                    else
                        confirm = MessageBox.Show("Unable to add show at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
                else
                {
                    success = show.ModifyShow(date, description, comments);
                    if (success)
                        RefreshForm(show.clubID, show.year, show.number);
                    else
                        confirm = MessageBox.Show("Unable to modify show at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
            }
        }

        private void CancelChanges(object sender, EventArgs e)
        {
            if (AbandonChanges())
                this.Close();
        }

        // Show list methods

        private void PopulateShowList()
        {
            this.showListBox.Items.Clear();
            foreach (ShowItem entry in show.showList)
            {
                string value;
                string dateString = entry.date.ToString("MM/dd/yyyy");
                if (entry.name == "")
                    value = dateString;
                else
                    value = dateString + " - " + entry.name;
                showListBox.Items.Add(value);
            }
        }

        private void NewShow(object sender, EventArgs e)
        {
            if (AbandonChanges())
                RefreshForm(show.clubID, show.year);
        }

        private void ViewShow(object sender, EventArgs e)
        {
            if (showListBox.SelectedItems.Count != 0)
            {
                int showNo = -1;

                if (AbandonChanges())
                {
                    string selectedShow = showListBox.SelectedItems[0].ToString();
                    selectedShow = selectedShow.Substring(15, 10);
                    foreach (ShowItem entry in show.showList)
                    {
                        string dateString = entry.date.ToString("MM/dd/yyyy");
                        if (dateString == selectedShow)
                        {
                            showNo = entry.no;
                            break;
                        }
                    }
                }

                if (showNo >= 0)
                    RefreshForm(show.clubID, show.year, showNo);
            }
        }

        // Class list methods

        private void PopulateClassList()
        {
            this.classListBox.Items.Clear();
            foreach (ClassItem entry in show.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void SortClass(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                show.SortClasses(ClassSort.Number);
            else if (e.Column == 1)
                show.SortClasses(ClassSort.Name);
            PopulateClassList();
        }

        private void ViewClass(object sender, EventArgs e)
        {
            if (classListBox.SelectedItems.Count != 0)
            {
                int selectedClass = -1;

                if (AbandonChanges())
                    selectedClass = Convert.ToInt32(classListBox.SelectedItems[0].Text);

                if (selectedClass >= 0)
                {
                    ResultsForm classForm = new ResultsForm(show.clubID, show.year, show.number, selectedClass);
                    classForm.Visible = true;
                    this.Close();
                }
            }
        }
    }
}