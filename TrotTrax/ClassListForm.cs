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
    public partial class ClassListForm : Form
    {
        private Class aClass;
        private bool isChanged;
        private bool isNew;
        private List<CatBoxItem> catBoxItemList = new List<CatBoxItem>();


        public ClassListForm(int year, string clubID)
        {
            aClass = new Class(year, clubID);
            InitializeComponent();
            PopulateClassList();
            PopulateCatList();
            PopulateShowList();
            PopulateCatBox();
            this.Text = "New Class Detail - TrotTrax";
            modifyBtn.Text = "Add New Class";
            deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = true;
        }

        public ClassListForm(int year, string clubID, int classNo)
        {
            aClass = new Class(year, clubID, classNo);
            InitializeComponent();
            PopulateClassList();
            PopulateCatList();            
            PopulateShowList();
            PopulateCatBox();
            this.Text = aClass.name + " Detail - TrotTrax";
            numberBox.Text = classNo.ToString();
            nameBox.Text = aClass.name;
            catBox.SelectedValue = aClass.catNo;
            showLabel.Text = aClass.name + "\r\nClass Detail";
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            isChanged = false;
            isNew = false;
        }

        private void PopulateClassList()
        {
            this.classListBox.Items.Clear();
            foreach (ClassItem entry in aClass.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateCatList()
        {
            this.catListBox.Items.Clear();
            foreach(CatItem entry in aClass.catList)
            {
                string[] row = { entry.description, entry.timed.ToString(), entry.payout.ToString(), 
                                  entry.jackpot.ToString(), "$" + entry.fee.ToString() };
                catListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateShowList()
        {
            this.showListBox.Items.Clear();
            foreach (ShowItem entry in aClass.showList)
            {
                string value;
                if (entry.description == "")
                    value = entry.date;
                else
                    value = entry.date + " - " + entry.description;
                showListBox.Items.Add(value);
            }
        }

        private void PopulateCatBox()
        {
            foreach(CatItem entry in aClass.catList)
            {
                catBoxItemList.Add(new CatBoxItem() {no = entry.no, description = entry.description});
            }

            this.catBox.DataSource = catBoxItemList;
            this.catBox.DisplayMember = "description";
            this.catBox.ValueMember = "no";
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
                    ClassListForm showList = new ClassListForm(aClass.year, aClass.clubID, classNo);
                    showList.Visible = true;
                    this.Close();
                }
            }
        }

        private void newClassBtn_Click(object sender, EventArgs e)
        {
            ClassListForm classList = new ClassListForm(aClass.year, aClass.clubID);
            classList.Visible = true;
            this.Close();
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            if(isChanged)
            {
                string noString = this.numberBox.Text.ToString();
                string name = this.nameBox.Text;
                int category = Convert.ToInt32(this.catBox.SelectedValue);
                int number;

                if (noString == String.Empty || !int.TryParse(noString, out number))
                {
                    DialogResult confirm = MessageBox.Show("Class number must be a unique integer value.",
                        "TrotTrax Alert", MessageBoxButtons.OK);
                }
                else
                {
                    if(isNew)
                    {
                        bool success = aClass.AddClass(number, category, name);
                        if (success)
                        {
                            ClassListForm classList = new ClassListForm(aClass.year, aClass.clubID, number);
                            classList.Visible = true;
                            this.Close();
                        }
                        else
                        {
                            DialogResult confirm = MessageBox.Show("Class number must be unique.",
                                "TrotTrax Alert", MessageBoxButtons.OK);
                        }
                    }                        
                    else
                    {
                        bool success = aClass.ModifyClass(number, category, name);
                        if (success)
                        {
                            ClassListForm classList = new ClassListForm(aClass.year, aClass.clubID, number);
                            classList.Visible = true;
                            this.Close();
                        }
                        else
                        {
                            DialogResult confirm = MessageBox.Show("Unable to add class at this time.",
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
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this class and all of its data?",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    aClass.RemoveClass();
                    ClassListForm classList = new ClassListForm(aClass.year, aClass.clubID);
                    classList.Visible = true;
                    this.Close();
                }          
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if(AbandonChanges())
            {
                ClassListForm classList = new ClassListForm(aClass.year, aClass.clubID, aClass.number);
                classList.Visible = true;
                this.Close();
            }
        }

        private void classListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                aClass.SortClasses("class_no");
            else if (e.Column == 1)
                aClass.SortClasses("name");
            PopulateClassList();
        }

        private void catListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                aClass.SortCats("category_no");
            else if (e.Column == 1)
                aClass.SortCats("description");
            else if (e.Column == 5)
                aClass.SortCats("fee");
            PopulateCatList();
        }
    }
}
