/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */

namespace TrotTrax
{
    partial class HorseListForm
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
            this.horseBox = new System.Windows.Forms.GroupBox();
            this.horseListBox = new System.Windows.Forms.ListView();
            this.horseNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.newHorseBtn = new System.Windows.Forms.Button();
            this.viewHorseBtn = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.commentsBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.heightLabel = new System.Windows.Forms.Label();
            this.callNameBox = new System.Windows.Forms.TextBox();
            this.altNameLabel = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.fullNameBox = new System.Windows.Forms.TextBox();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.horseNoLabel = new System.Windows.Forms.Label();
            this.riderListGroup = new System.Windows.Forms.GroupBox();
            this.backNoLabel = new System.Windows.Forms.Label();
            this.backNoBox = new System.Windows.Forms.TextBox();
            this.riderComboBox = new System.Windows.Forms.ComboBox();
            this.addRiderBtn = new System.Windows.Forms.Button();
            this.riderListBox = new System.Windows.Forms.ListView();
            this.backNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.riderNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewRiderBtn = new System.Windows.Forms.Button();
            this.horseLabel = new System.Windows.Forms.Label();
            this.ownerBox = new System.Windows.Forms.TextBox();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.horseBox.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.riderListGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // horseBox
            // 
            this.horseBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.horseBox.Controls.Add(this.horseListBox);
            this.horseBox.Controls.Add(this.newHorseBtn);
            this.horseBox.Controls.Add(this.viewHorseBtn);
            this.horseBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horseBox.Location = new System.Drawing.Point(12, 92);
            this.horseBox.Name = "horseBox";
            this.horseBox.Size = new System.Drawing.Size(226, 386);
            this.horseBox.TabIndex = 0;
            this.horseBox.TabStop = false;
            this.horseBox.Text = "Horses Shown";
            // 
            // horseListBox
            // 
            this.horseListBox.AllowColumnReorder = true;
            this.horseListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.horseListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.horseNameHeader});
            this.horseListBox.FullRowSelect = true;
            this.horseListBox.LabelWrap = false;
            this.horseListBox.Location = new System.Drawing.Point(7, 21);
            this.horseListBox.MultiSelect = false;
            this.horseListBox.Name = "horseListBox";
            this.horseListBox.Size = new System.Drawing.Size(213, 328);
            this.horseListBox.TabIndex = 0;
            this.horseListBox.TabStop = false;
            this.horseListBox.UseCompatibleStateImageBehavior = false;
            this.horseListBox.View = System.Windows.Forms.View.Details;
            // 
            // horseNameHeader
            // 
            this.horseNameHeader.Text = "Name";
            this.horseNameHeader.Width = 188;
            // 
            // newHorseBtn
            // 
            this.newHorseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newHorseBtn.Location = new System.Drawing.Point(109, 355);
            this.newHorseBtn.Name = "newHorseBtn";
            this.newHorseBtn.Size = new System.Drawing.Size(111, 25);
            this.newHorseBtn.TabIndex = 0;
            this.newHorseBtn.Text = "New Horse";
            this.newHorseBtn.UseVisualStyleBackColor = true;
            this.newHorseBtn.Click += new System.EventHandler(this.NewHorse);
            // 
            // viewHorseBtn
            // 
            this.viewHorseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewHorseBtn.Location = new System.Drawing.Point(7, 355);
            this.viewHorseBtn.Name = "viewHorseBtn";
            this.viewHorseBtn.Size = new System.Drawing.Size(95, 25);
            this.viewHorseBtn.TabIndex = 0;
            this.viewHorseBtn.Text = "View Horse";
            this.viewHorseBtn.UseVisualStyleBackColor = true;
            this.viewHorseBtn.Click += new System.EventHandler(this.ViewHorse);
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.ownerBox);
            this.infoBox.Controls.Add(this.ownerLabel);
            this.infoBox.Controls.Add(this.commentsLabel);
            this.infoBox.Controls.Add(this.commentsBox);
            this.infoBox.Controls.Add(this.heightBox);
            this.infoBox.Controls.Add(this.heightLabel);
            this.infoBox.Controls.Add(this.callNameBox);
            this.infoBox.Controls.Add(this.altNameLabel);
            this.infoBox.Controls.Add(this.cancelBtn);
            this.infoBox.Controls.Add(this.deleteBtn);
            this.infoBox.Controls.Add(this.modifyBtn);
            this.infoBox.Controls.Add(this.fullNameBox);
            this.infoBox.Controls.Add(this.fullNameLabel);
            this.infoBox.Controls.Add(this.numberBox);
            this.infoBox.Controls.Add(this.horseNoLabel);
            this.infoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.Location = new System.Drawing.Point(243, 12);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(422, 466);
            this.infoBox.TabIndex = 17;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Horse Information";
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(6, 228);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(72, 16);
            this.commentsLabel.TabIndex = 15;
            this.commentsLabel.Text = "Comments";
            // 
            // commentsBox
            // 
            this.commentsBox.Location = new System.Drawing.Point(9, 247);
            this.commentsBox.Multiline = true;
            this.commentsBox.Name = "commentsBox";
            this.commentsBox.Size = new System.Drawing.Size(407, 182);
            this.commentsBox.TabIndex = 5;
            this.commentsBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(6, 194);
            this.heightBox.MaxLength = 255;
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(69, 22);
            this.heightBox.TabIndex = 3;
            this.heightBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(6, 175);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(47, 16);
            this.heightLabel.TabIndex = 13;
            this.heightLabel.Text = "Height";
            // 
            // callNameBox
            // 
            this.callNameBox.Location = new System.Drawing.Point(9, 141);
            this.callNameBox.MaxLength = 255;
            this.callNameBox.Name = "callNameBox";
            this.callNameBox.Size = new System.Drawing.Size(407, 22);
            this.callNameBox.TabIndex = 2;
            this.callNameBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // altNameLabel
            // 
            this.altNameLabel.AutoSize = true;
            this.altNameLabel.Location = new System.Drawing.Point(6, 122);
            this.altNameLabel.Name = "altNameLabel";
            this.altNameLabel.Size = new System.Drawing.Size(101, 16);
            this.altNameLabel.TabIndex = 11;
            this.altNameLabel.Text = "Alternate Name";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(288, 435);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(128, 25);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelChanges);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(147, 435);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(135, 25);
            this.deleteBtn.TabIndex = 7;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteHorse);
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(6, 435);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(135, 25);
            this.modifyBtn.TabIndex = 6;
            this.modifyBtn.Text = "Save Changes";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.SaveHorse);
            // 
            // fullNameBox
            // 
            this.fullNameBox.Location = new System.Drawing.Point(9, 88);
            this.fullNameBox.MaxLength = 255;
            this.fullNameBox.Name = "fullNameBox";
            this.fullNameBox.Size = new System.Drawing.Size(407, 22);
            this.fullNameBox.TabIndex = 1;
            this.fullNameBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoSize = true;
            this.fullNameLabel.Location = new System.Drawing.Point(6, 69);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(69, 16);
            this.fullNameLabel.TabIndex = 4;
            this.fullNameLabel.Text = "Full Name";
            // 
            // numberBox
            // 
            this.numberBox.BackColor = System.Drawing.SystemColors.Control;
            this.numberBox.Location = new System.Drawing.Point(9, 44);
            this.numberBox.Name = "numberBox";
            this.numberBox.ReadOnly = true;
            this.numberBox.Size = new System.Drawing.Size(89, 22);
            this.numberBox.TabIndex = 0;
            this.numberBox.TabStop = false;
            // 
            // horseNoLabel
            // 
            this.horseNoLabel.AutoSize = true;
            this.horseNoLabel.Location = new System.Drawing.Point(6, 25);
            this.horseNoLabel.Name = "horseNoLabel";
            this.horseNoLabel.Size = new System.Drawing.Size(96, 16);
            this.horseNoLabel.TabIndex = 0;
            this.horseNoLabel.Text = "Horse Number";
            // 
            // riderListGroup
            // 
            this.riderListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.riderListGroup.Controls.Add(this.backNoLabel);
            this.riderListGroup.Controls.Add(this.backNoBox);
            this.riderListGroup.Controls.Add(this.riderComboBox);
            this.riderListGroup.Controls.Add(this.addRiderBtn);
            this.riderListGroup.Controls.Add(this.riderListBox);
            this.riderListGroup.Controls.Add(this.viewRiderBtn);
            this.riderListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.riderListGroup.Location = new System.Drawing.Point(671, 12);
            this.riderListGroup.Name = "riderListGroup";
            this.riderListGroup.Size = new System.Drawing.Size(226, 466);
            this.riderListGroup.TabIndex = 16;
            this.riderListGroup.TabStop = false;
            this.riderListGroup.Text = "Shown By";
            // 
            // backNoLabel
            // 
            this.backNoLabel.AutoSize = true;
            this.backNoLabel.Location = new System.Drawing.Point(6, 380);
            this.backNoLabel.Name = "backNoLabel";
            this.backNoLabel.Size = new System.Drawing.Size(63, 16);
            this.backNoLabel.TabIndex = 17;
            this.backNoLabel.Text = "Back No.";
            // 
            // backNoBox
            // 
            this.backNoBox.Location = new System.Drawing.Point(75, 377);
            this.backNoBox.Name = "backNoBox";
            this.backNoBox.Size = new System.Drawing.Size(145, 22);
            this.backNoBox.TabIndex = 9;
            this.backNoBox.TextChanged += new System.EventHandler(this.RiderChanged);
            // 
            // riderComboBox
            // 
            this.riderComboBox.FormattingEnabled = true;
            this.riderComboBox.Location = new System.Drawing.Point(7, 405);
            this.riderComboBox.Name = "riderComboBox";
            this.riderComboBox.Size = new System.Drawing.Size(213, 24);
            this.riderComboBox.TabIndex = 10;
            this.riderComboBox.TextChanged += new System.EventHandler(this.RiderChanged);
            // 
            // addRiderBtn
            // 
            this.addRiderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addRiderBtn.Location = new System.Drawing.Point(6, 435);
            this.addRiderBtn.Name = "addRiderBtn";
            this.addRiderBtn.Size = new System.Drawing.Size(214, 25);
            this.addRiderBtn.TabIndex = 11;
            this.addRiderBtn.Text = "Add Rider";
            this.addRiderBtn.UseVisualStyleBackColor = true;
            this.addRiderBtn.Click += new System.EventHandler(this.AddBackNo);
            // 
            // riderListBox
            // 
            this.riderListBox.AllowColumnReorder = true;
            this.riderListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.riderListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.backNoHeader,
            this.riderNameHeader});
            this.riderListBox.FullRowSelect = true;
            this.riderListBox.LabelWrap = false;
            this.riderListBox.Location = new System.Drawing.Point(7, 21);
            this.riderListBox.MultiSelect = false;
            this.riderListBox.Name = "riderListBox";
            this.riderListBox.Size = new System.Drawing.Size(213, 319);
            this.riderListBox.TabIndex = 0;
            this.riderListBox.TabStop = false;
            this.riderListBox.UseCompatibleStateImageBehavior = false;
            this.riderListBox.View = System.Windows.Forms.View.Details;
            // 
            // backNoHeader
            // 
            this.backNoHeader.Text = "No.";
            this.backNoHeader.Width = 40;
            // 
            // riderNameHeader
            // 
            this.riderNameHeader.Text = "Rider Name";
            this.riderNameHeader.Width = 145;
            // 
            // viewRiderBtn
            // 
            this.viewRiderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewRiderBtn.Location = new System.Drawing.Point(6, 346);
            this.viewRiderBtn.Name = "viewRiderBtn";
            this.viewRiderBtn.Size = new System.Drawing.Size(214, 25);
            this.viewRiderBtn.TabIndex = 0;
            this.viewRiderBtn.TabStop = false;
            this.viewRiderBtn.Text = "View Rider";
            this.viewRiderBtn.UseVisualStyleBackColor = true;
            this.viewRiderBtn.Click += new System.EventHandler(this.ViewRider);
            // 
            // horseLabel
            // 
            this.horseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horseLabel.Location = new System.Drawing.Point(12, 9);
            this.horseLabel.Name = "horseLabel";
            this.horseLabel.Size = new System.Drawing.Size(225, 80);
            this.horseLabel.TabIndex = 15;
            this.horseLabel.Text = "New Horse Setup";
            this.horseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ownerBox
            // 
            this.ownerBox.Location = new System.Drawing.Point(81, 194);
            this.ownerBox.MaxLength = 255;
            this.ownerBox.Name = "ownerBox";
            this.ownerBox.Size = new System.Drawing.Size(335, 22);
            this.ownerBox.TabIndex = 4;
            this.ownerBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // ownerLabel
            // 
            this.ownerLabel.AutoSize = true;
            this.ownerLabel.Location = new System.Drawing.Point(81, 175);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(86, 16);
            this.ownerLabel.TabIndex = 17;
            this.ownerLabel.Text = "Owner Name";
            // 
            // HorseListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.horseBox);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.riderListGroup);
            this.Controls.Add(this.horseLabel);
            this.Name = "HorseListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Horse Detail - TrotTrax";
            this.Load += new System.EventHandler(this.HorseListForm_Load);
            this.horseBox.ResumeLayout(false);
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.riderListGroup.ResumeLayout(false);
            this.riderListGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox horseBox;
        private System.Windows.Forms.ListView horseListBox;
        private System.Windows.Forms.ColumnHeader horseNameHeader;
        private System.Windows.Forms.Button newHorseBtn;
        private System.Windows.Forms.Button viewHorseBtn;
        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.TextBox callNameBox;
        private System.Windows.Forms.Label altNameLabel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.TextBox fullNameBox;
        private System.Windows.Forms.Label fullNameLabel;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.Label horseNoLabel;
        private System.Windows.Forms.GroupBox riderListGroup;
        private System.Windows.Forms.ListView riderListBox;
        private System.Windows.Forms.ColumnHeader backNoHeader;
        private System.Windows.Forms.ColumnHeader riderNameHeader;
        private System.Windows.Forms.Button viewRiderBtn;
        private System.Windows.Forms.Label horseLabel;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label backNoLabel;
        private System.Windows.Forms.TextBox backNoBox;
        private System.Windows.Forms.ComboBox riderComboBox;
        private System.Windows.Forms.Button addRiderBtn;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.TextBox commentsBox;
        private System.Windows.Forms.TextBox ownerBox;
        private System.Windows.Forms.Label ownerLabel;
    }
}