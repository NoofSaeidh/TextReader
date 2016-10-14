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
            var file = File.ReadAllLines(@"C:\Users\akuznetsov\Documents\Visual Studio 2015\Projects\TxtReader\txtreader\monsters.txt");
            AH.Name = "Навыки";
            AH.SearchScript = ScriptCollection.GetByName("Standart");
            AH.SearchScript(AH,file.ToList<string>(),@":\/|- ");


			//var AH = new AttributeHeader();
			//AH.S




			//Reader reader = new Reader();
			//reader.ReadFile(@"D:\!Repository\TxtReader\TxtReader\Monsters.txt");
			//reader.Attributes = new AttributeCollection(true,EType.Mandatory,"Характеристики", "Шаг", "Защита");
			//reader.Search();

			//foreach(var record in reader.Data)
			//{
			//	foreach(var r in record)
			//	{
			//		Console.WriteLine(r.Text);
			//	}
			//}

            //var collection = new AttributeCollection();
            //collection = new AttributeCollection(EType.Multiple, new List<string>() { "Five", "Six", "Seven" });
            //var input = new List<string>() { "No one live so far", "Five people eats", "Hi hi hi", "You are Seven eleven" };
            //var output = new List<List<Line>>();

            //collection["Five"].SearchScript = ScriptCollection.GetByName("WithLine");
            //var s = ScriptCollection.GetNames();
            ////collection["Six"].SearchScript = Script.WithName;
            //collection["Seven"].SearchScript = Script.WithoutName;

            //output.Add(collection["Five"].SearchScript(collection["Five"], input));
            //output.Add(collection["Six"].SearchScript(collection["Six"], input));
            //output.Add(collection["Seven"].SearchScript(collection["Seven"], input));			
            //output.Add(collection["Seven"].SearchScript(collection["Seven"], input));
            //collection[1].SearchScript(collection[1], input);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }

	}
}
