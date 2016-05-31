using System.Linq;

namespace VectorSpaceModel.TermFrequency
{
    public class BinaryCalculation : ITfCalculation
    {
        public void CalculateTf(Document document)
        {
            var grouping = document.Terms.GroupBy(s => s);
            foreach (var variable in grouping)
            {
                document.TermFrequency.Add(variable.Key, 1);
            }
        }
    }
}