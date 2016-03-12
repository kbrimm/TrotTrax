﻿/* 
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
    public partial class RiderListForm : Form
    {
        Rider rider;
        bool isNew;
        bool isChanged;

        // New rider
        public RiderListForm(string clubID, int year)
        {
            rider = new Rider(clubID, year);
            InitializeComponent();
            PopulateRiderList();
            PopulateHorseList();
            isNew = true;
            isChanged = false;
        }

        // Existing rider
        public RiderListForm(string clubID, int year, int riderNo)
        {
            rider = new Rider(clubID, year, riderNo);
            InitializeComponent();
            numberBox.Text = rider.number.ToString();
            firstNameBox.Text = rider.firstName;
            lastNameBox.Text = rider.lastName;
            phoneBox.Text = rider.phone;

            this.Text = rider.firstName + " " + rider.lastName + " Detail - TrotTrax";

            PopulateRiderList();
            PopulateHorseList();
            PopulateClassEntryList();
            isNew = false;
            isChanged = false;
        }

        private void RefreshForm(string clubID, int year)
        {
            rider = new Rider(clubID, year);
            PopulateRiderList();
            PopulateHorseList();
            isNew = true;
            isChanged = false;
        }

        private void RefreshForm(string clubID, int year, int riderNo)
        {

        }

        private void DataChanged(object sender, EventArgs e)
        {
            isChanged = true;
            cancelBtn.Text = "Cancel";
            modifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            modifyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private bool AbandonChanges()
        {
            if (isChanged)
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

        private void PopulateRiderList()
        {
            riderListBox.Items.Clear();
            foreach (RiderItem entry in rider.riderList)
            {
                string[] row = { entry.firstName, entry.lastName };
                riderListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateHorseList()
        {
            horseListBox.Items.Clear();
            foreach (HorseItem entry in rider.horseList)
            {
                string[] row = { entry.name };
                horseListBox.Items.Add(entry.no.ToString()).SubItems.AddRange(row);
            }
        }

        private void PopulateClassEntryList()
        {
            classEntryListBox.Items.Clear();
            foreach (ResultItem entry in rider.resultList)
            {
               // string[] row = { entry.horseName, entry.showDate, entry.className, entry.place.ToString() };
               // classEntryListBox.Items.Add(entry.backNo.ToString()).SubItems.AddRange(row);
            }
        }



        private void NewRiderAction(object sender, EventArgs e)
        {
            bool leaveForm = true;

            if (isChanged)
                leaveForm = AbandonChanges();
            if (leaveForm)
            {
                RiderListForm riderForm = new RiderListForm(rider.clubID, rider.year);
                riderForm.Visible = true;
                this.Close();
            }
        }

        private void LoadRiderAction(object sender, EventArgs e)
        {
            bool leaveForm = true;

            if (isChanged)
                leaveForm = AbandonChanges();
            if (leaveForm && riderListBox.SelectedItems.Count != 0)
            {
                int newRiderNo = Convert.ToInt32(riderListBox.SelectedItems[0].Text);
                RiderListForm riderForm = new RiderListForm(rider.clubID, rider.year, newRiderNo);
                riderForm.Visible = true;
                this.Close();
            }
        }
    }
}
