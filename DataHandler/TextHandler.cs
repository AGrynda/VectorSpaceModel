using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    public class TextHandler
    {
        static List<string> stopWords;
        static  string stopFilePath = "stop-word-list.txt";

        static TextHandler()
        {
            stopWords = File.ReadAllText(stopFilePath).Split().ToList();
        }

        public static IList<string> GetTerms(string textData)
        {
            var punctuation = textData.Where(Char.IsPunctuation).Distinct().ToArray();
            var terms = textData.Split().Select(x => x.Trim(punctuation)).Except(stopWords).ToList();

            return terms;
        }
    }
}
