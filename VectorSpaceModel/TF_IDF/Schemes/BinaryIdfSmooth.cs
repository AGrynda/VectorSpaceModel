﻿using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;

namespace VectorSpaceModel.TF_IDF.Schemes
{
    public class BinaryIdfSmooth : Scheme
    {
        public override TfIdfCalculators Calculators()
        {
            var tfFactory = new TfFactory();
            var tfCalculation = tfFactory.GetCalculator(TfWeight.LogNormalization);

            var idfFactory = new IdfFactory();
            var idfCalculation = idfFactory.GetCalc(IdfWeight.InverseDocumentFrequencySmooth);

            return new TfIdfCalculators(idfCalculation, tfCalculation);
        }
    }
}