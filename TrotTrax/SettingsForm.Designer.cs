namespace TrotTrax
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.percentLabel = new System.Windows.Forms.Label();
            this.percentDiscountRadioBtn = new System.Windows.Forms.RadioButton();
            this.percentDiscountTextBox = new System.Windows.Forms.TextBox();
            this.flatDiscountRadioBtn = new System.Windows.Forms.RadioButton();
            this.nonmemberPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.flatDiscountTextBox = new System.Windows.Forms.TextBox();
            this.discountCheckBox = new System.Windows.Forms.CheckBox();
            this.pointsGroupBox = new System.Windows.Forms.GroupBox();
            this.entryCountLabel = new System.Windows.Forms.Label();
            this.pointValueLabel = new System.Windows.Forms.Label();
            this.pointSchemeGridView = new System.Windows.Forms.DataGridView();
            this.placingCountTextBox = new System.Windows.Forms.TextBox();
            this.placingsLabel = new System.Windows.Forms.Label();
            this.graduatedPointsRadioButton = new System.Windows.Forms.RadioButton();
            this.flatPointsRadioButton = new System.Windows.Forms.RadioButton();
            this.schemeLabel = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.settingsGroupBox.SuspendLayout();
            this.pointsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointSchemeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.percentLabel);
            this.settingsGroupBox.Controls.Add(this.percentDiscountRadioBtn);
            this.settingsGroupBox.Controls.Add(this.percentDiscountTextBox);
            this.settingsGroupBox.Controls.Add(this.flatDiscountRadioBtn);
            this.settingsGroupBox.Controls.Add(this.nonmemberPointsCheckBox);
            this.settingsGroupBox.Controls.Add(this.flatDiscountTextBox);
            this.settingsGroupBox.Controls.Add(this.discountCheckBox);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(481, 76);
            this.settingsGroupBox.TabIndex = 0;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "TrotTrax Settings";
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Location = new System.Drawing.Point(454, 29);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(15, 13);
            this.percentLabel.TabIndex = 6;
            this.percentLabel.Text = "%";
            // 
            // percentDiscountRadioBtn
            // 
            this.percentDiscountRadioBtn.AutoSize = true;
            this.percentDiscountRadioBtn.Location = new System.Drawing.Point(320, 27);
            this.percentDiscountRadioBtn.Name = "percentDiscountRadioBtn";
            this.percentDiscountRadioBtn.Size = new System.Drawing.Size(65, 17);
            this.percentDiscountRadioBtn.TabIndex = 5;
            this.percentDiscountRadioBtn.TabStop = true;
            this.percentDiscountRadioBtn.Text = "Percent:";
            this.percentDiscountRadioBtn.UseVisualStyleBackColor = true;
            // 
            // percentDiscountTextBox
            // 
            this.percentDiscountTextBox.Location = new System.Drawing.Point(383, 26);
            this.percentDiscountTextBox.Name = "percentDiscountTextBox";
            this.percentDiscountTextBox.Size = new System.Drawing.Size(65, 20);
            this.percentDiscountTextBox.TabIndex = 4;
            // 
            // flatDiscountRadioBtn
            // 
            this.flatDiscountRadioBtn.AutoSize = true;
            this.flatDiscountRadioBtn.Location = new System.Drawing.Point(189, 27);
            this.flatDiscountRadioBtn.Name = "flatDiscountRadioBtn";
            this.flatDiscountRadioBtn.Size = new System.Drawing.Size(57, 17);
            this.flatDiscountRadioBtn.TabIndex = 3;
            this.flatDiscountRadioBtn.TabStop = true;
            this.flatDiscountRadioBtn.Text = "Flat:  $";
            this.flatDiscountRadioBtn.UseVisualStyleBackColor = true;
            // 
            // nonmemberPointsCheckBox
            // 
            this.nonmemberPointsCheckBox.AutoSize = true;
            this.nonmemberPointsCheckBox.Location = new System.Drawing.Point(6, 51);
            this.nonmemberPointsCheckBox.Name = "nonmemberPointsCheckBox";
            this.nonmemberPointsCheckBox.Size = new System.Drawing.Size(183, 17);
            this.nonmemberPointsCheckBox.TabIndex = 2;
            this.nonmemberPointsCheckBox.Text = "Non-Members Accumulate Points";
            this.nonmemberPointsCheckBox.UseVisualStyleBackColor = true;
            // 
            // flatDiscountTextBox
            // 
            this.flatDiscountTextBox.Location = new System.Drawing.Point(248, 26);
            this.flatDiscountTextBox.Name = "flatDiscountTextBox";
            this.flatDiscountTextBox.Size = new System.Drawing.Size(65, 20);
            this.flatDiscountTextBox.TabIndex = 1;
            // 
            // discountCheckBox
            // 
            this.discountCheckBox.AutoSize = true;
            this.discountCheckBox.Location = new System.Drawing.Point(6, 28);
            this.discountCheckBox.Name = "discountCheckBox";
            this.discountCheckBox.Size = new System.Drawing.Size(177, 17);
            this.discountCheckBox.TabIndex = 0;
            this.discountCheckBox.Text = "Entry Fee Discount for Members";
            this.discountCheckBox.UseVisualStyleBackColor = true;
            this.discountCheckBox.CheckedChanged += new System.EventHandler(this.EntryFeeGroupAction);
            this.discountCheckBox.Leave += new System.EventHandler(this.EntryFeeGroupAction);
            // 
            // pointsGroupBox
            // 
            this.pointsGroupBox.Controls.Add(this.entryCountLabel);
            this.pointsGroupBox.Controls.Add(this.pointValueLabel);
            this.pointsGroupBox.Controls.Add(this.pointSchemeGridView);
            this.pointsGroupBox.Controls.Add(this.placingCountTextBox);
            this.pointsGroupBox.Controls.Add(this.placingsLabel);
            this.pointsGroupBox.Controls.Add(this.graduatedPointsRadioButton);
            this.pointsGroupBox.Controls.Add(this.flatPointsRadioButton);
            this.pointsGroupBox.Controls.Add(this.schemeLabel);
            this.pointsGroupBox.Location = new System.Drawing.Point(12, 94);
            this.pointsGroupBox.Name = "pointsGroupBox";
            this.pointsGroupBox.Size = new System.Drawing.Size(481, 273);
            this.pointsGroupBox.TabIndex = 1;
            this.pointsGroupBox.TabStop = false;
            this.pointsGroupBox.Text = "Points Distribution Settings";
            // 
            // entryCountLabel
            // 
            this.entryCountLabel.AutoSize = true;
            this.entryCountLabel.Location = new System.Drawing.Point(6, 76);
            this.entryCountLabel.Name = "entryCountLabel";
            this.entryCountLabel.Size = new System.Drawing.Size(59, 13);
            this.entryCountLabel.TabIndex = 7;
            this.entryCountLabel.Text = "No. Entries";
            // 
            // pointValueLabel
            // 
            this.pointValueLabel.AutoSize = true;
            this.pointValueLabel.Location = new System.Drawing.Point(90, 76);
            this.pointValueLabel.Name = "pointValueLabel";
            this.pointValueLabel.Size = new System.Drawing.Size(106, 13);
            this.pointValueLabel.TabIndex = 6;
            this.pointValueLabel.Text = "Point Value for Place";
            // 
            // pointSchemeGridView
            // 
            this.pointSchemeGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pointSchemeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pointSchemeGridView.Location = new System.Drawing.Point(9, 92);
            this.pointSchemeGridView.Name = "pointSchemeGridView";
            this.pointSchemeGridView.Size = new System.Drawing.Size(466, 172);
            this.pointSchemeGridView.TabIndex = 5;
            // 
            // placingCountTextBox
            // 
            this.placingCountTextBox.Location = new System.Drawing.Point(114, 47);
            this.placingCountTextBox.Name = "placingCountTextBox";
            this.placingCountTextBox.Size = new System.Drawing.Size(128, 20);
            this.placingCountTextBox.TabIndex = 4;
            this.placingCountTextBox.Leave += new System.EventHandler(this.CalculateColumns);
            // 
            // placingsLabel
            // 
            this.placingsLabel.AutoSize = true;
            this.placingsLabel.Location = new System.Drawing.Point(6, 50);
            this.placingsLabel.Name = "placingsLabel";
            this.placingsLabel.Size = new System.Drawing.Size(102, 13);
            this.placingsLabel.TabIndex = 3;
            this.placingsLabel.Text = "Number of Placings:";
            // 
            // graduatedPointsRadioButton
            // 
            this.graduatedPointsRadioButton.AutoSize = true;
            this.graduatedPointsRadioButton.Location = new System.Drawing.Point(248, 23);
            this.graduatedPointsRadioButton.Name = "graduatedPointsRadioButton";
            this.graduatedPointsRadioButton.Size = new System.Drawing.Size(200, 17);
            this.graduatedPointsRadioButton.TabIndex = 2;
            this.graduatedPointsRadioButton.TabStop = true;
            this.graduatedPointsRadioButton.Text = "Graduated (Dependent on class size)";
            this.graduatedPointsRadioButton.UseVisualStyleBackColor = true;
            // 
            // flatPointsRadioButton
            // 
            this.flatPointsRadioButton.AutoSize = true;
            this.flatPointsRadioButton.Location = new System.Drawing.Point(93, 23);
            this.flatPointsRadioButton.Name = "flatPointsRadioButton";
            this.flatPointsRadioButton.Size = new System.Drawing.Size(149, 17);
            this.flatPointsRadioButton.TabIndex = 1;
            this.flatPointsRadioButton.TabStop = true;
            this.flatPointsRadioButton.Text = "Flat (Same for every class)";
            this.flatPointsRadioButton.UseVisualStyleBackColor = true;
            // 
            // schemeLabel
            // 
            this.schemeLabel.AutoSize = true;
            this.schemeLabel.Location = new System.Drawing.Point(6, 25);
            this.schemeLabel.Name = "schemeLabel";
            this.schemeLabel.Size = new System.Drawing.Size(81, 13);
            this.schemeLabel.TabIndex = 0;
            this.schemeLabel.Text = "Points Scheme:";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(331, 373);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveSettings);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(412, 373);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CloseForm);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 405);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.pointsGroupBox);
            this.Controls.Add(this.settingsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(521, 443);
            this.MinimumSize = new System.Drawing.Size(521, 443);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application Settings - TrotTrax";
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.pointsGroupBox.ResumeLayout(false);
            this.pointsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointSchemeGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.CheckBox nonmemberPointsCheckBox;
        private System.Windows.Forms.TextBox flatDiscountTextBox;
        private System.Windows.Forms.CheckBox discountCheckBox;
        private System.Windows.Forms.GroupBox pointsGroupBox;
        private System.Windows.Forms.DataGridView pointSchemeGridView;
        private System.Windows.Forms.TextBox placingCountTextBox;
        private System.Windows.Forms.Label placingsLabel;
        private System.Windows.Forms.RadioButton graduatedPointsRadioButton;
        private System.Windows.Forms.RadioButton flatPointsRadioButton;
        private System.Windows.Forms.Label schemeLabel;
        private System.Windows.Forms.Label pointValueLabel;
        private System.Windows.Forms.Label entryCountLabel;
        private System.Windows.Forms.RadioButton percentDiscountRadioBtn;
        private System.Windows.Forms.TextBox percentDiscountTextBox;
        private System.Windows.Forms.RadioButton flatDiscountRadioBtn;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}