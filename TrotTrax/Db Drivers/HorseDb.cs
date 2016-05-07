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
        // Interactions for <year>_horse table

        #region Select Statements

        public HorseItem GetHorseItem(int horseNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT horse_no, horse_name, horse_alt, height, owner_name, horse_comment FROM [" + Year +
                "_horse] WHERE horse_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", horseNo));
            query.Connection = ClubConn;
            SQLiteDataReader reader = DoTheReader(query);
            HorseItem item = new HorseItem();

            while (reader.Read())
            {
                item = new HorseItem();
                item.No = reader.GetInt32(0);
                item.Name = reader.GetString(1);
                item.AltName = reader.GetString(2);
                item.Height = reader.GetString(3);
                item.OwnerName = reader.GetString(4);
                item.Comments = reader.GetString(5);
            }
            reader.Close();
            ClubConn.Close();
            return item;
        }

        // Optional: sort (default is horse_name)
        public List<HorseItem> GetHorseItemList(HorseSort sort = HorseSort.Default)
        {
            // Case statment for sort column
            string sortString;
            switch (sort)
            {
                case HorseSort.Name: sortString = "horse_name"; break;
                case HorseSort.CallName: sortString = "horse_alt"; break;
                case HorseSort.Owner: sortString = "owner_name, horse_name"; break;
                default: sortString = "horse_no"; break;
            }

            string query = "SELECT horse_no, horse_name, horse_alt, height, owner_name, horse_comment FROM [" + Year +
                "_horse] ORDER BY " + sortString + ";";
            SQLiteDataReader reader = DoTheReader(ClubConn, query);
            List<HorseItem> horseItemList = new List<HorseItem>();
            HorseItem item;

            reader = DoTheReader(ClubConn, query);
            while (reader.Read())
            {
                item = new HorseItem();
                item.No = reader.GetInt32(0);
                item.Name = reader.GetString(1);
                item.AltName = reader.GetString(2);
                item.Height = reader.GetString(3);
                item.OwnerName = reader.GetString(4);
                item.Comments = reader.GetString(5);
                horseItemList.Add(item);
            }
            reader.Close();
            ClubConn.Close();
            return horseItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddHorseItem(int horseNo, string name, string altName, string height, string owner, string comment)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO [" + Year + "_horse] " +
                "(horse_no, horse_name, horse_alt, height, owner_name, horse_comment) " +
                "VALUES (@noparam, @nameparam, @altparam, @heightparam, @ownerparam, @commentparam)";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", horseNo));
            query.Parameters.Add(new SQLiteParameter("@nameparam", name));
            query.Parameters.Add(new SQLiteParameter("@altparam", altName));
            query.Parameters.Add(new SQLiteParameter("@heightparam", height));
            query.Parameters.Add(new SQLiteParameter("@ownerparam", owner));
            query.Parameters.Add(new SQLiteParameter("@commentparam", comment));
            query.Connection = ClubConn;
            return DoTheNonQuery(query);
        }

        #endregion

        #region Update Statements

        public bool UpdateHorseItem(int horseNo, string name, string altName, string height, string owner, string comment)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE [" + Year + "_horse] SET horse_no = @noparam, horse_name = @nameparam, " +
                "horse_alt = @altparam, height = @heightparam, owner_name = @ownerparam, horse_comment = @commentparam " +
                "WHERE horse_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@nameparam", name));
            query.Parameters.Add(new SQLiteParameter("@altparam", altName));
            query.Parameters.Add(new SQLiteParameter("@heightparam", height));
            query.Parameters.Add(new SQLiteParameter("@ownerparam", owner));
            query.Parameters.Add(new SQLiteParameter("@noparam", horseNo));
            query.Parameters.Add(new SQLiteParameter("@commentparam", comment));
            query.Connection = ClubConn;
            return DoTheNonQuery(query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteHorseItem(int horseNo)
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM [" + Year + "_horse] WHERE horse_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", horseNo));
            query.Connection = ClubConn;
            return DoTheNonQuery(query);
        }

        #endregion
    }
}
