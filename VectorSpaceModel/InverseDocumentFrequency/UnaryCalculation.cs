namespace VectorSpaceModel.InverseDocumentFrequency
{
    public class UnaryCalculation : IIDFCalculation
    {
        public void CalculateIdf(Corpus corpus)
        {
            foreach (var term in corpus.Terms)
            {
                corpus.IDF.Add(term, 1);
            }
        }
    }
}