using System;
using System.Collections;
using System.Linq;
using Wnlib;

namespace Similarity
{
    public class WordHierarchy
    {
        
        public Hashtable Distance { get; set; }
        public Hashtable DepthMatrix { get; set; }
        public Hashtable SynWord { get; set; }
        public string Word { get; set; }
        public PartsOfSpeech PoS{ get; set; }


        private int[] _rootNodes;
        public WordHierarchy(string word, PartsOfSpeech partOfSpeech)
        {
            PoS = partOfSpeech;
            Word = word;
            Distance = new Hashtable();
            DepthMatrix = new Hashtable();
            SynWord = new Hashtable();
            Init();
        }

        public int GetDistance(int key)
        {
            return Distance.ContainsKey(key) ? (int) Distance[key] : -1;
        }

        public int GetDepth(int key)
        {

            int rootDepth = -2;
            foreach (var rootNode in _rootNodes)
            {
                if (key == rootNode) return 1;
                if (DepthMatrix.ContainsKey(GetKey(key, rootNode)))
                    rootDepth = (int)DepthMatrix[GetKey(key, rootNode)];
            }
            return rootDepth + 1;
        }

        private void Init()
        {
            var opt = GetSearchType(PoS);
            if (opt == null) return;

            var searchResult = new Search(Word, true, opt.pos, opt.sch, 0);
            if (searchResult.senses != null && searchResult.senses.Count == 0 && searchResult.morphs.Count > 0)
            {
                var getEnum = searchResult.morphs.GetEnumerator();
                while (getEnum.MoveNext())
                {
                    var morphForm = (string) getEnum.Key;
                    if ((Search) getEnum.Value == null)
                        continue;

                    searchResult = (Search) getEnum.Value;
                    if (searchResult.senses == null || searchResult.senses.Count <= 0)
                        continue;

                    Word = morphForm;
                    Console.WriteLine(Word);
                    break;
                }
            }

            if (searchResult.senses != null)
                Walk(searchResult.senses, null, 1);
            DefineDepthMatrix();
        }

        private void Walk(SynSetList synSets, SynSet fromSynSet, int depth)
        {
            foreach (SynSet synSet in synSets)
            {
                AddWordSenses(fromSynSet, synSet, depth);

                if (synSet.senses != null)
                    Walk(synSet.senses, synSet, depth + 1);
            }

        }

        private void AddWordSenses(SynSet fromSynSet, SynSet toSynSet, int depth)
        {
            SynWord[toSynSet.hereiam] = toSynSet.words[0].word;
            if (fromSynSet != null)
                DepthMatrix[GetKey(fromSynSet.hereiam, toSynSet.hereiam)] = 1;
            if (!Distance.ContainsKey(toSynSet.hereiam))
            {
                Distance[toSynSet.hereiam] = depth;
            }
            else
            {
                int bestDepth = (int)Distance[toSynSet.hereiam];

                if (bestDepth > depth)
                    Distance[toSynSet.hereiam] = depth;
            }
        }

        private void DefineDepthMatrix()
        {
            var rootnodes = new ArrayList();
            foreach (int k in Distance.Keys)
            {
                foreach (int i in Distance.Keys)
                {
                    var ikKey = GetKey(i, k);
                    if (i != k && DepthMatrix.ContainsKey(ikKey))
                    {
                        foreach (int j in Distance.Keys)
                        { 
                            var kjKey = GetKey(k, j);
                            if (i != j && j != k && DepthMatrix.ContainsKey(kjKey))
                            {
                                var ijKey = GetKey(i, j);
                                var depth = (int) DepthMatrix[ikKey] + (int) DepthMatrix[kjKey];
                                if (!DepthMatrix.ContainsKey(ijKey) || (int) DepthMatrix[ijKey] > depth)
                                {
                                    DepthMatrix[ijKey] = depth;
                                }
                            }
                        }
                    }
                }
            }

            foreach (int i in Distance.Keys)
            {
                bool isRooted = true;
                foreach (var j in from int j in Distance.Keys where DepthMatrix.ContainsKey(GetKey(i, j)) select j)
                    isRooted = false;

                if (isRooted) rootnodes.Add(i);
            }

            _rootNodes = (int[])rootnodes.ToArray(typeof(int));
        }

        private static object GetKey(object i, object j)
        {
            var encodeI = Math.Log10(Convert.ToDouble(i));
            var encodeJ = Math.Log10(Convert.ToDouble(j));            
            return encodeI * 1000.0d + encodeJ;
        }

        private static Opt GetSearchType(PartsOfSpeech pos)
        {
            switch (pos)
            {
                case PartsOfSpeech.Noun:
                    return Opt.at(11);
                case PartsOfSpeech.Verb:
                    return Opt.at(33);
                default:
                    return null;
            }
        }
    }
}
