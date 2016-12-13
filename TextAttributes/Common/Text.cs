using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextReader.Core.Common
{
    public class Text : List<string>
    {
        public string FilePath { get; set; }


        #region Init

        public void Load()
        {
            base.Clear();
            base.AddRange(File.ReadAllLines(FilePath).ToList());
        }

        public void Load(string filePath)
        {
            FilePath = filePath;
            Load();
        }

        public Text()
        {

        }

        public Text(string filePath)
        {
            Load(filePath);
        }

        #endregion

        public void Save(string filePath)
        {
            File.AppendAllLines(filePath, this);
        }

        public void RemoveLines(params string[] patterns)
        {
            foreach (var pattern in patterns)
            {
                int i = 0;
                foreach (var line in this)
                {
                    if (Regex.IsMatch(line, pattern))
                    {
                        base.RemoveAt(i);
                    }
                    else i++;
                }                
            }
        }
    }
}
