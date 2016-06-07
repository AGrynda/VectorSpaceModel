using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lucene.Net;
using System.Threading.Tasks;

namespace LinguisticProcessor
{
    public class StopWordsFilter
    {
        private static readonly List<string> StopWords;
        private const string StopFilePath = "stop-word-list.txt";

        static StopWordsFilter()
        {
            StopWords = File.ReadAllText(StopFilePath).Split().ToList();
        }
        public static IList<string> Run(string textData)
        {
            var punctuation = textData.Where(char.IsPunctuation).Distinct().ToArray();
            var terms = textData.Split().Select(x => x.Trim(punctuation)).Except(StopWords).ToList();


//            var tokenizer = new 
            return terms;
        }
    }
}
