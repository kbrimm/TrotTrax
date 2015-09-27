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
    public partial class ClassInstanceForm : Form
    {
        ClassInstance aClass;
       // private List<EntryBoxItem> entryBoxItemList = new List<EntryBoxItem>();
        bool isChanged;
        bool isFirst;
        bool isLast;

        public ClassInstanceForm(string clubID, int year, int showNo, int classNo)
        {
            aClass = new ClassInstance(clubID, year, showNo, classNo);
            InitializeComponent();
            this.Text = aClass.showDate + " " + aClass.className + " - TrotTrax";
            showLabel.Text = aClass.showDate + "\n" + classNo + ". " + aClass.className;
            totalBox.Text = aClass.entryCount.ToString();
            PopulateEntryList();
            PopulateClassList();
            PopulateListBox();
            isChanged = false;
            isFirst = aClass.IsFirstClass();
            isLast = aClass.IsLastClass();
            if(isFirst)
            {
                prevBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                prevBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
            if(isLast)
            {
                nextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                nextBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void PopulateClassList()
        {
            classListBox.Items.Clear();
            foreach (ClassItem entry in aClass.classList)
            {
                string[] row = { entry.name, };
                classListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateEntryList()
        {
            entryListBox.Items.Clear();
            foreach (BackNoItem entry in aClass.entryList)
            {
                string[] row = { entry.rider, entry.horse };
                entryListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateListBox()
        {
            //entryBoxItemList.Add(new EntryBoxItem() { no = 0, combo = String.Empty });
            foreach (BackNoItem entry in aClass.backNoList)
            {
               // entryBoxItemList.Add(new EntryBoxItem() { no = entry.no, 
               //     combo = entry.no + " - " + entry.rider +  " - " + entry.horse});
            }

           // this.entryBox.DataSource = entryBoxItemList;
           // this.entryBox.DisplayMember = "combo";
           // this.entryBox.ValueMember = "no";
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

        private void entryListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
            if (e.Column == 0)
                aClass.SortEntries("b.back_no");
            else if (e.Column == 1)
                aClass.SortEntries("r.last_name");
            else if (e.Column == 2)
                aClass.SortEntries("h.name");
            PopulateEntryList();
        }

        private void classListBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                aClass.SortClasses("class_no");
            else if (e.Column == 1)
                aClass.SortClasses("name");
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
                bool success = aClass.AddEntry(backNo);
                if (success)
                {
                    totalBox.Text = aClass.entryCount.ToString();
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
                DialogResult confirm = MessageBox.Show("Do you want to remove back number " + backNo + " from this class?",
                    "TrotTrax Alert", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    aClass.RemoveEntry(backNo);
                    totalBox.Text = aClass.entryCount.ToString();
                    PopulateEntryList();
                }
            }
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
            int backNo = Convert.ToInt32(this.entryBox.SelectedValue);
            if (backNo > 0)
            {
                bool success = aClass.AddEntry(backNo);
                if (success)
                {
                    totalBox.Text = aClass.entryCount.ToString();
                    manualBox.Text = String.Empty;
                    PopulateEntryList();
                    entryBox.SelectedIndex = 0;
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

                if (isChanged)
                    loadNew = AbandonChanges();
                if (loadNew)
                    classNo = Convert.ToInt32(classListBox.SelectedItems[0].Text);

                if (classNo >= 0)
                {
                    ClassInstanceForm classInstance = new ClassInstanceForm(aClass.clubID, aClass.year, aClass.showNo, classNo);
                    classInstance.Visible = true;
                    this.Close();
                }
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if(!isFirst)
            {
                bool loadNew = true;
                
                if (isChanged)
                    loadNew = AbandonChanges();
                if (loadNew)
                {
                    ClassInstanceForm classInstance = new ClassInstanceForm(aClass.clubID, aClass.year, aClass.showNo, aClass.GetPrev());
                    classInstance.Visible = true;
                    this.Close();
                }
            }   
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (!isLast)
            {
                bool loadNew = true;

                if (isChanged)
                    loadNew = AbandonChanges();
                if (loadNew)
                {
                    ClassInstanceForm classInstance = new ClassInstanceForm(aClass.clubID, aClass.year, aClass.showNo, aClass.GetNext());
                    classInstance.Visible = true;
                    this.Close();
                }
            }  
        }
    }
}
