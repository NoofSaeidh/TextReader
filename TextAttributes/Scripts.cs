using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TextAttributes;
using isTuple = System.Tuple<int, string>;

namespace TextAttributes
{
    /// <summary>
    /// This delegate descibes Script for search entries of Attribute in text
    /// </summary>
    /// <param name="Owner"></param>
    /// <param name="Input"></param>
    /// <param name="Settings"></param>
    /// <returns></returns>
    public delegate List<isTuple> SearchScript(TextAttributeHeader Owner, List<string> Input, object Settings);

    public delegate void ChangeScript(TextAttribute Owner, object Settings);

    public static class ScriptCollection
    {
        public static List<string> GetNames()
        {
            var names = new List<string>();
            var MArr = typeof(ScriptCollection).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public).
                Where(X => X.Name != "GetNames" && X.Name != "GetByName");
            foreach (var m in MArr)
                names.Add(m.Name);
            return names;

        }
        public static SearchScript GetByName(string ScriptName)
        {
            try
            {
                var M = typeof(ScriptCollection).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public).
                    Single(x => x.Name == ScriptName);
                return System.Delegate.CreateDelegate(typeof(SearchScript), M) as SearchScript;
            }
            catch (Exception e)
            {
                if (e.Message == "Sequence contains no matching element")
                    throw new System.Exception(string.Format("Script with name {0} does not exist", ScriptName));
                else
                    throw e;
            }
        }
        //public static List<isTuple> WithLine(TextAttributeHeader OwnerAttribute, List<string> Input, object Settings)
        //{
        //    var output = new List<isTuple>();
        //    int num = 0;
        //    foreach (var line in Input)
        //    {
        //        if (line.Contains(OwnerAttribute.Name))
        //            output.Add(new isTuple(num, line.Replace(OwnerAttribute.Name, "")));
        //        num++;
        //    }
        //    OwnerAttribute.Value = output;
        //    return output;
        //}
        //public static List<isTuple> WithOutLine(TextAttributeHeader OwnerAttribute, List<string> Input, object Settings)
        //{
        //    var output = new List<isTuple>();
        //    int num = 0;
        //    foreach (var line in Input)
        //    {
        //        if (line.Contains(OwnerAttribute.Name))
        //            output.Add(new isTuple(num, line));
        //        num++;
        //    }
        //    OwnerAttribute.Value = output;
        //    return output;
        //}


        /// <summary>
        /// Catches only lines started with Attribute Name
        /// Param "Settings" - string that contains separators for Attribute Name and text
        /// </summary>
        /// <param name="OwnerAttribute"></param>
        /// <param name="Input"></param>
        /// <param name="Settings"></param>
        /// <returns></returns>
        public static List<isTuple> Standart(TextAttributeHeader OwnerAttribute, List<string> Input, object Settings = null)
        {
            var output = new List<isTuple>();
            int num = 0;
            string settings;
            try
            {
                settings = Settings as string;
            }
            catch
            {
                throw new Exception("Settings is not string type. Use string instead");
            }
            if (Settings == null)
            {
                foreach (var line in Input)
                {
                    if (line.StartsWith(OwnerAttribute.Name))
                        output.Add(new isTuple(num, line.Remove(0, OwnerAttribute.Name.Count()).Trim()));
                    num++;
                }
            }
            else
                foreach (var ch in settings)
                {
                    foreach (var line in Input)
                    {
                        if (line.Contains(OwnerAttribute.Name + ch))
                            output.Add(new isTuple(num, line.Remove(0, OwnerAttribute.Name.Count()+1).Trim()));
                        num++;
                    }
                    OwnerAttribute.Value = output;
                }
            return output;
        }
    }
}

