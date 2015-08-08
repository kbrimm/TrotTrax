﻿/* 
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
    class Class
    {
        private DBDriver database;
        public int year { get; private set; }
        public string clubID { get; private set; }
        public List<ClassItem> classList = new List<ClassItem>();
        public List<CatItem> catList = new List<CatItem>();
        public List<ShowItem> showList = new List<ShowItem>();

        public int number { get; private set; }
        public string name { get; private set; }
        public int catNo { get; private set; }
        public string catName { get; private set; }

        public Class(int year,string clubID)
        {
            database = new DBDriver(1);
            this.year = year;
            this.clubID = clubID;

            classList = database.GetClassItemList(clubID, year, String.Empty);
            catList = database.GetCatItemList(clubID, year, String.Empty); 
            showList = database.GetShowItemList(clubID, year, "date");            
        }

        public Class(int year, string clubID, int classNo)
        {
            database = new DBDriver(1);
            classList = new List<ClassItem>();
            showList = new List<ShowItem>();
            this.year = year;
            this.clubID = clubID;
            number = classNo;

            classList = database.GetClassItemList(clubID, year, String.Empty);
            catList = database.GetCatItemList(clubID, year, String.Empty); 
            showList = database.GetShowItemList(clubID, year, "date");
            name = database.GetValueString(clubID, year + "_class_list", "name", "class_no = " + classNo);
            catNo = database.GetValueInt(clubID, year + "_class_list", "category_no", "class_no = " + classNo);
            catName = database.GetValueString(clubID, year + "_category", "description", "category_no = " + catNo);
        }

        public void SortClasses(string field)
        {
            classList = database.GetClassItemList(clubID, year, field);
        }

        public void SortShows(string field)
        {
            showList = database.GetShowItemList(clubID, year, field);
        }

        public void SortCats(string field)
        {
            catList = database.GetCatItemList(clubID, year, field);
        }

        public bool AddClass(int classNo, int newCatNo, string className)
        {
            string target = "class_no, category_no, name";
            string values = "'" + classNo + "', '" + newCatNo +
                "', '" + database.FormatString(className) + "'";
            bool success = database.AddValues(clubID, year + "_class_list", target, values);
            return success;
        }

        public bool ModifyClass(int classNo, int newCatNo, string className)
        {
            string values = "class_no = '" + classNo + "', category_no = '" + newCatNo + 
                "', name = '" + database.FormatString(className) + "'";
            string qualifier = "show_no = " + number;
            bool success = database.ChangeValues(clubID, year + "_show_list", values, qualifier);
            return success;
        }

        public void RemoveClass()
        {
            string qualifier = "class_no = " + number;
            database.DeleteValues(clubID, year + "_class_list", qualifier);
        }
    }
}
