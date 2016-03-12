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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrotTrax
{
    class ShowYear : ListObject
    {
        public string clubName { get; private set; }
        public List<ClubItem> clubList;
        public List<int> yearList;

        public ShowYear()
        {
            database = new DBDriver(1);

            year = database.GetCurrentYear();
            clubName = database.GetCurrentClubName();

            clubList = database.GetClubItemList();
            yearList = database.GetYearItemList();

            backNoList = database.GetBackNoItemList();
            classList = database.GetClassItemList();
            showList = database.GetShowItemList();
        }

        public bool SetClub(string clubID)
        {
            return database.SetCurrentClub(clubID);
        }

        public void SetYear(int setYear)
        {
            database.SetCurrentYear(setYear);
        }
    }
}
