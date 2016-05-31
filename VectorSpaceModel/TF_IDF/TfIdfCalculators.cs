using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;

namespace VectorSpaceModel.TF_IDF
{
    public class TfIdfCalculators
    {
        public IIDFCalculation IDFCalculation { get; }
        public ITFCalculation TFCalculation { get; }

        public TfIdfCalculators(IIDFCalculation idfCalculation, ITFCalculation tfCalculation)
        {
            IDFCalculation = idfCalculation;
            TFCalculation = tfCalculation;
        }
    }
}