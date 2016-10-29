using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextAttributes
{
    /// <summary>
    /// Settings for scripts
    /// </summary>
    public class Settings
    {
		public Pattern Pattern { get; set; }

        public List<string> Text { get; set; }

        public List<TextAttributeHeader> SearchResults { get; set; }

        public Settings()
        {

        }

		public Settings(Pattern Pattern = null,List<string> Text = null, List<TextAttributeHeader> SearchResults = null)
        {
            this.Pattern = Pattern;
            this.Text = Text;
            this.SearchResults = SearchResults;
		}
    }
}
