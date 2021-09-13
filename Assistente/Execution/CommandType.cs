namespace Assistente.Execution
{
    internal enum CommandType
    {
        // System
        x0CallAssistente,
        x0SilenceMode,
        x0TurnOffSystem,
        x0RestartSystem,
        x0DebugOnSystem,
        x0DebugOffSystem,
        x0VoiceChangeSystem,

        // Programs
        x0OpenProgram,
        x0CloseProgram,
        x0DiscordMute,
        x0DiscordDesmute,
        x0InvalidCommand,
    }
}
