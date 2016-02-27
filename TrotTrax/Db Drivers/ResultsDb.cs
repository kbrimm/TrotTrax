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
        // Interactions for <year>_rider table

        #region Select Statements

        public ResultItem GetResultItem(int riderNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT rider_no, rider_first, rider_last, rider_dob, phone, email, member FROM " + year +
                "_rider WHERE rider_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", riderNo));
            SQLiteDataReader reader = DoTheReader(clubConn, query);
            ResultItem item = new ResultItem();

            while (reader.Read())
            {
                item.backNo = reader.GetInt32(0);
                item.riderNo = reader.GetInt32(1);
                item.rider = reader.GetString(2) + " " + reader.GetString(3);
                item.horseNo = reader.GetInt32(4);
                item.horse = reader.GetString(5);
                item.showNo = reader.GetInt32(6);
                item.showDate = reader.GetString(7);
                item.classNo = reader.GetInt32(8);
                item.className = reader.GetString(9);
                item.place = reader.GetInt32(10);
                item.time = reader.GetDecimal(11);
                item.points = reader.GetInt32(12);
                item.payIn = reader.GetDecimal(13);
                item.payOut = reader.GetDecimal(14);
            }
            reader.Close();
            clubConn.Close();
            return item;
        }

        // Optional: sort (default is back_no)
        public List<ResultItem> GetResultItemList(string sort)
        {
            // Case statment for sort column
            switch (sort)
            {
                case "rider": sort = "r.rider_last, r.rider_first"; break;
                case "horse": sort = "h.horse_name"; break;
                case "place": sort = "t.place"; break;
                case "class": sort = "c.class_no"; break;
                case "date": sort = "s.date"; break;
                default: sort = "back_no"; break;
            }

            string query = "SELECT b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name, " +
                "s.show_no, s.show_date, c.class_no, c.class_name, t.place, t.time, t.points, t.pay_in, t.pay_out" +
                "FROM " + year + "_result AS t JOIN " + year + "_backNo AS b ON t.back_no = b.back_no " +
                "JOIN " + year + "_rider AS r ON b.rider_no = r.rider_no " +
                "JOIN " + year + "_horse AS h ON b.horse_no = h.horse_no " +
                "JOIN " + year + "_class AS c ON t.class_no = c.class_no " +
                "JOIN " + year + "_show AS s ON t.show_no = s.show_no " + "ORDER BY " + sort + ";";
            SQLiteDataReader reader = DoTheReader(clubConn, query);
            List<ResultItem> resultItemList = new List<ResultItem>();
            ResultItem item;

            reader = DoTheReader(clubConn, query);
            while (reader.Read())
            {
                item = new ResultItem();
                item.backNo = reader.GetInt32(0);
                item.riderNo = reader.GetInt32(1);
                item.rider = reader.GetString(2) + " " + reader.GetString(3);
                item.horseNo = reader.GetInt32(4);
                item.horse = reader.GetString(5);
                item.showNo = reader.GetInt32(6);
                item.showDate = reader.GetString(7);
                item.classNo = reader.GetInt32(8);
                item.className = reader.GetString(9);
                item.place = reader.GetInt32(10);
                item.time = reader.GetDecimal(11);
                item.points = reader.GetInt32(12);
                item.payIn = reader.GetDecimal(13);
                item.payOut = reader.GetDecimal(14);

                resultItemList.Add(item);
            }
            reader.Close();
            clubConn.Close();
            return resultItemList;
        }

        #endregion

        // TO DO: THIS

        #region Insert Statements

        public bool AddResultItem(int riderNo, string first, string last, DateTime dob, string phone, string email, bool member)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO " + year + "_rider " +
                "(rider_no, rider_first, rider_last, rider_dob, phone, email, member) " +
                "VALUES (@noparam, @firstparam, @lastparam, @dobparam, @phoneparam, @emailparam, @memberparam)";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", riderNo));
            query.Parameters.Add(new SQLiteParameter("@firstparam", first));
            query.Parameters.Add(new SQLiteParameter("@lastparam", last));
            query.Parameters.Add(new SQLiteParameter("@dobparam", DateToString(dob)));
            query.Parameters.Add(new SQLiteParameter("@phoneparam", phone));
            query.Parameters.Add(new SQLiteParameter("@emailparam", email));
            query.Parameters.Add(new SQLiteParameter("@member", BoolToInt(member)));

            return DoTheNonQuery(clubConn, query);
        }

        #endregion

        #region Update Statements

        public bool UpdateResultItem(int riderNo, string first, string last, DateTime dob, string phone, string email, bool member)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE " + year + "_rider SET rider_no = @noparam, rider_first @firstparam, " +
                "rider_last = @lastparam, rider_dob = @dobparam, phone = @phoneparam, email = @emailparam, member = @memberparam) " +
                "WHERE rider_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", riderNo));
            query.Parameters.Add(new SQLiteParameter("@firstparam", first));
            query.Parameters.Add(new SQLiteParameter("@lastparam", last));
            query.Parameters.Add(new SQLiteParameter("@dobparam", DateToString(dob)));
            query.Parameters.Add(new SQLiteParameter("@phoneparam", phone));
            query.Parameters.Add(new SQLiteParameter("@emailparam", email));
            query.Parameters.Add(new SQLiteParameter("@member", BoolToInt(member)));

            return DoTheNonQuery(clubConn, query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteResultItem(int riderNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM " + year + "_rider WHERE rider_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", riderNo));

            return DoTheNonQuery(clubConn, query);
        }

        #endregion
    }
}
