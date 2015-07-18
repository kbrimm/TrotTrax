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
        // Creates trot_trax_data if not found
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
            if (!CheckTTD())
            {
                string tableString = "id VARCHAR(10) NOT NULL, " +
                        "name VARCHAR(255), " +
                        "PRIMARY KEY (id) ";

                CreateDB("trot_trax_data");
                AddTable("trot_trax_data", "clubs", tableString);

                tableString = "id VARCHAR(10) NOT NULL, " +
                    "year INT NOT NULL, " +
                    "FOREIGN KEY (id) REFERENCES clubs(id)";
                AddTable("trot_trax_data", "current", tableString);
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
                return false;
            }
        }

        // dataString requries value data consistent with the fields of the target table.
        // Maybe needs stronger error checking to prevent coding errors from b0rking stuff.
        private bool InsertData(string database, string table, string dataString)
        {
            MySqlCommand command;
            string query;

            try
            {
                connection.Open();
                Console.WriteLine("Adding data to " + database + "." + table);
                query = "INSERT INTO " + database + "." + table + " " +
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
                return "Object not found";
            }
        }

        // The following functions provide specific database interaction functionality.
        // Because of the complexity of the interactions between the tables, I've tried to
        //     add as many pertinent comments as possible to keep things relatively clear.

        // Checks the initial instance of the trot_trax_data database.
        private bool CheckTTD()
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
                    "WHERE (TABLE_SCHEMA = 'trot_trax_data') AND (TABLE_NAME = 'clubs');";
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
                return false;
            }
        }

        // Creates a new club entity
        // Requires a name and ID (generally acronym generated from full name)
        // Inserts club data into trot_trax_data.clubs
        // Creates club DB
        // Adds show_years table to club DB
        public void CreateClub(string id, string name)
        {
            string insertData = "'" + id + "', '" + name + "'";
            string tableData = "year INT NOT NULL, " +
                "yy INT NOT NULL, " +
                "PRIMARY KEY(year)";

            InsertData("trot_trax_data", "clubs", insertData);
            CreateDB(id);
            AddTable(id, "show_years", tableData);
        }

        // Creates a new show year to the club's database
        // Requires the club ID and the four digit year
        // Inserts year data into id.years
        // Adds tables for year_backno, year_classes, year_horses, year_placings, year_riders, year_shows, 
 /*       public void CreateYear(string id, string year)
        {
            string backnoData;      // backNo, horseNo, riderNo, totalPoints; PK backNo; FK horseNo, riderNo
            string categoryData;    // categoryNo, description, timed; PK categoryNo
            string classData;       // classNo, name, cost, categoryNo; PK classNo; FK categoryNo
            string placeData;       // showDate, classNo, backNo, time, place, fee, payout, points; FK showDate, classNo, backNo
            string horseData;       // horseNo, name, size, PK horseNo
            string riderData;       // riderNo, firstName, lastName, age, contact, isMember, totalFees, totalPmts; PK riderNo
            string showData;        // showDate, description, PK showDate
        }
  */
    }
}