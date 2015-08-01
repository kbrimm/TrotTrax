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
        public List<ShowItem> showList;
        public List<ClassItem> classList;
        public List<BackNoItem> numberList;
        public List<string> clubs;
        public List<string> years;

        public ShowYear()
        {
            showList = new List<ShowItem>();
            classList = new List<ClassItem>();
            numberList = new List<BackNoItem>();
            database = new DBDriver(1);

            year = database.GetValueInt("trax_data", "current", "year", String.Empty);
            clubID = database.GetValueString("trax_data", "current", "id", String.Empty);
            club = database.GetValueString("trax_data", "club", "name", "id = '" + clubID + "'");
            showList = database.GetShowItemList(clubID, year);
            classList = database.GetClassItemList(clubID, year);
            numberList = database.GetBackNoItemList(clubID, year);
            clubs = database.GetValueList("trax_data", "club", "name");
            years = database.GetValueList(clubID, "show_year", "year");
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
        public int no;
        public string rider;
        public string horse;

        public override string ToString()
        {
            string noString = no.ToString() + ".";
            return noString.PadRight(6) + rider.PadRight(30) + "   " + horse;
        }
    }
}
