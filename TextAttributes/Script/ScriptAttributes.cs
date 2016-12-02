using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReader.Core.Script
{
	/// <summary>
	/// Use attribute to mark you methods to use in ScriptReflection.
	/// Methods must be public static.
	/// Type must be specified.
	/// </summary>
	public class ScriptAttribute : System.Attribute
	{
//		/// <summary>
//		/// Type of delegate used for script.
//		/// </summary>
//		public Type Type { get; set; }
		/// <summary>
		/// Default script for current type of script. If more than one default script, first will be used.
		/// </summary>
		public bool Default { get; set; }
		/// <summary>
		/// Name of script to use in GUI.
		/// </summary>
		public string UserName { get; set; }
		/// <summary>
		/// Description of script to use in GUI.
		/// </summary>
		public string UserDescription { get; set; }
	}

}
