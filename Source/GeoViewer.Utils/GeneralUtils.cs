/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace GeoViewer.Utils
{
    public static class GeneralUtils
    {
        public const String Digit = "0123456789";
        public const String Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public const String AlphabetDigit = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static int ToInt32TryParse(this object input, int catchValue = 0)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch { return catchValue; }
        }

        public static long ToInt64TryParse(this object input, long catchValue = 0)
        {
            try
            {
                return Convert.ToInt64(input);
            }
            catch { return catchValue; }
        }

        public static double ToDoubleTryParse(this object input, double catchValue = 0)
        {
            try
            {
                return Convert.ToDouble(input, new CultureInfo("en-US"));
            }
            catch { return catchValue; }
        }

        public static Decimal ToDecimalTryParse(this object input, long catchValue = 0)
        {
            try
            {
                return Convert.ToDecimal(input, new CultureInfo("en-US"));
            }
            catch { return catchValue; }
        }

        public static DateTime? ToDateTimeTryParse(this object input, DateTime? catchValue = null)
        {
            try
            {
                return Convert.ToDateTime(input, new CultureInfo("vi-VN"));
            }
            catch { return catchValue; }
        }

        public static Boolean ToBooleanTryParse(this object input, Boolean catchValue = true)
        {
            try
            {
                return Convert.ToBoolean(input);
            }
            catch { return catchValue; }
        }

        public static Guid ToGuid(this object input)
        {
            return new Guid(input.ToString());
        }

        public static List<String> SplitToList(this String str, char spliter = ',')
        {
            var list = new List<String>();
            if (str.Contains(spliter))
            {
                list = str.Split(spliter).Where(ent => !string.IsNullOrEmpty(ent)).ToList();
            }
            else
            {
                list.Add(str);
            }
            return list;
        }

        public static string GenerateRandomString(int length = 7, String chars = AlphabetDigit)
        {
            StringBuilder str = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                str.Append(chars[rand.Next(chars.Length)]);
            }
            return str.ToString();
        }

        public static string ToDecimalString(this decimal input)
        {
            return input.ToString(CultureInfo.CreateSpecificCulture("en-US"));
        }
        public static string ToDecimalString(this decimal? input)
        {
            if (input == null) return "";
            return ((decimal)input).ToString(CultureInfo.CreateSpecificCulture("en-US"));
        }
    }

}
