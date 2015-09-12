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
        public List<int> years;

        public ShowYear()
        {
            database = new DBDriver(1);

            SetYearData();
            showList = database.GetShowItemList(clubID, year, String.Empty);
            classList = database.GetClassItemList(clubID, year, String.Empty);
            backNoList = database.GetBackNoItemList(clubID, year, String.Empty);
            clubs = database.GetStringList("trot_trax", "club", "name", String.Empty);
            years = database.GetIntList(clubID, "show_year", "year", String.Empty);
        }

        private void SetYearData()
        {
            YearItem item = database.GetYearItem();
            year = item.year;
            clubID = item.id;
            club = item.name;
        }
    }
}
