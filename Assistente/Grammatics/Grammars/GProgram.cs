using Assistente.Grammatics;
using Assistente.Programs;
using System.Collections.Generic;

namespace Assistente.Grammatics.Grammars
{
    [Grammar(typeof(GProgram))]
    internal sealed class GProgram : GrammarBase
    {
        public GProgram() : base(GrammarType.Programs.ToString(), GetGrammarChainPoints()) { }

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

        // GrammarPoints
        [GrammarPointReturnable]
        public static GrammarPoint GetDiscordMuteGrammarPoint()
        {
            var inputs = new string[]
            {
                "Mutar discord",
                "Mute discord",
            };

            return new GrammarPoint(inputs, GrammarSubType.DiscordMute);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetDiscordDesmuteGrammarPoint()
        {
            var inputs = new string[]
            {
                "Desmutar discord",
                "Desmute discord",
            };

            return new GrammarPoint(inputs, GrammarSubType.DiscordDesmute);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetCommandsListGrammarPoint()
        {
            var inputs = new string[]
            {
                "Lista de comandos",
                "Me mostre a lista de comandos",
                "Mostrar lista de comandos"
            };

            return new GrammarPoint(inputs, GrammarSubType.CommandsList);
        }
    }
}