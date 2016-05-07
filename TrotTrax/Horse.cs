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
    class Horse : ListObject
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public string AltName { get; private set; }
        public string Height { get; private set; }
        public string Owner { get; private set; }
        public string Comments { get; private set; }

        #region Constructors

        public Horse(string clubID, int year)
        {
            Database = new DBDriver(1);
            this.ClubID = clubID;
            this.Year = year;
            Number = Database.GetNextIndex(ItemType.Horse);
            BackNoList = Database.GetBackNoItemList(BackNoFilter.Horse, Number);
            HorseList = Database.GetHorseItemList(HorseSort.Name);
            RiderList = Database.GetRiderItemList();
        }

        public Horse(string clubID, int year, int horseNo)
        {
            Database = new DBDriver(1);
            this.ClubID = clubID;
            this.Year = year;
            this.Number = horseNo;
            SetHorseData();
            BackNoList = Database.GetBackNoItemList(BackNoFilter.Horse, Number);
            HorseList = Database.GetHorseItemList();
            RiderList = Database.GetRiderItemList();
        }

        #endregion

        private void SetHorseData()
        {
            HorseItem horseItem = Database.GetHorseItem(Number);
            Name = horseItem.Name;
            AltName = horseItem.AltName;
            Height = horseItem.Height;
            Owner = horseItem.OwnerName;
            Comments = horseItem.Comments;
        }

        public bool AddHorse(int number, string name, string callName, string height, string owner, string comment)
        {
            return Database.AddHorseItem(number, name, callName, height, owner, comment);
        }

        public bool ModifyHorse(int number, string name, string callName, string height, string owner, string comment)
        {
            return Database.UpdateHorseItem(number, name, callName, height, owner, comment);
        }

        public bool RemoveHorse()
        {
            return Database.DeleteHorseItem(Number);
        }

        public bool AddBackNo(int backNo, int riderNo)
        {
            return Database.AddBackNoItem(backNo, riderNo, Number);
        }
    }

    public enum HorseSort
    {
        Default,
        Name,
        Number,
        CallName,
        Owner
    }
}
