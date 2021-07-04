using Assistente.Engine;
using Assistente.Execution;
using Assistente.Grammatics;
using Assistente.Log;
using Microsoft.Speech.Recognition;
using System;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Assistente.View
{
    internal sealed partial class MainView : Form
    {
        // SubViews
        private VoiceChangeView voiceChangeView;

        internal MainView()
        {
            InitializeComponent();
            Synthesizer = new SynthesizerEngine();
            Recognizer = new RecognitionEngine(new System.Globalization.CultureInfo("pt-BR"));
            Recognizer.LoadGrammarCompleted += GrammarLoaded;
        }

        internal SynthesizerEngine Synthesizer { get; }
        internal RecognitionEngine Recognizer { get; }

        private void MainView_Load(object sender, EventArgs e)
            => Recognizer.Start();

        private void Recognized(string grammarName, string input, float confidence)
        {
            if (confidence < PRController.Confidence)
            {
                Rejected(grammarName, input, confidence);
                return;
            }

            if (!Enum.TryParse<GrammarType>(grammarName, out var grammarType))
                LogPack.AddWarningLog($"TryParse falhou em extrair de '{grammarName}'", $"Parsing result: {grammarType}");

            var result = string.Empty;
            var gGrammar = GrammarStructure.GetGrammarByType(grammarType);

            foreach (var gp in gGrammar.GrammarPoints)
            {
                if (gp.Inputs.Any(s => s == input))
                    result = Executer.Execute(gp.GrammarSubType);
            }

            // Executa um commando caso a entrada seja uma entrada de comando
            if (Enum.TryParse<CommandType>(result, out var commandType))
            {
                result = Executer.Execute(commandType);
                LogPack.AddRecognizedLog(input, result);
                Synthesizer.SpeakSync(result);

                Executer.ExecuteCommand(commandType, out result);

                if (!string.IsNullOrEmpty(result) && !string.IsNullOrWhiteSpace(result))
                {
                    Synthesizer.Speak(result);
                    LogPack.AddProcessResultLog($"Resultado da última operação: \"{result}\"");
                }

                return;
            }

            LogPack.AddRecognizedLog(input, result);
            Synthesizer.Speak(result);
        }

        private void Rejected(string grammarName, string input, float confidence)
        {
            if (!Enum.TryParse<GrammarType>(grammarName, out var grammarType))
                LogPack.AddWarningLog($"TryParse falhou em extrair de '{grammarName}'", $"Parsing result: {grammarType}");

            LogPack.AddRejectedLog($"Entrada recebida: '{input}' com {confidence} de conficende na gramatica '{grammarType}'", "Entrada rejeitada");

            if (confidence > 0.25)
                Synthesizer.Speak(Builder.RejectedReturns);
        }

        #region Synthesizer Events
        internal void SpeakStarted(SpeakStartedEventArgs e)
        {
            // TODO:
        }

        internal void SpeakInProgress(SpeakProgressEventArgs e)
        {
            // TODO:
        }

        internal void SpeakCompleted(SpeakCompletedEventArgs e)
        {
            // TODO:
        }
        #endregion

        #region Recognizer Events
        internal void GrammarLoaded(object sender, LoadGrammarCompletedEventArgs e)
            => LogPack.AddGrammarLoadLog($"'{e.Grammar.Name}' carregada!");

        internal void SpeechDetected(object sender, SpeechDetectedEventArgs e)
            => Console.WriteLine("Detectando...");

        internal void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            => Recognized(e.Result.Grammar.Name, e.Result.Text, e.Result.Confidence);

        internal void SpeechRejected(object sender, SpeechRecognitionRejectedEventArgs e)
            => Rejected(e.Result.Grammar == null ? "" : e.Result.Grammar.Name, e.Result.Text, e.Result.Confidence);
        #endregion

        internal void OpenVoiceChangeView()
        {
            if (voiceChangeView != null)
            {
                voiceChangeView.Dispose();
                voiceChangeView = null;
            }
            voiceChangeView = new VoiceChangeView(SynthesizerEngine.GetVoices());
            voiceChangeView.TestVoice += View_TestVoice;
            voiceChangeView.ApplyVoice += View_ApplyVoice;
            voiceChangeView.Show();
        }

        private void View_ApplyVoice(string voiceName)
        {
            LogPack.AddMessageLog($"Aplicando voz: {voiceName}");
            Synthesizer.ApplyVoice(voiceName);
            PRController.VoiceName = voiceName;
            PRController.Save();
            Synthesizer.Speak("Voz aplicada com sucesso!");

            if (voiceChangeView != null)
            {
                voiceChangeView.Dispose();
                voiceChangeView = null;
            }
        }

        private void View_TestVoice(string voiceName)
        {
            LogPack.AddMessageLog($"Testando voz: {voiceName}");
            Synthesizer.TestVoice(voiceName);
        }
    }
}
