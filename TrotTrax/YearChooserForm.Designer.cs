namespace TrotTrax
{
    partial class YearChooserForm
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
            this.yearChooserGroup = new System.Windows.Forms.GroupBox();
            this.yearPicker = new System.Windows.Forms.DateTimePicker();
            this.introLabel = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.yearChooserGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // yearChooserGroup
            // 
            this.yearChooserGroup.Controls.Add(this.yearPicker);
            this.yearChooserGroup.Controls.Add(this.introLabel);
            this.yearChooserGroup.Controls.Add(this.cancelBtn);
            this.yearChooserGroup.Controls.Add(this.okBtn);
            this.yearChooserGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearChooserGroup.Location = new System.Drawing.Point(12, 12);
            this.yearChooserGroup.Name = "yearChooserGroup";
            this.yearChooserGroup.Size = new System.Drawing.Size(335, 170);
            this.yearChooserGroup.TabIndex = 3;
            this.yearChooserGroup.TabStop = false;
            this.yearChooserGroup.Text = "Choose A Year";
            // 
            // yearPicker
            // 
            this.yearPicker.CustomFormat = "yyyy";
            this.yearPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearPicker.Location = new System.Drawing.Point(6, 98);
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.Size = new System.Drawing.Size(323, 26);
            this.yearPicker.TabIndex = 8;
            // 
            // introLabel
            // 
            this.introLabel.AutoSize = true;
            this.introLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introLabel.Location = new System.Drawing.Point(6, 46);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(319, 36);
            this.introLabel.TabIndex = 7;
            this.introLabel.Text = "Please select the year you wish to access, then\r\nclick \'Okay\'.";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(239, 130);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(90, 32);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(143, 130);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(90, 32);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "Okay";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // YearChooserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 193);
            this.Controls.Add(this.yearChooserGroup);
            this.Name = "YearChooserForm";
            this.Text = "TrotTrax";
            this.yearChooserGroup.ResumeLayout(false);
            this.yearChooserGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox yearChooserGroup;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label introLabel;
        private System.Windows.Forms.DateTimePicker yearPicker;
    }
}