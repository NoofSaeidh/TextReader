using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextAttributes
{
    /// <summary>
    /// Class for output result contains line number contains attribute and text
    /// </summary>
    public class LineNumText
    {
        public int Num { get; set; }
        public string Text { get; set; }

        public LineNumText(int num, string text)
        {
            Num = num;
            Text = text;

        }
        public LineNumText()
        {

        }
    }

    public static class LineNumTextListExtensions
    {

        public static void Add(this List<LineNumText> list, int num, string text)
        {
            list.Add(new LineNumText(num, text));
        }
    }
}
