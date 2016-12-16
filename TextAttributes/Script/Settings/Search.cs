using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextReader.Core.Common;


namespace TextReader.Core.Script.Settings
{
    /// <summary>
    /// Settings for scripts
    /// </summary>
    public class Search : ISettings<AttributeHeader>
    {
        public AttributeHeader Parent { get; internal set; }

		public Pattern Pattern { get; set; }

        public Text Text { get; internal set; }

        public Search()
        {

        }

		public Search(Pattern pattern = null)
        {
            Pattern = pattern;
		}
    }
}
