using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorSpaceModel
{
    public interface ICorpus
    {

    }

    public class Corpus : ICorpus
    {
        public IList<Document> Documents { get; set; }
        public IList<string> Terms { get; set; }

        IList<string> selectedTerms;

        public Corpus(string path)
        {
            
        }

        public Corpus()
        {
            
        }
    }
}
