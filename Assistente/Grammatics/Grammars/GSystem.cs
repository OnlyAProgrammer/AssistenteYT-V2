namespace Assistente.Grammatics.Grammars
{
    [Grammar(typeof(GSystem))]
    internal sealed class GSystem : GrammarBase
    {
        public GSystem() : base(GrammarType.System.ToString()) { }

        [GrammarPointReturnable]
        public static GrammarPoint GetCallAssistenteGrammarPoint()
        {
            var inputs = new string[]
            {
                "Asssitente",   
            };

            return new GrammarPoint(inputs, GrammarSubType.CallAssistente);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetSilenceModeGrammarPoint()
        {
            var inputs = new string[]
            {
                "Modo silencioso",
                "Ativar modo silencioso",
                "Iniciar modo silencioso",
            };

            return new GrammarPoint(inputs, GrammarSubType.SilenceMode);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetTurnOfGrammarPoint()
        {
            var inputs = new string[]
            {
                "Desligar",
                "Desligue",
                "Desligue o sistema",
                "Desligar o sistema",
            };

            return new GrammarPoint(inputs, GrammarSubType.TurnOff);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetRestartGrammarPoint()
        {
            var inputs = new string[]
            {
                "Reiniciar",
                "Reinicie",
                "Reinicie o sistema",
                "Reiniciar o sistema",
            };

            return new GrammarPoint(inputs, GrammarSubType.Restart);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetDebugModeOnGrammarPoint()
        {
            var inputs = new string[]
            {
                "Iniciar depuração",
                "Mostrar depuração",
                "Iniciar janela de depuração",
            };

            return new GrammarPoint(inputs, GrammarSubType.DebugModeOn);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetDebugModeOffGrammarPoint()
        {
            var inputs = new string[]
            {
                "Fechar depuração",
                "Ocultar depuração",
                "Fechar janela de depuração",
            };

            return new GrammarPoint(inputs, GrammarSubType.DebugModeOff);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetVoiceChangeGrammarPoint()
        {
            var inputs = new string[]
            {
                "Alterar voz",
                "Mudar voz",
                "Trocar voz",
            };

            return new GrammarPoint(inputs, GrammarSubType.VoiceChange);
        }
    }
}