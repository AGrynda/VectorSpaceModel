﻿using System;

namespace VectorSpaceModel.TermFrequency
{
    public class TFFactory
    {
        public ITFCalculation GetCalculator(TfWeight tfWeight, double k = 0.5)
        {
            switch (tfWeight)
            {
                case TfWeight.Binary:
                    return new BinaryCalculation();
                case TfWeight.RawFrequency:
                    return new RawFrequencyCalc();
                case TfWeight.LogNormalization:
                    return new LogNormalizationCalc();
                case TfWeight.DoubleNormalizationHalf:
                    return new DoubleNormalizationKCalc(0.5);
                case TfWeight.DoubleNormalizationK:
                    return new DoubleNormalizationKCalc(k);
                default:
                    throw new ArgumentOutOfRangeException(nameof(tfWeight), tfWeight, null);
            }
        }
    }

    public interface ITFCalculation
    {
        void CalculateTF(Document document);
        void CalculateTF(Corpus corpus);
    }
}