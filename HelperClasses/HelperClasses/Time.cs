using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperClasses
{
    public static class Time
    {
        static string StringFormat = "yyyy-MM-dd HH:mm:ss";

        public static string Now()
        { 
            return DateTime.Now.ToString(StringFormat);
        }

        public static DateTime GetCheckDbNull(object o)
        {
            if (o.GetType() == typeof(DBNull)) return new DateTime();
            else
                return Convert.ToDateTime(o);
        }

        public static string GetString(DateTime d)
        {
            return d.ToString(StringFormat);
        }

        public static string GetStringQuoted(DateTime d)
        {
            return "'" + d.ToString(StringFormat) + "'";
        }

        public static DateTime Hex2DateTime(short DDHH, short MMSS)
        {
            int Day = 10 * (DDHH >> 12) + ((DDHH & 0x0F00) >> 8);
            int Hour = 10 * ((DDHH&0x00F0) >> 4) + ((DDHH & 0x000F));
            int Minute = 10 * (MMSS >> 12) + ((MMSS & 0x0F00) >> 8);
            int Second = 10 * ((MMSS & 0x00F0) >> 4) + ((MMSS & 0x000F));

            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, Day, Hour, Minute, Second);
        }

        public static DateTime Hex2DateTime(short YYMM, short DDHH, short MMSS)
        {
            int Year = 10 * (YYMM >> 12) + ((YYMM & 0x0F00) >> 8) + 2000;
            int Month = 10 * ((YYMM & 0x00F0) >> 4) + ((YYMM & 0x000F));
            int Day = 10 * (DDHH >> 12) + ((DDHH & 0x0F00) >> 8);
            int Hour = 10 * ((DDHH & 0x00F0) >> 4) + ((DDHH & 0x000F));
            int Minute = 10 * (MMSS >> 12) + ((MMSS & 0x0F00) >> 8);
            int Second = 10 * ((MMSS & 0x00F0) >> 4) + ((MMSS & 0x000F));

            return new DateTime(Year, Month, Day, Hour, Minute, Second);
        }
    }
}
