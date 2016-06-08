using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;

namespace VectorSpaceModel.TF_IDF.Schemes
{
    public class LogInverseNormalization : Scheme
    {
        public override TfIdfCalculators Calculators()
        {
            var tfFactory = new TFFactory();
            var tfCalculation = tfFactory.GetCalculator(TfWeight.LogNormalization);

            var idfFactory = new IDFFactory();
            var idfCalculation = idfFactory.GetCalc(IdfWeight.InverseDocumentFrequency);

            return new TfIdfCalculators(idfCalculation, tfCalculation);
        }
    }
}