namespace Assistente
{
    internal static class PRController
    {
        internal static string Name => Properties.Settings.Default.Name;
        internal static float Confidence => Properties.Settings.Default.Confidence;

        internal static bool DebugMode
        {
            get { return Properties.Settings.Default.DebugMode; }
            set { Properties.Settings.Default.DebugMode = value; }
        }

        internal static System.Drawing.Icon Icon => Properties.Resources.icon;

        internal static void Save() => Properties.Settings.Default.Save();
    }
}
