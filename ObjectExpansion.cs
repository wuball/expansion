// ==============================================================================
// 
// Version: 1.0
// Compiler: Visual Studio 2015
// Created: 2016-07-18 15:38
// Updated: 2016-07-18 15:38
// 
// Author: Clark Wu
// Company: dbuy.cc
// 
// Project: Clark.Tools.Expansion
// Filename: ObjectExpansion.cs
// Description: 
// 
// ==============================================================================

using System;

namespace Clark.Tools.Expansion
{
    public static class ObjectExpansion
    {

        public static void ConsoleWriteLine(this object obj)
        {
            Console.WriteLine(obj);
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

    }
}