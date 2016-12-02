using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextReader.Core.Common
{
    /// <summary>
    /// Class for output result contains line number contains attribute and text
    /// </summary>
    public class LineNum
    {
        public int Num { get; set; }
        public string Text { get; set; }

        public LineNum(int num, string text)
        {
            Num = num;
            Text = text;

        }
        public LineNum()
        {

        }
    }

    public static class LineNumTextListExtensions
    {

        public static void Add(this List<LineNum> list, int num, string text)
        {
            list.Add(new LineNum(num, text));
        }
    }
}
