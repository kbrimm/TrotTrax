/* 
 * TrotTrax
 *     Copyright (c) 2015-2016 Katy Brimm
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
        public List<ResultItem> EntryList = new List<ResultItem>();
        public List<ResultItem> PlacingList = new List<ResultItem>();
        public Settings ActiveSettings;

        public int ClassNo { get; private set; }
        public string ClassName { get; private set; }
        public int ShowNo { get; private set; }
        public DateTime ShowDate { get; private set; }
        public int EntryCount { get; private set; }
        public bool Timed { get; private set; }
        public decimal EntryFee { get; private set; }

        #region Constructor

        public Result(string clubID, int year, int showNo, int classNo)
        {
            Database = new DBDriver(1);
            ActiveSettings = new Settings(clubID, year);
            this.ClubID = clubID;
            this.Year = year;
            this.ClassNo = classNo;
            this.ShowNo = showNo;
            SetShowData();

            ClassList = Database.GetClassItemList();
            BackNoList = Database.GetBackNoItemList();
            EntryList = Database.GetClassResultItemList(ClassNo, ShowNo);
            EntryCount = Database.CountValue(clubID, year + "_results", "back_no", 
                "class_no = " + classNo + " AND show_no = " + showNo);
        }

        private void SetShowData()
        {
            ClassItem aClass = Database.GetClassItem(ClassNo);
            ClassName = aClass.Name;
            ShowItem show = Database.GetShowItem(ShowNo);
            ShowDate = show.Date;
        }

        #endregion

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

        public bool IsLastClass()
        {
            foreach (ClassItem entry in ClassList)
                if (entry.No > ClassNo)
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
