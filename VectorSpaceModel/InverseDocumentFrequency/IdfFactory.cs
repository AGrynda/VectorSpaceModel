using System;

namespace VectorSpaceModel.InverseDocumentFrequency
{
    public class IdfFactory
    {
        public IIdfCalculation GetCalc(IdfWeight weight)
        {
            switch (weight)
            {
                case IdfWeight.Unary:
                    return new UnaryCalculation();
                case IdfWeight.InverseDocumentFrequency:
                    return new IdfCalculation();
                case IdfWeight.InverseDocumentFrequencySmooth:
                    return new IdfSmoothCalculation();
                case IdfWeight.InverseDocumentFrequencyMax:
                    return new IdfMaxCalculation();
                case IdfWeight.ProbabilisticInverseDocumentFrequency:
                    return new ProbabilisticIdfCalculation();
                default:
                    throw new ArgumentOutOfRangeException(nameof(weight), weight, null);
            }
        }
    }

    public interface IIdfCalculation
    {
        void CalculateIdf(Corpus corpus);
    }
}