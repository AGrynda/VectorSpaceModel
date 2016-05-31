using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;

namespace VectorSpaceModel.TF_IDF
{
    public class TfIdfCalculators
    {
        public IIDFCalculation IidfCalculation { get; }
        public ITFCalculation ItfCalculation { get; }

        public TfIdfCalculators(IIDFCalculation iidfCalculation, ITFCalculation itfCalculation)
        {
            IidfCalculation = iidfCalculation;
            ItfCalculation = itfCalculation;
        }
    }
}