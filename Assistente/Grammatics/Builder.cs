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

        internal static List<GrammarBase> GrammarBases = new List<GrammarBase>();

        internal static GrammarBase GetGrammarByType(GrammarType grammarType)
        {
            foreach (var gb in GrammarBases)
                if (gb.Name == grammarType.ToString()) return gb;

            return null;
        }

        internal static List<Grammar> GetGrammars()
        {
            var grammars = new List<Grammar>();
            GrammarBases = GetGrammarBases();

            foreach (var gb in GrammarBases)
            {
                var gatt = (GrammarAttribute)gb.GetType().GetCustomAttribute(typeof(GrammarAttribute));
                gb.GrammarPoints.AddRange(gatt.ExtractGrammarPoints());

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
   
            foreach (var g in GrammarBases)
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
                            where Attribute.IsDefined(o, typeof(GrammarAttribute)) && o.Namespace == nspace
                            select o).ToArray();

            return (from gType in typeList 
                    select (GrammarBase)Activator.CreateInstance(gType, true)).ToList();
        }   
    }
}