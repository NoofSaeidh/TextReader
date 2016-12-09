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
        public AttributeHeader Parent { get; set; }

		public Pattern Pattern { get; internal set; }

        public Text Text { get; set; }

        public Search()
        {

        }

		public Search(Pattern pattern = null,Text text = null)
        {
            Pattern = pattern;
            Text = text;
		}
    }
}
