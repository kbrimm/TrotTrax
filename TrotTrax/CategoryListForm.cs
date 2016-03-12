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
    public partial class CategoryListForm : Form
    {
        private Category category;
        private bool isChanged;
        private bool isNew;

        public CategoryListForm(string clubID, int year)
        {
            category = new Category(clubID, year);
            InitializeComponent();
            PopulateCatList();
            PopulateClassList();
            modifyBtn.Text = "Add New Category";
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = true;
        }

        public CategoryListForm(string clubID, int year, int catNo)
        {
            category = new Category(clubID, year, catNo);
            InitializeComponent();
            PopulateCatList();
            PopulateClassList();
            this.Text = category.name + " Detail - TrotTrax";
            infoLabel.Text = category.name + "\nCategory Detail";
            numberBox.Text = category.number.ToString();
            descriptionBox.Text = category.name;
            timedCheckBox.Checked = category.timed;
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = false;
        }

        private void RefreshForm(string clubID, int year)
        {
            category = new Category(clubID, year);
            PopulateCatList();
            PopulateClassList();
            modifyBtn.Text = "Add New Category";
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = true;
        }

        private void RefreshForm(string clubID, int year, int catNo)
        {
            category = new Category(clubID, year, catNo);
            PopulateCatList();
            PopulateClassList();
            this.Text = category.name + " Detail - TrotTrax";
            infoLabel.Text = category.name + "\nCategory Detail";
            numberBox.Text = category.number.ToString();
            descriptionBox.Text = category.name;
            timedCheckBox.Checked = category.timed;
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = false;
        }

        private void RefreshOnClose(object sender, FormClosingEventArgs e)
        {
            if (AbandonChanges())
                if (isNew)
                    RefreshForm(category.clubID, category.year);
                else
                    RefreshForm(category.clubID, category.year, category.number);
            else
                PopulateClassList();
        }

        private void DataChanged(object sender, EventArgs e)
        {
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelBtn.ForeColor = System.Drawing.SystemColors.ControlText;
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

        // Category data methods

        private void SaveCat(object sender, EventArgs e)
        {
            if (isChanged)
            {
                int newNo = Convert.ToInt32(this.numberBox.Text);
                string newDescription = this.descriptionBox.Text;
                bool newTimed = this.timedCheckBox.Checked;
                DialogResult confirm;

                if (isNew)
                {
                    bool success = category.AddCategory(newNo, newDescription, newTimed);
                    if (success)
                    {
                        confirm = MessageBox.Show("Would you like to add another category?",
                            "TrotTrax Alert", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                            RefreshForm(category.clubID, category.year);
                        else
                            RefreshForm(category.clubID, category.year, category.number);
                    }
                    else
                        confirm = MessageBox.Show("Unable to add category at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
                else
                {
                    bool success = category.ModifyCategory(newDescription, newTimed);
                    if (success)
                        RefreshForm(category.clubID, category.year, category.number);
                    else
                        confirm = MessageBox.Show("Unable to modify category at this time.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                }
            }
        }

        private void DeleteCat(object sender, EventArgs e)
        {
            if (!isNew)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this category?\n" +
                    "This operation will delete ALL classes in this category, and any data associated with them.\n" +
                    "This operation CANNOT be undone.",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    category.RemoveCat();
                    RefreshForm(category.clubID, category.year);
                }             
            }
        }

        private void CancelChanges(object sender, EventArgs e)
        {
            if (AbandonChanges())
                this.Close();
        }

        // Category list methods

        private void PopulateCatList()
        {
            this.catListBox.Items.Clear();
            foreach (CategoryItem entry in category.catList)
            {
                string[] row = { entry.name, entry.timed.ToString() };
                catListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void SortCats(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                category.SortCategories(CategorySort.Number);
            else if (e.Column == 1)
                category.SortCategories(CategorySort.Name);
            PopulateCatList();
        }

        private void NewCat(object sender, EventArgs e)
        {
            if (AbandonChanges())
                RefreshForm(category.clubID, category.year);
        }

        private void ViewCat(object sender, EventArgs e)
        {
            if (catListBox.SelectedItems.Count != 0)
            {
                int catNo = -1;

                if (AbandonChanges())
                    catNo = Convert.ToInt32(catListBox.SelectedItems[0].Text);

                if (catNo >= 0)
                    RefreshForm(category.clubID, category.year, catNo);
            }
        }

        // Class list methods

        private void PopulateClassList()
        {
            this.classListBox.Items.Clear();
            foreach (ClassItem entry in category.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void SortClasses(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                category.SortClasses(ClassSort.Number);
            else if (e.Column == 1)
                category.SortClasses(ClassSort.Name);
            PopulateClassList();
        }

        private void NewClass(object sender, EventArgs e)
        {
            if (AbandonChanges())
            {
                ClassListForm classList = new ClassListForm(category.clubID, category.year);
                classList.Visible = true;
                this.Close();
            }
        }

        private void ViewClass(object sender, EventArgs e)
        {
            if (classListBox.SelectedItems.Count != 0)
            {
                int classNo = -1;

                if (AbandonChanges())
                    classNo = Convert.ToInt32(classListBox.SelectedItems[0].Text);

                if (classNo >= 0)
                {
                    ClassListForm showList = new ClassListForm(category.clubID, category.year, classNo);
                    showList.Visible = true;
                    this.Close();
                }
            }
        }
    }
}
