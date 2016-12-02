using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReader.Core.Common
{
    class TextException : Exception
    {
        public TextException() : base() 
        {
              
        }
        public TextException(string message, Exception innerException) : base (message,innerException)
        {

        }
        public TextException(string message) :base(message)
        {

        }
    }
}
