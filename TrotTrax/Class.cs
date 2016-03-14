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
    class Class : ListObject
    {
        public int number { get; private set; }
        public string name { get; private set; }
        public int catNo { get; private set; }
        public string catName { get; private set; }
        public decimal fee { get; private set; }

        public Class(string clubID, int year)
        {
            database = new DBDriver(1);
            this.year = year;
            this.clubID = clubID;
            number = database.GetNextIndex(FormType.Class);
            classList = database.GetClassItemList();
            catList = database.GetCategoryItemList(); 
            showList = database.GetShowItemList();            
        }

        public Class(string clubID, int year, int number)
        {
            database = new DBDriver(1);
            this.year = year;
            this.clubID = clubID;
            this.number = number;
            catList = database.GetCategoryItemList(); 
            classList = database.GetClassItemList();
            showList = database.GetShowItemList();
            SetClassData();
        }
       
        private void SetClassData()
        {
            ClassItem classItem = database.GetClassItem(number);
            catNo = classItem.catNo;
            name = classItem.name;
            fee = classItem.fee;
            CategoryItem catItem = database.GetCategoryItem(catNo);
            catName = catItem.name;
        }

        public bool AddClass(int newClassNo, int newCatNo, string newClassName, decimal newFee)
        {
            bool success = database.AddClassItem(newClassNo, newCatNo, newClassName, newFee);
            return success;
        }

        public bool ModifyClass(int newClassNo, int newCatNo, string newClassName, decimal newFee)
        {
            bool success = database.UpdateClassItem(newClassNo, newCatNo, newClassName, newFee);
            return success;
        }

        public bool RemoveClass()
        {
            bool success = database.DeleteClassItem(number);
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
