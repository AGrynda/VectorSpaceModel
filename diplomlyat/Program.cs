using System;
using System.Linq;
using DataHandler;
using VectorSpaceModel.TF_IDF;
using VectorSpaceModel.TF_IDF.Schemes;

namespace diplomlyat
{
    static class Program
    {
        static void Main(string[] args)
        {
            var any = args.Any();
            if (any)
            {
                var corpus = FileHandler.GetCorpusByPath(args.First());

                var tfIdfContext = new TfIdfContext(new LogNormalizationIDF());
                var tfIdfCalculators = tfIdfContext.Calculators();

                tfIdfCalculators.IDFCalculation.CalculateIdf(corpus);
            }
            Console.WriteLine("Hello, pishy diplom bleat'!!!");

            Console.ReadKey();
        }
    }
}
