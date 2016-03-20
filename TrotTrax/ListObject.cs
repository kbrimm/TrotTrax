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
    public class ListObject
    {
        protected DBDriver Database { get; set; }
        public string ClubID { get; set; }
        public int Year { get; set; }
        public List<BackNoItem> BackNoList;
        public List<CategoryItem> CatList;
        public List<ClassItem> ClassList;        
        public List<HorseItem> HorseList;
        public List<ResultItem> ResultList;
        public List<RiderItem> RiderList;
        public List<ShowItem> ShowList;

        #region Sort Fns

        public void SortBackNos(BackNoSort sort)
        {
            BackNoList = Database.GetBackNoItemList(sort);
        }

        public void SortBackNos(BackNoSort sort, BackNoFilter filter, int number)
        {
            BackNoList = Database.GetBackNoItemList(filter, number, sort);
        }

        public void SortCategories(CategorySort sort)
        {
            CatList = Database.GetCategoryItemList(sort);
        }
        
        public void SortClasses(ClassSort sort)
        {
            ClassList = Database.GetClassItemList(sort);
        }

        public void SortHorses(HorseSort sort)
        {
            HorseList = Database.GetHorseItemList(sort);
        }

        public void SortRiders(RiderSort sort)
        {
            RiderList = Database.GetRiderItemList(sort);
        }

        #endregion

        public bool CheckIndexUsed(FormType type, int classNo)
        {
            return Database.CheckIndexUsed(type, classNo);
        }
    }

    public struct BackNoItem
    {
        public int No;
        public string Rider;
        public int RiderNo;
        public string Horse;
        public int HorseNo;
    }
    
    public struct CategoryItem
    {
        public int No;
        public string Name;
        public bool Timed;
    }

    public struct ClassItem
    {
        public int No;
        public string Name;
        public int CatNo;
        public decimal Fee;
    }

    public struct ClubItem
    {
        public string ClubId;
        public string ClubName;
    }

    public struct DropDownItem
    {
        public int No { get; set; }
        public string Name { get; set; }
    }

    public struct HorseItem
    {
        public int No;
        public string Name;
        public string AltName;
        public string Height;
        public string OwnerName;
        public string Comments;
    }

    public struct ResultItem
    {
        public int BackNo;
        public int RiderNo;
        public string Rider;
        public int HorseNo;
        public string Horse;
        public int ShowNo;
        public string ShowDate;
        public int ClassNo;
        public string ClassName;
        public int Place;
        public decimal Time;
        public int Points;
        public decimal PayIn;
        public decimal PayOut;
    }

    public struct RiderItem
    {
        public int No;
        public string FirstName;
        public string LastName;
        public DateTime Birthdate;
        public string Phone;
        public string Email;
        public bool Member;
        public string Comments;
    }

    public struct ShowItem
    {
        public int No;
        public DateTime Date;
        public string Name;
        public string Comments;
    }

    public enum FormType
    {
        BackNo,
        Category,
        Class,
        Horse,
        Rider,
        Result,
        Show
    }
}
