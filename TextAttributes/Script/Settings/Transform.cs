﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextReader.Core.Common;


namespace TextReader.Core.Script.Settings
{

    public class Transform : ISettings<Reader>
    {
        public Reader Parent { get; internal set;}

        public List<AttributeHeader> SearchResults { get; set; }

        public Text Text { get; set; }

        public Transform(Text text = null, List < AttributeHeader> searchResults = null)
        {
            SearchResults = searchResults;
            Text = text;
        }
    }
}
