using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;

namespace VectorSpaceModel.TF_IDF
{
    public class TfIdfCalculators
    {
        public IIdfCalculation IdfCalculation { get; }
        public ITfCalculation TfCalculation { get; }

        public TfIdfCalculators(IIdfCalculation idfCalculation, ITfCalculation tfCalculation)
        {
            IdfCalculation = idfCalculation;
            TfCalculation = tfCalculation;
        }
    }
}