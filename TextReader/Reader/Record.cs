using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using TextAttributes;

namespace TxtReader.Reader
{
    /// <summary>
    /// Record - the main essence of text that contains many parametrs.
    /// </summary>
    public class Record : ICollection, IList, IEnumerable
    {
        /// <summary>
        /// First TextAttribute will be set as primary. Primary TextAttribute reflects beggining of record.
        /// </summary>
        /// <param name="TextAttributes"></param>
        public Record(params TextAttribute[] TextAttributes)
        {
            foreach (var item in TextAttributes)
            {
                Add(item);
            }
            PrimaryTextAttribute = TextAttributeCollection[0];
        }

        /// <summary>
        /// First TextAttribute will be set as primary. Primary TextAttribute reflects beggining of record.
        /// </summary>
        public Record(List<TextAttribute> TextAttributes)
        {
            foreach (var item in TextAttributes)
            {
                Add(item);
            }
            PrimaryTextAttribute = TextAttributeCollection[0];
        }

        /// <summary>
        /// Primary TextAttribute reflects beggining of record.
        /// </summary>
        /// <param name="TextAttributes"></param>
        public Record(string PrimaryTextAttributeName, params TextAttribute[] TextAttributes)
        {
            foreach (var item in TextAttributes)
            {
                Add(item);
            }
            this.PrimaryTextAttributeName = PrimaryTextAttributeName;
        }

        /// <summary>
        /// Primary TextAttribute reflects beggining of record.
        /// </summary>
        public Record(string PrimaryTextAttributeName, List<TextAttribute> TextAttributes)
        {
            foreach (var item in TextAttributes)
            {
                Add(item);
            }
            this.PrimaryTextAttributeName = PrimaryTextAttributeName;
        }

        /// <summary>
        /// ~~~~~
        /// </summary>
        public string RecordToString
        {
            get
            {
                throw new Exception("MAKE METHOD");
            }
        }

        /// <summary>
        /// ~~~~~
        /// </summary>
        public List<string> RecordToText
        {
            get
            {
                return RecordToString.Split('\n').ToList();
            }
        }

        /// <summary>
        /// ~~~~~
        /// </summary>
        public System.Xml.XmlAttributeCollection RecordToXml
        {
            get
            {
                throw new Exception("MAKE METHOD");
            }
        }

        private string primaryName;

        /// <summary>
        /// Primary TextAttribute reflects beggining of record.
        /// </summary>
        /// 
        public string PrimaryTextAttributeName
        {
            get
            {
                return primaryName;
            }

            set
            {
                primaryName = value;
                if (TextAttributeCollection.Count(x => x.Name == primaryName) > 1)
                    throw new Exception("There are more than 1 TextAttribute with the specific name");
                if (TextAttributeCollection.Count(x => x.Name == primaryName) == 0)
                    throw new Exception("There are no TextAttributes with the specific name");
            }
        }

        /// <summary>
        /// Primary TextAttribute reflects beggining of record.
        /// </summary>
        public TextAttribute PrimaryTextAttribute
        {
            get
            {
                return TextAttributeCollection.Single(x => x.Name == primaryName);
            }

            set
            {
                primaryName = value.Name;
                if (TextAttributeCollection.Count(x => x.Name == primaryName) > 1)
                    throw new Exception("There are more than 1 TextAttribute with the specific name");
                if (TextAttributeCollection.Count(x => x.Name == primaryName) == 0)
                    Add(value);
            }
        }

        private List<TextAttribute> TextAttributeCollection { get; set; }

        private void CheckForNoDublicates(TextAttribute TextAttribute)
        {
            foreach (var item in TextAttributeCollection)
            {
                if (TextAttribute.Name == item.Name)
                    throw new Exception("There are already existing TextAttribute with specific name");
            }
        }

        #region Interfaces

        public int Count
        {
            get
            {
                return ((ICollection)TextAttributeCollection).Count;
            }
        }

        public object SyncRoot
        {
            get
            {
                return ((ICollection)TextAttributeCollection).SyncRoot;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return ((ICollection)TextAttributeCollection).IsSynchronized;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((IList)TextAttributeCollection).IsReadOnly;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return ((IList)TextAttributeCollection).IsFixedSize;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return ((IList)TextAttributeCollection)[index];
            }

            set
            {
                ((IList)TextAttributeCollection)[index] = value;
            }
        }

        public TextAttribute this[int index]
        {
            get
            {
                return TextAttributeCollection[index];
            }

            set
            {
                TextAttributeCollection[index] = value;
            }
        }

        public TextAttribute this[string TextAttributeName]
        {
            get
            {
                return TextAttributeCollection.Single(x => x.Name == TextAttributeName);
            }

            set
            {
                TextAttributeCollection[TextAttributeCollection.IndexOf(TextAttributeCollection.Single(x => x.Name == TextAttributeName))] = value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)TextAttributeCollection).CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return ((ICollection)TextAttributeCollection).GetEnumerator();
        }

        public int Add(object value)
        {
            CheckForNoDublicates(value as TextAttribute);
            return ((IList)TextAttributeCollection).Add(value);
        }

        public int Add(TextAttribute value)
        {
            CheckForNoDublicates(value);
            return ((IList)TextAttributeCollection).Add(value);
        }

        public bool Contains(object value)
        {
            return ((IList)TextAttributeCollection).Contains(value);
        }

        public void Clear()
        {
            ((IList)TextAttributeCollection).Clear();
        }

        public int IndexOf(object value)
        {
            return ((IList)TextAttributeCollection).IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            ((IList)TextAttributeCollection).Insert(index, value);
        }

        public void Remove(object value)
        {
            ((IList)TextAttributeCollection).Remove(value);
        }

        public void RemoveAt(int index)
        {
            ((IList)TextAttributeCollection).RemoveAt(index);
        }

        #endregion

    }
}
