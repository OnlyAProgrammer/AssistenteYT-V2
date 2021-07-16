namespace Assistente.Grammatics
{
    internal enum GrammarSubType
    {
        Null,

        // System
        TurnOff,
        Restart,
        DebugModeOn,
        DebugModeOff,
        VoiceChange,

        // Time
        WhatHourIs,
        WhatDateIs,
        WhatDayIs,
        WhatDayOfWeekIs,

        // Weather

        // Programs
        OpenProgram,
        CloseProgram,
        DiscordMute,
        DiscordDesmute,
    }
}
