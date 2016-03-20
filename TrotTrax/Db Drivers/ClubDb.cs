/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
 */

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    public partial class DBDriver
    {
        #region Select statements

        public string GetCurrentClubId()
        {
            string query = "SELECT club_id FROM current LIMIT 1;";
            object response = DoTheScalar(TrotTraxConn, query);
            if (response != null)
                return response.ToString();
            else
                return null;
        }

        public string GetCurrentClubName()
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT club_name FROM club WHERE club_id = @idparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@idparam", GetCurrentClubId()));
            query.Connection = TrotTraxConn;

            object response = DoTheScalar(query);
            return response.ToString();
        }

        // Returns a club from the club table if one exists.
        private string GetExistingClub()
        {
            string clubSelect = "SELECT club_id FROM club ORDER BY club_id LIMIT 1;";
            return DoTheScalar(TrotTraxConn, clubSelect).ToString();
        }

        public bool CheckClubExists(string id)
        {
            SQLiteCommand query = new SQLiteCommand();
            object response;
            int count = -1;

            query.CommandText = "SELECT COUNT(*) FROM club WHERE club_id = @idparam;";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@idparam", id));
            query.Connection = TrotTraxConn;
            response = DoTheScalar(query);

            try
            {
                count = Convert.ToInt32(response);
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                Console.WriteLine("No value for club " + id + " found. :(");
                return false;
            }
        }

        public List<ClubItem> GetClubItemList()
        {
            SQLiteDataReader reader;
            ClubItem item;
            List<ClubItem> clubItemList = new List<ClubItem>();
            string query = "SELECT club_id, club_name FROM club ORDER BY club_name DESC;";

            reader = DoTheReader(TrotTraxConn, query);
            while (reader.Read())
            {
                item = new ClubItem();
                item.ClubId = reader.GetString(0);
                item.ClubName = reader.GetString(1);
                clubItemList.Add(item);
            }
            reader.Close();
            TrotTraxConn.Close();
            return clubItemList;
        }

        #endregion

        #region Insert statements

        // Creates a new club entity
        // Requires a name and ID
        // Inserts club data into trot_trax.clubs
        // Creates club DB & adds year table
        public bool AddClub(string id, string name)
        {
            // Construct and execute club table creation query
            SQLiteCommand clubInsert = new SQLiteCommand();
            clubInsert.CommandText = "INSERT INTO club (club_id, club_name) VALUES (@idparam, @nameparam);";
            clubInsert.CommandType = System.Data.CommandType.Text;
            clubInsert.Parameters.Add(new SQLiteParameter("@idparam", id));
            clubInsert.Parameters.Add(new SQLiteParameter("@nameparam", name));
            clubInsert.Connection = TrotTraxConn;
            bool success = DoTheNonQuery(clubInsert);

            // If club successfully added, create database and year table
            if(success)
            {
                // Create new club database
                ClubConn = new SQLiteConnection("Data Source=" + id + ".db;Version=3;");
                SQLiteConnection.CreateFile(id + ".db");

                // Construct and execute year table creation query
                string yearTable = "CREATE TABLE show_year ( year INTEGER NOT NULL, UNIQUE (year) );";
                success =  DoTheNonQuery(ClubConn, yearTable);
            }
            return success;
        }

        #endregion

        #region Delete statements

        public void DeleteClub(string id)
        {
            // Delete club data from club & current
            SQLiteCommand clubDelete = new SQLiteCommand();
            clubDelete.CommandText = "DELETE FROM club WHERE club_id = @idparam; " + 
                "DELETE FROM current WHERE club_id = @idparam;";
            clubDelete.CommandType = System.Data.CommandType.Text;
            clubDelete.Parameters.Add(new SQLiteParameter("@idparam", id));
            clubDelete.Connection = TrotTraxConn;
            if (DoTheNonQuery(clubDelete))
            {
                Console.Out.WriteLine(id + " deleted from club database.");
            }
            else
            {
                Console.Out.WriteLine("Error while deleting " + id + " from club database.");
            }

            // Reset clubConn, drop club database
            ClubConn.Close();
            ClubConn.Dispose();
            ClubConn = null;
            File.Delete(id + ".db");
            if (File.Exists(id + ".db"))
            {
                Console.Out.WriteLine("Unable to delete database file.");
            }
            else
            {
                Console.Out.WriteLine("Database file successfully deleted!");
            }
        }

        #endregion
    }
}
