using System.Linq;

namespace VectorSpaceModel.TermFrequency
{
    public class BinaryCalculation : ITFCalculation
    {
        public void CalculateTF(Document document)
        {
            var grouping = document.Terms.GroupBy(s => s);
            foreach (var variable in grouping)
            {
                document.TF.Add(variable.Key, 1);
            }
        }

        public void CalculateTF(Corpus corpus)
        {
            throw new System.NotImplementedException();
        }
    }
}