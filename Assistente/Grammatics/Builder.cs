using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        internal static string[] CallAssistentReturns = new string[]
        {
            "Oi",
            "Pronto",
            "Estou aqui",
        };

        internal static List<Grammar> GetGrammars()
        {
            var grammars = new List<Grammar>();
            _ = GetVoiceCommands();
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

        internal static CommandOrganizer GetVoiceCommands()
        {
            var voiceCommandsDict = new Dictionary<string, Dictionary<string, List<string>>>();
            var grammars = GetGrammarBases();

            foreach (var g in grammars)
            {
                var commands = new Dictionary<string, List<string>>();

                foreach (var point in g.GrammarPoints)
                    commands.Add(point.GrammarSubType.ToString(), point.Inputs.ToList());

                voiceCommandsDict.Add(g.Name, commands);
            }

            return new CommandOrganizer(voiceCommandsDict);
        }

        private static List<GrammarBase> GetGrammarBases()
        {
            var nspace = "Assistente.Grammatics.Grammars";

            var typeList = (from o in Assembly.GetExecutingAssembly().GetTypes()
                            where o.IsClass && o.Namespace == nspace
                            select o).ToArray();

            return (from gType in typeList 
                    select (GrammarBase)Activator.CreateInstance(gType, true)).ToList();
        }
    }
}
