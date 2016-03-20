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
    class Show : ListObject
    {
        public int Number { get; private set; }
        public DateTime Date { get; private set; }
        public string Name { get; private set; }
        public string Comments { get; private set; }

        public Show(string clubID, int year)
        {
            Database = new DBDriver(1);
            this.Year = year;
            this.ClubID = clubID;
            Number = Database.GetNextIndex(ItemType.Show);
            ClassList = Database.GetClassItemList();
            ShowList = Database.GetShowItemList();
        }

        public Show(string clubID, int year, int number)
        {
            Database = new DBDriver(1);
            this.Year = year;
            this.ClubID = clubID;
            this.Number = number;
            SetShowData();
            ClassList = Database.GetClassItemList();
            ShowList = Database.GetShowItemList();
        }

        private void SetShowData()
        {
            ShowItem item = Database.GetShowItem(Number);
            Date = item.Date;
            Name = item.Name;
            Comments = item.Comments;
        }

        public bool AddShow(int showNo, DateTime date, string description, string comments)
        {
            return Database.AddShowItem(showNo, date, description, comments);
        }

        public bool ModifyShow(DateTime date, string description, string comments)
        {
            return Database.UpdateShowItem(Number, date, description, comments);
        }

        public bool RemoveShow()
        {
            return Database.DeleteShowItem(Number);
        }
    }

    public enum ShowSort
    {
        Default, 
        Number,
        Name,
        Date
    }
}
