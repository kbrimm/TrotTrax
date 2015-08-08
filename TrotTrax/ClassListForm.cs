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
            showLabel.Text = aClass.name + "\r\nClass Setup";
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
    }
}
