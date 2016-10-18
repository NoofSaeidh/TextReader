using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxtReader.Reader;
using TextAttributes;
using System.IO;

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
            var AH = new TextAttributeHeader();
            //var file = File.ReadAllLines(@"C:\Users\akuznetsov\Documents\Visual Studio 2015\Projects\TxtReader\txtreader\monsters.txt");
			var file = File.ReadAllLines(@"D:\!Repository\TextReader\TextReader\monsters.txt");
            AH.Name = "Навыки";
            AH.SearchScript = ScriptCollection.GetByName("Standart");
            AH.Search(file.ToList<string>(),new Settings(new Separators(@":\/|- ")));
			AH.SearchScript(AH, file.ToList<string>(), null);

            var c = AH.Search(file.ToList<string>(), null);


            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
	}
}
