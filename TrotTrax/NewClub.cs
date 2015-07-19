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
    public partial class NewClub : Form
    {
        private DBDriver database;

        public NewClub()
        {
            database = new DBDriver(1);
            InitializeComponent();
            Application.Run();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            string name = this.NameField.Text;
            DialogResult confirm = MessageBox.Show("Is " + name + " correct?", "Club Name Confirmation", MessageBoxButtons.YesNo);
            if(confirm ==DialogResult.Yes)
            {
                string id = GetID(name);
                database.CreateClub(id, FormatString(name));
           } 
        }

        // Formats club id from name.
        private string GetID(string name)
        {
            string id = String.Empty;
            int len = name.Length;
            id += name[0];
            for(int i = 0; i < len-1; i++)
            {
                if(name[i].Equals(" "))
                {
                    id += name[i + 1];
                    i++;
                }
            }

            if(id.Length > 10)
                id = id.Substring(0, 10);

            return id.ToLower();
        }

        private string FormatString(string stringIn)
        {
            string newString = String.Empty;

            foreach(char c in newString)
            {
                if (c.Equals(@"\") || c.Equals("'") || c.Equals('"'))
                    newString += @"\";
                newString += c;
            }
            return newString;
        }
    }
}
