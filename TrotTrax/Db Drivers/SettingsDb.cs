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
    public partial class DBDriver
    {
        // Interactions for <year>_settings table
        #region Select Statements
        public string GetSettingValue(SettingType type)
        {
            string typeString;
            switch(type)
            {
                case SettingType.EntryFeeDiscountAmount: typeString = "EntryFeeDiscountAmount"; break;
                case SettingType.EntryFeeDiscountType: typeString = "EntryFeeDiscountType"; break;
                case SettingType.NonMemberPoint: typeString = "NonMemberPoint"; break;
                case SettingType.PlacingNo: typeString = "PlacingNo"; break;
                case SettingType.PointSchemeType: typeString = "PointSchemeType"; break;
                default: return null;
            }
                
            string query = "SELECT setting_value FROM [" + Year + "_settings] where setting_name = '" + typeString + "';";
            return DoTheScalar(ClubConn, query).ToString();
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
            query.Parameters.Add(new SQLiteParameter("@memberPointParam", nonMemberPoint));
            query.Parameters.Add(new SQLiteParameter("@placingNoParam", placingNo));
            query.Connection = ClubConn;
            return DoTheNonQuery(query);
        }
        #endregion
    }
}
