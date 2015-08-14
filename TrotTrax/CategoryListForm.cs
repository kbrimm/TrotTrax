/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
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
            this.Text = category.description + " Detail - TrotTrax";
            infoLabel.Text = category.description + "\nCategory Detail";
            numberBox.Text = category.number.ToString();
            descriptionBox.Text = category.description;
            feeBox.Text = "$" + category.fee.ToString();
            timedCheckBox.Checked = category.timed;
            payoutCheckBox.Checked = category.payout;
            jackpotCheckBox.Checked = category.jackpot;
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = false;
        }

        private void PopulateCatList()
        {
            this.catListBox.Items.Clear();
            foreach (CatItem entry in category.catList)
            {
                string[] row = { entry.description, entry.timed.ToString(), entry.payout.ToString(), 
                                  entry.jackpot.ToString(), "$" + entry.fee.ToString() };
                catListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateClassList()
        {
            this.classListBox.Items.Clear();
            foreach (ClassItem entry in category.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
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
            DialogResult confirm = MessageBox.Show("Do you want to abandon your changes?",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void catListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                category.SortCats("category_no");
            else if (e.Column == 1)
                category.SortCats("description");
            else if (e.Column == 5)
                category.SortCats("fee");
            PopulateCatList();
        }

        private void classListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                category.SortClasses("class_no");
            else if (e.Column == 1)
                category.SortClasses("name");
            PopulateClassList();
        }

        private void viewCatBtn_Click(object sender, EventArgs e)
        {
            if (catListBox.SelectedItems.Count != 0)
            {
                bool loadNew = true;
                int catNo = -1;

                if (isChanged)
                    loadNew = AbandonChanges();
                if (loadNew)
                    catNo = Convert.ToInt32(catListBox.SelectedItems[0].Text);

                if (catNo >= 0)
                {
                    CategoryListForm showList = new CategoryListForm(category.clubID, category.year, catNo);
                    showList.Visible = true;
                    this.Close();
                }
            }
        }

        private void newCatBtn_Click(object sender, EventArgs e)
        {
            bool loadNew = true;

            if (isChanged)
                loadNew = AbandonChanges();
            if (loadNew)
            {
                CategoryListForm showList = new CategoryListForm(category.clubID, category.year);
                showList.Visible = true;
                this.Close();
            }
        }

        private void viewClassBtn_Click(object sender, EventArgs e)
        {
            if (classListBox.SelectedItems.Count != 0)
            {
                bool loadNew = true;
                int classNo = -1;

                if (isChanged)
                    loadNew = AbandonChanges();
                if (loadNew)
                    classNo = Convert.ToInt32(classListBox.SelectedItems[0].Text);

                if (classNo >= 0)
                {
                    ClassListForm showList = new ClassListForm(category.clubID, category.year, classNo);
                    showList.Visible = true;
                    this.Close();
                }
            }
        }

        private void newClassBtn_Click(object sender, EventArgs e)
        {
            bool loadNew = true;

            if (isChanged)
                loadNew = AbandonChanges();
            if (loadNew)
            {
                ClassListForm classList = new ClassListForm(category.clubID, category.year);
                classList.Visible = true;
                this.Close();
            }
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                string newDescription = this.descriptionBox.Text;
                string feeString = this.feeBox.Text;
                bool newTimed = this.timedCheckBox.Checked;
                bool newPayout = this.payoutCheckBox.Checked;
                bool newJackpot = this.jackpotCheckBox.Checked;
                DialogResult confirm;
                
                decimal newFee;
                if (feeString[0] == '$')
                    feeString = feeString.Substring(1);
                if (!decimal.TryParse(feeString, out newFee))
                {
                    confirm = MessageBox.Show("Fee must be a valid price.",
                        "TrotTrax Alert", MessageBoxButtons.OK);
                }
                else
                {
                    CategoryListForm catList;
                    if (isNew)
                    {
                        bool success = category.AddCat(newDescription, newTimed, newPayout, newJackpot, newFee);
                        if (success)
                        {
                            confirm = MessageBox.Show("Would you like to add another category?",
                                "TrotTrax Alert", MessageBoxButtons.YesNo);
                            if (confirm == DialogResult.Yes)
                                catList = new CategoryListForm(category.clubID, category.year);
                            else
                                catList = new CategoryListForm(category.clubID, category.year, category.number);
                            catList.Visible = true;
                            this.Close();
                        }
                        else
                        {
                            confirm = MessageBox.Show("Unable to add category at this time.",
                                "TrotTrax Alert", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        bool success = category.ModifyCat(newDescription, newTimed, newPayout, newJackpot, newFee);
                        if (success)
                        {
                            catList = new CategoryListForm(category.clubID, category.year, category.number);
                            catList.Visible = true;
                            this.Close();
                        }
                        else
                        {
                            confirm = MessageBox.Show("Unable to modify category at this time.",
                                "TrotTrax Alert", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if(!isNew)
            {
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete this category?\n" +
                        "This operation will delete ALL classes in this category, and any data associated with them.\n" +
                        "This operation CANNOT be undone.",
                        "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        category.RemoveCat();
                        CategoryListForm catList = new CategoryListForm(category.clubID, category.year);
                        catList.Visible = true;
                        this.Close();
                    }
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if(!isNew && isChanged)
                if(AbandonChanges())
                {
                    CategoryListForm catList = new CategoryListForm(category.clubID, category.year, category.number);
                    catList.Visible = true;
                    this.Close();
                }
        }
    }
}
