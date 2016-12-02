using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextReader.Core.Common;
using TextReader.Core.Script.Settings;

namespace TextReader.Core.Script
{

    ///// <summary>
    ///// This delegate descibes Script for search entries of Attribute in text
    ///// </summary>
    ///// <param name="Owner"></param>
    ///// <param name="Settings"></param>
    ///// <returns>List of: int - Line Number; string - Line Text<</returns>
    //public delegate List<LineNum> SearchScript(AttributeHeader Owner, SearchSettings Settings);

    //       /// <summary>
    //       /// This delegate descibes Script for transform results of change script to record
    //       /// </summary>
    //       /// <param name="Settings"></param>
    //       /// <returns>List of: int - Line Number; string - Line Text<</returns>
    //   public delegate List<Record> TransformScript(TransformSettings Settings);
    public delegate void Script<T>(T settings) where T : ISettings;
}
