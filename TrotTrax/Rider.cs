using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    class Rider : ListObject
    {
        public int riderNo { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string phone { get; private set; }

        public Rider(string clubID, int year)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;

            riderList = database.GetRiderItemList(clubID, year, "last_name");
            horseList = database.GetHorseItemList(clubID, year, String.Empty);
        }

        public Rider(string clubID, int year, int riderNo)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            this.riderNo = riderNo;

            firstName = database.GetValueString(clubID, year + "_rider", "first_name", "rider_no = " + riderNo);
            lastName = database.GetValueString(clubID, year + "_rider", "last_name", "rider_no = " + riderNo);
            phone = database.GetValueString(clubID, year + "_rider", "contact", "rider_no = " + riderNo);
            riderList = database.GetRiderItemList(clubID, year, "last_name");
            horseList = database.GetHorseItemList(clubID, year, String.Empty);
            classEntryList = database.GetClassEntryItemList(clubID, year, "r.rider_no = " + riderNo, "s.date");
        }
    }
}
