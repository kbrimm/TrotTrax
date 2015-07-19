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
            string club = null;
            DBDriver db = new DBDriver();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check for an existing club
            club = db.CheckCurrentClub();
            while (club == null)
            {
                Application.Run(new NewClubForm());
                club = db.CheckCurrentClub();
            }           
        }
    }
}
