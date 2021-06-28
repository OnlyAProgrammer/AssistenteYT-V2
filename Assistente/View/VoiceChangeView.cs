using Assistente.Engine;
using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Assistente.View
{
    internal sealed partial class VoiceChangeView : Form
    {
        internal delegate void VoiceTest(string voiceName);
        internal event VoiceTest TestVoice;

        internal delegate void VoiceApply(string voiceName);
        internal event VoiceApply ApplyVoice;

        private string voiceName;
       
        internal VoiceChangeView(IReadOnlyCollection<InstalledVoice> instaledVoices)
        {
            InitializeComponent();

            foreach (var voice in instaledVoices)
                listViewVoices.Items.Add(new Voice(voice.VoiceInfo).ToString());
        }

        private void ListViewVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var item = listViewVoices.SelectedItems[0];
                voiceName = Voice.GetName(item.Text);
            }
            catch
            {
                return;
            }
        }

        private void ButtonTest_Click(object sender, EventArgs e) => TestVoice?.Invoke(voiceName);

        private void ButtonApply_Click(object sender, EventArgs e) => ApplyVoice?.Invoke(voiceName);
    }
}
