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
            object response = DoTheScalar(TrotTraxConn, query);
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
            string query = "SELECT year FROM show_year ORDER BY year DESC LIMIT 1;";
            object response = DoTheScalar(ClubConn, query);

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

        public bool CheckYearExists(int year)
        {
            string query = "SELECT COUNT(*) FROM show_year WHERE year = " + year + ";";
            object response = DoTheScalar(ClubConn, query);
            int count = -1;            

            try
            {
                count = Convert.ToInt32(response);
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                Console.WriteLine("No value for year " + year + " found. :(");
                return false;
            }
        }

        public List<int> GetYearItemList()
        {          
            string query = "SELECT year FROM show_year ORDER BY year DESC;";
            SQLiteDataReader reader = DoTheReader(ClubConn, query);
            List<int> yearItemList = new List<int>();

            while (reader.Read())
            {
                yearItemList.Add(reader.GetInt32(0));
            }
            reader.Close();
            TrotTraxConn.Close();
            return yearItemList;
        }

        #endregion

        #region Insert statements

        // Creates a new year for the current club
        // Generates table set for new year
        // Adds year to show_year table
        public void AddYear(int year)
        {
            Year = year;
            string yearInsert = "INSERT INTO show_year (year) VALUES(" + year + ");";

            // rider: rider_no int (PK), first_name text, last_name text, age INT, contact text, member int
            string riderTable = "CREATE TABLE [" + year + "_rider] ( rider_no INTEGER NOT NULL, " +
                "rider_first TEXT NOT NULL, rider_last TEXT NOT NULL, rider_dob TEXT, phone TEXT, " +
                "email TEXT, member INTEGER NOT NULL DEFAULT 0, rider_comment TEXT, PRIMARY KEY (rider_no) );";

            // horse: horse_no int (PK), name text, nickname text, height real
            string horseTable = "CREATE TABLE [" + year + "_horse] ( horse_no INTEGER NOT NULL, " +
                "horse_name TEXT NOT NULL, horse_alt TEXT, height TEXT, owner_name TEXT, horse_comment TEXT, PRIMARY KEY (horse_no) );";

            // back_no: back_no int (PK), rider_no int (FK), horse_no int (FK)
            string backNoTable = "CREATE TABLE [" + year + "_back] ( back_no INTEGER NOT NULL, " +
                "rider_no INTEGER NOT NULL, horse_no INTEGER NOT NULL, PRIMARY KEY (back_no), " +
                "FOREIGN KEY (rider_no) REFERENCES [" + year + "_rider](rider_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (horse_no) REFERENCES [" + year + "_horse](horse_no) ON DELETE CASCADE );";

            // show: show_no int (PK), date int, description text, comments text
            string showTable = "CREATE TABLE [" + year + "_show] ( show_no INTEGER NOT NULL, " +
                "date TEXT NOT NULL, show_name TEXT, show_comment TEXT, UNIQUE (date), PRIMARY KEY (show_no) );";

            // category: category_no int (PK), description text, 
            string categoryTable = "CREATE TABLE [" + year + "_category] ( category_no INTEGER NOT NULL, " +
                "category_name TEXT NOT NULL, timed INTEGER NOT NULL DEFAULT 0, PRIMARY KEY (category_no) );";

            // class: class_no int (PK), category_no int (FK), name text, fee real
            string classTable = "CREATE TABLE [" + year + "_class] ( class_no INTEGER NOT NULL, category_no INTEGER NOT NULL, " +
                "class_name TEXT NOT NULL, fee NUMERIC NOT NULL DEFAULT 0, PRIMARY KEY (class_no), " +
                "FOREIGN KEY (category_no) REFERENCES [" + year + "_category](category_no) ON DELETE CASCADE );";

            // result: show_no (FK), class_no (FK), back_no (FK), place int, time real, points int, paid_in real, paid_out real
            string resultTable = "CREATE TABLE [" + year + "_result] ( show_no INTEGER NOT NULL, class_no INTEGER NOT NULL, " +
                "back_no INTEGER NOT NULL, place INTEGER, time NUMERIC, points INTEGER DEFAULT 0, " +
                "paid_in NUMERIC NOT NULL DEFAULT 0, paid_out NUMERIC, " +
                "FOREIGN KEY (show_no) REFERENCES [" + year + "_show](show_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (class_no) REFERENCES [" + year + "_class](class_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (back_no) REFERENCES [" + year + "_back](back_no) ON DELETE CASCADE );";

            // settings: setting_name text, setting_value text
            string settingsTable = "CREATE TABLE [" + year + "_settings] ( setting_name TEXT UNIQUE NOT NULL, " +
                "setting_value TEXT NOT NULL ); INSERT INTO [" + year + "_settings] VALUES ( 'EntryFeeDiscountType', 'n' ); " +
                "INSERT INTO [" + year + "_settings] VALUES ( 'EntryFeeDiscountAmount', 0 ); " +
                "INSERT INTO [" + year + "_settings] VALUES ( 'NonMemberPoint', 1 ); " +
                "INSERT INTO [" + year + "_settings] VALUES ( 'PointSchemeType', 'f' ); " +
                "INSERT INTO [" + year + "_settings] VALUES ( 'PlacingNo', 6 );";

            // And go!
            if(DoTheNonQuery(ClubConn, yearInsert))
                Console.WriteLine(year + " successfully inserted into show_year");
            if (DoTheNonQuery(ClubConn, riderTable))
                Console.WriteLine(year + "_rider successfully created.");
            if (DoTheNonQuery(ClubConn, horseTable))
                Console.WriteLine(year + "_horse successfully created.");
            if (DoTheNonQuery(ClubConn, backNoTable))
                Console.WriteLine(year + "_back successfully created.");
            if (DoTheNonQuery(ClubConn, showTable))
                Console.WriteLine(year + "_show successfully created.");
            if (DoTheNonQuery(ClubConn, categoryTable))
                Console.WriteLine(year + "_category successfully created.");
            if (DoTheNonQuery(ClubConn, classTable))
                Console.WriteLine(year + "_class successfully created.");
            if (DoTheNonQuery(ClubConn, resultTable))
                Console.WriteLine(year + "_result successfully created.");
            if (DoTheNonQuery(ClubConn, settingsTable))
                Console.WriteLine(year + "_settings successfully created and populated.");
            // pointscheme table is created dynamically. Initialized to a flat points scheme of 6 places.
            if (GetDefaultPointSchemeTable())
                Console.WriteLine(year + "_settings successfully created and populated.");
        }

        #endregion

        #region Delete statements

        public bool DeleteYear(int year)
        {
            string showYearDelete = "DELETE FROM show_year WHERE year = " + year + ";";
            if (DoTheNonQuery(ClubConn, showYearDelete))
            {
                string dropYearTables = "DROP TABLE [" + year + "_result] ; " +
                    "DROP TABLE [" + year + "_class] ; DROP TABLE [" + year + "_category] ; " +
                    "DROP TABLE [" + year + "_show] ; DROP TABLE [" + year + "_backNo] ; " +
                    "DROP TABLE [" + year + "_horse] ; DROP TABLE [" + year + "_rider]; " +
                    "DROP TABLE [" + year + "_settings];";
                return DoTheNonQuery(ClubConn, dropYearTables);
            }
            return false;
        }

        #endregion
    }
}
