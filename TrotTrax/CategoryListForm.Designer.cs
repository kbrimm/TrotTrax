namespace TrotTrax
{
    partial class CategoryListForm
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
            this.showLabel = new System.Windows.Forms.Label();
            this.listGroup = new System.Windows.Forms.GroupBox();
            this.newCatBtn = new System.Windows.Forms.Button();
            this.catListBox = new System.Windows.Forms.ListView();
            this.catNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catDescHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catTimedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catPayHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catPotHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catFeeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catViewBtn = new System.Windows.Forms.Button();
            this.classListGroup = new System.Windows.Forms.GroupBox();
            this.newClassBtn = new System.Windows.Forms.Button();
            this.classListBox = new System.Windows.Forms.ListView();
            this.classNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewClassBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.timedCheckBox = new System.Windows.Forms.CheckBox();
            this.payoutCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.listGroup.SuspendLayout();
            this.classListGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showLabel
            // 
            this.showLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLabel.Location = new System.Drawing.Point(7, 9);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(225, 223);
            this.showLabel.TabIndex = 8;
            this.showLabel.Text = "New Category \r\nSetup";
            this.showLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listGroup
            // 
            this.listGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listGroup.Controls.Add(this.newCatBtn);
            this.listGroup.Controls.Add(this.catListBox);
            this.listGroup.Controls.Add(this.catViewBtn);
            this.listGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGroup.Location = new System.Drawing.Point(12, 238);
            this.listGroup.Name = "listGroup";
            this.listGroup.Size = new System.Drawing.Size(885, 237);
            this.listGroup.TabIndex = 13;
            this.listGroup.TabStop = false;
            this.listGroup.Text = "Category List";
            // 
            // newCatBtn
            // 
            this.newCatBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newCatBtn.Location = new System.Drawing.Point(445, 206);
            this.newCatBtn.Name = "newCatBtn";
            this.newCatBtn.Size = new System.Drawing.Size(433, 25);
            this.newCatBtn.TabIndex = 13;
            this.newCatBtn.TabStop = false;
            this.newCatBtn.Text = "New Category";
            this.newCatBtn.UseVisualStyleBackColor = true;
            // 
            // catListBox
            // 
            this.catListBox.AllowColumnReorder = true;
            this.catListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.catListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.catNoHeader,
            this.catDescHeader,
            this.catTimedHeader,
            this.catPayHeader,
            this.catPotHeader,
            this.catFeeHeader});
            this.catListBox.FullRowSelect = true;
            this.catListBox.LabelWrap = false;
            this.catListBox.Location = new System.Drawing.Point(6, 25);
            this.catListBox.MultiSelect = false;
            this.catListBox.Name = "catListBox";
            this.catListBox.Size = new System.Drawing.Size(873, 175);
            this.catListBox.TabIndex = 12;
            this.catListBox.TabStop = false;
            this.catListBox.UseCompatibleStateImageBehavior = false;
            this.catListBox.View = System.Windows.Forms.View.Details;
            // 
            // catNoHeader
            // 
            this.catNoHeader.Text = "No.";
            this.catNoHeader.Width = 35;
            // 
            // catDescHeader
            // 
            this.catDescHeader.Text = "Category Description";
            this.catDescHeader.Width = 290;
            // 
            // catTimedHeader
            // 
            this.catTimedHeader.Text = "Timed";
            // 
            // catPayHeader
            // 
            this.catPayHeader.Text = "Payout";
            // 
            // catPotHeader
            // 
            this.catPotHeader.Text = "Jackpot";
            this.catPotHeader.Width = 65;
            // 
            // catFeeHeader
            // 
            this.catFeeHeader.Text = "Entry Fee";
            this.catFeeHeader.Width = 75;
            // 
            // catViewBtn
            // 
            this.catViewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.catViewBtn.Location = new System.Drawing.Point(6, 206);
            this.catViewBtn.Name = "catViewBtn";
            this.catViewBtn.Size = new System.Drawing.Size(433, 25);
            this.catViewBtn.TabIndex = 7;
            this.catViewBtn.TabStop = false;
            this.catViewBtn.Text = "View Category";
            this.catViewBtn.UseVisualStyleBackColor = true;
            // 
            // classListGroup
            // 
            this.classListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classListGroup.Controls.Add(this.newClassBtn);
            this.classListGroup.Controls.Add(this.classListBox);
            this.classListGroup.Controls.Add(this.viewClassBtn);
            this.classListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classListGroup.Location = new System.Drawing.Point(647, 12);
            this.classListGroup.Name = "classListGroup";
            this.classListGroup.Size = new System.Drawing.Size(250, 220);
            this.classListGroup.TabIndex = 14;
            this.classListGroup.TabStop = false;
            this.classListGroup.Text = "Class List";
            // 
            // newClassBtn
            // 
            this.newClassBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newClassBtn.Location = new System.Drawing.Point(129, 189);
            this.newClassBtn.Name = "newClassBtn";
            this.newClassBtn.Size = new System.Drawing.Size(115, 25);
            this.newClassBtn.TabIndex = 8;
            this.newClassBtn.Text = "New Class";
            this.newClassBtn.UseVisualStyleBackColor = true;
            // 
            // classListBox
            // 
            this.classListBox.AllowColumnReorder = true;
            this.classListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.classListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.classNoHeader,
            this.classNameHeader});
            this.classListBox.FullRowSelect = true;
            this.classListBox.LabelWrap = false;
            this.classListBox.Location = new System.Drawing.Point(6, 25);
            this.classListBox.MultiSelect = false;
            this.classListBox.Name = "classListBox";
            this.classListBox.Size = new System.Drawing.Size(237, 158);
            this.classListBox.TabIndex = 12;
            this.classListBox.TabStop = false;
            this.classListBox.UseCompatibleStateImageBehavior = false;
            this.classListBox.View = System.Windows.Forms.View.Details;
            // 
            // classNoHeader
            // 
            this.classNoHeader.Text = "No.";
            this.classNoHeader.Width = 35;
            // 
            // classNameHeader
            // 
            this.classNameHeader.Text = "Class Name";
            this.classNameHeader.Width = 176;
            // 
            // viewClassBtn
            // 
            this.viewClassBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewClassBtn.Location = new System.Drawing.Point(6, 189);
            this.viewClassBtn.Name = "viewClassBtn";
            this.viewClassBtn.Size = new System.Drawing.Size(115, 25);
            this.viewClassBtn.TabIndex = 7;
            this.viewClassBtn.TabStop = false;
            this.viewClassBtn.Text = "View Class";
            this.viewClassBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancelBtn);
            this.groupBox1.Controls.Add(this.deleteBtn);
            this.groupBox1.Controls.Add(this.modifyBtn);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.payoutCheckBox);
            this.groupBox1.Controls.Add(this.timedCheckBox);
            this.groupBox1.Controls.Add(this.descriptionBox);
            this.groupBox1.Controls.Add(this.descriptionLabel);
            this.groupBox1.Controls.Add(this.numberBox);
            this.groupBox1.Controls.Add(this.numberLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(238, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 220);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Category Details";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(6, 25);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(114, 16);
            this.numberLabel.TabIndex = 0;
            this.numberLabel.Text = "Category Number";
            // 
            // numberBox
            // 
            this.numberBox.BackColor = System.Drawing.SystemColors.Control;
            this.numberBox.Location = new System.Drawing.Point(9, 44);
            this.numberBox.Name = "numberBox";
            this.numberBox.ReadOnly = true;
            this.numberBox.Size = new System.Drawing.Size(111, 22);
            this.numberBox.TabIndex = 2;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(6, 78);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(76, 16);
            this.descriptionLabel.TabIndex = 5;
            this.descriptionLabel.Text = "Description";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(9, 97);
            this.descriptionBox.MaxLength = 255;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(387, 22);
            this.descriptionBox.TabIndex = 6;
            // 
            // timedCheckBox
            // 
            this.timedCheckBox.AutoSize = true;
            this.timedCheckBox.Location = new System.Drawing.Point(211, 163);
            this.timedCheckBox.Name = "timedCheckBox";
            this.timedCheckBox.Size = new System.Drawing.Size(103, 20);
            this.timedCheckBox.TabIndex = 8;
            this.timedCheckBox.Text = "Timed Class";
            this.timedCheckBox.UseVisualStyleBackColor = true;
            // 
            // payoutCheckBox
            // 
            this.payoutCheckBox.AutoSize = true;
            this.payoutCheckBox.Location = new System.Drawing.Point(164, 137);
            this.payoutCheckBox.Name = "payoutCheckBox";
            this.payoutCheckBox.Size = new System.Drawing.Size(69, 20);
            this.payoutCheckBox.TabIndex = 9;
            this.payoutCheckBox.Text = "Payout";
            this.payoutCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(239, 137);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 20);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Jackpot Class";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Entry Fee";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 154);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(96, 22);
            this.textBox1.TabIndex = 12;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(277, 189);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 25);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(151, 189);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(120, 25);
            this.deleteBtn.TabIndex = 14;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(9, 189);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(136, 25);
            this.modifyBtn.TabIndex = 13;
            this.modifyBtn.Text = "Save Changes";
            this.modifyBtn.UseVisualStyleBackColor = true;
            // 
            // CategoryListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.classListGroup);
            this.Controls.Add(this.listGroup);
            this.Controls.Add(this.showLabel);
            this.Name = "CategoryListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Category - TrotTrax";
            this.listGroup.ResumeLayout(false);
            this.classListGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label showLabel;
        private System.Windows.Forms.GroupBox listGroup;
        private System.Windows.Forms.Button newCatBtn;
        private System.Windows.Forms.ListView catListBox;
        private System.Windows.Forms.ColumnHeader catNoHeader;
        private System.Windows.Forms.ColumnHeader catDescHeader;
        private System.Windows.Forms.ColumnHeader catTimedHeader;
        private System.Windows.Forms.ColumnHeader catPayHeader;
        private System.Windows.Forms.ColumnHeader catPotHeader;
        private System.Windows.Forms.ColumnHeader catFeeHeader;
        private System.Windows.Forms.Button catViewBtn;
        private System.Windows.Forms.GroupBox classListGroup;
        private System.Windows.Forms.Button newClassBtn;
        private System.Windows.Forms.ListView classListBox;
        private System.Windows.Forms.ColumnHeader classNoHeader;
        private System.Windows.Forms.ColumnHeader classNameHeader;
        private System.Windows.Forms.Button viewClassBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox payoutCheckBox;
        private System.Windows.Forms.CheckBox timedCheckBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button modifyBtn;
    }
}