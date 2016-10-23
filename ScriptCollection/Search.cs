using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <param name="OwnerAttribute">Attribute wich for this script will be execute, and that have it's method</param>
        /// <param name="Input"></param>
        /// <param name="Settings">if null - will search without separators</param>
        /// <returns>Dictionary: Key - Line Number; Value - Line Text</returns>
        [SearchMethod(Default = true)]
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
                        output.Add(num,line.Remove(0, OwnerAttribute.Name.Count()).Trim(), new Separator("@@@ $$$"));
                    num++;
                }
            }
            else
                foreach (var sep in Settings.Separators)
                {
                    foreach (var line in Input)
                    {
                        if (line.Contains(OwnerAttribute.Name + sep))
                            output.Add(num,line.Remove(0, OwnerAttribute.Name.Count() + 1).Trim(),sep);
                        num++;
                    }
                    OwnerAttribute.Separator = sep;
                }
            return output;
        }
    }
}
