using System;
using System.Linq;

namespace VectorSpaceModel.InverseDocumentFrequency
{
    public class IdfMaxCalculation : IIdfCalculation
    {
        public void CalculateIdf(Corpus corpus)
        {
            foreach (var term in corpus.Terms)
            {
                var occursInDocuments = corpus.Documents.Count(document => document.Terms.Contains(term));
                corpus.InverseDocumentFrequency.Add(term, occursInDocuments);
            }

            var maxOccurs = corpus.InverseDocumentFrequency.Max(s => s.Value);
            foreach (var pair in corpus.InverseDocumentFrequency)
                corpus.InverseDocumentFrequency[pair.Key] = Math.Log(1 + maxOccurs/pair.Value);
        }
    }
}