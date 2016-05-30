using System;
using System.Linq;

namespace VectorSpaceModel.TermFrequency
{
    public class DoubleNormalizationKCalc : ITermFrequencyCalc
    {
        private readonly double k;

        public DoubleNormalizationKCalc(double d)
        {
            if (k > 1 || k < 0) throw new ArgumentOutOfRangeException();
            k = d;
        }

        public void CalculateTermFrequency(Document document)
        {
            var dictionary = document.Terms.GroupBy(s => s).ToDictionary(t => t.Key, t => t.Count());
            var max = dictionary.Max(s => s.Value);
            foreach (var variable in dictionary)
            {
                document.TermFrequency.Add(variable.Key, k + (1 - k)*variable.Value/max);
            }
        }
    }
}