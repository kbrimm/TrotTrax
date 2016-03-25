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
    public partial class SettingsForm : Form
    {
        private Settings ActiveSettings;

        #region Constructors/Initializors

        public SettingsForm(string clubId, int year)
        {
            ActiveSettings = new Settings(clubId, year);
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Set entry fee radio button/values.
            switch (ActiveSettings.EntryFeeDiscountType)
            {
                case 'n': this.discountCheckBox.Checked = false; break;
                case 'f': this.discountCheckBox.Checked = true;
                    this.flatDiscountRadioBtn.Checked = true;
                    this.flatDiscountTextBox.Text = ActiveSettings.EntryFeeDiscountAmount.ToString();
                    break;
                case 'p': this.discountCheckBox.Checked = true;
                    this.percentDiscountRadioBtn.Checked = true;
                    this.percentDiscountTextBox.Text = ActiveSettings.EntryFeeDiscountAmount.ToString();
                    break;
            }
            nonmemberPointsCheckBox.Checked = ActiveSettings.NonMemberPoint;           
            // Set points scheme radio buttons
            switch (ActiveSettings.PointSchemeType)
            {
                case 'f': flatPointsRadioButton.Checked = true; break;
                case 'g': graduatedPointsRadioButton.Checked = true; break;
            }
            placingCountTextBox.Text = ActiveSettings.PlacingNo.ToString();
            EntryFeeGroupAction();
        }

        #endregion

        #region Dynamic Form Elements

        // Sets elements active/inactive based on entry fee group selections. Triggers on change of status/leaving.
        private void EntryFeeGroupAction(object sender=null, EventArgs e=null)
        {
            // If there is not discount selected, grey out discount radio selectors and text boxes.
            if(!discountCheckBox.Checked)
            {
                this.flatDiscountRadioBtn.Checked = false;
                this.flatDiscountRadioBtn.Enabled = false;
                this.flatDiscountRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.flatDiscountRadioBtn.ForeColor = System.Drawing.SystemColors.GrayText;
                this.flatDiscountTextBox.Text = String.Empty;
                this.flatDiscountTextBox.Enabled = false;
                this.flatDiscountTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
                this.percentDiscountRadioBtn.Checked = false;
                this.percentDiscountRadioBtn.Enabled = false;
                this.percentDiscountRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.percentDiscountRadioBtn.ForeColor = System.Drawing.SystemColors.GrayText;
                this.percentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.percentLabel.ForeColor = System.Drawing.SystemColors.GrayText;
                this.percentDiscountTextBox.Text = String.Empty;
                this.percentDiscountTextBox.Enabled = false;
                this.percentDiscountTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            } 
            else
            {
                this.flatDiscountRadioBtn.Enabled = true;
                this.flatDiscountRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.flatDiscountRadioBtn.ForeColor = System.Drawing.SystemColors.ControlText;
                this.flatDiscountTextBox.Enabled = true;
                this.flatDiscountTextBox.BackColor = System.Drawing.SystemColors.Window;
                this.percentDiscountRadioBtn.Enabled = true;
                this.percentDiscountRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.percentDiscountRadioBtn.ForeColor = System.Drawing.SystemColors.ControlText;
                this.percentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.percentLabel.ForeColor = System.Drawing.SystemColors.ControlText;
                this.percentDiscountTextBox.Enabled = true;
                this.percentDiscountTextBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void DiscountSelectionAction(object sender, EventArgs e)
        {
            if(flatDiscountRadioBtn.Checked)
            {
                this.flatDiscountTextBox.BackColor = System.Drawing.SystemColors.Window;
                this.flatDiscountTextBox.Enabled = true;
                this.percentDiscountTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
                this.percentDiscountTextBox.Enabled = false;
                this.percentDiscountTextBox.Text = String.Empty;
            }
            else if(percentDiscountRadioBtn.Checked)
            {
                this.percentDiscountTextBox.BackColor = System.Drawing.SystemColors.Window;
                this.percentDiscountTextBox.Enabled = true;
                this.flatDiscountTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
                this.flatDiscountTextBox.Enabled = false;
                this.flatDiscountTextBox.Text = String.Empty;
            }
        }

        private void CalculateColumns(object sender, EventArgs e)
        {
            int places = VerifyPlacings(placingCountTextBox.Text);
            if (places > 0)
            {

            }
        }

        #endregion

        #region Save/Close
        // In the absence of explicit settings, application will revert to defaults:
        // No discount, non-members accumulate points, flat points scheme, 6 places.
        private void SaveSettings(object sender, EventArgs e)
        {
            // Entry fee discount
            char discountType = 'n';
            decimal discountAmount = 0;
            if (flatDiscountRadioBtn.Checked)
            {
                discountType = 'f';
                discountAmount = VerifyDiscount(flatDiscountTextBox.Text);
            }
            else if (percentDiscountRadioBtn.Checked)
            {
                discountType = 'p';
                discountAmount = VerifyDiscount(percentDiscountTextBox.Text);
            }

            // Non-member points
            bool nonMemberPoint = false;
            if (nonmemberPointsCheckBox.Checked)
                nonMemberPoint = true;

            // Point scheme
            char schemeType = 'f';
            if (graduatedPointsRadioButton.Checked)
                schemeType = 'p';
            int placingNo = VerifyPlacings(placingCountTextBox.Text);

            if (discountAmount >= 0 && placingNo >= 0)
                ActiveSettings.SaveSettings(discountType, discountAmount, nonMemberPoint, schemeType, placingNo);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Data Verifiers

        private decimal VerifyDiscount(string discountString)
        {
            decimal discount = -1;

            bool validDiscount = decimal.TryParse(discountString, System.Globalization.NumberStyles.Any,
                new System.Globalization.CultureInfo("en-US"), out discount);
            if (discountString == String.Empty || !validDiscount || discount < 0)
            {
                DialogResult confirm = MessageBox.Show("Discount must be a positive decimal value.", 
                    "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }
            else
                return discount;
        }

        private int VerifyPlacings(string placeString)
        {
            int places = -1;

            bool validInteger = Int32.TryParse(placeString, out places);
            if (placeString == String.Empty || !validInteger || places < 0)
            {
                DialogResult confirm = MessageBox.Show("Number of places must be a positive integer value.",
                    "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }
            else
                return places;
        }

        #endregion

    }
}
