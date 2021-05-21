using System.Speech.Synthesis;
using System;

namespace Assistente.Engine
{
    internal sealed class SynthesizerEngine
    {
        internal delegate void SpeakStarted(SpeakStartedEventArgs e);
        internal delegate void SpeakProgress(SpeakProgressEventArgs e);
        internal delegate void SpeakCompleted(SpeakCompletedEventArgs e);

        internal event SpeakStarted SpeakStarting;
        internal event SpeakProgress SpeakInProgress;
        internal event SpeakCompleted SpeakComplete;

        internal SynthesizerEngine()
        {
            Synthesizer = new SpeechSynthesizer();
            Synthesizer.SetOutputToDefaultAudioDevice();

            Synthesizer.SpeakStarted += Synthesizer_SpeakStarted;
            Synthesizer.SpeakProgress += Synthesizer_SpeakProgress;
            Synthesizer.SpeakCompleted += Synthesizer_SpeakCompleted;
        }

        private SpeechSynthesizer Synthesizer { get; }

        #region Eventos
        private void Synthesizer_SpeakStarted(object sender, SpeakStartedEventArgs e) => SpeakStarting?.Invoke(e);
        private void Synthesizer_SpeakProgress(object sender, SpeakProgressEventArgs e) => SpeakInProgress?.Invoke(e);
        private void Synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e) => SpeakComplete?.Invoke(e);
        #endregion

        internal void Speak(string text)
        {
            if (Synthesizer.State.Equals(SynthesizerState.Speaking))
                Synthesizer.SpeakAsyncCancelAll();
            Synthesizer.SpeakAsync(text);
        }

        internal void Speak(string[] options)
            => Speak(options[new Random().Next(0, options.Length)]);

        internal void SpeakSync(string result)
            => Synthesizer.Speak(result);

        internal void SpeakSync(string[] options)
            => SpeakSync(options[new Random().Next(0, options.Length)]);
    }
}
