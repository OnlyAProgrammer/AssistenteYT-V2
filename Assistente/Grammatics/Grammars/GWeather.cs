using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistente.Grammatics.Grammars
{
    [Grammar(typeof(GWeather))]
    internal sealed class GWeather : GrammarBase
    {
        public GWeather() : base(GrammarType.Weather.ToString()) { }

        [GrammarPointReturnable]
        public static GrammarPoint GetTemperatureGrammarPoint()
        {
            var inputs = new string[]
            {
                "Qual é a temperatura",
                "Temperatura de agora",
            };

            return new GrammarPoint(inputs, GrammarSubType.Temperature);
        }
    }
}