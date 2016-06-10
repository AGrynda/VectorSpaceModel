using System;
using System.IO;
using System.Linq;
using DataHandler;
using LinguisticProcessor;
using Similarity;
using VectorSpaceModel;
using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;
using VectorSpaceModel.TF_IDF;
using VectorSpaceModel.TF_IDF.Schemes;
using Wnlib;

namespace diplomlyat
{
    static class Program
    {
        static void Main(string[] args)
        {
            var any = args.Any();

            WNCommon.path = @"..\..\..\WordNet\dict\";

            var stemmer = new Stemmer();
            var test = stemmer.stem("nationalize");

            Console.WriteLine(test);

            var ws = new SimilarityCalculator();

            Console.WriteLine(ws.CalcSimilarity("pen", "lion"));

            if (any)
            {
                var corpus = FileHandler.GetCorpusByPath(args.First());
                var idfFactory = new IDFFactory();
                var tfIdfContext = new TfIdfContext(new LogIdfNormalization());
                var tfIdfCalculators = tfIdfContext.Calculators();
                tfIdfCalculators.IDFCalculation.CalculateIdf(corpus);
            }
            Console.WriteLine("Hello, pishy diplom bleat'!!!");

            Console.ReadKey();
        }
    }
}
