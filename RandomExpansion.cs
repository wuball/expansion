// ==============================================================================
// 
// Version: 1.0
// Compiler: Visual Studio 2015
// Created: 2016-07-18 15:42
// Updated: 2016-07-18 15:42
// 
// Author: Clark Wu
// Company: dbuy.cc
// 
// Project: Clark.Tools.Expansion
// Filename: RandomExpansion.cs
// Description: 
// 
// ==============================================================================

using System;

namespace Clark.Tools.Expansion
{
    public static class RandomExpansion
    {
        /// <summary>
        /// random code only number
        /// </summary>
        /// <param name="random"></param>
        /// <param name="length">length</param>
        /// <returns></returns>
        public static int NextCode(this Random random, int length = 6)
        {
            var bn = Math.Pow(10, Math.Abs(length));
            var en = Math.Pow(10, Math.Abs(length + 1));

            //include min, exclude max
            return random.Next((int)bn, (int)en);
        }

        /// <summary>
        /// random bool 
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static bool NextBool(this Random random)
        {
            return random.NextDouble() > 0.5;
        }

        /// <summary>
        /// random enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="random"></param>
        /// <returns></returns>
        public static T NextEnum<T>(this Random random)
            where T : struct
        {
            var type = typeof(T);
            if (type.IsEnum == false) throw new InvalidOperationException();

            var array = Enum.GetValues(type);
            var index = random.Next(array.GetLowerBound(0), array.GetUpperBound(0) + 1);
            return (T)array.GetValue(index);
        }


        /// <summary>
        /// random byte 
        /// </summary>
        /// <param name="random"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] NextBytes(this Random random, int length)
        {
            var data = new byte[length];
            random.NextBytes(data);
            return data;
        }

        /// <summary>
        /// random Uint16/ushort
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static ushort NextUInt16(this Random random)
        {
            return BitConverter.ToUInt16(random.NextBytes(2), 0);
        }

        /// <summary>
        /// random Int16/short 
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static short NextInt16(this Random random)
        {
            return BitConverter.ToInt16(random.NextBytes(2), 0);
        }


        /// <summary>
        /// random Int32 
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static int NextInt32(this Random random)
        {
            return BitConverter.ToInt32(random.NextBytes(2), 0);
        }

        /// <summary>
        /// random float 
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static float NextFloat(this Random random)
        {
            return BitConverter.ToSingle(random.NextBytes(4), 0);
        }

        /// <summary>
        /// random float 
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static double NextDouble(this Random random)
        {
            return BitConverter.ToDouble(random.NextBytes(4), 0);
        }

        /// <summary>
        /// random datetime 
        /// </summary>
        /// <param name="random"></param>
        /// <param name="minValue">begin </param>
        /// <param name="maxValue">end </param>
        /// <returns></returns>
        public static DateTime NextDateTime(this Random random, DateTime minValue, DateTime maxValue)
        {
            var ticks = minValue.Ticks + (long)((maxValue.Ticks - minValue.Ticks) * random.NextDouble());
            return new DateTime(ticks);
        }

        /// <summary>
        /// random datetime (unlimited)
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static DateTime NextDateTime(this Random random)
        {
            return NextDateTime(random, DateTime.MinValue, DateTime.MaxValue);
        }
    }
}