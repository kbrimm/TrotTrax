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
    class Rider : ListObject
    {
        public int number { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public DateTime dob { get; private set; }
        public string phone { get; private set; }
        public string email { get; private set; }
        public bool member { get; private set; }

        public Rider(string clubID, int year)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            riderList = database.GetRiderItemList(clubID, year, "rider_last");
            horseList = database.GetHorseItemList(clubID, year, String.Empty);
        }

        public Rider(string clubID, int year, int riderNo)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            this.number = riderNo;
            SetRiderData();
            riderList = database.GetRiderItemList(clubID, year, "rider_last");
            horseList = database.GetHorseItemList(clubID, year, String.Empty);
            // classEntryList = database.GetClassEntryItemList(clubID, year, "r.rider_no = " + riderNo, "s.date");
        }

        private void SetRiderData()
        {
            RiderItem riderItem = database.GetRiderItem(clubID, year, number);
            firstName = riderItem.firstName;
            lastName = riderItem.lastName;
            dob = riderItem.dob;
            phone = riderItem.phone;
            email = riderItem.email;
            member = riderItem.member;
        }

        public bool AddRider(string firstName, string lastName, DateTime dob, string phone, 
            string email, bool member)
        {
            string dobString = dob.ToString("yyyy-MM-dd");
            string columns = "rider_first, rider_last, rider_dob, " +
                "phone, email, member";
            string values = "'" + database.CleanString(firstName) + "', '" + database.CleanString(lastName) +
                "', " + dobString + ", '" + database.CleanString(phone) + "', '" + database.CleanString(email) +
                "', " + member;
            bool success = database.AddValues(clubID, year + "_rider", columns, values);
            if (success)
            {
                this.number = number;
                riderList = database.GetRiderItemList(clubID, year, "rider_last");
            }
            return success;
        }

        public bool ModifyRider(int number, string firstName, string lastName, DateTime dob, string phone, 
            string email, bool member)
        {
            string dobString = dob.ToString("yyyy-MM-dd");
            string data = "rider_first = '" + database.CleanString(firstName) + "', rider_last = '" + 
                database.CleanString(lastName) + "', rider_dob = " + dobString + ", phone = '" + database.CleanString(phone) + 
                "', email = '" + database.CleanString(email) + "', member = " + member;
            string where = "rider_first = '" + database.CleanString(firstName) + "', rider_last = '" + database.CleanString(lastName) + "'";
            bool success = database.ChangeValues(clubID, year + "_rider", data, where);
            if (success)
            {
                riderList = database.GetRiderItemList(clubID, year, "rider_last");
            }
            return success;
        }

        public bool RemoveRider()
        {
            string where = "rider_no = " + number;
            bool success = database.DeleteValues(clubID, year + "_rider", where);
            if (success)
            {
                riderList = database.GetRiderItemList(clubID, year, "rider_last");
            }
            return success;
        }
    }
}
