using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GeoViewer.Utils
{
    public static class ValidationUtils
    {
        /// <summary>
        /// Check valid user name
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidUsername(this string input)
        {
            Regex r = new Regex("^[a-zA-Z0-9_]{4,20}$");
            return r.IsMatch(input);
        }

        /// <summary>
        /// Check valid email
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidEmail(this string input)
        {
            Regex r = new Regex(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$");
            return r.IsMatch(input);
        }

        /// <summary>
        /// Check valid length
        /// </summary>
        /// <param name="input"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsValidLength(this string input, int min = 0, int max = 250)
        {
            if (input == null) return min < 0;
            return (input.Trim().Length >= min) && (input.Trim().Length <= max);
        }
    }
}
