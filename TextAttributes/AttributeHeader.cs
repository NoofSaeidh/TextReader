using System.Collections.Generic;
using System;

namespace TextAttributes
{
    public class TextAttributeHeader : TextAttribute
    {
		/// <summary>
		/// Internal Value - Should use ChangeScript after SearchScript
		/// </summary>
		new public List<LineNumText> Value { get; internal set; }

		/// <summary>
		/// Separator that was used in text
		/// </summary>
		public string Separator { get; internal set; }

		/// <summary>
		/// Script for search this attribute in text
		/// </summary>
		public SearchScript SearchScript { get; set; }

        public ChangeScript ChangeScript { get; set; }

        public TextAttributeHeader() : base()
        {

        }

        public TextAttributeHeader(string Name, EType Type = EType.Optional, bool Displayed = false, SearchScript SearchScript = null) : base(Name, Type, Displayed)
        {
            this.SearchScript = SearchScript;
        }

		public List<LineNumText> Search(List<string> Text, Settings Settings)
		{
			if(SearchScript!=null)
			{
				Value = SearchScript(this, Text, Settings);
				return Value;
			}
			throw new Exception("SearchScript null reference");
		}

		public TextAttribute Change(List<string> Text, Settings Settings, object FoundCollection = null) 
		{
			if (ChangeScript != null)
			{
				return ChangeScript(this, Text, Settings, FoundCollection);
			}
			throw new Exception("ChangeScript null reference");
		}

	}
}
