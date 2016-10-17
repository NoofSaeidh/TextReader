using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAttributes
{
    /// <summary>
    /// Setting it is massive of parametrs using by SearchScript
    /// </summary>
    public class Settings
    {
		public Separators Separators { get; set; }

        public Settings()
        {
			Separators = new Separators();
        }

		public Settings(Separators Separators = null) : this()
		{
			this.Separators = Separators;
		}
    }
}
