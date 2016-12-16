using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextReader.Core.Common;
using TextReader.Core.Script;
using TextReader.Core;
using TextReader.Core.Script.Settings;

namespace ScriptCollection
{
    public static class TransformCollection
    {
        [Script(Default = true, UserName = "Default transform script", UserDescription = "Script transform something")]
        public static void DefaultTransform(Transform settings)
        {

        }
    }
}
