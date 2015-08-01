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
    public partial class YearChooserForm : Form
    {
        DBDriver database;
        string clubID;

        public YearChooserForm()
        {
            database = new DBDriver(1);
            clubID = database.GetValueString("trax_data", "current", "id", String.Empty);
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            string date = this.yearPicker.Value.ToShortDateString();
            int year = FormatYearString(date);
            bool yearExists = database.CheckValue(clubID, "show_year", "year", year);
            if (yearExists)
                database.SetYear(year);
            else
            {
                DialogResult confirm = MessageBox.Show("Create a new show year for " + year + "?",
                    "TrotTrax Create Year Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                    database.CreateYear(clubID, year);
            }
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int FormatYearString(string date)
        {
            int year;
            int len = date.Length;

            year = Convert.ToInt32(date.Substring(len - 4, 4));
            return year;
        }
    }
}
