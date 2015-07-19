namespace TrotTrax
{
    partial class NewClubForm
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
            this.getStartedGroup = new System.Windows.Forms.GroupBox();
            this.trotTraxLabel = new System.Windows.Forms.Label();
            this.introText = new System.Windows.Forms.RichTextBox();
            this.nameField = new System.Windows.Forms.TextBox();
            this.nameBoxLabel = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.getStartedGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // getStartedGroup
            // 
            this.getStartedGroup.Controls.Add(this.cancelBtn);
            this.getStartedGroup.Controls.Add(this.okBtn);
            this.getStartedGroup.Controls.Add(this.nameBoxLabel);
            this.getStartedGroup.Controls.Add(this.nameField);
            this.getStartedGroup.Controls.Add(this.introText);
            this.getStartedGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getStartedGroup.Location = new System.Drawing.Point(12, 69);
            this.getStartedGroup.Name = "getStartedGroup";
            this.getStartedGroup.Size = new System.Drawing.Size(335, 228);
            this.getStartedGroup.TabIndex = 1;
            this.getStartedGroup.TabStop = false;
            this.getStartedGroup.Text = "Getting Started";
            // 
            // trotTraxLabel
            // 
            this.trotTraxLabel.AutoSize = true;
            this.trotTraxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trotTraxLabel.Location = new System.Drawing.Point(117, 15);
            this.trotTraxLabel.Name = "trotTraxLabel";
            this.trotTraxLabel.Size = new System.Drawing.Size(139, 37);
            this.trotTraxLabel.TabIndex = 0;
            this.trotTraxLabel.Text = "TrotTrax";
            // 
            // introText
            // 
            this.introText.BackColor = System.Drawing.SystemColors.Control;
            this.introText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.introText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.introText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introText.HideSelection = false;
            this.introText.Location = new System.Drawing.Point(6, 35);
            this.introText.Name = "introText";
            this.introText.ReadOnly = true;
            this.introText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.introText.Size = new System.Drawing.Size(323, 95);
            this.introText.TabIndex = 0;
            this.introText.Text = "Thank you for choosing TrotTrax!\n\nLet\'s get you all set up! The first step is to " +
    "start an account for your club. Please enter your club\'s name in the box below a" +
    "nd press \'Okay\'.";
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(6, 156);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(323, 26);
            this.nameField.TabIndex = 1;
            // 
            // nameBoxLabel
            // 
            this.nameBoxLabel.AutoSize = true;
            this.nameBoxLabel.Location = new System.Drawing.Point(6, 133);
            this.nameBoxLabel.Name = "nameBoxLabel";
            this.nameBoxLabel.Size = new System.Drawing.Size(89, 20);
            this.nameBoxLabel.TabIndex = 2;
            this.nameBoxLabel.Text = "Club name:";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(143, 188);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(90, 32);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "Okay";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(239, 188);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(90, 32);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // NewClubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 305);
            this.Controls.Add(this.getStartedGroup);
            this.Controls.Add(this.trotTraxLabel);
            this.Name = "NewClubForm";
            this.Text = "TrotTrax";
            this.getStartedGroup.ResumeLayout(false);
            this.getStartedGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox getStartedGroup;
        private System.Windows.Forms.Label nameBoxLabel;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.RichTextBox introText;
        private System.Windows.Forms.Label trotTraxLabel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
    }
}

