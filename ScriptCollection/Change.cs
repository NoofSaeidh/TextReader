using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAttributes;

namespace ScriptCollection
{

    [ChangeCollection]
    public class Change
    {
        [ChangeMethod(Default = true)]
        public static List<TextAttribute> DefaultChange(TextAttributeHeader Owner, Settings Settings)
        {
            //if (SearchResults != null)
            //{
            //    if (SearchResults is IList)
            //    {
            //        var listResult = (IList)SearchResults;
            //        var typeResult = listResult[0].GetType();

            //    }
            //}
            return null;
        }
    }
}
