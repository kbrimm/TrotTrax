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
        public bool NonMemberPoints;
        public char PointsSchemeType;
        public int Placings;
        public int[][] PointSchemeValues;

        public Settings(string clubId, int year)
        {
            Database = new DBDriver(1);
            ClubID = clubId;
            Year = year;
        }
    }
}
