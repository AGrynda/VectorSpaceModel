using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;

namespace VectorSpaceModel.TF_IDF.Schemes
{
    public class DoubleNormalizationInverse : Scheme
    {
        public override TfIdfCalculators Calculators()
        {
            var tfFactory = new TfFactory();
            var tfCalculation = tfFactory.GetCalculator(TfWeight.DoubleNormalizationHalf);

            var idfFactory = new IdfFactory();
            var idfCalculation = idfFactory.GetCalc(IdfWeight.InverseDocumentFrequency);

            return new TfIdfCalculators(idfCalculation, tfCalculation);
        }
    }
}