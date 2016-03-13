/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
 */
 
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
            this.infoLabel = new System.Windows.Forms.Label();
            this.listGroup = new System.Windows.Forms.GroupBox();
            this.newCatBtn = new System.Windows.Forms.Button();
            this.catListBox = new System.Windows.Forms.ListView();
            this.catNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catDescHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catTimedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewCatBtn = new System.Windows.Forms.Button();
            this.classListGroup = new System.Windows.Forms.GroupBox();
            this.newClassBtn = new System.Windows.Forms.Button();
            this.classListBox = new System.Windows.Forms.ListView();
            this.classNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewClassBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.timedCheckBox = new System.Windows.Forms.CheckBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.listGroup.SuspendLayout();
            this.classListGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(7, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(225, 170);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "New Category \r\nSetup";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listGroup
            // 
            this.listGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listGroup.Controls.Add(this.newCatBtn);
            this.listGroup.Controls.Add(this.catListBox);
            this.listGroup.Controls.Add(this.viewCatBtn);
            this.listGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGroup.Location = new System.Drawing.Point(12, 185);
            this.listGroup.Name = "listGroup";
            this.listGroup.Size = new System.Drawing.Size(629, 290);
            this.listGroup.TabIndex = 0;
            this.listGroup.TabStop = false;
            this.listGroup.Text = "Category List";
            // 
            // newCatBtn
            // 
            this.newCatBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newCatBtn.Location = new System.Drawing.Point(266, 259);
            this.newCatBtn.Name = "newCatBtn";
            this.newCatBtn.Size = new System.Drawing.Size(356, 25);
            this.newCatBtn.TabIndex = 7;
            this.newCatBtn.TabStop = false;
            this.newCatBtn.Text = "New Category";
            this.newCatBtn.UseVisualStyleBackColor = true;
            this.newCatBtn.Click += new System.EventHandler(this.NewCat);
            // 
            // catListBox
            // 
            this.catListBox.AllowColumnReorder = true;
            this.catListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.catListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.catNoHeader,
            this.catDescHeader,
            this.catTimedHeader});
            this.catListBox.FullRowSelect = true;
            this.catListBox.LabelWrap = false;
            this.catListBox.Location = new System.Drawing.Point(6, 25);
            this.catListBox.MultiSelect = false;
            this.catListBox.Name = "catListBox";
            this.catListBox.Size = new System.Drawing.Size(616, 228);
            this.catListBox.TabIndex = 12;
            this.catListBox.TabStop = false;
            this.catListBox.UseCompatibleStateImageBehavior = false;
            this.catListBox.View = System.Windows.Forms.View.Details;
            this.catListBox.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortCats);
            this.catListBox.DoubleClick += new System.EventHandler(this.ViewCat);
            // 
            // catNoHeader
            // 
            this.catNoHeader.Text = "No.";
            this.catNoHeader.Width = 35;
            // 
            // catDescHeader
            // 
            this.catDescHeader.Text = "Category Description";
            this.catDescHeader.Width = 493;
            // 
            // catTimedHeader
            // 
            this.catTimedHeader.Text = "Timed";
            // 
            // viewCatBtn
            // 
            this.viewCatBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewCatBtn.Location = new System.Drawing.Point(6, 259);
            this.viewCatBtn.Name = "viewCatBtn";
            this.viewCatBtn.Size = new System.Drawing.Size(254, 25);
            this.viewCatBtn.TabIndex = 6;
            this.viewCatBtn.TabStop = false;
            this.viewCatBtn.Text = "View Category";
            this.viewCatBtn.UseVisualStyleBackColor = true;
            this.viewCatBtn.Click += new System.EventHandler(this.ViewCat);
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
            this.classListGroup.Size = new System.Drawing.Size(250, 463);
            this.classListGroup.TabIndex = 0;
            this.classListGroup.TabStop = false;
            this.classListGroup.Text = "Class List";
            // 
            // newClassBtn
            // 
            this.newClassBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newClassBtn.Location = new System.Drawing.Point(129, 432);
            this.newClassBtn.Name = "newClassBtn";
            this.newClassBtn.Size = new System.Drawing.Size(115, 25);
            this.newClassBtn.TabIndex = 9;
            this.newClassBtn.TabStop = false;
            this.newClassBtn.Text = "New Class";
            this.newClassBtn.UseVisualStyleBackColor = true;
            this.newClassBtn.Click += new System.EventHandler(this.NewClass);
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
            this.classListBox.Size = new System.Drawing.Size(237, 401);
            this.classListBox.TabIndex = 12;
            this.classListBox.TabStop = false;
            this.classListBox.UseCompatibleStateImageBehavior = false;
            this.classListBox.View = System.Windows.Forms.View.Details;
            this.classListBox.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortClasses);
            this.classListBox.DoubleClick += new System.EventHandler(this.ViewClass);
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
            this.viewClassBtn.Location = new System.Drawing.Point(6, 432);
            this.viewClassBtn.Name = "viewClassBtn";
            this.viewClassBtn.Size = new System.Drawing.Size(115, 25);
            this.viewClassBtn.TabIndex = 8;
            this.viewClassBtn.TabStop = false;
            this.viewClassBtn.Text = "View Class";
            this.viewClassBtn.UseVisualStyleBackColor = true;
            this.viewClassBtn.Click += new System.EventHandler(this.ViewClass);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancelBtn);
            this.groupBox1.Controls.Add(this.deleteBtn);
            this.groupBox1.Controls.Add(this.modifyBtn);
            this.groupBox1.Controls.Add(this.timedCheckBox);
            this.groupBox1.Controls.Add(this.descriptionBox);
            this.groupBox1.Controls.Add(this.descriptionLabel);
            this.groupBox1.Controls.Add(this.numberBox);
            this.groupBox1.Controls.Add(this.numberLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(238, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Category Details";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(296, 134);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 25);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelChanges);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(183, 134);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(108, 25);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteCat);
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(9, 134);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(168, 25);
            this.modifyBtn.TabIndex = 3;
            this.modifyBtn.Text = "Save Changes";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.SaveCategory);
            // 
            // timedCheckBox
            // 
            this.timedCheckBox.AutoSize = true;
            this.timedCheckBox.Location = new System.Drawing.Point(293, 44);
            this.timedCheckBox.Name = "timedCheckBox";
            this.timedCheckBox.Size = new System.Drawing.Size(103, 20);
            this.timedCheckBox.TabIndex = 2;
            this.timedCheckBox.Text = "Timed Class";
            this.timedCheckBox.UseVisualStyleBackColor = true;
            this.timedCheckBox.CheckedChanged += new System.EventHandler(this.DataChanged);
            this.timedCheckBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(9, 97);
            this.descriptionBox.MaxLength = 255;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(387, 22);
            this.descriptionBox.TabIndex = 1;
            this.descriptionBox.TextChanged += new System.EventHandler(this.DataChanged);
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
            // numberBox
            // 
            this.numberBox.BackColor = System.Drawing.SystemColors.Control;
            this.numberBox.Location = new System.Drawing.Point(9, 44);
            this.numberBox.Name = "numberBox";
            this.numberBox.ReadOnly = true;
            this.numberBox.Size = new System.Drawing.Size(278, 22);
            this.numberBox.TabIndex = 0;
            this.numberBox.TabStop = false;
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
            // CategoryListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.classListGroup);
            this.Controls.Add(this.listGroup);
            this.Controls.Add(this.infoLabel);
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

        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.GroupBox listGroup;
        private System.Windows.Forms.Button newCatBtn;
        private System.Windows.Forms.ListView catListBox;
        private System.Windows.Forms.ColumnHeader catNoHeader;
        private System.Windows.Forms.ColumnHeader catDescHeader;
        private System.Windows.Forms.ColumnHeader catTimedHeader;
        private System.Windows.Forms.Button viewCatBtn;
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
        private System.Windows.Forms.CheckBox timedCheckBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button modifyBtn;
    }
}