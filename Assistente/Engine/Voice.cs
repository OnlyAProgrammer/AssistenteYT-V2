using System.Speech.Synthesis;

namespace Assistente.Engine
{
    internal sealed class Voice
    {
        internal Voice(VoiceInfo voiceInfo)
        {
            VoiceInfo = voiceInfo;
        }

        internal VoiceInfo VoiceInfo { get; }

        internal static string GetName(string fullDescription)
        {
            try
            {
                var name = fullDescription.Split(',')[0];
                return name;
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
            => $"{VoiceInfo.Name}, {VoiceInfo.Gender}, {VoiceInfo.Age}, {VoiceInfo.Culture}";
    }
}
