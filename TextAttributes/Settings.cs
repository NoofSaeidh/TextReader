using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAttributes
{
    /// <summary>
    /// Setting it is massive of parametrs using by SearchScript
    /// </summary>
    public class Settings
    {
        public Type ActiveSeparator { get; set; }

        public string CharSeparators { get; set; }

        public List<string> StringSeparators { get; set; }

        public int? CountSeparator { get; set; }

        /// <summary>
        /// Default Separator is space as a char
        /// </summary>
        public Settings(string CharSeparators = " ")
        {
            ActiveSeparator = typeof(string);
        }
        public Settings(
            string CharSeparators = null,
            List<string> StringSeparators = null,
            int? CountSeparators = null,
            Type ActiveSeparator = null
            )
        {
            this.ActiveSeparator = ActiveSeparator;
            this.CharSeparators = CharSeparators;
            this.StringSeparators = StringSeparators;
            this.ActiveSeparator = ActiveSeparator;
        }

    }
}
