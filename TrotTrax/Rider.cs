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
        public string comment { get; private set; }

        public Rider(string clubID, int year)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            number = database.GetNextIndex(FormType.Rider);
            backNoList = database.GetBackNoItemList(BackNoFilter.Rider, number);
            horseList = database.GetHorseItemList();
            riderList = database.GetRiderItemList();
            
        }

        public Rider(string clubID, int year, int riderNo)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            this.number = riderNo;
            SetRiderData();
            backNoList = database.GetBackNoItemList(BackNoFilter.Rider, number);
            horseList = database.GetHorseItemList();
            riderList = database.GetRiderItemList();
        }

        private void SetRiderData()
        {
            RiderItem riderItem = database.GetRiderItem(number);
            firstName = riderItem.firstName;
            lastName = riderItem.lastName;
            dob = riderItem.dob;
            phone = riderItem.phone;
            email = riderItem.email;
            member = riderItem.member;
            comment = riderItem.comments;
        }

        public bool AddRider(int riderNo, string firstName, string lastName, DateTime dob, string phone, 
            string email, bool member, string comment)
        {
            return database.AddRiderItem(riderNo, firstName, lastName, dob, phone, email, member, comment);
        }

        public bool ModifyRider(int number, string firstName, string lastName, DateTime dob, string phone,
            string email, bool member, string comment)
        {
            return database.UpdateRiderItem(number, firstName, lastName, dob, phone, email, member, comment);
        }

        public bool RemoveRider()
        {
            return database.DeleteRiderItem(number);
        }

        public bool AddBackNo(int backNo, int horseNo)
        {
            return database.AddBackNoItem(backNo, number, horseNo);
        }
    }

    public enum RiderSort
    {
        Default,
        Number,
        FirstName,
        LastName,
        BirthDate
    }
}
