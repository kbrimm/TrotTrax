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
        public List<HorseItem> horseList;
        public List<RiderItem> riderList;
        public List<ShowItem> showList;
        public List<ClassEntryItem> classEntryList;

        public void SortBackNos(string field)
        {
            backNoList = database.GetBackNoItemList(clubID, year, field);
        }

        public void SortCats(string field)
        {
            catList = database.GetCatItemList(clubID, year, field);
        }
        
        public void SortClasses(string field)
        {
            classList = database.GetClassItemList(clubID, year, field);
        }

        public void SortRiders(string field)
        {
            riderList = database.GetRiderItemList(clubID, year, field);
        }
    }

    public struct BackNoItem
    {
        public int no { get; set; }
        public string rider { get; set; }
        public int riderNo { get; set; }
        public string horse { get; set; }
        public int horseNo { get; set; }
    }

    public struct CatBoxItem
    {
        public int no { get; set; }
        public string description { get; set; }
    }
    
    public struct CatItem
    {
        public int no { get; set; }
        public string description { get; set; }
        public bool timed { get; set; }
        public bool payout { get; set; }
        public bool jackpot { get; set; }
        public decimal fee { get; set; }
    }

    public struct ClassItem
    {
        public int no { get; set; }
        public string name { get; set; }
    }

    public struct ClassEntryItem
    {
        public int backNo { get; set; }
        public string horseName { get; set; }
        public string showDate { get; set; }
        public string className { get; set; }
        public int place { get; set; }
    }

    public struct EntryBoxItem
    {
        public int no { get; set; }
        public string combo { get; set; }
    }

    public struct HorseItem
    {
        public int no { get; set; }
        public string name { get; set; }
    }

    public struct RiderItem
    {
        public int no { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public struct ShowItem
    {
        public int no { get; set; }
        public string date { get; set; }
        public string description { get; set; }
    }
}
