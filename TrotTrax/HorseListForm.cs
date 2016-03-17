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
    public partial class HorseListForm : Form
    {
        Horse horse;
        bool isNew;
        bool isChanged;
        private List<DropDownItem> dropDownList;

        #region Constructors

        // New horse form.
        public HorseListForm(string clubID, int year)
        {
            horse = new Horse(clubID, year);
            InitializeComponent();
            SetNewData();
        }

        private void SetNewData()
        {
            PopulateHorseList();
            PopulateRiderList();
            this.Text = "New Horse - TrotTrax";
            horseLabel.Text = "New Horse\nSetup";
            this.numberBox.Text = horse.number.ToString();
            this.fullNameBox.Text = String.Empty;
            this.fullNameBox.Focus();
            this.callNameBox.Text = String.Empty;
            this.heightBox.Text = String.Empty;
            this.commentsBox.Text = String.Empty;
            this.modifyBtn.Text = "Add Horse";

            // Modify btn is disabled until changes are made. Cannot delete record or add/view riders for an unsaved record.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewRiderBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.addRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRiderBtn.ForeColor = System.Drawing.SystemColors.GrayText;

            isNew = true;
            isChanged = false;
        }

        // Existing horse form.
        public HorseListForm(string clubID, int year, int horseNo)
        {
            horse = new Horse(clubID, year, horseNo);
            InitializeComponent();
            SetExistingData();
        }

        private void SetExistingData()
        {
            PopulateHorseList();
            PopulateRiderList();
            this.Text = horse.name + " Horse Detail - TrotTrax";
            horseLabel.Text = horse.name + "\nHorse Detail";
            this.numberBox.Text = horse.number.ToString();
            this.fullNameBox.Text = horse.name;
            this.fullNameBox.Focus();
            this.callNameBox.Text = horse.altName;
            this.heightBox.Text = horse.height.ToString();
            this.commentsBox.Text = horse.comment;
            this.modifyBtn.Text = "Save Changes";

            // Modify btn is disabled until changes are made. View rider depends on presence of data.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRiderBtn.ForeColor = System.Drawing.SystemColors.ControlText;

            isNew = false;
            isChanged = false;
        }

        #endregion

        #region Refresh Form

        // Refresh to new horse form.
        private void RefreshForm(string clubID, int year)
        {
            horse = new Horse(clubID, year);
            SetNewData();
        }

        private void RefreshForm(string clubID, int year, int horseNo)
        {
            horse = new Horse(clubID, year, horseNo);
            SetExistingData();
        }

        private void RefreshOnClose(object sender, FormClosingEventArgs e)
        {
            if (AbandonChanges())
                if (isNew)
                    RefreshForm(horse.clubID, horse.year);
                else
                    RefreshForm(horse.clubID, horse.year, horse.number);
            else
            {
                PopulateHorseList();
                PopulateRiderList();
                PopulateDropDown();
            }
        }

        #endregion

        #region Form Changes

        // When changes are made, activates relevant buttons.
        private void DataChanged(object sender, EventArgs e)
        {     
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            isChanged = true;
        }

        // If a rider is selected from drop down or back no is entered, activate add rider button.
        private void RiderChanged(object sender, EventArgs e)
        {
            this.addRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRiderBtn.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        // On form close, prompt to abandon unsaved changes.
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

        #endregion

        #region Horse Data

        private void SaveHorse(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult confirm;
                int number = Convert.ToInt32(this.numberBox.Text);
                string name = this.fullNameBox.Text;
                string callName = this.callNameBox.Text;
                string height = this.heightBox.Text;
                string owner = this.ownerBox.Text;
                string comment = this.commentsBox.Text;

                // Because the number is not accessible to the user, there's no need to validate it.
                // If it's a new horse, add and prompt for more additions.
                if (isNew)
                {
                    if (horse.AddHorse(number, name, callName, height, owner, comment))
                    {
                        confirm = MessageBox.Show("Would you like to add another horse?", "TrotTrax Alert", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                            RefreshForm(horse.clubID, horse.year);
                        else
                            RefreshForm(horse.clubID, horse.year, number);
                    }
                    // Something went wrong.
                    else
                        confirm = MessageBox.Show("Something went wrong. Unable to save horse at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
                // Otherwise: do or do not, there is no try.
                else
                {
                    if (horse.ModifyHorse(number, name, callName, height, owner, comment))
                        RefreshForm(horse.clubID, horse.year, number);
                    // Unless something terrible happens.
                    else
                        confirm = MessageBox.Show("Something went wrong. Unable to save horse at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
                
            }
        }

        private void DeleteHorse(object sender, EventArgs e)
        {
            if (!isNew)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this horse?\n" +
                        "This operation CANNOT be undone.",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    horse.RemoveHorse();
                    RefreshForm(horse.clubID, horse.year);
                }
            }
        }

        private void CancelChanges(object sender, EventArgs e)
        {
            if (AbandonChanges())
                this.Close();
        }

        #endregion

        #region Horse List

        private void PopulateHorseList()
        {
            horseListBox.Items.Clear();
            foreach (HorseItem entry in horse.horseList)
            {
                string[] row = { entry.name };
                horseListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }

            // If the horseList box is empty, no view option.
            if(horseListBox.Items.Count == 0)
            {
                this.viewHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewHorseBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            else
            {
                this.viewHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewHorseBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            } 
        }

        // Sorts horseList based on column clicks.
        private void SortHorseList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                horse.SortHorses(HorseSort.Name);
            PopulateHorseList();
        }

        // Refreshes to new horse form.
        private void NewHorse(object sender, EventArgs e)
        {
            if (AbandonChanges())
                RefreshForm(horse.clubID, horse.year);
        }

        // If horse is selected, refreshes to existing horse form.
        private void ViewHorse(object sender, EventArgs e)
        {
            if (horseListBox.SelectedItems.Count != 0)
            {
                int horseNo = -1;

                if (AbandonChanges())
                    horseNo = Convert.ToInt32(horseListBox.SelectedItems[0].Text);
                if (horseNo >= 0)
                    RefreshForm(horse.clubID, horse.year, horseNo);
            }
        }

        #endregion

        #region Rider List

        // List of riders for this horse, populated from backNo table.
        private void PopulateRiderList()
        {
            riderListBox.Items.Clear();
            foreach (BackNoItem entry in horse.backNoList)
            {
                string[] row = { entry.rider };
                riderListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }

            // If the riderList box is empty, no view option.
            if(riderListBox.Items.Count == 0)
            {
                this.viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewRiderBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            else
            {
                this.viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewRiderBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            } 
        }

        // Sorts riderList based on column clicks.
        private void SortRiderList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                horse.SortBackNos(BackNoSort.Number);
            else if (e.Column == 1)
                horse.SortBackNos(BackNoSort.Rider);
            PopulateRiderList();
        }

        // Populates add rider combo box.
        private void PopulateDropDown()
        {
            // Initializes box with a 'null' item for display purposes.
            dropDownList = new List<DropDownItem>();
            dropDownList.Add(new DropDownItem() { no = 0, name = String.Empty });

            // Adds the contents of the category item list retrieved from the database.
            foreach (RiderItem entry in horse.riderList)
                dropDownList.Add(new DropDownItem() { name = entry.firstName + " " + entry.lastName });

            // Sets this list as the menu's data source and tells the menu which parts to show.
            this.riderComboBox.DataSource = dropDownList;
            this.riderComboBox.DisplayMember = "name";
            this.riderComboBox.ValueMember = "no";
        }

        // Loads new back number form, closes current.
        private void AddBackNo(object sender, EventArgs e)
        {
            if (AbandonChanges())
            {
                this.Close();
            }
        }

        // If back number is selected from list, loads existing back number form, closes current.
        private void ViewRider(object sender, EventArgs e)
        {
            if (riderListBox.SelectedItems.Count != 0)
            {
                int backNo = -1;

                if (int.TryParse(riderListBox.SelectedItems[0].Text, out backNo) && AbandonChanges())
                {
                    this.Close();
                }
            }
        }
        #endregion

        private void HorseListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
