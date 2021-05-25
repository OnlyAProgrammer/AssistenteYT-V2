using Assistente.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistente
{
    internal static class Program
    {
        private static Mutex mutex = null;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmd);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        [STAThread]
        internal static void Main()
        {
            mutex = new Mutex(true, PRController.Name, out var createNew);

            if (!createNew)
            {
                MessageBox.Show($"{PRController.Name} já esta aberto, não é possível executar dois ao mesmo tempo!", "Aviso", MessageBoxButtons.OK);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoadingView());
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

            target.Closed += (s, e) => origin.Close();
            target.Show();
            target.WindowState = FormWindowState.Normal;
        }

        internal static void Exit() => Application.Exit();
        internal static void Restart() => Application.Restart();
    }
}
