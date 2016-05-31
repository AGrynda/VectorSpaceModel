using System;
using System.Linq;

namespace VectorSpaceModel.InverseDocumentFrequency
{
    public class IDFMaxCalculation : IIDFCalculation
    {
        public void CalculateIdf(Corpus corpus)
        {
            foreach (var term in corpus.Terms)
            {
                var occursInDocuments = corpus.Documents.Count(document => document.Terms.Contains(term));
                corpus.IDF.Add(term, occursInDocuments);
            }

            var maxOccurs = corpus.IDF.Max(s => s.Value);
            foreach (var pair in corpus.IDF)
                corpus.IDF[pair.Key] = Math.Log(1 + maxOccurs/pair.Value);
        }
    }
}