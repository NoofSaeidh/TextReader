using System.Collections.Generic;
using System;

namespace TextAttributes
{
    public class TextAttributeHeader : TextAttribute
    {
        public static EType DefaultType = EType.Optional;

        public static bool DefaultDisplayed = false;

        public static SearchScript DefaultSearchScript = null;

        public static ChangeScript DefaultChangeScript = null;

		/// <summary>
		/// Internal Value - Should use ChangeScript after SearchScript
		/// </summary>
		new public List<LineNumText> Value { get; internal set; }

        /// <summary>
		/// Script for search this attribute in text
		/// </summary>
		public SearchScript SearchScript { get; set; }

        public ChangeScript ChangeScript { get; set; }

        public TextAttributeHeader() : base()
        {

        }

        /// <summary>
        /// All nulls becoming Defaults
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Type"></param>
        /// <param name="Displayed"></param>
        /// <param name="SearchScript"></param>
        public TextAttributeHeader(string Name, EType? Type = null, bool? Displayed = null, SearchScript SearchScript = null, ChangeScript ChangeScript = null)
        {
            this.Name = Name;
            if (Type == null)
                this.Type = DefaultType;
            else
                this.Type = (EType)Type;
            if (Displayed == null)
                this.Displayed = DefaultDisplayed;
            else
                this.Displayed = (bool)Displayed;
            if (SearchScript == null)
                this.SearchScript = DefaultSearchScript;
            else
                this.SearchScript = SearchScript;
            if (ChangeScript == null)
                this.ChangeScript = DefaultChangeScript;
            else
                this.ChangeScript = ChangeScript;
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

		public TextAttribute Change(List<string> Text, Settings Settings, object SearchResult = null) 
		{
			if (ChangeScript != null)
			{
				return ChangeScript(this, Text, Settings, SearchResult);
			}
			throw new Exception("ChangeScript null reference");
		}

	}

    public static class TextAttributeHeaderListExtensions
    {
        public static List<TextAttributeHeader> Add(this List<TextAttributeHeader> List, string Name, TextAttribute.EType? Type = null, 
            bool? Displayed = null, SearchScript SearchScript = null, ChangeScript ChangeScript = null)
        {
            var header = new TextAttributeHeader(Name);
            if (Type != null) header.Type= (TextAttribute.EType)Type;
            if (Displayed != null) header.Displayed= (bool)Displayed;
            if (SearchScript != null) header.SearchScript = SearchScript;
            if (ChangeScript != null) header.ChangeScript = ChangeScript;
            List.Add(header);
            return List;
        }

        public static List<List<LineNumText>> Search(this List<TextAttributeHeader> List, List<string> Text, Settings Settings)
        {
            var listlist = new List<List<LineNumText>>();
            foreach (var header in List)
            {
                listlist.Add(header.Search(Text, Settings));
            }
            return listlist;
        }
    }
}
