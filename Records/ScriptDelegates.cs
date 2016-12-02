using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAttributes;

namespace Records
{
    class ScriptDelegates
    {
        /// <summary>
        /// This delegate descibes Script for transform resalts of change script to record
        /// </summary>
        /// <param name="Settings"></param>
        /// <returns>List of: int - Line Number; string - Line Text<</returns>
        public delegate List<Record> TransformScript(Settings Settings);
    }
}
