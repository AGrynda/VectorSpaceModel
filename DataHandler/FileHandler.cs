using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorSpaceModel;

namespace DataHandler
{
    public class FileHandler
    {
        public static Corpus GetCorpusByPath(string path)
        {
            var corpus = new Corpus();

            var files = Directory.GetFiles(path, "*.txt");

            foreach (var terms in files.Select(file => TextHandler.GetTerms(File.ReadAllText(file))))
            {
                corpus.AddDocument(new Document(terms));
            }

            return corpus;
        }
    }
}
