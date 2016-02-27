/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
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
            query.CommandText = "SELECT show_no, date, show_name, show_comment FROM " + year + "_show WHERE show_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", showNo));
            SQLiteDataReader reader = DoTheReader(clubConn, query);
            ShowItem item = new ShowItem();

            while (reader.Read())
            {
                item.no = reader.GetInt32(0);
                item.date = StringToDate(reader.GetString(1));
                item.name = reader.GetString(2);
                item.comments = reader.GetString(3);
            }
            reader.Close();
            clubConn.Close();
            return item;
        }

        // Optional: sort (default is date)
        public List<ShowItem> GetShowItemList(string sort)
        {
            // Case statment for sort column
            switch(sort)
            {
                case "showNo": sort = "show_no"; break;
                case "name": sort = "show_name"; break;
                default: sort = "date"; break;
            }

            string query = "SELECT show_no, date, show_name, show_comment FROM " + year + "_show ORDER BY " + sort + ";";
            SQLiteDataReader reader = DoTheReader(clubConn, query);
            List<ShowItem> showItemList = new List<ShowItem>();
            ShowItem item;

            reader = DoTheReader(clubConn, query);
            while (reader.Read())
            {
                item = new ShowItem();
                item.no = reader.GetInt32(0);
                item.date = StringToDate(reader.GetString(1));
                item.name = reader.GetString(2);
                item.comments = reader.GetString(3);
                showItemList.Add(item);
            }
            reader.Close();
            clubConn.Close();
            return showItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddShowItem(int showNo, DateTime date, string name, string comment)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO " + year + "_show (show_no, date, show_name, show_comment) " +
                "VALUES (@noparam, @dateparam, @nameparam, @commentparam)";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", showNo));
            query.Parameters.Add(new SQLiteParameter("@dateparam", DateToString(date)));
            query.Parameters.Add(new SQLiteParameter("@nameparam", name));
            query.Parameters.Add(new SQLiteParameter("@commentparam", comment));

            return DoTheNonQuery(clubConn, query);
        }

        #endregion

        #region Update Statements

        public bool UpdateShowItem(int showNo, DateTime date, string name, string comment)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE " + year + "_show SET date = @dateparam, show_name = @nameparam, show_comment = @commentparam " +
                "WHERE show_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", showNo));
            query.Parameters.Add(new SQLiteParameter("@dateparam", DateToString(date)));
            query.Parameters.Add(new SQLiteParameter("@nameparam", name));
            query.Parameters.Add(new SQLiteParameter("@commentparam", comment));

            return DoTheNonQuery(clubConn, query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteShowItem(int showNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM " + year + "_show WHERE show_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", showNo));

            return DoTheNonQuery(clubConn, query);
        }

        #endregion
    }
}
