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
        // Interactions for <year>_backNo table

        #region Select Statements

        public BackNoItem GetBackNoItem(int backNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name FROM ["
                + Year + "_back] AS b JOIN [" + Year + "_rider] AS r ON b.rider_no = r.rider_no " +
                "JOIN [" + Year + "_horse] AS h ON b.horse_no = h.horse_no WHERE back_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", backNo));
            query.Connection = ClubConn;
            SQLiteDataReader reader = DoTheReader(query);
            BackNoItem item = new BackNoItem();

            while (reader.Read())
            {
                item.No = reader.GetInt32(0);
                item.RiderNo = reader.GetInt32(1);
                item.RiderFirst = reader.GetString(2);
                item.RiderLast = reader.GetString(3);
                item.HorseNo = reader.GetInt32(4);
                item.Horse = reader.GetString(5);
            }
            reader.Close();
            ClubConn.Close();
            return item;
        }

        //Optional: sort (default is backNo_no)
        public List<BackNoItem> GetBackNoItemList(BackNoSort sort = BackNoSort.Default)
        {
            // Case statment for sort column
            string sortString;
            switch (sort)
            {
                case BackNoSort.Horse: sortString = "h.horse_name"; break;
                case BackNoSort.RiderFirst: sortString = "r.rider_first, r.rider_last"; break;
                case BackNoSort.RiderLast: sortString = "r.rider_last, r.rider_first"; break;
                default: sortString = "b.back_no"; break;
            }

            string query = "SELECT b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name FROM ["
                + Year + "_back] AS b JOIN [" + Year + "_rider] AS r ON b.rider_no = r.rider_no " +
                "JOIN [" + Year + "_horse] AS h ON b.horse_no = h.horse_no ORDER BY " + sortString + ";";
            SQLiteDataReader reader = DoTheReader(ClubConn, query);
            List<BackNoItem> backNoItemList = new List<BackNoItem>();
            BackNoItem item;

            reader = DoTheReader(ClubConn, query);
            while (reader.Read())
            {
                item = new BackNoItem();

                item.No = reader.GetInt32(0);
                item.RiderNo = reader.GetInt32(1);
                item.RiderFirst = reader.GetString(2);
                item.RiderLast = reader.GetString(3);
                item.HorseNo = reader.GetInt32(4);
                item.Horse = reader.GetString(5);

                backNoItemList.Add(item);
            }
            reader.Close();
            ClubConn.Close();
            return backNoItemList;
        }

        public List<BackNoItem> GetBackNoItemList(BackNoFilter filter, int number, BackNoSort sort = BackNoSort.Default)
        {
            // Case statment for sort column
            string sortString;
            switch (sort)
            {
                case BackNoSort.Horse: sortString = "h.horse_name"; break;
                case BackNoSort.RiderFirst: sortString = "r.rider_first, r.rider_last"; break;
                case BackNoSort.RiderLast: sortString = "r.rider_last, r.rider_first"; break;
                default: sortString = "b.back_no"; break;
            }
            
            // Case statment for filter column
            string filterString;
            switch (filter)
            {
                case BackNoFilter.Horse: filterString = "h.horse_no"; break;
                case BackNoFilter.Rider: filterString = "r.rider_no"; break;
                default: filterString = "b.back_no"; break;
            }

            string query = "SELECT b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name FROM ["
                + Year + "_back] AS b JOIN [" + Year + "_rider] AS r ON b.rider_no = r.rider_no " +
                "JOIN [" + Year + "_horse] AS h ON b.horse_no = h.horse_no WHERE " + filterString + " = " + number +
                " ORDER BY " + sortString + ";";
            SQLiteDataReader reader = DoTheReader(ClubConn, query);
            List<BackNoItem> backNoItemList = new List<BackNoItem>();
            BackNoItem item;

            reader = DoTheReader(ClubConn, query);
            while (reader.Read())
            {
                item = new BackNoItem();

                item.No = reader.GetInt32(0);
                item.RiderNo = reader.GetInt32(1);
                item.RiderFirst = reader.GetString(2);
                item.RiderLast = reader.GetString(3);
                item.HorseNo = reader.GetInt32(4);
                item.Horse = reader.GetString(5);

                backNoItemList.Add(item);
            }
            reader.Close();
            ClubConn.Close();
            return backNoItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddBackNoItem(int backNo, int riderNo, int horseNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO [" + Year + "_back] " +
                "(back_no, rider_no, horse_no) " +
                "VALUES (@noparam, @riderparam, @horseparam)";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", backNo));
            query.Parameters.Add(new SQLiteParameter("@riderparam", riderNo));
            query.Parameters.Add(new SQLiteParameter("@horseparam", horseNo));
            query.Connection = ClubConn;

            return DoTheNonQuery(query);
        }

        #endregion

        #region Update Statements

        public bool UpdateBackNoItem(int backNo, int riderNo, int horseNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE [" + Year + "_back] SET rider_no = @riderparam, horse_no = @horseparam " +
                "WHERE back_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", backNo));
            query.Parameters.Add(new SQLiteParameter("@riderparam", riderNo));
            query.Parameters.Add(new SQLiteParameter("@horseparam", horseNo));
            query.Connection = ClubConn;

            return DoTheNonQuery(query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteBackNoItem(int backNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM [" + Year + "_back] WHERE back_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", backNo));
            query.Connection = ClubConn;

            return DoTheNonQuery(query);
        }

        #endregion
    }
}
