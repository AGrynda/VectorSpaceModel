namespace VectorSpaceModel
{
    public enum TfWeight
    {
        Binary,
        RawFrequency,
        LogNormalization,
        DoubleNormalizationHalf,
        DoubleNormalizationK
    }

    public enum IdfWeight
    {
        Unary,
        InverseDocumentFrequency,
        InverseDocumentFrequencySmooth,
        InverseDocumentFrequencyMax,
        ProbabilisticInverseDocumentFrequency,
    }

    public enum WeightingScheme
    {
        DocumentTermWeight,
        QueryTermWeight
    }
}
