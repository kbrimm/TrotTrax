using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrotTrax
{
    class Settings
    {
        private DBDriver Database { get; set; }
        public string ClubID { get; private set; }
        public int Year { get; private set; }

        public char EntryFeeDiscountType;
        public decimal EntryFeeDiscountAmount;
        public bool NonMemberPoint;
        public char PointSchemeType;
        public int PlacingNo;
        public int[][] PointSchemeValues;

        public Settings(string clubId, int year)
        {
            Database = new DBDriver(1);
            ClubID = clubId;
            Year = year;
            EntryFeeDiscountType =  Char.Parse(Database.GetSettingValue(SettingType.EntryFeeDiscountType));
            if (EntryFeeDiscountType != 'n')
                EntryFeeDiscountAmount = Decimal.Parse(Database.GetSettingValue(SettingType.EntryFeeDiscountAmount));
            
            // Boolean requires extra switch. This is pretty inelegant.
            if(Int32.Parse(Database.GetSettingValue(SettingType.NonMemberPoint)) == 0)
                NonMemberPoint = false;
            else
                NonMemberPoint = true;

            PointSchemeType = Char.Parse(Database.GetSettingValue(SettingType.PointSchemeType));
            PlacingNo = Int32.Parse(Database.GetSettingValue(SettingType.PlacingNo));
            
        }

        public void SaveSettings(char discountType, decimal discountAmount, bool nonMemberPoint, char schemeType, int placingNo)
        {
            Database.UpdateSettings(discountType, discountAmount, nonMemberPoint, schemeType, placingNo);
        }
    }

    public enum SettingType
    {
        EntryFeeDiscountAmount,
        EntryFeeDiscountType,
        NonMemberPoint,
        PlacingNo,
        PointSchemeType
    }
}
