using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records
{
    public class Table : Dictionary<string, Record>
    {
        public void Add(Record record)
        {
            base.Add(record.PrimaryTextAttributeName, record);
        }

    }
}
