using System;
using System.Linq;

namespace VectorSpaceModel.TermFrequency
{
    public class RawFrequencyCalc : ITermFrequencyCalc
    {
        public void CalculateTermFrequency(Document document)
        {
            var grouping = document.Terms.GroupBy(s => s);
            foreach (var variable in grouping)
            {
                document.TermFrequency.Add(variable.Key, variable.Count());
            }
        }
    }
}