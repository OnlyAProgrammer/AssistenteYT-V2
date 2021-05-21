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
                case GrammarType.Time:
                case GrammarType.Weather:
                default: return null;
            }
        }
    }
}
