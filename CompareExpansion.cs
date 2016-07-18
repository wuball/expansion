// ==============================================================================
// 
// Version: 1.0
// Compiler: Visual Studio 2015
// Created: 2016-07-18 11:27
// Updated: 2016-07-18 11:27
// 
// Author: Clark Wu
// Company: dbuy.cc
// 
// Project: Clark.Tools.Expansion
// Filename: CompareExpansion.cs
// Description: 
// 
// ==============================================================================

using System;

namespace Clark.Tools.Expansion
{
    public static class CompareExpansion
    {

        /// <summary>
        /// compare between 
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="t"></param>
        /// <param name="lowerBound">min </param>
        /// <param name="upperBound">max </param>
        /// <param name="includeLowerBound">include min :default false </param>
        /// <param name="includeUpperBound">include max :default false </param>
        /// <returns>include = true </returns>
        public static bool IsBetween<T>(this IComparable<T> t, T lowerBound, T upperBound,
            bool includeLowerBound = false, bool includeUpperBound = false)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            var lowerCompareResult = t.CompareTo(lowerBound);
            var upperCompareResult = t.CompareTo(upperBound);

            return (includeLowerBound && lowerCompareResult == 0) ||
                   (includeUpperBound && upperCompareResult == 0) ||
                   (lowerCompareResult > 0 && upperCompareResult < 0);
        }
    }
}