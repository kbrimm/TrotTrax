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
            nonmemberPointsCheckBox.Checked = ActiveSettings.NonMemberPoints;           
            // Set points scheme radio buttons
            switch (ActiveSettings.PointsSchemeType)
            {
                case 'f': flatPointsRadioButton.Checked = true; break;
                case 'g': graduatedPointsRadioButton.Checked = true; break;
            }
            placingCountTextBox.Text = ActiveSettings.Placings.ToString();
            EntryFeeGroupAction();
        }

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

        #endregion

        private void SaveSettings(object sender, EventArgs e)
        {
            ActiveSettings.SaveValues();
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculateColumns(object sender, EventArgs e)
        {
            int places = -1;
            if(Int32.TryParse(placingCountTextBox.Text, out places) && places > 0)
            {

            }
        }
    }
}
