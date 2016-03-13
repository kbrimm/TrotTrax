﻿/* 
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
        System.Drawing.Font menuItalicText = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic,
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        System.Drawing.Font italicText = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic,
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        System.Drawing.Color grayText = System.Drawing.SystemColors.GrayText;
        System.Drawing.Font menuRegularText = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        System.Drawing.Font regularText = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        System.Drawing.Color blackText = System.Drawing.SystemColors.ControlText;
        
        private Category category;
        private bool isChanged;
        private bool isNew;

        #region Constructors
        // Load a new category form.
        public CategoryListForm(string clubID, int year)
        {
            category = new Category(clubID, year);
            InitializeComponent();
            PopulateCatList();
            PopulateClassList();
            this.numberBox.Text = category.number.ToString();
            this.modifyBtn.Text = "Add New Category";
            this.deleteBtn.Font = italicText;
            this.deleteBtn.ForeColor = grayText;
            isChanged = false;
            isNew = true;
        }

        // Load an existing category form.
        public CategoryListForm(string clubID, int year, int catNo)
        {
            category = new Category(clubID, year, catNo);
            InitializeComponent();
            PopulateCatList();
            PopulateClassList();
            this.Text = category.name + " Category Detail - TrotTrax";
            this.infoLabel.Text = category.name + "\nCategory Detail";
            this.numberBox.Text = category.number.ToString();
            this.descriptionBox.Text = category.name;
            this.timedCheckBox.Checked = category.timed;
            this.modifyBtn.Font = italicText;
            this.modifyBtn.ForeColor = grayText;
            this.cancelBtn.Font = italicText;
            this.cancelBtn.ForeColor = grayText;
            isChanged = false;
            isNew = false;
        }

        #endregion

        #region Refresh Form
        // Refresh to new category form.
        private void RefreshForm(string clubID, int year)
        {
            category = new Category(clubID, year);
            PopulateCatList();
            PopulateClassList();
            this.numberBox.Text = category.number.ToString();
            this.modifyBtn.Text = "Add New Category";
            this.deleteBtn.Font = italicText;
            this.deleteBtn.ForeColor = grayText;
            isChanged = false;
            isNew = true;
        }

        // Refresh to existing category form.
        private void RefreshForm(string clubID, int year, int catNo)
        {
            category = new Category(clubID, year, catNo);
            PopulateCatList();
            PopulateClassList();
            this.Text = category.name + " Category Detail - TrotTrax";
            this.infoLabel.Text = category.name + "\nCategory Detail";
            this.numberBox.Text = category.number.ToString();
            this.descriptionBox.Text = category.name;
            this.timedCheckBox.Checked = category.timed;
            this.modifyBtn.Font = italicText;
            this.modifyBtn.ForeColor = grayText;
            this.cancelBtn.Font = italicText;
            this.cancelBtn.ForeColor = grayText;
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

        #endregion

        #region Form Changes

        // When changes are made, activates relevant buttons.
        private void DataChanged(object sender, EventArgs e)
        {
            this.modifyBtn.Font = regularText;
            this.modifyBtn.ForeColor = blackText;
            this.cancelBtn.Font = regularText;
            this.cancelBtn.ForeColor = blackText;
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

        #region Category Data

        // Gets user-entered description and timed value
        // For new categories, adds to database, prompts to add more automatically.
        // For existing categories, modifies existing entry.
        private void SaveCategory(object sender, EventArgs e)
        {
            if (isChanged)
            {
                string newDescription = this.descriptionBox.Text;
                bool newTimed = this.timedCheckBox.Checked;
                DialogResult confirm;

                if (isNew)
                {
                    bool success = category.AddCategory(newDescription, newTimed);
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

        // Deletes category item from database. Prompts user, as this has a delete-on-cascade effect.
        private void DeleteCat(object sender, EventArgs e)
        {
            if (!isNew)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this category?\n" +
                    "This operation will delete ALL classes in this category, and any data associated with them. " +
                    "This operation CANNOT be undone.",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    category.RemoveCat();
                    RefreshForm(category.clubID, category.year);
                }             
            }
        }

        // Exits without saving. Prompts for abandoned changes.
        private void CancelChanges(object sender, EventArgs e)
        {
            if (AbandonChanges())
                this.Close();
        }

        #endregion

        #region Category List

        // Populates catList from database.
        private void PopulateCatList()
        {
            this.catListBox.Items.Clear();
            foreach (CategoryItem entry in category.catList)
            {
                string[] row = { entry.name, entry.timed.ToString() };
                catListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        // Sorts catList based on column clicks by repopulating catList.
        private void SortCats(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                category.SortCategories(CategorySort.Number);
            else if (e.Column == 1)
                category.SortCategories(CategorySort.Name);
            PopulateCatList();
        }

        // Refreshes to new category form.
        private void NewCat(object sender, EventArgs e)
        {
            if (AbandonChanges())
                RefreshForm(category.clubID, category.year);
        }

        // If category is selected from list, refreshes to existing category form.
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

        #endregion

        #region Class List

        // Populates classList from database.
        private void PopulateClassList()
        {
            this.classListBox.Items.Clear();
            foreach (ClassItem entry in category.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        // Sorts classList based on column clicks by repopulating classList.
        private void SortClasses(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                category.SortClasses(ClassSort.Number);
            else if (e.Column == 1)
                category.SortClasses(ClassSort.Name);
            PopulateClassList();
        }

        // Loads new class form, closes current.
        private void NewClass(object sender, EventArgs e)
        {
            if (AbandonChanges())
            {
                ClassListForm classList = new ClassListForm(category.clubID, category.year);
                classList.Visible = true;
                this.Close();
            }
        }

        // If class is selected from list, loads existing class window, closes current.
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
        #endregion
    }
}
