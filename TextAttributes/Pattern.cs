using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAttributes
{
    /// <summary>
    /// For Text use Wildcards for Attribute Name specify Attribute Mark
    /// </summary>
    public class Pattern
    {
        public string Text { get; set; }

        public string Substitute(string attribute)
        {
            return Text.Replace(Mark, attribute);
        }

        public static string Substitute(string pattern, string attribute, string mark = null)
        {
            if (mark == null) mark = DefaultMark;
            return pattern.Replace(mark, attribute);
        }

        public static string DefaultMark { get; set; } = "@@@";

        public string Mark { get; set; } = DefaultMark;

        public Pattern()
        {

        }

        public Pattern(string text, string mark = null):this()
        {
            Mark = mark!=null?mark:DefaultMark;
            Text = text;
        }

    }

    public static class SearchPatternListExtensions
    {
        public static List<Pattern> Add(this List<Pattern> list, string pattern, string mark = null)
        {
            list.Add(new Pattern(pattern, mark));
            return list;
        }
    }
}
