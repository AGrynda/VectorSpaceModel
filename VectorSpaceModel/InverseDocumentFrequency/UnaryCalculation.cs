namespace VectorSpaceModel.InverseDocumentFrequency
{
    public class UnaryCalculation : IIdfCalculation
    {
        public void CalculateIdf(Corpus corpus)
        {
            foreach (var term in corpus.Terms)
            {
                corpus.InverseDocumentFrequency.Add(term, 1);
            }
        }
    }
}