﻿/* 
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
    public partial class DBDriver
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

                DoTheNonQuery(trotTraxConn, clubString);
                DoTheNonQuery(trotTraxConn, currentString);
                Console.WriteLine("\tDatabase creation successful.");
                connected = true;
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
            string clubId = GetCurrentClubId();
            if (clubId != null)
                clubConn = new SQLiteConnection("Data Source=" + clubId + ".db;Version=3;");
            else
                clubConn = null;
            year = GetCurrentYear();           
        }

        // Checks the for instance of the trot_trax database.
        private bool CheckDB()
        {
            string query = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='current';";
            int response = 0;

            Console.WriteLine("Welcome to TrotTrax!\nChecking database...");
            response = Convert.ToInt32(DoTheScalar(trotTraxConn, query));
            if (response > 0)
                return true;
            else
                return false;
        }

        #endregion

        #region Input translators
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
                conn.Close();
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

        private bool DoTheNonQuery(SQLiteCommand query)
        {
            try
            {
                query.Connection.Close();
                query.Connection.Open();
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

            try
            {
                conn.Close();
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

        private object DoTheScalar(SQLiteCommand query)
        {
            Object value;
            try
            {
                query.Connection.Close();
                query.Connection.Open();
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

            try
            {
                conn.Close();
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

        private SQLiteDataReader DoTheReader(SQLiteCommand query)
        {
            SQLiteDataReader reader;

            try
            {
                query.Connection.Close();
                query.Connection.Open();
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

        #region Current table interactions

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
            currentInsert.Connection = trotTraxConn;
            
            if (DoTheNonQuery(trotTraxConn, currentDelete) && DoTheNonQuery(currentInsert))
            {
                clubConn = new SQLiteConnection("Data Source=" + id + ".db;Version=3;");
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
                year = (int)DoTheScalar(clubConn, yearSelect);
            }

            // Update the current values
            SQLiteCommand currentUpdate = new SQLiteCommand();
            currentUpdate.CommandText = "UPDATE current SET current_year = @yearparam WHERE club_id = @idparam";
            currentUpdate.CommandType = System.Data.CommandType.Text;
            currentUpdate.Parameters.Add(new SQLiteParameter("@yearparam", year));
            currentUpdate.Parameters.Add(new SQLiteParameter("@idparam", GetCurrentClubId()));
            currentUpdate.Connection = trotTraxConn;
            DoTheNonQuery(currentUpdate);
            this.year = (int)year;
            return (int)year;
        }

        #endregion
    }
}