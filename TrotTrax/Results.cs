/* 
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
    class Results : ListObject
    {
        public List<BackNoItem> entryList = new List<BackNoItem>();
        public List<BackNoItem> placingList = new List<BackNoItem>();

        private string qualifier; 
        public int classNo { get; private set; }
        public string className { get; private set; }
        public int showNo { get; private set; }
        public string showDate { get; private set; }
        public int entryCount { get; private set; }
        // To be implemented at a later date:
        //public bool isTimed { get; private set; }
        //public bool isPayout { get; private set; }
        //public bool isJackpot { get; private set; }
        //public decimal fee { get; private set; }

        public Results(string clubID, int year, int showNo, int classNo)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            this.classNo = classNo;
            this.showNo = showNo;
            qualifier = "s.show_no = " + showNo + " AND s.class_no = " + classNo;

            classList = database.GetClassItemList(clubID, year, String.Empty);
            backNoList = database.GetBackNoItemList(clubID, year, String.Empty);
           // entryList = database.GetEntryList(clubID, year, String.Empty, qualifier);
           // placingList = database.GetEntryList(clubID, year, "place", "place IS NOT NULL AND show_no = " + showNo +
           //     " AND class_no = " + classNo);
            className = database.GetValueString(clubID, year + "_class_list", "name", "class_no = " + classNo);
            showDate = database.GetValueString(clubID, year + "_show_list", "date", "show_no = " + showNo);
           // entryCount = database.CountValue(clubID, year + "_results", "back_no", "class_no = " + classNo + " AND show_no = " + showNo);
        }

        public void SortEntries(string field)
        {
            //entryList = database.GetEntryList(clubID, year, field, qualifier);
        }

        public bool AddEntry(int backNo)
        {
            string values = showNo + ", " + classNo + ", " + backNo;
            bool success = database.AddValues(clubID, year + "_results", "show_no, class_no, back_no", values);
            if (success)
            {
              //  entryList = database.GetEntryList(clubID, year, String.Empty, qualifier);
               // entryCount = database.CountValue(clubID, year + "_results", "back_no", "class_no = " + classNo + " AND show_no = " + showNo);
            }
            return success;
        }

        public bool RemoveEntry(int backNo)
        {
            string where = "show_no = " + showNo + " AND class_no = " + classNo + " AND back_no = " + backNo;
            bool success = database.DeleteValues(clubID, year + "_results", where);
            if (success)
            {
               // entryList = database.GetEntryList(clubID, year, String.Empty, qualifier);
                //entryCount = database.CountValue(clubID, year + "_results", "back_no", "class_no = " + classNo + " AND show_no = " + showNo);
            }
            return success;
        }

        public bool IsFirstClass()
        {
            foreach(ClassItem entry in classList)
                if (entry.no < classNo)
                    return false;

            return true;
        }

        public int GetPrev()
        {
            int prev = classNo - 1;
            bool found = false;

            while(!found && prev > 0)
            {
                foreach (ClassItem entry in classList)
                    if(entry.no == prev)
                    { 
                        found = true;
                        return prev;
                    }
                prev -= 1;
            }
            return 0;
        }

        public bool IsLastClass()
        {
            foreach (ClassItem entry in classList)
                if (entry.no > classNo)
                    return false;

            return true;
        }

        public int GetNext()
        {
            int next = classNo + 1;
            bool found = false;

            while (!found && next < 250)
            {
                foreach (ClassItem entry in classList)
                    if (entry.no == next)
                    {
                        found = true;
                        return next;
                    }
                next += 1;
            }
            return 0;
        }
    }
}
