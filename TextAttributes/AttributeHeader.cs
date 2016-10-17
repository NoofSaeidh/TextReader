using System.Collections.Generic;
using System;

namespace TextAttributes
{
    public class TextAttributeHeader : TextAttribute
    {
		/// <summary>
		/// Value for Header is always null!
		/// </summary>
		new public string Value
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Separator that was used in text
		/// </summary>
		public string Separator { get; internal set; }

		/// <summary>
		/// Script for search this attribute in text
		/// </summary>
		public SearchScript SearchScript { get; set; }

        public TextAttributeHeader() : base()
        {

        }

        public TextAttributeHeader(string Name, EType Type = EType.Optional, bool Displayed = false, SearchScript SearchScript = null) : base(Name, Type, Displayed)
        {
            this.SearchScript = SearchScript;
        }

    }
}
