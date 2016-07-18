// ==============================================================================
// 
// Version: 1.0
// Compiler: Visual Studio 2015
// Created: 2016-07-18 16:03
// Updated: 2016-07-18 16:03
// 
// Author: Clark Wu
// Company: dbuy.cc
// 
// Project: Clark.Tools.Expansion
// Filename: StringExpansion.cs
// Description: 
// 
// ==============================================================================

using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Clark.Tools.Expansion
{
    public static class StringExpansion
    {
        #region String

        /// <summary>
        /// IsNullOrEmpty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// IsNullOrWhiteSpace
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Format object[]
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// Format object
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <returns></returns>
        public static string Format(string format, object arg0)
        {
            return string.Format(format, arg0);
        }

        /// <summary>
        /// Regular expressions(validation)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pattern"></param>
        /// <returns>match = true</returns>
        public static bool IsMatch(this string s, string pattern)
        {
            return s != null && Regex.IsMatch(s, pattern);
        }

        /// <summary>
        /// Regular expressions(filter)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pattern"></param>
        /// <returns>match value</returns>
        public static string Match(this string s, string pattern)
        {
            return s == null ? "" : Regex.Match(s, pattern).Value;
        }

        /// <summary>
        /// IsInt(validation)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInt(this string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        /// <summary>
        /// ToInt
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        /// <summary>
        /// ToGuid
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string s)
        {
            return new Guid(s);
        }


        /// <summary>
        /// First ToLower
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToCamel(this string s)
        {
            if (s.IsNullOrEmpty()) return s;
            return s[0].ToString().ToLower() + s.Substring(1);
        }

        /// <summary>
        /// First ToUpper
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToPascal(this string s)
        {
            if (s.IsNullOrEmpty()) return s;
            return s[0].ToString().ToUpper() + s.Substring(1);
        }


        /// <summary>
        /// String Left len
        /// </summary>
        /// <param name="s"></param>
        /// <param name="len"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string Left(this string s, int len, string txt = "")
        {
            if (len >= s.Length)
                return s;
            return s.Substring(0, len) + txt;
        }

        /// <summary>
        /// String Right len
        /// </summary>
        /// <param name="s"></param>
        /// <param name="len"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string Right(this string s, int len, string txt = "")
        {
            if (len >= s.Length)
                return s;
            return txt + s.Substring(s.Length - len);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="shortDatePattern"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string s, string shortDatePattern = "MM/dd/yyyy")
        {
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo { ShortDatePattern = shortDatePattern };

            return Convert.ToDateTime(s, dtFormat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal[] ToDecimals(this string s)
        {
            var vMatchss = Regex.Matches(s, @"-?(0|[1-9]\d*)(\.\d+)?")
                .Cast<Match>();

            var vMatchs = vMatchss.Select(m => decimal.Parse(m.Value))
                  .ToArray();

            return vMatchs;
        }

        /// <summary>
        /// SBC case
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>SBC</returns>
        public static string ToSbc(this string str)
        {
            char[] c = str.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// DBC case
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>DBC</returns>
        public static string ToDbc(this string str)
        {
            char[] c = str.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        #endregion


    }
}