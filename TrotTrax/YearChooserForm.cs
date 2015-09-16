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
    public partial class YearChooserForm : Form
    {
        DBDriver database;
        string clubID;

        public YearChooserForm()
        {
            database = new DBDriver(1);
            clubID = database.GetValueString("trot_trax", "current", "club_id", String.Empty);
            InitializeComponent();
        }

        private void OkayBtn(object sender, EventArgs e)
        {
            string date = this.yearPicker.Value.ToShortDateString();
            int year = FormatYearString(date);
            if (CheckYear(clubID, year))
            {
                DialogResult confirm = MessageBox.Show(year + " already exists for this club. Do you wish to erase it and start over?",
                    "TrotTrax Create Year Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                    database.CreateYear(clubID, year);
                else
                    database.SetYear(year);
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Create a new show year for " + year + "?",
                    "TrotTrax Create Year Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                    database.CreateYear(clubID, year);
            }
            Close();
        }

        private void KeyStroke(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OkayBtn(sender, e);
            }
        }

        private void CancelBtn(object sender, EventArgs e)
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

        private bool CheckYear(string id, int year)
        {
            int? yearCount = database.CountValue(id, "show_year", "year", "year = " + year);
            if (yearCount.HasValue && yearCount > 0)
                return true;
            else
                return false;
        }
    }
}
