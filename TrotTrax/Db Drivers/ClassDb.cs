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
        // Interactions for <year>_class table

        #region Select Statements

        public ClassItem GetClassItem(int classNo)
        {
            // Construct and execute the query
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT class_no, category_no, class_name, fee FROM [" + Year +
                "_class] WHERE class_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", classNo));
            query.Connection = ClubConn;
            SQLiteDataReader reader = DoTheReader(query);

            // Read the results
            ClassItem item = new ClassItem();
            while (reader.Read())
            {
                item.No = reader.GetInt32(0);
                item.CatNo = reader.GetInt32(1);
                item.Name = reader.GetString(2);
                item.Fee = reader.GetDecimal(3);
            }
            reader.Close();
            ClubConn.Close();
            return item;
        }

        //Optional: sort (default is class_no)
        public List<ClassItem> GetClassItemList(ClassSort sort = ClassSort.Default)
        {
            // Case statment for sort column
            string sortString;
            switch (sort)
            {
                case ClassSort.Name: sortString = "class_name"; break;
                case ClassSort.Category: sortString = "category_no"; break;
                default: sortString = "class_no"; break;
            }

            // Construct and execute the query
            string query = "SELECT class_no, category_no, class_name, fee FROM [" + Year +
                "_class] ORDER BY " + sortString + ";";
            SQLiteDataReader reader = DoTheReader(ClubConn, query);
            List<ClassItem> classItemList = new List<ClassItem>();
            ClassItem item;

            // Read the results
            reader = DoTheReader(ClubConn, query);
            while (reader.Read())
            {
                item = new ClassItem();

                item.No = reader.GetInt32(0);
                item.CatNo = reader.GetInt32(1);
                item.Name = reader.GetString(2);
                item.Fee = reader.GetDecimal(3);

                classItemList.Add(item);
            }
            reader.Close();
            ClubConn.Close();
            return classItemList;
        }

        #endregion

        #region Insert Statements

        public bool AddClassItem(int classNo, int category, string name, decimal fee)
        {
            // Construct and execute the query
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "INSERT INTO [" + Year + "_class] " +
                "(class_no, category_no, class_name, fee) " +
                "VALUES (@noparam, @catparam, @nameparam, @feeparam);";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", classNo));
            query.Parameters.Add(new SQLiteParameter("@catparam", category));
            query.Parameters.Add(new SQLiteParameter("@nameparam", name));
            query.Parameters.Add(new SQLiteParameter("@feeparam", fee));
            query.Connection = ClubConn;
            return DoTheNonQuery(query);
        }

        #endregion

        #region Update Statements

        public bool UpdateClassItem(int classNo, int category, string name, decimal fee)
        {
            // Construct and execute the query
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE [" + Year + "_class] SET category_no = @catparam, class_name = @nameparam, fee = @feeparam " +
                "WHERE class_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", classNo));
            query.Parameters.Add(new SQLiteParameter("@catparam", category));
            query.Parameters.Add(new SQLiteParameter("@nameparam", name));
            query.Parameters.Add(new SQLiteParameter("@feeparam", fee));
            query.Connection = ClubConn;
            return DoTheNonQuery(query);
        }

        #endregion

        #region Delete Statements

        public bool DeleteClassItem(int classNo)
        {
            // Construct and execute the query
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "DELETE FROM [" + Year + "_class] WHERE class_no = @noparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@noparam", classNo));
            query.Connection = ClubConn;
            return DoTheNonQuery(query);
        }

        #endregion
    }
}
