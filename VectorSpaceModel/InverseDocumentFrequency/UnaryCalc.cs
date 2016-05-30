namespace VectorSpaceModel.InverseDocumentFrequency
{
    public class UnaryCalc : IInverseDocumentFrequencyCalc
    {
        public void Calculate(Corpus corpus)
        {
            foreach (var term in corpus.Terms)
            {
                corpus.InverseDocumentFrequency.Add(term, 1);
            }
        }
    }
}