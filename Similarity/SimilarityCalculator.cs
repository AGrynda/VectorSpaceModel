using System;
using System.Linq;
using Wnlib;

namespace Similarity
{
    public interface ISimilarity
    {
        float CalcSimilarity(string word1, string word2);
        float CalcSimilarity(WordHierarchy word1, WordHierarchy word2, int strategy = 2);
    }

    public class SimilarityCalculator : ISimilarity
    {
        public float CalcSimilarity(string word1, string word2)
        {
            var partsOfSpeech = (PartsOfSpeech[]) Enum.GetValues(typeof (PartsOfSpeech));

            var minSim = float.MaxValue;
            partsOfSpeech.ToList().ForEach(pos =>
            {
                var wordH1 = new WordHierarchy(word1, pos);
                var wordH2 = new WordHierarchy(word2, pos);
                var sim = CalcSimilarity(wordH1, wordH2);
                if (minSim > sim && sim != 0.0F) minSim = sim;
            });
            
            return minSim;
        }

        public float CalcSimilarity(WordHierarchy word1, WordHierarchy word2, int strategy = 2)
        {
            if (word1.PoS != word2.PoS || word1.PoS == PartsOfSpeech.Unknown) return 0.0F;
            if (word1.Word == word2.Word) return 1.0F;

            int pathLength, lcaDepth, depth1, depth2;
            FindLeastCommonAncestor(new[] { word1, word2 }, out pathLength, out lcaDepth, out depth1, out depth2);

            if (pathLength == int.MaxValue) return 0;
            if (pathLength == 0) return 1;
            float sim = 0;
            switch (strategy)
            {
                case 1:
                    sim = 1.0F/pathLength;
                    break;
                case 2:
                    sim = lcaDepth/(float) (depth1 + depth2);
                    break;
            }

            return (float) Math.Round(sim, 2);
        }

        public int FindLeastCommonAncestor(WordHierarchy[] words, out int distance, out int lcaDepth, out int depth1, out int depth2)
        {
            int LCA = -1;
            lcaDepth = -1;
            depth1 = -1;
            depth2 = -1;

            distance = int.MaxValue;
            int i = -1;
            while (++i < 1 && LCA == -1)
            {
                var trackEnum = words[1 - i].Distance.GetEnumerator();
//                if (trackEnum == null) return -1;
                while (trackEnum.MoveNext())
                {
                    var commonAcestor = (int)trackEnum.Key;
                    if (words[i].Distance.ContainsKey(commonAcestor))
                    {
                        var dis_1 = words[i].GetDistance(commonAcestor);
                        var dis_2 = words[1 - i].GetDistance(commonAcestor);

                        var len = dis_1 + dis_2 - 1;
                        if (distance > len)
                        {
                            int lcaDepth1 = words[i].GetDepth(commonAcestor);
                            int lcaDepth2 = words[1 - i].GetDepth(commonAcestor);
                            lcaDepth = lcaDepth1 + lcaDepth2;
                            depth1 = dis_1 + lcaDepth1 - 1;
                            depth2 = dis_2 + lcaDepth2 - 1;
                            distance = len;
                            LCA = commonAcestor;
                        }
                    }
                }
            }

            return LCA;
        }
    }
}
