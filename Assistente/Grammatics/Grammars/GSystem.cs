using System.Collections.Generic;

namespace Assistente.Grammatics.Grammars
{
    internal sealed class GSystem : GrammarBase
    {
        internal GSystem(GrammarType grammarType) 
            : base(grammarType.ToString(), GetGrammarPoints()) { }

        private static List<GrammarPoint> GetGrammarPoints() => new List<GrammarPoint>()
        {
            GetTurnOfGrammarPoint(),
            GetRestartGrammarPoint(),
            GetDebugModeOnGrammarPoint(),
            GetDebugModeOffGrammarPoint(),
        };

        private static GrammarPoint GetTurnOfGrammarPoint()
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

        private static GrammarPoint GetRestartGrammarPoint()
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

        private static GrammarPoint GetDebugModeOnGrammarPoint()
        {
            var inputs = new string[]
            {
                "Iniciar depuração",
                "Mostrar depuração",
                "Iniciar janela de depuração",
            };

            return new GrammarPoint(inputs, GrammarSubType.DebugModeOn);
        }

        private static GrammarPoint GetDebugModeOffGrammarPoint()
        {
            var inputs = new string[]
            {
                "Fechar depuração",
                "Ocultar depuração",
                "Fechar janela de depuração",
            };

            return new GrammarPoint(inputs, GrammarSubType.DebugModeOff);
        }
    }
}
