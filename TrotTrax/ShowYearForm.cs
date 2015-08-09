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

        public ShowYearForm()
        {
            year = new ShowYear();
            InitializeComponent();
            currentLabel.Text = year.club + "\n\n" + year.year + " Show Year";
            PopulateShowList();
            PopulateClassList();
            PopulateBackNoList();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you really want to quit?",
                    "TrotTrax Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
                Close();
        }

        private void PopulateShowList()
        {
            showListBox.Items.Clear();
            foreach (ShowItem entry in year.showList)
            {
                string value;
                if(entry.description == "")
                    value = entry.date;
                else
                    value = entry.date + " - " + entry.description;
                showListBox.Items.Add(value);
            }
        }

        private void PopulateClassList()
        {
            classListBox.Items.Clear();
            foreach (ClassItem entry in year.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateBackNoList()
        {
            backNoListBox.Items.Clear();
            foreach (BackNoItem entry in year.backNoList)
            {
                string[] row = { entry.rider, entry.horse };
                backNoListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void backNoListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                year.SortBackNos("b.back_no");
            else if (e.Column == 1)
                year.SortBackNos("r.last_name");
            else if (e.Column == 2)
                year.SortBackNos("h.name");
            PopulateBackNoList();
        }

        private void classListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                year.SortClasses("class_no");
            else if (e.Column == 1)
                year.SortClasses("name");
            PopulateClassList();
        }

        private void showsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowListForm showList = new ShowListForm(year.clubID, year.year);
            showList.Visible = true;
        }

        private void viewShowBtn_Click(object sender, EventArgs e)
        {
            int showNo = -1;

            if (showListBox.SelectedItems.Count != 0)
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

            if(showNo >= 0)
            {
                ShowListForm showList = new ShowListForm(year.clubID, year.year, showNo);
                showList.Visible = true;
            }
        }

        private void addShowsBtn_Click(object sender, EventArgs e)
        {
            ShowListForm showList = new ShowListForm(year.clubID, year.year);
            showList.Visible = true;
        }

        private void viewClassBtn_Click(object sender, EventArgs e)
        {
            int classNo = -1;

            if (classListBox.SelectedItems.Count != 0)
                classNo = Convert.ToInt32(classListBox.SelectedItems[0].Text);

            if (classNo >= 0)
            {
                ClassListForm classList = new ClassListForm(year.year, year.clubID, classNo);
                classList.Visible = true;
            }
        }

        private void addClassBtn_Click(object sender, EventArgs e)
        {
            ClassListForm classList = new ClassListForm(year.year, year.clubID);
            classList.Visible = true;
        }

    }
}
