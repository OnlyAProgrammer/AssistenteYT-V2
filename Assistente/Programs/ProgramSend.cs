using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Assistente.Programs
{
    internal static class ProgramSend
    {
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWind);

        internal static bool SendHotKeyToProcess(string processName, HotKey prekey, string key)
        {
            try
            {
                var proc = Process.GetProcessesByName(processName)[0];
                SetForegroundWindow(proc.MainWindowHandle);
                SendKeys.Send(BuildHotKey(prekey, key));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string BuildHotKey(HotKey prekey, string key)
        {
            // CTRL ^
            // SHIFT +
            // ALT %

            switch (prekey)
            {
                case HotKey.CTRL: return $"^({key})";
                case HotKey.SHIFT: return $"+({key})";
                case HotKey.ALT: return $"%({key})";
                case HotKey.CTRL_SHIFT: return $"^+({key})";
                case HotKey.CTRL_ALT: return $"^%({key})";
                case HotKey.CTRL_ALT_SHIFT: return $"^%+({key})";
                default: return $"";
            }
        }
    }
}