using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxtReader.Reader;
using TextAttributes;
using System.IO;
using ScriptCollection;

namespace TxtReader
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
            var s = GetScript.DefaultSearch;
            var file = File.ReadAllLines(@"D:\!Repository\TextReader\TextReader\monsters.txt").ToList();

            var sScript = GetScript.DefaultSearch;
            var cScript = GetScript.DefaultChange;

            TextAttributeHeader.DefaultType = TextAttribute.EType.Mandatory;
            TextAttributeHeader.DefaultDisplayed = true;
            TextAttributeHeader.DefaultChangeScript = cScript;
            TextAttributeHeader.DefaultSearchScript = sScript;

            List<TextAttributeHeader> headers = new List<TextAttributeHeader>();
            headers.Add("Навыки")
                .Add("Характеристики")
                .Add("Шаг");

            headers.Search(file, null);


            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
	}
}
