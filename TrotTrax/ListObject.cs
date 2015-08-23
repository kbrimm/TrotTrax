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
    public class ListObject
    {
        protected DBDriver database { get; set; }
        public string clubID { get; set; }
        public int year { get; set; }
        public List<BackNoItem> backNoList;
        public List<CatItem> catList;
        public List<ClassItem> classList;
        public List<ClassEntryItem> classEntryList;
        public List<HorseItem> horseList;
        public List<RiderItem> riderList;
        public List<ShowItem> showList;

        public void SortBackNos(string sortOn)
        {
            backNoList = database.GetBackNoItemList(clubID, year, sortOn);
        }

        public void SortCats(string sortOn)
        {
            catList = database.GetCatItemList(clubID, year, sortOn);
        }
        
        public void SortClasses(string sortOn)
        {
            classList = database.GetClassItemList(clubID, year, sortOn);
        }

        public void SortRiders(string sortOn)
        {
            riderList = database.GetRiderItemList(clubID, year, sortOn);
        }
    }

    public struct BackNoItem
    {
        public int no;
        public string rider;
        public int riderNo;
        public string horse;
        public int horseNo;
    }
    
    public struct CatItem
    {
        public int no;
        public string description;
        public decimal fee;
        public bool timed;
        public bool payout;
        public bool jackpot;
    }

    public struct ClassItem
    {
        public int no;
        public string name;
        public int catNo;
    }

    public struct ClassEntryItem
    {
        public int backNo;
        public int riderNo;
        public string rider;
        public int horseNo;
        public string horse;
        public int showNo;
        public string showDate;
        public int classNo;
        public string className;
        public int place;
        public int points;
        public decimal payIn;
        public decimal payOut;
    }

    public struct HorseItem
    {
        public int no;
        public string name;
        public string shortName;
        public decimal height;
    }

    public struct RiderItem
    {
        public int no;
        public string firstName;
        public string lastName;
        public int age;
        public string phone;
        public string email;
        public bool member;
    }

    public struct ShowItem
    {
        public int no;
        public string date;
        public string name;
        public string comments;
    }
}
