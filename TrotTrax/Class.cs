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
            classList = database.GetClassItemList(clubID, year, String.Empty);
            catList = database.GetCategoryItemList(clubID, year, String.Empty); 
            showList = database.GetShowItemList(clubID, year, "date");            
        }

        public Class(string clubID, int year, int number)
        {
            database = new DBDriver(1);
            this.year = year;
            this.clubID = clubID;
            this.number = number;
            catList = database.GetCategoryItemList(clubID, year, String.Empty); 
            classList = database.GetClassItemList(clubID, year, String.Empty);
            showList = database.GetShowItemList(clubID, year, String.Empty);
            SetClassData();
        }
       
        private void SetClassData()
        {
            ClassItem classItem = database.GetClassItem(clubID, year, number);
            catNo = classItem.catNo;
            name = classItem.name;
            fee = classItem.fee;
            catName = database.GetValueString(clubID, year + "_category", "category_name", "category_no=" + catNo);
        }

        public bool AddClass(int newClassNo, int newCatNo, string newClassName)
        {
            string columns = "class_no, category_no, class_name, fee";
            string data = newClassNo + ", " + newCatNo +
                ", '" + database.FormatString(newClassName) + "', " + fee;
            bool success = database.AddValues(clubID, year + "_class", columns, data);
            return success;
        }

        public bool ModifyClass(int newClassNo, int newCatNo, string newClassName)
        {
            string data = "class_no = '" + newClassNo + "', category_no = '" + newCatNo + 
                "', class_name = '" + database.FormatString(newClassName) + "'";
            string where = "class_no = " + number;
            bool success = database.ChangeValues(clubID, year + "_class", data, where);
            return success;
        }

        public void RemoveClass()
        {
            string where = "class_no = " + number;
            database.DeleteValues(clubID, year + "_class", where);
        }
    }
}
