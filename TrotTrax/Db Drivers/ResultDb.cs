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
        // Interactions for <year>_result table

        #region Select Statements

        public ResultItem GetResultItem(int riderNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT rider_no, rider_first, rider_last, rider_dob, phone, email, member FROM [" + Year +
                "_rider] WHERE rider_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", riderNo));
            query.Connection = ClubConn;
            SQLiteDataReader reader = DoTheReader(query);
            ResultItem item = new ResultItem();

            while (reader.Read())
            {
                item.BackNo = reader.GetInt32(0);
                item.RiderNo = reader.GetInt32(1);
                item.Rider = reader.GetString(2) + " " + reader.GetString(3);
                item.HorseNo = reader.GetInt32(4);
                item.Horse = reader.GetString(5);
                item.ShowNo = reader.GetInt32(6);
                item.ShowDate = reader.GetString(7);
                item.ClassNo = reader.GetInt32(8);
                item.ClassName = reader.GetString(9);
                item.Place = reader.GetInt32(10);
                item.Time = reader.GetDecimal(11);
                item.Points = reader.GetInt32(12);
                item.PayIn = reader.GetDecimal(13);
                item.PayOut = reader.GetDecimal(14);
            }
            reader.Close();
            ClubConn.Close();
            return item;
        }

        // Optional: sort (default is back_no)
        public List<ResultItem> GetResultItemList(ResultSort sort = ResultSort.Default)
        {
            // Case statment for sort column
            string sortString = null;
            switch (sort)
            {
                case ResultSort.BackNo: sortString = "b.back_no, s.date, c.class_no"; break;
                case ResultSort.Class: sortString = "c.class_no"; break;
                case ResultSort.Horse: sortString = "h.horse_no"; break;
                case ResultSort.Place: sortString = "t.place"; break;
                case ResultSort.Rider: sortString = "r.rider_last, r.rider_first, s.date, c.class_no, t.place"; break;
                case ResultSort.Show: sortString = "s.date, c.class_no"; break;
                default: sortString = "back_no"; break;
            }

            string query = "SELECT b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name, " +
                "s.show_no, s.date, c.class_no, c.class_name, t.place, t.time, t.points, t.paid_in, t.paid_out " +
                "FROM [" + Year + "_result] AS t JOIN [" + Year + "_backNo] AS b ON t.back_no = b.back_no " +
                "JOIN [" + Year + "_rider] AS r ON b.rider_no = r.rider_no " +
                "JOIN [" + Year + "_horse] AS h ON b.horse_no = h.horse_no " +
                "JOIN [" + Year + "_class] AS c ON t.class_no = c.class_no " +
                "JOIN [" + Year + "_show] AS s ON t.show_no = s.show_no " + "ORDER BY " + sort + ";";
            SQLiteDataReader reader = DoTheReader(ClubConn, query);
            List<ResultItem> resultItemList = new List<ResultItem>();
            ResultItem item;

            reader = DoTheReader(ClubConn, query);
            while (reader.Read())
            {
                item = new ResultItem();
                item.BackNo = reader.GetInt32(0);
                item.RiderNo = reader.GetInt32(1);
                item.Rider = reader.GetString(2) + " " + reader.GetString(3);
                item.HorseNo = reader.GetInt32(4);
                item.Horse = reader.GetString(5);
                item.ShowNo = reader.GetInt32(6);
                item.ShowDate = reader.GetString(7);
                item.ClassNo = reader.GetInt32(8);
                item.ClassName = reader.GetString(9);
                item.Place = reader.GetInt32(10);
                item.Time = reader.GetDecimal(11);
                item.Points = reader.GetInt32(12);
                item.PayIn = reader.GetDecimal(13);
                item.PayOut = reader.GetDecimal(14);

                resultItemList.Add(item);
            }
            reader.Close();
            ClubConn.Close();
            return resultItemList;
        }

        // Optional: sort (default is back_no)
        public List<ResultItem> GetResultItemList(ResultFilter filter, int number, ResultSort sort = ResultSort.Default)
        {
            // Case statment for sort column
            string sortString = null;
            switch (sort)
            {
                case ResultSort.Class: sortString = "c.class_no"; break;
                case ResultSort.Horse: sortString = "h.horse_no"; break;
                case ResultSort.Place: sortString = "t.place"; break;
                case ResultSort.Rider: sortString = "r.rider_last, r.rider_first, s.date, c.class_no, t.place"; break;
                case ResultSort.Show: sortString = "s.date, c.class_no"; break;
                default: sortString = "b.back_no, s.date, c.class_no"; break;
            }

            string filterString = null;
            switch (filter)
            {
                case ResultFilter.BackNo: filterString = "b.back_no"; break;
                case ResultFilter.Class: filterString = "c.class_no"; break;
                case ResultFilter.Horse: filterString = "h.horse_no"; break;
                case ResultFilter.Rider: filterString = "r.rider_no"; break;
                case ResultFilter.Show: filterString = "s.show_no"; break;
                default: sortString = "b.back_no"; break;
            }

            string query = "SELECT b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name, " +
                "s.show_no, s.date, c.class_no, c.class_name, t.place, t.time, t.points, t.paid_in, t.paid_out " +
                "FROM [" + Year + "_result] AS t JOIN [" + Year + "_back] AS b ON t.back_no = b.back_no " +
                "JOIN [" + Year + "_rider] AS r ON b.rider_no = r.rider_no " +
                "JOIN [" + Year + "_horse] AS h ON b.horse_no = h.horse_no " +
                "JOIN [" + Year + "_class] AS c ON t.class_no = c.class_no " +
                "JOIN [" + Year + "_show] AS s ON t.show_no = s.show_no " + 
                "WHERE " + filterString + " = " + number + " " +
                "ORDER BY " + sortString + ";";
            SQLiteDataReader reader = DoTheReader(ClubConn, query);
            List<ResultItem> resultItemList = new List<ResultItem>();
            ResultItem item;

            reader = DoTheReader(ClubConn, query);
            while (reader.Read())
            {
                item = new ResultItem();
                item.BackNo = reader.GetInt32(0);
                item.RiderNo = reader.GetInt32(1);
                item.Rider = reader.GetString(2) + " " + reader.GetString(3);
                item.HorseNo = reader.GetInt32(4);
                item.Horse = reader.GetString(5);
                item.ShowNo = reader.GetInt32(6);
                item.ShowDate = reader.GetString(7);
                item.ClassNo = reader.GetInt32(8);
                item.ClassName = reader.GetString(9);
                item.Place = reader.GetInt32(10);
                item.Time = reader.GetDecimal(11);
                item.Points = reader.GetInt32(12);
                item.PayIn = reader.GetDecimal(13);
                item.PayOut = reader.GetDecimal(14);

                resultItemList.Add(item);
            }
            reader.Close();
            ClubConn.Close();
            return resultItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddResultItem(int riderNo, string first, string last, DateTime dob, string phone, string email, bool member)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO [" + Year + "_rider] " +
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
            query.Connection = ClubConn;

            return DoTheNonQuery(query);
        }

        #endregion

        #region Update Statements

        public bool UpdateResultItem(int riderNo, string first, string last, DateTime dob, string phone, string email, bool member)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE [" + Year + "_rider] SET rider_no = @noparam, rider_first @firstparam, " +
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
            query.Connection = ClubConn;

            return DoTheNonQuery(query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteResultItem(int riderNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM [" + Year + "_rider] WHERE rider_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", riderNo));
            query.Connection = ClubConn;

            return DoTheNonQuery(query);
        }

        #endregion
    }
}
