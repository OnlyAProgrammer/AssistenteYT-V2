using Assistente.Engine;
using Assistente.Execution;
using Assistente.Grammatics;
using Assistente.Grammatics.Grammars;
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
        internal static RecognitionState RecognitionState = RecognitionState.NORMAL;

        // SubViews
        private VoiceChangeView voiceChangeView;
        private CommandListView commandListView;

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

        private void Rejected(string grammarName, string input, float confidence)
        {
            if (!Enum.TryParse<GrammarType>(grammarName, out var grammarType))
                LogPack.AddWarningLog($"TryParse falhou em extrair de '{grammarName}'", $"Parsing result: {grammarType}");

            LogPack.AddRejectedLog($"Entrada recebida: '{input}' com {confidence} de conficende na gramatica '{grammarType}'", "Entrada rejeitada");

            if (confidence > 0.25 && RecognitionState != RecognitionState.SILENCE_MODE)
                Synthesizer.Speak(Builder.RejectedReturns);
        }

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

            switch (RecognitionState)
            {
                case RecognitionState.SILENCE_MODE:
                    {
                        if (!(gGrammar is GSystem gs)) return;

                        foreach(var gp in gs.GrammarPoints)
                        {
                            // Se o input for diferente das entradas na lista
                            // ou o gramamrSubType for diferente de CallAssistente
                            // passa para o prox valor

                            if (!gp.Inputs.Any(s => s == input) ||
                                gp.GrammarSubType != GrammarSubType.CallAssistente)
                                continue;

                            result = Executer.Execute(GrammarSubType.CallAssistente);
                            SpeakExecutionResult(input, gGrammar, result);
                            break;
                        }

                        break;
                    }
                case RecognitionState.NORMAL: default:
                    SpeakExecutionResult(input, gGrammar, result); break;
            }
        }

        private void SpeakExecutionResult(string input, GrammarBase gGrammar, string result)
        {
            foreach (var gp in gGrammar.GrammarPoints)
            {
                if (gp.Inputs.Any(s => s == input)) // bom dia == input
                {
                    string[] args = new string[3];

                    if (gp.GrammarSubType.Equals(GrammarSubType.OpenProgram) ||
                        gp.GrammarSubType.Equals(GrammarSubType.CloseProgram))
                    {
                        args[0] = gp.GrammarSubType.ToString();

                        foreach (var prog in Programs.ProgramManagement.ProgramsDic.Keys)
                        {
                            if (input.Contains(prog))
                            {
                                args[1] = Programs.ProgramManagement.ProgramsDic[prog].ProcessName;
                                args[2] = Programs.ProgramManagement.ProgramsDic[prog].UseShell.ToString();
                                break;
                            }
                        }
                    }

                    result = Executer.Execute(gp.GrammarSubType, args);
                    break;
                }
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

        internal void OpenCommandsList()
        {
            if (commandListView != null)
            {
                commandListView.Dispose();
                commandListView = null;
            }

            commandListView = new CommandListView();
            commandListView.Show();
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
