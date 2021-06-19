using Assistente.Engine;
using Assistente.Log;
using System;
using System.Windows.Forms;

namespace Assistente.View
{
    internal sealed partial class LoadingView : Form
    {
        internal LoadingView()
        {
            InitializeComponent();
            Text = $"{PRController.Name} carregando...";
            Icon = PRController.Icon;
        }

        private void LoadingView_Load(object sender, EventArgs @event)
        {
            LogPack.AddMessageLog("Iniciando carregamento do sistema");

            try
            {
                var syn = new SynthesizerEngine();
                syn.Speak("Carregando");

                #region MainView
                var mainView = new MainView();
                LogPack.AddMessageLog("MainView Carregado!");
                #endregion

                #region Carrega eventos do synthesizer
                mainView.Synthesizer.SpeakStarting += mainView.SpeakStarted;
                mainView.Synthesizer.SpeakInProgress += mainView.SpeakInProgress;
                mainView.Synthesizer.SpeakComplete += mainView.SpeakCompleted;
                #endregion

                #region Carrega eventos do recognizer
                mainView.Recognizer.SpeechDetected += mainView.SpeechDetected;
                mainView.Recognizer.SpeechRecognized += mainView.SpeechRecognized;
                mainView.Recognizer.SpeechRecognitionRejected += mainView.SpeechRejected;
                #endregion

                LogPack.AddMessageLog("Sistema carregado com sucesso!");
                Program.Switch(this, mainView);
            }
            catch (Exception e)
            {
                LogPack.AddErrorLog("Carregando sistema", e);
            }
        }
    }
}
