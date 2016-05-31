using System;
using System.Linq;

namespace VectorSpaceModel.TermFrequency
{
    public class LogNormalizationCalc : ITfCalculation
    {
        public void CalculateTf(Document document)
        {
            var count = document.Terms.Count;
            var grouping = document.Terms.GroupBy(s => s);
            foreach (var variable in grouping)
            {
                document.TermFrequency.Add(variable.Key, 1 + Math.Log(variable.Count()/(double) count));
            }
        }
    }
}