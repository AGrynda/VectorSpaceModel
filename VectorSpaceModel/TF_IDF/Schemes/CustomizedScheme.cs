using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;

namespace VectorSpaceModel.TF_IDF.Schemes
{
    public class CustomizedScheme : Scheme
    {
        private TfWeight tf;
        private IdfWeight idf;

        public CustomizedScheme(TfWeight tf, IdfWeight idf)
        {
            this.tf = tf;
            this.idf = idf;
        }

        public override TfIdfCalculators Calculators()
        {
            var tfFactory = new TFFactory();
            var tfCalculation = tfFactory.GetCalculator(tf);

            var idfFactory = new IDFFactory();
            var idfCalculation = idfFactory.GetCalculator(idf);

            return new TfIdfCalculators(idfCalculation, tfCalculation);
        }
    }
}
