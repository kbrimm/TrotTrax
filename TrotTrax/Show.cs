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

namespace TrotTrax
{
    class Show : ListObject
    {
        public int number { get; private set; }
        public string date { get; private set; }
        public string name { get; private set; }
        public string comments { get; private set; }

        public Show(string clubID, int year)
        {
            database = new DBDriver(1);
            this.year = year;
            this.clubID = clubID;
            classList = database.GetClassItemList(clubID, year, String.Empty);
            showList = database.GetShowItemList(clubID, year, "date");
        }

        public Show(string clubID, int year, int number)
        {
            database = new DBDriver(1);
            this.year = year;
            this.clubID = clubID;
            this.number = number;
            SetShowData();
            classList = database.GetClassItemList(clubID, year, String.Empty);
            showList = database.GetShowItemList(clubID, year, "date");
        }

        private void SetShowData()
        {
            ShowItem item = database.GetShowItem(clubID, year, number);
            date = item.date.ToString("MM/dd/yyyy");
            name = item.name;
            comments = item.comments;
        }

        public bool AddShow(DateTime date, string description, string comments)
        {
            string dateString = date.ToString("yyyy-MM-dd");
            string columns = "date, show_name, show_comment";
            string values = "'" + dateString + "', '" + database.CleanString(description) +
                "', '" + database.CleanString(comments) + "'";
            bool success = database.AddValues(clubID, year + "_show", columns, values);
            if (success)
            {
                string no = database.GetValueString(clubID, year + "_show", "show_no", "date = '" + dateString + "'");
                number = Convert.ToInt32(no);
                showList = database.GetShowItemList(clubID, year, "date");
            }
            return success;
        }

        public bool ModifyShow(DateTime date, string description, string comments)
        {
            string dateString = date.ToString("yyyy-MM-dd");
            string values = "date = '" + dateString + "', show_name = '" + database.CleanString(description) + 
                "', show_comment = '" + database.CleanString(comments) + "'";
            string qualifier = "show_no = " + number;
            bool success = database.ChangeValues(clubID, year + "_show", values, qualifier);
            if(success)
            {
                showList = database.GetShowItemList(clubID, year, "date");
            }
            return success;
        }

        public bool RemoveShow()
        {
            string qualifier = "show_no = " + number;
            bool success = database.DeleteValues(clubID, year + "_show", qualifier);
            if (success)
            {
                showList = database.GetShowItemList(clubID, year, "date");
            }
            return success;
        }
    }
}
