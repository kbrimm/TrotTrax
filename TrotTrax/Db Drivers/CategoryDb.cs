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
        public CategoryItem GetCategoryItem(string database, int year, int catNo)
        {
            SQLiteDataReader reader;
            CategoryItem item = new CategoryItem();

            reader = GetReader(database, year + "_category", "category_no, category_name, timed", "category_no=" + catNo, "category_no");
            while (reader.Read())
            {
                item.no = reader.GetInt32(0);
                item.name = reader.GetString(1);
                item.timed = reader.GetBoolean(2);
            }
            reader.Close();
            connection.Close();
            return item;
        }

        // Optional: sort (default is category_no)
        public List<CategoryItem> GetCategoryItemList(string database, int year, string sort)
        {
            SQLiteDataReader reader;
            CategoryItem item;
            List<CategoryItem> CatItemList = new List<CategoryItem>();

            if (sort == String.Empty)
                sort = "category_no";

            reader = GetReader(database, year + "_category", "category_no, category_name, timed", String.Empty, sort);
            while (reader.Read())
            {
                item = new CategoryItem();
                item.no = reader.GetInt32(0);
                item.name = reader.GetString(1);
                item.timed = reader.GetBoolean(2);
                CatItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return CatItemList;
        }
    }
}
