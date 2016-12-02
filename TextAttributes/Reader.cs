using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextReader.Core.Common;
using TextReader.Core.Script;
using TextReader.Core.Script.Settings;

namespace TextReader.Core
{
    public class Reader : Dictionary<string, Record>
    {

        #region Init

        public Script<Transform> TransformScript { get; set; }

        public List<AttributeHeader> AttributeHeaders { get; set; }

        private Transform _settings;
        /// <summary>
        /// No need to specify Parent for setting. It is assigns in setter 
        /// </summary>
        public Transform Settings
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

        #endregion

        #region Script exucutin

        public void Transform(Transform settings)
        {
            if (Settings is null) throw new TextException("Settings null reference");

            Clear();
            Settings = settings;
            TransformScript(settings);

        }
        public void Transform()
        {
            if (TransformScript is null) throw new TextException("TransformScript null reference");

            Transform(Settings);
        }

        public void Search(Search settings)
        {
            AttributeHeaders.Search(settings);
        }

        public void Search()
        {
            AttributeHeaders.Search();
        }


        public void SearchAndTransform()
        {
            Search();
            Transform();
        }
        public void SearchAndTransform(Search searchSettings)
        {
            Search(searchSettings);
            Transform();
        }
        public void SearchAndTransform(Transform settings)
        {
            Search();
            Transform(settings);
        }
        public void SearchAndTransform(Search searchSettings,Transform settings)
        {
            Search(searchSettings);
            Transform(settings);
        }

        #endregion

        public void Add(Record record)
        {
            base.Add(record.Key.Name, record);
        }
    }
}
