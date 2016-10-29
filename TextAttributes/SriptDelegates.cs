using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAttributes
{
    /// <summary>
    /// This delegate descibes Script for search entries of Attribute in text
    /// </summary>
    /// <param name="Owner"></param>
    /// <param name="Input"></param>
    /// <param name="Settings"></param>
    /// <returns>List of: int - Line Number; string - Line Text<</returns>
    public delegate List<LineNumText> SearchScript(TextAttributeHeader Owner, Settings Settings);

    public delegate List<TextAttribute> ChangeScript(TextAttributeHeader Owner, Settings Settings);
}
