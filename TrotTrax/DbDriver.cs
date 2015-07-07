/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    class DBDriver
    {
        private string clubID { get; set; }
        private string clubName { get; set; }

        public DBDriver()
        {
            clubID = "BHCSC";
            clubName = "Black Hawk Creek Saddle Club";

            bool dbExists = CheckDB();

            if (!dbExists)
            {
                Console.WriteLine("The DB does not exist. We should build it!");
                CreateClub();
            }
            else
                Console.WriteLine("The DB does exist! We can proceed with more interesting stuff.");
        }

        private SqlConnection GetConnection()
        {
            SqlConnection dbConn = null;
            Console.WriteLine("Creating connection to server.");
            try
            {
                dbConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                return dbConn;
            }
            catch(Exception oops)
            {
                Console.WriteLine(oops.ToString());
                return null;
            }
        }

        // Manages queries to database which result in a change of data. Does not retun a value.
        public void ChangeData(string queryString)
        {
            SqlConnection dbConn = GetConnection();
            SqlCommand query = new SqlCommand(queryString, dbConn);

             try
            {
                dbConn.Open();
                query.ExecuteNonQuery();
                Console.WriteLine("\tQuery executed successfully.");
            }
            catch(Exception oops)
            {
                Console.WriteLine(oops.ToString() + "\n\tSomething went wrong. :(");
            }
            finally
            {
                dbConn.Close();
            }
        }

        // Need to devise a way to check to see if the actual DB is up and running before attempting to create it a bajillion times
        // when it only needs to create a new club.
        private bool CheckDB()
        {
            Console.WriteLine("Checking to see if " + clubID + " database exists.");

            SqlConnection dbConn = GetConnection();
            string query = "SELECT id " +
                "FROM  trax_data.dbo.club " +
                "WHERE id = '" + clubID + "';";
            SqlCommand command = new SqlCommand(query, dbConn);

            Console.WriteLine("Executing query.");
            try
            {
                dbConn.Open();
                object queryResult = command.ExecuteScalar();

                dbConn.Close();
                if(queryResult.ToString() == clubID)
                    return true;
                else
                    return false;
            }
            catch(Exception oops)
            {
                Console.WriteLine(oops.ToString());
                return false;
            }
        }

        // Think about making the create command more specific (allocating specific file locations/sizes/whatever)
        // This should get run only when the user selects to configure database.
        private void CreateDB()
        {
            Console.WriteLine("Creating new DB");

            // Creates database "trax_data".
            string query = "CREATE DATABASE trax_data; ";
            ChangeData(query);

            // Creates table "dbo.club", initializes two fields.
            query = "CREATE TABLE trax_data.dbo.club " +
                "( " +
                "id		VARCHAR(10)		NOT NULL, " +
                "name	VARCHAR(100)	NULL, " +
                "CONSTRAINT PK_club_id PRIMARY KEY CLUSTERED (id) " +
                ");";
            ChangeData(query);
        }

        // Enters the club in to the dbo.club table (needs to receive the full name), then creates its schema and a clubID.years table.
        // Don't forget to validate input for escape sequences.
        private void CreateClub()
        {
            Console.WriteLine("Adding " + clubName + " to club data.");

            string query = "INSERT INTO trax_data.dbo.club " +
                "VALUES ('" + clubID + "', '" + clubName + "'); ";
            ChangeData(query);

            query = "CREATE SCHEMA " + clubID + "; ";
            ChangeData(query);

            query = "CREATE TABLE trax_data." + clubID + ".year " +
                "( " +
                "show_year  INT NOT NULL, " +
                "CONSTRAINT PK_year_show_year PRIMARY KEY CLUSTERED (show_year) " +
                ");";
            ChangeData(query);
        }
    }
}