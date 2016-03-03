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
    class Category : ListObject
    {
        public int number { get; private set; }
        public string name { get; private set; }
        public bool timed { get; private set; }

        public Category(string clubID, int year)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            classList = database.GetClassItemList(clubID, year, String.Empty);
            catList = database.GetCategoryItemList(clubID, year, String.Empty);
        }

        public Category(string clubID, int year, int number)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            this.number = number;
            SetCategoryData();
            classList = database.GetClassItemList(clubID, year, String.Empty);
            catList = database.GetCategoryItemList(clubID, year, String.Empty);
        }

        private void SetCategoryData()
        {
            CategoryItem item = database.GetCategoryItem(clubID, year, number);
            name = item.name;
            timed = item.timed;
        }

        public bool AddCategory(string newDesc, bool newTimed)
        {
            string column = "category_name, timed";
            string data = "'" + database.CleanString(newDesc) + "', " + newTimed;
            bool success = database.AddValues(clubID, year + "_category", column, data);
            number = database.GetLastIndex();
            return success;
        }

        public bool ModifyCategory(string newDesc, bool newTimed)
        {
            string data = "category_name = '" + database.CleanString(newDesc) + 
                "', timed = " + newTimed;
            string where = "category_no = " + number;
            bool success = database.ChangeValues(clubID, year + "_category", data, where);
            return success;
        }

        public void RemoveCat()
        {
            string where = "category_no = " + number;
            database.DeleteValues(clubID, year + "_category", where);
        }
    }

    public enum CategorySort
    {
        Default,
        Name,
        Number
    }
}
