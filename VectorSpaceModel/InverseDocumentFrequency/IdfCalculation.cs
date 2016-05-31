using System;
using System.Linq;

namespace VectorSpaceModel.InverseDocumentFrequency
{
    public class IDFCalculation : IIDFCalculation
    {
        public void CalculateIdf(Corpus corpus)
        {
            var totalDocuments = corpus.Documents.Count;
            foreach (var term in corpus.Terms)
            {
                var occursInDocuments = corpus.Documents.Count(document => document.Terms.Contains(term));
                corpus.IDF.Add(term, Math.Log(totalDocuments / (double) occursInDocuments));
            }
        }
    }
}