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
    public partial class ShowYearForm : Form
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

        ShowYear year;
        bool isNew;

        #region Constructors 

        // No arguments opens an blank show year panel, prompts user to enter club/year.
        public ShowYearForm()
        {
            InitializeComponent();
            isNew = true;
            ActiveButtons();
        }

        // Passing an integer value indicates that there is data in trot_trax.current
        public ShowYearForm(int hasData)
        {
            year = new ShowYear();
            InitializeComponent();
            isNew = false;
            ActiveButtons();
            PopulateClubMenu();
            PopulateYearMenu();
            PopulateShowList();
            PopulateClassList();
            PopulateBackNoList();

            currentLabel.Text = year.clubName + "\n\n" + year.year + " Show Year";
        }

        #endregion

        #region Form Refresh

        private void RefreshForm()
        {
            year = new ShowYear();
            isNew = false;
            ActiveButtons();

            PopulateClubMenu();
            PopulateYearMenu();
            PopulateShowList();
            PopulateClassList();
            PopulateBackNoList();
        }

        private void ActiveButtons()
        {
            if(isNew)
            {
                // If there's no data in the show, all menu items and view buttons are greyed out.
                viewToolStripMenuItem.Font = menuItalicText;
                viewToolStripMenuItem.ForeColor = grayText;
                reportsToolStripMenuItem.Font = menuItalicText;
                reportsToolStripMenuItem.ForeColor = grayText;
                settingsToolStripMenuItem.Font = menuItalicText;
                settingsToolStripMenuItem.ForeColor = grayText;                

                addShowBtn.Font = italicText;
                addShowBtn.ForeColor = grayText;
                showsToolStripMenuItem.Font = menuItalicText;
                showsToolStripMenuItem.ForeColor = grayText;

                addClassBtn.Font = italicText;
                addClassBtn.ForeColor = grayText;
                classesToolStripMenuItem.Font = menuItalicText;
                classesToolStripMenuItem.ForeColor = grayText;

                addNumberBtn.Font = italicText;
                addNumberBtn.ForeColor = grayText;
                backNumbersToolStripMenuItem.Font = menuItalicText;
                backNumbersToolStripMenuItem.ForeColor = grayText;

                riderListBtn.Font = italicText;
                riderListBtn.ForeColor = grayText;
                ridersToolStripMenuItem.Font = menuItalicText;
                ridersToolStripMenuItem.ForeColor = grayText;
                
                horseListBtn.Font = italicText;
                horseListBtn.ForeColor = grayText;
                horsesToolStripMenuItem.Font = menuItalicText;
                horsesToolStripMenuItem.ForeColor = grayText;
            }
            else
            {
                // Otherwise we can open any menu or blank form.
                viewToolStripMenuItem.Font = menuRegularText;
                viewToolStripMenuItem.ForeColor = blackText;
                reportsToolStripMenuItem.Font = menuRegularText;
                reportsToolStripMenuItem.ForeColor = blackText;
                settingsToolStripMenuItem.Font = menuRegularText;
                settingsToolStripMenuItem.ForeColor = blackText;

                addShowBtn.Font = italicText;
                addShowBtn.ForeColor = grayText;
                showsToolStripMenuItem.Font = menuRegularText;
                showsToolStripMenuItem.ForeColor = blackText;

                addClassBtn.Font = italicText;
                addClassBtn.ForeColor = grayText;
                classesToolStripMenuItem.Font = menuRegularText;
                classesToolStripMenuItem.ForeColor = blackText;

                addNumberBtn.Font = regularText;
                addNumberBtn.ForeColor = blackText;
                backNumbersToolStripMenuItem.Font = menuRegularText;
                backNumbersToolStripMenuItem.ForeColor = blackText;

                riderListBtn.Font = regularText;
                riderListBtn.ForeColor = blackText;
                ridersToolStripMenuItem.Font = menuRegularText;
                ridersToolStripMenuItem.ForeColor = blackText;

                horseListBtn.Font = regularText;
                horseListBtn.ForeColor = blackText;
                horsesToolStripMenuItem.Font = menuRegularText;
                horsesToolStripMenuItem.ForeColor = blackText;
            }

            // These buttons depend on the presence of particular data.
            viewShowBtn.Font = italicText;
            viewShowBtn.ForeColor = grayText;
            viewClassBtn.Font = italicText;
            viewClassBtn.ForeColor = grayText;
            viewNumberBtn.Font = regularText;
            viewNumberBtn.ForeColor = blackText;
        }

        private void RefreshOnClose(object sender, FormClosingEventArgs e)
        {
            RefreshForm();
        }

        private void RefreshOnClick(object sender, EventArgs e)
        {
            RefreshForm();
        }

        #endregion

        #region Form Exit

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

        #endregion

        #region Club Menu

        private void PopulateClubMenu()
        {
            while (openClubToolStripMenuItem.DropDownItems.Count > 2)
                openClubToolStripMenuItem.DropDownItems[2].Dispose();

            foreach (ClubItem clubItem in year.clubList)
            {
                ToolStripMenuItem clubMenuItem = new ToolStripMenuItem();
                clubMenuItem.Name = clubItem.clubID + "MenuEntry";
                clubMenuItem.Size = new System.Drawing.Size(152, 22);
                clubMenuItem.Text = clubItem.clubName;
                clubMenuItem.Click += new System.EventHandler(this.ViewClub);
                this.openClubToolStripMenuItem.DropDownItems.Add(clubMenuItem);
            }
        }

        private void NewClub(object sender, EventArgs e)
        {
            ClubChooserForm clubForm = new ClubChooserForm();
            clubForm.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
            clubForm.Visible = true;
        }

        private void ViewClub(object sender, EventArgs e)
        {
            string viewClub = Convert.ToString(sender);
            foreach(ClubItem club in year.clubList)
                if(club.clubName == viewClub)
                {
                    if (year.SetClub(club.clubID))
                    {
                        RefreshForm();
                        break;
                    }
                    else
                    {
                        DialogResult confirm = MessageBox.Show("Something went wrong, unable to load club data.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
                    }
                }
        }

        #endregion

        #region Year Menu

        private void PopulateYearMenu()
        {
            while (openYearToolStripMenuItem.DropDownItems.Count > 2)
                openYearToolStripMenuItem.DropDownItems[2].Dispose();

            foreach (int yearItem in year.yearList)
            {
                ToolStripMenuItem yearMenuItem = new ToolStripMenuItem();
                yearMenuItem.Name = Convert.ToString(yearItem) + "MenuEntry";
                yearMenuItem.Size = new System.Drawing.Size(152, 22);
                yearMenuItem.Text = Convert.ToString(yearItem);
                yearMenuItem.Click += new System.EventHandler(this.ViewYear);
                this.openYearToolStripMenuItem.DropDownItems.Add(yearMenuItem);
            }
        }

        private void NewYear(object sender, EventArgs e)
        {
            YearChooserForm yearForm = new YearChooserForm();
            yearForm.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
            yearForm.Visible = true;
        }

        private void ViewYear(object sender, EventArgs e)
        {
            int viewYear;
            string yearString = Convert.ToString(sender);

            try
            {
                viewYear = Convert.ToInt32(yearString);
                year.SetYear(viewYear);
                RefreshForm();
            }
            catch
            {
                DialogResult confirm = MessageBox.Show("Something went wrong, unable to load club data.",
                            "TrotTrax Alert", MessageBoxButtons.OK);
            }
        }

        #endregion

        #region Show List

        private void PopulateShowList()
        {
            showListBox.Items.Clear();
            foreach (ShowItem entry in year.showList)
            {
                string dateString = entry.date.ToString("MM/dd/yyyy");
                string value;
                if(entry.name == "")
                    value = dateString;
                else
                    value = dateString + " - " + entry.name;
                showListBox.Items.Add(value);
            }

            if (year.showList.Count() > 0)
            {
                viewShowBtn.Font = regularText;
                viewShowBtn.ForeColor = blackText;
            }
        }

        private void NewShow(object sender, EventArgs e)
        {
            {
                if (!isNew)
                {
                    ShowListForm showList = new ShowListForm(year.clubID, year.year);
                    showList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
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
                ShowListForm showList = new ShowListForm(year.clubID, year.year, showNo);
                showList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                showList.Visible = true;
            }
        }

        #endregion

        #region Class List

        private void PopulateClassList()
        {
            classListBox.Items.Clear();
            foreach (ClassItem entry in year.classList)
            {
                string[] row = { entry.name };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }

            if(year.classList.Count() > 0)
            {
                viewClassBtn.Font = regularText;
                viewClassBtn.ForeColor = blackText;
            }
        }

        private void SortClassList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                year.SortClasses(ClassSort.Number);
            else if (e.Column == 1)
                year.SortClasses(ClassSort.Name);
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

        #endregion

        #region Back Number List

        private void PopulateBackNoList()
        {
            backNoListBox.Items.Clear();
            foreach (BackNoItem entry in year.backNoList)
            {
                string[] row = { entry.rider, entry.horse };
                backNoListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }

            if (year.backNoList.Count() > 0)
            {
                viewNumberBtn.Font = regularText;
                viewNumberBtn.ForeColor = blackText;
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

        private void ViewBackNo(object sender, EventArgs e)
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

        private void ViewRider(object sender, EventArgs e)
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

        private void ViewHorse(object sender, EventArgs e)
        {
            if (!isNew)
            {
                HorseListForm horseList = new HorseListForm();
                horseList.Visible = true;
            }
        }

        #endregion

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
