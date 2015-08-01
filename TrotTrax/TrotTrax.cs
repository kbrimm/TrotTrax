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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check for an existing club
            CheckClub(database);

            Application.Run(new ShowYearForm());
            return;
        }

        private static void CheckClub(DBDriver database)
        {
            bool exists = false;
            int count;

            while(!exists)
            {
                count = database.CountValue("trax_data", "current", "id");
                if (count == 0)
                    Application.Run(new ClubChooserForm());
                else
                    exists = true;
            }
            exists = false;
            while(!exists)
            {
                count = database.CountValue("trax_data", "current", "year");
                if (count == 0)
                    Application.Run(new YearChooserForm());
                else
                    exists = true;
            }
        }
    }
}
