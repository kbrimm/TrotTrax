/* 
 * TrotTrax
 *     Copyright (c) 2015-2016 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
 */

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    public partial class DBDriver
    {
        // Interactions for <year>_show table

        #region Select Statements

        public ShowItem GetShowItem(int showNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT show_no, date, show_name, show_comment FROM [" + Year + "_show] WHERE show_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", showNo));
            query.Connection = ClubConn;
            SQLiteDataReader reader = DoTheReader(query);
            ShowItem item = new ShowItem();

            while (reader.Read())
            {
                item.No = reader.GetInt32(0);
                item.Date = StringToDate(reader.GetString(1));
                item.Name = reader.GetString(2);
                item.Comments = reader.GetString(3);
            }
            reader.Close();
            ClubConn.Close();
            return item;
        }

        // Optional: sort (default is date)
        public List<ShowItem> GetShowItemList(ShowSort sort = ShowSort.Default)
        {
            // Case statment for sort column
            string sortString;
            switch(sort)
            {
                case ShowSort.Number: sortString = "show_no"; break;
                case ShowSort.Name: sortString = "show_name"; break;
                default: sortString = "date"; break;
            }

            string query = "SELECT show_no, date, show_name, show_comment FROM [" + Year + "_show] ORDER BY " + sortString + ";";
            SQLiteDataReader reader = DoTheReader(ClubConn, query);
            List<ShowItem> showItemList = new List<ShowItem>();
            ShowItem item;

            reader = DoTheReader(ClubConn, query);
            while (reader.Read())
            {
                item = new ShowItem();
                item.No = reader.GetInt32(0);
                item.Date = StringToDate(reader.GetString(1));
                item.Name = reader.GetString(2);
                item.Comments = reader.GetString(3);
                showItemList.Add(item);
            }
            reader.Close();
            ClubConn.Close();
            return showItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddShowItem(int showNo, DateTime date, string name, string comment)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO [" + Year + "_show] (show_no, date, show_name, show_comment) " +
                "VALUES (@noparam, @dateparam, @nameparam, @commentparam)";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", showNo));
            query.Parameters.Add(new SQLiteParameter("@dateparam", DateToString(date)));
            query.Parameters.Add(new SQLiteParameter("@nameparam", name));
            query.Parameters.Add(new SQLiteParameter("@commentparam", comment));
            query.Connection = ClubConn;

            return DoTheNonQuery(query);
        }

        #endregion

        #region Update Statements

        public bool UpdateShowItem(int showNo, DateTime date, string name, string comment)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE [" + Year + "_show] SET date = @dateparam, show_name = @nameparam, show_comment = @commentparam " +
                "WHERE show_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", showNo));
            query.Parameters.Add(new SQLiteParameter("@dateparam", DateToString(date)));
            query.Parameters.Add(new SQLiteParameter("@nameparam", name));
            query.Parameters.Add(new SQLiteParameter("@commentparam", comment));
            query.Connection = ClubConn;

            return DoTheNonQuery(query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteShowItem(int showNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM [" + Year + "_show] WHERE show_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", showNo));
            query.Connection = ClubConn;

            return DoTheNonQuery(query);
        }

        #endregion
    }
}
