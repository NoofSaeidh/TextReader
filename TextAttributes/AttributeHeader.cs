using System.Collections.Generic;
using TextReader.Core.Common;
using TextReader.Core.Script;
using TextReader.Core.Script.Settings;

namespace TextReader.Core
{
    public class AttributeHeader : Attribute
    {
        public static EType DefaultType { get; set; } = EType.Optional;

        public static bool DefaultDisplayed { get; set; } = false;

        public static Script<Search> DefaultSearchScript { get; set; } = null;

        public static Search DefaultSetting { get; set; } = null;

        private Search _settings;
        /// <summary>
        /// You can no specify Parent for settings, it is assigns to this insance in Setting's setter
        /// </summary>
        public Search Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                _settings = value;
                if (!(value is null))
                    _settings.Parent = this;
            }
        }

        /// <summary>
        /// Internal Value - Should use ChangeScript after SearchScript
        /// </summary>
        new public List<LineNum> Value { get; set; }

        /// <summary>
		/// Script for search this attribute in text
		/// </summary>
		public Script<Search> SearchScript { get; set; }

        public AttributeHeader() : base()
        {

        }

        /// <summary>
        /// All nulls becoming Defaults
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="displayed"></param>
        /// <param name="settings"></param>
        /// <param name="searchScript"></param>
        public AttributeHeader(string name, EType? type = null, bool? displayed = null, Search settings = null, Script<Search> searchScript = null)
        {
            this.Name = name;

            if (type == null)
                Type = DefaultType;
            else
                Type = (EType)type;

            if (displayed == null)
                Displayed = DefaultDisplayed;
            else
                Displayed = (bool)displayed;

            if (searchScript == null)
                SearchScript = DefaultSearchScript;
            else
                SearchScript = searchScript;

            if (settings == null)
                Settings = DefaultSetting;
            else
                Settings = settings;

        }

        public void Search(Search settings)
        {
            if (SearchScript is null) throw new TextException("SearchScript null reference");
            Settings = settings;
            SearchScript(Settings);
        }

        public void Search()
        {
            if (Settings is null) throw new TextException("DefaultSetting null reference");
            Search(Settings);
        }
    }

    public static class AttributeHeaderListExtensions
    {
        public static List<AttributeHeader> Add(this List<AttributeHeader> list, string name, Attribute.EType? type = null,
            bool? displayed = null, Script<Search> searchScript = null)
        {
            var header = new AttributeHeader(name);
            if (type != null) header.Type = (Attribute.EType)type;
            if (displayed != null) header.Displayed = (bool)displayed;
            if (searchScript != null) header.SearchScript = searchScript;
            list.Add(header);
            return list;
        }

        public static void Search(this List<AttributeHeader> list, Search settings)
        {
            foreach (var header in list)
            {
                header.Search(settings);
            }

        }

        public static void Search(this List<AttributeHeader> list)
        {
            foreach (var header in list)
            {
                header.Search();
            }
        }

        //public static List<List<LineNum>> Search(this List<AttributeHeader> List, List<string> Text)
        //{
        //    var listlist = new List<List<LineNum>>();
        //    foreach (var header in List)
        //    {
        //        listlist.Add(header.Search(new SearchSettings(text: Text)));
        //    }
        //    return listlist;
        //}
    }
}
