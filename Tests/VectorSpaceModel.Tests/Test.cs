using System.Collections.Generic;
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
            var tfIdfContext = new TfIdfContext(new LogNormalizationIdf());
            var tfIdfCalculators = tfIdfContext.Calculators();

            tfIdfCalculators.TfCalculation.CalculateTf(new Document(new List<string>()));
            tfIdfCalculators.IdfCalculation.CalculateIdf(new Corpus());

            tfIdfCalculators.TfCalculation.Should().BeAssignableTo<LogNormalizationCalc>();
            tfIdfCalculators.IdfCalculation.Should().BeAssignableTo<IdfCalculation>();
        }
    }
}
