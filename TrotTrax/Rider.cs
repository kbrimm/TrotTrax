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
        public int Number { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public bool IsMember { get; private set; }
        public string Comments { get; private set; }

        #region Constructors

        public Rider(string clubID, int year)
        {
            Database = new DBDriver(1);
            this.ClubID = clubID;
            this.Year = year;
            Number = Database.GetNextIndex(FormType.Rider);
            BackNoList = Database.GetBackNoItemList(BackNoFilter.Rider, Number);
            HorseList = Database.GetHorseItemList();
            RiderList = Database.GetRiderItemList();
            
        }

        public Rider(string clubID, int year, int riderNo)
        {
            Database = new DBDriver(1);
            this.ClubID = clubID;
            this.Year = year;
            this.Number = riderNo;
            SetRiderData();
            BackNoList = Database.GetBackNoItemList(BackNoFilter.Rider, Number);
            HorseList = Database.GetHorseItemList();
            RiderList = Database.GetRiderItemList();
        }

        private void SetRiderData()
        {
            RiderItem riderItem = Database.GetRiderItem(Number);
            FirstName = riderItem.FirstName;
            LastName = riderItem.LastName;
            Birthdate = riderItem.Birthdate;
            Phone = riderItem.Phone;
            Email = riderItem.Email;
            IsMember = riderItem.Member;
            Comments = riderItem.Comments;
        }

        #endregion

        public bool AddRider(int riderNo, string firstName, string lastName, DateTime dob, string phone, 
            string email, bool member, string comments)
        {
            return Database.AddRiderItem(riderNo, firstName, lastName, dob, phone, email, member, comments);
        }

        public bool ModifyRider(int number, string firstName, string lastName, DateTime dob, string phone,
            string email, bool member, string comments)
        {
            return Database.UpdateRiderItem(number, firstName, lastName, dob, phone, email, member, comments);
        }

        public bool RemoveRider()
        {
            return Database.DeleteRiderItem(Number);
        }

        public bool AddBackNo(int backNo, int horseNo)
        {
            return Database.AddBackNoItem(backNo, Number, horseNo);
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
