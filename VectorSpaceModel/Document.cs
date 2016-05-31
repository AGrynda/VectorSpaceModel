using System.Collections.Generic;

namespace VectorSpaceModel
{
    public class Document
    {
        public IList<string> Terms { get; set; }
        public IDictionary<string, double> TermFrequency { get; set; } = new Dictionary<string, double>();

        public Document(IList<string> terms)
        {
            Terms = terms;
        }
    }
}
