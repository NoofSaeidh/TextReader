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
		public List<Separator> Separators { get; set; }

        public Settings()
        {
            Separators = new List<Separator>();
        }

		public Settings(List<Separator> Separators = null) : this()
		{
			this.Separators = Separators;
		}
    }
}
