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
                case 0: return false;
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

        #endregion
    }
}