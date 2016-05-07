/* 
 * TrotTrax
 *     Copyright (c) 2015-2016 Katy Brimm
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
    class Class : ListObject
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public int CatNo { get; private set; }
        public string CatName { get; private set; }
        public decimal Fee { get; private set; }

        public Class(string clubID, int year)
        {
            Database = new DBDriver(1);
            this.Year = year;
            this.ClubID = clubID;
            Number = Database.GetNextIndex(ItemType.Class);
            ClassList = Database.GetClassItemList();
            CatList = Database.GetCategoryItemList(); 
            ShowList = Database.GetShowItemList();            
        }

        public Class(string clubID, int year, int number)
        {
            Database = new DBDriver(1);
            this.Year = year;
            this.ClubID = clubID;
            this.Number = number;
            CatList = Database.GetCategoryItemList(); 
            ClassList = Database.GetClassItemList();
            ShowList = Database.GetShowItemList();
            SetClassData();
        }
       
        private void SetClassData()
        {
            ClassItem classItem = Database.GetClassItem(Number);
            CatNo = classItem.CatNo;
            Name = classItem.Name;
            Fee = classItem.Fee;
            CategoryItem catItem = Database.GetCategoryItem(CatNo);
            CatName = catItem.Name;
        }

        public bool AddClass(int newClassNo, int newCatNo, string newClassName, decimal newFee)
        {
            bool success = Database.AddClassItem(newClassNo, newCatNo, newClassName, newFee);
            return success;
        }

        public bool ModifyClass(int newClassNo, int newCatNo, string newClassName, decimal newFee)
        {
            bool success = Database.UpdateClassItem(newClassNo, newCatNo, newClassName, newFee);
            return success;
        }

        public bool RemoveClass()
        {
            bool success = Database.DeleteClassItem(Number);
            return success;
        }
    }

    public enum ClassSort
    {
        Default,
        Name,
        Number,
        Category
    }
}
