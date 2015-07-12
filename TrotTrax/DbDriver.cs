/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. Please see the file LICENSE in this distribution for license terms.
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

        // Initializes variables
        // Checks for instance of database
        // Creates trot_trax_data if not found
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

            }
            else
                Console.WriteLine("\tDatabase connection successful!");
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
        // Inserts club data into trot_trax_data.clubs
        // Creates new DB for club
        // Adds show_years table to club DB
        public void CreateClub(string id, string name)
        {
            string insertData = "'" + id + "', '" + name + "'";
            string tableData = "long_year INT NOT NULL, " +
                "yy INT NOT NULL, " +
                "PRIMARY KEY(long_year)";

            InsertData("trot_trax_data", "clubs", insertData);
            CreateDB(id);
            AddTable(id, "show_years", tableData);
        }

        // Creates a new show year to the club's database.
        // Inserts year data into id.years
        // Adds tables for year_backno, year_classes, year_horses, year_placings, year_riders, year_shows, 
        public void CreateYear(string id, string year)
        {
            string backnoData;
            string classData;
            string horseData;
            string riderData;
            string showData;
        }
    }
}