using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public LineNumText(int Num, string Text)
        {
            this.Num = Num;
            this.Text = Text;
        }
        public LineNumText()
        {

        }
    }
    /// <summary>
    /// LineNumText extensions
    /// </summary>
    public static class LineNumTextListExtensions
    {
        /// <summary>
        /// Add LineNumText
        /// </summary>
        /// <param name="list"></param>
        /// <param name="Num">Line Number</param>
        /// <param name="Text">Line Text</param>
        public static void Add(this List<LineNumText> list, int Num, string Text)
        {
            list.Add(new LineNumText(Num, Text));
        }
    }
}
