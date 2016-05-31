using System.Linq;

namespace VectorSpaceModel.TermFrequency
{
    public class RawFrequencyCalc : ITfCalculation
    {
        public void CalculateTf(Document document)
        {
            var count = document.Terms.Count;
            var grouping = document.Terms.GroupBy(s => s);
            foreach (var variable in grouping)
            {
                document.TermFrequency.Add(variable.Key, variable.Count()/(double) count);
            }
        }
    }
}