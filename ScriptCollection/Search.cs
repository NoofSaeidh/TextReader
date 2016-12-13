using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextReader.Core.Common;
using TextReader.Core.Script;
using TextReader.Core;
using TextReader.Core.Script.Settings;

namespace ScriptCollection
{

    public static class SearchCollection
    {

		[Script(Default = true, UserName ="Default script", UserDescription = "Script search for something")]
		public static void DefaultSearch(Search settings)
        {
            var output = new List<LineNum>();
            var Input = settings.Text;
            var Pattern = settings.Pattern != null ? settings.Pattern : new Pattern("@@@: *");
            var pattern = Pattern.Substitute(settings.Parent.Name);

            int num = 0;
            foreach (var line in Input)
            {
                if (Regex.IsMatch(line, pattern))
                {
                    output.Add(num, Regex.Replace(line, pattern, ""));
                }
                num++;
            }
            settings.Parent.RecoverPattern = Pattern;
            settings.Parent.Value = output;
        }
    }
}
