using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime FirstDayOfMonth(this DateTime dt)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
        }

        public static DateTime FirstDayOfLastMonth(this DateTime dt)
        {
            DateTime lastmonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
            return new DateTime(lastmonth.Year, lastmonth.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime dt)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
        }

        public static DateTime LastDayOfLastMonth(this DateTime dt)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
        }

        public static string ToMySqlString(this DateTime dt)
        {
            return dt.ToString("yyy-MM-dd hh:mm:ss");
        }
    }
}
