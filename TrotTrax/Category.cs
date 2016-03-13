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

        // New category item.
        public Category(string clubID, int year)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            // If this is a new item, pull in the next number from the database.
            number = database.GetNextCategoryNumber();
            classList = database.GetClassItemList();
            catList = database.GetCategoryItemList();
        }

        // Existing cateogry item.
        public Category(string clubID, int year, int number)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            this.number = number;
            SetCategoryData();
            classList = database.GetClassItemList();
            catList = database.GetCategoryItemList();
        }

        private void SetCategoryData()
        {
            CategoryItem item = database.GetCategoryItem(number);
            name = item.name;
            timed = item.timed;
        }

        public bool AddCategory(string newDesc, bool newTimed)
        {
            return database.AddCategoryItem(number, newDesc, newTimed);
        }

        public bool ModifyCategory(string newDesc, bool newTimed)
        {
            return database.UpdateCategoryItem(number, newDesc, newTimed);
        }

        public bool RemoveCat()
        {
            return database.DeleteCategoryItem(number);
        }
    }

    public enum CategorySort
    {
        Default,
        Name,
        Number,
        Timed
    }
}
