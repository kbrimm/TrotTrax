/* 
 * TrotTrax
 *     Copyright (c) 2015-2016 Katy Brimm
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
    public partial class DBDriver
    {
        private SQLiteConnection TrotTraxConn;
        private SQLiteConnection ClubConn;
        private int Year;
        public bool Connected;
        // Must be set for each db transaction in order to enforce foreign key constraints.
        private const string PRAGMA_STRING = "PRAGMA foreign_keys = ON; ";
        
        #region Constructors/Initializers

        // Initializes variables & checks for instance of database
        // Creates trot_trax if not found, adds tables for club data & current data
        public DBDriver()
        {
            TrotTraxConn = new SQLiteConnection("Data Source=trot_trax.trax;Version=3;");

            // If the database check fails, we need to initalize some things.
            // Otherwise, we're good to go.
            if (!CheckDB())
            {
                // Initialize tables.
                string clubString = "CREATE TABLE club ( club_id TEXT NOT NULL, club_name TEXT, PRIMARY KEY (club_id) );";
                string currentString = "CREATE TABLE current ( club_id TEXT NOT NULL, current_year INTEGER, " +
                    "FOREIGN KEY (club_id) REFERENCES club(club_id) ON DELETE CASCADE );";

                DoTheNonQuery(TrotTraxConn, clubString);
                DoTheNonQuery(TrotTraxConn, currentString);
                Console.WriteLine("\tDatabase creation successful.");
                Connected = true;
            }
            else
            {
                Console.WriteLine("\tDatabase connection successful!");
                Connected = true;
            }
        }

        // Passing in a club name value skips the DB instance check step.
        public DBDriver(int skipCheck)
        {
            TrotTraxConn = new SQLiteConnection("Data Source=trot_trax.trax;Version=3;");
            string clubId = GetCurrentClubId();
            if (clubId != null)
                ClubConn = new SQLiteConnection("Data Source=" + clubId + ".trax;Version=3;");
            else
                ClubConn = null;
            Year = GetCurrentYear();           
        }

        // Checks the for instance of the trot_trax database.
        private bool CheckDB()
        {
            string query = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='current';";
            int response = 0;

            Console.WriteLine("\tChecking database...");
            response = Convert.ToInt32(DoTheScalar(TrotTraxConn, query));
            if (response > 0)
                return true;
            else
                return false;
        }

        #endregion

        #region Input Translators
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

        #region Query Executors

        private bool DoTheNonQuery(SQLiteConnection conn, string query)
        {
            SQLiteCommand command;
            Console.WriteLine("Executing non-query: " + query);
            try
            {
                conn.Close();
                conn.Open();
                query = PRAGMA_STRING + query;
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

        private bool DoTheNonQuery(SQLiteCommand query)
        {
            Console.WriteLine("Executing non-query: " + query.CommandText);
            try
            {
                query.Connection.Close();
                query.Connection.Open();
                query.CommandText = PRAGMA_STRING + query.CommandText;
                query.ExecuteNonQuery();
                query.Connection.Close();
                Console.WriteLine("\tSuccess! :D");
                return true;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                query.Connection.Close();
                return false;
            }
        }

        private object DoTheScalar(SQLiteConnection conn, string query)
        {
            SQLiteCommand command;
            object value;
            Console.WriteLine("Executing scalar: " + query);
            try
            {
                conn.Close();
                conn.Open();
                query = PRAGMA_STRING + query;
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

        private object DoTheScalar(SQLiteCommand query)
        {
            Object value;
            Console.WriteLine("Executing scalar: " + query.CommandText);
            try
            {
                query.Connection.Close();
                query.Connection.Open();
                query.CommandText = PRAGMA_STRING + query.CommandText;
                value = query.ExecuteScalar();
                query.Connection.Close();
                Console.WriteLine("\tSuccess! :D");
                return value;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                query.Connection.Close();
                return null;
            }
        }

        private SQLiteDataReader DoTheReader(SQLiteConnection conn, string query)
        {
            SQLiteCommand command;
            SQLiteDataReader reader;
            Console.WriteLine("Executing reader: " + query);
            try
            {
                conn.Close();
                conn.Open();
                query = PRAGMA_STRING + query;
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

        private SQLiteDataReader DoTheReader(SQLiteCommand query)
        {
            SQLiteDataReader reader;
            Console.WriteLine("Executing reader: " + query.CommandText);
            try
            {
                query.Connection.Close();
                query.Connection.Open();
                query.CommandText = PRAGMA_STRING + query.CommandText;
                reader = query.ExecuteReader();
                Console.WriteLine("\tSuccess! :D");
                return reader;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                query.Connection.Close();
                return null;
            }
        }

        #endregion   

        #region Current Table

        // Checks the current table: returns true if it has a value, false otherwise.
        public bool HasCurrent()
        {
            string query = "SELECT count(*) FROM current;";
            object response = DoTheScalar(TrotTraxConn, query);
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

        // Resets data in current, sets club as current, calls SetCurrentYear
        public bool SetCurrentClub(string id, int? year = null)
        {
            // Delete existing current data
            string currentDelete = "DELETE FROM current;";
            
            // Construct club id insertion command
            SQLiteCommand currentInsert = new SQLiteCommand();
            currentInsert.CommandText = "INSERT INTO current (club_id) VALUES (@idparam)";
            currentInsert.CommandType = System.Data.CommandType.Text;
            currentInsert.Parameters.Add(new SQLiteParameter("@idparam", id));
            currentInsert.Connection = TrotTraxConn;
            
            if (DoTheNonQuery(TrotTraxConn, currentDelete) && DoTheNonQuery(currentInsert))
            {
                ClubConn = new SQLiteConnection("Data Source=" + id + ".trax;Version=3;");
                return true;
            }
            return false;
        }

        // Sets current year - if no year is passed in, the most current for the club is used.
        public int SetCurrentYear(int? year = null)
        {
            // If no year value is passed in, find the most current year for the club.
            if (year == null)
            {
                string yearSelect = "SELECT year FROM show_year ORDER BY year DESC LIMIT 1;";
                year = (int)DoTheScalar(ClubConn, yearSelect);
            }

            // Update the current values
            SQLiteCommand currentUpdate = new SQLiteCommand();
            currentUpdate.CommandText = "UPDATE current SET current_year = @yearparam WHERE club_id = @idparam";
            currentUpdate.CommandType = System.Data.CommandType.Text;
            currentUpdate.Parameters.Add(new SQLiteParameter("@yearparam", year));
            currentUpdate.Parameters.Add(new SQLiteParameter("@idparam", GetCurrentClubId()));
            currentUpdate.Connection = TrotTraxConn;
            DoTheNonQuery(currentUpdate);
            this.Year = (int)year;
            return (int)year;
        }

        #endregion

        #region Index Checkers

        // Returns 1 + the greatest index.
        // Returns 1 for empty database, -1 for invalid selector.
        public int GetNextIndex(ItemType type)
        {
            string formString;
            switch (type)
            {
                case ItemType.BackNo: formString = "back"; break;
                case ItemType.Category: formString = "category"; break;
                case ItemType.Class: formString = "class"; break;
                case ItemType.Horse: formString = "horse"; break;
                case ItemType.Rider: formString = "rider"; break;
                case ItemType.Show: formString = "show"; break;
                default: formString = String.Empty; break;
            }

            if (formString.Equals(String.Empty))
            {
                Console.WriteLine("\tInvalid selector.");
                return -1;
            }

            string query = "SELECT " + formString + "_no FROM [" + Year + "_" + formString + "] ORDER BY " + formString + "_no DESC LIMIT 1;";
            object value = DoTheScalar(ClubConn, query);
            if (value != null)
                return Convert.ToInt32(value) + 1;
            else
                return 1;
        }

        // Returns true if requested index is in use, false otherwise.
        public bool CheckIndexUsed(ItemType type, int number)
        {
            string formString;
            switch (type)
            {
                case ItemType.BackNo: formString = "back"; break;
                case ItemType.Category: formString = "category"; break;
                case ItemType.Class: formString = "class"; break;
                case ItemType.Horse: formString = "horse"; break;
                case ItemType.Rider: formString = "rider"; break;
                case ItemType.Show: formString = "show"; break;
                default: formString = String.Empty; break;
            }

            if (formString.Equals(String.Empty))
            {
                Console.WriteLine("\tInvalid selector.");
                return false;
            }

            string query = "SELECT COUNT(*) FROM [" + Year + "_" + formString + "] WHERE " + formString + "_no = " + number + ";";
            object value = DoTheScalar(ClubConn, query);
            if (value != null && Convert.ToInt32(value) > 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
