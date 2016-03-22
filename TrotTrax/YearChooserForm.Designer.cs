/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */
 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YearChooserForm));
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
            this.yearChooserGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yearChooserGroup.Controls.Add(this.yearPicker);
            this.yearChooserGroup.Controls.Add(this.introLabel);
            this.yearChooserGroup.Controls.Add(this.cancelBtn);
            this.yearChooserGroup.Controls.Add(this.okBtn);
            this.yearChooserGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearChooserGroup.Location = new System.Drawing.Point(12, 12);
            this.yearChooserGroup.Name = "yearChooserGroup";
            this.yearChooserGroup.Size = new System.Drawing.Size(326, 135);
            this.yearChooserGroup.TabIndex = 3;
            this.yearChooserGroup.TabStop = false;
            this.yearChooserGroup.Text = "New Show Year";
            // 
            // yearPicker
            // 
            this.yearPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yearPicker.CustomFormat = "yyyy";
            this.yearPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearPicker.Location = new System.Drawing.Point(6, 65);
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.ShowUpDown = true;
            this.yearPicker.Size = new System.Drawing.Size(314, 26);
            this.yearPicker.TabIndex = 8;
            this.yearPicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyStroke);
            // 
            // introLabel
            // 
            this.introLabel.AutoSize = true;
            this.introLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introLabel.Location = new System.Drawing.Point(6, 22);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(322, 20);
            this.introLabel.TabIndex = 7;
            this.introLabel.Text = "Please select the show year you wish to add:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(217, 97);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(103, 32);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(121, 97);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(90, 32);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "Okay";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkayBtn);
            // 
            // YearChooserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 158);
            this.Controls.Add(this.yearChooserGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YearChooserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TrotTrax - New Show Year";
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