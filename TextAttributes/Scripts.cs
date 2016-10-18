using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TextAttributes;


namespace TextAttributes
{
    /// <summary>
    /// This delegate descibes Script for search entries of Attribute in text
    /// </summary>
    /// <param name="Owner"></param>
    /// <param name="Input"></param>
    /// <param name="Settings"></param>
    /// <returns>List of: int - Line Number; string - Line Text<</returns>
    public delegate List<LineNumText> SearchScript(
		TextAttributeHeader Owner, 
		List<string> Input, 
		Settings Settings);

	public delegate TextAttribute ChangeScript(
		TextAttributeHeader Owner,
		List<string> Input,
		Settings Settings,
		object SearchResults);

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

        /// <summary>
        /// Catches only lines started with Attribute Name
        /// 
        /// </summary>
        /// <param name="OwnerAttribute">Attribute wich for this script will be execute, and that have it's method</param>
        /// <param name="Input"></param>
        /// <param name="Settings">if null - will search without separators</param>
        /// <returns>Dictionary: Key - Line Number; Value - Line Text</returns>
        public static List<LineNumText> DefaultSearch(
			TextAttributeHeader OwnerAttribute, 
			List<string> Input, 
			Settings Settings = null)
        {
            var output = new List<LineNumText>();
            int num = 0;
            if (Settings == null || Settings.Separators == null)
            {
                foreach (var line in Input)
                {
                    if (line.StartsWith(OwnerAttribute.Name))
                        output.Add(
                            num,
                            line.Remove(
                                0, OwnerAttribute.Name.Count())
                        .Trim()
                        );
                    num++;
                }
            }
            else
                foreach (var sep in Settings.Separators)
                {
                    foreach (var line in Input)
                    {
                        if (line.Contains(OwnerAttribute.Name + sep))
                            output.Add(
                                num,
                                line.Remove(
                                    0, OwnerAttribute.Name.Count() + 1)
                            .Trim()
                            );
                            num++;
                    }
                    OwnerAttribute.Separator = sep;
                }
            return output;
        }

		public static TextAttribute DefaultChange(
			TextAttributeHeader Owner,
			List<string> Input,
			Settings Settings,
			object SearchResults)
		{
			if(SearchResults != null)
			{
				if(SearchResults is IList)
				{
					var listResult = (IList)SearchResults;
					listResult.
					var typeResult = typeof(listResult)
				}
			}
		}
    }
}

