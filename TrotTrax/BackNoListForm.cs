using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrotTrax
{
    public partial class BackNoListForm : Form
    {
        private BackNumber ActiveBackNo;
        private bool IsNew;
        private bool IsChanged;
        private List<DropDownItem> HorseDropDown;
        private List<DropDownItem> RiderDropDown;

        #region Constructors

        // Creates a new back number form.
        public BackNoListForm(string clubID, int year)
        {
            ActiveBackNo = new BackNumber(clubID, year);
            InitializeComponent();
            SetNewData();
        }

        // Populates data for new back number.
        private void SetNewData()
        {
            PopulateBackNoList();
            PopulateHorseDropDown();
            PopulateRiderDropDown();
            
            this.Text = "New Back Number - TrotTrax";
            this.infoLabel.Text = "New Back Number\nSetup";
            this.backNoBox.Text = String.Empty;
            this.backNoBox.Focus();
            this.modifyBtn.Text = "Add Back No.";

            // Modify btn is disabled until changes are made. Cannot delete for an unsaved record.
            // View back no., rider, and horse btns depend on presence of data.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;

            if (ActiveBackNo.BackNoList.Count() > 0)
            {
                this.viewBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewBackNoBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                this.viewBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewBackNoBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }

            if (ActiveBackNo.RiderList.Count() > 0)
            {
                viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewRiderBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                this.viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewRiderBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }

            if (ActiveBackNo.HorseList.Count() > 0)
            {
                viewHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewHorseBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                this.viewHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewHorseBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }

            IsNew = true;
            IsChanged = false;
        }

        // Creates existing back number form.
        public BackNoListForm(string clubID, int year, int backNo)
        {
            ActiveBackNo = new BackNumber(clubID, year, backNo);
            InitializeComponent();
            SetExistingData();
        }

        // Populates data for existing back number.
        private void SetExistingData()
        {
            PopulateBackNoList();
            PopulateClassEntryList();
            PopulateHorseDropDown();
            PopulateRiderDropDown();

            this.Text = "Back Number " + ActiveBackNo.Number.ToString() + " - " + ActiveBackNo.RiderFirst + " " + ActiveBackNo.RiderLast + 
                " & " + ActiveBackNo.HorseName + " - TrotTrax";
            this.infoLabel.Text = ActiveBackNo.Number.ToString() + ". " + ActiveBackNo.RiderFirst + " " + ActiveBackNo.RiderLast + 
                " & " + ActiveBackNo.HorseName + "\nBack Number Detail";
            this.backNoBox.Text = ActiveBackNo.Number.ToString();
            this.backNoBox.Focus();
            this.modifyBtn.Text = "Save Changes";
            this.riderComboBox.SelectedValue = ActiveBackNo.RiderNo;
            this.horseComboBox.SelectedValue = ActiveBackNo.HorseNo;

            // Modify btn is disabled until changes are made. View back no., rider, and horse btns depend on presence of data.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;

            if (ActiveBackNo.BackNoList.Count() > 0)
            {
                this.viewBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewBackNoBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                this.viewBackNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewBackNoBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }

            if (ActiveBackNo.RiderList.Count() > 0)
            {
                viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewRiderBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                this.viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewRiderBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }

            if (ActiveBackNo.HorseList.Count() > 0)
            {
                viewHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewHorseBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                this.viewHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewHorseBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }

            IsNew = false;
            IsChanged = false;
        }

        #endregion

        #region Refresh Form

        // Refresh to new back number form.
        private void RefreshForm(string clubID, int year)
        {
            ActiveBackNo = new BackNumber(clubID, year);
            SetNewData();
        }

        // Refresh to existing back number form.
        private void RefreshForm(string clubID, int year, int horseNo)
        {
            ActiveBackNo = new BackNumber(clubID, year, horseNo);
            SetExistingData();
        }

        private void RefreshOnClose(object sender, FormClosingEventArgs e)
        {
            if (AbandonChanges())
                if (IsNew)
                    RefreshForm(ActiveBackNo.ClubID, ActiveBackNo.Year);
                else
                    RefreshForm(ActiveBackNo.ClubID, ActiveBackNo.Year, ActiveBackNo.Number);
            else
            {
                PopulateBackNoList();
                PopulateClassEntryList();
                PopulateHorseDropDown();
                PopulateRiderDropDown();
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

        private void CancelChanges(object sender, EventArgs e)
        {
            if (AbandonChanges())
                this.Close();
        }

        #endregion

        #region Back Number Data

        private void SaveBackNo(object sender, EventArgs e)
        {
            if(IsChanged)
            {
                DialogResult confirm;
                int backNo = VerifyUniqueBackNo(backNoBox.Text);
                int riderNo = VerifyExistsRiderNo(riderComboBox.SelectedValue.ToString());
                int horseNo = VerifyExistsHorseNo(horseComboBox.SelectedValue.ToString());

                // Ensure required parameters are satisfied.
                if (backNo <= 0 || riderNo <= 0 || horseNo <= 0)
                    return;

                // If it's a new entry, go ahead and add it. Prompt for more additions.
                if (IsNew)
                {
                    if (ActiveBackNo.AddBackNo(backNo, riderNo, horseNo))
                    {
                        confirm = MessageBox.Show("Would you like to add another back number?", "TrotTrax Alert", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                            RefreshForm(ActiveBackNo.ClubID, ActiveBackNo.Year);
                        else
                            RefreshForm(ActiveBackNo.ClubID, ActiveBackNo.Year, backNo);
                    }
                    // Something went wrong.
                    else
                        confirm = MessageBox.Show("Something went wrong. Unable to save back number at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
                // Otherwise: do or do not, there is no try.
                else
                {
                    if (ActiveBackNo.ModifyBackNo(backNo, riderNo, horseNo))
                        RefreshForm(ActiveBackNo.ClubID, ActiveBackNo.Year, backNo);
                    // Unless something terrible happens.
                    else
                        confirm = MessageBox.Show("Something went wrong. Unable to save back number at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
            }
        }

        private void DeleteBackNo(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this back number?\n" +
                        "This operation CANNOT be undone.",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    ActiveBackNo.RemoveBackNo();
                    RefreshForm(ActiveBackNo.ClubID, ActiveBackNo.Year);
                }
            }
        }

        #endregion

        #region Horse & Rider Selections

        private void PopulateHorseDropDown()
        {
            // Initializes box with a 'null' item for display purposes.
            HorseDropDown = new List<DropDownItem>();
            HorseDropDown.Add(new DropDownItem() { No = 0, Name = "Select Horse" });

            // Adds the contents of the category item list retrieved from the database.
            foreach (HorseItem entry in ActiveBackNo.HorseList)
                HorseDropDown.Add(new DropDownItem() { No = entry.No, Name = entry.Name });

            // Sets this list as the menu's data source and tells the menu which parts to show.
            this.horseComboBox.DataSource = HorseDropDown;
            this.horseComboBox.DisplayMember = "name";
            this.horseComboBox.ValueMember = "no";
        }

        private void ViewHorse(object sender, EventArgs e)
        {
            if (AbandonChanges())
            {
                int horseNo = VerifyExistsHorseNo(horseComboBox.SelectedValue.ToString());
                if (horseNo > 0)
                {
                    HorseListForm form = new HorseListForm(ActiveBackNo.ClubID, ActiveBackNo.Year, horseNo);
                    form.Visible = true;
                    this.Close();
                }
            }
        }

        private void PopulateRiderDropDown()
        {
            // Initializes box with a 'null' item for display purposes.
            RiderDropDown = new List<DropDownItem>();
            RiderDropDown.Add(new DropDownItem() { No = 0, Name = "Select Rider" });

            // Adds the contents of the category item list retrieved from the database.
            foreach (RiderItem entry in ActiveBackNo.RiderList)
                RiderDropDown.Add(new DropDownItem() { No = entry.No, Name = entry.LastName + ", " + entry.FirstName});

            // Sets this list as the menu's data source and tells the menu which parts to show.
            this.riderComboBox.DataSource = RiderDropDown;
            this.riderComboBox.DisplayMember = "name";
            this.riderComboBox.ValueMember = "no";
        }

        private void ViewRider(object sender, EventArgs e)
        {
            if (AbandonChanges())
            {
                int riderNo = VerifyExistsRiderNo(riderComboBox.SelectedValue.ToString());
                if (riderNo > 0)
                {
                    RiderListForm form = new RiderListForm(ActiveBackNo.ClubID, ActiveBackNo.Year, riderNo);
                    form.Visible = true;
                    this.Close();
                }
            }
        }

        #endregion

        #region Back Number List

        private void PopulateBackNoList()
        {
            backNoListBox.Items.Clear();
            foreach (BackNoItem entry in ActiveBackNo.BackNoList)
            {
                string[] row = { entry.RiderNo.ToString(), entry.RiderFirst, entry.RiderLast, entry.HorseNo.ToString(), entry.Horse };
                backNoListBox.Items.Add(entry.No.ToString()).SubItems.AddRange(row);
            }
        }

        private void SortBackNoList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                ActiveBackNo.SortBackNos(BackNoSort.Number);
            else if (e.Column == 2)
                ActiveBackNo.SortBackNos(BackNoSort.RiderFirst);
            else if (e.Column == 3)
                ActiveBackNo.SortBackNos(BackNoSort.RiderLast);
            else if (e.Column == 5)
                ActiveBackNo.SortBackNos(BackNoSort.Horse);
            PopulateBackNoList();
        }

        private void NewBackNo(object sender, EventArgs e)
        {
            if(AbandonChanges())
            {
                RefreshForm(ActiveBackNo.ClubID, ActiveBackNo.Year);
            }
        }

        private void ViewBackNo(object sender, EventArgs e)
        {
            if (backNoListBox.SelectedItems.Count != 0)
            {
                int backNo = -1;

                if (AbandonChanges())
                    backNo = Convert.ToInt32(backNoListBox.SelectedItems[0].Text);
                if (backNo >= 0)
                    RefreshForm(ActiveBackNo.ClubID, ActiveBackNo.Year, backNo);
            }
        }

        #endregion

        #region Class Entry List

        private void PopulateClassEntryList()
        {
            classEntryListBox.Items.Clear();
            foreach (ResultItem entry in ActiveBackNo.ResultList)
            {
                string[] row = { entry.ClassName, entry.Place.ToString(), entry.Time.ToString(), entry.Points.ToString() };
                backNoListBox.Items.Add(entry.ShowDate.ToString()).SubItems.AddRange(row);
            }
        }

        #endregion

        #region Data Entry Verifiers

        // Checks that back no. is an integer and that it is unique. Returns -1 on error.
        private int VerifyUniqueBackNo(string backNoString)
        {
            DialogResult confirm;
            int backNo;
            if (Int32.TryParse(backNoString, out backNo))
            {
                if (!ActiveBackNo.CheckIndexUsed(ItemType.BackNo, backNo) || backNo == ActiveBackNo.Number)
                {
                    return backNo;
                }
                else
                {
                    confirm = MessageBox.Show("Back number must be unique.",
                        "TrotTrax Alert", MessageBoxButtons.OK);
                    return -1;
                }
            }
            confirm = MessageBox.Show("Back number must be an integer value.",
                "TrotTrax Alert", MessageBoxButtons.OK);

            return -1;
        }

        // Checks that rider exists in database. Returns -1 on error.
        private int VerifyExistsRiderNo(string riderNoString)
        {
            DialogResult confirm;
            int riderNo;
            if (Int32.TryParse(riderNoString, out riderNo))
            {
                if (ActiveBackNo.CheckIndexUsed(ItemType.Rider, riderNo))
                {
                    return riderNo;
                }
                else
                {
                    confirm = MessageBox.Show("Rider does not exist in database.",
                        "TrotTrax Alert", MessageBoxButtons.OK);
                    return -1;
                }
            }
            confirm = MessageBox.Show("Unable to identify rider.",
                "TrotTrax Alert", MessageBoxButtons.OK);

            return -1;
        }

        // Checks that horse exists in database. Returns -1 on error.
        private int VerifyExistsHorseNo(string horseNoString)
        {
            DialogResult confirm;
            int horseNo;
            if (Int32.TryParse(horseNoString, out horseNo))
            {
                if (ActiveBackNo.CheckIndexUsed(ItemType.Horse, horseNo))
                {
                    return horseNo;
                }
                else
                {
                    confirm = MessageBox.Show("Horse does not exist in database.",
                        "TrotTrax Alert", MessageBoxButtons.OK);
                    return -1;
                }
            }
            confirm = MessageBox.Show("Unable to identify horse.",
                "TrotTrax Alert", MessageBoxButtons.OK);

            return -1;
        }

        #endregion
    }
}
