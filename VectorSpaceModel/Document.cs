using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorSpaceModel
{
    class Document
    {
        IList<string> terms;
        IDictionary<string, double> termFrequency;

    }
}
