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
        public ClassItem GetClassItem(string database, int year, int classNo)
        {
            SQLiteDataReader reader;
            ClassItem item = new ClassItem();

            reader = GetReader(database, year + "_class", "class_no, category_no, class_name, fee", "class_no=" + classNo, "class_no");
            while (reader.Read())
            {
                item.no = reader.GetInt32(0);
                item.catNo = reader.GetInt32(1);
                item.name = reader.GetString(2);
                item.fee = reader.GetDecimal(3);
            }
            reader.Close();
            connection.Close();
            return item;
        }

        //Optional: sort (default is class_name)
        public List<ClassItem> GetClassItemList(string database, int year, string sort)
        {
            SQLiteDataReader reader;
            ClassItem item;
            List<ClassItem> classItemList = new List<ClassItem>();

            if (sort == String.Empty)
                sort = "class_no";

            reader = GetReader(database, year + "_class", "class_no, category_no, class_name, fee", String.Empty, sort);
            while (reader.Read())
            {
                item = new ClassItem();
                item.no = reader.GetInt32(0);
                item.catNo = reader.GetInt32(1);
                item.name = reader.GetString(2);
                item.fee = reader.GetDecimal(3);

                classItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return classItemList;
        }
    }
}
