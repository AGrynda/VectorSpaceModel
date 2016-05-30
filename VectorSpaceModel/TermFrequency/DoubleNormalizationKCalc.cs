using System;

namespace VectorSpaceModel.TermFrequency
{
    public class DoubleNormalizationKCalc : ITermFrequencyCalc
    {
        private double k;

        public DoubleNormalizationKCalc(double d)
        {
            k = d;
        }

        public void CalculateTermFrequency(Corpus corpus)
        {
            throw new NotImplementedException();
        }
    }
}