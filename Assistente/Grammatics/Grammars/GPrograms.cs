using System.Collections.Generic;

namespace Assistente.Grammatics.Grammars
{
    internal sealed class GPrograms : GrammarBase
    {
        internal GPrograms(GrammarType grammarType) 
            : base(grammarType.ToString(), GetGrammarPoints()) { }

        private static List<GrammarPoint> GetGrammarPoints()
        {
            return new List<GrammarPoint>()
            {
                GetDiscordMuteGrammarPoint(),
                GetDiscordDesmuteGrammarPoint(),
            };
        }

        private static GrammarPoint GetDiscordMuteGrammarPoint()
        {
            var inputs = new string[]
            {
                "Mutar discord",
                "Mute discord",
            };

            return new GrammarPoint(inputs, GrammarSubType.DiscordMute);
        }

        private static GrammarPoint GetDiscordDesmuteGrammarPoint()
        {
            var inputs = new string[]
            {
                "Desmutar discord",
                "Desmute discord",
            };

            return new GrammarPoint(inputs, GrammarSubType.DiscordDesmute);
        }
    }
}
