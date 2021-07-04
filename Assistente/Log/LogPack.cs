using System;
using System.Collections.Generic;

namespace Assistente.Log
{
    internal static class LogPack
    {
        internal static List<Logs> LogList { get; private set; } = new List<Logs>();

        private static void AddLog(LogType logType, string operation, string result, bool show)
        {
            var logs = new Logs(logType, operation, result);
            LogList.Add(logs);

            if (show)
                Console.WriteLine(logs);
        }

        internal static void AddMessageLog(string message, bool show = true)
            => AddLog(LogType.SYSTEM, message, null, show);

        internal static void AddErrorLog(string operation, Exception e)
            => AddLog(LogType.ERROR, operation, $"{e.Message}\nSource: {e.Source}\nStackTrace: {e.StackTrace}", true);

        internal static void AddGrammarLoadLog(string message, bool show = true)
            => AddLog(LogType.GRAMMAR, message, null, show);

        internal static void AddWarningLog(string operation, string result)
            => AddLog(LogType.WARNING, operation, result, true);

        internal static void AddRejectedLog(string operation, string result)
            => AddLog(LogType.REJECTED, operation, result, true);

        internal static void AddRecognizedLog(string operation, string result)
            => AddLog(LogType.RECOGNIZED, operation, result, true);

        internal static void AddProcessResultLog(string message)
            => AddLog(LogType.OPERATION, message, null, true);
    }
}
