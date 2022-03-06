using System.Collections.Generic;

namespace Assistente.Grammatics
{
    internal sealed class CommandOrganizer
    {
        internal CommandOrganizer(Dictionary<string, Dictionary<string, List<string>>> commandKeyAndOptions)
        {
            CommandKeyAndOptions = commandKeyAndOptions;
        }

        internal Dictionary<string, Dictionary<string, List<string>>> CommandKeyAndOptions { get; }
    }
}