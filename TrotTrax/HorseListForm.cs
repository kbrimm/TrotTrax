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
        private Horse ActiveHorse;
        private bool IsNew;
        private bool IsChanged;
        private List<DropDownItem> DropDownList;

        #region Constructors

        // New horse form.
        public HorseListForm(string clubID, int year)
        {
            ActiveHorse = new Horse(clubID, year);
            InitializeComponent();
            SetNewData();
        }

        private void SetNewData()
        {
            PopulateHorseList();
            PopulateRiderList();
            PopulateDropDown();
            this.Text = "New Horse - TrotTrax";
            horseLabel.Text = "New Horse\nSetup";
            this.numberBox.Text = ActiveHorse.Number.ToString();
            this.horseNameBox.Text = String.Empty;
            this.horseNameBox.Focus();
            this.altNameBox.Text = String.Empty;
            this.heightBox.Text = String.Empty;
            this.commentsBox.Text = String.Empty;
            this.backNoBox.Text = String.Empty;
            this.modifyBtn.Text = "Add Horse";

            // Modify btn is disabled until changes are made. Cannot delete record or add/view riders for an unsaved record.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.viewBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBackNoBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.addBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBackNoBtn.ForeColor = System.Drawing.SystemColors.GrayText;

            IsNew = true;
            IsChanged = false;
        }

        // Existing horse form.
        public HorseListForm(string clubID, int year, int horseNo)
        {
            ActiveHorse = new Horse(clubID, year, horseNo);
            InitializeComponent();
            SetExistingData();
        }

        private void SetExistingData()
        {
            PopulateHorseList();
            PopulateRiderList();
            PopulateDropDown();
            this.Text = ActiveHorse.Name + " Horse Detail - TrotTrax";
            horseLabel.Text = ActiveHorse.Name + "\nHorse Detail";
            this.numberBox.Text = ActiveHorse.Number.ToString();
            this.horseNameBox.Text = ActiveHorse.Name;
            this.horseNameBox.Focus();
            this.altNameBox.Text = ActiveHorse.AltName;
            this.heightBox.Text = ActiveHorse.Height.ToString();
            this.commentsBox.Text = ActiveHorse.Comments;
            this.backNoBox.Text = String.Empty;
            this.modifyBtn.Text = "Save Changes";

            // Modify btn is disabled until changes are made. View rider depends on presence of data.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBackNoBtn.ForeColor = System.Drawing.SystemColors.ControlText;

            IsNew = false;
            IsChanged = false;
        }

        #endregion

        #region Refresh Form

        // Refresh to new horse form.
        private void RefreshForm(string clubID, int year)
        {
            ActiveHorse = new Horse(clubID, year);
            SetNewData();
        }

        // Refresh to existing horse form.
        private void RefreshForm(string clubID, int year, int horseNo)
        {
            ActiveHorse = new Horse(clubID, year, horseNo);
            SetExistingData();
        }

        private void RefreshOnClose(object sender, FormClosingEventArgs e)
        {
            if (AbandonChanges())
                if (IsNew)
                    RefreshForm(ActiveHorse.ClubID, ActiveHorse.Year);
                else
                    RefreshForm(ActiveHorse.ClubID, ActiveHorse.Year, ActiveHorse.Number);
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
            IsChanged = true;
        }

        // If a rider is selected from drop down or back no is entered, activate add rider button.
        private void RiderChanged(object sender, EventArgs e)
        {
            this.addBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBackNoBtn.ForeColor = System.Drawing.SystemColors.ControlText;
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

        #region Horse Data

        private void SaveHorse(object sender, EventArgs e)
        {
            if (IsChanged)
            {
                DialogResult confirm;
                int number = Convert.ToInt32(this.numberBox.Text);
                string name = this.horseNameBox.Text;
                string altName = this.altNameBox.Text;
                string height = this.heightBox.Text;
                string owner = this.ownerBox.Text;
                string comment = this.commentsBox.Text;

                // Because the number is not accessible to the user, there's no need to validate it.
                // If it's a new horse, add and prompt for more additions.
                if (IsNew)
                {
                    if (ActiveHorse.AddHorse(number, name, altName, height, owner, comment))
                    {
                        confirm = MessageBox.Show("Would you like to add another horse?", "TrotTrax Alert", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                            RefreshForm(ActiveHorse.ClubID, ActiveHorse.Year);
                        else
                            RefreshForm(ActiveHorse.ClubID, ActiveHorse.Year, number);
                    }
                    // Something went wrong.
                    else
                        confirm = MessageBox.Show("Something went wrong. Unable to save horse at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
                // Otherwise: do or do not, there is no try.
                else
                {
                    if (ActiveHorse.ModifyHorse(number, name, altName, height, owner, comment))
                        RefreshForm(ActiveHorse.ClubID, ActiveHorse.Year, number);
                    // Unless something terrible happens.
                    else
                        confirm = MessageBox.Show("Something went wrong. Unable to save horse at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
                
            }
        }

        private void DeleteHorse(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this horse?\n" +
                        "This operation CANNOT be undone.",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    ActiveHorse.RemoveHorse();
                    RefreshForm(ActiveHorse.ClubID, ActiveHorse.Year);
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
            foreach (HorseItem entry in ActiveHorse.HorseList)
            {
                string[] row = { entry.Name };
                horseListBox.Items.Add(entry.No.ToString()).SubItems.AddRange(row);
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
                ActiveHorse.SortHorses(HorseSort.Name);
            PopulateHorseList();
        }

        // Refreshes to new horse form.
        private void NewHorse(object sender, EventArgs e)
        {
            if (AbandonChanges())
                RefreshForm(ActiveHorse.ClubID, ActiveHorse.Year);
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
                    RefreshForm(ActiveHorse.ClubID, ActiveHorse.Year, horseNo);
            }
        }

        #endregion

        #region Rider List

        // List of riders for this horse, populated from backNo table.
        private void PopulateRiderList()
        {
            riderListBox.Items.Clear();
            foreach (BackNoItem entry in ActiveHorse.BackNoList)
            {
                string[] row = { entry.RiderLast + ", " + entry.RiderFirst };
                riderListBox.Items.Add(entry.No.ToString()).SubItems.AddRange(row);
            }

            // If the riderList box is empty, no view option.
            if(riderListBox.Items.Count == 0)
            {
                this.viewBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewBackNoBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            else
            {
                this.viewBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewBackNoBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            } 
        }

        // Sorts riderList based on column clicks.
        private void SortRiderList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                ActiveHorse.SortBackNos(BackNoSort.Number);
            else if (e.Column == 1)
                ActiveHorse.SortBackNos(BackNoSort.RiderLast);
            PopulateRiderList();
        }

        // Populates add rider combo box.
        private void PopulateDropDown()
        {
            // Initializes box with a 'null' item for display purposes.
            DropDownList = new List<DropDownItem>();
            DropDownList.Add(new DropDownItem() { No = 0, Name = "Select Rider" });

            // Adds the contents of the category item list retrieved from the database.
            foreach (RiderItem entry in ActiveHorse.RiderList)
                DropDownList.Add(new DropDownItem() { No = entry.No, Name = entry.LastName + ", " + entry.FirstName });

            // Sets this list as the menu's data source and tells the menu which parts to show.
            this.riderComboBox.DataSource = DropDownList;
            this.riderComboBox.DisplayMember = "name";
            this.riderComboBox.ValueMember = "no";
        }

        // Loads new back number form, closes current.
        private void AddBackNo(object sender, EventArgs e)
        {
            int backNo = VerifyBackNo(backNoBox.Text);
            int riderNo = VerifyRider(riderComboBox.SelectedValue.ToString());

            if(backNo > 0 && riderNo > 0)
            {
                ActiveHorse.AddBackNo(backNo, riderNo);
                RefreshForm(ActiveHorse.ClubID, ActiveHorse.Year, ActiveHorse.Number);
            }
        }

        // If back number is selected from list, loads existing back number form, closes current.
        private void ViewBackNo(object sender, EventArgs e)
        {
            if (riderListBox.SelectedItems.Count != 0)
            {
                int backNo = -1;

                if (int.TryParse(riderListBox.SelectedItems[0].Text, out backNo) && AbandonChanges())
                {
                    BackNoListForm form = new BackNoListForm(ActiveHorse.ClubID, ActiveHorse.Year, backNo);
                    form.Visible = true;
                    this.Close();
                }
            }
        }
        #endregion

        #region Data Verifiers

        private int VerifyBackNo(string backNoString)
        {
            int backNo;
            if (Int32.TryParse(backNoString, out backNo) && !ActiveHorse.CheckIndexUsed(ItemType.BackNo, backNo))
            {
                return backNo;
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Invalid back number.", "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }
        }

        private int VerifyRider(string riderString)
        {
            int riderNo;
            if (Int32.TryParse(riderString, out riderNo) && ActiveHorse.CheckIndexUsed(ItemType.Rider, riderNo))
            {
                return riderNo;
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Rider not found.", "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }
        }

        #endregion
    }
}
