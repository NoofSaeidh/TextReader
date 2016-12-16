using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using TextReader;
using TextReader.Core.Common;
using TextReader.Core.Script;
using System.Reflection;
using TextReader.Core.Script.Settings;
using TextReader.Core;

namespace TextReader
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var assambly = Assembly.Load("ScriptCollection");
            var script = new ScriptReflection(assambly);
            var defS = script.TryGetDefaultScript<Search>();
            var defT = script.TryGetDefaultScript<Transform>();
            var set = new Search(new Pattern("Характеристика@@@"));

            var aHeaders = new List<AttributeHeader>()
                .Add("Name", Core.Attribute.EType.Mandatory, false,set)
                .Add("Primary", Core.Attribute.EType.Mandatory, true, set, defS);

            var reader = new Reader()
            {
                AttributeHeaders = aHeaders,
                Settings = new ReaderSettings()
                {
                    Text = new Text(Environment.CurrentDirectory.Replace("bin\\Debug", "monsters.txt"))
                },
                TransformScript = defT
            };
            reader.Search();
            //var reader = new Reader()
            //{
            //    TransformScript = script.TryGetDefaultScript<Transform>(),
            //    Text = new Text("C:\\file.txt"),
            //    AttributeHeaders = new List<AttributeHeader>().
            //};


            //var scripts = script.GetCollection<SearchScript>();
            //var a = script.GetCollection<SearchScript>();

            //var s = GetScript.DefaultSearch;
            //var file = File.ReadAllLines(@"D:\!Repository\TextReader\TextReader\monsters.txt").ToList();

            //var sScript = GetScript.DefaultSearch;
            //var cScript = GetScript.DefaultChange;

            //TextAttributeHeader.DefaultType = TextAttribute.EType.Mandatory;
            //TextAttributeHeader.DefaultDisplayed = true;
            //TextAttributeHeader.DefaultChangeScript = cScript;
            //TextAttributeHeader.DefaultSearchScript = sScript;

            //List<TextAttributeHeader> headers = new List<TextAttributeHeader>();
            //headers.Add("Навыки")
            //    .Add("Характеристики")
            //    .Add("Шаг");

            //var searchSettings = new Settings(Text: file);
            //headers.Search(searchSettings);

            //var changeSettings = new Settings(Text: file, SearchResults: headers);
            //headers.Change(changeSettings);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
