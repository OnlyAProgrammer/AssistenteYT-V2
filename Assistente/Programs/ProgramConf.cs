namespace Assistente.Programs
{
    internal sealed class ProgramConf
    {
        internal ProgramConf(string processName, bool useShell)
        {
            ProcessName = processName;
            UseShell = useShell;
        }

        internal string ProcessName { get; }
        internal bool UseShell { get; }
    }
}
