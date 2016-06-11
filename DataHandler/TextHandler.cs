using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataHandler
{
    public static class TextHandler
    {
        private static readonly List<string> StopWords;
        private const string StopFilePath = "stop-word-list.txt";

        static TextHandler()
        {
            StopWords = File.ReadAllText(StopFilePath).Split().ToList();
        }

        public static IList<string> GetTerms(string textData)
        {
            var punctuation = textData.Where(char.IsPunctuation).Distinct().ToArray();
            var terms = textData.Split().Select(x => x.Trim(punctuation)).Except(StopWords).Where(term => term.All(char.IsLetter)).ToList();

            return terms;
        }
    }
}