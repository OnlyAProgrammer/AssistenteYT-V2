using Assistente.Grammatics.Grammars;
using Microsoft.Speech.Recognition;
using System.Collections.Generic;

namespace Assistente.Grammatics
{
    internal static class Builder
    {
        internal static string[] RejectedReturns = new string[]
        {
            "Não entendi",
            "Perdão não entendi",
            "Desculpe não entendi",
            "Não compreendi"
        };

        internal static List<Grammar> GetGrammars()
        {
            var grammars = new List<Grammar>();
            var grammarBases = GetGrammarBases();

            foreach (var gb in grammarBases)
            {
                var choices = new Choices();

                foreach (var gp in gb.GrammarPoints)
                {
                    choices.Add(gp.Inputs);
                }

                var grammarbuilder = new GrammarBuilder(choices);
                grammars.Add(new Grammar(grammarbuilder) { Name = gb.Name });
            }

            return grammars;
        }

        private static List<GrammarBase> GetGrammarBases() => new List<GrammarBase>()
        {
            new GSystem(GrammarType.System),
            new GTime(GrammarType.Time),
            new GPrograms(GrammarType.Programs),
        };
    }
}
