/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General private License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
 */

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    private partial class DBDriver
    {
        private SQLiteConnection trotTraxConn;
        private SQLiteConnection clubConn;

        public bool connected;
        private int year;

        #region Constructors/Initializers

        // Initializes variables & checks for instance of database
        // Creates trot_trax if not found, adds tables for club data & current data
        public DBDriver()
        {
            trotTraxConn = new SQLiteConnection("Data Source=trot_trax.db;Version=3;");

            // If the database check fails, we need to initalize some things.
            // Otherwise, we're good to go.
            if (!CheckDB())
            {
                // Initialize tables.
                string clubString = "CREATE TABLE club ( club_id TEXT NOT NULL, club_name TEXT, PRIMARY KEY (club_id) );";
                string currentString = "CREATE TABLE current ( club_id TEXT NOT NULL, current_year INTEGER, " +
                    "FOREIGN KEY (club_id) REFERENCES club(club_id) ON DELETE CASCADE );";
                SQLiteConnection.CreateFile("trot_trax.db");

                if (CheckDB())
                {
                    DoTheNonQuery(trotTraxConn, clubString);
                    DoTheNonQuery(trotTraxConn, currentString);
                    Console.WriteLine("\tDatabase creation successful.");
                    connected = true;
                }
                else
                {
                    Console.WriteLine("Unable to create database.");
                    connected = false;
                }
            }
            else
            {
                Console.WriteLine("\tDatabase connection successful!");
                connected = true;
            }
        }

        // Passing in a club name value skips the DB instance check step.
        public DBDriver(int skipCheck)
        {
            trotTraxConn = new SQLiteConnection("Data Source=trot_trax.db;Version=3;");
            clubConn = new SQLiteConnection("Data Source=" + GetCurrentClubId() + ".db;Version=3;"); 
            year = GetCurrentYear();           
        }

        // Checks the for instance of the trot_trax database.
        private bool CheckDB()
        {
            string query = "SELECT count(*) FROM sqlite_maser WHERE type='table' AND name='trot_trax';";

            Console.WriteLine("Welcome to TrotTrax!\nChecking database...");
            return DoTheNonQuery(trotTraxConn, query);    
        }

        #endregion

        #region String Management

        // Santizes user strings to prevent injection errors or other horrible things.
        private string CleanString(string stringIn)
        {
            string newString = String.Empty;

            foreach (char c in stringIn)
            {
                if (c == '\'')
                    newString += '’';
                else
                    newString += c;
            }
            return newString;
        }

        // SQLite does not support a date format, so we need to use a string that will sort properly.
        private string DateToString(DateTime date)
        {
            string format = "yyyy-MM-dd";
            return date.ToString(format);
        }

        private DateTime StringToDate(string date)
        {
            string format = "yyyy-MM-dd";
            CultureInfo culture = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(date, format, culture);
        }

        // SQLite ALSO does not support a boolean because why even would it.
        private bool? IntToBool(int value)
        {
            switch (value)
            {
                case 1: return true;
                case 2: return false;
                default: return null;
            }
        }

        private int? BoolToInt(bool value)
        {
            switch (value)
            {
                case true: return 1;
                case false: return 0;
                default: return null;
            }
        }

        #endregion

        #region Query executors

        private bool DoTheNonQuery(SQLiteConnection conn, string query)
        {
            SQLiteCommand command;

            try
            {
                conn.Open();
                command = new SQLiteCommand(query, conn);
                command.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("\tSuccess! :D");
                return true;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                conn.Close();
                return false;
            }
        }

        private bool DoTheNonQuery(SQLiteConnection conn, SQLiteCommand query)
        {
            try
            {
                conn.Open();
                query.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("\tSuccess! :D");
                return true;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                conn.Close();
                return false;
            }
        }

        private object DoTheScalar(SQLiteConnection conn, string query)
        {
            SQLiteCommand command;
            object value;

            try
            {
                conn.Open();
                command = new SQLiteCommand(query, conn);
                value = command.ExecuteScalar();
                conn.Close();
                Console.WriteLine("\tSuccess! :D");
                return value;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                conn.Close();
                return null;
            }
        }

        private object DoTheScalar(SQLiteConnection conn, SQLiteCommand query)
        {
            Object value;
            try
            {
                conn.Open();
                value = query.ExecuteScalar();
                conn.Close();
                Console.WriteLine("\tSuccess! :D");
                return value;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                conn.Close();
                return null;
            }
        }

        private SQLiteDataReader DoTheReader(SQLiteConnection conn, string query)
        {
            SQLiteCommand command;
            SQLiteDataReader reader;          

            try
            {
                conn.Open();
                command = new SQLiteCommand(query, conn);
                reader = command.ExecuteReader();
                Console.WriteLine("\tSuccess! :D");
                return reader;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                conn.Close();
                return null;
            }
        }

        private SQLiteDataReader DoTheReader(SQLiteConnection conn, SQLiteCommand query)
        {
            SQLiteDataReader reader;

            try
            {
                conn.Open();
                reader = query.ExecuteReader();
                Console.WriteLine("\tSuccess! :D");
                return reader;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                conn.Close();
                return null;
            }
        }

        #endregion   

        #region Other bizz

        // Checks the current table: returns true if it has a value, false otherwise.
        public bool HasCurrent()
        {
            string query = "SELECT count(*) FROM current;";
            object response = DoTheScalar(trotTraxConn, query);
            Console.WriteLine("Checking for values in current...");
            try
            {
                if (Convert.ToInt32(response) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("No value found. :(");
                return false;
            }
        }

        #endregion

        #region Table creators

        // Resets data in current, sets club as current
        public void SetCurrent(string id, int year)
        {
            // Construct club id insertion command
            SQLiteCommand currentInsert = new SQLiteCommand();
            currentInsert.CommandText = "INSERT INTO current (club_id, current_year) VALUES (@idparam, @yearparam)";
            currentInsert.CommandType = System.Data.CommandType.Text;
            currentInsert.Parameters.Add(new SQLiteParameter("@idparam", id));
            currentInsert.Parameters.Add(new SQLiteParameter("@yearparam", year));

            string currentDelete = "DELETE FROM current;";
            if (DoTheNonQuery(trotTraxConn, currentDelete) && DoTheNonQuery(trotTraxConn, currentInsert))
            {
                this.year = year;
                SQLiteConnection.CreateFile(id + ".db");
            }
        }

        // Creates a new club entity
        // Requires a name and ID (generally acronym generated from full name)
        // Inserts club data into trot_trax.clubs
        // Creates club DB & adds year table
        public void CreateClub(string id, string name)
        {
            string yearTable = "CREATE TABLE show_year ( year INTEGER NOT NULL, UNIQUE (year) );";
            clubConn = new SQLiteConnection("Data Source=" + id + ".db;Version=3;");

            // Construct club insertion command
            SQLiteCommand clubInsert = new SQLiteCommand();
            clubInsert.CommandText = "INSERT INTO club (club_id, club_name) VALUES (@idparam, @nameparam)";
            clubInsert.CommandType = System.Data.CommandType.Text;
            clubInsert.Parameters.Add(new SQLiteParameter("@idparam", id));
            clubInsert.Parameters.Add(new SQLiteParameter("@nameparam", name));

            // Do the stuff!
            SQLiteConnection.CreateFile(id + ".db");
            clubInsert.ExecuteNonQuery();
            DoTheNonQuery(trotTraxConn, clubInsert);
            DoTheNonQuery(clubConn, yearTable);
        }

        // Creates a new year for the current club
        // Generates table set for new year
        // Adds year to show_year table
        private void CreateYear(int year)
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
    }
}