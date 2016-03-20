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
        private ShowYear Year;
        private bool IsNew;

        #region Constructors 

        // No arguments opens an blank show year panel.
        public ShowYearForm()
        {
            InitializeComponent(); 
            ActiveButtons();
            IsNew = true;
        }

        // Passing an integer value indicates that there is data in trot_trax.current
        public ShowYearForm(int hasData)
        {
            Year = new ShowYear();
            InitializeComponent();
            ActiveButtons();
            PopulateClubMenu();
            PopulateYearMenu();
            PopulateShowList();
            PopulateClassList();
            PopulateBackNoList();

            this.currentLabel.Text = Year.ClubName + "\n\n" + Year.Year + " Show Year";
            IsNew = false;
        }

        #endregion

        #region Form Refresh

        private void RefreshForm()
        {
            Year = new ShowYear();
            ActiveButtons();
            PopulateClubMenu();
            PopulateYearMenu();
            PopulateShowList();
            PopulateClassList();
            PopulateBackNoList();

            this.currentLabel.Text = Year.ClubName + "\n\n" + Year.Year + " Show Year";
            IsNew = false;
        }

        private void ActiveButtons()
        {
            if(IsNew)
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
                addRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                addRiderBtn.ForeColor = System.Drawing.SystemColors.GrayText;                
                addHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                addHorseBtn.ForeColor = System.Drawing.SystemColors.GrayText;
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
            }

            // These buttons depend on the presence of particular data.
            viewShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewShowBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewClassBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewNumberBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewNumberBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewRiderBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            viewHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewHorseBtn.ForeColor = System.Drawing.SystemColors.GrayText;
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

            foreach (ClubItem clubItem in Year.ClubList)
            {
                ToolStripMenuItem clubMenuItem = new ToolStripMenuItem();
                clubMenuItem.Name = clubItem.ClubId + "MenuEntry";
                clubMenuItem.Size = new System.Drawing.Size(152, 22);
                clubMenuItem.Text = clubItem.ClubName;
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
            foreach(ClubItem club in Year.ClubList)
                if(club.ClubName == viewClub)
                {
                    if (Year.SetClub(club.ClubId))
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

            foreach (int yearItem in Year.YearList)
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
                Year.SetYear(viewYear);
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
            foreach (ShowItem entry in Year.ShowList)
            {
                string dateString = entry.Date.ToString("MM/dd/yyyy");
                string value;
                if(entry.Name == "")
                    value = dateString;
                else
                    value = dateString + " - " + entry.Name;
                showListBox.Items.Add(value);
            }

            if (Year.ShowList.Count() > 0)
            {
                viewShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewShowBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void NewShow(object sender, EventArgs e)
        {
            {
                if (!IsNew)
                {
                    ShowListForm showList = new ShowListForm(Year.ClubID, Year.Year);
                    showList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                    showList.Visible = true;
                }
            }
        }

        private void ViewShow(object sender, EventArgs e)
        {
            int showNo = -1;

            if (showListBox.SelectedItems.Count != 0 && !IsNew)
            {
                string selectedShow = showListBox.SelectedItems[0].ToString();
                selectedShow = selectedShow.Substring(15, 10);
                foreach (ShowItem entry in Year.ShowList)
                {
                    string dateString = entry.Date.ToString("MM/dd/yyyy");
                    if (dateString == selectedShow)
                    {
                        showNo = entry.No;
                        break;
                    }
                }
            }

            if (showNo >= 0)
            {
                ShowListForm showList = new ShowListForm(Year.ClubID, Year.Year, showNo);
                showList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                showList.Visible = true;
            }
        }

        #endregion

        #region Class List

        private void PopulateClassList()
        {
            classListBox.Items.Clear();
            foreach (ClassItem entry in Year.ClassList)
            {
                string[] row = { entry.Name };
                classListBox.Items.Add(entry.No.ToString()).SubItems.AddRange(row);
            }

            if(Year.ClassList.Count() > 0)
            {
                viewClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewClassBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void SortClassList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                Year.SortClasses(ClassSort.Number);
            else if (e.Column == 1)
                Year.SortClasses(ClassSort.Name);
            PopulateClassList();
        }

        private void NewClass(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                ClassListForm classList = new ClassListForm(Year.ClubID, Year.Year);
                classList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                classList.Visible = true;
            }
        }

        private void ViewClass(object sender, EventArgs e)
        {
            int classNo = -1;

            if (classListBox.SelectedItems.Count != 0 && !IsNew)
                classNo = Convert.ToInt32(classListBox.SelectedItems[0].Text);

            if (classNo >= 0)
            {
                ClassListForm classList = new ClassListForm(Year.ClubID, Year.Year, classNo);
                classList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                classList.Visible = true;
            }
        }

        #endregion

        #region Back Number List

        private void PopulateBackNoList()
        {
            backNoListBox.Items.Clear();
            foreach (BackNoItem entry in Year.BackNoList)
            {
                string[] row = { entry.RiderNo.ToString(), entry.RiderLast + ", " + entry.RiderFirst, entry.HorseNo.ToString(), entry.Horse };
                backNoListBox.Items.Add(entry.No.ToString()).SubItems.AddRange(row);
            }

            if (Year.BackNoList.Count() > 0)
            {
                viewNumberBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewNumberBtn.ForeColor = System.Drawing.SystemColors.ControlText;
                viewRiderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewRiderBtn.ForeColor = System.Drawing.SystemColors.ControlText;
                viewHorseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                viewHorseBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void SortBackNoList(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                Year.SortBackNos(BackNoSort.Number);
            else if (e.Column == 2)
                Year.SortBackNos(BackNoSort.RiderLast);
            else if (e.Column == 4)
                Year.SortBackNos(BackNoSort.Horse);
            PopulateBackNoList();
        }

        private void NewBackNo(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                BackNoListForm backNoList = new BackNoListForm(Year.ClubID, Year.Year);
                backNoList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                backNoList.Visible = true;
            }
        }

        private void ViewBackNo(object sender, EventArgs e)
        {
            if (backNoListBox.SelectedItems.Count != 0)
            {
                int backNo = -1;

                backNo = Convert.ToInt32(backNoListBox.SelectedItems[0].Text);
                if (backNo >= 0)
                {
                    BackNoListForm backNoList = new BackNoListForm(Year.ClubID, Year.Year, backNo);
                    backNoList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                    backNoList.Visible = true;
                }
            }
        }

        private void NewRider(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                RiderListForm riderList = new RiderListForm(Year.ClubID, Year.Year);
                riderList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                riderList.Visible = true;
            }
        }

        private void ViewRider(object sender, EventArgs e)
        {
            if (backNoListBox.SelectedItems.Count != 0)
            {
                int riderNo = -1;

                riderNo = Convert.ToInt32(backNoListBox.SelectedItems[0].SubItems[1].Text);
                if (riderNo >= 0)
                {
                    RiderListForm riderList = new RiderListForm (Year.ClubID, Year.Year, riderNo);
                    riderList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                    riderList.Visible = true;
                }
            }
        }

        private void NewHorse(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                HorseListForm horseList = new HorseListForm(Year.ClubID, Year.Year);
                horseList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                horseList.Visible = true;
            }
        }

        // If horse is selected, refreshes to existing horse form.
        private void ViewHorse(object sender, EventArgs e)
        {
            if (backNoListBox.SelectedItems.Count != 0)
            {
                int horseNo = -1;

                horseNo = Convert.ToInt32(backNoListBox.SelectedItems[0].SubItems[3].Text);
                if (horseNo >= 0)
                {
                    HorseListForm horseList = new HorseListForm(Year.ClubID, Year.Year, horseNo);
                    horseList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                    horseList.Visible = true;
                }
            }
        }

        #endregion

        // Reports Menu

        #region Settings Menu

        private void NewCategory(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                CategoryListForm catList = new CategoryListForm(Year.ClubID, Year.Year);
                catList.FormClosing += new FormClosingEventHandler(this.RefreshOnClose);
                catList.Visible = true;
            }
        }

        #endregion

    }
}
