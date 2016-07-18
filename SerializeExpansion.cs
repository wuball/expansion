// ==============================================================================
// 
// Version: 1.0
// Compiler: Visual Studio 2015
// Created: 2016-07-18 11:35
// Updated: 2016-07-18 11:35
// 
// Author: Clark Wu
// Company: dbuy.cc
// 
// Project: Clark.Tools.Expansion
// Filename: SerializeExpansion.cs
// Description: 
// 
// ==============================================================================

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clark.Tools.Expansion
{
    public static class SerializeExpansion
    {
        #region Json , Newtonsoft.json


        public static string GetJsonValue(this string str, string key)
        {
            JObject obj = (JObject)JsonConvert.DeserializeObject(str);
            return obj[key].ToString();
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        #endregion


    }
}