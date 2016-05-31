namespace VectorSpaceModel.TF_IDF
{
    public class TfIdfContext
    {
        private readonly Scheme _scheme;

        public TfIdfContext(Scheme scheme)
        {
            _scheme = scheme;
        }

        public TfIdfCalculators Calculators()
        {
            var tfIdfCalculators = _scheme.Calculators();
            return tfIdfCalculators;
        }
    }
}