using Assistente.Grammatics.Grammars;

namespace Assistente.Grammatics
{
    internal static class GrammarStructure
    {
        internal static GrammarBase GetGrammarByType(GrammarType grammarType)
        {
            switch (grammarType)
            {
                case GrammarType.System: return new GSystem();
                case GrammarType.Time: return new GTime();
                case GrammarType.Programs: return new GProgram();
                default: return null;
            }
        }
    }
}
