using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;

namespace VectorSpaceModel.TF_IDF.Schemes
{
    public class LogUnaryNormalization : Scheme
    {
        public override TfIdfCalculators Calculators()
        {
            var tfFactory = new TFFactory();
            var tfCalculation = tfFactory.GetCalculator(TfWeight.LogNormalization);

            var idfFactory = new IDFFactory();
            var idfCalculation = idfFactory.GetCalculator(IdfWeight.Unary);

            return new TfIdfCalculators(idfCalculation, tfCalculation);
        }
    }
}