using Assistente.Log;
using Assistente.View;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Assistente
{
    internal static class Program
    {
        private static Form currentForm;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmd);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        [STAThread]
        internal static void Main()
        {
            _ = new Mutex(true, PRController.Name, out var createNew);
            LogPack.AddMessageLog("Instancia mutex criado");

            if (!createNew)
            {
                MessageBox.Show($"{PRController.Name} já esta aberto, não é possível executar dois ao mesmo tempo!", "Aviso", MessageBoxButtons.OK);
                return;
            }
            LogPack.AddMessageLog("Verificação mutex, programa não estava iniciado, inciando o programa.");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogPack.AddMessageLog("Iniciando LoadingView");
            currentForm = new LoadingView();
            Application.Run(currentForm);
        }

        internal static void Debug(bool debugMode)
        {
            PRController.DebugMode = debugMode;
            ShowWindow(GetConsoleWindow(), debugMode ? SW_SHOW : SW_HIDE);
        }

        internal static void Switch(Form origin, Form target)
        {
            origin.WindowState = FormWindowState.Minimized;
            origin.Hide();
            origin.Visible = false;
            origin.Enabled = false;
            origin.ShowInTaskbar = false;

            currentForm = target;

            target.Closed += (s, e) => origin.Close();
            target.Show();
            target.WindowState = FormWindowState.Normal;
        }

        internal static void Exit()
        {
            GenerateLog();
            Application.Exit();
        }
        internal static void Restart() => Application.Restart();

        internal static void GenerateLog() => DataControl.RWController.SaveLog();

        internal static void OpenVoiceChangeView()
        {
            if (currentForm is MainView mv)
                mv.OpenVoiceChangeView();
        }

        internal static void OpenCommandsList()
        {
            if (currentForm is MainView mv)
                mv.OpenCommandsList();
        }
    }
}
