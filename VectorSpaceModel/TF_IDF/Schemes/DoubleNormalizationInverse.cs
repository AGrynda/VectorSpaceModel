﻿using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;

namespace VectorSpaceModel.TF_IDF.Schemes
{
    public class DoubleNormalizationInverse : Scheme
    {
        public override TfIdfCalculators Calculators()
        {
            var tfFactory = new TFFactory();
            var tfCalculation = tfFactory.GetCalculator(TfWeight.DoubleNormalizationHalf);

            var idfFactory = new IDFFactory();
            var idfCalculation = idfFactory.GetCalculator(IdfWeight.InverseDocumentFrequency);

            return new TfIdfCalculators(idfCalculation, tfCalculation);
        }
    }
}