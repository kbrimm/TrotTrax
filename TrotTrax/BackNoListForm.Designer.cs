namespace TrotTrax
{
    partial class BackNoListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackNoListForm));
            this.riderListGroup = new System.Windows.Forms.GroupBox();
            this.backNoListBox = new System.Windows.Forms.ListView();
            this.noHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.riderNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backNoRiderFirstHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backNoRiderLastHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.horseNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backNoHorseNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addBackNoBtn = new System.Windows.Forms.Button();
            this.viewBackNoBtn = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.detailGroup = new System.Windows.Forms.GroupBox();
            this.backNoLabel = new System.Windows.Forms.Label();
            this.backNoBox = new System.Windows.Forms.TextBox();
            this.viewHorseBtn = new System.Windows.Forms.Button();
            this.viewRiderBtn = new System.Windows.Forms.Button();
            this.horseLabel = new System.Windows.Forms.Label();
            this.riderComboBox = new System.Windows.Forms.ComboBox();
            this.horseComboBox = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.riderLabel = new System.Windows.Forms.Label();
            this.classEntryGroup = new System.Windows.Forms.GroupBox();
            this.classEntryListBox = new System.Windows.Forms.ListView();
            this.showHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.placeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pointsHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.riderListGroup.SuspendLayout();
            this.detailGroup.SuspendLayout();
            this.classEntryGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // riderListGroup
            // 
            this.riderListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.riderListGroup.Controls.Add(this.backNoListBox);
            this.riderListGroup.Controls.Add(this.addBackNoBtn);
            this.riderListGroup.Controls.Add(this.viewBackNoBtn);
            this.riderListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.riderListGroup.Location = new System.Drawing.Point(12, 92);
            this.riderListGroup.Name = "riderListGroup";
            this.riderListGroup.Size = new System.Drawing.Size(383, 386);
            this.riderListGroup.TabIndex = 16;
            this.riderListGroup.TabStop = false;
            this.riderListGroup.Text = "Back Number List";
            // 
            // backNoListBox
            // 
            this.backNoListBox.AllowColumnReorder = true;
            this.backNoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.backNoListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.noHeader,
            this.riderNoHeader,
            this.backNoRiderFirstHeader,
            this.backNoRiderLastHeader,
            this.horseNoHeader,
            this.backNoHorseNameHeader});
            this.backNoListBox.FullRowSelect = true;
            this.backNoListBox.LabelWrap = false;
            this.backNoListBox.Location = new System.Drawing.Point(7, 21);
            this.backNoListBox.MultiSelect = false;
            this.backNoListBox.Name = "backNoListBox";
            this.backNoListBox.Size = new System.Drawing.Size(370, 328);
            this.backNoListBox.TabIndex = 0;
            this.backNoListBox.TabStop = false;
            this.backNoListBox.UseCompatibleStateImageBehavior = false;
            this.backNoListBox.View = System.Windows.Forms.View.Details;
            this.backNoListBox.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortBackNoList);
            this.backNoListBox.DoubleClick += new System.EventHandler(this.ViewBackNo);
            // 
            // noHeader
            // 
            this.noHeader.Text = "No.";
            this.noHeader.Width = 45;
            // 
            // riderNoHeader
            // 
            this.riderNoHeader.Text = "Rider No.";
            this.riderNoHeader.Width = 0;
            // 
            // backNoRiderFirstHeader
            // 
            this.backNoRiderFirstHeader.Text = "First Name";
            this.backNoRiderFirstHeader.Width = 86;
            // 
            // backNoRiderLastHeader
            // 
            this.backNoRiderLastHeader.Text = "Last Name";
            this.backNoRiderLastHeader.Width = 95;
            // 
            // horseNoHeader
            // 
            this.horseNoHeader.Text = "Horse No.";
            this.horseNoHeader.Width = 0;
            // 
            // backNoHorseNameHeader
            // 
            this.backNoHorseNameHeader.Text = "Horse";
            this.backNoHorseNameHeader.Width = 120;
            // 
            // addBackNoBtn
            // 
            this.addBackNoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addBackNoBtn.Location = new System.Drawing.Point(195, 355);
            this.addBackNoBtn.Name = "addBackNoBtn";
            this.addBackNoBtn.Size = new System.Drawing.Size(182, 25);
            this.addBackNoBtn.TabIndex = 0;
            this.addBackNoBtn.TabStop = false;
            this.addBackNoBtn.Text = "New Back No.";
            this.addBackNoBtn.UseVisualStyleBackColor = true;
            this.addBackNoBtn.Click += new System.EventHandler(this.NewBackNo);
            // 
            // viewBackNoBtn
            // 
            this.viewBackNoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewBackNoBtn.Location = new System.Drawing.Point(7, 355);
            this.viewBackNoBtn.Name = "viewBackNoBtn";
            this.viewBackNoBtn.Size = new System.Drawing.Size(182, 25);
            this.viewBackNoBtn.TabIndex = 0;
            this.viewBackNoBtn.TabStop = false;
            this.viewBackNoBtn.Text = "View Back No.";
            this.viewBackNoBtn.UseVisualStyleBackColor = true;
            this.viewBackNoBtn.Click += new System.EventHandler(this.ViewBackNo);
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(12, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(383, 80);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "New Back Number Setup";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infoLabel.UseMnemonic = false;
            // 
            // detailGroup
            // 
            this.detailGroup.Controls.Add(this.backNoLabel);
            this.detailGroup.Controls.Add(this.backNoBox);
            this.detailGroup.Controls.Add(this.viewHorseBtn);
            this.detailGroup.Controls.Add(this.viewRiderBtn);
            this.detailGroup.Controls.Add(this.horseLabel);
            this.detailGroup.Controls.Add(this.riderComboBox);
            this.detailGroup.Controls.Add(this.horseComboBox);
            this.detailGroup.Controls.Add(this.cancelBtn);
            this.detailGroup.Controls.Add(this.deleteBtn);
            this.detailGroup.Controls.Add(this.modifyBtn);
            this.detailGroup.Controls.Add(this.riderLabel);
            this.detailGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailGroup.Location = new System.Drawing.Point(401, 12);
            this.detailGroup.Name = "detailGroup";
            this.detailGroup.Size = new System.Drawing.Size(496, 143);
            this.detailGroup.TabIndex = 17;
            this.detailGroup.TabStop = false;
            this.detailGroup.Text = "Back Number Detail";
            // 
            // backNoLabel
            // 
            this.backNoLabel.AutoSize = true;
            this.backNoLabel.Location = new System.Drawing.Point(6, 25);
            this.backNoLabel.Name = "backNoLabel";
            this.backNoLabel.Size = new System.Drawing.Size(63, 16);
            this.backNoLabel.TabIndex = 20;
            this.backNoLabel.Text = "Back No.";
            // 
            // backNoBox
            // 
            this.backNoBox.Location = new System.Drawing.Point(6, 44);
            this.backNoBox.Name = "backNoBox";
            this.backNoBox.Size = new System.Drawing.Size(71, 22);
            this.backNoBox.TabIndex = 1;
            this.backNoBox.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // viewHorseBtn
            // 
            this.viewHorseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewHorseBtn.Location = new System.Drawing.Point(251, 105);
            this.viewHorseBtn.Name = "viewHorseBtn";
            this.viewHorseBtn.Size = new System.Drawing.Size(240, 25);
            this.viewHorseBtn.TabIndex = 8;
            this.viewHorseBtn.TabStop = false;
            this.viewHorseBtn.Text = "View Horse";
            this.viewHorseBtn.UseVisualStyleBackColor = true;
            this.viewHorseBtn.Click += new System.EventHandler(this.ViewHorse);
            // 
            // viewRiderBtn
            // 
            this.viewRiderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewRiderBtn.Location = new System.Drawing.Point(6, 105);
            this.viewRiderBtn.Name = "viewRiderBtn";
            this.viewRiderBtn.Size = new System.Drawing.Size(239, 25);
            this.viewRiderBtn.TabIndex = 7;
            this.viewRiderBtn.TabStop = false;
            this.viewRiderBtn.Text = "View Rider";
            this.viewRiderBtn.UseVisualStyleBackColor = true;
            this.viewRiderBtn.Click += new System.EventHandler(this.ViewRider);
            // 
            // horseLabel
            // 
            this.horseLabel.AutoSize = true;
            this.horseLabel.Location = new System.Drawing.Point(288, 25);
            this.horseLabel.Name = "horseLabel";
            this.horseLabel.Size = new System.Drawing.Size(45, 16);
            this.horseLabel.TabIndex = 16;
            this.horseLabel.Text = "Horse";
            // 
            // riderComboBox
            // 
            this.riderComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.riderComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.riderComboBox.FormattingEnabled = true;
            this.riderComboBox.Location = new System.Drawing.Point(86, 44);
            this.riderComboBox.Name = "riderComboBox";
            this.riderComboBox.Size = new System.Drawing.Size(199, 24);
            this.riderComboBox.TabIndex = 2;
            this.riderComboBox.SelectedIndexChanged += new System.EventHandler(this.DataChanged);
            // 
            // horseComboBox
            // 
            this.horseComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.horseComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.horseComboBox.FormattingEnabled = true;
            this.horseComboBox.Location = new System.Drawing.Point(291, 44);
            this.horseComboBox.Name = "horseComboBox";
            this.horseComboBox.Size = new System.Drawing.Size(199, 24);
            this.horseComboBox.TabIndex = 3;
            this.horseComboBox.SelectedIndexChanged += new System.EventHandler(this.DataChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(333, 74);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(157, 25);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelChanges);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(169, 74);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(158, 25);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBackNo);
            // 
            // modifyBtn
            // 
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.modifyBtn.Location = new System.Drawing.Point(6, 74);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(157, 25);
            this.modifyBtn.TabIndex = 4;
            this.modifyBtn.Text = "Save Changes";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.SaveBackNo);
            // 
            // riderLabel
            // 
            this.riderLabel.AutoSize = true;
            this.riderLabel.Location = new System.Drawing.Point(83, 25);
            this.riderLabel.Name = "riderLabel";
            this.riderLabel.Size = new System.Drawing.Size(41, 16);
            this.riderLabel.TabIndex = 0;
            this.riderLabel.Text = "Rider";
            // 
            // classEntryGroup
            // 
            this.classEntryGroup.Controls.Add(this.classEntryListBox);
            this.classEntryGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classEntryGroup.Location = new System.Drawing.Point(401, 161);
            this.classEntryGroup.Name = "classEntryGroup";
            this.classEntryGroup.Size = new System.Drawing.Size(496, 317);
            this.classEntryGroup.TabIndex = 0;
            this.classEntryGroup.TabStop = false;
            this.classEntryGroup.Text = "Class Entries";
            // 
            // classEntryListBox
            // 
            this.classEntryListBox.AllowColumnReorder = true;
            this.classEntryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.classEntryListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.showHeader,
            this.classHeader,
            this.placeHeader,
            this.timeHeader,
            this.pointsHeader});
            this.classEntryListBox.FullRowSelect = true;
            this.classEntryListBox.LabelWrap = false;
            this.classEntryListBox.Location = new System.Drawing.Point(9, 27);
            this.classEntryListBox.MultiSelect = false;
            this.classEntryListBox.Name = "classEntryListBox";
            this.classEntryListBox.Size = new System.Drawing.Size(481, 284);
            this.classEntryListBox.TabIndex = 0;
            this.classEntryListBox.TabStop = false;
            this.classEntryListBox.UseCompatibleStateImageBehavior = false;
            this.classEntryListBox.View = System.Windows.Forms.View.Details;
            // 
            // showHeader
            // 
            this.showHeader.Text = "Show";
            this.showHeader.Width = 85;
            // 
            // classHeader
            // 
            this.classHeader.Text = "Class";
            this.classHeader.Width = 223;
            // 
            // placeHeader
            // 
            this.placeHeader.Text = "Place";
            this.placeHeader.Width = 47;
            // 
            // timeHeader
            // 
            this.timeHeader.Text = "Time";
            this.timeHeader.Width = 48;
            // 
            // pointsHeader
            // 
            this.pointsHeader.Text = "Points";
            this.pointsHeader.Width = 49;
            // 
            // BackNoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.classEntryGroup);
            this.Controls.Add(this.detailGroup);
            this.Controls.Add(this.riderListGroup);
            this.Controls.Add(this.infoLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackNoListForm";
            this.Text = "BackNoListForm";
            this.riderListGroup.ResumeLayout(false);
            this.detailGroup.ResumeLayout(false);
            this.detailGroup.PerformLayout();
            this.classEntryGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox riderListGroup;
        private System.Windows.Forms.ListView backNoListBox;
        private System.Windows.Forms.ColumnHeader noHeader;
        private System.Windows.Forms.ColumnHeader riderNoHeader;
        private System.Windows.Forms.ColumnHeader backNoRiderFirstHeader;
        private System.Windows.Forms.ColumnHeader backNoRiderLastHeader;
        private System.Windows.Forms.ColumnHeader horseNoHeader;
        private System.Windows.Forms.ColumnHeader backNoHorseNameHeader;
        private System.Windows.Forms.Button addBackNoBtn;
        private System.Windows.Forms.Button viewBackNoBtn;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.GroupBox detailGroup;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Label riderLabel;
        private System.Windows.Forms.ComboBox horseComboBox;
        private System.Windows.Forms.ComboBox riderComboBox;
        private System.Windows.Forms.Label horseLabel;
        private System.Windows.Forms.GroupBox classEntryGroup;
        private System.Windows.Forms.ListView classEntryListBox;
        private System.Windows.Forms.ColumnHeader showHeader;
        private System.Windows.Forms.ColumnHeader classHeader;
        private System.Windows.Forms.ColumnHeader placeHeader;
        private System.Windows.Forms.ColumnHeader timeHeader;
        private System.Windows.Forms.ColumnHeader pointsHeader;
        private System.Windows.Forms.Button viewHorseBtn;
        private System.Windows.Forms.Button viewRiderBtn;
        private System.Windows.Forms.Label backNoLabel;
        private System.Windows.Forms.TextBox backNoBox;
    }
}