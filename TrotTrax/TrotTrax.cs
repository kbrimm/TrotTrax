/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
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
            // Startup process: Check DB, create trot_trax.trax if necessary.
            // Check for existence of initial tables.
            DBDriver database = new DBDriver();
            if (database.Connected)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Check for an existing club
                if (database.HasCurrent())
                    Application.Run(new ShowYearForm(1));
                else
                    Application.Run(new ShowYearForm());
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
