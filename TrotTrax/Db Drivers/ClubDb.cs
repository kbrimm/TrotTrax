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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    // Interactions w
    public partial class DBDriver
    {
        #region Club 

        private string GetCurrentClubId()
        {
            string query = "SELECT club_id FROM current LIMIT 1;";
            object response = DoTheScalar(trotTraxConn, query);
            return response.ToString();
        }

        public string GetCurrentClubName()
        {
            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "SELECT club_name FROM club WHERE club_id = @idparam";
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.Add(new SQLiteParameter("@idparam", GetCurrentClubId()));

            object response = DoTheScalar(trotTraxConn, query);
            return response.ToString();
        }

        public List<ClubItem> GetClubItemList()
        {
            SQLiteDataReader reader;
            ClubItem item;
            List<ClubItem> clubItemList = new List<ClubItem>();
            string query = "SELECT club_id, club_name FROM club ORDER BY club_name DESC;";

            reader = DoTheReader(trotTraxConn, query);
            while (reader.Read())
            {
                item = new ClubItem();
                item.clubID = reader.GetString(0);
                item.clubName = reader.GetString(1);
                clubItemList.Add(item);
            }
            reader.Close();
            trotTraxConn.Close();
            return clubItemList;
        }

        #endregion

        #region Year

        public int GetCurrentYear()
        {
            string query = "SELECT current_year FROM current LIMIT 1;";
            object response = DoTheScalar(trotTraxConn, query);
            try
            {
                return Convert.ToInt32(response);
            }
            catch
            {
                Console.WriteLine("No value found. :(");
                return 0;
            }
        }

        private int GetLatestYear()
        {
            string query;
            object response;

            query = "SELECT year FROM show_year ORDER BY year DESC LIMIT 1;";
            response = DoTheScalar(clubConn, query);

            try
            {
                return Convert.ToInt32(response);
            }
            catch
            {
                Console.WriteLine("No value found. :(");
                return 0;
            }
        }

        public List<int> GetYearItemList()
        {
            SQLiteDataReader reader;
            List<int> yearItemList = new List<int>();
            string query = "SELECT year FROM show_year ORDER BY year DESC;";

            reader = DoTheReader(trotTraxConn, query);
            while (reader.Read())
            {
                yearItemList.Add(reader.GetInt32(0));
            }
            reader.Close();
            trotTraxConn.Close();
            return yearItemList;
        }

        #endregion
    }
}
