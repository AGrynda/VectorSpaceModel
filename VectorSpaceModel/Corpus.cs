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
        IList<Document> documents;
        IList<string> terms;

        IList<string> selectedTerms;
    }
}
