using System.Collections.Generic;

namespace Assistente.Grammatics
{
    internal abstract class GrammarBase
    {
        protected GrammarBase(string name, List<GrammarPoint> grammarPoints)
        {
            Name = name;
            GrammarPoints = grammarPoints;
        }

        internal string Name { get; }
        internal List<GrammarPoint> GrammarPoints { get; }
    }
}
