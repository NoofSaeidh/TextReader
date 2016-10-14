using System.Collections.Generic;
using System;

namespace TextAttributes
{
    public class TextAttributeHeader : TextAttribute
    {
        /// <summary>
        /// Value for Header is List of Tuple where int - line number, string line text
        /// </summary>
        new public List<Tuple<int, string>> Value { get; internal set; }

        /// <summary>
        /// Script for search this attribute in text
        /// </summary>
        public SearchScript SearchScript { get; set; }

        public TextAttributeHeader() : base()
        {
            Value = new List<Tuple<int, string>>();
        }

        public TextAttributeHeader(string Name, EType Type, bool Displayed):base(Name,Type,Displayed)
        {
            Value = new List<Tuple<int, string>>();
        }

        public TextAttributeHeader(string Name, EType Type, bool Displayed, SearchScript SearchScript) : base(Name, Type, Displayed)
        {
            Value = new List<Tuple<int, string>>();
            this.SearchScript = SearchScript;
        }

        public TextAttributeHeader(string Name):base(Name)
        {
            Value = new List<Tuple<int, string>>();
        }
    }
}
