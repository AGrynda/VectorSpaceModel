using System.Collections.Generic;

namespace VectorSpaceModel
{
    public class Document
    {
        public IList<string> Terms { get; }
        public IDictionary<string, double> TF { get; } = new Dictionary<string, double>();

        public Document(IList<string> terms)
        {
            Terms = terms;
        }
    }
}
