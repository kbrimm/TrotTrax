﻿/* 
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
    public class ListObject
    {
        protected DBDriver database { get; set; }
        public string clubID { get; set; }
        public int year { get; set; }
        public List<BackNoItem> backNoList;
        public List<CategoryItem> catList;
        public List<ClassItem> classList;        
        public List<HorseItem> horseList;
        public List<ResultItem> resultList;
        public List<RiderItem> riderList;
        public List<ShowItem> showList;

        public void SortBackNos(string sort)
        {
            backNoList = database.GetBackNoItemList(sort);
        }

        public void SortCategories(string sort)
        {
            catList = database.GetCategoryItemList(sort);
        }
        
        public void SortClasses(string sort)
        {
            classList = database.GetClassItemList(sort);
        }

        public void SortRiders(string sort)
        {
            riderList = database.GetRiderItemList(sort);
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
    
    public struct CategoryItem
    {
        public int no;
        public string name;
        public bool timed;
    }

    public struct ClassItem
    {
        public int no;
        public string name;
        public int catNo;
        public decimal fee;
    }

    public struct ClubItem
    {
        public string clubID;
        public string clubName;
    }

    public struct DropDownItem
    {
        public int no { get; set; }
        public string name { get; set; }
    }

    public struct HorseItem
    {
        public int no;
        public string name;
        public string callName;
        public decimal height;
        public string ownerName;
    }

    public struct ResultItem
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
        public decimal time;
        public int points;
        public decimal payIn;
        public decimal payOut;
    }

    public struct RiderItem
    {
        public int no;
        public string firstName;
        public string lastName;
        public DateTime dob;
        public string phone;
        public string email;
        public bool member;
    }

    public struct ShowItem
    {
        public int no;
        public DateTime date;
        public string name;
        public string comments;
    }
}
