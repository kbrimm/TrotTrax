/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrotTrax
{
    public partial class ClassListForm : Form
    {
        private Class aClass;
        private bool isChanged;
        private bool isNew;
        private List<DropDownItem> dropDownList;

        // Form methods

        public ClassListForm(string clubID, int year)
        {
            aClass = new Class(clubID, year);
            InitializeComponent();
            PopulateDropDown();
            PopulateCategoryList();
            PopulateClassList();
            this.Text = "New Class - TrotTrax";
            showLabel.Text = "New Class\nSetup";
            modifyBtn.Text = "Add New Class";
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewShowBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = true;
        }

        public ClassListForm(string clubID, int year, int classNo)
        {
            aClass = new Class(clubID, year, classNo);
            InitializeComponent();
            PopulateDropDown();
            PopulateCategoryList();
            PopulateClassList();
            PopulateShowList();
            this.Text = aClass.name + " Class Detail - TrotTrax";
            showLabel.Text = aClass.name + "\r\nClass Detail";
            numberBox.Text = classNo.ToString();
            nameBox.Text = aClass.name;
            feeBox.Text = aClass.fee.ToString();
            catDropDown.SelectedValue = aClass.catNo;
            modifyBtn.Text = "Save Changes";
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = false;
        }

        private void RefreshForm(string clubID, int year)
        {
            aClass = new Class(clubID, year);
            PopulateCategoryList();
            PopulateDropDown();
            PopulateClassList();
            this.Text = "New Class - TrotTrax";
            showLabel.Text = "New Class\nSetup";
            modifyBtn.Text = "Add New Class";
            feeBox.Text = "0.00";
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewShowBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = true;
        }

        private void RefreshForm(string clubID, int year, int classNo)
        {
            aClass = new Class(clubID, year, classNo);
            PopulateDropDown();
            PopulateCategoryList();
            PopulateClassList();
            PopulateShowList();
            this.Text = aClass.name + " Class Detail - TrotTrax";
            showLabel.Text = aClass.name + "\r\nClass Detail";
            numberBox.Text = classNo.ToString();
            nameBox.Text = aClass.name;
            feeBox.Text = aClass.fee.ToString();
            catDropDown.SelectedValue = aClass.catNo;
            modifyBtn.Text = "Save Changes";
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = false;
        }

        private void RefreshOnClose(object sender, FormClosingEventArgs e)
        {
            if (AbandonChanges())
                if (isNew)
                    RefreshForm(aClass.clubID, aClass.year);
                else
                    RefreshForm(aClass.clubID, aClass.year, aClass.number);
            else
            {
                PopulateClassList();
                PopulateCategoryList();
                PopulateDropDown();
            }
        }

        private void DataChanged(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            isChanged = true;
        }

        private bool AbandonChanges()
        {
            if (isChanged)
            {
                DialogResult confirm = MessageBox.Show("Do you want to abandon your changes?",
                        "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        // Class data methods

        private void PopulateDropDown()
        {
            // Initializes box with a 'null' item for display purposes.
            dropDownList = new List<DropDownItem>();
            dropDownList.Add(new DropDownItem() { no = 0, name = String.Empty });

            // Adds the contents of the category item list retrieved from the database.
            foreach (CategoryItem entry in aClass.catList)
                dropDownList.Add(new DropDownItem() { no = entry.no, name = entry.name });

            // Sets this list as the menu's data source and tells the menu which parts to show.
            catDropDown.DataSource = dropDownList;
            catDropDown.DisplayMember = "name";
            catDropDown.ValueMember = "no";
        }

        private void SaveClass(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult confirm;
                string noString = this.numberBox.Text.ToString();
                int number;
                int category = Convert.ToInt32(this.catDropDown.SelectedValue);
                string name = this.nameBox.Text;
                bool validFee;
                string feeString = this.feeBox.ToString().Substring(36);
                decimal fee;

                // Reject save conditions: fee is not a decimal, class number is not an integer, class is not in a category
                // Otherwise, proceed.
                Console.WriteLine("String value for fee: " + feeString);
                Console.WriteLine("Length of string: " + feeString.Length);
                validFee = decimal.TryParse(feeString, System.Globalization.NumberStyles.Any, new System.Globalization.CultureInfo("en-US"), out fee);
                Console.WriteLine("Parsed value for fee: " + fee);
                if (!validFee)
                    confirm = MessageBox.Show("Fee must be a decimal value.",
                        "TrotTrax Alert", MessageBoxButtons.OK);   
                else if (noString == String.Empty || !int.TryParse(noString, out number))
                    confirm = MessageBox.Show("Class number must be an integer value.",
                        "TrotTrax Alert", MessageBoxButtons.OK);
                else if (aClass.catList.Count == 0)
                    confirm = MessageBox.Show("You must configure at least one category before adding a class to this show year.",
                        "TrotTrax Confirmation", MessageBoxButtons.OK);
                else
                {
                    // If it's a new class, check that the class number is unique, prompt for more additions.
                    if (isNew)
                    {
                        if (aClass.AddClass(number, category, name, fee))
                        {
                            confirm = MessageBox.Show("Would you like to add another class?",
                                "TrotTrax Alert", MessageBoxButtons.YesNo);
                            if (confirm == DialogResult.Yes)
                                RefreshForm(aClass.clubID, aClass.year);
                            else
                                RefreshForm(aClass.clubID, aClass.year, number);
                        }
                        // Something went wrong, it's probably the class number.
                        else
                            confirm = MessageBox.Show("Class number must be unique.",
                                "TrotTrax Alert", MessageBoxButtons.OK);
                    }
                    // Otherwise: do or do not, there is no try.
                    else
                    {
                        if (aClass.ModifyClass(number, category, name, fee))
                            RefreshForm(aClass.clubID, aClass.year, number);
                        // Unless something terrible happens.
                        else
                            confirm = MessageBox.Show("Something went wrong. Unable to save class at this time.",
                                "TrotTrax Alert", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void DeleteClass(object sender, EventArgs e)
        {
            if (!isNew)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this class?\n" +
                        "This operation will delete ALL data associated with this class.\n" +
                        "This operation CANNOT be undone.",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    aClass.RemoveClass();
                    RefreshForm(aClass.clubID, aClass.year);
                }
            }
        }

        private void CancelChanges(object sender, EventArgs e)
        {
            if (AbandonChanges())
                this.Close();
        }

        // Class list methods

        private void PopulateClassList()
        {
            classListBox.Items.Clear();
            foreach (ClassItem entry in aClass.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void NewClass(object sender, EventArgs e)
        {
            if (AbandonChanges())
                RefreshForm(aClass.clubID, aClass.year);
        }

        private void ViewClass(object sender, EventArgs e)
        {
            if (classListBox.SelectedItems.Count != 0)
            {
                int classNo = -1;

                if (AbandonChanges())
                    classNo = Convert.ToInt32(classListBox.SelectedItems[0].Text);
                if (classNo >= 0)
                    RefreshForm(aClass.clubID, aClass.year, classNo);
            }
        }

        private void SortClassList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                aClass.SortClasses("class_no");
            else if (e.Column == 1)
                aClass.SortClasses("class_name");
            PopulateClassList();
        }

        // Category list methods
        private void PopulateCategoryList()
        {
            catListBox.Items.Clear();
            foreach (CategoryItem entry in aClass.catList)
            {
                string[] row = { entry.name, entry.timed.ToString() };
                catListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void SortCategoryList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                aClass.SortCategories("category_no");
            else if (e.Column == 1)
                aClass.SortCategories("description");
            else if (e.Column == 2)
                aClass.SortCategories("fee");
            PopulateCategoryList();
        }

        private void ViewCategory(object sender, EventArgs e)
        {
            if (catListBox.SelectedItems.Count != 0)
            {
                int catNo = -1;

                if (AbandonChanges())
                    catNo = Convert.ToInt32(catListBox.SelectedItems[0].Text);
                if (catNo >= 0)
                {
                    CategoryListForm catForm = new CategoryListForm(aClass.clubID, aClass.year, catNo);
                    catForm.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                    catForm.Visible = true;
                }
            }
        }

        private void NewCategory(object sender, EventArgs e)
        {
            if (AbandonChanges())
            {
                CategoryListForm catForm = new CategoryListForm(aClass.clubID, aClass.year);
                catForm.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                catForm.Visible = true;
            }
        }

        // Show list methods        

        private void PopulateShowList()
        {
            this.showListBox.Items.Clear();
            foreach (ShowItem entry in aClass.showList)
            {
                string value;
                string dateString = entry.date.ToString("MM/dd/yyyy");
                if (entry.name == "")
                    value = dateString;
                else
                    value = dateString + " - " + entry.name;
                showListBox.Items.Add(value);
            }
        }

        private void ViewClassInstance(object sender, EventArgs e)
        {
            if (showListBox.SelectedItems.Count != 0)
            {
                int showNo = -1;

                if (AbandonChanges())
                {
                    string selectedShow = showListBox.SelectedItems[0].ToString();
                    selectedShow = selectedShow.Substring(15, 10);
                    foreach (ShowItem entry in aClass.showList)
                    {
                        string dateString = entry.date.ToString("MM/dd/yyyy");
                        if (dateString == selectedShow)
                        {
                            showNo = entry.no;
                            break;
                        }
                    }
                }
                if (showNo >= 0)
                {
                    ClassInstanceForm classForm = new ClassInstanceForm(aClass.clubID, aClass.year, showNo, aClass.number);
                    classForm.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                    classForm.Visible = true;
                }
            }
        }
    }
}
