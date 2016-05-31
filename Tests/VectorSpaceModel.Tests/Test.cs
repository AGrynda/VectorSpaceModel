using FluentAssertions;
using NUnit.Framework;
using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;
using VectorSpaceModel.TF_IDF;
using VectorSpaceModel.TF_IDF.Schemes;

namespace VectorSpaceModel.Tests
{
    public class Test
    {
        [Test]
        public void ShouldReturnCalculators()
        {
            var tfIdfContext = new TfIdfContext(new LogNormalizationIDF());
            var tfIdfCalculators = tfIdfContext.Calculators();

            tfIdfCalculators.ItfCalculation.Should().BeAssignableTo<LogNormalizationCalc>();
            tfIdfCalculators.IidfCalculation.Should().BeAssignableTo<IDFCalculation>();
        }
    }
}
