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
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    class ShowYear
    {
        private DBDriver dataBase;
        private int year { get; set; }
        private string club { get; set; }
        private string clubID { get; set; }
        private List<string> showList;
        private List<string> classList;
        private List<string> numberList;

        ShowYear(int year, string club, string clubID)
        {
            dataBase = new DBDriver(1);

         //   year = dataBase.GetValue("trot_trax_data", "current", "string");
        }
    }
}
