using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    class ClassInstance
    {
        private DBDriver database;
        public int year { get; private set; }
        public string clubID { get; private set; }
        public List<ClassItem> classList = new List<ClassItem>();
        public List<BackNoItem> backNoList = new List<BackNoItem>();
        public List<BackNoItem> entryList = new List<BackNoItem>();
        public List<BackNoItem> placingList = new List<BackNoItem>();

        private string qualifier; 
        public int classNo { get; private set; }
        public string className { get; private set; }
        public int showNo { get; private set; }
        public string showDate { get; private set; }
        public int entryCount { get; private set; }
        public bool isTimed { get; private set; }
        public bool isPayout { get; private set; }
        public bool isJackpot { get; private set; }
        public decimal fee { get; private set; }

        public ClassInstance(string clubID, int year, int showNo, int classNo)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            this.classNo = classNo;
            this.showNo = showNo;
            qualifier = "s.show_no = " + showNo + " AND s.class_no = " + classNo;

            classList = database.GetClassItemList(clubID, year, String.Empty);
            backNoList = database.GetBackNoItemList(clubID, year, String.Empty);
            entryList = database.GetEntryList(clubID, year, String.Empty, qualifier);
            className = database.GetValueString(clubID, year + "_class_list", "name", "class_no = " + classNo);
            showDate = database.GetValueString(clubID, year + "_show_list", "date", "show_no = " + showNo);
            entryCount = database.CountValue(clubID, year + "_results", "back_no", "class_no = " + classNo + " AND show_no = " + showNo);
        }

        public void SortClasses(string field)
        {
            classList = database.GetClassItemList(clubID, year, field);
        }

        public void SortEntries(string field)
        {
            entryList = database.GetEntryList(clubID, year, field, qualifier);
        }

        public bool AddEntry(int backNo)
        {
            return true;
        }
    }
}
