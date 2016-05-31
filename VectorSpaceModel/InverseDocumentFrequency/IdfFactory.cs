using System;

namespace VectorSpaceModel.InverseDocumentFrequency
{
    public class IDFFactory
    {
        public IIDFCalculation GetCalc(IdfWeight weight)
        {
            switch (weight)
            {
                case IdfWeight.Unary:
                    return new UnaryCalculation();
                case IdfWeight.InverseDocumentFrequency:
                    return new IDFCalculation();
                case IdfWeight.InverseDocumentFrequencySmooth:
                    return new IDFSmoothCalculation();
                case IdfWeight.InverseDocumentFrequencyMax:
                    return new IDFMaxCalculation();
                case IdfWeight.ProbabilisticInverseDocumentFrequency:
                    return new ProbabilisticIDFCalculation();
                default:
                    throw new ArgumentOutOfRangeException(nameof(weight), weight, null);
            }
        }
    }

    public interface IIDFCalculation
    {
        void CalculateIdf(Corpus corpus);
    }
}