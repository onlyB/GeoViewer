/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoViewer.Utils
{
    public static class DatetimeUtils
    {
        /// <summary>
        /// Get the subtraction (in date) of firstDate and secondDate
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns></returns>
        public static Double SubTwoDate(DateTime firstDate, DateTime secondDate)
        {
            return Math.Floor((Double)(firstDate.Ticks - secondDate.Ticks) / 864000000000);
        }

        public static DateTime FirstDateOfWeek(this DateTime date)
        {
            return date.AddDays(-(int)date.DayOfWeek);
        }

        public static DateTime FirstDateOfWeek()
        {
            return DateTime.Now.Date.FirstDateOfWeek();
        }

        public static DateTime FirstDateOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime FirstDateOfMonth()
        {
            return DateTime.Now.Date.FirstDateOfMonth();
        }
        
        public static string ToDatetimeString(this DateTime? date)
        {
            if (date == null) return "";
            return ((DateTime)date).ToString("dd/MM/yyyy , hh:mm tt");
        }

        public static string ToDatetimeString(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy , hh:mm tt");
        }
    }
}
