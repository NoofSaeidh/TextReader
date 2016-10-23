using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAttributes
{
    public class Separator
    {
        public string SeparatorForm { get; set; }

        /// <summary>
        /// By default Mark is @@@. Use .Replace("Attribute", "@@@")
        ///  This is separator for @@@ sample.
        /// </summary>
        public string AttributeMark { get; set; }

        public string TextMark { get; set; }

        public Separator() : this(null)
        {

        }

        public Separator(string SeparatorForm, string AttributeMark = "@@@", string TextMark = "$$$")
        {
            this.AttributeMark = AttributeMark;
            this.SeparatorForm = SeparatorForm;
            this.TextMark = TextMark;
        }

    }

    public static class SeparatorListExtensions
    {
        public static List<Separator> Add(this List<Separator> List, string SeparatorForm, string AttributeMark = null, string TextMark = null)
        {
            if (AttributeMark != null && TextMark != null)
                List.Add(SeparatorForm, AttributeMark, TextMark);
            else if (AttributeMark != null)
                List.Add(SeparatorForm, AttributeMark: AttributeMark);
            else if (TextMark != null)
                List.Add(SeparatorForm, TextMark: TextMark);
            else
                List.Add(SeparatorForm);
            return List;
        }
    }
}
