using System;

namespace VectorSpaceModel.TermFrequency
{
    public class TfFactory
    {
        public ITfCalculation GetCalculator(TfWeight tfWeight, double K=0.5)
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
                    return new DoubleNormalizationKCalc(K);
                default:
                    throw new ArgumentOutOfRangeException(nameof(tfWeight), tfWeight, null);
            }
        }
    }

    public interface ITfCalculation
    {
        void CalculateTf(Document document);
    }
}