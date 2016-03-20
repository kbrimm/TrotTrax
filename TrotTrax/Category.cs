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
        public int Number { get; private set; }
        public string Name { get; private set; }
        public bool IsTimed { get; private set; }

        #region Constructors

        // New category item.
        public Category(string clubID, int year)
        {
            Database = new DBDriver(1);
            this.ClubID = clubID;
            this.Year = year;
            // If this is a new item, pull in the next number from the database.
            Number = Database.GetNextIndex(FormType.Category);
            ClassList = Database.GetClassItemList();
            CatList = Database.GetCategoryItemList();
        }

        // Existing category item.
        public Category(string clubID, int year, int number)
        {
            Database = new DBDriver(1);
            this.ClubID = clubID;
            this.Year = year;
            this.Number = number;
            SetCategoryData();
            ClassList = Database.GetClassItemList();
            CatList = Database.GetCategoryItemList();
        }

        #endregion

        private void SetCategoryData()
        {
            CategoryItem item = Database.GetCategoryItem(Number);
            Name = item.Name;
            IsTimed = item.Timed;
        }

        public bool AddCategory(string newDesc, bool newTimed)
        {
            return Database.AddCategoryItem(Number, newDesc, newTimed);
        }

        public bool ModifyCategory(string newDesc, bool newTimed)
        {
            return Database.UpdateCategoryItem(Number, newDesc, newTimed);
        }

        public bool RemoveCategory()
        {
            return Database.DeleteCategoryItem(Number);
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
