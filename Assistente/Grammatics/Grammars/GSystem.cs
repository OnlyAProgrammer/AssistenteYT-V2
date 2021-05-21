using System.Collections.Generic;

namespace Assistente.Grammatics.Grammars
{
    internal sealed class GSystem : GrammarBase
    {
        internal GSystem(GrammarType grammarType) 
            : base(grammarType.ToString(), GetGrammarPoints()) { }

        private static List<GrammarPoint> GetGrammarPoints() => new List<GrammarPoint>()
        {
            GetTurnOfGrammarPoint(),
        };

        private static GrammarPoint GetTurnOfGrammarPoint()
        {
            var inputs = new string[]
            {
                "Desligar",
                "Desligue",
                "Desligue o sistema",
                "Desligar o sistema",
            };

            return new GrammarPoint(inputs, GrammarSubType.TurnOff);
        }
    }
}
