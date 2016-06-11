using System.Collections.Generic;
using VectorSpaceModel.TermFrequency;

namespace VectorSpaceModel
{
    public interface ICorpus
    {
        void AddDocument(Document doc);
    }

    public class Corpus : ICorpus
    {
        private IList<string> selectedTerms;

        public Corpus(string path)
        {
        }

        public Corpus()
        {
        }

        public IList<Document> Documents { get; set; } = new List<Document>();
        public HashSet<string> Terms { get; set; } = new HashSet<string>();
        public Dictionary<string, double> IDF { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, double> TF { get; set; } = new Dictionary<string, double>();

        public void AddDocument(Document doc)
        {
            Documents.Add(doc);
            Terms.UnionWith(doc.Terms);
        }


        public void ReCalcTF(ITFCalculation tfCalculation)
        {
            foreach (var document in Documents)
            {
                tfCalculation.CalculateTF(document);
            }
        }
    }
}