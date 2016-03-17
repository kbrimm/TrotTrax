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
    class Horse : ListObject
    {
        public int number { get; private set; }
        public string name { get; private set; }
        public string altName { get; private set; }
        public string height { get; private set; }
        public string owner { get; private set; }
        public string comment { get; private set; }

        public Horse(string clubID, int year)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            number = database.GetNextIndex(FormType.Horse);
            backNoList = database.GetBackNoItemList(BackNoFilter.Horse, number);
            horseList = database.GetHorseItemList(HorseSort.Name);
            
        }

        public Horse(string clubID, int year, int horseNo)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            this.number = horseNo;
            SetHorseData();
            backNoList = database.GetBackNoItemList(BackNoFilter.Horse, number);
            horseList = database.GetHorseItemList();
            riderList = database.GetRiderItemList();
        }

        private void SetHorseData()
        {
            HorseItem horseItem = database.GetHorseItem(number);
            name = horseItem.name;
            altName = horseItem.altName;
            height = horseItem.height;
            owner = horseItem.ownerName;
            comment = horseItem.comments;
        }

        public bool AddHorse(int number, string name, string callName, string height, string owner, string comment)
        {
            return database.AddHorseItem(number, name, callName, height, owner, comment);
        }

        public bool ModifyHorse(int number, string name, string callName, string height, string owner, string comment)
        {
            return database.UpdateHorseItem(number, name, callName, height, owner, comment);
        }

        public bool RemoveHorse()
        {
            return database.DeleteHorseItem(number);
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
