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
using System.Windows.Forms;

namespace TrotTrax
{
    class ShowYear : ListObject
    {
        public string club { get; private set; }
        public List<string> clubs;
        public List<string> years;

        public ShowYear()
        {
            database = new DBDriver(1);

            year = database.GetValueInt("trax_data", "current", "year", String.Empty);
            clubID = database.GetValueString("trax_data", "current", "id", String.Empty);
            club = database.GetValueString("trax_data", "club", "name", "id = '" + clubID + "'");
            showList = database.GetShowItemList(clubID, year, "date");
            classList = database.GetClassItemList(clubID, year, String.Empty);
            backNoList = database.GetBackNoItemList(clubID, year, String.Empty);
            clubs = database.GetValueList("trax_data", "club", "name", String.Empty);
            years = database.GetValueList(clubID, "show_year", "year", String.Empty);
        }
    }
}
