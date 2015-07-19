namespace TrotTrax
{
    partial class NewClub
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
            this.TrotTraxLabel = new System.Windows.Forms.Label();
            this.GettingStartedBox = new System.Windows.Forms.GroupBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.NameBoxLabel = new System.Windows.Forms.Label();
            this.NameField = new System.Windows.Forms.TextBox();
            this.IntroText = new System.Windows.Forms.RichTextBox();
            this.GettingStartedBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrotTraxLabel
            // 
            this.TrotTraxLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TrotTraxLabel.AutoSize = true;
            this.TrotTraxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrotTraxLabel.Location = new System.Drawing.Point(132, 10);
            this.TrotTraxLabel.Name = "TrotTraxLabel";
            this.TrotTraxLabel.Size = new System.Drawing.Size(105, 29);
            this.TrotTraxLabel.TabIndex = 0;
            this.TrotTraxLabel.Text = "TrotTrax";
            this.TrotTraxLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GettingStartedBox
            // 
            this.GettingStartedBox.Controls.Add(this.CancelButton);
            this.GettingStartedBox.Controls.Add(this.OkayButton);
            this.GettingStartedBox.Controls.Add(this.NameBoxLabel);
            this.GettingStartedBox.Controls.Add(this.NameField);
            this.GettingStartedBox.Controls.Add(this.IntroText);
            this.GettingStartedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GettingStartedBox.Location = new System.Drawing.Point(12, 61);
            this.GettingStartedBox.Name = "GettingStartedBox";
            this.GettingStartedBox.Size = new System.Drawing.Size(335, 233);
            this.GettingStartedBox.TabIndex = 1;
            this.GettingStartedBox.TabStop = false;
            this.GettingStartedBox.Text = "Getting Started";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(231, 195);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(97, 30);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OkayButton
            // 
            this.OkayButton.Location = new System.Drawing.Point(150, 195);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 30);
            this.OkayButton.TabIndex = 3;
            this.OkayButton.Text = "Okay";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // NameBoxLabel
            // 
            this.NameBoxLabel.AutoSize = true;
            this.NameBoxLabel.Location = new System.Drawing.Point(6, 140);
            this.NameBoxLabel.Name = "NameBoxLabel";
            this.NameBoxLabel.Size = new System.Drawing.Size(91, 20);
            this.NameBoxLabel.TabIndex = 2;
            this.NameBoxLabel.Text = "Club Name:";
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(6, 163);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(322, 26);
            this.NameField.TabIndex = 1;
            // 
            // IntroText
            // 
            this.IntroText.BackColor = System.Drawing.SystemColors.Control;
            this.IntroText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IntroText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IntroText.Location = new System.Drawing.Point(7, 26);
            this.IntroText.Name = "IntroText";
            this.IntroText.ReadOnly = true;
            this.IntroText.Size = new System.Drawing.Size(322, 89);
            this.IntroText.TabIndex = 0;
            this.IntroText.Text = "Thank you for choosing TrotTrax!\n\nLet\'s get you all set up! The first step is to " +
    "start an account for your club. Please enter your club\'s name in the box below a" +
    "nd press Okay.";
            // 
            // NewClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 304);
            this.Controls.Add(this.GettingStartedBox);
            this.Controls.Add(this.TrotTraxLabel);
            this.Name = "NewClub";
            this.Text = "TrotTrax";
            this.GettingStartedBox.ResumeLayout(false);
            this.GettingStartedBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TrotTraxLabel;
        private System.Windows.Forms.GroupBox GettingStartedBox;
        private System.Windows.Forms.RichTextBox IntroText;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Label NameBoxLabel;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.Button CancelButton;
    }
}