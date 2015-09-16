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
    public partial class ClubChooserForm : Form
    {
        private DBDriver database;
        
        public ClubChooserForm()
        {
            database = new DBDriver(1);
            InitializeComponent();
        }

        private void OkayBtn(object sender, EventArgs e)
        {
            string name = this.nameField.Text;
            if (name.Length > 255)
            {
                MessageBox.Show("The club name is too long. Please enter a name less than 255 characters.",
                    "TrotTrax Alert", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Is \"" + name + "\" correct?",
                    "TrotTrax Club Name Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    string id = GetID(name);
                    if (CheckClubName(id))
                    {
                        confirm = MessageBox.Show("The club \"" + name + "\" already exists. Do you wish to erase it and start over?",
                            "TrotTrax Club Name Confirmation", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            database.CreateClub(id, name);
                            YearChooserForm yearForm = new YearChooserForm();
                            yearForm.FormClosing += new FormClosingEventHandler(this.CloseOnClose);
                            yearForm.Visible = true;
                            this.Visible = false;
                        }
                    }
                    else
                    {
                        database.CreateClub(id, name);
                        YearChooserForm yearForm = new YearChooserForm();
                        yearForm.FormClosing += new FormClosingEventHandler(this.CloseOnClose);
                        yearForm.Visible = true;
                        this.Visible = false;
                    }
                }
            }
        }

        private void KeyStroke(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OkayBtn(sender, e);
            }
        }

        private void CloseOnClose(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void CancelBtn(object sender, EventArgs e)
        {
            Close();
        }

        // Formats club id from name.
        private string GetID(string name)
        {
            string id = String.Empty;
            int len = name.Length;
            id += name[0];
            for (int i = 0; i < len - 1; i++)
            {
                if (name[i] == (' '))
                {
                    id += name[i + 1];
                    i++;
                }
            }

            if (id.Length > 10)
                id = id.Substring(0, 10);

            return id.ToLower();
        }

        private bool CheckClubName(string id)
        {
            int? clubCount = database.CountValue("trot_trax", "club", "club_id", "club_id = '" + id + "'");
            if (clubCount.HasValue && clubCount > 0)
                return true;
            else
                return false;
        }
    }
}
