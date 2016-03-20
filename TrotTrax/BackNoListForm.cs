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

        public BackNoListForm(string clubID, int year)
        {
            ActiveBackNo = new BackNumber(clubID, year);
            InitializeComponent();
            SetNewData();
        }

        private void SetNewData()
        {
            PopulateBackNoList();
            PopulateHorseDropDown();
            PopulateRiderDropDown();
            
            this.Text = "New Back Number - TrotTrax";
            horseLabel.Text = "New Back Number\nSetup";
            this.backNoBox.Text = ActiveBackNo.Number.ToString();
            this.backNoBox.Focus();
            this.modifyBtn.Text = "Add Back No.";

            // Modify btn is disabled until changes are made. Cannot delete for an unsaved record.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, 
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;

            IsNew = true;
            IsChanged = false;
        }

        public BackNoListForm(string clubID, int year, int backNo)
        {
            ActiveBackNo = new BackNumber(clubID, year, backNo);
            InitializeComponent();
            SetExistingData();
        }

        private void SetExistingData()
        {
            PopulateBackNoList();
            PopulateClassEntryList();
            PopulateHorseDropDown();
            PopulateRiderDropDown();

            this.Text = "New Back Number - TrotTrax";
            horseLabel.Text = "New Back Number\nSetup";
            this.backNoBox.Text = ActiveBackNo.Number.ToString();
            this.backNoBox.Focus();
            this.modifyBtn.Text = "Add Back No.";

            // Modify btn is disabled until changes are made.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;

            IsNew = false;
            IsChanged = false;
        }

        #endregion

        #region Refresh Form

        // Refresh to new horse form.
        private void RefreshForm(string clubID, int year)
        {
            ActiveBackNo = new BackNumber(clubID, year);
            SetNewData();
        }

        // Refresh to existing horse form.
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

        #endregion

        #region Back Number Data

        private void PopulateHorseDropDown()
        {

        }

        private void PopulateRiderDropDown()
        {

        }

        #endregion

        #region Back Number List

        private void PopulateBackNoList()
        {

        }

        #endregion

        #region Class Entry List

        private void PopulateClassEntryList()
        {

        }

        #endregion
    }
}
