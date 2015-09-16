/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */
 
 namespace TrotTrax
{
    partial class ClubChooserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClubChooserForm));
            this.getStartedGroup = new System.Windows.Forms.GroupBox();
            this.introLabel = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.nameBoxLabel = new System.Windows.Forms.Label();
            this.nameField = new System.Windows.Forms.TextBox();
            this.getStartedGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // getStartedGroup
            // 
            this.getStartedGroup.Controls.Add(this.introLabel);
            this.getStartedGroup.Controls.Add(this.cancelBtn);
            this.getStartedGroup.Controls.Add(this.okBtn);
            this.getStartedGroup.Controls.Add(this.nameBoxLabel);
            this.getStartedGroup.Controls.Add(this.nameField);
            this.getStartedGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getStartedGroup.Location = new System.Drawing.Point(12, 12);
            this.getStartedGroup.Name = "getStartedGroup";
            this.getStartedGroup.Size = new System.Drawing.Size(373, 152);
            this.getStartedGroup.TabIndex = 1;
            this.getStartedGroup.TabStop = false;
            this.getStartedGroup.Text = "New Club";
            // 
            // introLabel
            // 
            this.introLabel.AutoSize = true;
            this.introLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introLabel.Location = new System.Drawing.Point(6, 22);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(364, 20);
            this.introLabel.TabIndex = 5;
            this.introLabel.Text = "Please enter the name of the club you wish to add:\r\n";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(275, 114);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(92, 32);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(179, 114);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(90, 32);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "Okay";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkayBtn);
            // 
            // nameBoxLabel
            // 
            this.nameBoxLabel.AutoSize = true;
            this.nameBoxLabel.Location = new System.Drawing.Point(6, 59);
            this.nameBoxLabel.Name = "nameBoxLabel";
            this.nameBoxLabel.Size = new System.Drawing.Size(89, 20);
            this.nameBoxLabel.TabIndex = 2;
            this.nameBoxLabel.Text = "Club name:";
            // 
            // nameField
            // 
            this.nameField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameField.Location = new System.Drawing.Point(6, 82);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(361, 26);
            this.nameField.TabIndex = 1;
            this.nameField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyStroke);
            // 
            // ClubChooserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(397, 176);
            this.Controls.Add(this.getStartedGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClubChooserForm";
            this.Text = "TrotTrax - New Club";
            this.getStartedGroup.ResumeLayout(false);
            this.getStartedGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox getStartedGroup;
        private System.Windows.Forms.Label nameBoxLabel;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label introLabel;
    }
}

