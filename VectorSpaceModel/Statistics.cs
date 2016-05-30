namespace VectorSpaceModel
{
    public class Statistics
    {
        // N - total number of documents n_t the number of documents containing the term
        public Document CalculateFrequencies(Corpus corpus, IdfWeight idfWeight, TfWeight tfWeight, double K = 0.5)
        {
            var result = new Document();
            foreach (var document in corpus.Documents)
            {
            }
            return null;
        }
    }
}