/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    public partial class DBDriver
    {
        // Interactions for <year>_settings  and <year>_pointscheme tables
        #region Select Statements

        public string GetSettingValue(SettingType type)
        {
            string typeString;
            switch (type)
            {
                case SettingType.EntryFeeDiscountAmount: typeString = "EntryFeeDiscountAmount"; break;
                case SettingType.EntryFeeDiscountType: typeString = "EntryFeeDiscountType"; break;
                case SettingType.NonMemberPoint: typeString = "NonMemberPoint"; break;
                case SettingType.PlacingNo: typeString = "PlacingNo"; break;
                case SettingType.PointSchemeType: typeString = "PointSchemeType"; break;
                default: return null;
            }     
            string query = "SELECT setting_value FROM [" + Year + "_settings] WHERE setting_name = '" + typeString + "';";
            return DoTheScalar(ClubConn, query).ToString();
        }

        public ArrayList GetGraduatedPointScheme(int places)
        {
            ArrayList pointScheme = new ArrayList();
            int[] pointList;
            for (int i = 1; i <= places; i++)
            {
                string query = "SELECT * FROM [" + Year + "_pointscheme WHERE entries = '" + places + "';";
                SQLiteDataReader reader = DoTheReader(ClubConn, query);
                pointList = new int[places];

                for (int p = 0; p <= places; p++)
                    pointList[p] = reader.GetInt32(p + 1);

                pointScheme.Add(pointList);
                reader.Close();
            }
            return pointScheme;
        }

        public ArrayList GetFlatPointScheme(int places)
        {
            ArrayList pointScheme = new ArrayList();
            int[] pointList;

            string query = "SELECT * FROM [" + Year + "_pointscheme] LIMIT 1;";
            SQLiteDataReader reader = DoTheReader(ClubConn, query);
            reader.Read();
            pointList = new int[places + 1];
            for (int p = 0; p <= places; p++)
                pointList[p] = reader.GetInt32(p);

            pointScheme.Add(pointList);
            reader.Close();

            return pointScheme;
        }

        #endregion   

        #region Insert Statements

        public bool AddPointScheme(ArrayList pointScheme, int places = 6)
        {
            string insertString = String.Empty;
            int entries = 1;

            string dropString = "DROP TABLE IF EXISTS [" + Year + "_pointscheme];";
            if (DoTheNonQuery(ClubConn, dropString))
            {
                // Create tables
                string createString = "CREATE TABLE [" + Year + "_pointscheme] ( entries INTEGER NOT NULL";

                for (int i = 1; i <= places; i++)
                    createString += ", [" + i + "] INTEGER";

                createString += " );";
                DoTheNonQuery(ClubConn, createString);
            }

            // For each number of entries
            foreach (int[] item in pointScheme)
            {
                // Construct insert string
                insertString += "INSERT INTO [" + Year + "_pointscheme] VALUES ( " + entries;

                for (int i = 1; i <= places; i++)
                    insertString += ", " + item[i]; 

                insertString += " ); ";
                entries++;
            }
            return DoTheNonQuery(ClubConn, insertString); ;
        }

        private bool GetDefaultPointSchemeTable()
        {
            ArrayList pointScheme = new ArrayList();
            int[] points = new int[7] {0, 6, 5, 4, 3, 2, 1};
            pointScheme.Add(points);
            return AddPointScheme(pointScheme);
        }

        #endregion

        #region Update Statements

        public bool UpdateSettings(char discountType, decimal discountAmount, bool nonMemberPoint, char schemeType, int placingNo)
        {
            // Parameterizing the character input yielded unsatisfactory results.
            if (discountType == '\'')
                discountType = 'n';
            if (schemeType == '\'')
                schemeType = 'f';

            SQLiteCommand query = new SQLiteCommand();
            query.CommandText = "UPDATE [" + Year + "_settings] SET setting_value = '" + discountType + "' WHERE setting_name = 'EntryFeeDiscountType'; " +
                "UPDATE [" + Year + "_settings] SET setting_value = @discountAmountParam WHERE setting_name = 'EntryFeeDiscountAmount'; " +
                "UPDATE [" + Year + "_settings] SET setting_value = @memberPointParam WHERE setting_name = 'NonMemberPoint'; " +
                "UPDATE [" + Year + "_settings] SET setting_value = '" + schemeType + "' WHERE setting_name = 'PointSchemeType'; " +
                "UPDATE [" + Year + "_settings] SET setting_value = @placingNoParam WHERE setting_name = 'PlacingNo';";
            query.Parameters.Add(new SQLiteParameter("@discountAmountParam", discountAmount));
            query.Parameters.Add(new SQLiteParameter("@memberPointParam", BoolToInt(nonMemberPoint)));
            query.Parameters.Add(new SQLiteParameter("@placingNoParam", placingNo));
            query.Connection = ClubConn;
            return DoTheNonQuery(query);
        }

        #endregion   
    }
}
