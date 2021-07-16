﻿using Assistente.Grammatics;
using Assistente.Programs;
using System;

namespace Assistente.Execution
{
    internal static class Executer
    {
        internal static string Execute(GrammarSubType grammarSubType, string[] args = null)
        {
            var datetime = DateTime.Now;

            switch (grammarSubType)
            {
                // GSystem
                case GrammarSubType.TurnOff: return CommandType.x0TurnOffSystem.ToString();
                case GrammarSubType.Restart: return CommandType.x0RestartSystem.ToString();
                case GrammarSubType.DebugModeOn: return CommandType.x0DebugOnSystem.ToString();
                case GrammarSubType.DebugModeOff: return CommandType.x0DebugOffSystem.ToString();
                case GrammarSubType.VoiceChange: return CommandType.x0VoiceChangeSystem.ToString();

                // GTime
                case GrammarSubType.WhatHourIs: return $"São {datetime.ToLongTimeString()}";
                case GrammarSubType.WhatDateIs: return $"A data de hoje é {datetime.ToLongDateString()}";
                case GrammarSubType.WhatDayIs: return $"Hoje é dia {datetime.Day}";
                case GrammarSubType.WhatDayOfWeekIs: return $"Hoje é {GetDayOfWeekTranslate(datetime.DayOfWeek)}";

                // GPrograms
                case GrammarSubType.DiscordMute: return CommandType.x0DiscordMute.ToString();
                case GrammarSubType.DiscordDesmute: return CommandType.x0DiscordDesmute.ToString();

                case GrammarSubType.OpenProgram:
                case GrammarSubType.CloseProgram:
                    return ConvertArgument(args).ToString();

                default: return "Entrada de sub-gramatica inválida";
            }
        }

        internal static string Execute(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.x0TurnOffSystem: return "Desligando...";
                case CommandType.x0RestartSystem: return "Reiniciando...";
                case CommandType.x0DebugOnSystem: return "Iniciando janela de depuração";
                case CommandType.x0DebugOffSystem: return "Fechando janela de depuração";
                case CommandType.x0VoiceChangeSystem: return "Abrindo janela de configuração de voz";

                case CommandType.x0DiscordMute: return "Mutando discord";
                case CommandType.x0DiscordDesmute: return "Desmutando discord";
                case CommandType.x0OpenProgram: return "Abrindo...";
                case CommandType.x0CloseProgram: return "Encerrando...";

                default: return "Entrada de commando inválido em Execute";
            }
        }

        internal static void ExecuteCommand(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.x0TurnOffSystem: Program.Exit(); break;
                case CommandType.x0RestartSystem: Program.Restart(); break;
                case CommandType.x0DebugOnSystem: Program.Debug(true); break;
                case CommandType.x0DebugOffSystem: Program.Debug(false); break;
                case CommandType.x0VoiceChangeSystem: Program.OpenVoiceChangeView(); break;
            }
        }

        private static object GetDayOfWeekTranslate(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday: return "Domingo";
                case DayOfWeek.Monday: return "Segunda-feira";
                case DayOfWeek.Tuesday: return "Terça-feira";
                case DayOfWeek.Wednesday: return "Quarta-feira";
                case DayOfWeek.Thursday: return "Quinta-feira";
                case DayOfWeek.Friday: return "Sexta-feira";
                case DayOfWeek.Saturday: return "Sábado";
                default: return dayOfWeek.ToString();
            }
        }

        private static CommandType ConvertArgument(string[] args)
        {
            if (args[0] == "OpenProgram")
            {
                var sucess = ProgramManagement.OpenProgram(args[1], bool.Parse(args[2]));
                // TODO

                return CommandType.x0OpenProgram;
            }
            else if (args[0] == "CloseProgram")
            {
                var sucess = ProgramManagement.CloseProgram(args[1]);
                // TODO

                return CommandType.x0CloseProgram;
            }

            return CommandType.x0InvalidCommand;
        }
    }
}
