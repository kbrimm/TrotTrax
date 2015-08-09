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
    class Show : ListObject
    {
        public int number { get; private set; }
        public string date { get; private set; }
        public string description { get; private set; }
        public string comments { get; private set; }

        public Show(string clubID, int year)
        {
            database = new DBDriver(1);
            this.year = year;
            this.clubID = clubID;

            classList = database.GetClassItemList(clubID, year, String.Empty);
            showList = database.GetShowItemList(clubID, year, "date");
        }

        public Show(string clubID, int year, int showNo)
        {
            database = new DBDriver(1);
            classList = new List<ClassItem>();
            showList = new List<ShowItem>();
            this.year = year;
            this.clubID = clubID;
            number = showNo;

            classList = database.GetClassItemList(clubID, year, String.Empty);
            showList = database.GetShowItemList(clubID, year, "date");
            date = database.GetValueString(clubID, year + "_show_list", "date", "show_no = " + showNo);
            description = database.GetValueString(clubID, year + "_show_list", "description", "show_no = " + showNo);
            comments = database.GetValueString(clubID, year + "_show_list", "comment", "show_no = " + showNo);
        }

        public bool AddShow(DateTime date, string description, string comments)
        {
            string dateString = date.ToString("MM/dd/yyyy");
            string target = "date, description, comment";
            string values = "'" + dateString + "', '" + database.FormatString(description) +
                "', '" + database.FormatString(comments) + "'";
            bool success = database.AddValues(clubID, year + "_show_list", target, values);
            if (success)
            {
                string no = database.GetValueString(clubID, year + "_show_list", "show_no", "date = '" + dateString + "'");
                number = Convert.ToInt32(no);
                showList = database.GetShowItemList(clubID, year, "date");
            }
            return success;
        }

        public bool ModifyShow(DateTime date, string description, string comments)
        {
            string dateString = date.ToString("MM/dd/yyyy");
            string values = "date = '" + dateString + "', description = '" + database.FormatString(description) + 
                "', comment = '" + database.FormatString(comments) + "'";
            string qualifier = "show_no = " + number;
            bool success = database.ChangeValues(clubID, year + "_show_list", values, qualifier);
            if(success)
            {
                showList = database.GetShowItemList(clubID, year, "date");
            }
            return success;
        }

        public bool RemoveShow()
        {
            string qualifier = "show_no = " + number;
            bool success = database.DeleteValues(clubID, year + "_show_list", qualifier);
            if (success)
            {
                showList = database.GetShowItemList(clubID, year, "date");
            }
            return success;
        }
    }
}
