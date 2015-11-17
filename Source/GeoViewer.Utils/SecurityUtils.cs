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
    public static class SecurityUtils
    {
        /// <summary>
        /// Get MD5 Encode Of String
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String GetMd5Hash(this string input)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] bs = Encoding.UTF8.GetBytes(input);

            bs = x.ComputeHash(bs);

            var s = new StringBuilder();

            foreach (var b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            String md5String = s.ToString();
            return md5String;
        }
    }
}
