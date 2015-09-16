/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
 */

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    public class DBDriver
    {
        private MySqlConnection connection;
        private string server;
        private string port;
        private string usrID;
        private string password;

        public bool connected;

        // Initializes variables & checks for instance of database
        // Creates trot_trax if not found
        //     the adds tables for club data & current data (last club and year viewed)
        public DBDriver()
        {
            server = "localhost";
            port = "3306";
            usrID = "root";
            password = "password";

            string connString = "SERVER=" + server + "; PORT=" + port + ";" +
                "UID=" + usrID + "; PASSWORD=" + password + ";";

            connection = new MySqlConnection(connString);
            if (!CheckDB())
            {
                string clubString = "club_id VARCHAR(10) NOT NULL, " +
                        "club_name VARCHAR(255), " +
                        "PRIMARY KEY (club_id)";
                string currentString = "club_id VARCHAR(10) NOT NULL, " +
                    "current_year INT, " +
                    "FOREIGN KEY (club_id) REFERENCES trot_trax.club(club_id) ON DELETE CASCADE";

                DropDB("trax_data");
                if (CreateDB("trot_trax"))
                {
                    AddTable("trot_trax", "club", clubString);
                    AddTable("trot_trax", "current", currentString);
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

        // Checks the initial instance of the trot_trax database.
        private bool CheckDB()
        {
            string query;
            object checkValue;

            Console.WriteLine("Welcome to TrotTrax!\nChecking database...");
            query = "SELECT count(*) " +
                "FROM information_schema.TABLES " +
                "WHERE (TABLE_SCHEMA = 'trot_trax') AND (TABLE_NAME = 'club');";
            checkValue = DoTheScalar(query);
            if (checkValue != null && Convert.ToInt32(checkValue) > 0)
                return true;
            else
                return false;
        }

        // Adding an integer value to the driver instantiation skips the DB initialization check.
        public DBDriver(int nonInitCheck)
        {
            server = "localhost";
            port = "3306";
            usrID = "root";
            password = "password";

            string connString = "SERVER=" + server + "; PORT=" + port + ";" +
                "UID=" + usrID + "; PASSWORD=" + password + ";";

            connection = new MySqlConnection(connString);
        }

        private bool DoTheNonQuery(string query)
        {
            MySqlCommand command;

            try
            {
                connection.Open();
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("\tSuccess! :D");
                return true;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                connection.Close();
                return false;
            }
        }

        private object DoTheScalar(string query)
        {
            MySqlCommand command;
            object value;

            try
            {
                connection.Open();
                command = new MySqlCommand(query, connection);
                value = command.ExecuteScalar();
                connection.Close();
                Console.WriteLine("\tSuccess! :D");
                return value;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                connection.Close();
                return null;
            }
        }

        private MySqlDataReader DoTheReader(string query)
        {
            MySqlCommand command;
            MySqlDataReader reader;

            try
            {
                connection.Open();
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();
                Console.WriteLine("\tSuccess! :D");
                return reader;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                connection.Close();
                return null;
            }
        }
        
        // Santizes user strings to prevent injection errors or other horrible things.
        public string FormatString(string stringIn)
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

        // The following are some basic commands for interacting with the database.
        // They are all private, return bool, and they should all be self-explanatory.
        // Optional parameters should be replaced with String.Empty if no data is passed.
        // Note: The goal is to minimize the typing required in other functions,
        //     so most of the standard beginning/end of SQL commands is embedded here.
        private bool CreateDB(string database)
        {
            string query;
            bool success;

            Console.WriteLine("Creating database:" + database + ".");
            DropDB(database);
            query = "CREATE DATABASE " + database + ";";
            success = DoTheNonQuery(query);
            if(success)
                return true;
            else
                return false;
        }

        private bool DropDB(string database)
        {
            string query;
            bool success;

            Console.WriteLine("Dropping database:" + database + "...");
            query = "DROP DATABASE IF EXISTS " + database + ";";            
            success = DoTheNonQuery(query);
            if(success)
                return true;
            else
                return false;
        }

        // tableString requires SQL formatted variable parameters and key designations.
        private bool AddTable(string database, string table, string columnString)
        {
            string query;
            bool success;

            DropTable(database, table);

            Console.WriteLine("Adding " + table + " to " + database + "...");
            query = "CREATE TABLE " + database + "." + table + " " +
                    "(" + columnString + ");";
            success = DoTheNonQuery(query);
            if (success)
                return true;
            else
                return false;
        }

        private bool DropTable(string database, string table)
        {
           string query;
            bool success;
            
            Console.WriteLine("Dropping " + table + " from " + database);
            query = "DROP TABLE IF EXISTS " + database + "." + table + ";";
            success = DoTheNonQuery(query);
            if (success)
                return true;
            else
                return false;
        }

        // Takes input as object to accomodate for strings or ints.
        // Optional: column
        private bool InsertData(string database, string table, string column, object data)
        {
            string query;
            bool success;

            Console.WriteLine("Adding data to " + database + "." + table);

            if (column != String.Empty)
                column = " (" + column + ")";
            query = "INSERT INTO " + database + "." + table + column + " " +
                "VALUES (" + data + ");";
            success = DoTheNonQuery(query);
            if (success)
                return true;
            else
                return false;
        }

        // Optional: where
        private bool UpdateData(string database, string table, string data, string where)
        {
            string query;
            bool success;

            Console.WriteLine("Updating data in " + database + "." + table);

            if (where != String.Empty)
                where = " WHERE " + where;
            query = "UPDATE " + database + "." + table + " " +
                    "SET " + data +
                    where + ";";
            success = DoTheNonQuery(query);
            if (success)
                return true;
            else
                return false;
        }

        // Optional: where
        private bool DeleteData(string database, string table, string where)
        {
            string query;
            bool success;

            Console.WriteLine("Deleting data in " + database + "." + table);
            if (where != String.Empty)
                where = " WHERE " + where;
            query = "DELETE FROM " + database + "." + table + 
                    where + ";";
            success = DoTheNonQuery(query);
            if (success)
                return true;
            else
                return false;
        }

        // Essentially wraps ExecuteScalar, returns particular format of the data found.
        // Optional: where
        public bool? GetValueBool(string database, string table, string column, string where)
        {
            string query;
            object response;

            Console.WriteLine("Retrieving value for " + column + " from " + database + ".");
            if (where != String.Empty)
                where = " WHERE " + where;
            query = "SELECT " + column + " " +
                "FROM " + database + "." + table + where + ";";
            response = DoTheScalar(query);
            try
            {
                return Convert.ToBoolean(response);
            }
            catch 
            {
                return null;
            }
        }

        // Optional: where
        public decimal? GetValueDecimal(string database, string table, string column, string where)
        {
            string query;
            object response;

            Console.WriteLine("Retrieving value for " + column + " from " + database + ".");
            if (where != String.Empty)
                where = " WHERE " + where;
            query = "SELECT " + column + " " +
                "FROM " + database + "." + table + where + ";";
            response = DoTheScalar(query);
            try
            {
                return Convert.ToDecimal(response);
            }
            catch
            {
                return null;
            }
        }

        // Optional: where
        public int? GetValueInt(string database, string table, string column, string where)
        {
            string query;
            object response;

            Console.WriteLine("Retrieving value for " + column + " from " + database + ".");

            if (where != String.Empty)
                where = " WHERE " + where;
            query = "SELECT " + column + " " +
                "FROM " + database + "." + table + where + ";";
            response = DoTheScalar(query);

            try
            {
                return Convert.ToInt32(response);
            }
            catch
            {
                return null;
            }
        }

        // Optional: where
        public string GetValueString(string database, string table, string column, string where)
        {
            string query;
            object response;

            Console.WriteLine("Retrieving value for " + column + " from " + database + ".");
            if (where != String.Empty)
                where = " WHERE " + where;
            query = "SELECT " + column + " " +
                "FROM " + database + "." + table + where + ";";
            response = DoTheScalar(query);
            if (response != null)
                return response.ToString();
            else
                return "Object not found";
        }

        // Wraps for DoTheReader.
        // Assembles the query, passes it to DoTheReader, then returns the reader to the calling function.
        // Private, because there's not much to be done with a reader as-is.
        // Reader MUST BE CLOSED by calling function.
        // Optional: column, where, sort
        private MySqlDataReader GetReader(string database, string table, string column, string where, string sort)
        {
            string query;
            MySqlDataReader reader;

            Console.WriteLine("Retrieving values for " + column + ".");
            if (column == String.Empty)
                column = "*";
            if (where != String.Empty)
                where = " WHERE " + where;
            if (sort != String.Empty)
                sort = " ORDER BY " + sort;
            query = "SELECT " + column + " " +
                "FROM " + database + "." + table + 
                where + sort + ";";
            reader = DoTheReader(query);
            return reader;
        }

        // Similar to above, requires pre-formatted join list in lieu of db + table.
        // Optional: column, where, sort
        private MySqlDataReader GetJoinedReader(string join, string column, string where, string sort)
        {
            string query;
            MySqlDataReader reader;

            Console.WriteLine("Retrieving values for " + column + " from joined tables.");
            if (column == String.Empty)
                column = "*";
            if (where != String.Empty)
                where = " WHERE " + where;
            if (sort != String.Empty)
                sort = " ORDER BY " + sort;
            query = "SELECT " + column + " " +
                "FROM " + join +
                where + sort + ";";
            reader = DoTheReader(query);
            return reader;
        }

        // Returns a single column in List<string> form.
        public List<string> GetStringList(string database, string table, string column, string sort)
        {
            MySqlDataReader reader;
            string item;
            List<string> list = new List<string>();

            Console.WriteLine("Procuring list of " + column + ".");
            reader = GetReader(database, table, column, String.Empty, sort);
            while (reader.Read())
            {
                item = reader.GetString(0);
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        // Returns a single column in List<string> form.
        public List<int> GetIntList(string database, string table, string column, string sort)
        {
            MySqlDataReader reader;
            int? item;
            List<int> list = new List<int>();

            Console.WriteLine("Procuring list of " + column + ".");
            reader = GetReader(database, table, column, String.Empty, sort);
            while (reader.Read())
            {
                item = reader.GetInt32(0);
                if (item.HasValue)
                    list.Add(Convert.ToInt32(item));
            }
            reader.Close();
            connection.Close();
            return list;
        }

        // Optional: where
        public int? CountValue(string database, string table, string column, string where)
        {
            string query;
            object count;

            Console.WriteLine("Counting entries in " + column + ":");
            if (where != String.Empty)
                where = " WHERE " + where;
            query = "SELECT count(" + column + ") " +
                "FROM " + database + "." + table + 
                where + ";";
            count = DoTheScalar(query);
            if (count != null)
                return Convert.ToInt32(count);
            else
                return null;
        }

        // The following functions provide specific database interaction functionality.
        // Because of the complexity of the interactions between the tables, I've tried to
        //     add as many pertinent comments as possible to keep things relatively clear.

        // Creates a new club entity
        // Requires a name and ID (generally acronym generated from full name)
        // Inserts club data into trot_trax.clubs
        // Creates club DB & adds year table
        // Sets club to current.
        public void CreateClub(string id, string name)
        {
            string cleanName = FormatString(name);
            string insertClubString = "'" + id + "', '" + cleanName + "'";
            string yearString = "year INT NOT NULL, " +
                "UNIQUE (year)";

            InsertData("trot_trax", "club", String.Empty, insertClubString);
            CreateDB(id);
            AddTable(id, "show_year", yearString);
            SetClub(id);
        }

        // Creates a new year for the current club
        // Generates table set for new year
        // Adds year to show_year table
        // Sets year as current
        public void CreateYear(string id, int year)
        {
            // rider: rider_no int (PK), first_name VC(255), last_name VC(255), age INT, contact VC(255), member BOOLEAN
            string riderString = "rider_no INT NOT NULL AUTO_INCREMENT, " +
                "rider_first VARCHAR(255) NOT NULL, " +
                "rider_last VARCHAR(255) NOT NULL, " +
                "rider_age INT, " +
                "phone VARCHAR(255), " +
                "email VARCHAR(255), " +
                "member BOOLEAN NOT NULL DEFAULT 0, " +
                "PRIMARY KEY (rider_no)";

            // horse: horse_no int (PK), name VC(255), nickname VC(255), height decimal(4,2)
            string horseString = "horse_no INT NOT NULL AUTO_INCREMENT, " +
                "horse_name VARCHAR(255) NOT NULL, " +
                "horse_short VARCHAR(255), " +
                "height DECIMAL(5,2), " +
                "PRIMARY KEY (horse_no)";

            // back_no: back_no int (PK), rider_no int (FK), horse_no int (FK)
            string backNoString = "back_no INT NOT NULL, " +
                "rider_no INT NOT NULL, " +
                "horse_no INT NOT NULL, " +
                "PRIMARY KEY (back_no), " +
                "FOREIGN KEY (rider_no) REFERENCES " + id + "." + year + "_rider(rider_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (horse_no) REFERENCES " + id + "." + year + "_horse(horse_no) ON DELETE CASCADE";

            // show: show_no int (PK), date VC(10), description VC(255), comments VC(500)
            string showString = "show_no INT NOT NULL AUTO_INCREMENT, " +
                "date DATE NOT NULL," +
                "show_name VARCHAR(255), " +
                "show_comment VARCHAR(500), " +
                "UNIQUE (date), " +
                "PRIMARY KEY (show_no)";

            // category: category_no int (PK), description VC(255), 
            string categoryString = "category_no INT NOT NULL AUTO_INCREMENT, " +
                "category_desc VARCHAR(255), " +
                "fee DECIMAL(5,2) NOT NULL, " +
                "timed BOOLEAN NOT NULL, " +
                "payout BOOLEAN NOT NULL, " +
                "jackpot BOOLEAN NOT NULL, " +
                "PRIMARY KEY (category_no)";

            // class: class_no int (PK), category_no int (FK), name VC(255), fee decimal(5,2)
            string classString = "class_no INT NOT NULL, " +
                "category_no INT NOT NULL, " +
                "class_name VARCHAR(255) NOT NULL, " +
                "PRIMARY KEY (class_no), " +
                "FOREIGN KEY (category_no) REFERENCES " + id + "." + year + "_category(category_no) ON DELETE CASCADE";

            // result: show_no (FK), class_no (FK), back_no (FK), place int, time decimal(6,3), points int, paid_in decimal(5,2), paid_out decimal (5,2)
            string resultString = "show_no INT NOT NULL, " +
                "class_no INT NOT NULL, " +
                "back_no INT NOT NULL, " +
                "place INT, " +
                "time DECIMAL(6,3), " +
                "points INT DEFAULT 0, " +
                "paid_in DECIMAL(5,3) NOT NULL DEFAULT 0, " +
                "paid_out DECIMAL(5,3), " +
                "FOREIGN KEY (show_no) REFERENCES " + id + "." + year + "_show(show_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (class_no) REFERENCES " + id + "." + year + "_class(class_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (back_no) REFERENCES " + id + "." + year + "_backNo(back_no) ON DELETE CASCADE";

            // The extra drop references are to clear any data from the demo release from 08/14/15.
            InsertData(id, "show_year", String.Empty, year);
            AddTable(id, year + "_rider", riderString);
            AddTable(id, year + "_horse", horseString);
            DropTable(id, year + "_back_no");
            AddTable(id, year + "_backNo", backNoString);
            DropTable(id, year + "_show_list");
            AddTable(id, year + "_show", showString);
            AddTable(id, year + "_category", categoryString);
            DropTable(id, year + "_class_list");
            AddTable(id, year + "_class", classString);
            DropTable(id, year + "_results");
            AddTable(id, year + "_result", resultString);
            SetYear(year);
        }

        // Resets data in current
        // Sets club as current
        public void SetClub(string id)
        {
            DeleteData("trot_trax", "current", String.Empty);
            InsertData("trot_trax", "current", "club_id", "'" + id + "'");
        }

        public void SetYear(int year)
        {
            UpdateData("trot_trax", "current", "current_year = " + year, String.Empty);
        }

        // This set of functions now pulls ALL of the information for each group to reduce repeat queries.
        // Sort columns referred to by name - functions instituting joins should define which table to pull from.

        // Optional: sort (default is back_no)
        public List<BackNoItem> GetBackNoItemList(string database, int year, string sort)
        {
            MySqlDataReader reader;
            BackNoItem item;
            List<BackNoItem> backNoItemList = new List<BackNoItem>();
            string join = database + "." + year + "_backNo AS b " +
                "JOIN " + database + "." + year + "_rider AS r ON b.rider_no = r.rider_no " +
                "JOIN " + database + "." + year + "_horse AS h ON b.horse_no = h.horse_no";

            if (sort == "rider_last")
                sort = "r.rider_last, r.rider_first";
            else if (sort == "horse_name")
                sort = "h.horse_name";
            else
                sort = "b.back_no";

            reader = GetJoinedReader(join, "b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name", String.Empty, sort);
            while (reader.Read())
            {
                item = new BackNoItem();
                item.no = reader.GetInt32(0);
                item.riderNo = reader.GetInt32(1);
                item.rider = reader.GetString(2) + " " + reader.GetString(3);
                item.horseNo = reader.GetInt32(4);
                item.horse = reader.GetString(5);
                backNoItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return backNoItemList;
        }

        // Optional: sort (default is cat_no)
        public List<CatItem> GetCatItemList(string database, int year, string sort)
        {
            MySqlDataReader reader;
            CatItem item;
            List<CatItem> catItemList = new List<CatItem>();

            if (sort == String.Empty)
                sort = "cat_no";

            reader = GetReader(database, year + "_category", "cat_no, cat_desc, fee, timed, payout, jackpot", String.Empty, sort);
            while (reader.Read())
            {
                item = new CatItem();
                item.no = reader.GetInt32(0);
                item.description = reader.GetString(1);
                item.fee = reader.GetDecimal(2);
                item.timed = reader.GetBoolean(3);
                item.payout = reader.GetBoolean(4);
                item.jackpot = reader.GetBoolean(5);
                

                catItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return catItemList;
        }

        //Optional: sort (default is class_name)
        public List<ClassItem> GetClassItemList(string database, int year, string sort)
        {
            MySqlDataReader reader;
            ClassItem item;
            List<ClassItem> classItemList = new List<ClassItem>();

            if (sort == String.Empty)
                sort = "class_no";

            reader = GetReader(database, year + "_class", "class_no, class_name, category_no", String.Empty, sort);
            while (reader.Read())
            {
                item = new ClassItem();
                item.no = reader.GetInt32(0);
                item.name = reader.GetString(1);
                item.catNo = reader.GetInt32(2);
                classItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return classItemList;
        }

        // Optional: sort (default is back_no)
        public List<ClassEntryItem> GetEntryList(string database, int year, string where, string sort)
        {
            MySqlDataReader reader;
            ClassEntryItem item;
            List<ClassEntryItem> classEntryItemList = new List<ClassEntryItem>();
            string join = database + "." + year + "_result AS t " +
                "JOIN " + database + "." + year + "_backNo AS b ON t.back_no = b.back_no " +
                "JOIN " + database + "." + year + "_rider AS r ON b.rider_no = r.rider_no " +
                "JOIN " + database + "." + year + "_horse AS h ON b.horse_no = h.horse_no " +
                "JOIN " + database + "." + year + "_class AS c ON t.class_no = c.class_no " +
                "JOIN " + database + "." + year + "_show AS s ON t.show_no = s.show_no";
            string column = "b.back_no, r.rider_no, r.rider_first, r.rider_last, h.horse_no, h.horse_name, " +
                "s.show_no, s.show_date, c.class_no, c.class_name, t.place, t.points, t.pay_in, t.pay_out";

            if (sort == "rider_last")
                sort = "r.rider_last, r.rider_first";
            else if (sort == "horse_name")
                sort = "h.horse_name";
            else if (sort == "place")
                sort = "t.place";
            else if (sort == "class_no")
                sort = "c.class_no";
            else if (sort == "date")
                sort = "s.date";
            else
                sort = "b.back_no";

            reader = GetJoinedReader(join, column, where, sort);
            while (reader.Read())
            {
                item = new ClassEntryItem();
                item.backNo = reader.GetInt32(0);
                item.riderNo = reader.GetInt32(1);
                item.rider = reader.GetString(2) + " " + reader.GetString(3);
                item.horseNo = reader.GetInt32(4);
                item.horse = reader.GetString(5);
                item.showNo = reader.GetInt32(6);
                item.showDate = reader.GetString(7);
                item.classNo = reader.GetInt32(8);
                item.className = reader.GetString(9);
                item.place = reader.GetInt32(10);
                item.points = reader.GetInt32(11);
                item.payIn = reader.GetDecimal(12);
                item.payOut = reader.GetDecimal(13);

                classEntryItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return classEntryItemList;
        }

        // Optional: sort (default is horse_name)
        public List<HorseItem> GetHorseItemList(string database, int year, string sort)
        {
            MySqlDataReader reader;
            HorseItem item;
            List<HorseItem> horseItemList = new List<HorseItem>();

            if (sort == String.Empty)
                sort = "horse_name";

            reader = GetReader(database, year + "_horse", "horse_no, horse_name, horse_short, height", String.Empty, sort);
            while (reader.Read())
            {
                item = new HorseItem();
                item.no = reader.GetInt32(0);
                item.name = reader.GetString(1);
                item.shortName = reader.GetString(2);
                item.height = reader.GetDecimal(3);
                horseItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return horseItemList;
        }

        // Optional: sort (default is rider_last)
        public List<RiderItem> GetRiderItemList(string database, int year, string sort)
        {
            MySqlDataReader reader;
            RiderItem item;
            List<RiderItem> riderItemList = new List<RiderItem>();

            if (sort == "rider_last" || sort == String.Empty)
                sort = "rider_last, rider_first";

            reader = GetReader(database, year + "_rider", "rider_no, first_name, last_name, rider_age, phone, email, member", String.Empty, sort);
            while (reader.Read())
            {
                item = new RiderItem();
                item.no = reader.GetInt32(0);
                item.firstName = reader.GetString(1);
                item.lastName = reader.GetString(2);
                item.age = reader.GetInt32(3);
                item.phone = reader.GetString(4);
                item.email = reader.GetString(5);
                item.member = reader.GetBoolean(6);
                riderItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return riderItemList;
        }

        // Optional: sort (default is date)
        public List<ShowItem> GetShowItemList(string database, int year, string sort)
        {
            MySqlDataReader reader;
            ShowItem item;
            List<ShowItem> showItemList = new List<ShowItem>();

            if (sort == String.Empty)
                sort = "date";
            reader = GetReader(database, year + "_show", "show_no, date, show_name, show_comment", String.Empty, sort);
            while(reader.Read())
            {
                item = new ShowItem();
                item.no = reader.GetInt32(0);
                item.date = reader.GetString(1);
                item.name = reader.GetString(2);
                item.comments = reader.GetString(3);
                showItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return showItemList;
        }

        public bool AddValues(string database, string table, string column, string data)
        {
            return InsertData(database, table, column, data);
        }

        public bool ChangeValues(string database, string table, string data, string where)
        {
            return UpdateData(database, table, data, where);
        }

        public bool DeleteValues(string database, string table, string where)
        {
            return DeleteData(database, table, where);
        }

    }
}