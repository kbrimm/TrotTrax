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
        #region Select Statements
        public List<BackNoItem> GetBackNoItemList(string database, int year, string sort)
        {
            SQLiteDataReader reader;
            BackNoItem item;
            List<BackNoItem> backNoItemList = new List<BackNoItem>();
            string join = database + "." + year + "_backNo AS b " +
                "JOIN " + database + "." + year + "_rider AS r ON b.rider_no = r.rider_no " +
                "JOIN " + database + "." + year + "_horse AS h ON b.horse_no = h.horse_no";

            if (sort == "rider_last")
                sort = "r.rider_last, r.rider_first";
            else if (sort == "horse_name")
                sort = "h.horse_name";
            else
                sort = "b.back_no";

            reader = GetJoinedReader(join, "b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name", String.Empty, sort);
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
            connection.Close();
            return backNoItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddBackNo(int backNo, int riderNo, int horseNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO " + year + "_backNo (back_no, rider_no, horse_no) " +
                "VALUES (@backparam, @riderparam, @horseparam);";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@backparam", backNo));
            query.Parameters.Add(new SQLiteParameter("@riderparam", riderNo));
            query.Parameters.Add(new SQLiteParameter("@horseparam", horseNo));

            return DoTheNonQuery(clubConn, query);
        }

        #endregion


    }
}
