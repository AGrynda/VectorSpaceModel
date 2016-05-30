using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorSpaceModel
{
    public class Document
    {
        public IList<string> Terms { get; set; }
        public IDictionary<string, double> TermFrequency { get; set; }
        public IDictionary<string, double> InverseDocumentFrequency { get; set; }
    }
}
