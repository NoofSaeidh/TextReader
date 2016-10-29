using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextAttributes;

namespace ScriptCollection
{

    [SearchCollection]
    public class Search
    {

        /// <summary>
        /// Catches only lines started with Attribute Name
        /// </summary>
        /// <param name="owner">Attribute wich for this script will be execute, and that have it's method</param>
        /// <param name="settings">Notice that text in settings</param>
        /// <returns>Dictionary: Key - Line Number; Value - Line Text</returns>
        [SearchMethod(Default = true)]
        public static List<LineNumText> DefaultSearch(TextAttributeHeader owner, Settings settings)
        {
            var output = new List<LineNumText>();
            var Input = settings.Text;

            //if (Settings.Regexs == null)
            //{
            //    foreach (var line in Input)
            //    {
            //        if (line.StartsWith(OwnerAttribute.Name))
            //            output.Add(num,line.Remove(0, OwnerAttribute.Name.Count()).Trim(), new Regex("@@@ $$$"));
            //        num++;
            //    }
            //}
            //else
            var Pattern = settings.Pattern!=null?settings.Pattern: new Pattern("@@@: *");
            var pattern = Pattern.Substitute(owner.Name);

            int num = 0;
            foreach (var line in Input)
            {
                if(Regex.IsMatch(line,pattern))
                {
                    output.Add(num, Regex.Replace(line, pattern, ""));
                }
                num++;
            }
            owner.RecoverPattern = Pattern;

            return owner.Value = output;
        }
    }
}
