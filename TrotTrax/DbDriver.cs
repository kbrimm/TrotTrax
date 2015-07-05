using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    class DbDriver
    {
        private string dbAddress;
        private string dbName;

        public DbDriver()
        {
            dbName = "BHCSC";
            dbAddress = "C:\\Program Files\\TrotTrax\\Data";

            bool dbExists = checkDb();

            if (!dbExists)
            {
                Console.WriteLine("The DB does not exist. We should build it!");
                createDb();
            }
            else
                Console.WriteLine("The DB does exist! We can proceed with more interesting stuff.");
        }

        public SqlConnection getConnection()
        {
            SqlConnection dbConn = null;
            Console.WriteLine("Creating connection to server.");
            try
            {
                dbConn = new SqlConnection("Integrated Security=SSPI;Initial Catalog=" + dbName + ";Data Source=localhost;");
                return dbConn;
            }
            catch(Exception oops)
            {
                Console.WriteLine(oops.ToString());
                return null;
            }
        }

        private bool checkDb()
        {
            Console.WriteLine("Checking to see if " + dbName + " database exists.");

            SqlConnection dbConn = getConnection();
            string query = "SELECT year " +
                "FROM " + dbName + "dbo.show_years";
            SqlCommand command = new SqlCommand(query, dbConn);

            Console.WriteLine("Executing query.");
            try
            {
                dbConn.Open();
                object queryResult = command.ExecuteScalar();

                dbConn.Close();
                if(queryResult != null)
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

        private void createDb()
        {
            Console.WriteLine("Creating new DB");

            SqlConnection dbConn = getConnection();
            string commandStr = "CREATE DATABASE [" + dbName + "] ON PRIMARY " +
                "( NAME = N'" + dbName + "', FILENAME = N'" + dbAddress + dbName + ".mdf') " +
                " LOG ON " +
                "( NAME = N'" + dbName + "_log', FILENAME = N'" + dbAddress + dbName + "_log.ldf') " +
                "GO ";
            SqlCommand command = new SqlCommand(commandStr, dbConn);

            try
            {
                dbConn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Database created successfully.");
            }
            catch(Exception oops)
            {
                Console.WriteLine(oops.ToString() + "\nSomething went wrong. :(");
            }
            finally
            {
                dbConn.Close();
            }
        }
    }
}