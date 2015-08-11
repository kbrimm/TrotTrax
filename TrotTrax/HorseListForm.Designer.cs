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
            this.listView1 = new System.Windows.Forms.ListView();
            this.horseNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.entryGroup = new System.Windows.Forms.GroupBox();
            this.entryListBox = new System.Windows.Forms.ListView();
            this.backNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.horseHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.placeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewNumber = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.nickNameBox = new System.Windows.Forms.TextBox();
            this.callNameLabel = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.fullNameBox = new System.Windows.Forms.TextBox();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.showNoLabel = new System.Windows.Forms.Label();
            this.riderListGroup = new System.Windows.Forms.GroupBox();
            this.riderListBox = new System.Windows.Forms.ListView();
            this.riderFirstHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.riderLastHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewRiderBtn = new System.Windows.Forms.Button();
            this.showLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.Label();
            this.horseBox.SuspendLayout();
            this.entryGroup.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.riderListGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // horseBox
            // 
            this.horseBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.horseBox.Controls.Add(this.listView1);
            this.horseBox.Controls.Add(this.button1);
            this.horseBox.Controls.Add(this.button2);
            this.horseBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horseBox.Location = new System.Drawing.Point(12, 92);
            this.horseBox.Name = "horseBox";
            this.horseBox.Size = new System.Drawing.Size(226, 386);
            this.horseBox.TabIndex = 19;
            this.horseBox.TabStop = false;
            this.horseBox.Text = "Horses Shown";
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.horseNameHeader});
            this.listView1.FullRowSelect = true;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(7, 21);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(213, 328);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // horseNameHeader
            // 
            this.horseNameHeader.Text = "Name";
            this.horseNameHeader.Width = 188;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(109, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "New Horse";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(7, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "View Horse";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // entryGroup
            // 
            this.entryGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryGroup.Controls.Add(this.entryListBox);
            this.entryGroup.Controls.Add(this.viewNumber);
            this.entryGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryGroup.Location = new System.Drawing.Point(243, 268);
            this.entryGroup.Name = "entryGroup";
            this.entryGroup.Size = new System.Drawing.Size(654, 210);
            this.entryGroup.TabIndex = 18;
            this.entryGroup.TabStop = false;
            this.entryGroup.Text = "Class Entries";
            // 
            // entryListBox
            // 
            this.entryListBox.AllowColumnReorder = true;
            this.entryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.backNoHeader,
            this.horseHeader,
            this.dateHeader,
            this.classHeader,
            this.placeHeader});
            this.entryListBox.FullRowSelect = true;
            this.entryListBox.LabelWrap = false;
            this.entryListBox.Location = new System.Drawing.Point(6, 25);
            this.entryListBox.MultiSelect = false;
            this.entryListBox.Name = "entryListBox";
            this.entryListBox.Size = new System.Drawing.Size(642, 148);
            this.entryListBox.TabIndex = 11;
            this.entryListBox.TabStop = false;
            this.entryListBox.UseCompatibleStateImageBehavior = false;
            this.entryListBox.View = System.Windows.Forms.View.Details;
            // 
            // backNoHeader
            // 
            this.backNoHeader.Text = "Back No.";
            this.backNoHeader.Width = 70;
            // 
            // horseHeader
            // 
            this.horseHeader.Text = "Horse Name";
            this.horseHeader.Width = 184;
            // 
            // dateHeader
            // 
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 74;
            // 
            // classHeader
            // 
            this.classHeader.Text = "Class";
            this.classHeader.Width = 228;
            // 
            // placeHeader
            // 
            this.placeHeader.Text = "Place";
            // 
            // viewNumber
            // 
            this.viewNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewNumber.Location = new System.Drawing.Point(441, 179);
            this.viewNumber.Name = "viewNumber";
            this.viewNumber.Size = new System.Drawing.Size(207, 25);
            this.viewNumber.TabIndex = 5;
            this.viewNumber.TabStop = false;
            this.viewNumber.Text = "View Class";
            this.viewNumber.UseVisualStyleBackColor = true;
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.textBox1);
            this.infoBox.Controls.Add(this.heightBox);
            this.infoBox.Controls.Add(this.nickNameBox);
            this.infoBox.Controls.Add(this.callNameLabel);
            this.infoBox.Controls.Add(this.cancelBtn);
            this.infoBox.Controls.Add(this.deleteBtn);
            this.infoBox.Controls.Add(this.modifyBtn);
            this.infoBox.Controls.Add(this.fullNameBox);
            this.infoBox.Controls.Add(this.fullNameLabel);
            this.infoBox.Controls.Add(this.numberBox);
            this.infoBox.Controls.Add(this.showNoLabel);
            this.infoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.Location = new System.Drawing.Point(243, 12);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(422, 250);
            this.infoBox.TabIndex = 17;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Rider Information";
            // 
            // nickNameBox
            // 
            this.nickNameBox.Location = new System.Drawing.Point(9, 141);
            this.nickNameBox.MaxLength = 255;
            this.nickNameBox.Name = "nickNameBox";
            this.nickNameBox.Size = new System.Drawing.Size(217, 22);
            this.nickNameBox.TabIndex = 12;
            // 
            // callNameLabel
            // 
            this.callNameLabel.AutoSize = true;
            this.callNameLabel.Location = new System.Drawing.Point(6, 122);
            this.callNameLabel.Name = "callNameLabel";
            this.callNameLabel.Size = new System.Drawing.Size(71, 16);
            this.callNameLabel.TabIndex = 11;
            this.callNameLabel.Text = "Call Name";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(267, 217);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 25);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(141, 217);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(120, 25);
            this.deleteBtn.TabIndex = 9;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(6, 217);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(129, 25);
            this.modifyBtn.TabIndex = 8;
            this.modifyBtn.Text = "Save Changes";
            this.modifyBtn.UseVisualStyleBackColor = true;
            // 
            // fullNameBox
            // 
            this.fullNameBox.Location = new System.Drawing.Point(9, 88);
            this.fullNameBox.MaxLength = 255;
            this.fullNameBox.Name = "fullNameBox";
            this.fullNameBox.Size = new System.Drawing.Size(407, 22);
            this.fullNameBox.TabIndex = 5;
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
            this.numberBox.TabIndex = 1;
            // 
            // showNoLabel
            // 
            this.showNoLabel.AutoSize = true;
            this.showNoLabel.Location = new System.Drawing.Point(6, 25);
            this.showNoLabel.Name = "showNoLabel";
            this.showNoLabel.Size = new System.Drawing.Size(96, 16);
            this.showNoLabel.TabIndex = 0;
            this.showNoLabel.Text = "Horse Number";
            // 
            // riderListGroup
            // 
            this.riderListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.riderListGroup.Controls.Add(this.riderListBox);
            this.riderListGroup.Controls.Add(this.viewRiderBtn);
            this.riderListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.riderListGroup.Location = new System.Drawing.Point(677, 12);
            this.riderListGroup.Name = "riderListGroup";
            this.riderListGroup.Size = new System.Drawing.Size(220, 250);
            this.riderListGroup.TabIndex = 16;
            this.riderListGroup.TabStop = false;
            this.riderListGroup.Text = "Shown By";
            // 
            // riderListBox
            // 
            this.riderListBox.AllowColumnReorder = true;
            this.riderListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.riderListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.riderFirstHeader,
            this.riderLastHeader});
            this.riderListBox.FullRowSelect = true;
            this.riderListBox.LabelWrap = false;
            this.riderListBox.Location = new System.Drawing.Point(7, 21);
            this.riderListBox.MultiSelect = false;
            this.riderListBox.Name = "riderListBox";
            this.riderListBox.Size = new System.Drawing.Size(207, 192);
            this.riderListBox.TabIndex = 13;
            this.riderListBox.UseCompatibleStateImageBehavior = false;
            this.riderListBox.View = System.Windows.Forms.View.Details;
            // 
            // riderFirstHeader
            // 
            this.riderFirstHeader.Text = "First Name";
            this.riderFirstHeader.Width = 86;
            // 
            // riderLastHeader
            // 
            this.riderLastHeader.Text = "Last Name";
            this.riderLastHeader.Width = 95;
            // 
            // viewRiderBtn
            // 
            this.viewRiderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewRiderBtn.Location = new System.Drawing.Point(7, 217);
            this.viewRiderBtn.Name = "viewRiderBtn";
            this.viewRiderBtn.Size = new System.Drawing.Size(207, 25);
            this.viewRiderBtn.TabIndex = 7;
            this.viewRiderBtn.Text = "View Rider";
            this.viewRiderBtn.UseVisualStyleBackColor = true;
            // 
            // showLabel
            // 
            this.showLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLabel.Location = new System.Drawing.Point(12, 9);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(225, 80);
            this.showLabel.TabIndex = 15;
            this.showLabel.Text = "New Horse Detail";
            this.showLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(232, 141);
            this.textBox1.MaxLength = 255;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 22);
            this.textBox1.TabIndex = 14;
            // 
            // heightBox
            // 
            this.heightBox.AutoSize = true;
            this.heightBox.Location = new System.Drawing.Point(229, 122);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(47, 16);
            this.heightBox.TabIndex = 13;
            this.heightBox.Text = "Height";
            // 
            // HorseListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.horseBox);
            this.Controls.Add(this.entryGroup);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.riderListGroup);
            this.Controls.Add(this.showLabel);
            this.Name = "HorseListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Horse Detail - TrotTrax";
            this.Load += new System.EventHandler(this.HorseListForm_Load);
            this.horseBox.ResumeLayout(false);
            this.entryGroup.ResumeLayout(false);
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.riderListGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox horseBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader horseNameHeader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox entryGroup;
        private System.Windows.Forms.ListView entryListBox;
        private System.Windows.Forms.ColumnHeader backNoHeader;
        private System.Windows.Forms.ColumnHeader horseHeader;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ColumnHeader classHeader;
        private System.Windows.Forms.ColumnHeader placeHeader;
        private System.Windows.Forms.Button viewNumber;
        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.TextBox nickNameBox;
        private System.Windows.Forms.Label callNameLabel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.TextBox fullNameBox;
        private System.Windows.Forms.Label fullNameLabel;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.Label showNoLabel;
        private System.Windows.Forms.GroupBox riderListGroup;
        private System.Windows.Forms.ListView riderListBox;
        private System.Windows.Forms.ColumnHeader riderFirstHeader;
        private System.Windows.Forms.ColumnHeader riderLastHeader;
        private System.Windows.Forms.Button viewRiderBtn;
        private System.Windows.Forms.Label showLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label heightBox;
    }
}