using System;
using System.Linq;

namespace VectorSpaceModel.TermFrequency
{
    public class DoubleNormalizationKCalc : ITFCalculation
    {
        private readonly double _k;

        public DoubleNormalizationKCalc(double coefficient)
        {
            _k = coefficient;
            if (_k > 1 || _k < 0) throw new ArgumentOutOfRangeException();
        }

        public void CalculateTF(Document document)
        {
            var dictionary = document.Terms.GroupBy(s => s).ToDictionary(t => t.Key, t => t.Count());
            var max = dictionary.Max(s => s.Value);
            foreach (var variable in dictionary)
            {
                document.TF.Add(variable.Key, _k + (1 - _k)*variable.Value/max);
            }
        }

        public void CalculateTF(Corpus corpus)
        {
            throw new NotImplementedException();
        }
    }
}