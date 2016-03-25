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
    class Result : ListObject
    {
        public List<BackNoItem> EntryList = new List<BackNoItem>();
        public List<BackNoItem> PlacingList = new List<BackNoItem>();
        public Settings ActiveSettings;

        public int ClassNo { get; private set; }
        public string ClassName { get; private set; }
        public int ShowNo { get; private set; }
        public string ShowDate { get; private set; }
        public int EntryCount { get; private set; }
        // To be implemented at a later date:
        //public bool isTimed { get; private set; }
        //public bool isPayout { get; private set; }
        //public bool isJackpot { get; private set; }
        //public decimal fee { get; private set; }

        public Result(string clubID, int year, int showNo, int classNo)
        {
            Database = new DBDriver(1);
            ActiveSettings = new Settings(clubID, year);
            this.ClubID = clubID;
            this.Year = year;
            this.ClassNo = classNo;
            this.ShowNo = showNo;

            ClassList = Database.GetClassItemList();
            BackNoList = Database.GetBackNoItemList();
            // entryList = database.GetEntryList(clubID, year, String.Empty, qualifier);
            // placingList = database.GetEntryList(clubID, year, "place", "place IS NOT NULL AND show_no = " + showNo +
            //     " AND class_no = " + classNo);
            // className = database.GetValueString(clubID, year + "_class_list", "name", "class_no = " + classNo);
            // showDate = database.GetValueString(clubID, year + "_show_list", "date", "show_no = " + showNo);
            // entryCount = database.CountValue(clubID, year + "_results", "back_no", "class_no = " + classNo + " AND show_no = " + showNo);
        }

        public void SortEntries(string field)
        {
            //entryList = database.GetEntryList(clubID, year, field, qualifier);
        }

        public bool AddEntry(int backNo)
        {
            return false;
        }

        public bool RemoveEntry(int backNo)
        {
            return false;
        }

        public bool IsFirstClass()
        {
            foreach(ClassItem entry in ClassList)
                if (entry.No < ClassNo)
                    return false;
            return true;
        }

        public int GetPrev()
        {
            int prev = ClassNo - 1;
            bool found = false;

            while(!found && prev > 0)
            {
                foreach (ClassItem entry in ClassList)
                    if(entry.No == prev)
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
            foreach (ClassItem entry in ClassList)
                if (entry.No > ClassNo)
                    return false;

            return true;
        }

        public int GetNext()
        {
            int next = ClassNo + 1;
            bool found = false;

            while (!found && next < 250)
            {
                foreach (ClassItem entry in ClassList)
                    if (entry.No == next)
                    {
                        found = true;
                        return next;
                    }
                next += 1;
            }
            return 0;
        }
    }

    public enum ResultSort
    {
        Default,
        BackNo,
        Category,
        Class,
        Horse,
        Place,
        Rider,
        Show
    }

    public enum ResultFilter
    {
        Default,
        BackNo,
        Category,
        Class,
        Horse,
        Rider,
        Show,
        Time
    }
}
