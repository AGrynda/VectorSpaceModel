using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorSpaceModel;
using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;

namespace DataHandler
{
    public class DataManager
    {
        public string SamplesPath { get; set; }
        public Corpus Corpus{ get; set; }
        private TFFactory tfFactory { get; set; }
        private IDFFactory idffFactory { get; set; }

        public DataManager()
        {
            tfFactory = new TFFactory();
            idffFactory = new IDFFactory();
            SamplesPath = "E:\\gryndos\\Diploma\\diplomlyat\\Samples";
        }

        public void Run(TfWeight tfWeight, IdfWeight idfWeight)
        {
            if (Corpus == null)
            {
                Corpus = FileHandler.GetCorpusByPath(SamplesPath);
                if (tfWeight != TfWeight.RawFrequency)
                {
                    Corpus.ReCalcTF(tfFactory.GetCalculator(tfWeight));
                }
            }

            idffFactory.GetCalculator(idfWeight).CalculateIdf(Corpus);
        }
    }
}
