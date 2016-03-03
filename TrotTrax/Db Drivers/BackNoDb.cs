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
    // Methods for interacting with the <club_name>.<show_year>_backNo table
    public partial class DBDriver
    {
        // Interactions for <year>_backNo table

        #region Select Statements

        public BackNoItem GetBackNoItem(int backNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name FROM "
                + year + "_backNo AS b JOIN " + year + "_rider AS r ON b.rider_no = r.rider_no " +
                "JOIN " + year + "_horse AS h ON b.horse_no = h.horse_no WHERE backNo_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", backNo));
            SQLiteDataReader reader = DoTheReader(clubConn, query);
            BackNoItem item = new BackNoItem();

            while (reader.Read())
            {
                item.no = reader.GetInt32(0);
                item.riderNo = reader.GetInt32(1);
                item.rider = reader.GetString(2) + " " + reader.GetString(3);
                item.horseNo = reader.GetInt32(4);
                item.horse = reader.GetString(5);
            }
            reader.Close();
            clubConn.Close();
            return item;
        }

        //Optional: sort (default is backNo_no)
        public List<BackNoItem> GetBackNoItemList(string sort = null)
        {
            // Case statment for sort column
            switch (sort)
            {
                case "rider": sort = "r.rider_last, r.rider_first"; break;
                case "horse": sort = "h.horse_name"; break;
                default: sort = "b.back_no"; break;
            }

            string query = "SELECT b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name FROM "
                + year + "_backNo AS b JOIN " + year + "_rider AS r ON b.rider_no = r.rider_no " +
                "JOIN " + year + "_horse AS h ON b.horse_no = h.horse_no ORDER BY " + sort + ";";
            SQLiteDataReader reader = DoTheReader(clubConn, query);
            List<BackNoItem> backNoItemList = new List<BackNoItem>();
            BackNoItem item;

            reader = DoTheReader(clubConn, query);
            while (reader.Read())
            {
                item = new BackNoItem();

                item.no = reader.GetInt32(0);
                item.riderNo = reader.GetInt32(1);
                item.rider = reader.GetString(2) + " " + reader.GetString(3);
                item.horseNo = reader.GetInt32(4);
                item.horse = reader.GetString(5);

                backNoItemList.Add(item);
            }
            reader.Close();
            clubConn.Close();
            return backNoItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddBackNoItem(int backNo, int riderNo, string horseNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO " + year + "_backNo " +
                "(backNo_no, rider_no, horse_no) " +
                "VALUES (@noparam, @riderparam, @horseparam)";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", backNo));
            query.Parameters.Add(new SQLiteParameter("@riderparam", riderNo));
            query.Parameters.Add(new SQLiteParameter("@horseparam", horseNo));

            return DoTheNonQuery(clubConn, query);
        }

        #endregion

        #region Update Statements

        public bool UpdateBackNoItem(int backNo, int riderNo, string horseNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE " + year + "_backNo SET rider_no = @riderparam, horse_no = @horseparam " +
                "WHERE backNo_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", backNo));
            query.Parameters.Add(new SQLiteParameter("@riderparam", riderNo));
            query.Parameters.Add(new SQLiteParameter("@horseparam", horseNo));

            return DoTheNonQuery(clubConn, query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteBackNoItem(int backNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM " + year + "_backNo WHERE backNo_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", backNo));

            return DoTheNonQuery(clubConn, query);
        }

        #endregion
    }
}
