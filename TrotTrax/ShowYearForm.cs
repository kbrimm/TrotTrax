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
        ShowYear year;
        bool isNew;

        #region Constructors 

        // No arguments opens an blank show year panel.
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

            this.currentLabel.Text = year.clubName + "\n\n" + year.year + " Show Year";
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

            this.currentLabel.Text = year.clubName + "\n\n" + year.year + " Show Year";
        }

        private void ActiveButtons()
        {
            if(isNew)
            {
                // If there's no data in the show, all menu items and view buttons are greyed out.
                openYearToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                openYearToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                newYearToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newYearToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                refreshDataToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                refreshDataToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;

                viewToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                backNumbersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                backNumbersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                classesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                classesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                horsesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                horsesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                ridersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ridersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                showsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                showsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;     

                reportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                reportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                classReportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                classReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                membershipReportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                membershipReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                showReportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                showReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                yearlyReportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                yearlyReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;

                settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                settingsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                categoriesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                categoriesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                importToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                importToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
                pointsSchemeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                pointsSchemeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;

                addShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                addShowBtn.ForeColor = System.Drawing.SystemColors.GrayText;
                addClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                addClassBtn.ForeColor = System.Drawing.SystemColors.GrayText;
                addNumberBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                addNumberBtn.ForeColor = System.Drawing.SystemColors.GrayText;
                viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewRiderBtn.ForeColor = System.Drawing.SystemColors.GrayText;                
                viewHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewHorseBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            else
            {
                // Otherwise we can open any menu or blank form.

                openYearToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                openYearToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                newYearToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newYearToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                refreshDataToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                refreshDataToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;

                viewToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                backNumbersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                backNumbersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                classesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                classesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                horsesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                horsesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                ridersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ridersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                showsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                showsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;

                reportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                reportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                classReportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                classReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                membershipReportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                membershipReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                showReportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                showReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                yearlyReportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                yearlyReportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;

                settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                settingsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                categoriesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                categoriesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                importToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                importToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
                pointsSchemeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                pointsSchemeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;

                addShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                addShowBtn.ForeColor = System.Drawing.SystemColors.ControlText;
                addClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                addClassBtn.ForeColor = System.Drawing.SystemColors.ControlText;
                addNumberBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                addNumberBtn.ForeColor = System.Drawing.SystemColors.ControlText;
                viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewRiderBtn.ForeColor = System.Drawing.SystemColors.ControlText;
                viewHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewHorseBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }

            // These buttons depend on the presence of particular data.
            viewShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewShowBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewClassBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewNumberBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewNumberBtn.ForeColor = System.Drawing.SystemColors.GrayText;
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
                viewShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewShowBtn.ForeColor = System.Drawing.SystemColors.ControlText;
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
                viewClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewClassBtn.ForeColor = System.Drawing.SystemColors.ControlText;
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
                string[] row = { entry.riderNo.ToString(), entry.rider, entry.horseNo.ToString(), entry.horse };
                backNoListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }

            if (year.backNoList.Count() > 0)
            {
                viewNumberBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewNumberBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void SortBackNoList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                year.SortBackNos(BackNoSort.Number);
            else if (e.Column == 1)
                year.SortBackNos(BackNoSort.Rider);
            else if (e.Column == 2)
                year.SortBackNos(BackNoSort.Horse);
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
                HorseListForm horseList = new HorseListForm(year.clubID, year.year);
                horseList.Visible = true;
            }
        }

        // If horse is selected, refreshes to existing horse form.
        private void ViewHorse(object sender, EventArgs e)
        {
            if (backNoListBox.SelectedItems.Count != 0)
            {
                int horseNo = -1;

                horseNo = Convert.ToInt32(backNoListBox.SelectedItems[3].Text);
                if (horseNo >= 0)
                {
                    HorseListForm horseList = new HorseListForm(year.clubID, year.year, horseNo);
                    horseList.Visible = true;
                }
            }
        }

        #endregion

        // Reports Menu

        #region Settings Menu

        private void NewCategory(object sender, EventArgs e)
        {
            if (!isNew)
            {
                CategoryListForm catList = new CategoryListForm(year.clubID, year.year);
                catList.Visible = true;
            }
        }

        #endregion

    }
}
