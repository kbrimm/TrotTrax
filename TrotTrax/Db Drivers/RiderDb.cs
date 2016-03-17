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

        public RiderItem GetRiderItem(int riderNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT rider_no, rider_first, rider_last, rider_dob, phone, email, member, rider_comment " +
                "FROM [" + year + "_rider] WHERE rider_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", riderNo));
            query.Connection = clubConn;
            SQLiteDataReader reader = DoTheReader(query);
            RiderItem item = new RiderItem();

            while (reader.Read())
            {
                item.no = reader.GetInt32(0);
                item.firstName = reader.GetString(1);
                item.lastName = reader.GetString(2);
                item.dob = StringToDate(reader.GetString(3));
                item.phone = reader.GetString(4);
                item.email = reader.GetString(5);
                item.member = (bool)IntToBool(reader.GetInt32(6));
                item.comments = reader.GetString(7);
            }
            reader.Close();
            clubConn.Close();
            return item;
        }

        // Optional: sort (default is rider_last)
        public List<RiderItem> GetRiderItemList(RiderSort sort = RiderSort.Default)
        {
            // Case statment for sort column
            string sortString;
            switch (sort)
            {
                case RiderSort.Number: sortString = "rider_no"; break;
                case RiderSort.FirstName: sortString = "rider_first, rider_last"; break;
                case RiderSort.BirthDate: sortString = "rider_dob, rider_last"; break;
                default: sortString = "rider_last, rider_first"; break;
            }

            string query = "SELECT rider_no, rider_first, rider_last, rider_dob, phone, email, member, rider_comment FROM [" + 
                year + "_rider] ORDER BY " + sortString + ";";
            SQLiteDataReader reader = DoTheReader(clubConn, query);
            List<RiderItem> riderItemList = new List<RiderItem>();
            RiderItem item;

            reader = DoTheReader(clubConn, query);
            while (reader.Read())
            {
                item = new RiderItem();
                item.no = reader.GetInt32(0);
                item.firstName = reader.GetString(1);
                item.lastName = reader.GetString(2);
                item.dob = StringToDate(reader.GetString(3));
                item.phone = reader.GetString(4);
                item.email = reader.GetString(5);
                item.member = (bool)IntToBool(reader.GetInt32(6));
                item.comments = reader.GetString(7);
                riderItemList.Add(item);
            }
            reader.Close();
            clubConn.Close();
            return riderItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddRiderItem(int riderNo, string first, string last, DateTime dob, string phone, string email, 
            bool member, string comment)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO [" + year + "_rider] " +
                "(rider_no, rider_first, rider_last, rider_dob, phone, email, member, rider_comment) " +
                "VALUES (@noparam, @firstparam, @lastparam, @dobparam, @phoneparam, @emailparam, @memberparam, @commentparam)";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", riderNo));
            query.Parameters.Add(new SQLiteParameter("@firstparam", first));
            query.Parameters.Add(new SQLiteParameter("@lastparam", last));
            query.Parameters.Add(new SQLiteParameter("@dobparam", DateToString(dob)));
            query.Parameters.Add(new SQLiteParameter("@phoneparam", phone));
            query.Parameters.Add(new SQLiteParameter("@emailparam", email));
            query.Parameters.Add(new SQLiteParameter("@memberparam", BoolToInt(member)));
            query.Parameters.Add(new SQLiteParameter("@commentparam", comment));
            query.Connection = clubConn;

            return DoTheNonQuery(query);
        }

        #endregion

        #region Update Statements

        public bool UpdateRiderItem(int riderNo, string first, string last, DateTime dob, string phone, string email, 
            bool member, string comment)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE [" + year + "_rider] SET rider_no = @noparam, rider_first = @firstparam, " +
                "rider_last = @lastparam, rider_dob = @dobparam, phone = @phoneparam, email = @emailparam, member = @memberparam, " +
                "rider_comment = @commentparam WHERE rider_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", riderNo));
            query.Parameters.Add(new SQLiteParameter("@firstparam", first));
            query.Parameters.Add(new SQLiteParameter("@lastparam", last));
            query.Parameters.Add(new SQLiteParameter("@dobparam", DateToString(dob)));
            query.Parameters.Add(new SQLiteParameter("@phoneparam", phone));
            query.Parameters.Add(new SQLiteParameter("@emailparam", email));
            query.Parameters.Add(new SQLiteParameter("@memberparam", BoolToInt(member)));
            query.Parameters.Add(new SQLiteParameter("@commentparam", comment));
            query.Connection = clubConn;

            return DoTheNonQuery(query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteRiderItem(int riderNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM [" + year + "_rider] WHERE rider_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", riderNo));
            query.Connection = clubConn;

            return DoTheNonQuery(query);
        }

        #endregion
    }
}
