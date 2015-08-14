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
    class Category : ListObject
    {
        public int number { get; private set; }
        public string description { get; private set; }
        public decimal fee { get; private set; }
        public bool timed { get; private set; }
        public bool payout { get; private set; }
        public bool jackpot { get; private set; }

        public Category(string clubID, int year)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            classList = database.GetClassItemList(clubID, year, String.Empty);
            catList = database.GetCatItemList(clubID, year, String.Empty);
        }

        public Category(string clubID, int year, int catNo)
        {
            database = new DBDriver(1);
            this.clubID = clubID;
            this.year = year;
            number = catNo;
            classList = database.GetClassItemList(clubID, year, String.Empty);
            catList = database.GetCatItemList(clubID, year, String.Empty);
            description = database.GetValueString(clubID, year + "_category", "description", "category_no = " + catNo);
            fee = database.GetValueDecimal(clubID, year + "_category", "fee", "category_no = " + catNo);
            timed = database.GetValueBool(clubID, year + "_category", "timed", "category_no = " + catNo);
            payout = database.GetValueBool(clubID, year + "_category", "payout", "category_no = " + catNo);
            jackpot = database.GetValueBool(clubID, year + "_category", "jackpot", "category_no = " + catNo);
        }

        public bool AddCat(string newDesc, bool newTimed, bool newPayout, bool newJackpot, decimal newFee)
        {
            string target = "description, timed, payout, jackpot, fee";
            string values = "'" + database.FormatString(newDesc) + "', " + newTimed + ", " +
                newPayout + ", " + newJackpot + ", " + newFee;
            bool success = database.AddValues(clubID, year + "_category", target, values);
            number = database.GetValueInt(clubID, year + "_category", "category_no", "description = '" + newDesc + "'");
            return success;
        }

        public bool ModifyCat(string newDesc, bool newTimed, bool newPayout, bool newJackpot, decimal newFee)
        {
            string values = "description = '" + database.FormatString(newDesc) + 
                "', timed = " + newTimed + ", payout = " + newPayout + ", jackpot = " + newJackpot + 
                ", fee = " + newFee;
            string qualifier = "category_no = " + number;
            bool success = database.ChangeValues(clubID, year + "_category", values, qualifier);
            return success;
        }

        public void RemoveCat()
        {
            string qualifier = "category_no = " + number;
            database.DeleteValues(clubID, year + "_category", qualifier);
        }
    }
}
