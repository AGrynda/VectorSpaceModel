using System;

namespace VectorSpaceModel.InverseDocumentFrequency
{
    public class InverseDocumentFrequencyFactory
    {
        public IInverseDocumentFrequencyCalc GetCalc(IdfWeight weight)
        {
            switch (weight)
            {
                case IdfWeight.Unary:
                    return new UnaryCalc();
                case IdfWeight.InverseDocumentFrequency:
                    return new InverseDocumentFrequencyCalc();
                case IdfWeight.InverseDocumentFrequencySmooth:
                    return new InverseDocumentFrequencySmoothCalc();
                case IdfWeight.InverseDocumentFrequencyMax:
                    return new InverseDocumentFrequencyMaxCalc();
                case IdfWeight.ProbabilisticInverseDocumentFrequency:
                    return new ProbabilisticInverseDocumentFrequencyCalc();
                default:
                    throw new ArgumentOutOfRangeException(nameof(weight), weight, null);
            }
        }
    }

    public interface IInverseDocumentFrequencyCalc
    {
        void Calculate(Corpus corpus);
    }
}