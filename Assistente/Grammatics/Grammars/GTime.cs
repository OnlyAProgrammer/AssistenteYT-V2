namespace Assistente.Grammatics.Grammars
{
    [Grammar(typeof(GTime))]
    internal sealed class GTime : GrammarBase
    {
        public GTime() : base(GrammarType.Time.ToString()) { }

        [GrammarPointReturnable]
        public static GrammarPoint GetWhatTimeIsGrammarPoint()
        {
            var inputs = new string[]
            {
                "Que horas são",
                "Quais são as horas",
                "Que horas é",
            };

            return new GrammarPoint(inputs, GrammarSubType.WhatHourIs);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetWhatDateIsGrammarPoint()
        {
            var inputs = new string[]
            {
                "Que data é hoje",
                "Qual a data de hoje",
                "Qual a data",
            };

            return new GrammarPoint(inputs, GrammarSubType.WhatDateIs);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetWhatDayIsGrammarPoint()
        {
            var inputs = new string[]
            {
                "Que dia é hoje",
                "Qual o dia de hoje",
                "Qual que é o dia de hoje",
            };

            return new GrammarPoint(inputs, GrammarSubType.WhatDayIs);
        }

        [GrammarPointReturnable]
        public static GrammarPoint GetWhatDayOfWeekIsGrammarPoint()
        {
            var inputs = new string[]
            {
                "Que dia da semana é hoje",
                "Qual o dia da semana de hoje",
                "Qual que é o dia da semana de hoje",
            };

            return new GrammarPoint(inputs, GrammarSubType.WhatDayOfWeekIs);
        }
    }
}