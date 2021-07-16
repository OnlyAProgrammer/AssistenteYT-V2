using System.Collections.Generic;

namespace Assistente.Grammatics
{
    internal sealed class GrammarChainPoint
    {
        internal GrammarChainPoint(GrammarSubType grammarSubType, List<string[]> inputs)
        {
            GrammarSubType = grammarSubType;
            Inputs = inputs;
        }

        internal GrammarSubType GrammarSubType { get; }
        internal List<string[]> Inputs { get; }

        internal List<GrammarPoint> GenerateGrammarPoint()
        {
            var grammarPoints = new List<GrammarPoint>();

            string[] gen = CombineList(Inputs[0], Inputs[1]);

            for (int i = 2; i < Inputs.Count; i++)
                gen = CombineList(gen, Inputs[i]);

            grammarPoints.Add(new GrammarPoint(gen, GrammarSubType));

            return grammarPoints;
        }

        // abre, abra, inicie
        // o programa, o bloco de notas, a geladeira
        private string[] CombineList(string[] vs1, string[] vs2)
        {
            var k = 0;
            var result = new string[vs1.Length * vs2.Length];

            foreach(var c1 in vs1)
            {
                foreach(var c2 in vs2)
                {
                    result[k] = $"{c1} {c2}";
                    k++;
                }
            }

            return result;
        }
    }
}
