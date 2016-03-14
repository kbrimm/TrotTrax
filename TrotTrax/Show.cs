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
            number = database.GetNextIndex(FormType.Show);
            classList = database.GetClassItemList();
            showList = database.GetShowItemList();
        }

        public Show(string clubID, int year, int number)
        {
            database = new DBDriver(1);
            this.year = year;
            this.clubID = clubID;
            this.number = number;
            SetShowData();
            classList = database.GetClassItemList();
            showList = database.GetShowItemList();
        }

        private void SetShowData()
        {
            ShowItem item = database.GetShowItem(number);
            date = item.date.ToString("MM/dd/yyyy");
            name = item.name;
            comments = item.comments;
        }

        public bool AddShow(int showNo, DateTime date, string description, string comments)
        {
            return database.AddShowItem(showNo, date, description, comments);
        }

        public bool ModifyShow(DateTime date, string description, string comments)
        {
            return database.UpdateShowItem(number, date, description, comments);
        }

        public bool RemoveShow()
        {
            return database.DeleteShowItem(number);
        }
    }

    public enum ShowSort
    {
        Default, 
        Number,
        Name,
        Date
    }
}
