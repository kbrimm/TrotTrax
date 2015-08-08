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
    class ShowYear
    {
        private DBDriver database;
        public int year { get; private set; }
        public string club { get; private set; }
        public string clubID { get; private set; }
        public List<ShowItem> showList = new List<ShowItem>();
        public List<ClassItem> classList = new List<ClassItem>();
        public List<BackNoItem> backNoList = new List<BackNoItem>();
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

        public void SortBackNos(string field)
        {
            backNoList = database.GetBackNoItemList(clubID, year, field);
        }

        public void SortClasses(string field)
        {
            classList = database.GetClassItemList(clubID, year, field);
        }
    }
    
    struct ShowItem
    {
        public int no;
        public string date;
        public string description;

        public override string ToString()
        {
            string noString = no.ToString() + ".";
            return noString.PadRight(6) + date + "   " + description;
        }
    }

    struct ClassItem
    {
        public int no;
        public string name;

        public override string ToString()
        {
            string noString = no.ToString() + ".";
            return noString.PadRight(6) + name;
        }
    }

    struct BackNoItem
    {
        public int no { get; set; }
        public string rider { get; set; }
        public string horse { get; set; }

        public override string ToString()
        {
            string noString = no.ToString() + ".";
            return noString.PadRight(6) + rider.PadRight(30) + "   " + horse;
        }
    }
}
