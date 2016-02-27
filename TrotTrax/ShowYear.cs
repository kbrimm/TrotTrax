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

            CastYearData();
            clubName = database.GetCurrentClubName();

            clubList = database.GetClubItemList();
            yearList = database.GetYearItemList();

            backNoList = database.GetBackNoItemList(clubID, year, String.Empty);
            classList = database.GetClassItemList(clubID, year, String.Empty);
            showList = database.GetShowItemList(clubID, year, String.Empty);
        }

        public bool SetClub(string clubID)
        {
            // Assigns new data to trot_trax.current
            // Uses latest year for clubID
            int setYear = database.GetLatestYear(clubID);

            if (setYear > 0)
            {
                database.SetClub(clubID);
                database.SetYear(setYear);
                return true;
            }
            else
                return false;
        }

        public void SetYear(int setYear)
        {
            database.SetYear(setYear);
        }

        private void CastYearData()
        {
            int? tryYear = database.GetValueInt("trot_trax", "current", "current_year", String.Empty);
            if (tryYear.HasValue)
                year = tryYear.Value;
        }
    }
}
