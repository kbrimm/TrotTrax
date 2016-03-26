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
        private Show ActiveShow;
        private bool IsChanged;
        private bool IsNew;

        #region Constructors
        // New show form.
        public ShowListForm(string clubID, int year)
        {
            ActiveShow = new Show(clubID, year);
            InitializeComponent();
            SetNewData();
        }

        private void SetNewData()
        {
            PopulateClassList();
            PopulateShowList();
            this.Text = "New Show - TrotTrax";
            this.showLabel.Text = "New Show\nSetup";
            this.numberBox.Text = ActiveShow.Number.ToString();
            this.numberBox.Focus();
            this.descriptionBox.Text = String.Empty;
            this.commentsBox.Text = String.Empty;
            this.modifyBtn.Text = "Add Show";

            // Modify btn is disabled until changes are made. Cannot delete or view results for an unsaved record.
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewResultsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewResultsBtn.ForeColor = System.Drawing.SystemColors.GrayText;

            IsChanged = false;
            IsNew = true;
        }

        // Existing show form.
        public ShowListForm(string clubID, int year, int showNo)
        {
            ActiveShow = new Show(clubID, year, showNo);
            InitializeComponent();
            SetExistingData();
        }

        private void SetExistingData()
        {
            PopulateClassList();
            PopulateShowList();
            this.Text = ActiveShow.Date.ToString("MM/dd/yyyy") + " Show Detail - TrotTrax";
            numberBox.Text = ActiveShow.Number.ToString();
            this.numberBox.Focus();
            datePicker.Value = ActiveShow.Date;
            descriptionBox.Text = ActiveShow.Name;
            commentsBox.Text = ActiveShow.Comments;
            showLabel.Text = ActiveShow.Date.ToString("MM/dd/yyyy") + "\r\nShow Detail";

            // Modify btn is disabled until changes are made.
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;

            IsChanged = false;
            IsNew = false;
        }

        #endregion

        #region Refresh Form
        // Refresh to new show form.
        private void RefreshForm(string clubID, int year)
        {
            ActiveShow = new Show(clubID, year);
            SetNewData();
        }

        // Refresh to existing show form.
        private void RefreshForm(string clubID, int year, int showNo)
        {
            ActiveShow = new Show(clubID, year, showNo);
            SetExistingData();
        }

        private void RefreshOnClose(object sender, FormClosingEventArgs e)
        {
            if (AbandonChanges())
                if (IsNew)
                    RefreshForm(ActiveShow.ClubID, ActiveShow.Year);
                else
                    RefreshForm(ActiveShow.ClubID, ActiveShow.Year, ActiveShow.Number);
            else
                PopulateClassList();
        }

        #endregion

        #region Form Changes

        // When changes are made, activates relevant buttons.
        private void ChangesMade(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            IsChanged = true;
        }

        // On form close, prompt to abandon unsaved changes.
        private bool AbandonChanges()
        {
            if (IsChanged)
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

        #endregion

        #region Show Data

        // Gets user-entered number, date, description, and comments.
        // For new categories, adds to database, prompts to add more automatically.
        // For existing categories, modifies existing entry for same number,
        // or inserts new and deletes old entry for different number.
        private void SaveShow(object sender, EventArgs e)
        {
            if (IsChanged)
            {
                DialogResult confirm;
                bool success;
                int number = VerifyNumber(this.numberBox.Text);
                DateTime date = this.datePicker.Value;
                string description = this.descriptionBox.Text;
                string comments = this.commentsBox.Text;

                // Ensure required parameters are satisfied.
                if (number <= 0)
                    return;

                if (IsNew)
                {
                    success = ActiveShow.AddShow(number, date, description, comments);
                    if (success)
                    {
                        confirm = MessageBox.Show("Would you like to add another show?",
                            "TrotTrax Alert", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                            RefreshForm(ActiveShow.ClubID, ActiveShow.Year);
                        else
                            RefreshForm(ActiveShow.ClubID, ActiveShow.Year, ActiveShow.Number);
                    }
                    else
                        confirm = MessageBox.Show("Something went wrong. Unable to add show at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
                else
                {
                    // If this update does not change the class number, just update the entry.
                    // Otherwise, insert new class at new number, delete current.
                    if (number == ActiveShow.Number)
                    {
                        if (ActiveShow.ModifyShow(date, description, comments))
                            RefreshForm(ActiveShow.ClubID, ActiveShow.Year, number);
                        // Unless something terrible happens.
                        else
                            confirm = MessageBox.Show("Something went wrong. Unable to save show at this time.",
                                "TrotTrax Alert", MessageBoxButtons.OK);
                    }
                    else
                    {
                        // The deletion of the existing number relies on successful insertion of the new,
                        // so in the event of catastrophic failure, the data should hopefully still be there somewhere.
                        if (ActiveShow.AddShow(number, date, description, comments))
                        {
                            ActiveShow.RemoveShow();
                            RefreshForm(ActiveShow.ClubID, ActiveShow.Year, number);
                        }
                        // Unless something terrible happens.
                        else
                            confirm = MessageBox.Show("Something went wrong. Unable to save show at this time.",
                                "TrotTrax Alert", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void DeleteShow(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                DialogResult confirm = MessageBox.Show("Do you really want to remove this show and all of its data?\n" +
                    "This operation cannot be undone.",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    ActiveShow.RemoveShow();
                    RefreshForm(ActiveShow.ClubID, ActiveShow.Year);
                }
            }
        }

        private void CancelChanges(object sender, EventArgs e)
        {
            if (AbandonChanges())
                this.Close();
        }

        #endregion

        #region Show List

        // Populates showList from database.
        private void PopulateShowList()
        {
            this.showListBox.Items.Clear();
            foreach (ShowItem entry in ActiveShow.ShowList)
            {
                string value;
                string dateString = entry.Date.ToString("MM/dd/yyyy");
                if (entry.Name == "")
                    value = dateString;
                else
                    value = dateString + " - " + entry.Name;
                showListBox.Items.Add(value);
            }

            if (showListBox.Items.Count == 0)
            {
                this.viewShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewShowBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            else
            {
                this.viewShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewShowBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        // Refreshes to new show form.
        private void NewShow(object sender, EventArgs e)
        {
            if (AbandonChanges())
                RefreshForm(ActiveShow.ClubID, ActiveShow.Year);
        }

        // If show is selected, refreshes to exisitng show.
        private void ViewShow(object sender, EventArgs e)
        {
            if (showListBox.SelectedItems.Count != 0)
            {
                int showNo = -1;

                if (AbandonChanges())
                {
                    string selectedShow = showListBox.SelectedItems[0].ToString();
                    selectedShow = selectedShow.Substring(15, 10);
                    foreach (ShowItem entry in ActiveShow.ShowList)
                    {
                        string dateString = entry.Date.ToString("MM/dd/yyyy");
                        if (dateString == selectedShow)
                        {
                            showNo = entry.No;
                            break;
                        }
                    }
                }

                if (showNo >= 0)
                    RefreshForm(ActiveShow.ClubID, ActiveShow.Year, showNo);
            }
        }

        #endregion

        #region Class List

        // Populates classList from database.
        private void PopulateClassList()
        {
            this.classListBox.Items.Clear();
            foreach (ClassItem entry in ActiveShow.ClassList)
            {
                string[] row = { entry.Name, };
                classListBox.Items.Add(entry.No.ToString()).SubItems.AddRange(row);
            }

            if (classListBox.Items.Count == 0)
            {
                this.viewResultsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewResultsBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            else
            {
                this.viewResultsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewResultsBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        // Sorts classList according to column clicks.
        private void SortClass(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                ActiveShow.SortClasses(ClassSort.Number);
            else if (e.Column == 1)
                ActiveShow.SortClasses(ClassSort.Name);
            PopulateClassList();
        }

        // If class selected, launches results form for current show and selected class.
        private void ViewResults(object sender, EventArgs e)
        {
            if (classListBox.SelectedItems.Count != 0)
            {
                int selectedClass = -1;

                if (AbandonChanges())
                    selectedClass = Convert.ToInt32(classListBox.SelectedItems[0].Text);

                if (selectedClass >= 0)
                {
                    ResultListForm classForm = new ResultListForm(ActiveShow.ClubID, ActiveShow.Year, ActiveShow.Number, selectedClass);
                    classForm.Visible = true;
                    this.Close();
                }
            }
        }
        #endregion

        #region Data Verifiers

        // Verifies class number input - returns -1 on fail.
        private int VerifyNumber(string noString)
        {
            DialogResult confirm;
            int number;

            // If the number field is empty or not a valid integer
            if (noString == String.Empty || !int.TryParse(noString, out number))
            {
                confirm = MessageBox.Show("Show number must be an integer value.", "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }

            // If we're assigning a new number to a show, see if it exists.
            if ((IsNew || number != ActiveShow.Number) && ActiveShow.CheckIndexUsed(ItemType.Show, number))
            {
                confirm = MessageBox.Show("Show number already exists.", "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }

            return number;
        }

        #endregion
    }
}