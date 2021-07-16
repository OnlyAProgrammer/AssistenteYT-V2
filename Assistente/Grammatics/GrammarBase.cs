using System.Collections.Generic;

namespace Assistente.Grammatics
{
    internal abstract class GrammarBase
    {
        protected GrammarBase(string name, List<GrammarPoint> grammarPoints, List<GrammarChainPoint> grammarChain = null)
        {
            Name = name;
            GrammarPoints = grammarPoints;
            GrammarChain = grammarChain;

            if (grammarChain != null)
            {
                foreach(var chain in grammarChain)
                {
                    GrammarPoints.AddRange(chain.GenerateGrammarPoint());
                }
            }
        }

        internal string Name { get; }
        internal List<GrammarPoint> GrammarPoints { get; }
        internal List<GrammarChainPoint> GrammarChain { get; }
    }
}
