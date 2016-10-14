using System.Collections.Generic;
using System.Linq;
using System.IO;
using TextAttributes;

namespace TxtReader.Reader
{
    /// <summary>
    /// Класс для распознования и разложения в классы текста
    /// </summary>
    public class Reader
    {
        public List<string> TextFile { protected set; get; }

        public List<TextAttributeHeader> AttributeHeaderCollection { get; set; }

        public List<Record> RecordCollection { get; protected set; }

        #region Constructors

        public Reader() : this(null, null)
        {

        }

        public Reader(string Path) : this(Path, null)
        {

        }

        public Reader(string Path, List<TextAttributeHeader> AttributeHeaderCollection)
        {
            if (Path == null)
                TextFile = new List<string>();
            else
                this.ReadFile(Path);
            if (AttributeHeaderCollection == null)
                AttributeHeaderCollection = new List<TextAttributeHeader>();
            else
                this.AttributeHeaderCollection = AttributeHeaderCollection;
            RecordCollection = new List<Record>();
        }

        #endregion

        public void ReadFile(string Path)
        {
            TextFile = File.ReadAllLines(Path).ToList();
        }

        public List<Record> CreateRecordCollection()
        {
            RecordCollection = new List<Record>();


            return RecordCollection;
        }

        #region Attributes Creation Methods

        public void ClearAttributeHeaderCollection()
        {
            AttributeHeaderCollection = new List<TextAttributeHeader>();
        }

        public void AddAttributeHeader(string AttributeName,
            TextAttribute.EType Type = TextAttribute.EType.Optional,
            bool Displayed = false,
            SearchScript SearchScript = null)
        {
            AttributeHeaderCollection.Add(new TextAttributeHeader(AttributeName, Type, Displayed, SearchScript));
        }

        public void AddAttributeHeader(string[] AttributeNames,
            TextAttribute.EType Type = TextAttribute.EType.Optional,
            bool Displayed = false,
            SearchScript SearchScript = null)
        {
            foreach (var name in AttributeNames)
                AttributeHeaderCollection.Add(new TextAttributeHeader(name, Type, Displayed, SearchScript));
        }

        public void AddAttributeHeader(List<string> AttributeNames,
            TextAttribute.EType Type = TextAttribute.EType.Optional,
            bool Displayed = false,
            SearchScript SearchScript = null)
        {
            foreach (var name in AttributeNames)
                AttributeHeaderCollection.Add(new TextAttributeHeader(name, Type, Displayed, SearchScript));
        }

        public void AddAttributeHeader(
            TextAttribute.EType Type,
            bool Displayed,
            SearchScript SearchScript,
            params string[] AttributeNames)
        {
            foreach (var name in AttributeNames)
                AttributeHeaderCollection.Add(new TextAttributeHeader(name, Type, Displayed, SearchScript));
        }
        #endregion
    }
}
