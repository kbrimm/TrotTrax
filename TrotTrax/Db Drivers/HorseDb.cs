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
        // Interactions for <year>_horse table

        #region Select Statements

        public HorseItem GetHorseItem(int horseNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT horse_no, horse_name, horse_call, height, owner_name FROM [" + year +
                "_horse] WHERE horse_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", horseNo));
            query.Connection = clubConn;
            SQLiteDataReader reader = DoTheReader(query);
            HorseItem item = new HorseItem();

            while (reader.Read())
            {
                item = new HorseItem();
                item.no = reader.GetInt32(0);
                item.name = reader.GetString(1);
                item.callName = reader.GetString(2);
                item.height = reader.GetDecimal(3);
                item.ownerName = reader.GetString(4);
            }
            reader.Close();
            clubConn.Close();
            return item;
        }

        // Optional: sort (default is horse_name)
        public List<HorseItem> GetHorseItemList(HorseSort sort = HorseSort.Default)
        {
            // Case statment for sort column
            string sortString;
            switch (sort)
            {
                case HorseSort.Owner: sortString = "owner_name, horse_name"; break;
                default: sortString = "horse_name"; break;
            }

            string query = "SELECT horse_no, horse_name, horse_call, height, owner_name FROM [" + year +
                "_horse] ORDER BY " + sortString + ";";
            SQLiteDataReader reader = DoTheReader(clubConn, query);
            List<HorseItem> horseItemList = new List<HorseItem>();
            HorseItem item;

            reader = DoTheReader(clubConn, query);
            while (reader.Read())
            {
                item = new HorseItem();
                item.no = reader.GetInt32(0);
                item.name = reader.GetString(1);
                item.callName = reader.GetString(2);
                item.height = reader.GetDecimal(3);
                item.ownerName = reader.GetString(4);
                horseItemList.Add(item);
            }
            reader.Close();
            clubConn.Close();
            return horseItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddHorseItem(int horseNo, string name, string callName, decimal height, string owner)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO [" + year + "_horse] " +
                "(horse_no, horse_name, horse_call, height, owner_name) " +
                "VALUES (@noparam, @nameparam, @callparam, @heightparam, @ownerparam)";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", horseNo));
            query.Parameters.Add(new SQLiteParameter("@nameparam", name));
            query.Parameters.Add(new SQLiteParameter("@callparam", callName));
            query.Parameters.Add(new SQLiteParameter("@height", height));
            query.Parameters.Add(new SQLiteParameter("@ownerparam", owner));
            query.Connection = clubConn;
            return DoTheNonQuery(query);
        }

        #endregion

        #region Update Statements

        public bool UpdateHorseItem(int horseNo, string name, string callName, decimal height, string owner)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE [" + year + "_horse] SET horse_no = @noparam, horse_name = @nameparam, " +
                "horse_call = @callparam, height = @heightparam, owner = @ownerparam " +
                "WHERE horse_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@nameparam", name));
            query.Parameters.Add(new SQLiteParameter("@callparam", callName));
            query.Parameters.Add(new SQLiteParameter("@height", height));
            query.Parameters.Add(new SQLiteParameter("@ownerparam", owner));
            query.Parameters.Add(new SQLiteParameter("@noparam", horseNo));
            query.Connection = clubConn;
            return DoTheNonQuery(query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteHorseItem(int horseNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM [" + year + "_horse] WHERE horse_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", horseNo));
            query.Connection = clubConn;
            return DoTheNonQuery(query);
        }

        #endregion
    }
}
