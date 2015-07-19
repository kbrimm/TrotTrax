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
    public partial class NewClubForm : Form
    {
        private DBDriver database;
        
        public NewClubForm()
        {
            database = new DBDriver(1);
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            string name = this.nameField.Text;
            DialogResult confirm = MessageBox.Show("Is \"" + name + "\" correct?", "Club Name Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
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

        private string FormatString(string stringIn)
        {
            string newString = String.Empty;

            foreach (char c in stringIn)
            {
                if (c == '\'')
                    newString += '’';
                else
                    newString += c;
            }
            return newString;
        }
    }
}
