using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        public ArrayList PointSchemeValues;

        public Settings(string clubId, int year)
        {
            Database = new DBDriver(1);
            ClubID = clubId;
            Year = year;
            GetSettingsValues();
        }

        private void GetSettingsValues()
        {
            EntryFeeDiscountType =  Char.Parse(Database.GetSettingValue(SettingType.EntryFeeDiscountType));
            if (EntryFeeDiscountType != 'n')
                EntryFeeDiscountAmount = Decimal.Parse(Database.GetSettingValue(SettingType.EntryFeeDiscountAmount));
            
            // Boolean requires extra switch. 
            if(Int32.Parse(Database.GetSettingValue(SettingType.NonMemberPoint)) == 0)
                NonMemberPoint = false;
            else
                NonMemberPoint = true;

            PointSchemeType = Char.Parse(Database.GetSettingValue(SettingType.PointSchemeType));
            PlacingNo = Int32.Parse(Database.GetSettingValue(SettingType.PlacingNo));
            if (PointSchemeType == 'f')
                PointSchemeValues = Database.GetFlatPointScheme(PlacingNo);
            else
                PointSchemeValues = Database.GetGraduatedPointScheme(PlacingNo);
        }

        public void SaveSettings(char discountType, decimal discountAmount, bool nonMemberPoint, char schemeType, int placingNo,
            ArrayList pointScheme)
        {
            Database.UpdateSettings(discountType, discountAmount, nonMemberPoint, schemeType, placingNo);
            Database.AddPointScheme(pointScheme, placingNo);
        }

        public void NewPointScheme(int size, bool multidimensional)
        {
            int[] pointArray;
            ArrayList pointScheme = new ArrayList();

            if (multidimensional)
            for (int i = 1; i <= size; i++)
            {
                pointArray = new int[size + 1];
                pointArray[0] = i;
                pointScheme.Add(pointArray);
            }
            else
            {
                pointArray = new int[size + 1];
                pointArray[0] = 0;
                pointScheme.Add(pointArray);
            }
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
