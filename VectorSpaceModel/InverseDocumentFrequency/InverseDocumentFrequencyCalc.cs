﻿using System;
using System.Linq;

namespace VectorSpaceModel.InverseDocumentFrequency
{
    public class InverseDocumentFrequencyCalc : IInverseDocumentFrequencyCalc
    {
        public void Calculate(Corpus corpus)
        {
            var totalDocuments = corpus.Documents.Count;
            foreach (var term in corpus.Terms)
            {
                var occursInDocuments = corpus.Documents.Count(document => document.Terms.Contains(term));
                corpus.InverseDocumentFrequency.Add(term, Math.Log(totalDocuments / (double) occursInDocuments));
            }
        }
    }
}