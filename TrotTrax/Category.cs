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
            classList = database.GetClassItemList();
            catList = database.GetCategoryItemList();
        }

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

        public bool AddCategory(int catNo, string newDesc, bool newTimed)
        {
            return database.AddCategoryItem(catNo, newDesc, newTimed);
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
        Number
    }
}
