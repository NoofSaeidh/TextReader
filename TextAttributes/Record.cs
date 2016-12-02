using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextReader.Core.Common;

namespace TextReader.Core
{
    public class Record : List<Attribute>
    {
        private int _key = 0;
        /// <summary>
        /// Key - it's main Attribute
        /// Record must contain it or exception will be thrown
        /// First Attribute will be Key
        /// </summary>
        public Attribute Key
        {
            get
            {
                return this[_key];
            }
            set
            {
                if (this.IndexOf(value) == -1)
                    throw new TextException($"Record does not contain such Attribute, with name {value.Name}");
                _key = this.IndexOf(value);
            }
        }

        public Record():base()
        {

        }


    }
}
