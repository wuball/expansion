// ==============================================================================
// 
// Version: 1.0
// Compiler: Visual Studio 2015
// Created: 2016-07-18 11:01
// Updated: 2016-07-18 11:01
// 
// Author: Clark Wu
// Company: dbuy.cc
// 
// Project: Clark.Tools.Expansion
// Filename: CollectionsExpansion.cs
// Description: 
// CollectionsExpansion , help to using
// ==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Clark.Tools.Expansion
{
    public static class CollectionsExpansion
    {
        #region IEnumerable

        /// <summary>
        /// Collection to String by separator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string EnumerableToString<T>(this IEnumerable<T> collection, string separator = ",")
        {
            return collection.IsEmpty() ? null : string.Join(separator, collection);
        }

        /// <summary>
        /// Collection is null ?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns>null=true</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            return !collection.Any();
        }

        /// <summary>
        /// If condition is true , append predicate 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// Group by keySelector
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            return source.GroupBy(keySelector).Select(group => group.First());
        }

        #endregion

        #region IQueryable

        /// <summary>
        /// If condition is true , append predicate 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }


        #endregion

    }
}
