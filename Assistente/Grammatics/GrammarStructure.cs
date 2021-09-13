using Assistente.Grammatics.Grammars;

namespace Assistente.Grammatics
{
    internal static class GrammarStructure
    {
        internal static GrammarBase GetGrammarByType(GrammarType grammarType)
        {
            switch (grammarType)
            {
                case GrammarType.System: return new GSystem(grammarType);
                case GrammarType.Time: return new GTime(grammarType);
                case GrammarType.Programs: return new GPrograms(grammarType);
                case GrammarType.Weather:
                default: return null;
            }
        }
    }
}
