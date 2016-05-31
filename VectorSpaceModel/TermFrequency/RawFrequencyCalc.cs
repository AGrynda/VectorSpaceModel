using System.Linq;

namespace VectorSpaceModel.TermFrequency
{
    public class RawFrequencyCalc : ITFCalculation
    {
        public void CalculateTF(Document document)
        {
            var count = document.Terms.Count;
            var grouping = document.Terms.GroupBy(s => s);
            foreach (var variable in grouping)
            {
                document.TF.Add(variable.Key, variable.Count()/(double) count);
            }
        }

        public void CalculateTF(Corpus corpus)
        {
            throw new System.NotImplementedException();
        }
    }
}