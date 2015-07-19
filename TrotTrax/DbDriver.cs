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

        // The following are some basic commands for interacting with the database.
        // They are all private, return bool, and they should all be self-explanatory.
        // Note: The goal is to minimize the typing required in other functions,
        //     so most of the standard beginning/end of SQL commands is embedded here.
        private bool CreateDB(string database)
        {
            MySqlCommand command;
            string query;

            Console.WriteLine("Creating database:" + database + ".");
            try
            {
                connection.Open();
                query = "CREATE DATABASE " + database + ";";
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("\tSuccess! :D");
                return true;
            }
            catch(Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                connection.Close();
                return false;
            }
        }

        private bool DropDB(string database)
        {
            MySqlCommand command;
            string query;

            Console.WriteLine("Dropping database:" + database + ".");
            try
            {
                connection.Open();
                query = "DROP DATABASE " + database + ";";
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

        // tableString requires SQL formatted variable parameters and key designations.
        private bool AddTable(string database, string table, string tableString)
        {
            MySqlCommand command;
            string query;

            try
            {
                connection.Open();
                Console.WriteLine("Adding " + table + " to " + database);
                query = "CREATE TABLE " + database + "." + table + " " +
                    "(" + tableString + ");";
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("\tSuccess! :D");
                return true;
            }
            catch(Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                connection.Close();
                return false;
            }
        }

        private bool DropTable(string database, string table)
        {
            MySqlCommand command;
            string query;

            try
            {
                connection.Open();
                Console.WriteLine("Dropping " + table + " from " + database);
                query = "DROP TABLE " + database + "." + table + ";" ;
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

        // dataString requries value data consistent with the fields of the target table.
        // Maybe needs stronger error checking to prevent coding errors from b0rking stuff.
        private bool InsertData(string database, string table, string target, string dataString)
        {
            MySqlCommand command;
            string query;

            try
            {
                connection.Open();
                Console.WriteLine("Adding data to " + database + "." + table);
                query = "INSERT " + target  + 
                "INTO " + database + "." + table + " " +
                    "VALUES(" + dataString + ");";
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

        // parameterString requires SQL query of '[table_name] = [value]'
        // Essentially wraps ExecuteScalar, returns string value of the data found.
        // For numerical values, the receiving function will need to cast.
        public string GetValue(string database, string table, string fieldString, string parameterString)
        {
            MySqlCommand command;
            string query;
            object response;

            Console.WriteLine("Retrieving value from:" + database + ".");
            try
            {
                connection.Open();
                query = "SELECT " + fieldString + " " +
                    "FROM " + database + "." + table + " " +
                    "WHERE " + parameterString + ";";
                command = new MySqlCommand(query, connection);
                response = command.ExecuteScalar();
                connection.Close();
                Console.WriteLine("\tSuccess! :D");
                return response.ToString();
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                connection.Close();
                return "Object not found";
            }
        }

        // The following functions provide specific database interaction functionality.
        // Because of the complexity of the interactions between the tables, I've tried to
        //     add as many pertinent comments as possible to keep things relatively clear.

        // Checks the initial instance of the trax_data database.
        private bool CheckTD()
        {
            MySqlCommand command;
            string query;
            object checkValue;

            Console.WriteLine("Welcome to TrotTrax!\nChecking database...");
            try
            {
                connection.Open();
                query = "SELECT count(*) " +
                    "FROM information_schema.TABLES " +
                    "WHERE (TABLE_SCHEMA = 'trax_data') AND (TABLE_NAME = 'club');";
                command = new MySqlCommand(query, connection);

                checkValue = command.ExecuteScalar();
                connection.Close();
                if (checkValue.ToString() != "0")
                    return true;
                else
                    return false;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                connection.Close();
                return false;
            }
        }

        // Checks for an existing "current club"
        public string CheckCurrentClub()
        {
            MySqlCommand command;
            string query;
            object checkValue;

            Console.WriteLine("Checking for current club...");
            try
            {
                connection.Open();
                query = "SELECT id " +
                    "FROM trax_data.current;";
                command = new MySqlCommand(query, connection);

                checkValue = command.ExecuteScalar();
                connection.Close();
                if (checkValue != null)
                    return checkValue.ToString();
                else
                    return null;
            }
            catch (Exception oops)
            {
                Console.WriteLine("\tSomething went wrong. :(");
                Console.WriteLine(oops.ToString());
                connection.Close();
                return "";
            }
        }

        // Creates a new club entity
        // Requires a name and ID (generally acronym generated from full name)
        // Inserts club data into trax_data.clubs
        // Creates club DB & adds tables
        public void CreateClub(string id, string name)
        {
            string insertClubString = "'" + id + "', '" + name + "'";

            string yearString = "year INT NOT NULL, " +
                "PRIMARY KEY(year)";

            // rider: rider_no int (PK), year int (FK), first_name VC(255), last_name VC(255), age INT, contact VC(255), member BOOLEAN
            string riderString = "rider_no INT NOT NULL AUTO_INCREMENT, " +
                "year INT NOT NULL, " +
                "first_name VARCHAR(255) NOT NULL, " +
                "last_name VARCHAR(255) NOT NULL, " +
                "age INT, " +
                "contact VARCHAR(255), " +
                "member BOOLEAN NOT NULL, " +
                "PRIMARY KEY (rider_no), " +
                "FOREIGN KEY (year) REFERENCES " + id + ".show_year(year) ON DELETE CASCADE";

            // horse: horse_no int (PK), year int (FK), name VC(255), nickname VC(255), height decimal(4,2)
            string horseString = "horse_no INT NOT NULL AUTO_INCREMENT, " +
                "year INT NOT NULL, " +
                "name VARCHAR(255) NOT NULL, " +
                "nickname VARCHAR(255), " +
                "height DECIMAL(5,2), " +
                "PRIMARY KEY (horse_no), " +
                "FOREIGN KEY (year) REFERENCES " + id + ".show_year(year) ON DELETE CASCADE";

            // back_no: back_no int (PK), year int (FK), rider_no int (FK), horse_no int (FK)
            string back_noString = "back_no INT NOT NULL, " +
                "year INT NOT NULL, " +
                "rider_no INT NOT NULL, " +
                "horse_no INT NOT NULL, " +
                "PRIMARY KEY (back_no), " +
                "FOREIGN KEY (year) REFERENCES " + id + ".show_year(year) ON DELETE CASCADE, " +
                "FOREIGN KEY (rider_no) REFERENCES " + id + ".rider(rider_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (horse_no) REFERENCES " + id + ".horse(horse_no) ON DELETE CASCADE";

            // show_list: show_no int (PK), year int (FK), date VC(10), description VC(255), comments VC(500)
            string show_listString = "show_no INT NOT NULL AUTO_INCREMENT, " +
                "year INT NOT NULL, " +
                "date VARCHAR(10), " +
                "description VARCHAR(255), " +
                "comment VARCHAR(500), " +
                "PRIMARY KEY (show_no), " +
                "FOREIGN KEY (year) REFERENCES " + id + ".show_year(year) ON DELETE CASCADE";

            // category: category_no int (PK), year int (FK), description VC(255), 
            string categoryString = "category_no INT NOT NULL AUTO_INCREMENT, " +
                "year INT NOT NULL, " +
                "description VARCHAR(255), " +
                "timed BOOLEAN NOT NULL, " +
                "payout BOOLEAN NOT NULL, " +
                "jackpot BOOLEAN NOT NULL, " +
                "PRIMARY KEY (category_no), " +
                "FOREIGN KEY (year) REFERENCES " + id + ".show_year(year)";

            // class_list: class_no int (PK), year int (FK), category_no int (FK), name VC(255), fee decimal(5,2)
            string class_listString = "class_no INT NOT NULL, " +
                "year INT NOT NULL, " +
                "category_no INT NOT NULL, " +
                "name VARCHAR(255) NOT NULL, " +
                "fee DECIMAL(5,2) NOT NULL, " +
                "PRIMARY KEY (class_no), " +
                "FOREIGN KEY (year) REFERENCES " + id + ".show_year(year) ON DELETE CASCADE, " +
                "FOREIGN KEY (category_no) REFERENCES " + id + ".category(category_no) ON DELETE CASCADE";

            // results: year int (FK), show_no (FK), class_no (FK), back_no (FK), place int, time decimal(6,3), points int, paid_in decimal(5,2), paid_out decimal (5,2)
            string resultsString = "year INT NOT NULL, " +
                "show_no INT NOT NULL, " +
                "class_no INT NOT NULL, " +
                "back_no INT NOT NULL, " +
                "place INT, " +
                "time DECIMAL(6,3), " +
                "points INT, " +
                "paid_in DECIMAL(5,3) NOT NULL, " +
                "paid_out DECIMAL(5,3), " +
                "FOREIGN KEY (year) REFERENCES " + id + ".show_year(year) ON DELETE CASCADE, " +
                "FOREIGN KEY (show_no) REFERENCES " + id + ".show_list(show_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (class_no) REFERENCES " + id + ".class_list(class_no) ON DELETE CASCADE, " +
                "FOREIGN KEY (back_no) REFERENCES " + id + ".back_no(back_no) ON DELETE CASCADE";

            InsertData("trax_data", "club", "", insertClubString);
            InsertData("trax_data", "current", "id", id);
            CreateDB(id);
            AddTable(id, "show_year", yearString);
            AddTable(id, "rider", riderString);
            AddTable(id, "horse", horseString);
            AddTable(id, "back_no", back_noString);
            AddTable(id, "show_list", show_listString);
            AddTable(id, "category", categoryString);
            AddTable(id, "class_list", class_listString);
            AddTable(id, "results", resultsString);
        }
    }
}