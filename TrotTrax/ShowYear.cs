/* 
 * TrotTrax
 *     Copyright (c) 2015-2016 Katy Brimm
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
        public string ClubName { get; private set; }
        public List<ClubItem> ClubList;
        public List<int> YearList;

        public ShowYear()
        {
            Database = new DBDriver(1);

            Year = Database.GetCurrentYear();
            ClubName = Database.GetCurrentClubName();

            ClubList = Database.GetClubItemList();
            YearList = Database.GetYearItemList();

            BackNoList = Database.GetBackNoItemList();
            ClassList = Database.GetClassItemList();
            ShowList = Database.GetShowItemList();
        }

        public bool SetClub(string clubID)
        {
            return Database.SetCurrentClub(clubID);
        }

        public void SetYear(int setYear)
        {
            Database.SetCurrentYear(setYear);
        }
    }
}
