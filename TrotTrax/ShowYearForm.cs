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
    public partial class ShowYearForm : Form
    {
        ShowYear year;
        bool isNew;

        // No arguments opens an blank show year panel, prompts user to enter club/year.
        public ShowYearForm()
        {
            InitializeComponent();
            viewShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewShowBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            addShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            addShowBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            addClassBtn.ForeColor = System.Drawing.SystemColors.GrayText;

            isNew = true;
        }

        // Passing an integer value indicates that there is data in trot_trax.current
        public ShowYearForm(int hasData)
        {
            year = new ShowYear();
            InitializeComponent();
            currentLabel.Text = year.club + "\n\n" + year.year + " Show Year";
            PopulateShowList();
            PopulateClassList();
            PopulateBackNoList();

            isNew = false;
        }

        private void ExitMenu(object sender, EventArgs e)
        {
            Close();
        }

        private void ExitPrompt(object sender, FormClosingEventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you really want to quit?",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
                e.Cancel = true;
        }

        // Club list methods

        private void PopulateClubList()
        {

        }

        private void NewClub(object sender, EventArgs e)
        {

        }

        private void ViewClub(object sender, EventArgs e)
        {

        }

        // Year list methods

        private void PopulateYearList()
        {

        }

        private void NewYear(object sender, EventArgs e)
        {

        }

        private void ViewYear(object sender, EventArgs e)
        {
            if (!isNew)
            {
                CategoryListForm catList = new CategoryListForm(year.clubID, year.year);
                catList.Visible = true;
            }
        }

        // Show list methods

        private void PopulateShowList()
        {
            showListBox.Items.Clear();
            foreach (ShowItem entry in year.showList)
            {
                string value;
                if(entry.name == "")
                    value = entry.date;
                else
                    value = entry.date + " - " + entry.name;
                showListBox.Items.Add(value);
            }
        }

        private void NewShow(object sender, EventArgs e)
        {
            {
                if (!isNew)
                {
                    ShowListForm showList = new ShowListForm(year.clubID, year.year);
                    showList.Visible = true;
                }
            }
        }

        private void ViewShow(object sender, EventArgs e)
        {
            int showNo = -1;

            if (showListBox.SelectedItems.Count != 0 && !isNew)
            {
                string selectedShow = showListBox.SelectedItems[0].ToString();
                selectedShow = selectedShow.Substring(15, 10);
                foreach (ShowItem entry in year.showList)
                    if (entry.date == selectedShow)
                    {
                        showNo = entry.no;
                        break;
                    }
            }

            if (showNo >= 0)
            {
                ShowListForm showList = new ShowListForm(year.clubID, year.year, showNo);
                showList.Visible = true;
            }
        }

        // Class list methods

        private void PopulateClassList()
        {
            classListBox.Items.Clear();
            foreach (ClassItem entry in year.classList)
            {
                string[] row = { entry.name };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void SortClassList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                year.SortClasses("class_no");
            else if (e.Column == 1)
                year.SortClasses("class_name");
            PopulateClassList();
        }

        private void NewClass(object sender, EventArgs e)
        {
            if (!isNew)
            {
                ClassListForm classList = new ClassListForm(year.clubID, year.year);
                classList.Visible = true;
            }
        }

        private void ViewClass(object sender, EventArgs e)
        {
            int classNo = -1;

            if (classListBox.SelectedItems.Count != 0 && !isNew)
                classNo = Convert.ToInt32(classListBox.SelectedItems[0].Text);

            if (classNo >= 0)
            {
                ClassListForm classList = new ClassListForm(year.clubID, year.year, classNo);
                classList.Visible = true;
            }
        }

        // Back number list functions

        private void PopulateBackNoList()
        {
            backNoListBox.Items.Clear();
            foreach (BackNoItem entry in year.backNoList)
            {
                string[] row = { entry.rider, entry.horse };
                backNoListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void SortBackNoList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                year.SortBackNos("back_no");
            else if (e.Column == 1)
                year.SortBackNos("rider_last");
            else if (e.Column == 2)
                year.SortBackNos("horse_name");
            PopulateBackNoList();
        }

        private void NewBackNo(object sender, EventArgs e)
        {
            
        }

        private void NewRider(object sender, EventArgs e)
        {
            if (!isNew)
            {
                RiderListForm riderList = new RiderListForm(year.clubID, year.year);
                riderList.Visible = true;
            }
        }

        private void NewHorse(object sender, EventArgs e)
        {
            if (!isNew)
            {
                HorseListForm horseList = new HorseListForm();
                horseList.Visible = true;
            }
        }

        private void ViewBackNo(object sender, EventArgs e)
        {
            
        }

        private void ViewRider(object sender, EventArgs e)
        {
            if (!isNew)
            {
                RiderListForm riderList = new RiderListForm(year.clubID, year.year);
                riderList.Visible = true;
            }
        }

        private void ViewHorse(object sender, EventArgs e)
        {
            if (!isNew)
            {
                HorseListForm horseList = new HorseListForm();
                horseList.Visible = true;
            }
        }

        // Other toolbar methods

        private void NewCategory(object sender, EventArgs e)
        {
            if (!isNew)
            {
                CategoryListForm catList = new CategoryListForm(year.clubID, year.year);
                catList.Visible = true;
            }
        }
    }
}
