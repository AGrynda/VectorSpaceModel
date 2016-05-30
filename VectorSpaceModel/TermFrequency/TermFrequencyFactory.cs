using System;

namespace VectorSpaceModel.TermFrequency
{
    public class TermFrequencyFactory
    {
        public ITermFrequencyCalc GetCalculator(TfWeight tfWeight, double K=0.5)
        {
            switch (tfWeight)
            {
                case TfWeight.Binary:
                    return new BinaryCalc();
                    break;
                case TfWeight.RawFrequency:
                    return new RawFrequencyCalc();
                    break;
                case TfWeight.LogNormalization:
                    return new LogNormalizationCalc();
                    break;
                case TfWeight.DoubleNormalizationHalf:
                    return new DoubleNormalizationKCalc(0.5);
                    break;
                case TfWeight.DoubleNormalizationK:
                    return new DoubleNormalizationKCalc(K);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tfWeight), tfWeight, null);
            }
        }
    }

    public interface ITermFrequencyCalc
    {
        void CalculateTermFrequency(Corpus corpus);
    }
}