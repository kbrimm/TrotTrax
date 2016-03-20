/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    class BackNumber : ListObject
    {
        public int Number { get; private set; }
        public int RiderNo { get; private set; }
        public string RiderFirst { get; private set; }
        public string RiderLast { get; private set; }
        public int HorseNo { get; private set; }
        public string HorseName { get; private set; }

        #region Constructors

        public BackNumber(string clubID, int year)
        {
            Database = new DBDriver(1);
            this.ClubID = clubID;
            this.Year = year;
            Number = -1;
            BackNoList = Database.GetBackNoItemList();
            HorseList = Database.GetHorseItemList(); 
            RiderList = Database.GetRiderItemList();
        }

        public BackNumber(string clubID, int year, int backNo)
        {
            Database = new DBDriver(1);
            this.ClubID = clubID;
            this.Year = year;
            this.Number = backNo;
            SetBackNoData();
            BackNoList = Database.GetBackNoItemList();
            HorseList = Database.GetHorseItemList();
            ResultList = Database.GetResultItemList(ResultFilter.BackNo, backNo);
            RiderList = Database.GetRiderItemList();
        }

        #endregion

        private void SetBackNoData()
        {
            BackNoItem backNoItem = Database.GetBackNoItem(Number);
            RiderFirst = backNoItem.RiderFirst;
            RiderLast = backNoItem.RiderLast;
            RiderNo = backNoItem.RiderNo;
            HorseName = backNoItem.Horse;
            HorseNo = backNoItem.HorseNo;
        }

        public bool AddBackNo(int backNo, int riderNo, int horseNo)
        {
            return Database.AddBackNoItem(backNo, riderNo, horseNo);
        }

        public bool ModifyBackNo(int backNo, int riderNo, int horseNo)
        {
            return Database.UpdateBackNoItem(backNo, riderNo, horseNo);
        }

        public bool RemoveBackNo()
        {
            return Database.DeleteBackNoItem(Number);
        }
    }

    public enum BackNoSort
    {
        Default,
        Horse,
        Number,
        RiderFirst,
        RiderLast
    }

    public enum BackNoFilter
    {
        Horse,
        Number,
        Rider
    }
}
