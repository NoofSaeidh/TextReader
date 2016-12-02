using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReader.Core.Script.Settings
{
    public interface ISettings<T> : ISettings
    {
        T Parent { get; set; }
    }
    //workaround
    //class should inherit from both interfaces
    public interface ISettings{}
}
