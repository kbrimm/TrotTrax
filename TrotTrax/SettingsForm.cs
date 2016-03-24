using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrotTrax
{
    public partial class SettingsForm : Form
    {
        private Settings ActiveSettings;

        public SettingsForm(string clubId, int year)
        {
            ActiveSettings = new Settings(clubId, year);
            InitializeComponent();
        }

        private void LoadSettings()
        {

        }

        private void SaveSettings()
        {

        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculateColumns(object sender, EventArgs e)
        {
            int places = -1;
            if(Int32.TryParse(placingCountTextBox.Text, out places) && places > 0)
            {

            }
        }
    }
}
