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
    public partial class RiderListForm : Form
    {
        private Rider ActiveRider;
        private bool IsNew;
        private bool IsChanged;
        private List<DropDownItem> DropDownList;

        #region Constructors

        // New rider form.
        public RiderListForm(string clubID, int year)
        {
            ActiveRider = new Rider(clubID, year);
            InitializeComponent();
            SetNewData();
        }

        private void SetNewData()
        {
            PopulateRiderList();
            PopulateHorseList();
            PopulateDropDown();
            this.Text = "New Rider - TrotTrax";
            riderLabel.Text = "New Rider\nSetup";
            this.numberBox.Text = ActiveRider.Number.ToString();
            this.firstNameBox.Text = String.Empty;
            this.firstNameBox.Focus();
            this.lastNameBox.Text = String.Empty;
            this.birthdayPicker.Value = DateTime.Now;
            this.ageBox.Text = String.Empty;
            this.memberCheckBox.Checked = false;
            this.phoneBox.Text = String.Empty;
            this.emailBox.Text = String.Empty;
            this.commentsBox.Text = String.Empty;
            this.modifyBtn.Text = "Add Rider";

            // Modify btn is disabled until changes are made. Cannot delete record or add/view horses for an unsaved record.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.viewBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBackNoBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.addBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBackNoBtn.ForeColor = System.Drawing.SystemColors.GrayText;

            IsNew = true;
            IsChanged = false;
        }

        // Existing rider form.
        public RiderListForm(string clubID, int year, int riderNo)
        {
            ActiveRider = new Rider(clubID, year, riderNo);
            InitializeComponent();
            SetExistingData();
        }

        private void SetExistingData()
        {
            PopulateRiderList();
            PopulateHorseList();
            PopulateDropDown();
            this.Text = ActiveRider.FirstName + " " + ActiveRider.LastName + " Rider Detail - TrotTrax";
            riderLabel.Text = ActiveRider.FirstName + " " + ActiveRider.LastName + "\nRider Detail";
            this.numberBox.Text = ActiveRider.Number.ToString();
            this.firstNameBox.Text = ActiveRider.FirstName;
            this.firstNameBox.Focus();
            this.lastNameBox.Text = ActiveRider.LastName;

            // Calculates age value from Jan first of the show year. Treat birthdays before this year as
            // empty values.
            DateTime jan = new DateTime(ActiveRider.Year, 1, 1);
            int age = 0;
            if (ActiveRider.Birthdate < jan)
            {
                this.birthdayPicker.Value = ActiveRider.Birthdate;
                age = ((TimeSpan)(new DateTime(ActiveRider.Year, 1, 1) - ActiveRider.Birthdate)).Days / 365;
                this.ageBox.Text = age.ToString();
            }
            else
            {
                this.birthdayPicker.Value = DateTime.Today;
                this.ageBox.Text = String.Empty;
            }

            this.memberCheckBox.Checked = ActiveRider.IsMember;
            this.phoneBox.Text = ActiveRider.Phone;
            this.emailBox.Text = ActiveRider.Email;
            this.commentsBox.Text = ActiveRider.Comments;
            this.modifyBtn.Text = "Save Changes";

            // Modify btn is disabled until changes are made. View horse depends on presence of data.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBackNoBtn.ForeColor = System.Drawing.SystemColors.ControlText;

            IsNew = false;
            IsChanged = false;
        }

        #endregion

        #region Refresh Form

        // Refresh to new rider form.
        private void RefreshForm(string clubID, int year)
        {
            ActiveRider = new Rider(clubID, year);
            SetNewData();
        }

        private void RefreshForm(string clubID, int year, int riderNo)
        {
            ActiveRider = new Rider(clubID, year, riderNo);
            SetExistingData();
        }

        private void RefreshOnClose(object sender, FormClosingEventArgs e)
        {
            if (AbandonChanges())
                if (IsNew)
                    RefreshForm(ActiveRider.ClubID, ActiveRider.Year);
                else
                    RefreshForm(ActiveRider.ClubID, ActiveRider.Year, ActiveRider.Number);
            else
            {
                PopulateRiderList();
                PopulateHorseList();
                PopulateDropDown();
            }
        }

        #endregion

        #region Form Changes

        // When changes are made, activates relevant buttons.
        private void DataChanged(object sender, EventArgs e)
        {     
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            IsChanged = true;
        }

        // If a horse is selected from drop down or back no is entered, activate add horse button.
        private void HorseChanged(object sender, EventArgs e)
        {
            this.addBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

        // Toggles value of member checkbox on keypress when in focus.
        private void ToggleMember(object sender, KeyPressEventArgs e)
        {
            if (this.memberCheckBox.Checked)
                this.memberCheckBox.Checked = false;
            else
                this.memberCheckBox.Checked = true;
        }

        #endregion

        #region Rider Data

        private void SaveRider(object sender, EventArgs e)
        {
            if (IsChanged)
            {
                DialogResult confirm;
                int number = Convert.ToInt32(this.numberBox.Text);
                string first = this.firstNameBox.Text;
                string last = this.lastNameBox.Text;
                DateTime dob = this.birthdayPicker.Value;
                bool member = this.memberCheckBox.Checked;
                string phone = this.phoneBox.Text;
                string email = this.emailBox.Text;
                string comment = this.commentsBox.Text;

                // Because the number is not accessible to the user, there's no need to validate it.
                // If it's a new rider, add and prompt for more additions.
                if (IsNew)
                {
                    if (ActiveRider.AddRider(number, first, last, dob, phone, email, member, comment))
                    {
                        confirm = MessageBox.Show("Would you like to add another rider?", "TrotTrax Alert", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                            RefreshForm(ActiveRider.ClubID, ActiveRider.Year);
                        else
                            RefreshForm(ActiveRider.ClubID, ActiveRider.Year, number);
                    }
                    // Something went wrong.
                    else
                        confirm = MessageBox.Show("Something went wrong. Unable to save rider at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
                // Otherwise: do or do not, there is no try.
                else
                {
                    if (ActiveRider.ModifyRider(number, first, last, dob, phone, email, member, comment))
                        RefreshForm(ActiveRider.ClubID, ActiveRider.Year, number);
                    // Unless something terrible happens.
                    else
                        confirm = MessageBox.Show("Something went wrong. Unable to save rider at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
            }
        }

        private void DeleteRider(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this rider?\n" +
                        "This operation CANNOT be undone.",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    ActiveRider.RemoveRider();
                    RefreshForm(ActiveRider.ClubID, ActiveRider.Year);
                }
            }
        }

        private void CancelChanges(object sender, EventArgs e)
        {
            if (AbandonChanges())
                this.Close();
        }

        #endregion

        #region Rider List

        private void PopulateRiderList()
        {
            riderListBox.Items.Clear();
            foreach (RiderItem entry in ActiveRider.RiderList)
            {
                string[] row = { entry.FirstName, entry.LastName };
                riderListBox.Items.Add(entry.No.ToString()).SubItems.AddRange(row);
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
            if (e.Column == 1)
                ActiveRider.SortRiders(RiderSort.FirstName);
            else if (e.Column == 2)
                ActiveRider.SortRiders(RiderSort.LastName);
            PopulateRiderList();
        }

        // Refreshes to new rider form.
        private void NewRider(object sender, EventArgs e)
        {
            if (AbandonChanges())
                RefreshForm(ActiveRider.ClubID, ActiveRider.Year);
        }

        // If rider is selected, refreshes to existing rider form.
        private void ViewRider(object sender, EventArgs e)
        {
            if (riderListBox.SelectedItems.Count != 0)
            {
                int riderNo = -1;

                if (AbandonChanges())
                    riderNo = Convert.ToInt32(riderListBox.SelectedItems[0].Text);
                if (riderNo >= 0)
                    RefreshForm(ActiveRider.ClubID, ActiveRider.Year, riderNo);
            }
        }

        #endregion

        #region Horse List

        // List of horses for this rider, populated from backNo table.
        private void PopulateHorseList()
        {
            horseListBox.Items.Clear();
            foreach (BackNoItem entry in ActiveRider.BackNoList)
            {
                string[] row = { entry.Horse };
                horseListBox.Items.Add(entry.No.ToString()).SubItems.AddRange(row);
            }

            // If the riderList box is empty, no view option.
            if (horseListBox.Items.Count == 0)
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

        // Populates add horse combo box.
        private void PopulateDropDown()
        {
            // Initializes box with a 'null' item for display purposes.
            DropDownList = new List<DropDownItem>();
            DropDownList.Add(new DropDownItem() { No = 0, Name = String.Empty });

            // Adds the contents of the category item list retrieved from the database.
            foreach (HorseItem entry in ActiveRider.HorseList)
                DropDownList.Add(new DropDownItem() { No = entry.No, Name = entry.Name });

            // Sets this list as the menu's data source and tells the menu which parts to show.
            this.horseComboBox.DataSource = DropDownList;
            this.horseComboBox.DisplayMember = "name";
            this.horseComboBox.ValueMember = "no";
        }

        private void SortHorseList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                ActiveRider.SortBackNos(BackNoSort.Number, BackNoFilter.Rider, ActiveRider.Number);
            else if (e.Column == 1)
                ActiveRider.SortBackNos(BackNoSort.Horse, BackNoFilter.Rider, ActiveRider.Number);
            PopulateHorseList();
        }

        // Loads new back number form, closes current.
        private void AddBackNo(object sender, EventArgs e)
        {
            int backNo = VerifyBackNo(backNoBox.Text);
            int horseNo = VerifyRider(horseComboBox.SelectedValue.ToString());

            if (backNo > 0 && horseNo > 0)
            {
                ActiveRider.AddBackNo(backNo, horseNo);
                RefreshForm(ActiveRider.ClubID, ActiveRider.Year, ActiveRider.Number);
            }
        }

        private int VerifyBackNo(string backNoString)
        {
            int backNo;
            if (Int32.TryParse(backNoString, out backNo) && !ActiveRider.CheckIndexUsed(FormType.BackNo, backNo))
            {
                return backNo;
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Invalid back number.", "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }
        }

        private int VerifyRider(string horseString)
        {
            int horseNo;
            if (Int32.TryParse(horseString, out horseNo) && ActiveRider.CheckIndexUsed(FormType.Horse, horseNo))
            {
                return horseNo;
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Rider not found.", "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }
        }

        // If back number is selected from list, loads existing back number form, closes current.
        private void ViewBackNo(object sender, EventArgs e)
        {
            if (horseListBox.SelectedItems.Count != 0)
            {
                int backNo = -1;

                if (int.TryParse(horseListBox.SelectedItems[0].Text, out backNo) && AbandonChanges())
                {
                    this.Close();
                }
            }
        }

        #endregion
    }
}
