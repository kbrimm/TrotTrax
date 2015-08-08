using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    class Show
    {
        private DBDriver database;
        public int year { get; set; }
        public string clubID { get; set; }
        public List<ShowItem> showList = new List<ShowItem>();
        public List<ClassItem> classList = new List<ClassItem>();

        public int number { get; private set; }
        public string date { get; private set; }
        public string description { get; private set; }
        public string comments { get; private set; }

        public Show(int year,string clubID)
        {
            database = new DBDriver(1);
            this.year = year;
            this.clubID = clubID;

            classList = database.GetClassItemList(clubID, year, String.Empty);
            showList = database.GetShowItemList(clubID, year, "date");
        }

        public Show(int year, string clubID, int showNo)
        {
            database = new DBDriver(1);
            classList = new List<ClassItem>();
            showList = new List<ShowItem>();
            this.year = year;
            this.clubID = clubID;
            number = showNo;

            classList = database.GetClassItemList(clubID, year, String.Empty);
            showList = database.GetShowItemList(clubID, year, "date");
            date = database.GetValueString(clubID, year + "_show_list", "date", "show_no = " + showNo);
            description = database.GetValueString(clubID, year + "_show_list", "description", "show_no = " + showNo);
            comments = database.GetValueString(clubID, year + "_show_list", "comment", "show_no = " + showNo);
        }

        public void SortClasses(string field)
        {
            classList = database.GetClassItemList(clubID, year, field);
        }

        public void SortShows(string field)
        {
            showList = database.GetShowItemList(clubID, year, field);
        }

        public void AddShow(DateTime date, string description, string comments)
        {
            string dateString = date.ToString("MM/dd/yyyy");
            string target = "date, description, comment";
            string values = "'" + dateString + "', '" + database.FormatString(description) +
                "', '" + database.FormatString(comments) + "'";
            database.AddValues(clubID, year + "_show_list", target, values);
            string no = database.GetValueString(clubID, year + "_show_list", "show_no", "date = '" + dateString + "'");
            number = Convert.ToInt32(no);
        }

        public void ModifyShow(DateTime date, string description, string comments)
        {
            string dateString = date.ToString("MM/dd/yyyy");
            string values = "date = '" + dateString + "', description = '" + database.FormatString(description) + 
                "', comment = '" + database.FormatString(comments) + "'";
            string qualifier = "show_no = " + number;
            database.ChangeValues(clubID, year + "_show_list", values, qualifier);
        }

        public void RemoveShow()
        {
            string qualifier = "show_no = " + number;
            database.DeleteValues(clubID, year + "_show_list", qualifier);
        }
    }
}
