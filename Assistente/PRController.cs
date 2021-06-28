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

        internal static string DataPath
        {
            get
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.DataPath) ||
                    string.IsNullOrWhiteSpace(Properties.Settings.Default.DataPath))
                {
                    var hdname = System.Environment.GetLogicalDrives()[0];
                    var username = System.Environment.UserName;

                    return $"{hdname}\\Users\\{username}\\Documents\\{Name}";
                }

                return Properties.Settings.Default.DataPath;
            }

            set { Properties.Settings.Default.DataPath = value; }
        }

        internal static string VoiceName
        {
            get { return Properties.Settings.Default.VoiceName; }
            set { Properties.Settings.Default.VoiceName = value; }
        }

        internal static void Save() => Properties.Settings.Default.Save();
    }
}
