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
        private List<EntryBoxItem> entryBoxItemList = new List<EntryBoxItem>();
        bool isModified;

        public ClassInstanceForm(string clubID, int year, int showNo, int classNo)
        {
            aClass = new ClassInstance(clubID, year, showNo, classNo);
            InitializeComponent();
            this.Text = aClass.showDate + " " + aClass.className + " - TrotTrax";
            showLabel.Text = aClass.showDate + "\r\n" + aClass.className;
            PopulateEntryList();
            PopulateClassList();
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
            foreach (BackNoItem entry in aClass.entryList)
            {
                entryBoxItemList.Add(new EntryBoxItem() { no = entry.no, 
                    combo = entry.no + " - " + entry.rider +  " - " + entry.horse});
            }

            this.entryBox.DataSource = entryBoxItemList;
            this.entryBox.DisplayMember = "combo";
            this.entryBox.ValueMember = "no";
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
            int number;
            if (noString == String.Empty || !int.TryParse(noString, out number))
            {
                DialogResult confirm = MessageBox.Show("Please enter an integer value.",
                    "TrotTrax Alert", MessageBoxButtons.OK);

                bool success = aClass.AddEntry(number);
                if (success)
                    PopulateEntryList();
                else
                {
                    confirm = MessageBox.Show("Back number not found.",
                    "TrotTrax Alert", MessageBoxButtons.OK);
                }
            }
        }
    }
}
