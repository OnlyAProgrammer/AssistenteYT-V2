using Assistente.Grammatics;

namespace Assistente.Execution
{
    class Executer
    {
        internal static string Execute(GrammarSubType grammarSubType)
        {
            switch (grammarSubType)
            {
                case GrammarSubType.TurnOff: return CommandType.x0TurnOffSystem.ToString();
                case GrammarSubType.Restart:
                    break;
                case GrammarSubType.DebugModeOn:
                    break;
                case GrammarSubType.DebugModeOff:
                    break;
                case GrammarSubType.WhatHourIs:
                    break;
                case GrammarSubType.WhatDateIs:
                    break;
                case GrammarSubType.WhatDayIs:
                    break;
                case GrammarSubType.WhatDayOfWeekIs:
                    break;
                default: return "Entrada de sub-gramatica inválida";
            }

            return "";
        }

        internal static string Execute(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.x0TurnOffSystem: return "Desligando...";
                default: return "Entrada de commando inválido em Execute";
            }
        }

        internal static void ExecuteCommand(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.x0TurnOffSystem: Program.Exit(); break;
            }
        }
    }
}
