/* 
 * TrotTrax
 *     Copyright (c) 2015-2016 Katy Brimm
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
    public partial class ResultListForm : Form
    {
        private Result ActiveResults;
        private List<ResultItem> EntryList = new List<ResultItem>();
        private bool IsChanged;
        private bool IsFirst;
        private bool IsLast;

        #region Constructors
        // This form is only ever opened with an existing class/show.
        public ResultListForm(string clubID, int year, int showNo, int classNo)
        {
            ActiveResults = new Result(clubID, year, showNo, classNo);
            InitializeComponent();
            SetData();
        }

        private void SetData()
        {
            PopulateEntryList();
            PopulateClassList();
            PopulateBackNoBox();
            this.Text = ActiveResults.ShowDate + " " + ActiveResults.ClassName + " - TrotTrax";
            this.infoLabel.Text = ActiveResults.ShowDate + "\n" + ActiveResults.ClassNo 
                + ". " + ActiveResults.ClassName;
            this.totalBox.Text = ActiveResults.EntryCount.ToString();

            // Assign placings button is disabled until changes are made.
            this.placeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, 
                System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeBtn.ForeColor = System.Drawing.SystemColors.GrayText;

            // Determine position in list
            IsFirst = ActiveResults.IsFirstClass();
            IsLast = ActiveResults.IsLastClass();
            if (IsFirst)
            {
                prevBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, 
                    System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                prevBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            if (IsLast)
            {
                nextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, 
                    System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                nextBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }

            IsChanged = false;
        }

        #endregion

        #region Refresh Form

        private void RefreshForm(string clubID, int year, int showNo, int classNo)
        {
            ActiveResults = new Result(clubID, year, showNo, classNo);
            SetData();
        }

        private void RefreshOnClose(object sender, FormClosingEventArgs e)
        {
            if (AbandonChanges())
            {
                RefreshForm(ActiveResults.ClubID, ActiveResults.Year, ActiveResults.ShowNo, 
                    ActiveResults.ClassNo);
            }
            else
            {
                PopulateEntryList();
                PopulateClassList();
                PopulateBackNoBox();
            }
        }

        #endregion

        #region Form Changes

        // When changes are made, activates relevant buttons.
        private void DataChanged(object sender, EventArgs e)
        {
            this.placeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, 
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            IsChanged = true;
        }

        // On form close, prompt to abandon unsaved changes.
        private bool AbandonChanges()
        {
            if (IsChanged)
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

        #region Result Data



        #endregion

        #region Class List

        private void PopulateClassList()
        {
            classListBox.Items.Clear();
            foreach (ClassItem entry in ActiveResults.ClassList)
            {
                string[] row = { entry.Name, };
                classListBox.Items.Add(entry.No.ToString()).SubItems.AddRange(row);
            }
        }

        #endregion

        #region Back Number List

        private void PopulateEntryList()
        {
            entryListBox.Items.Clear();
            foreach (ResultItem entry in ActiveResults.EntryList)
            {
                string[] row = { entry.RiderLast + ", " + entry.RiderFirst, entry.Horse };
                entryListBox.Items.Add(entry.BackNo.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateBackNoBox()
        {
            //entryBoxItemList.Add(new EntryBoxItem() { no = 0, combo = String.Empty });
            foreach (BackNoItem entry in ActiveResults.BackNoList)
            {
                // entryBoxItemList.Add(new EntryBoxItem() { no = entry.no, 
                //     combo = entry.no + " - " + entry.rider +  " - " + entry.horse});
            }

            // this.entryBox.DataSource = entryBoxItemList;
            // this.entryBox.DisplayMember = "combo";
            // this.entryBox.ValueMember = "no";
        }

        #endregion

        private void entryListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
            if (e.Column == 0)
                ActiveResults.SortEntries("b.back_no");
            else if (e.Column == 1)
                ActiveResults.SortEntries("r.last_name");
            else if (e.Column == 2)
                ActiveResults.SortEntries("h.name");
            PopulateEntryList();
        }

        private void classListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                ActiveResults.SortClasses(ClassSort.Number);
            else if (e.Column == 1)
                ActiveResults.SortClasses(ClassSort.Name);
            PopulateClassList();
        }

        private void manualBtn_Click(object sender, EventArgs e)
        {
            string noString = this.manualBox.Text.ToString();
            int backNo = 0;
            DialogResult confirm;

            if (noString == String.Empty || !int.TryParse(noString, out backNo))
            {
                confirm = MessageBox.Show("Please enter an integer value.",
                    "TrotTrax Alert", MessageBoxButtons.OK);
            }
            if (backNo > 0)
            {
                bool success = ActiveResults.AddEntry(backNo);
                if (success)
                {
                    totalBox.Text = ActiveResults.EntryCount.ToString();
                    manualBox.Text = String.Empty;
                    PopulateEntryList();
                }
                else
                {
                    confirm = MessageBox.Show("Back number not found.",
                        "TrotTrax Alert", MessageBoxButtons.OK);
                }
            }
        }

        private void removeEntryBtn_Click(object sender, EventArgs e)
        {
            if (entryListBox.SelectedItems.Count != 0)
            {
                int backNo = Convert.ToInt32(entryListBox.SelectedItems[0].Text);
                DialogResult confirm = MessageBox.Show("Do you want to remove back number " 
                    + backNo + " from this class?",
                    "TrotTrax Alert", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    ActiveResults.RemoveEntry(backNo);
                    totalBox.Text = ActiveResults.EntryCount.ToString();
                    PopulateEntryList();
                }
            }
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
            int backNo = Convert.ToInt32(this.backNoComboBox.SelectedValue);
            if (backNo > 0)
            {
                bool success = ActiveResults.AddEntry(backNo);
                if (success)
                {
                    totalBox.Text = ActiveResults.EntryCount.ToString();
                    manualBox.Text = String.Empty;
                    PopulateEntryList();
                    backNoComboBox.SelectedIndex = 0;
                }
                else
                {
                    DialogResult confirm = MessageBox.Show("Something went wrong.",
                    "TrotTrax Alert", MessageBoxButtons.OK);
                }
            }
        }

        private void viewClassBtn_Click(object sender, EventArgs e)
        {
            if (classListBox.SelectedItems.Count != 0)
            {
                bool loadNew = true;
                int classNo = -1;

                if (IsChanged)
                    loadNew = AbandonChanges();
                if (loadNew)
                    classNo = Convert.ToInt32(classListBox.SelectedItems[0].Text);

                if (classNo >= 0)
                {
                    ResultListForm classInstance = new ResultListForm(ActiveResults.ClubID,
                        ActiveResults.Year, ActiveResults.ShowNo, classNo);
                    classInstance.Visible = true;
                    this.Close();
                }
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if(!IsFirst)
            {
                bool loadNew = true;
                
                if (IsChanged)
                    loadNew = AbandonChanges();
                if (loadNew)
                {
                    ResultListForm classInstance = new ResultListForm(ActiveResults.ClubID, 
                        ActiveResults.Year, ActiveResults.ShowNo, ActiveResults.GetPrev());
                    classInstance.Visible = true;
                    this.Close();
                }
            }   
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (!IsLast)
            {
                bool loadNew = true;

                if (IsChanged)
                    loadNew = AbandonChanges();
                if (loadNew)
                {
                    ResultListForm classInstance = new ResultListForm(ActiveResults.ClubID, 
                        ActiveResults.Year, ActiveResults.ShowNo, ActiveResults.GetNext());
                    classInstance.Visible = true;
                    this.Close();
                }
            }  
        }
    }
}
