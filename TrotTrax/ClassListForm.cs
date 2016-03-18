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

        #region Constructors

        // New class form.
        public ClassListForm(string clubID, int year)
        {
            aClass = new Class(clubID, year);
            InitializeComponent();
            SetNewData();
        }

        private void SetNewData()
        {
            PopulateDropDown();
            PopulateCategoryList();
            PopulateClassList();
            this.Text = "New Class - TrotTrax";
            this.showLabel.Text = "New Class\nSetup";
            this.numberBox.Text = aClass.number.ToString();
            this.nameBox.Text = String.Empty;
            this.nameBox.Focus();
            this.feeBox.Text = "0.00";
            this.modifyBtn.Text = "Add Class";

            // Modify btn is disabled until changes are made. Cannot delete or view results for an unsaved record.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.viewResultBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewResultBtn.ForeColor = System.Drawing.SystemColors.GrayText;

            isChanged = false;
            isNew = true;
        }

        // Existing class from.
        public ClassListForm(string clubID, int year, int classNo)
        {
            aClass = new Class(clubID, year, classNo);
            InitializeComponent();
            SetExistingData();
        }

        private void SetExistingData()
        {
            PopulateDropDown();
            PopulateCategoryList();
            PopulateClassList();
            PopulateShowList();
            this.Text = aClass.name + " Class Detail - TrotTrax";
            this.showLabel.Text = aClass.name + "\r\nClass Detail";
            this.numberBox.Text = aClass.number.ToString();
            this.nameBox.Text = aClass.name;
            this.nameBox.Focus();
            this.feeBox.Text = aClass.fee.ToString("#,##0.00");
            this.catComboBox.SelectedValue = aClass.catNo;
            this.modifyBtn.Text = "Save Changes";

            // Modify btn is disabled until changes are made.
            this.modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.viewResultBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewResultBtn.ForeColor = System.Drawing.SystemColors.ControlText;

            isChanged = false;
            isNew = false;
        }

        #endregion

        #region Refresh Form

        // Refresh to new class form.
        private void RefreshForm(string clubID, int year)
        {
            aClass = new Class(clubID, year);
            SetNewData();
        }

        // Refresh to existing class form.
        private void RefreshForm(string clubID, int year, int classNo)
        {
            aClass = new Class(clubID, year, classNo);
            SetExistingData();
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

        #endregion

        #region Form Changes

        // When changes are made, activates relevant buttons.
        private void DataChanged(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            isChanged = true;
        }

        // On form close, prompt to abandon unsaved changes.
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

        #endregion

        #region Class Data

        // Populates category combo box.
        private void PopulateDropDown()
        {
            // Initializes box with a 'null' item for display purposes.
            dropDownList = new List<DropDownItem>();
            dropDownList.Add(new DropDownItem() { no = 0, name = String.Empty });

            // Adds the contents of the category item list retrieved from the database.
            foreach (CategoryItem entry in aClass.catList)
                dropDownList.Add(new DropDownItem() { no = entry.no, name = entry.no + " - " + entry.name });

            // Sets this list as the menu's data source and tells the menu which parts to show.
            catComboBox.DataSource = dropDownList;
            catComboBox.DisplayMember = "name";
            catComboBox.ValueMember = "no";
        }

        // Gets user-entered class number, name, fee, and category.
        // Validates that fee is not a decimal, class number is a unique value, class is not in a category
        // For new classes, adds to database, prompts to add more automatically.
        // For existing categories, modifies existing entry for same number,
        // or inserts new and deletes old entry for different number.
        private void SaveClass(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult confirm;
                string name = this.nameBox.Text;
                int number = VerifyNumber(this.numberBox.Text);
                decimal fee = VerifyFee(this.feeBox.Text);
                int category = VerifyCategory(this.catComboBox.SelectedValue);
 
                if(number > 0 && fee > 0 && category > 0)
                {
                    // If it's a new class, add and prompt for more additions.
                    if (isNew)
                    {
                        if (aClass.AddClass(number, category, name, fee))
                        {
                            confirm = MessageBox.Show("Would you like to add another class?", "TrotTrax Alert", MessageBoxButtons.YesNo);
                            if (confirm == DialogResult.Yes)
                                RefreshForm(aClass.clubID, aClass.year);
                            else
                                RefreshForm(aClass.clubID, aClass.year, number);
                        }
                        // Something went wrong.
                        else
                            confirm = MessageBox.Show("Something went wrong. Unable to save class at this time.",
                                "TrotTrax Alert", MessageBoxButtons.OK);
                    }
                    // Otherwise: do or do not, there is no try.
                    else
                    {
                        // If this update does not change the class number, just update the entry.
                        // Otherwise, insert new class at new number, delete current.
                        if(number == aClass.number)
                        {
                            if (aClass.ModifyClass(number, category, name, fee))
                                RefreshForm(aClass.clubID, aClass.year, number);
                            // Unless something terrible happens.
                            else
                                confirm = MessageBox.Show("Something went wrong. Unable to save class at this time.",
                                    "TrotTrax Alert", MessageBoxButtons.OK);
                        }
                        else
                        {
                            // The deletion of the existing number relies on successful insertion of the new,
                            // so in the event of catastrophic failure, the data should hopefully still be there somewhere.
                            if (aClass.AddClass(number, category, name, fee))
                            {
                                aClass.RemoveClass();
                                RefreshForm(aClass.clubID, aClass.year, number);
                            }
                            // Unless something terrible happens.
                            else
                                confirm = MessageBox.Show("Something went wrong. Unable to save class at this time.",
                                    "TrotTrax Alert", MessageBoxButtons.OK);
                        }
                        
                    }
                }
            }
        }

        #region Data Verifiers

        // Verifies class number input - returns -1 on fail.
        private int VerifyNumber(string noString)
        {
            DialogResult confirm;
            int number;

            if (noString == String.Empty || !int.TryParse(noString, out number))
            { 
                confirm = MessageBox.Show("Class number must be an integer value.", "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }

            // If we're assigning a new number to a class, it needs to be checked.
            if ((isNew || number != aClass.number) && aClass.CheckIndexUsed(FormType.Class, number))
            {
                confirm = MessageBox.Show("Class number already exists.", "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }

            return number;
        }

        // Verifies fee input - returns -1 on fail.
        private decimal VerifyFee(string feeString)
        {
            DialogResult confirm;
            bool validFee;
            decimal fee;

            Console.WriteLine("String value for fee: " + feeString);
            Console.WriteLine("Length of string: " + feeString.Length);
            validFee = decimal.TryParse(feeString, System.Globalization.NumberStyles.Any, 
                new System.Globalization.CultureInfo("en-US"), out fee);
            Console.WriteLine("Parsed value for fee: " + fee);
            if (feeString == String.Empty || !validFee)
            {
                confirm = MessageBox.Show("Fee must be a valid decimal value.", "TrotTrax Alert", MessageBoxButtons.OK);
                return -1;
            }
            else
                return fee;
        }

        // Verifies category number - returns -1 on fail.
        private int VerifyCategory(object categoryObject)
        {
            DialogResult confirm;
            int category = Convert.ToInt32(this.catComboBox.SelectedValue);

            if (aClass.catList.Count == 0)
            {
                confirm = MessageBox.Show("Each class must have an associated category.",
                    "TrotTrax Confirmation", MessageBoxButtons.OK);
                return -1;
            }
            return category;
        }

        #endregion

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

        #endregion

        #region Class List

        // Populates classList.
        private void PopulateClassList()
        {
            classListBox.Items.Clear();
            foreach (ClassItem entry in aClass.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }

            // If the classList box is empty, no view option.
            if (classListBox.Items.Count == 0)
            {
                this.viewClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewClassBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            else
            {
                this.viewClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewClassBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        // Sorts classList based on column clicks.
        private void SortClassList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                aClass.SortClasses(ClassSort.Number);
            else if (e.Column == 1)
                aClass.SortClasses(ClassSort.Name);
            PopulateClassList();
        }

        // Refreshes to new class form.
        private void NewClass(object sender, EventArgs e)
        {
            if (AbandonChanges())
                RefreshForm(aClass.clubID, aClass.year);
        }

        // If class is selected, refreshes to existing class form.
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

        #endregion

        #region Category List

        private void PopulateCategoryList()
        {
            catListBox.Items.Clear();
            foreach (CategoryItem entry in aClass.catList)
            {
                string[] row = { entry.name, entry.timed.ToString() };
                catListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }

            // If the catList box is empty, no view option.
            if (catListBox.Items.Count == 0)
            {
                this.catViewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.catViewBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            else
            {
                this.catViewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.catViewBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void SortCategoryList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                aClass.SortCategories(CategorySort.Number);
            else if (e.Column == 1)
                aClass.SortCategories(CategorySort.Name);
            PopulateCategoryList();
        }

        // Loads new category form, closes current.
        private void NewCategory(object sender, EventArgs e)
        {
            if (AbandonChanges())
            {
                CategoryListForm catForm = new CategoryListForm(aClass.clubID, aClass.year);
                // catForm.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                catForm.Visible = true;
                this.Close();
            }
        }

        // If category is selected from list, loads existing category form, closes current.
        private void ViewCategory(object sender, EventArgs e)
        {
            if (catListBox.SelectedItems.Count != 0)
            {
                int catNo = -1;

                if (int.TryParse(catListBox.SelectedItems[0].Text, out catNo) && AbandonChanges())
                {
                    CategoryListForm catForm = new CategoryListForm(aClass.clubID, aClass.year, catNo);
                    // catForm.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                    catForm.Visible = true;
                    this.Close();
                }
            }
        }

        #endregion

        #region Show List

        // Populates showList from database.
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

        // If class is selected from list, loads results form, closes current;
        private void ViewResults(object sender, EventArgs e)
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
                    ResultListForm classForm = new ResultListForm(aClass.clubID, aClass.year, showNo, aClass.number);
                    //classForm.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                    classForm.Visible = true;
                    this.Close();
                }
            }

            if (showListBox.Items.Count == 0)
            {
                this.viewResultBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewResultBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            else
            {
                this.viewResultBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.viewResultBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        #endregion
    }
}
