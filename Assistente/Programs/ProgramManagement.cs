using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assistente.Programs
{
    internal static class ProgramManagement
    {
        internal static Dictionary<string, Process> ActiveProcess = new Dictionary<string, Process>();

        internal readonly static Dictionary<string, ProgramConf> ProgramsDic = new Dictionary<string, ProgramConf>()
        {
            {"Bloco de notas", new ProgramConf("notepad", false) },
            {"Notepad", new ProgramConf("notepad", false) },
            {"Cmd", new ProgramConf("cmd", false) },
            {"Prompt de comando", new ProgramConf("cmd", false) },

            // Caminho de execução do programa
            // "Opera", new ProgramConf("C://programa//opera//opera.exe", true) },
        };

        internal static bool OpenProgram(string processName, bool shellExecute)
        {
            try
            {
                var procInfo = new ProcessStartInfo
                {
                    FileName = processName,
                    UseShellExecute = shellExecute,
                };
                var newProcess = Process.Start(procInfo);
                ActiveProcess.Add(processName, newProcess);

                return true;
            }
            catch (Exception e)
            {
                Log.LogPack.AddErrorLog($"Erro ao tentar abrir o programa: {{{processName}}}.", e);
                return false;
            }
        }

        internal static bool CloseProgram(string processName)
        {
            try
            {
                var process = ActiveProcess[processName];
                process.Kill();

                ActiveProcess.Remove(processName);
                Log.LogPack.AddMessageLog($"O processo '{processName}' foi finalizado.");

                return true;
            }
            catch (Exception e)
            {
                Log.LogPack.AddErrorLog($"Erro ao tentar fechar o programa: {{{processName}}}.", e);
                return false;
            }
        }
    }
}
