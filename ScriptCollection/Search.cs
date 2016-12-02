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

		[Script(/*Type = typeof(Search) ,*/Default = true, UserName ="Default script", UserDescription = "Script search for something")]
		public static void DefaultSearch(Search settings)
        {
            //var output = new List<LineNum>();
            //var Input = settings.Text;
            //var Pattern = settings.Pattern!=null?settings.Pattern: new Pattern("@@@: *");
            //var pattern = Pattern.Substitute(owner.Name);

            //int num = 0;
            //foreach (var line in Input)
            //{
            //    if(Regex.IsMatch(line,pattern))
            //    {
            //        output.Add(num, Regex.Replace(line, pattern, ""));
            //    }
            //    num++;
            //}
            //owner.RecoverPattern = Pattern;

            //return owner.Value = output;
        }
    }
}
