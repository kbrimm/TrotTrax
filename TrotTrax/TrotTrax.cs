/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrotTrax
{
    static class TrotTrax
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBDriver database = new DBDriver();
            if (database.connected)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Check for an existing club
                int? count = database.CountValue("trax_data", "current", "id", String.Empty);

                if (count.HasValue && count == 0)
                    Application.Run(new ShowYearForm());
                else
                    Application.Run(new ShowYearForm(1));
                return;
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Fatal error: Unable to contact database.",
                    "TrotTrax Alert", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
