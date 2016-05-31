using System;
using System.Linq;

namespace VectorSpaceModel.TermFrequency
{
    public class LogNormalizationCalc : ITFCalculation
    {
        public void CalculateTF(Document document)
        {
            var count = document.Terms.Count;
            var grouping = document.Terms.GroupBy(s => s);
            foreach (var variable in grouping)
            {
                document.TF.Add(variable.Key, 1 + Math.Log(variable.Count()/(double) count));
            }
        }

        public void CalculateTF(Corpus corpus)
        {
            throw new NotImplementedException();
        }
    }
}