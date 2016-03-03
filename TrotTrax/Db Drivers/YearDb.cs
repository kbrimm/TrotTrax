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
        // Interactions for show_year table 

        #region Select statements

        public int GetCurrentYear()
        {
            string query = "SELECT current_year FROM current LIMIT 1;";
            object response = DoTheScalar(trotTraxConn, query);
            try
            {
                return Convert.ToInt32(response);
            }
            catch
            {
                Console.WriteLine("No value found. :(");
                return 0;
            }
        }

        private int GetLatestYear()
        {
            string query;
            object response;

            query = "SELECT year FROM show_year ORDER BY year DESC LIMIT 1;";
            response = DoTheScalar(clubConn, query);

            try
            {
                return Convert.ToInt32(response);
            }
            catch
            {
                Console.WriteLine("No value found. :(");
                return 0;
            }
        }

        public List<int> GetYearItemList()
        {
            SQLiteDataReader reader;
            List<int> yearItemList = new List<int>();
            string query = "SELECT year FROM show_year ORDER BY year DESC;";

            reader = DoTheReader(trotTraxConn, query);
            while (reader.Read())
            {
                yearItemList.Add(reader.GetInt32(0));
            }
            reader.Close();
            trotTraxConn.Close();
            return yearItemList;
        }

        #endregion

        #region Insert statements

        // Creates a new year for the current club
        // Generates table set for new year
        // Adds year to show_year table
        private void AddYear(int year)
        {
            string yearInsert = "INSERT INTO show_year (year) VALUES(" + year + ");";

            // rider: rider_no int (PK), first_name VC(255), last_name VC(255), age INT, contact VC(255), member BOOLEAN
            string riderTable = "CREATE TABLE " + year + "_rider ( rider_no INTEGER NOT NULL AUTO_INCREMENT, " +
                "rider_first TEXT NOT NULL, rider_last TEXT NOT NULL, rider_dob TEXT, phone TEXT, " +
                "email TEXT, member INTEGER NOT NULL DEFAULT 0, PRIMARY KEY (rider_no) );";

            // horse: horse_no int (PK), name VC(255), nickname VC(255), height decimal(4,2)
            string horseTable = "CREATE TABLE " + year + "_horse ( horse_no INTEGER NOT NULL AUTO_INCREMENT, " +
                "horse_name TEXT NOT NULL, horse_call TEXT, height REAL, owner_name TEXT, PRIMARY KEY (horse_no) );";

            // back_no: back_no int (PK), rider_no int (FK), horse_no int (FK)
            string backNoTable = "CREATE TABLE " + year + "_backNo ( back_no INTEGER NOT NULL, " +
                "rider_no INTEGER NOT NULL, horse_no INTEGER NOT NULL, PRIMARY KEY (back_no), " +
                "FOREIGN KEY (rider_no) REFERENCES " + year + "_rider(rider_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (horse_no) REFERENCES " + year + "_horse(horse_no) ON DELETE CASCADE );";

            // show: show_no int (PK), date VC(10), description VC(255), comments VC(500)
            string showTable = "CREATE TABLE " + year + "_show ( show_no INTEGER NOT NULL AUTO_INCREMENT, " +
                "date TEXT NOT NULL, show_name TEXT, show_comment TEXT, UNIQUE (date), PRIMARY KEY (show_no) );";

            // category: category_no int (PK), description VC(255), 
            string categoryTable = "CREATE TABLE " + year + "_category ( category_no INTEGER NOT NULL AUTO_INCREMENT, " +
                "category_name TEXT, timed INTEGER NOT NULL DEFAULT 0, PRIMARY KEY (category_no) );";

            // class: class_no int (PK), category_no int (FK), name VC(255), fee decimal(5,2)
            string classTable = "CREATE TABLE " + year + "_class ( class_no INTEGER NOT NULL, category_no INTEGER NOT NULL, " +
                "class_name TEXT NOT NULL, fee NUMERIC NOT NULL, PRIMARY KEY (class_no), " +
                "FOREIGN KEY (category_no) REFERENCES " + year + "_category(category_no) ON DELETE CASCADE );";

            // result: show_no (FK), class_no (FK), back_no (FK), place int, time decimal(6,3), points int, paid_in decimal(5,2), paid_out decimal (5,2)
            string resultTable = "CREATE TABLE " + year + "_result ( show_no INTEGER NOT NULL, class_no INTEGER NOT NULL, " +
                "back_no INTEGER NOT NULL, place INTEGER, time NUMERIC, points INTEGER DEFAULT 0, " +
                "paid_in NUMERIC NOT NULL DEFAULT 0, paid_out NUMERIC, " +
                "FOREIGN KEY (show_no) REFERENCES " + year + "_show(show_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (class_no) REFERENCES " + year + "_class(class_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (back_no) REFERENCES " + year + "_backNo(back_no) ON DELETE CASCADE );";

            // And go!
            DoTheNonQuery(clubConn, yearInsert);
            DoTheNonQuery(clubConn, riderTable);
            DoTheNonQuery(clubConn, horseTable);
            DoTheNonQuery(clubConn, backNoTable);
            DoTheNonQuery(clubConn, showTable);
            DoTheNonQuery(clubConn, categoryTable);
            DoTheNonQuery(clubConn, classTable);
            DoTheNonQuery(clubConn, resultTable);
        }

        #endregion

        #region Delete statements

        public void DeleteYear(int year)
        {
            string showYearDelete = "DELETE FROM show_year WHERE year = " + year + ";";
            if(DoTheNonQuery(clubConn, showYearDelete))
            {
                string dropYearTables = "DROP TABLE " + year + "_result ; " +
                    "DROP TABLE " + year + "_class ; DROP TABLE " + year + "_category ; " +
                    "DROP TABLE " + year + "_show ; DROP TABLE " + year + "_backNo ; " +
                    "DROP TABLE " + year + "_horse ; DROP TABLE " + year + "_rider;";
                DoTheNonQuery(clubConn, dropYearTables);
            }
        }

        #endregion
    }
}
