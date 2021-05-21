using Assistente.Engine;
using Assistente.Execution;
using Assistente.Grammatics;
using Assistente.Log;
using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistente.View
{
    internal sealed partial class MainView : Form
    {
        internal MainView()
        {
            InitializeComponent();
            Synthesizer = new SynthesizerEngine();
            Recognizer = new RecognitionEngine(new System.Globalization.CultureInfo("pt-BR"));
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
            if (Enum.TryParse<Execution.CommandType>(result, out var commandType))
            {
                result = Executer.Execute(commandType);
                LogPack.AddRecognizedLog(input, result);
                Synthesizer.SpeakSync(result);
                Executer.ExecuteCommand(commandType);
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
            => LogPack.AddGrammarLoadLog($"Gramatica: '{e.Grammar.Name}' carregada!");

        internal void SpeechDetected(object sender, SpeechDetectedEventArgs e)
            => Console.WriteLine("Detectando...");

        internal void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            => Recognized(e.Result.Grammar.Name, e.Result.Text, e.Result.Confidence);

        internal void SpeechRejected(object sender, SpeechRecognitionRejectedEventArgs e)
            => Rejected(e.Result.Grammar == null ? "" : e.Result.Grammar.Name, e.Result.Text, e.Result.Confidence);
        #endregion
    }
}
