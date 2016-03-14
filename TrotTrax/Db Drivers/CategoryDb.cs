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
        // Interactions for <year>_category table

        #region Select Statements

        public CategoryItem GetCategoryItem(int catNo)
        {
            // Construct and execute the query
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT category_no, category_name, timed FROM [" + year +
                "_category] WHERE category_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", catNo));
            query.Connection = clubConn;
            SQLiteDataReader reader = DoTheReader(query);

            // Read the results
            CategoryItem item = new CategoryItem();
            while (reader.Read())
            {
                item.no = reader.GetInt32(0);
                item.name = reader.GetString(1);
                item.timed = (bool)IntToBool(reader.GetInt32(2));
            }
            reader.Close();
            clubConn.Close();
            return item;
        }

        // Optional: sort (default is category_no)
        public List<CategoryItem> GetCategoryItemList(CategorySort sort = CategorySort.Default)
        {
            // Case statment for sort column
            string sortString;
            switch (sort)
            {
                case CategorySort.Name: sortString = "category_name"; break;
                case CategorySort.Timed: sortString = "timed"; break;
                default: sortString = "category_no"; break;
            }

            // Construct and execute the query
            string query = "SELECT category_no, category_name, timed FROM [" + year +
                "_category] ORDER BY " + sortString + ";";
            SQLiteDataReader reader = DoTheReader(clubConn, query);
            List<CategoryItem> catItemList = new List<CategoryItem>();
            CategoryItem item;

            // Read the results
            while (reader.Read())
            {
                item = new CategoryItem();
                item.no = reader.GetInt32(0);
                item.name = reader.GetString(1);
                item.timed = (bool)IntToBool(reader.GetInt32(2));
                catItemList.Add(item);
            }
            reader.Close();
            clubConn.Close();
            return catItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddCategoryItem(int catNo, string catName, bool timed)
        {
            // Construct and execute the query
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO [" + year + "_category] " +
                "(category_no, category_name, timed) " +
                "VALUES (@noparam, @nameparam, @timedparam)";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", catNo));
            query.Parameters.Add(new SQLiteParameter("@nameparam", catName));
            query.Parameters.Add(new SQLiteParameter("@timedparam", BoolToInt(timed)));
            query.Connection = clubConn;

            return DoTheNonQuery(query);
        }

        #endregion

        #region Update Statements

        public bool UpdateCategoryItem(int catNo, string catName, bool timed)
        {
            // Construct and execute the query
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE [" + year + "_category] SET category_name = @nameparam, timed = @timedparam " +
                "WHERE category_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", catNo));
            query.Parameters.Add(new SQLiteParameter("@nameparam", catName));
            query.Parameters.Add(new SQLiteParameter("@timedparam", BoolToInt(timed)));
            query.Connection = clubConn;

            return DoTheNonQuery(query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteCategoryItem(int classNo)
        {
            // Construct and execute the query
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM [" + year + "_category] WHERE category_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", classNo));
            query.Connection = clubConn;

            return DoTheNonQuery(query);
        }

        #endregion
    }
}
