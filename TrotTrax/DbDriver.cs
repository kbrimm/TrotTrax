/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    class DBDriver
    {
        private MySqlConnection connection;
        private string server;
        private string port;
        private string usrID;
        private string password;

        // Initializes variables & checks for instance of database
        // Creates trax_data if not found
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
            if (!CheckTD())
            {
                string tableString = "id VARCHAR(10) NOT NULL, " +
                        "name VARCHAR(255), " +
                        "PRIMARY KEY (id)";

                CreateDB("trax_data");
                AddTable("trax_data", "club", tableString);

                tableString = "id VARCHAR(10) NOT NULL, " +
                    "year INT, " +
                    "FOREIGN KEY (id) REFERENCES trax_data.club(id) ON DELETE CASCADE";
                AddTable("trax_data", "current", tableString);
            }
            else
                Console.WriteLine("\tDatabase connection successful!");
        }

        // Adding an integer value to the driver instantiation skips the DB initialization check.
        public DBDriver(int value)
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
        // Note: The goal is to minimize the typing required in other functions,
        //     so most of the standard beginning/end of SQL commands is embedded here.
        private bool CreateDB(string database)
        {
            string query;
            bool success;

            Console.WriteLine("Creating database:" + database + ".");
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
            query = "DROP DATABASE " + database + ";";            
            success = DoTheNonQuery(query);
            if(success)
                return true;
            else
                return false;
        }

        // tableString requires SQL formatted variable parameters and key designations.
        private bool AddTable(string database, string table, string tableString)
        {
            string query;
            bool success;

            Console.WriteLine("Adding " + table + " to " + database + "...");
            query = "CREATE TABLE " + database + "." + table + " " +
                    "(" + tableString + ");";
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
            query = "DROP TABLE " + database + "." + table + ";";
            success = DoTheNonQuery(query);
            if (success)
                return true;
            else
                return false;
        }

        // dataString requires value data consistent with the fields of the target table.
        // Maybe needs stronger error checking to prevent coding errors from b0rking stuff.
        // Takes input as object to accomodate for strings or ints.
        private bool InsertData(string database, string table, string target, object data)
        {
            string query;
            bool success;

            Console.WriteLine("Adding data to " + database + "." + table);

            if (target != String.Empty)
                target = " (" + target + ")";
            query = "INSERT INTO " + database + "." + table + target + " " +
                "VALUES (" + data + ");";
            success = DoTheNonQuery(query);
            if (success)
                return true;
            else
                return false;
        }

        private bool UpdateData(string database, string table, string target, string data, string qualifier)
        {
            string query;
            bool success;

            Console.WriteLine("Updating data in " + database + "." + table);

            if (qualifier != String.Empty)
                qualifier = " WHERE " + qualifier;
            query = "UPDATE " + database + "." + table + " " +
                    "SET " + target + " = '" + data + "'" +
                    qualifier + ";";
            success = DoTheNonQuery(query);
            if (success)
                return true;
            else
                return false;
        }

        private bool UpdateData(string database, string table, string target, int data, string qualifier)
        {
            string query;
            bool success;

            Console.WriteLine("Updating data in " + database + "." + table);

            if (qualifier != String.Empty)
                qualifier = " WHERE " + qualifier;
            query = "UPDATE " + database + "." + table + " " +
                    "SET " + target + " = " + data + 
                    qualifier + ";";
            success = DoTheNonQuery(query);
            if (success)
                return true;
            else
                return false;
        }

        private bool DeleteData(string database, string table, string qualifier)
        {
            string query;
            bool success;

            Console.WriteLine("Deleting data in " + database + "." + table);
            if (qualifier != String.Empty)
                qualifier = " WHERE " + qualifier;
            query = "DELETE FROM " + database + "." + table + 
                    qualifier + ";";
            success = DoTheNonQuery(query);
            if (success)
                return true;
            else
                return false;
        }

        // qualifiers require SQL query of '[table_name] = [value]'
        // Essentially wraps ExecuteScalar, returns string value of the data found.
        public string GetValueString(string database, string table, string column, string qualifier)
        {
            string query;
            object response;

            Console.WriteLine("Retrieving value for " + column + " from " + database + ".");
            if (qualifier != String.Empty)
                qualifier = " WHERE " + qualifier;
            query = "SELECT " + column + " " +
                "FROM " + database + "." + table + qualifier + ";";
            response = DoTheScalar(query);
            if(response != null)
                return response.ToString();
            else
                return "Object not found";
        }

        public int GetValueInt(string database, string table, string column, string qualifier)
        {
            string query;
            object response;

            Console.WriteLine("Retrieving value for " + column + " from " + database + ".");
            if (qualifier != String.Empty)
                qualifier = " WHERE " + qualifier;
            query = "SELECT " + column + " " +
                "FROM " + database + "." + table + qualifier + ";";
            response = DoTheScalar(query);
            if (response != null)
                return Convert.ToInt32(response);
            else
                return 0;
        }

        // This is a fancy wrapper for DoTheReader.
        // Assembles the query, passes it to DoTheReader, then returns the reader to the calling function.
        // Private, because there's not much to be done with a reader as-is.
        private MySqlDataReader GetReader(string database, string table, string columns, string qualifier)
        {
            string query;
            MySqlDataReader reader;

            Console.WriteLine("Retrieving values for " + columns + " from " + database + ".");
            if (qualifier != String.Empty)
                qualifier = " WHERE " + qualifier;
            query = "SELECT " + columns + " " +
                "FROM " + database + "." + table + qualifier + ";";
            reader = DoTheReader(query);
            return reader;
        }

        private MySqlDataReader GetBackNoReader(string database, int year, string qualifier)
        {
            string query;
            MySqlDataReader reader;

            if (qualifier != String.Empty)
                qualifier = " WHERE " + qualifier;
            query = query = "SELECT b.back_no, r.first_name, r.last_name, h.name " +
                "FROM " + database + "." + year + "_back_no AS b " +
                "JOIN " + database + "." + year + "_rider AS r ON b.rider_no = r.rider_no " +
                "JOIN " + database + "." + year + "_horse AS h ON b.horse_no = h.horse_no" +
                qualifier + ";";
            reader = DoTheReader(query);
            return reader;
        }

        public List<string> GetValueList(string database, string table, string column)
        {
            MySqlDataReader reader;
            string item;
            List<string> list = new List<string>();

            Console.WriteLine("Procuring list of " + column + ".");
            reader = GetReader(database, table, column, String.Empty);
            while (reader.Read())
            {
                item = reader.GetString(0);
                list.Add(item);
            }
            reader.Close();
            connection.Close();
            return list;
        }

        //Three-value CountValue counts entries in a specified column
        public int CountValue(string database, string table, string column)
        {
            string query;
            object count;

            Console.WriteLine("Counting entries in " + column + ":");
            query = "SELECT count(" + column + ") " +
                "FROM " + database + "." + table + ";";
            count = DoTheScalar(query);
            if (count != null)
                return Convert.ToInt32(count);
            else
                return 0;
        }

        // Four-value CountValue counts occurrences of a specific value in a table.
        // Comes in string and int flavors.
        public int CountValue(string database, string table, string column, string value)
        {
            string query;
            object count;

            Console.WriteLine("Counting instances of " + value + ":");
            query = "SELECT count(*) " +
                "FROM " + database + "." + table + " " +
                "WHERE " + column + " = '" + value + "';";
            count = DoTheScalar(query);
            if (count != null)
                return Convert.ToInt32(count);
            else
                return 0;
        }

        public int CountValue(string database, string table, string column, int value)
        {
            string query;
            object count;

            Console.WriteLine("Counting instances of " + value + ":");
            query = "SELECT count(*) " +
                "FROM " + database + "." + table + " " +
                "WHERE " + column + " = " + value + ";";
            count = DoTheScalar(query);
            if (count != null)
                return Convert.ToInt32(count);
            else
                return 0;
        }

        // Returns true if value exists in table.
        // Comes in string and int flavors.
        public bool CheckValue(string database, string table, string column, string value)
        {
            string query;
            object count;

            Console.WriteLine("Counting instances of " + value + ":");
            query = "SELECT count(*) " +
                "FROM " + database + "." + table + " " +
                "WHERE " + column + " = '" + value + "';";
            count = DoTheScalar(query);
            if (count != null && Convert.ToInt32(count) > 0)
                return true;
            else
                return false;
        }

        public bool CheckValue(string database, string table, string column, int value)
        {
            string query;
            object count;

            Console.WriteLine("Counting instances of " + value + ":");
            query = "SELECT count(*) " +
                "FROM " + database + "." + table + " " +
                "WHERE " + column + " = " + value + ";";
            count = DoTheScalar(query);
            if (count != null && Convert.ToInt32(count) > 0)
                return true;
            else
                return false;
        }

        // The following functions provide specific database interaction functionality.
        // Because of the complexity of the interactions between the tables, I've tried to
        //     add as many pertinent comments as possible to keep things relatively clear.

        // Checks the initial instance of the trax_data database.
        private bool CheckTD()
        {
            string query;
            object checkValue;

            Console.WriteLine("Welcome to TrotTrax!\nChecking database...");
            query = "SELECT count(*) " +
                "FROM information_schema.TABLES " +
                "WHERE (TABLE_SCHEMA = 'trax_data') AND (TABLE_NAME = 'club');";
            checkValue = DoTheScalar(query);
            if (checkValue != null && Convert.ToInt32(checkValue) > 0)
                return true;
            else
                return false;
        }

        // Creates a new club entity
        // Requires a name and ID (generally acronym generated from full name)
        // Inserts club data into trax_data.clubs
        // Creates club DB & adds year table
        // Sets club to current.
        public void CreateClub(string id, string name)
        {
            string insertClubString = "'" + id + "', '" + name + "'";
            string yearString = "year INT NOT NULL, " +
                "PRIMARY KEY(year)";

            InsertData("trax_data", "club", String.Empty, insertClubString);
            CreateDB(id);
            AddTable(id, "show_year", yearString);
            SetClub(id);
        }

        // Resets data in current
        // Sets club as current
        public void SetClub(string id)
        {
            DeleteData("trax_data", "current", String.Empty);
            InsertData("trax_data", "current", "id", "'" + id + "'");
        }

        // Creates a new year for the current club
        // Generates table set for new year
        // Adds year to show_year table
        // Sets year as current
        public void CreateYear(string id, int year)
        {
            // rider: rider_no int (PK), first_name VC(255), last_name VC(255), age INT, contact VC(255), member BOOLEAN
            string riderString = "rider_no INT NOT NULL AUTO_INCREMENT, " +
                "first_name VARCHAR(255) NOT NULL, " +
                "last_name VARCHAR(255) NOT NULL, " +
                "age INT, " +
                "contact VARCHAR(255), " +
                "member BOOLEAN NOT NULL, " +
                "PRIMARY KEY (rider_no)";

            // horse: horse_no int (PK), name VC(255), nickname VC(255), height decimal(4,2)
            string horseString = "horse_no INT NOT NULL AUTO_INCREMENT, " +
                "name VARCHAR(255) NOT NULL, " +
                "nickname VARCHAR(255), " +
                "height DECIMAL(5,2), " +
                "PRIMARY KEY (horse_no)";

            // back_no: back_no int (PK), rider_no int (FK), horse_no int (FK)
            string back_noString = "back_no INT NOT NULL, " +
                "rider_no INT NOT NULL, " +
                "horse_no INT NOT NULL, " +
                "PRIMARY KEY (back_no), " +
                "FOREIGN KEY (rider_no) REFERENCES " + id + "." + year + "_rider(rider_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (horse_no) REFERENCES " + id + "." + year + "_horse(horse_no) ON DELETE CASCADE";

            // show_list: show_no int (PK), date VC(10), description VC(255), comments VC(500)
            string show_listString = "show_no INT NOT NULL AUTO_INCREMENT, " +
                "date VARCHAR(10), " +
                "description VARCHAR(255), " +
                "comment VARCHAR(500), " +
                "PRIMARY KEY (show_no)";

            // category: category_no int (PK), description VC(255), 
            string categoryString = "category_no INT NOT NULL AUTO_INCREMENT, " +
                "description VARCHAR(255), " +
                "timed BOOLEAN NOT NULL, " +
                "payout BOOLEAN NOT NULL, " +
                "jackpot BOOLEAN NOT NULL, " +
                "fee DECIMAL(5,2) NOT NULL, " +
                "PRIMARY KEY (category_no)";

            // class_list: class_no int (PK), category_no int (FK), name VC(255), fee decimal(5,2)
            string class_listString = "class_no INT NOT NULL, " +
                "category_no INT NOT NULL, " +
                "name VARCHAR(255) NOT NULL, " +
                "PRIMARY KEY (class_no), " +
                "FOREIGN KEY (category_no) REFERENCES " + id + "." + year + "_category(category_no) ON DELETE CASCADE";

            // results: show_no (FK), class_no (FK), back_no (FK), place int, time decimal(6,3), points int, paid_in decimal(5,2), paid_out decimal (5,2)
            string resultsString = "show_no INT NOT NULL, " +
                "class_no INT NOT NULL, " +
                "back_no INT NOT NULL, " +
                "place INT, " +
                "time DECIMAL(6,3), " +
                "points INT, " +
                "paid_in DECIMAL(5,3) NOT NULL, " +
                "paid_out DECIMAL(5,3), " +
                "FOREIGN KEY (show_no) REFERENCES " + id + "." + year + "_show_list(show_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (class_no) REFERENCES " + id + "." + year + "_class_list(class_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (back_no) REFERENCES " + id + "." + year + "_back_no(back_no) ON DELETE CASCADE";

            InsertData(id, "show_year", String.Empty, year);
            AddTable(id, year + "_rider", riderString);
            AddTable(id, year + "_horse", horseString);
            AddTable(id, year + "_back_no", back_noString);
            AddTable(id, year + "_show_list", show_listString);
            AddTable(id, year + "_category", categoryString);
            AddTable(id, year + "_class_list", class_listString);
            AddTable(id, year + "_results", resultsString);
            SetYear(year);
        }

        public void SetYear(int year)
        {
            UpdateData("trax_data", "current", "year", year, String.Empty);
        }

        public List<ShowItem> GetShowItemList(string database, int year)
        {
            MySqlDataReader reader;
            ShowItem item;
            List<ShowItem> showItemList = new List<ShowItem>();

            Console.WriteLine("Procuring list of shows.");
            reader = GetReader(database, year + "_show_list", "show_no, date, description", String.Empty);
            while(reader.Read())
            {
                item = new ShowItem();
                item.no = reader.GetInt32(0);
                item.date = reader.GetString(1);
                item.description = reader.GetString(2);
                showItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return showItemList;
        }

        public List<ClassItem> GetClassItemList(string database, int year)
        {
            MySqlDataReader reader;
            ClassItem item;
            List<ClassItem> classItemList = new List<ClassItem>();

            Console.WriteLine("Procuring list of classes.");
            reader = GetReader(database, year + "_class_list", "class_no, name", String.Empty);
            while(reader.Read())
            {
                item = new ClassItem();
                item.no = reader.GetInt32(0);
                item.name = reader.GetString(1);
                classItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return classItemList;
        }

        public List<BackNoItem> GetBackNoItemList(string database, int year)
        {
            MySqlDataReader reader;
            BackNoItem item;
            List<BackNoItem> backNoItemList = new List<BackNoItem>();

            Console.WriteLine("Procuring list of shows.");
            reader = GetBackNoReader(database, year, String.Empty);
            while(reader.Read())
            {
                item = new BackNoItem();
                item.no = reader.GetInt32(0);
                item.rider = reader.GetString(1) + " " + reader.GetString(2);
                item.horse = reader.GetString(3);
                backNoItemList.Add(item);
            }
            reader.Close();
            connection.Close();
            return backNoItemList;
        }
    }
}