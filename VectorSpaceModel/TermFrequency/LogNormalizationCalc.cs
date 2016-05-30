using System;
using System.Linq;

namespace VectorSpaceModel.TermFrequency
{
    public class LogNormalizationCalc : ITermFrequencyCalc
    {
        public void CalculateTermFrequency(Document document)
        {
            var grouping = document.Terms.GroupBy(s => s);
            foreach (var variable in grouping)
            {
                document.TermFrequency.Add(variable.Key, 1 + Math.Log(variable.Count()));
            }
        }
    }
}