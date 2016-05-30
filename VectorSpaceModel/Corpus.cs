using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorSpaceModel
{
    public interface ICorpus
    {
        void AddDocument(Document doc);
    }

    public class Corpus : ICorpus
    {
        public IList<Document> Documents { get; set; }
        public HashSet<string> Terms { get; set; }
        public IDictionary<string, double> InverseDocumentFrequency { get; set; }

        IList<string> selectedTerms;

        public Corpus(string path)
        {
            
        }

        public Corpus()
        {
            
        }

        public void AddDocument(Document doc)
        {
            Documents.Add(doc);
            Terms.UnionWith(doc.Terms);
        }
    }
}
