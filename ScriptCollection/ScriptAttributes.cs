using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCollection
{
    public class ScriptAttributes : Attribute { }

    public class SearchCollection : ScriptAttributes { }

    public class ChangeCollection : ScriptAttributes { }

    public class SearchMethod : SearchCollection
    {
        public bool Default { get; set; }
    }

    public class ChangeMethod : ChangeCollection
    {
        public bool Default { get; set; }
    }
}
