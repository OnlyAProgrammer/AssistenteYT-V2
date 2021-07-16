using Assistente.Grammatics;
using Assistente.Programs;
using System.Collections.Generic;

namespace Assistente.Grammatics.Grammars
{
    internal sealed class GPrograms : GrammarBase
    {
        internal GPrograms(GrammarType grammarType) : base(grammarType.ToString(), GetGrammarPoints(), GetGrammarChainPoints()) { }

        private static List<GrammarPoint> GetGrammarPoints()
        {
            return new List<GrammarPoint>()
            {
                GetDiscordMuteGrammarPoint(),
                GetDiscordDesmuteGrammarPoint(),
            };
        }

        private static List<GrammarChainPoint> GetGrammarChainPoints()
        {
            var openProgramsChain = new GrammarChainPoint(GrammarSubType.OpenProgram, new List<string[]>
            {
                GetOpenProgramGrammarPoint().Inputs,
                GetProgramsGrammarPoint().Inputs,
            });

            var closeProgramsChain = new GrammarChainPoint(GrammarSubType.CloseProgram, new List<string[]>
            {
                GetCloseProgramGrammarPoint().Inputs,
                GetProgramsGrammarPoint().Inputs
            });

            return new List<GrammarChainPoint>()
            {
                openProgramsChain,
                closeProgramsChain,
            };
        }

        // GrammarPoints
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

        private static GrammarPoint GetOpenProgramGrammarPoint()
        {
            var inputs = new string[]
            {
                "Abrir programa",
                "Abrir",
                "Iniciar programa",
                "Iniciar"
            };

            return new GrammarPoint(inputs, GrammarSubType.Null);
        }

        private static GrammarPoint GetCloseProgramGrammarPoint()
        {
            var inputs = new string[]
            {
                "Encerrar programa",
                "Encerrar",
                "Fechar programa",
                "Fechar"
            };

            return new GrammarPoint(inputs, GrammarSubType.Null);
        }

        private static GrammarPoint GetProgramsGrammarPoint()
        {
            var values = ProgramManagement.ProgramsDic.Keys;
            var inputs = new string[values.Count];
            var count = 0;

            foreach (var val in values)
            {
                inputs[count] = val;
                count++;
            }

            return new GrammarPoint(inputs, GrammarSubType.Null);
        }
    }
}
